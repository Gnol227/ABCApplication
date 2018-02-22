var query = {
    init: function () {
        query.registerEvents();
    },
    registerEvents: function () {
        $('.btn-change').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            $.ajax({
                url: "/Query/ChangeStatus",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    console.log(response);
                    if (response.status == true) {
                        btn.text('Done');
                    } else {
                        btn.text('Working');
                    }
                }
            });
        });
    }
}
query.init();