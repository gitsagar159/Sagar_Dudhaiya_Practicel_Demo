
function ValidateRegistrationForm() {

    var flagError = false;

    //Name 
    if ($("#name").val() == "" || $("#name").val() == undefined) {

        flagError = true;
        $("#name").parents(".form-group").find(".invalid-feedback").css("display", "block");
    }
    else {
        $("#name").parents(".form-group").find(".invalid-feedback").css("display", "none");
    }

    // Qualification
    if ($("#qualification").val() == "" || $("#qualification").val() == undefined) {

        flagError = true;
        $("#qualification").parents(".form-group").find(".invalid-feedback").css("display", "block");
    }
    else {
        $("#qualification").parents(".form-group").find(".invalid-feedback").css("display", "none");
    }

    // Age
    if ($("#age").val() == "" || $("#age").val() == undefined) {

        flagError = true;
        $("#age").parents(".form-group").find(".invalid-feedback").css("display", "block");
    }
    else {
        $("#age").parents(".form-group").find(".invalid-feedback").css("display", "none");
    }

    // Email
    if ($("#email").val() == "" || $("#email").val() == undefined) {

        flagError = true;
        $("#EmailError").css("display", "block");
        $("#InvelidEmailError").css("display", "none");
        
    }
    else {
        if (!ValidateEmail($("#email").val())) {
            flagError = true;
            $("#EmailError").css("display", "none");
            $("#InvelidEmailError").css("display", "block");
        }
        else {
            $("#EmailError").css("display", "none");
            $("#InvelidEmailError").css("display", "none");
        }
    }

    var passwordValid = false;
    // Password
    if ($("#password").val() == "" || $("#password").val() == undefined) {

        flagError = true;
        $("#password").parents(".form-group").find(".invalid-feedback").css("display", "block");
    }
    else {
        $("#password").parents(".form-group").find(".invalid-feedback").css("display", "none");
        passwordValid = true;
    }


    // Password
    if ($("#confirmpassword").val() == "" || $("#confirmpassword").val() == undefined) {

        flagError = true;
        $("#cpasswordError").css("display", "block");
        $("#InvalidcpasswordError").css("display", "none");
    }
    else {
        if (passwordValid) {

            if ($("#password").val() != $("#confirmpassword").val()) {
                flagError = true;
                $("#cpasswordError").css("display", "none");
                $("#InvalidcpasswordError").css("display", "block");
            }
            else {

                $("#cpasswordError").css("display", "none");
                $("#InvalidcpasswordError").css("display", "none");
            }

        }
    }




    if (flagError) {
        return false;
    }
    else {
        return true;
    }

}


function ValidateEmail(email) {
    var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    return regex.test(email);
}


function show(input)
{
    if (input.files && input.files[0])
    {
        var filerdr = new FileReader();
        filerdr.onload = function (e)
        {
            $('#user_img').attr('src', e.target.result);
        }
        filerdr.readAsDataURL(input.files[0]);
    }
}