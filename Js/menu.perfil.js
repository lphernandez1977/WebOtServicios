//Funcion que muestra el div en la posicion del mouse
function showdiv(event) {
	//determina un margen de pixels del div al raton
	margin = 5;

	//La variable IE determina si estamos utilizando IE
	var IE = document.all ? true : false;
	//Si no utilizamos IE capturamos el evento del mouse
	if (!IE) document.captureEvents(Event.MOUSEMOVE)

	var tempX = 0;
	var tempY = 0;

	if (IE) { //para IE
		tempX = event.clientX + document.body.scrollLeft;
		tempY = event.clientY + document.body.scrollTop;
	} else { //para netscape
		tempX = event.pageX;
		tempY = event.pageY;
	}
	if (tempX < 0) { tempX = 0; }
	if (tempY < 0) { tempY = 0; }

	document.getElementById('menuperfil').style.display = 'block';
	return;
}

function hidediv(event) {
	document.getElementById('menuperfil').style.display = 'none';
	return;
}