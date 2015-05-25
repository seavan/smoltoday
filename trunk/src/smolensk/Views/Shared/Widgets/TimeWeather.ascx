<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<div class="weatherBlock">
	<div class="citySelect">
		<p>Сейчас в <span class="_weatherDoor">Смоленске</span></p>
	</div>
	<div class="selectedInfo">
		<span class="time" id="clockbox"><%= DateTime.Now.ToShortTimeString() %></span>
        <%
            var weather = meridian.smolensk.system.Meridian.Default.main_page_widgetsStore.GetRecord();
             %>
		<span class="weather"><img src="<%= weather.sky_icon %>" width="28" height="28" title="<%= weather.sky %>"/><%= weather.temperature %></span>
	</div>
    <script type="text/javascript">
        var nhour = <%= DateTime.Now.Hour %>;
        var nmin = <%= DateTime.Now.Minute %>;
        var nsec = 0;
        (function () {
            function GetClock() {
                nsec++;
                
                if (nsec > 60) {
                    nsec = 0;
                    nmin++;
                }
                
                if (nmin > 60) {
                    nhour++;
                    nmin = 0;
                }
                
                if (nhour > 23) {
                    nhour = 0;
                }

                var min = nmin;
                var hour  = nhour;
                
                if (nmin <= 9) {
                    min = "0" + nmin;
                }
                if (nhour <= 9) {
                    hour = "0" + nhour;
                }

                var separator = (nsec % 2) ? ":" : "&nbsp;";

                document.getElementById('clockbox').innerHTML = "" + hour + separator + min + "";
                setTimeout(GetClock, 1000);
            }

            ;
            
            GetClock();
        })();

    </script>
    
    <div class="weatherPopUp" style="display: none" >
        <span class="close"></span>
                                
        <span class="selectedInfo">   
            <span class="time">Утро</span>                                 
            <span class="weather"><img src="<%= weather.sky_icon_morning %>" width="28" height="28" title="<%= weather.sky_morning %>" /><%= weather.temperature_morning %></span>
        </span>
        <span class="selectedInfo">   
            <span class="time">День</span>                                 
            <span class="weather"><img src="<%= weather.sky_icon_afternoon %>" width="28" height="28" title="<%= weather.sky_afternoon %>" /><%= weather.temperature_afternoon %></span>
        </span>
        <span class="selectedInfo">   
            <span class="time">Вечер</span>                                 
            <span class="weather"><img src="<%= weather.sky_icon_evening %>" width="28" height="28" title="<%= weather.sky_evening %>" /><%= weather.temperature_evening %></span>
        </span>
    </div>
</div>	

<script>
    $('._weatherDoor').click(function () {
        $('.weatherPopUp').fadeIn();
    });
    $('.weatherPopUp .close').click(function () {
        $(this).parent().hide();
    });
</script>
