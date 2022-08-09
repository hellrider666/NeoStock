
function CreateCompany() {
    var Model = $('#CreateCompForm').serialize();
    var typeId = $('#comptypeId').val();
    console.log(typeId);
    console.log(Model);
    debugger;
    $.ajax({
        type: "POST",
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        url: "/WorkPages/CreateCompany",
        data: Model + "&Id=" + typeId,
        success: function (data) {
            if (JSON.parse(data) === true) {
                LoadCompaniesList();
                document.getElementById('CompanyResult-text').innerHTML = "Компания успешно создана!";
            }
            else{
                document.getElementById('CompanyResult-text').innerHTML = "Ошибка при создании!";
                }
        },
        error: function (error) {
            alert(error.responseText);
        }
    });
}
