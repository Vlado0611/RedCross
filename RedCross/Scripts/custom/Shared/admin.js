$(document).ready(function () {
    let user = localStorage.getItem('user');
    let userObj = JSON.parse(user);

    if (!user || userObj["Admin"] == 0) {
        $('.admin-options').hide();
    }

})