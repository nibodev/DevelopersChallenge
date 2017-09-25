$(document).ready(function () {

    $("#linkQuart1").click(function () {
        var kingdomQuart1 = $("#kingdomQuart1").val();
        var kingdomQuart2 = $("#kingdomQuart2").val();

        $.ajax({
            url: "ProcessVictory",
            data: { idKingdomOne: kingdomQuart1, idKingdomTwo: kingdomQuart2 },
            dataType: "json",
            type: "GET",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                $("#kingdomNameSemi1").val(data.Data.Name);
                $("#kingdomIdSemi1").val(data.Data.Id);
                $("#kingdomNameSemi1").addClass("campo_focus");
            },
            error: function (xhr) {
                toastr.error("Error verifying!", "Error");
            }
        });
    });


    $("#linkQuart2").click(function () {
        var kingdomQuart3 = $("#kingdomQuart3").val();
        var kingdomQuart4 = $("#kingdomQuart4").val();

        $.ajax({
            url: "ProcessVictory",
            data: { idKingdomOne: kingdomQuart3, idKingdomTwo: kingdomQuart4 },
            dataType: "json",
            type: "GET",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                $("#kingdomNameSemi2").val(data.Data.Name);
                $("#kingdomIdSemi2").val(data.Data.Id);
                $("#kingdomNameSemi2").addClass("campo_focus");
            },
            error: function (xhr) {
                toastr.error("Error verifying!", "Error");
            }
        });
        
    });


    $("#linkEnd").click(function () {
        var kingdomSemi1 = $("#kingdomIdSemi1").val();
        var kingdomSemi2 = $("#kingdomIdSemi2").val();

        $.ajax({
            url: "ProcessVictory",
            data: { idKingdomOne: kingdomSemi1, idKingdomTwo: kingdomSemi2 },
            dataType: "json",
            type: "GET",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                $("#kingdomWinner").val(data.Data.Name);
                $("#kingdomWinner").addClass("campo_focus");
                toastr.success("We have the champion!","Victory");
            },
            error: function (xhr) {
                toastr.error("Check for winners in the previous step!", "Error");
            }
        });
    });

    $("#btnReturn").click(function () {
        window.location = "Kingdoms";
    });




});