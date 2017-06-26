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
        url: 'RegisterPhase/GetAllStages',
        datatype: "json",
        colNames: ['ID', 'Nome'],
        colModel: [
            { key: false, name: 'IdPhase', index: 'IdPhase', width: 55 },
            { key: false, name: 'Name', index: 'Name asc, invdate', width: 200 }
        ],
        rowNum: 10,
        rowList: [10, 20, 30],
        pager: '#pager',
        sortname: 'Name',
        sortorder: "asc",
        viewrecords: true,
        caption: 'Listagem de fases do campeonato  - CLIQUE 2 VEZES NA LINHA DESEJADA PARA EDITAR OU EXCLUIR',
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
    $('#IdPhase').val(data['IdPhase']);
    $('#Name').val(data['Name']);
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
        IdPhase: $('#IdPhase').val(),
        Name: $('#Name').val()

    }
}

function excluir(callback) {
    postAJAX('/RegisterPhase/Excluir', JSON.stringify({ pPhase: MontaObjeto() }), function (response) {

        if (response) {
            return callback(response);
        }
    });



}

function AddItem(callback) {
    postAJAX('/RegisterPhase/Save', JSON.stringify({ pPhase: MontaObjeto() }), function (response) {

        if (response) {
            return callback(response);
        }
    });


}

function limpaTela() {
    $('input[type=text]').val('');
}