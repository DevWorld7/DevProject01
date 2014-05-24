var ErrorMsg ="";
var Separator = "\n ";

function RequiredTextbox(_ctrlId, errorMsg)
{
    var ctrlId = '#' + _ctrlId;
    if ($(ctrlId).val() == "")
        ErrorMsg += errorMsg + Separator;
}

function ValidateMobilenumber(_ctrlId, errorMsg)
{
    var ctrlId = '#' + _ctrlId;
    if ($(ctrlId).val() != "")
    {
        if ($(ctrlId).val().match("^[7-9][0-9]{9}$")) { }
        else { ErrorMsg += errorMsg + Separator}
    }
    
}

function ValidatePhonenumber(_ctrlId, errorMsg)
{
    var ctrlId = '#' + _ctrlId;
    if ($(ctrlId).val() != "") {
        if ($(ctrlId).val().match("^[0][1-9]{10}$")) { }
        else { ErrorMsg += errorMsg + Separator }
    }
}

function ValidateOnlyNumber(_ctrlId, digits, errorMsg)
{
    
}

function ValidateEmailaddress(_ctrlId, errorMsg)
{
    var ctrlId = '#' + _ctrlId;
    if ($(ctrlId).val() != "") {
        if ($(ctrlId).val().match("^[a-zA-Z0-9_.+-]+@@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$")) { }
        else { ErrorMsg += errorMsg + Separator }
    }
    
}

function AlertError()
{
    if (ErrorMsg == "")
        return true;
    else
    {
        alert(ErrorMsg);
        ErrorMsg = "";
        return false;
    }
}

function GetErrorMsg()
{
    return ErrorMsg;
}