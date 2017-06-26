function postAJAX(url, data, success) {
    $.ajax({
        url: url,
        method: 'POST',
        contentType: 'application/json',
        data: data,
        success: function (response) {
            ValidateProperties(response, function (result) {
                if (result) {
                    return success(result);
                }
               
            });
            
        },
        error: function (error) {
            return error;
        }
    });

    
   
};