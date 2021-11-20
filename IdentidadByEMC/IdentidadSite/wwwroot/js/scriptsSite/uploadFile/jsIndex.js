$(document).ready(function () {
    console.log("ready!");
    $('#uploadFile_').hide();
    HideSpinner();
});

function HideSpinner() {
    $('#divLoading').show();
    $('#itemLoading').show();
}

function ShowSpinner(){
    $('#divLoading').show();
    $('#itemLoading').show();
}
