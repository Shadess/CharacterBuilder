/* HOME LOGIN FORM SUBMIT */
$(document).on('submit', "#NavLoginForm", function () {

});




/* HOME REGISTER FORM SUBMIT*/
$(document).on('submit', "#homeRegisterForm", function () {
    $(".form-error-icon").hide();
    $(".js-home-register-alert").hide();
    $("#reg_submit").prop('disabled', true);

    var email = $("#reg_email").val();
    var username = $("#reg_username").val();
    var password = $("#reg_password").val();
    var confirmPassword = $("#reg_confirm_password").val();

    // Basic error checking
    if (password.length < 8)
    {
        $("#reg_password_error").show();
        $("#reg_submit").prop('disabled', false);
        return false;
    }
    if (password !== confirmPassword)
    {
        $("#reg_confirm_password_error").show();
        $("#reg_submit").prop('disabled', false);
        return false;
    }

    // Fill in our fields
    $("#reg_hidden_email").val(email);
    $("#reg_hidden_username").val(username);
    $("#reg_hidden_password").val(password);
    $("#reg_hidden_confirm_password").val(confirmPassword);
});




/* DOCUMENT READY FUNCTION */
$(function () {
    $(".form-error-icon").tooltip();
});