(function () {

    document.getElementById("btnExcluir").addEventListener("click", function () {
        excluir(function (response) {
            if (response) {
                MontaGridConsulta();
                limpaTela();
                MostrarConsulta();

            }

        });

    });

    document.getElementById("btnAdd").addEventListener("click", function (response) {

        MostrarCadastro();
        limpaTela();
        $('#btnExcluir').attr('disabled', 'disabled');

    });

    document.getElementById("btnCancelar").addEventListener("click", function () {
        limpaTela();
        MostrarConsulta();
    });

    document.getElementById("btnSalvar").addEventListener("click", function () {
        AddItem(function (response) {
            if (response) {
                MontaGridConsulta();
                limpaTela();
                MostrarConsulta();
            }
        });

    });

})();

//Runs the update in the table
function afterSubmitGrid() {
    $('#list').jqGrid("setGridParam", { datatype: 'json' }).trigger('reloadGrid');
    return [true];
}

function MontaGridConsulta() {
    var jgrid = $("#list");
    jgrid.jqGrid({
        url: 'RegisterRules/GetAllRules',
        datatype: "json",
        colNames: ['ID', 'Menimo de Pontos', 'Máximo de Pontos','Número de Times','Número de Fases'],
        colModel: [
            { key: false, name: 'IdRules', index: 'IdRules', width: 55 },
            { key: false, name: 'MinScore', index: 'MinScore asc, invdate', width: 200 },
            { key: false, name: 'MaxScore', index: 'MaxScore, invdate', width: 200 },
            { key: false, name: 'NumberOfPaticipants', index: 'NumberOfPaticipants, invdate', width: 200 },
            { key: false, name: 'NumberOfStages', index: 'NumberOfStages, invdate', width: 200 },
        ],
        rowNum: 10,
        rowList: [10, 20, 30],
        pager: '#pager',
        sortname: 'IdRules',
        sortorder: "asc",
        viewrecords: true,
        caption: 'Regras do campeonato  - CLIQUE 2 VEZES NA LINHA DESEJADA PARA EDITAR OU EXCLUIR',
        emptyrecords: 'Nenhuma informação à ser exibida',

        ondblClickRow: function (rowId) {
            var rowData = $(this).getRowData(rowId);

            Editar(rowData);
        },
        jsonReader: {
            root: "rows",
            page: "page",
            total: "total",
            records: "records",
            repeatitems: false,
            Id: "0"
        },
        autowidth: true,
        multiselect: false
    })
    afterSubmitGrid();


}

window.onload = function () {
    MontaGridConsulta();

}

function Editar(data) {
    $('#IdRules').val(data['IdRules']);
    $('#MinScore').val(data['MinScore']),
    $('#MaxScore').val(data['MaxScore']),
    $('#NumberOfPaticipants').val(data['NumberOfPaticipants']),
    $('#NumberOfStages').val(data['NumberOfStages']),
    $('#btnExcluir').removeAttr('disabled', 'disabled');
    MostrarCadastro();
}

function MostrarConsulta() {

    $('#cadastro').slideUp(300);
    $('#consulta').slideDown(300, function () {

    });
};

function MostrarCadastro() {

    $('#consulta').slideUp(300);
    $('#cadastro').slideDown(300);

};

function MontaObjeto() {
    return {
        IdRules: $('#IdRules').val(),
        MinScore: $('#MinScore').val(),
        MaxScore: $('#MaxScore').val(),
        NumberOfPaticipants: $('#NumberOfPaticipants').val(),
        NumberOfStages: $('#NumberOfStages').val(),

    }
}

function excluir(callback) {
    postAJAX('/RegisterRules/Excluir', JSON.stringify({ pRules: MontaObjeto() }), function (response) {

        if (response) {
            return callback(response);
        }
    });



}

function AddItem(callback) {
    postAJAX('/RegisterRules/Save', JSON.stringify({ pRules: MontaObjeto() }), function (response) {

        if (response) {
            return callback(response);
        }
    });


}

function limpaTela() {
    $('input[type=number]').val(null);
}