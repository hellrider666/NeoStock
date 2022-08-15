$(document).ready(function () {
    alert('Тест');
    $('#work-partial-table').load('@Url.Action("ProductionListPartialView", "WorkPages")');
})
function LoadCompaniesList() {
    $('#work-partial-table').load('@Url.Action("ProductionListPartialView", "WorkPages")');
}