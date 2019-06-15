var common = {
    init: function () {
        common.registerEvents();
    },
    registerEvents: function () {

        $("#txtKeyword").autocomplete({           
            minLength: 0,
            source: function (request, response) {
                debugger
                $.ajax({
                    url: "/Product/GetListProductByName",
                    async: true,
                    dataType: "json",
                    data: {
                        keyword: request.term
                    },
                    success: function (res) {
                        console.log(res.data);
                        response(res.data);
                    }
                });
            },
            focus: function (event, ui) {
                $("#txtKeyword").val(ui.item.label);
                return false;
            },
            select: function (event, ui) {
                $("#txtKeyword").val(ui.item.label);            
                return false;
            }
        }).autocomplete("instance")._renderItem = function (ul, item) {
            return $("<li>")
            .append("<div>" + item.label + "</div>")
            .appendTo(ul);
        };

    } 
    
}
common.init();