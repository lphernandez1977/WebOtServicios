
$(function() {
    //instancia cuando se carga la pagina
    var info;
    $(document).ready(function(){
        var options = {
            'maxCharacterSize': textareaMaxLength3,
            'originalStyle': 'originalTextareaInfo',
            'warningStyle' : 'warningTextareaInfo',
            'warningNumber': 40,
            'displayFormat' : 'caract. #input/#max'
        };
        $('#' + textarea1).textareaCount(options);				
    }); 
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
    //cuando se realizaron llamados post-back
    function EndRequestHandler(sender, args) {
        var info;
        $(document).ready(function(){
            var options = {
                'maxCharacterSize': textareaMaxLength3,
                'originalStyle': 'originalTextareaInfo',
                'warningStyle' : 'warningTextareaInfo',
                'warningNumber': 40,
                'displayFormat' : 'caract. #input/#max'
            };
            $('#' + textarea1).textareaCount(options);				
        });
    }

});