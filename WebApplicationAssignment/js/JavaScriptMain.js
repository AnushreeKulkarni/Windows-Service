function validateForm() {
    var inputID = document.getElementById("txtInput").value;
    if (inputID == '') {
        alert("ID must be filled out");
        return false;
    }
}