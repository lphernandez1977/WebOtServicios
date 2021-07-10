function valida_caracteres(Consulta, maxlength) {
    if (Consulta.value.length > maxlength) {
        Consulta.value = Consulta.value.substring(0, maxlength);
        alert("Debe ingresar hasta un maximo de " + maxlength + " caracteres");
    }
}