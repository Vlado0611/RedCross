
$('#btn-register').click(function (e) {
    let username = $('#usernameR').val();
    let password = $('#passwordR').val();
    let email = $('#emailR').val();
    let name = $('#nameR').val();
    let surname = $('#surnameR').val();


    //AJAX
    if (!username || !password || !email || !name || !surname) {
        alert("Insert all data");
    }
    else {
        //AJAX poziv
        $.ajax({
            type: "POST",
            url: "http://localhost:50104/api/user/register",
            data: { Username: username, Password: password, Email: email, Name: name, Surname: surname, Admin: 0 },
            success: function (data) {
                if (data) {
                    let url = `${window.location.origin}/UserManagement/Login`;
                    window.location.href = url;
                }
                else {
                    alert("Try Again");
                }
            }
        })

        }
})