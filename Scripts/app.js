function validarDPI(dpi)
{
    var regex = /^[0-9]{4}\s?[0-9]{5}\s?[0-9]{4}$/;

    if (!regex.test(dpi)) {

        $(':input[type="submit"]').prop('disabled', true);
    } else {
        $(':input[type="submit"]').prop('disabled', false);
        codigoVerificacion(dpi);
    }
}

function codigoVerificacion(dpi)
{
    let numeros = [];
    for (let i of dpi) {
        if (!numeros.includes(i)) {
            numeros.push(i);
        }
    }
    numeros = numeros.sort(function (a, b) { return b - a });
    let codigo = "";
    for (let i = 0; i < 4; i++) {
        codigo = codigo + numeros[i];
    }
    $("#CodigoVerificacion").val(codigo);
}

$(document).ready(function () {
    $("#CUI").on('change', function() {
        validarDPI($("#CUI").val());
    });
    $("#CUI").keyup(function () {
        validarDPI($("#CUI").val());
    });

});