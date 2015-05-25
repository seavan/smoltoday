<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<smolensk.Models.ViewModels.AddToCartViewModel>" %>

<span class="basket button <%: Request.IsAuthenticated ? "" : "no-auth" %>" data-id="<%=Model.Id %>" data-priceId="<%=Model.PriceId %>"><span></span></span>