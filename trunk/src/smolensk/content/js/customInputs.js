//##############################
// jQuery Custom Radio-buttons and Checkbox; 

var elmHeight = "25";	// should be specified based on image size

// Extend JQuery Functionality For Custom Radio Button Functionality
jQuery.fn.extend({
dgStyle: function()
{
	// Initialize with initial load time control state
	$.each($(this), function(){
		var elm	=	$(this).children().get(0);
		elmType = $(elm).attr("type");
		$(this).data('type',elmType);
		$(this).data('checked',$(elm).attr("checked"));
		$(this).dgClear();
	});
	$(this).mousedown(function() { $(this).dgEffect(); });
	$(this).mouseup(function() { $(this).dgHandle(); });	
},
dgClear: function()
{
	if($(this).data("checked") == true || $(this).data("checked") == 'checked')
	{
		$(this).css("backgroundPosition","0 -"+(elmHeight*2)+"px");
		}
	else
	{
		$(this).css("backgroundPosition","0 0");
		}	
},
dgEffect: function()
{
	if($(this).data("checked") == true || $(this).data("checked") == 'checked')
		$(this).css({backgroundPosition:"0 -"+(elmHeight*3)+"px"});
	else
		$(this).css({backgroundPosition:"0 -"+(elmHeight)+"px"});
},
dgHandle: function()
{	
	var elm	=	$(this).children().get(0);
	if($(this).data("checked") == true || $(this).data("checked") == 'checked')
	{
		if($(this).data('type') != 'radio')
		{
			$(elm).dgUncheck(this);
		}
		
	}
	else
	{
		$(elm).dgCheck(this);
	}
	
	if($(this).data('type') == 'radio')
	{
		$.each($("input[name='"+$(elm).attr("name")+"']"),function()
		{
			if(elm!=this)
				$(this).dgUncheck(-1);
		});
	}
	
},
dgCheck: function(div)
{
	$(this).attr("checked",true);
	$(div).data('checked',true).css({backgroundPosition:"0 -"+(elmHeight*2)+"px"});
},
dgUncheck: function(div)
{
	$(this).attr("checked",false);
	if(div != -1)
		$(div).data('checked',false).css({backgroundPosition:"0 0"});
	else
		$(this).parent().data("checked",false).css({backgroundPosition:"0 0"});
}
});