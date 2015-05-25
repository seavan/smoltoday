using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace admin.common
{
    public enum LinkType
    {
        ltOneToOne, ltOneToMany, ltManyToMany, ltChild
    }

    public enum LinkMode
    {
        ltGrid, ltComboBox, ltInline
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class LinkAttribute : Attribute
    {
        public LinkType LinkType { get; set; }
        public LinkMode LinkMode { get; set; }
        public string ThisKeyName { get; set; }
        public string ForeignKeyName { get; set; }
        public string DisplayField { get; set; }
        public string ThisLinkTable { get; set; }
        public string Template { get; set; }
        public string Controller { get; set; }
        public object Param { get; set; }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class ManyToManyLinkAttribute : LinkAttribute
    {
        public ManyToManyLinkAttribute()
        {
            LinkType = LinkType.ltManyToMany;
        }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class GroupAttribute : Attribute
    {
        public GroupAttribute()
        {
            
        }

        public string GroupFieldName { get; set; }

        public string GroupFieldValue { get; set; }
    }


    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class OneToManyLinkAttribute : LinkAttribute
    {
        public OneToManyLinkAttribute()
        {
            LinkType = LinkType.ltOneToMany;
        }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class OneToOneLinkAttribute : LinkAttribute
    {
        public OneToOneLinkAttribute()
        {
            LinkType = LinkType.ltOneToOne;
        }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class WizardAttribute : Attribute
    {
        public WizardAttribute()
        {
            
        }

        public int Step { get; set; }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class OptionalAttribute : Attribute
    {
        public OptionalAttribute()
        {
            
        }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class CreationOnlyAttribute : Attribute
    {
        public CreationOnlyAttribute()
        {

        }
    }
}
