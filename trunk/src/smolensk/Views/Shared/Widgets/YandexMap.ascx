<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<meridian.smolensk.proto.IGeoLocation>>" %>
<%@ Import namespace="meridian.smolensk.proto" %>
<%
    string baseCoords = "[32.048859,54.783821]"; //Центр Смоленска

    List<IGeoLocation> ListPoints = new List<IGeoLocation>();
    
    if(Model != null )
    {
        ListPoints = Model.Where(p => p.GeoLocationCoordinates != null && p.GeoLocationCoordinates != "").ToList();
    }

    if (ListPoints.Count() == 1)
    {
        baseCoords = string.Format("[{0}]", ListPoints.First().GeoLocationCoordinates);
    }

    var grouped = ListPoints.GroupBy(g => g.GetGeoLocationCategoryName());

    string groups = "[";
    foreach (var group in grouped)
    {
        groups += "\r\n{name: \""+ group.Key +"\", items: [";

        groups += string.Join(",", group.Select(i => "{ center: [" + i.GeoLocationCoordinates + "], " +
                                                     "balloonContentHeader: \"" + i.GeoLocationTitle.Replace("\"", "\\\"").Replace("\r", "").Replace("\n", "") + "\", " +
                                                     "balloonContentHeaderLink: \"" + i.GetGeoLocationUri() + "\"," +
                                                     "balloonContent: \"" + i.GeoLocationDescription.Replace("\"", "\\\"").Replace("\r", "").Replace("\n", "") + "\"}\r\n"));
        
        groups += "]}";
        
        if(!group.Key.Equals(grouped.Last().Key))
        {
            groups += ",";
        }


    }
    groups += "]";
    
%>

<script type="text/javascript" src="/content/js/map.js"></script>

<script type="text/javascript">
    $(function () {
        smolenskInitMap(<%= baseCoords %>, <%= groups %>);
        //myMap.setThumbCenterPoint(<%= baseCoords %>, 15);
    });
</script>

<div class="map" id="yandexMap">
    <%if(grouped.Count() > 1) {%>
    <div class="tools" style="z-index:5;">
        <div id="toolsScroll">
	        <ul>
		   
	        </ul>
        </div>
    </div>
    <%}%>
</div>

