$(function () {
	//instancia cuando se carga la pagina
	$('#' + calendar1).datepicker({
		dateFormat: 'dd/mm/yy',
		showOn: 'button',
		buttonImage: '../css/images/calendar.gif',
		buttonImageOnly: true,
		changeMonth: true,
		changeYear: true,
		showButtonPanel: true
	});
	Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
	//cuando se realizaron llamados post-back
	function EndRequestHandler(sender, args) {
		$('#' + calendar1).datepicker({
			dateFormat: 'dd/mm/yy',
			showOn: 'button',
			buttonImage: '../css/images/calendar.gif',
			buttonImageOnly: true,
			changeMonth: true,
			changeYear: true,
			showButtonPanel: true
		});
	}

});
