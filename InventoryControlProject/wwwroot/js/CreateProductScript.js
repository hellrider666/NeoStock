function CreateProduct() {
    var Model = $('#createProdForm').serialize();
    $.ajax({
        type: "POST",
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        url: "/WorkPages/CreateProduct",
        data: Model,
        success: function (data) {
            if (JSON.parse(data) === true) {
                LoadProductList();
                document.getElementById('CompanyResult-text').innerHTML = "Товар успешно создан!";
            }
            else {
                document.getElementById('CompanyResult-text').innerHTML = "Ошибка при создании!";
            }
        },
        error: function (error) {
            alert(error.responseText);
        }
    });
}