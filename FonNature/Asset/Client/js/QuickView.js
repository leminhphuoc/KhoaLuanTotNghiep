var product = {
    init: function () {
        product.registerEvents();
    },
    registerEvents: function () {
        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            $.ajax({
                url: "/Admin/ProductAdmin/ChangeStatus",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function (res) {
                    console.log(res);
                    if (res.Status == true) {
                        btn.text('Kích hoạt');
                    }
                    else {
                        btn.text('Khóa');
                    }
                }
            });
        });

        $('.btn-image').off('click').on('click', function (e) {
            e.preventDefault();
            $('#btn-multi-image').modal('show');
            $('#hidProductId').val($(this).data('id'))
            product.loadImage();
           
        });

        $('#btnChooseImage').off('click').on('click', function (e) {
            e.preventDefault();
            var finder = new CKFinder();
            finder.selectActionFunction = function (url) {
                $('#imageList').append('<div class="col-md-4"><img style="margin-bottom:10px;max-height:100px" width="100" src="' + url + '" /><a class="btnDelImage" style="margin-left:5px" href="#"><i class ="fa fa-times"><i/></a></div>');
                $('.btnDelImage').off('click').on('click', function (e) {
                    e.preventDefault();
                    $(this).parent().remove();
                });
            };
            finder.popup();
        })

        $('#btnSaveImage').off('click').on('click', function (e) {
            e.preventDefault();
            var images = [];
            $.each($('#imageList div img'), function (i, item) {
                images.push($(item).attr('src'));
            })
            var id = $('#hidProductId').val();

            $.ajax({
                url: "/Admin/ProductAdmin/SaveProductImages",
                data: { images: JSON.stringify(images), id: id  },
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
            url: "/Admin/ProductAdmin/ProductImages",
            data: { id: $('#hidProductId').val() },
            dataType: "json",
            type: "GET",
            success: function (res) {
                var data = res.data;
                console.log(data);
                //var html = '';
                //$.each(data, function (i, item) {
                //    $('#imageList').append('<div class="col-md-4"><img style="margin-bottom:10px;max-height:100px" width="100" src="' + item + '" /><a class="btnDelImage" style="margin-left:5px" href="#"><i class ="fa fa-times"><i/></a></div>');
                //    $('.btnDelImage').off('click').on('click', function (e) {
                //        e.preventDefault();
                //        $(this).parent().remove();
                //    });
                //})
            }
        });
    }
}
product.init();