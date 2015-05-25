<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<smolensk.Models.ViewModels.Profile.PhotosList>" %>
    
    <%if(Model!= null && Model.Photos != null && Model.Photos.Count() > 0){%>
    <div class="profileBody">
        <table class="prfTable">
            <tr>
                <th>N</th>
                <th></th>
                <th>ID</th>
                <th>Лицензия</th>
                <th>Размер фото</th>
                <th>Цена</th>
                <%--<th>Действия</th>--%>
            </tr>
            
            <%
                int counterOut = 0;
                int counterGroup = 0;
                int counterPhoto = 0;
                foreach (var photo in Model.Photos){%>
                <tr>
                    <%
                        var relPhotos = photo.GetPhotos();
                    %>
                    <td class="date" rowspan="<%: relPhotos.Count() %>"><%: counterOut + 1 %></td> 
                    
                                                       
                    <td rowspan="<%: relPhotos.Count() %>"><a href="<%: photo.ItemUri() %>" title="<%: photo.title %>"><img src="<%: photo.PreviewUrl %>" width="138" alt="<%: photo.title %>"/></a></td>
                    <td class="date" rowspan="<%: relPhotos.Count() %>">#<%: photo.id %></td>
                    
                    <%
                    var groupLicense = relPhotos.GroupBy(r => r.GetPrices().First().GetLicensesPhotobank_license());
                        counterGroup = 0;
                        
                        foreach (var gr in groupLicense)
                        {
                            if ( counterGroup == 0)
                            {
                                %><td rowspan="<%:gr.Count() %>"><%: gr.Key.title %></td><%
                            }else
                            {
                                %><tr><td rowspan="<%:gr.Count() %>"><%: gr.Key.title %></td><%
                            }
                            
                            counterPhoto = 0;
                            foreach (var relP in gr)
                            {
                                if (counterPhoto != 0)
                                {
                                    %><tr><%
                                }
                                %>
                                    <td class="date"><%:relP.width%>*<%:relP.height %></td>
                                    <td class="date"><%:relP.GetPrices().First().price %> руб.</td>
                                </tr>
                                <%
                                ++counterPhoto;
                            }
                                
                            ++counterGroup;
                        }
                    %>

                   <%-- <td rowspan="2">ограниченная</td>                                    
                    <td class="date">3560*7568</td>
                    <td class="date">100 руб.</td>
                    <td></td>
                </tr>

		        <tr>                               	
                                                                   
                    <td class="date">3560*7568</td>
                    <td class="date">100 руб.</td>
                    <td></td>
                </tr>

		        <tr>                                	
                    <td>расширенная</td>                                    
                    <td class="date">3560*7568</td>
                    <td class="date">200 руб.</td>
                    <td></td>
                </tr>           --%>                    
                <%--</tr>--%>               
                <tr>
                    <th colspan="6">
				        <div class="photoInfo">
					        <div class="info">
						        <p class="name">Название: <a href="<%: photo.ItemUri() %>" title="<%: photo.title %>"><%: photo.title %></a></p>
						        <%--<p class="date">Ключевые слова: <a href="#" title="Пейзаж">Пейзаж</a>, <a href="#" title="деревня">деревня</a></p>--%>
												
					        </div>
					        <span class="addPhoto" data-url="/Profile/AddRelPhoto?albumId=<%:Model.albumId %>&parentId=<%: photo.id %>">Добавить фотографию</span>
				        </div>
			        </th>                                    
                </tr>
                
                <%++counterOut;} %>

            
								                         	
            <%--<tr>
                <td class="date" rowspan="3">1</td>                                    
                <td rowspan="3"><a href="#" title="Фото"><img src="/content/images/onePhoto_1.jpg" width="138" height="96" alt="1"/></a></td>
                <td class="date" rowspan="3">#17505</td>
                <td rowspan="2">ограниченная</td>                                    
                <td class="date">3560*7568</td>
                <td class="date">100 руб.</td>
                <td></td>
            </tr>
		    <tr>                               	
                                                                   
                <td class="date">3560*7568</td>
                <td class="date">100 руб.</td>
                <td></td>
            </tr>
		    <tr>                                	
                <td>расширенная</td>                                    
                <td class="date">3560*7568</td>
                <td class="date">200 руб.</td>
                <td></td>
            </tr>              --%>                 
                               
        </table>
    </div>
                        
                        
    <div class="blockLine">
	    <%: Html.Pager(Model.CurrentPage, Model.TotalPages, "ProfileAlbum", new { albumId = Model.albumId}, "page")%>
    </div>
    <%} %>