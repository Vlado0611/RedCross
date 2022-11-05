$(document).ready(function () {
    let user = localStorage.getItem('user');
    if (!user) {
        $('.user-options').hide();
    }
})