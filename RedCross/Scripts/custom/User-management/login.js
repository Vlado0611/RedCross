$(document).ready(function () {

    $('#btn-login').click(function (e) {
        let username = $('#username').val();
        let password = $('#password').val();
        
        //AJAX
        if (!username || !password) {
            alert("Insert all data");
        }
        else {
            //AJAX poziv
            $.ajax({
                type: "POST",
                url: "http://localhost:50104/api/user/login",
                data: { Username: username, Password: password },
                success: function (data) {
                    if (data) {
                        localStorage.setItem('user', JSON.stringify(data));
                        let url = `${window.location.origin}/Home/Index`;
                        window.location.href = url;
                    }
                    else {
                        alert("Try Again");
                    }
                }
            })

        }
    })

})