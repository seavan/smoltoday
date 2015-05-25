<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<smolensk.Models.ViewModels.AlphabetViewModel>" %>
<%@ Import Namespace="smolensk.Models.ViewModels" %>
<%@ Import Namespace="smolensk.common" %>
<div class="alphabet">
    <div class="languageSelector">
        <span class="rus <%: Model.Alphabet == Alphabet.Rus ? "cur" : "" %>">RUS</span>
        <span class="eng <%: Model.Alphabet == Alphabet.Eng ? "cur" : "" %>">ENG</span>
        </div>
        <div class="letters rus" style="display:<%: Model.Alphabet != Alphabet.Rus ? "none" : "block"%>;">
            <% foreach (string letter in AlphabetViewModel.RusAlphabet)
               { %>
            <a href="<%= Model.RouteUrl(Url, letter, Alphabet.Rus) %>" title="<%:letter %>" style="<%: letter.ToLower() == Model.Letter.ToLower() ? "cur" : "" %>"><%:letter%></a>
            <%  } %>
        </div>
        <div class="letters eng" style="display:<%: Model.Alphabet != Alphabet.Eng ? "none" : "block"%>;">
            <% foreach (string letter in AlphabetViewModel.EngAlphabet)
               { %>
            <a href="<%= Model.RouteUrl(Url, letter, Alphabet.Eng) %>" title="<%:letter %>" style="<%: letter.ToLower() == Model.Letter.ToLower() ? "cur" : "" %>"><%:letter%></a>
            <%  } %>
        </div>
    </div>
