function IsFirstNameEmpty() {
    if (document.getElementById('TxtFName').value == '') {
        return 'First Name should not be empty';
    }
    return '';
}

function IsFirstNameInValid() {
    if (document.getElementById('TxtFName').value.indexOf('@') == -1) {
        return 'First Name should contain @';
    }
    return '';
}

function IsLastNameInValid() {
    if (document.getElementById('TxtLName').value.length > 5) {
        return 'Last Name should not contain more than 5 character';
    }
    return '';
}

function IsSalaryEmpty() {
    if (document.getElementById('TxtSalary').value == '') {
        return 'Salary should not be empty';
    }
    return '';
}

function IsSalaryInValid() {
    if (isNaN(document.getElementById('TxtSalary').value)) {
        return 'Enter valid salary';
    }
    return '';
}

function IsValid() {
    var FirstNameEmptyMessage = IsFirstNameEmpty();
    var FirstNameInValidMessage = IsFirstNameInValid();
    var LastNameInValidMessage = IsLastNameInValid();
    var SalaryEmptyMessage = IsSalaryEmpty();
    var SalaryInvalidMessage = IsSalaryInValid();
    var FinalErrorMessage = 'Errors:';

    if (FirstNameEmptyMessage != '')
        FinalErrorMessage += '\n' + FirstNameEmptyMessage;
    if (FirstNameInValidMessage != '')
        FinalErrorMessage += '\n' + FirstNameInValidMessage;
    if (LastNameInValidMessage != '')
        FinalErrorMessage += '\n' + LastNameInValidMessage;
    if (SalaryEmptyMessage != '')
        FinalErrorMessage += '\n' + SalaryEmptyMessage;
    if (SalaryInvalidMessage != '')
        FinalErrorMessage += '\n' + SalaryInvalidMessage;
    if (FinalErrorMessage != 'Errors:') {
        alert(FinalErrorMessage);
        return false;
    }else {
        return true;
    }
}