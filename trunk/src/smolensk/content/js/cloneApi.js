jQuery.fn.extend({
	resetFormBlock: function(){
		
		$.each($(this), function(){
			$clone = $(this);
			
			var $input = $clone.find('input');
			var $select = $clone.find('select');
			var $txtAr = $clone.find('textarea');
			// Textarea
			$txtAr.val('');
			// Select
			$select.val($select.find('option:first').val());					
			$input.not(':checkbox').not(':radio').each(function (i) {
				$el = $(this);

				//if (!($el.prev('input').length == 1 && $el.parent('label').length == 1))
					$el.val('');
			});
			
			//checkbox & radio
			$input.filter(':checkbox').removeAttr('checked');
			
			$clone.find('.checkbox').css('background-position','0 0').data("checked",false);
		});
	},
	cloneFormBlock: function(){
		var mask = /\d+/;
		var hdrIncrement = function (_str, _i, _src) { return parseInt(_str, 10) + 1; };
	
		$wr = $(this);
		
		$block = $wr.find('._clonePiece._template');
		
		if($block.length == 0)
			$block = $wr.find('._clonePiece:last');
					
		$clone = $block.clone(true);
		var $lbl = $clone.find('label[for]');
		var $elm = $clone.find('input, textarea, select');
		
		//id block	
		if($clone.attr('id'))
			$clone.attr('id', $clone.attr('id').replace(mask, hdrIncrement));
				
		// Label
		$lbl.each(function (i) {
			var $el = $(this);				
			$el.attr('for', $el.attr('for').replace(mask, hdrIncrement))
		});
		
		//input[text]
		$elm.each(function (i) {
			var $el = $(this);
			if($el.attr('name').length > 0){
				var isName = $el.attr('name').split('.');

				var numb;
				
				if (isName.length == 1)
					numb = 0;
				else
					if (/*cloneOne*/false) { // last element
						numb = isName.length;
						while (numb--) {
							if (/\d+/.test(isName[numb]))
								break;
						}
					}
					else // first element
						numb = 0;

				
				isName[numb] = isName[numb].replace(mask, hdrIncrement);
				$el.attr('name', isName.join('.'));
				
			}
			if($el.attr('id'))
				$el.attr('id', $el.attr('id').replace(mask, hdrIncrement));
			
		});
									
		$clone.resetFormBlock();
		/*if($clone.hasClass('_template')){
			$clone.removeClass('_template');
			$clone.appendTo($block.parent());
		}
		else{
			$block.after($clone);	
		}*/
		$clone.removeClass('_template');
		$clone.appendTo($block.parent());
		$clone.show();		
		$clone.find('._delete').show();	
		
		return $clone;
	}
});

$( function() {
	
	
	
	var hdrClone = function (ev) {
		
		$bt = $(this);
		$wr = $bt.closest('._cloneWrapper');		
		$wr.cloneFormBlock();
	}
	
	$('._clonePiece ._delete:not(._clone)').live("click", function(){
		$(this).closest('._clonePiece').remove();
	});
	
	$('._clonePiece ._delete._clone').live("click", function(){
		$deletePiece = $(this).closest('._clonePiece');
		if($deletePiece.parent().children('._clonePiece').length == 1) {
			$deletePiece.resetFormBlock();
		} else {
			$deletePiece.remove();
		}
		
	});
	
	$('._cloneButton').click(hdrClone);
});