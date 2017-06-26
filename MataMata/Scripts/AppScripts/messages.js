dataObject = null;
nibo = {
    showMessage: function (msg, type) {

        document.getElementById('messages').innerHTML = trataMensagem(msg, type);
        $('#messages').fadeIn(100).delay(800).fadeOut(1500).delay(2000);
    },


}

scriptTypeMsg = {
    Success: 83,
    Error: 69,
    Information: 73,
    Warning: 87
}

function trataMensagem(msg, type) {
    var scope = '';
    switch (type) {
        case 83: {
            scope += '<div class="success message">';
            scope += '<h3>Sucesso</h3>';
            scope += '<p>' + msg + '</p>';
            scope += '</div>';

            break;
        }
        case 69: {

            scope += '<div class="error message">';
            scope += ' <h3>Falha</h3>';
            scope += '<p>' + msg + '</p>';
            scope += '</div>';
            break;
        }
        case 73: {

            scope += '<div class="info message">';
            scope += '<h3>Informativo</h3>';
            scope += '<p>' + msg + '</p>';
            scope += '</div>';
            break;
        }
        case 87: {
            scope += '<div class="warning message">';
            scope += '<h3>Atenção</h3>';
            scope += '<p>' + msg + '</p>';
            scope += '</div>';
            break;
        }
        default:

    }
    return scope;
}

function ValidateProperties(myObj, callback) {

    dataObject = myObj;
    if (dataObject['dados'] != null) {
        if (dataObject['msg'] != null && dataObject['MsgType'] != null) {
            nibo.showMessage(dataObject.msg, dataObject.MsgType);
        }
        return callback(dataObject.dados);
    } else {
        if (dataObject['msg'] != null && dataObject['MsgType'] != null) {
            nibo.showMessage(dataObject.msg, dataObject.MsgType);
        }
    }


}

