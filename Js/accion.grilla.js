function Resaltar_On(GridView) {
    if (GridView != null) {
        GridView.originalBgColor = GridView.style.backgroundColor;
        GridView.style.backgroundColor = "#DBE7F6";
    }
}

function Resaltar_Off(GridView) {
    if (GridView != null) {
        GridView.style.backgroundColor = GridView.originalBgColor;
    }
}


function Resaltar_click(GridView) {
    if (GridView != null) {
        GridView.originalBgColor = GridView.style.backgroundColor;
        GridView.style.backgroundColor = "#DBE7F6";
    }
}

/* para desplazar el encabezado junto con el detalle */
function scrollPanel(objDIV)
{
        document.all(GridPanel).style.pixelLeft = objDIV.scrollLeft * -1;
} 



