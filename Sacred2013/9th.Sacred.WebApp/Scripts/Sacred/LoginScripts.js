/* HOME LOGIN FORM SUBMIT */
$(document).on('submit', "#NavLoginForm", function () {

});

/* HOME REGISTER FORM SUBMIT*/
$(document).on('submit', "#homeRegisterForm", function () {
    $(".form-error-icon").hide();
    $(".js-home-register-alert").hide();

    var email = $("#reg_email").val();
    var username = $("#reg_username").val();
    var password = $("#reg_password").val();
    var confirmPassword = $("#reg_confirm_password").val();
    var errorsExist = false;

    // Basic error checking
    if (password.length < 8)
    {
        $("#reg_password_error").show();
        errorsExist = true;
    }
    if (password != confirmPassword)
    {
        $("#reg_confirm_password_error").show();
        errorsExist = true;
    }

    // Handle submit if no errors
    if (!errorsExist)
    {
        var newUser = {
            Email: email,
            UserName: username,
            Password: password,
            ConfirmPassword: confirmPassword
        };

        $.ajax({
            url: api_baseurl + 'User/RegisterUser',
            type: 'POST',
            async: false,
            cache: false,
            traditional: true,
            data: JSON.stringify(newUser),
            contentType: "application/json",
            success: function (data) {
                if (!data.Success)
                {
                    // Show error
                    console.log("Failure");
                    $(".js-home-register-alert").html(data.Message);
                    $(".js-home-register-alert").show();
                }
                else
                {
                    // TODO: Redirect to success / validate page
                    location.reload();
                }
            },
            error: function (xhr, ajaxOptions, thrownError) {
                //alert(xhr.status);
                //alert(thrownError);
            }
        });
    }

    return false;
});

/* DOCUMENT READY FUNCTION */
$(function () {
    $(".form-error-icon").tooltip();
});