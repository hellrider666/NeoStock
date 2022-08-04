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
            document.getElementById('Layout_FullName').innerHTML = data.fullName;
        },
        error: function (data) {
            //console.log(data);
            alert('Ошибка');
        }
    });
}