/// <reference path="jquery-1.9.1.min.js" />

$(function () {
    $('#make').attr('disabled', 'disabled');
    $('#model').attr('disabled', 'disabled');
    $('#car').attr('disabled', 'disabled');
    
    GetMake();
});

$("#make").change(function () {
    var makeId = $("#make").val();
    GetModelByMakeId(makeId);
});

$("#model").change(function () {
    var modelId = $("#model").val();
    GetCarByModelId(modelId);
});

function GetMake() {
    $.ajax({
        url: "http://localhost:86/api/MakeAPI",
        type: "GET",
        dataType: 'json',
        success: function (data) {
            SetMake(data);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert(textStatus);
        }
    });
}

function SetMake(makes) {
    $('#make').empty();
    $('#model').empty();
    $('#car').empty();
    
    $('#make').removeAttr('disabled');
    
    $("#make").append("<option value='' selected='selected'></option>");

    $.each(makes, function (index, value) {
        $('#make').append($('<option>', {
            value: value.MakeId,
            text: value.Name
        }));
    });
}

function GetModelByMakeId(makeId) {
    $.ajax({
        url: "http://localhost:86/api/ModelAPI/" + makeId,
        type: "GET",
        dataType: 'json',
        success: function (data) {
            SetModel(data);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert(textStatus);
        }
    });
}

function SetModel(models) {
    $('#model').empty();
    $('#car').empty();
    
    $('#model').removeAttr('disabled');

    $("#model").append("<option value='' selected='selected'></option>");

    $.each(models, function (index, value) {
        $('#model').append($('<option>', {
            value: value.ModelId,
            text: value.Name
        }));
    });
}

function GetCarByModelId(modelId) {
    $.ajax({
        url: "http://localhost:86/api/CarAPI/" + modelId,
        type: "GET",
        dataType: 'json',
        success: function (data) {
            SetCar(data);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert(textStatus);
        }
    });
}

function SetCar(cars) {
    $('#car').empty();
    
    $('#car').removeAttr('disabled');

    $("#car").append("<option value='' selected='selected'></option>");

    $.each(cars, function (index, value) {
        $('#car').append($('<option>', {
            value: value.ModelId,
            text: value.Name
        }));
    });
}