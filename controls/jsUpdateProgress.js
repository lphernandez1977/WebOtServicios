
Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(beginReq);
Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endReq);
function beginReq(sender, args) {
    //	// shows the Popup 
    if (botonProgress == '1') {
        $find(ModalProgress).show();
    }
}

function endReq(sender, args) {
    //  shows the Popup 
    botonProgress = '0';
    timeOut = setTimeout('$find(ModalProgress).hide()', 750);
    clearTimeout(timeOut);
}


// se debe agregar un updatepanel paque que funcione correctamente