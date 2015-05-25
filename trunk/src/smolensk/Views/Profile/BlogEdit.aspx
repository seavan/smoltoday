<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Profile.Master" Inherits="System.Web.Mvc.ViewPage<meridian.smolensk.proto.blogs>" %>
<%@ Import Namespace="meridian.smolensk.proto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ProfilePage" runat="server">
    
    <%
        List<blog_categories> base_categories = ViewBag.Categories as List<blog_categories>;
        List<blog_categories> list_categories = new List<blog_categories>(){new blog_categories(){id = 0, title = "Выберите из списка"}};
        list_categories.AddRange(base_categories);
    %>

    <div class="profileHeader">
        <h3>Новая запись в блоге</h3>
    </div>
                        
    <div class="profileBody">
                        	
        <div class="grayCreateBlock">
            <form action="<%: Url.Action("BlogEdit") %>" method="post">
                <%: Html.HiddenFor(m=>m.id) %> 
                <table class="createBlock">   
                    <tr>
                        <td style="vertical-align:top;">Категория</td>
                        <td>
                            <%= Html.DropDownListFor(m => m.category_id, new SelectList(list_categories.ToDictionary(str => str.id, str => str.title), "Key", "Value", Model.category_id))%>
                        </td>
                    </tr>
                                                             	
                    <tr>
                        <td>Тема поста <span class="need">*</span></td>
                        <td>
                            <%: Html.TextBoxFor(m=>m.title) %>
                            <%: Html.ValidationMessageFor(m => m.title)%>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="vertical-align:top;">Содержимое поста <span class="need">*</span></td>
                                        
                    </tr>
                    <tr>                                    	
                        <td colspan="2">
                            <%: Html.TextAreaFor(m=>m.text, new{@class="_ckeditor"}) %>  
                            <%: Html.ValidationMessageFor(m => m.text)%>                
                        </td>
                    </tr>
                                    
                   <%-- <tr> <!-- Скрыто до реализации -->
                        <td>Ключевые слова</td>
                        <td><input type="text" value="" name="tags" /></td>
                    </tr>--%>
                                    
                    <tr>
                        <td style="vertical-align:top;">Комментарии</td>
                        <td>
                            <%: Html.DropDownListFor(m => m.can_comment, Html.TrueFalseListForSelection("Запретить", "Разрешить"))%>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align:top;">Доступ к записи</td>
                        <td>
                            <%: Html.DropDownListFor(m => m.is_publish, Html.TrueFalseListForSelection("Запретить", "Разрешить"))%>           
                        </td>
                    </tr>
                </table>   
                                
                                
                <div class="buttonPanel">    
                    <span class="button cancel">Отмена</span>
                    <span class="button save" onClick="$(this).closest('form').submit();">Сохранить</span>                                    
                </div>
                                
            </form>
        </div>
                            
                            
    </div>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="RightBlockHeader" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="RightBlockBottom" runat="server">
</asp:Content>
