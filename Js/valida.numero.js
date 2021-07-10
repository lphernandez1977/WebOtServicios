////<%--Valida se sea solo numeros tanto positivos como negativos--%>
function valida_numeros(evt) {
    // NOTE: Backspace = 8, Enter = 13, '0' = 48, '9' = 57
    var key = (document.all) ? evt.keyCode : evt.which;
    return (key <= 13 || (key >= 48 && key <= 57) || key == 45);
}

function valida_numeros_format(input) {
    var num = input.value.replace(/\./g, '');
    if (!isNaN(num)) {
        num = num.toString().split('').reverse().join('').replace(/(?=\d*\.?)(\d{3})/g, '$1.');
        num = num.split('').reverse().join('').replace(/^[\.]/, '');
        input.value = num;
    }
    else {
        //alert('Solo se permiten numeros');
        input.value = input.value.replace(/[^\d\.]*/g, '');
    }
}