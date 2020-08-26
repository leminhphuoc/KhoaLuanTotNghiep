var Acc = {
    init: function () {
        Acc.registerEvents();
    },
    registerEvents: function () {
        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            $.ajax({
                url: "/Admin/RoomAdmin/ChangeStatus",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function (res) {
                    console.log(res);
                    if (res.Status == true) {
                        btn.text('Active');
                    }
                    else {
                        btn.text('Empty');
                    }
                }
            });
        });
    }
}
Acc.init();