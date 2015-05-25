using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using meridian.smolensk.impl.Interfaces;
using meridian.smolensk.system;
using smolensk.common;

namespace meridian.smolensk.proto
{
    public partial class ad_advertisments : IViewableMaterial, IFavorite, ILookupValueAspectProvider, IAttachedPhotoAspectProvider, IDictionaryValuesAspectProvider
    {
        public ILookupValueAspect Getcategory_idLookupValueAspect()
        {

            return new LookupAspect("category_id", this, () =>
            {
                var categories = Meridian.Default.ad_categoriesStore.All();
                var parentCategories = categories.Where(s => s.parent_id == 0);
                var res = new List<ILookupValue>();

                foreach (var pc in parentCategories)
                {
                    res.Add(pc);
                    res.AddRange(categories.Where(s => s.parent_id == pc.id));
                }

                return res;
            });
        }

        public ILookupValueAspect Getaccount_idLookupValueAspect()
        {
            return new LookupAspect("account_id", this, () => { return Meridian.Default.accountsStore.All(); });
        }

        public int ViewsCount
        {
            get { return view_count; } 
            private set { view_count = value; }
        }
        
        public void IncrementViewsCount()
        {
            ViewsCount++;
            Meridian.Default.ad_advertismentsStore.Update(this);
        }

        public Dictionary<string, string> GetSingleValueProperties()
        {
            var result = new Dictionary<string, string>();
            
            foreach (var field in AdFields)
            {
                var fieldDescription = Meridian.Default.ad_field_descriptionsStore.Get(field.description_id);

                if (fieldDescription.is_multiple) continue;

                string value;

                if (field.value_id > 0)
                {
                    var lookupValue = Meridian.Default.ad_lookup_valuesStore.Get(field.value_id);
                    value = lookupValue.value;
                }
                else
                {
                    value = field.value;
                }

                result.Add(fieldDescription.title, value);
            }

            return result;
        }

        public string PhotoUrl 
        { 
            get
            {
                return Photos.Any() ? getMainPhoto().PhotoUrl : Constants.AdvertsNoPhoto;
            } 
        }

        public string PreviewPhotoUrl
        {
            get
            {
                return Photos.Any() ? getMainPhoto().PreviewUrl : Constants.AdvertsNoPhotoInList;
            }
        }

        private ad_photos getMainPhoto()
        {
            return Photos.Where(p => p.is_main).FirstOrDefault() ?? Photos.FirstOrDefault();
        }

        public long ParentCategoryId
        {
            get
            {
                return 
                    Meridian.Default.ad_categoriesStore.Exists(category_id) ?
                    Meridian.Default.ad_categoriesStore.Get(category_id).ParentCategoryId : 0;
            }
        }

        public List<string> GetWords()
        {
            return
                title.ToLower().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                     .Where(word => word.Length > 3)
                     .Take(3)
                     .ToList();
        } 

        public List<ad_advertisments> GetSimilarAds()
        {
            var result = new List<ad_advertisments>();

            ad_field_descriptions desc = Meridian.Default.ad_field_descriptionsStore.All()
                        .FirstOrDefault(item => item.ad_category_id == ParentCategoryId && item.title == "Тип предложения");
            
            if (desc != null)
            {
                ad_fields field = Meridian.Default.ad_fieldsStore.All().FirstOrDefault(item => item.ad_id == id && item.description_id == desc.id);

                if (field != null)
                {
                    List<ad_advertisments> similarAds =
                        Meridian.Default.ad_fieldsStore.All()
                                .Where(item =>
                                       item.description_id == desc.id && item.value_id == field.value_id &&
                                       item.ad_id != id)
                                .Select(item => Meridian.Default.ad_advertismentsStore.Get(item.ad_id)).
                                Where(ad => ad.GetWords().Intersect(GetWords()).Any()).Take(5).ToList();
                    
                    return similarAds;
                }
            }
            
            return result;
        }

        public bool IsFavorite(long account_id)
        {
            return Meridian.Default.accounts_favoritesStore.All().Any(f => f.account_id == account_id && f.ad_id == this.id);
        }

        public void AddToFavorite(long account_id)
        {
            Meridian.Default.accounts_favoritesStore.Insert(
                new accounts_favorites() { account_id = account_id, ad_id = this.id });
        }

        public void DeleteFromFavorite(long account_id)
        {
            var fs = Meridian.Default.accounts_favoritesStore.All().FirstOrDefault(f => f.account_id == account_id && f.ad_id == this.id);
            if (fs == null) return;
            Meridian.Default.accounts_favoritesStore.Delete(fs);
        }

        public void Delete()
        {
            Meridian.Default.ad_advertismentsStore.Delete(this);

            var photos = Meridian.Default.ad_photosStore.All().Where(item => item.ad_id == id).ToArray();

            foreach (var photo in photos)
            {
                photo.Delete();
            }

            var fields = Meridian.Default.ad_fieldsStore.All().Where(item => item.ad_id == id).ToArray();
            foreach (var field in fields)
                Meridian.Default.ad_fieldsStore.Delete(field);
        }

        public Uri ItemUri()
        {
            string uri = string.Format("/Adverts/One/{0}/{1}", this.id, this.title.TransliterateAndClear());

            return new Uri(uri, UriKind.Relative);
        }

        public IAttachedPhotoAspect GetAttachedPhotoAspect(string _fieldName)
        {
            return new AdvertsPhotosAspect(this);
        }

        #region Implementation of IDictionaryValuesAspectProvider
        public IDictionaryValuesAspect GetDictionaryValuesAspect(string _fieldName)
        {
            return new DictionaryAspect<ad_field_descriptions, ad_fields>(
                            this,
                            "AdFields",
                            () => Meridian.Default.ad_field_descriptionsStore.GetDescriptionsByCategory(this.category_id),
                            () => this.AdFields,
                            (a, b) =>
                            {
                                var entries = AdFields.Where(s => b != 0 ? s.ValueId.Equals(b) : s.Category != null && s.Category.id.Equals(a)).ToArray();
                                foreach (var e in entries) this.RemoveAdFields(e, true);
                            },
                            (a, b, c) =>
                            {
                                var existing = AdFields.Where(s => s.Category != null && s.Category.id == a).ToArray();

                                if (existing.Count() >= 1)
                                {
                                    var category = existing.First().Category;

                                    if (category.MultiValue)
                                    {
                                        if (existing.Any(s => s.ValueId.Equals(b)))
                                        {
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        for (int i = 1; i < existing.Length; ++i)
                                        {
                                            RemoveAdFields(existing[i], true);
                                        }
                                        if (!category.FreeValue)
                                            existing[0].ValueId = b;
                                        else
                                            existing[0].FreeValue = c;

                                        return;
                                    }


                                }

                                this.AddAdFields(new ad_fields()
                                {
                                    ad_id = id,
                                    value_id = b,
                                    description_id = a,
                                    value = c

                                }, true);
                            }
                            );
        }
        #endregion
    }
}
