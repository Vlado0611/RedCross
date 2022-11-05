$(document).ready(function () {

    let user = localStorage.getItem('user');
    
    if (!user) {
        $('#list-item-login').show();
        $('#list-item-register').show();
        $('#list-item-logout').hide();
    }
    else {
        $('#list-item-logout').show();
        $('#list-item-register').hide();
        $('#list-item-login').hide();
        let userObject = JSON.parse(user);
        let username = userObject["Username"];
        $('#layout-username').text(username);
    }
})

$('#logout-button').click(function () {
    localStorage.removeItem('user');
    let url = `${window.location.origin}/Home/Index`;
    window.location.href = url;
})