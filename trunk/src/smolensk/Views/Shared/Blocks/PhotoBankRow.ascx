<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<meridian.smolensk.proto.photobank_photos>>" %>
<%@Import namespace="meridian.smolensk.proto" %>
<%
    photobank_photos mainPhoto = Model.Where(p => p.day_photo).FirstOrDefault();
%>

<div class="blockPhotoBank">
	<div class="widthContent">					
		<div class="headerBlock">
			<h3><a href="<%: Url.Action("Index","PhotoBank") %>" title="Фотобанк">Фотобанк</a></h3>						
		</div>
		<table>
			<tr>
				<th>Фото дня</th>
				<th>Популярные фотографии</th>
			</tr>
			<tr>
				<td style="width:477px;">
				    <%if(mainPhoto!=null){%>
				    <a href="<%: mainPhoto.ItemUri() %>"><img src="<%:mainPhoto.PreviewMainUrl %>" width="473" height="299" alt="<%:mainPhoto.title %>" /></a>
                    <%} %>
				</td>
				<td>
					<table>
					    <tr>
					    <%
					        int counter = 0;
                            var popular = Model.Where(p => !p.day_photo);
                            for (var i=0; i < 10; ++i)
                            {
                                var photo = popular.ElementAtOrDefault(i);
                                if(counter > 4)
                                {
                                    counter = 0;
                                    %></tr><tr><%
                                }
                                
                                if(counter == 0)
                                {
                                    %>
                                    <td>
                                        <%if(photo!=null){%><a href="<%: photo.ItemUri() %>"><img src="<%: photo.PreviewUrl %>" width="233" height="146" alt="<%: photo.title %>" /></a><%} %>
                                    </td>
                                    <td>
								        <table>
									        <tr>
                                    <%
                                }
                                if (counter == 1 || counter == 2)
                                {
                                    %>
                                    <td>
                                        <%if(photo!=null){%><a href="<%: photo.ItemUri() %>"><img src="<%: photo.PreviewUrl %>" width="116" height="72" alt="<%: photo.title %>" /></a><%} %>
                                    </td>
                                    <%
                                }
                                if(counter == 3)
                                {
                                    %>
                                    </tr><tr><td>
                                                 <%if(photo!=null){%><a href="<%: photo.ItemUri() %>"><img src="<%: photo.PreviewUrl %>" width="116" height="72" alt="<%: photo.title %>" /></a><%} %>
                                             </td>
                                    <%
                                }
                                if(counter == 4)
                                {
                                    %>
                                            <td>
                                                <%if(photo!=null){%><a href="<%: photo.ItemUri() %>"><img src="<%: photo.PreviewUrl %>" width="116" height="72" alt="<%: photo.title %>" /></a> <%} %>
                                            </td>
									        </tr>
								        </table>
							        </td>
                                    <%
                                }
                        %>
                           
                            
							<%--<td><img src="/content/images/photo_2.jpg" width="233" height="146" alt="2" /></td>
							<td>
								<table>
									<tr>
										<td><img src="/content/images/photo_4.jpg" width="116" height="72" alt="4" /></td>  
										<td><img src="/content/images/photo_5.jpg" width="116" height="72" alt="5" /></td>
									</tr>
									<tr>
										<td><img src="/content/images/photo_6.jpg" width="116" height="72" alt="6" /></td>
										<td><img src="/content/images/photo_7.jpg" width="116" height="72" alt="7" /></td>
									</tr>
								</table>
							</td>--%>
						    
                        <%++counter;} %>
						</tr>
						<%--<tr>
							<td><img src="/content/images/photo_3.jpg" width="233" height="146" alt="3" /></td>
							<td>
								<table>
									<tr>
										<td><img src="/content/images/photo_8.jpg" width="116" height="72" alt="8" /></td>
										<td><img src="/content/images/photo_9.jpg" width="116" height="72" alt="9" /></td>
									</tr>
									<tr>
										<td><img src="/content/images/photo_10.jpg" width="116" height="72" alt="10" /></td>
										<td><img src="/content/images/photo_11.jpg" width="116" height="72" alt="11" /></td>
									</tr>
								</table>
							</td>
						</tr>--%>
					</table>
				</td>
			</tr>						
		</table>
	</div>
</div>
