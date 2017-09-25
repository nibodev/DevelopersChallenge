$(document).ready(function () {

    $('#giantsKingdom').slider({
        formatter: function (value) {
            return value;
        }
    });

    $('#swordmenKingdom').slider({
        formatter: function (value) {
            return value;
        }
    });

    $('#archersKingdom').slider({
        formatter: function (value) {
            return value;
        }
    });
   
    $('#launchersKingdom').slider({
        formatter: function (value) {
            return value;
        }
    });

    $('#beatersKingdom').slider({
        formatter: function (value) {
            return value;
        }
    });

    var qtd_Lines = $("#bodyList tr").length;
    if (qtd_Lines > 0) {
        var idLines = qtd_Lines;
    } else {
        var idLines = 0;
    }

    $("#btnSave").click(function () {

        idLines++;

        var qtdLinhas = $("#bodyList tr").length;
        
        if (qtdLinhas == 4) {
            LimpaCampos();
            toastr.error("It is only allowed to register four kingdoms!", "Error");

        } else {

            var name = $("#nameKingdom").val();
            var giants = $("#giantsKingdom").val();
            var swordmen = $("#swordmenKingdom").val();
            var archers = $("#archersKingdom").val();
            var launchers = $("#launchersKingdom").val();
            var beaters = $("#beatersKingdom").val();

            var dataArray = [giants, swordmen, archers, launchers, beaters];

            var verifyVal = 0;
            for (i = 0; i < dataArray.length; i++) {
                if ((dataArray[i] == 10) || (dataArray[i] == 9)) {
                    verifyVal = i;
                }
            }
            
            if (name == "") {
                toastr.warning("Name is required!", "Warning");
            } else if (verifyVal >= 1) {
                toastr.warning("Rule: Only one item can be equal to 9 or 10!", "Warning");
            } else {

                var kingdom = { Name: name, Giants: giants, Swordsmen: swordmen, Archers: archers, Launchers: launchers, Beaters: beaters };

                $.ajax({
                    url: "Register",
                    data: JSON.stringify(kingdom),
                    dataType: "json",
                    type: "POST",
                    contentType: 'application/json; charset=utf-8',
                    success: function (data) {

                        if (data.Status == 200) {
                            var newRow = $('<tr id=lineDelete_' + idLines + '>');
                            var cols = "";
                            cols += '<td>' + data.Data.Name + '</td>';
                            cols += '<td>' + data.Data.Giants + '</td>';
                            cols += '<td>' + data.Data.Swordsmen + '</td>';
                            cols += '<td>' + data.Data.Archers + '</td>';
                            cols += '<td>' + data.Data.Launchers + '</td>';
                            cols += '<td>' + data.Data.Beaters + '</td>';
                            cols += '<td><div id=btnDelete_' + idLines + '_' + data.Data.Id + ' class="btn btnDelete"><img src="../Images/delete.png"/></div></td>';
                            newRow.append(cols);
                            $("#bodyList").append(newRow);
                            LimpaCampos();

                            $("div[id^=btnDelete_" + idLines + "]").click(function () {
                                $("tr[id='lineDelete_" + $(this).attr("id").split("_")[1] + "']").remove();
                                idLines--;
                            });

                            $("div[id^=btnDelete_]").click(function () {
                                var id = $(this).attr("id").split("_")[2];

                                var tr = $(this).closest('tr');

                                $.ajax({
                                    url: "DeleteKingdom",
                                    data: { idKingdom: id },
                                    dataType: "json",
                                    type: "GET",
                                    contentType: 'application/json; charset=utf-8',
                                    success: function (data) {

                                        tr.remove();
                                    },
                                    error: function (xhr) {
                                        toastr.error("Error deleting!", "Error");
                                    }
                                });
                            });
                        }
                    },
                    error: function (xhr) {
                        toastr.error("Error saving!", "Error");
                    }
                });
            }
        }      
    });

    function LimpaCampos() {
        $("#nameKingdom").val("");
    };

    $("#start").click(function () {
        var qtdLinhas = $("#bodyList tr").length;

        if (qtdLinhas < 4) {
            toastr.warning("It takes four kingdoms to start the battle", "Warning");
        } else {
            window.location = "Battle";
        }
    });

    $("div[id^=btnDelete_]").click(function () {
        var id = $(this).attr("id").split("_")[1];

        var tr = $(this).closest('tr');

        $.ajax({
            url: "DeleteKingdom",
            data: { idKingdom : id },
            dataType: "json",
            type: "GET",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                
                tr.remove();
            },
            error: function (xhr) {
                toastr.error("Error deleting!", "Error");
            }
        });
    });

});