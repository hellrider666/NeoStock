
$(document).ready(function () {
    LoadCompaniesList();
})
function LoadCompaniesList() {
    $.ajax({
        type: 'GET',
        url: '/WorkPages/ProductionListPartialView',
        contentType: 'application/html; charset=utf-8',
        dataType: 'html',
        success: function (data) {
            console.log(data);
            $('#work-partial-table').html(data);
        },
        error: function (error) {
            alert('Ошибка!');
        },
    });  
}
function OpenProdCreateView() {
    $.ajax({
        type: 'GET',
        url: '/WorkPages/CreateProductPartialView',
        contentType: 'application/html; charset=utf-8',
        dataType: 'html',
        success: function (data) {
            console.log(data);
            $('#work-partial-prop-1').html(data);
        },
        error: function (error) {
            alert('Ошибка!');
        },
    });
}