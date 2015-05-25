<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Discounts.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Discounts" runat="server">

    <div class="saleList">
		<h3>Избранные скидки</h3>
							
		<div class="sortingTools">
								
			<ul>									
				<li><a href="#" title="Скидки" class="cur"><span>Скидки</span></a></li>
				<li><a href="#" title="Распродажи"><span>Распродажи</span></a></li>
				<li><a href="#" title="Акции"><span>Акции</span></a></li>
				<li><a href="#" title="Скидки по банковской карте"><span>Скидки по банковской карте</span></a></li>
			</ul>
									
			<div class="linkFavor cur">
				<a href="<%: Url.Action("Index","Discounts") %>" title="Избранное">Избранное</a>
			</div>
		</div>
														
		<div class="selectorSort">
			<form action="#">								
			<select id="selector_sort" name="selector_sort">
				<option value="1">По дате добавления</option>
				<option value="2">По проплаченности )</option>
			</select>
			</form>
		</div>
							
		<div class="blockLine">
			<dl>
				<dt>
					<a href="<%: Url.Action("One","Discounts") %>" title="автомир"><img src="/content/images/sale_1.jpg" alt="автомир" /></a>
				</dt>
				<dd>
					<span class="sale_value red">скидки до 80%</span>
					<p class="date">07.08.2013 - 21.09.2013</p>
					<p><a href="#" title="Скидки до 80% при оплате ">Скидки до 50% при оплате картой Visa</a></p>
				</dd>
			</dl>
			<dl>
				<dt>
					<a href="#" title="автомир"><img src="/content/images/sale_2.jpg" alt="автомир" /></a>
				</dt>
				<dd>
					<span class="sale_value orange">скидки до 50%</span>
					<p class="date">07.08.2013 - 21.09.2013</p>
					<p><a href="#" title="Скидки до 50% при оплате ">Скидка 7% на продукцию для держателей международных платежных систем VISA и Master Card, эмитированных Смоленским Банком</a></p>
				</dd>
			</dl>
			<dl>
				<dt>
					<a href="#" title="автомир"><img src="/content/images/sale_3.jpg" alt="автомир" /></a>
				</dt>
				<dd>
					<span class="sale_value blue">скидки до 25%</span>
					<p class="date">07.08.2013 - 21.09.2013</p>
					<p><a href="#" title="Скидки до 25% при оплате ">Скидки до 50% при оплате картой Visa</a></p>
				</dd>
			</dl>
		</div>
		<div class="blockLine">
			<dl>
				<dt>
					<a href="#" title="автомир"><img src="/content/images/sale_4.jpg" alt="автомир" /></a>
				</dt>
				<dd>
					<span class="sale_value red">скидки до 80%</span>
					<p class="date">07.08.2013 - 21.09.2013</p>
					<p><a href="#" title="Скидки до 80% при оплате ">Скидки до 50% при оплате картой Visa</a></p>
				</dd>
			</dl>
			<dl>
				<dt>
					<a href="#" title="автомир"><img src="/content/images/sale_2.jpg" alt="автомир" /></a>
				</dt>
				<dd>
					<span class="sale_value orange">скидки до 50%</span>
					<p class="date">07.08.2013 - 21.09.2013</p>
					<p><a href="#" title="Скидки до 50% при оплате ">Скидка 7% на продукцию для держателей международных платежных систем VISA и Master Card, эмитированных Смоленским Банком</a></p>
				</dd>
			</dl>
			<dl>
				<dt>
					<a href="#" title="автомир"><img src="/content/images/sale_3.jpg" alt="автомир" /></a>
				</dt>
				<dd>
					<span class="sale_value blue">скидки до 25%</span>
					<p class="date">07.08.2013 - 21.09.2013</p>
					<p><a href="#" title="Скидки до 25% при оплате ">Скидки до 50% при оплате картой Visa</a></p>
				</dd>
			</dl>
		</div>
		<div class="blockLine">
			<dl>
				<dt>
					<a href="#" title="автомир"><img src="/content/images/sale_1.jpg" alt="автомир" /></a>
				</dt>
				<dd>
					<span class="sale_value red">скидки до 80%</span>
					<p class="date">07.08.2013 - 21.09.2013</p>
					<p><a href="#" title="Скидки до 80% при оплате ">Скидки до 50% при оплате картой Visa</a></p>
				</dd>
			</dl>
			<dl>
				<dt>
					<a href="#" title="автомир"><img src="/content/images/sale_2.jpg" alt="автомир" /></a>
				</dt>
				<dd>
					<span class="sale_value orange">скидки до 50%</span>
					<p class="date">07.08.2013 - 21.09.2013</p>
					<p><a href="#" title="Скидки до 50% при оплате ">Скидка 7% на продукцию для держателей международных платежных систем VISA и Master Card, эмитированных Смоленским Банком</a></p>
				</dd>
			</dl>
			<dl>
				<dt>
					<a href="#" title="автомир"><img src="/content/images/sale_1.jpg" alt="автомир" /></a>
				</dt>
				<dd>
					<span class="sale_value blue">скидки до 25%</span>
					<p class="date">07.08.2013 - 21.09.2013</p>
					<p><a href="#" title="Скидки до 25% при оплате ">Скидки до 50% при оплате картой Visa</a></p>
				</dd>
			</dl>
		</div>
							
	</div>
						
    <div class="blockLine">
		<div class="pager">
		<a class="button cur" href="javascript:void(0);" title="1">1</a>
		<a class="button" href="javascript:void(0);" title="2">2</a>
		<a class="button" href="javascript:void(0);" title="3">3</a>
		<a class="button" href="javascript:void(0);" title="3">4</a>
		<a class="button" href="javascript:void(0);" title="...">...</a>
		<a class="button" href="javascript:void(0);" title="9">9</a>
		</div>
	</div>

</asp:Content>
