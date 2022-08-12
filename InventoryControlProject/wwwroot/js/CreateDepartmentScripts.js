function CreateDepartment() {
    var Model = $('#CreateCompForm').serialize();
    var typeId = $('#comptypeId').val();
    console.log(typeId);
    console.log(Model);
    debugger;
    $.ajax({
        type: "POST",
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        url: "/WorkPages/CreateDepartment",
        data: Model + "&Id=" + typeId,
        success: function (data) {
            if (JSON.parse(data) === true) {
                LoadDepartList();
                document.getElementById('CompanyResult-text').innerHTML = "Подразделение успешно создано!";
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
