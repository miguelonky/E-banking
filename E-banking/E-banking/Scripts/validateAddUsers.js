$(function() {
    $('#formAddUser').validate({
        rules: {
            fname: {
                required: true,
                minlength: 3,
                maxlength: 45
            },
            lname: {
                required: true,
                minlength: 3,
                maxlength: 45
            },
            cedula: {
                required: true,
                number: true,
                minlength: 11,
                maxlength: 11
            },
            email: {
                required: true,
                email: true,
                minlength: 5,
                maxlength: 100
            },
            phone: {
                required: true,
                number: true,
                minlength: 10,
                maxlength: 10
            },
            birthdate: {
                required: true,
                date: true,
                minlength: 3,
                maxlength: 45
            }
        }
    });

    $('#changepassword').validate({
        rules: {
            actual_password: {
                required: true,
                minlength: 6
            },
            new_password: {
                required: true,
                minlength: 6
            },
            confirm_password: {
                required: true,
                minlength: 6
            }
        }
    });
})