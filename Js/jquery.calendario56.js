$(function () {
	//instancia cuando se carga la pagina
	$('#' + calendar5).datepicker({
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
		$('#' + calendar5).datepicker({
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

$(function () {
    //instancia cuando se carga la pagina
    $('#' + calendar6).datepicker({
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
        $('#' + calendar6).datepicker({
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