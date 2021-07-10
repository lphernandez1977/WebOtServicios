function AbrirVentana(alto, ancho, url) {
    var win = null;
    h = alto;
    w = ancho;
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 2 : 0;
    //LeftPosition = si agrego el "-" alinea a la izquierda y si agrego el "+" alinea a la derecha  ejemplo.:(LeftPosition+750) 
    //TopPosition  = si agrego el "-" sube la ventanay si agrego el "+" baja la ventanaejemplo.:(TopPosition+100) 
    settings = 'height=' + h + ',width=' + w + ',top=' + (TopPosition + 90) + ',left =' + (LeftPosition + 400) + ',status=no,resizable=yes,scrollbars=no'
    win = window.open(url, 'ventana', settings)
}

function AbrirFoto(alto, ancho, url) {
    var win = null;
    h = alto;
    w = ancho;
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 2 : 0;
    //LeftPosition = si agrego el "-" alinea a la izquierda y si agrego el "+" alinea a la derecha  ejemplo.:(LeftPosition+750) 
    //TopPosition  = si agrego el "-" sube la ventanay si agrego el "+" baja la ventanaejemplo.:(TopPosition+100) 
    settings = 'height=' + h + ',width=' + w + ',top=' + (TopPosition + 20) + ',left =' + (LeftPosition + 100) + ',status=no,resizable=yes,scrollbars=no'
    win = window.open(url, 'ventana', settings)
}
function AbrirVentanaScroll(alto, ancho, scoll, url) {
    var win = null;
    h = alto;
    w = ancho;
    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
    TopPosition = (screen.height) ? (screen.height - h) / 2 : 0;
    //LeftPosition = si agrego el "-" alinea a la izquierda y si agrego el "+" alinea a la derecha  ejemplo.:(LeftPosition+750) 
    //TopPosition  = si agrego el "-" sube la ventanay si agrego el "+" baja la ventanaejemplo.:(TopPosition+100) 
    settings = 'height=' + h + ',width=' + w + ',top=' + (TopPosition + 20) + ',left =' + (LeftPosition + 100) + ',status=no,scrollbars=' + scoll + ',resizable=no'
    win = window.open(url, 'ventana', settings)
}