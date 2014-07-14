var ErrorMsg ="";
var Separator = "<br/> ";

function RequiredTextbox(_ctrlId, errorMsg)
{
    var ctrlId = '#' + _ctrlId;
    if ($(ctrlId).val() == "") {
        ErrorMsg += errorMsg + Separator;
        $(ctrlId).addClass('txt-validation-error');
    }
    else {
        $(ctrlId).removeClass('txt-validation-error');
    }
        
}

function RequiredDropdown(_ctrlId, minIndex, errorMsg)
{
    var ctrlId = '#' + _ctrlId;
    if ($(ctrlId).prop("selectedIndex") <= minIndex) {
        ErrorMsg += errorMsg + Separator;
        $(ctrlId).addClass('txt-validation-error');
    }
    else {
        $(ctrlId).removeClass('txt-validation-error');
    }
}

function ValidateMobilenumber(_ctrlId, errorMsg)
{
    var ctrlId = '#' + _ctrlId;
    if ($(ctrlId).val() != "")
    {
        if ($(ctrlId).val().match("^[7-9][0-9]{9}$")) {
            $(ctrlId).removeClass('txt-validation-error');
        }
        else {
            $(ctrlId).addClass('txt-validation-error');
            ErrorMsg += errorMsg + Separator
        }
    }
    
}

function ValidatePhonenumber(_ctrlId, errorMsg)
{
    var ctrlId = '#' + _ctrlId;
    if ($(ctrlId).val() != "") {
        if ($(ctrlId).val().match("^[0][1-9]{10}$")) {
            $(ctrlId).removeClass('txt-validation-error');
        }
        else {
            $(ctrlId).addClass('txt-validation-error');
            ErrorMsg += errorMsg + Separator
        }
    }
}

function ValidateZip(_ctrlId, errorMsg) {
    var ctrlId = '#' + _ctrlId;
    if ($(ctrlId).val() != "") {
        if ($(ctrlId).val().match("^[0-9]{6}$")) {
            $(ctrlId).removeClass('txt-validation-error');
        }
        else {
            $(ctrlId).addClass('txt-validation-error');
            ErrorMsg += errorMsg + Separator
        }
    }

}

function ValidateEmailaddress(_ctrlId, errorMsg)
{
    var ctrlId = '#' + _ctrlId;
    var emailRegex = /\S+@\S+\.\S+/;
    if ($(ctrlId).val() != "") {
        if (emailRegex.test($(ctrlId).val())) {
            $(ctrlId).removeClass('txt-validation-error');
        }
        else {
            $(ctrlId).addClass('txt-validation-error');
            ErrorMsg += errorMsg + Separator
        }
    }
    
}

function ValidateWebaddress(_ctrlId, errorMsg) {
    var ctrlId = '#' + _ctrlId;
    if ($(ctrlId).val() != "") {
        if ($(ctrlId).val().test("/^((https?):\/\/)?([w|W]{3}\.)+[a-zA-Z0-9\-\.]{3,}\.[a-zA-Z]{2,}(\.[a-zA-Z]{2,})?$/")) {
            $(ctrlId).removeClass('txt-validation-error');
        }
        else {
            $(ctrlId).addClass('txt-validation-error');
            ErrorMsg += errorMsg + Separator
        }
    }

}

function ValidMinLength(_ctrlId, length, errorMsg) {
    var ctrlId = '#' + _ctrlId;
    if ($(ctrlId).val() != "") {
        if ($(ctrlId).val().length < length) {
            $(ctrlId).addClass('txt-validation-error');
            ErrorMsg += errorMsg + Separator;
        }
        else {
            $(ctrlId).removeClass('txt-validation-error');
        }
    }
}

function AlertError()
{
    if (ErrorMsg == "")
        return true;
    else
    {
        $("#dialog-message").html(ErrorMsg);
        $("#dialog-message").dialog("open");
        ErrorMsg = "";
        return false;
    }
}

function GetErrorMsg()
{
    return ErrorMsg;
}