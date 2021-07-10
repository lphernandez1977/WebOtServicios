function Resaltar_On(this) {
    if (this != null) {
        this.originalBgColor = this.style.backgroundColor;
        this.style.backgroundColor = "#DBE7F6";
    }
}

function Resaltar_Off(this) {
    if (this != null) {
        this.style.backgroundColor = this.originalBgColor;
    }
}
