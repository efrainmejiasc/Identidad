$(document).ready(function () {
    console.log("ready!");
    $('#uploadFile_').hide();
    HideSpinner();
});

function HideSpinner() {
    $('#divLoading').hide();
    $('#itemLoading').hide();
    $('#containerLoading').hide();
}

function ShowSpinner(){
    $('#divLoading').show();
    $('#itemLoading').show();
    $('#containerLoading').show();
}
