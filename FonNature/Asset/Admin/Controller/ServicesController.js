var Acc = {
    init: function () {
        Acc.registerEvents();
    },
    registerEvents: function () {
        $('.btn-image').off('click').on('click', function (e) {
            e.preventDefault();
            //$('#btn-multi-image').modal('show');
            $('#btn-multi-image').modal({
                backdrop: 'static',
                keyboard: false
            });
            $('#hideServiceId').val($(this).data('id'))
            Acc.loadImage();

        });

        $('#btnChooseImage').off('click').on('click', function (e) {
            e.preventDefault();
            CKFinder.popup({
                chooseFiles: true,
                onInit: function (finder) {
                    finder.on('files:choose', function (evt) {
                        var file = evt.data.files.first();
                        $('#imageList').append('<div class="col-md-4"><img style="margin-bottom:10px;max-height:100px" width="100" src="' + file.getUrl() + '" /><a class="btnDelImage" style="margin-left:5px" href="#"><i class ="fa fa-times"><i/></a></div>');
                        $('.btnDelImage').off('click').on('click', function (e) {
                            e.preventDefault();
                            $(this).parent().remove();
                        });
                    });
                }
            });

            finder.popup();
        })

        $('#btnSaveImage').off('click').on('click', function (e) {
            e.preventDefault();
            var images = [];
            $.each($('#imageList div img'), function (i, item) {
                images.push($(item).attr('src'));
            })
            var id = $('#hideServiceId').val();

            $.ajax({
                url: "/Admin/ServiceAdmin/SaveServiceImages",
                data: { images: JSON.stringify(images), id: id },
                dataType: "json",
                type: "POST",
                success: function (res) {
                    $('#btn-multi-image').modal('hide');
                    $('#imageList').children().remove();
                }
            });
        })

        $('.closeImage').off('click').on('click', function (e) {
            e.preventDefault();
            $('#imageList').children().remove();
        })
    },

    loadImage: function () {
        $.ajax({
            url: "/Admin/ServiceAdmin/ServiceImages",
            data: { id: $('#hideServiceId').val() },
            dataType: "json",
            type: "GET",
            success: function (res) {
                var data = res.data;
                console.log(data);
                var html = '';
                $.each(data, function (i, item) {
                    $('#imageList').append('<div class="col-md-4"><img style="margin-bottom:10px;max-height:100px" width="100" src="' + item + '" /><a class="btnDelImage" style="margin-left:5px" href="#"><i class ="fa fa-times"><i/></a></div>');
                    $('.btnDelImage').off('click').on('click', function (e) {
                        e.preventDefault();
                        $(this).parent().remove();
                    });
                })
            }
        });
    }
}
Acc.init();