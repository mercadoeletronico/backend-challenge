$(function () {
    $("#CPF").mask("999.999.999-99");
    $("#DataNascimento").mask("99/99/9999");
    $("#Preco").maskMoney({
        allowNegative: true, thousands: ".", decimal: ",", affixesStay: false
    });
})
