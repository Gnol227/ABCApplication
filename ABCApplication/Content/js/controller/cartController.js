var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {
        $('#btnContinue').off('click').on('click', function () {
            window.location.href = "/Product/Index";
        }); 

        $('#btnAddOrder').off('click').on('click', function () {
            window.location.href = "/add-order";
        }); 


        $('#btnRemoveAll').off('click').on('click', function () {

            $.ajax({
                url: '/Cart/RemoveAll',
                dataType: 'json',
                type: 'POST',
                success: function (e) {
                    if (e.status == true) {
                        window.location.href = "/Cart";
                    }
                }
            })
        });

        $('.btn-delete').off('click').on('click', function (e) { //prevent default value of # in href
            e.preventDefault();
            $.ajax({
                data: { id: $(this).data('id') },
                url: '/Cart/Remove',
                dataType: 'json',
                type: 'POST',
                success: function (response) {
                    if (response.status == true) {
                        window.location.href = "/Cart";
                    }
                }
            })
        });
    }
}
cart.init();