var cart = {
    init: function() {
        cart.regEvents();
    },
    regEvents: function() {
        $('#btnContinueShopCart').off('click').on('click', function() {
            window.location.href = "/HomeClient/Index";
        });

        $('#btnPayment').off('click').on('click', function () {
            window.location.href = "/ShoppingCart/Payment";
        });

        $('#btnUpdateShopCart').off('click').on('click', function () {
            var listProduct = $('.quantityProduct');
            var cartList = [];
            $.each(listProduct, function(i, item) {
                cartList.push({
                    sl: $(item).val(),
                    Product: {
                        ID_Product: $(item).data("id")
                    }
                });
            });

            $.ajax({
                url: '/ShoppingCart/Update',
                data: { cartModel: JSON.stringify(cartList) },
                dataType: 'json',
                type: 'POST',
                success: function(res) {
                    if (res.status == true) {
                        window.location.href = "/ShoppingCart";
                    }
                }
            });
        });

        $('.btnDelete').off('click').on('click', function () {
            
            $.ajax({
                url: '/ShoppingCart/DeleteItem',
                data: { id: $(this).data("id") },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/ShoppingCart";
                    }
                }
            });
        });

        $('#btnDeleteAllShopCart').off('click').on('click', function () {

            $.ajax({
                url: '/ShoppingCart/DeleteAll',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/ShoppingCart";
                    }
                }
            });
        });

    }
}
cart.init();