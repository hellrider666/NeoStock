


function Layout_OpenDropdown() {
    loaddata(Cachedata);
    document.getElementById('dropdown-content').style.display = "block";
}
function Layout_OpenDropdown_without_data() {
    document.getElementById('dropdown-content').style.display = "block";
}

var ContentBar;
var Cachedata;

function Layout_CloseMenu() {
    document.getElementById('dropdown-content').style.display = "none";
}
function Layout_LoadProfile(login) {
    $.ajax({
        type: 'GET',
        url: '../WorkPages/LoadProfileData',
        data: {
            login: login,
        },
        dataType: 'json',
        success: function (data) {
            console.log(data);
            Cachedata = data;
            removeAttribute();
        },
        error: function (data) {
            //console.log(data);
            alert('Ошибка');
        }
    });
}
function removeAttribute() {
    var btn = document.getElementById('dropbtn');
    btn.removeAttribute('disabled');
}
function loaddata(Cachedata) {
    document.getElementById('Layout_FullName').innerHTML = Cachedata.fullName;
}