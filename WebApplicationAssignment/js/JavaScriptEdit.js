function validateForm() {
    var inputID = document.getElementById("txtInput").value;
    if (inputID == '') {
        alert("ID must be filled out");
        return false;
    }

    var inputName = document.getElementById("txtName").value;
   
    if (inputName == '') {
        alert("Name must be filled out");
        return false;
    }
    var inputEmail = document.getElementById("txtEmail").value;

    if (inputEmail == '') {
        alert("Email must be filled out");
        return false;
    }

    var dropdownList1 = document.getElementById("ddlPlaces1").value;
    if (dropdownList1 == 'Please Select') {
        alert("Select option from First Place List");
        return false;
    }

    var dropdownList2 = document.getElementById("ddlPlaces2").value;
    if (dropdownList2 == 'Please Select') {
        alert("Select option from Second Place List");
        return false;
    }

    var addressDropdown1 = document.getElementById("ddlAddresses1").value;
    if (addressDropdown1 == 'Please Select') {
        alert("Select First Address for Place One");
        return false;
    }

    var addressDropdown2 = document.getElementById("ddlAddresses2").value;
    if (addressDropdown2 == 'Please Select') {
        alert("Select Second Address for Place One");
        return false;
    }

    var addressDropdown3 = document.getElementById("ddlAddresses3").value;
    if (addressDropdown3 == 'Please Select') {
        alert("Select First Address for Place Two");
        return false;
    }

    var addressDropdown4 = document.getElementById("ddlAddresses4").value;
    if (addressDropdown4 == 'Please Select') {
        alert("Select Second Address for Place Two");
        return false;
    }
}