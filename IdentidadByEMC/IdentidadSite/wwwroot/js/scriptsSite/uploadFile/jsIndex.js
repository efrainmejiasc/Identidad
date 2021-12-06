$(document).ready(function () {
    console.log("ready!");
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
