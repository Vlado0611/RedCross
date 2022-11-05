$(document).ready(function () {
    let user = localStorage.getItem('user');
    let userObj = JSON.parse(user);

    let username = userObj["Username"];
    $('#usernameE').val(username);

    let password = userObj["Password"];
    $('#passwordE').val(password);

    let email = userObj["Email"];
    $('#emailE').val(email);

    let name = userObj["Name"];
    $('#nameE').val(name);

    let surname = userObj["Surname"];
    $('#surnameE').val(surname);
})

$('#btn-save').click(function (e) {
    let username = $('#usernameE').val();
    let password = $('#passwordE').val();
    let email = $('#emailE').val();
    let name = $('#nameE').val();
    let surname = $('#surnameE').val();
    let user = localStorage.getItem('user');
    let userObj = JSON.parse(user);
    let admin = userObj["Admin"];
    let userID = userObj["UserID"];

    debugger;

    //AJAX
    if (!username || !password || !email || !name || !surname) {
        alert("Insert all data");
    }
    else {
        //AJAX poziv
        $.ajax({
            type: "POST",
            url: "http://localhost:50104/api/user/edit",
            data: { Username: username, Password: password, Email: email, Name: name, Surname: surname, Admin: admin, UserID: userID},
            success: function (data) {
                if (data) {
                    localStorage.removeItem('user');
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