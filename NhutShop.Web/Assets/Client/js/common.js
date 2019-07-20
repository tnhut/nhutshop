﻿var common = {
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

        $('#btnLogout').off('click').on('click', function (e) {
            e.preventDefault();
            $('#frmLogout').submit();
        })

        $('.btnAddToCart').off('click').on('click', function (e) {
            debugger
            e.preventDefault();
            var productId = parseInt($(this).data('id'));
            $.ajax({
                url: '/ShoppingCart/Add',
                data: {
                    id: productId
                },
                type: 'POST',
                dataType: 'json',
                success: function (response) {
                    if (response.status) {
                        alert('Thêm sản phẩm thành công')
                    }
                }
            })
        })

    } 
    
}
common.init();