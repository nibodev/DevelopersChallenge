var Equipes = [];
var listagem = [];
var itemAdd = [];
(function () {
    document.getElementById("btnAdd").addEventListener("click", function (response) {
       
        Salvar(itemAdd, function (result) {
            MontaGridConsulta();
            MontaGridConsultaChampionship();
        });
    });

    document.getElementById("btnCancelar").addEventListener("click", function () {
        limpaTela();
        MostrarConsulta();
    });

    document.getElementById("btnExcluir").addEventListener("click", function () {
        Excluir(function (response) {
            if (response) {
                MontaGridConsulta();
                MontaGridConsultaChampionship();
                limpaTela();
                MostrarConsulta();

            }

        });

    });

})();

function afterSubmitGrid() {
    $('#list').jqGrid("setGridParam", { datatype: 'json' }).trigger('reloadGrid');
    return [true];
}

function MontaGridConsulta() {
    var jgrid = $("#list");
    jgrid.jqGrid({
        url: 'RegisterTeam/GetAllTeamsNotSelectedToChampionship',
        datatype: "json",
        colNames: ['ID', 'Nome'],
        colModel: [
            { key: false, name: 'IdTeam', index: 'IdTeam', width: 55 },
            { key: false, name: 'Name', index: 'Name asc, invdate', width: 200 }
        ],
        rowNum: 10,
        rowList: [10, 20, 30],
        pager: '#pager',
        sortname: 'Name',
        sortorder: "asc",
        viewrecords: true,
        caption: 'Listagem de times',
        emptyrecords: 'Nenhuma informação à ser exibida',

        ondblClickRow: function (rowId) {
            var rowData = $(this).getRowData(rowId);

        },
        onSelectRow: function(rowid) {
            var rowData = $(this).getRowData(rowid);
            itemAdd.push(rowData);
            if (itemAdd.length == 2) {
                $('#btnAdd').removeAttr('disabled', 'disabled');
            }
            if (itemAdd.length > 2) {
                nibo.showMessage('Não é possivel adicionar 3 adversários ou mais, ao mesmo tempo, na mesma chave.', scriptTypeMsg.Warning);
                itemAdd.splice(rowData, 1);
            }
            // do something with row
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
        multiselect: true
    })
    //.click(function () {
    //    var rowData = $(this).getRowData();
    //    itemAdd.push(rowData);
    //    if (itemAdd.length == 2) {
    //        $('#btnAdd').removeAttr('disabled', 'disabled');
    //    }
    //});
    afterSubmitGrid();


}

function afterSubmitGridChampionship() {
    $('#list1').jqGrid("setGridParam", { datatype: 'json' }).trigger('reloadGrid');
    return [true];
}

function MontaGridConsultaChampionship() {
    var jgrid = $("#list1");
    jgrid.jqGrid({
        url: 'RegisterChampionship/GetAllAdversaries',
        datatype: "json",
        colNames: ['ID', 'HiddenID1', 'Eqipe1', 'HiddenID2', 'Equipe2'],
        colModel: [
            { key: false, name: 'IdCampionShip', index: 'IdCampionShip', width: 55 },
            { key: false, name: 'IdTeam1', index: 'IdTeam1 asc, invdate', width: 200, hidden: true },
            { key: false, name: 'Name1', index: 'Name1 asc, invdate', width: 200},
            { key: false, name: 'IdTeam2', index: 'IdTeam2 asc, invdate', width: 200, hidden: true },
            { key: false, name: 'Name2', index: 'Name2 asc, invdate', width: 200 },
        ],
        rowNum: 10,
        rowList: [10, 20, 30],
        pager: '#pager',
        sortname: 'IdChampionship',
        sortorder: "asc",
        viewrecords: true,
        caption: 'Listagem de Adversarios - CLIQUE 2 VEZES NA LINHA DESEJADA PARA EXCLUIR',
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
    afterSubmitGridChampionship();
    $('#btnAdd').attr('disabled', 'disabled');

}

function Editar(data) {
    $('#IdChampionship').val(data['IdCampionShip']);
    $('#IdTeam1').val(data['IdTeam1']);
    $('#Name1').val(data['Name1']);
    $('#IdTeam2').val(data['IdTeam2']);
    $('#Name2').val(data['Name2']);
    itemAdd.push(data);
    MostrarCadastro();
}

function Excluir(callback) {
    postAJAX('/RegisterChampionship/DeleteAdversaries', JSON.stringify({ pChampionship: MontaObjetoExclusao(itemAdd) }), function (response) {

        if (response) {
            itemAdd = [];
            return callback(response);
        }
    });
}

window.onload = function () {
    MontaGridConsulta();
    MontaGridConsultaChampionship();
    MostrarConsulta();
}

function MontaObjeto(data) {
    var obj = {
        IdCampionShip: 0,
        IdTeam1: data[0].IdTeam,
        Name1: data[0].Name,
        IdTeam2: data[1].IdTeam,
        Name2: data[1].Name,
    }
    return obj;
}

function MontaObjetoExclusao(data) {
    var obj = {
        IdCampionShip: data[0].IdCampionShip,
        IdTeam1: data[0].IdTeam1,
        Name1: data[0].Name1,
        IdTeam2: data[0].IdTeam2,
        Name2: data[0].Name2,
    }
    return obj;
}

function montaListaCampeonato(data) {
    $('#IdTeam').val(data['IdTeam']);

    listagem.push({ IdTeam: data['IdTeam'] })

    if (listagem.length == 2) {
        salvar(listagem)
    }
}

function Salvar(data,callback) {
    postAJAX('/RegisterChampionship/SaveAdversaries', JSON.stringify({ pChampionship: MontaObjeto(data) }), function (response) {

        if (response) {
            itemAdd = [];
            return callback(response);
        }
    });
}

function limpaTela() {
    $('input[type=text]').val('');
    $('input[type=hidden]').val('');
    itemAdd = [];
    $('#btnAdd').attr('disabled', 'disabled');
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