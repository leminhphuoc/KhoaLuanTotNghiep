var cartPreview = {
    init: function () {
        cartPreview.registerEvents();
    },
    loadCart: function () {
        var cartItemsList = JSON.parse(localStorage.getItem("cartItemsList"));
        localStorage.setItem("couponCode", null);
        if (cartItemsList == null) return;
        var amount = 0;
        $.each(cartItemsList, function (index, value) {
            $.ajax({
                url: "/product/GetDetailJson",
                data: { id: value.itemId },
                dataType: "json",
                type: "POST",
                success: function (res) {
                    console.log(res);
                    if (res.product != null) {
                        var price = res.product.promotionPrice;
                        if (price === 0 || price == null) {
                            price = res.product.price;
                        }
                        amount += price * value.quantity;
                        var totalAmount = price * value.quantity;
                        var htmlString = `<tr><td class="pro-thumbnail"><a href="#"><img src="${res.product.image}" alt="Product"></a></td><td class="pro-title"><a href="#">${res.product.name}</a></td><td class="pro-price"><span>${price} vnđ</span></td><td class="pro-quantity"><div class="pro-qty"><input min="1" max="9999" type="number" value="${value.quantity}"></div></td><td class="pro-subtotal"><span>${totalAmount} vnđ</span></td><td class="pro-remove_${res.product.id}"><a href="#"><i class="fa fa-trash-o"></i></a></td></tr>`;
                        $(".cartPreviewTable").append(htmlString);
                        //$("#amountCart").html(amount.toLocaleString(undefined, { minimumFractionDigits: 0 }) + "")
                    }
                    else {
                        console.log(res.product);
                    }
                }
            });
        });
    },
    registerEvents: function () {
        $('#btn-apply-couponcode').off('click').on('click', function (e) {
            e.preventDefault();
            $('#coupon-code-error-label').html("")
            var couponCode = $('#coupon-code-input').val()
            GetCouponAjax(couponCode)
                .then(data => SetCouponCodeAndGrandTotalLabel(data))
                .catch(error => console.log('Error:', error));
            $(document).ajaxStop(function () {
                
            });
        });
    }
}
cartPreview.init();


function GetCouponAjax(couponCode) {
    return $.ajax({
        url: "/product/getcoupon",
        data: { code: couponCode },
        dataType: "json",
        type: "POST"
    });
}
function GetGrandTotalOfProduct(itemId) {
     return $.ajax({
        url: "/product/GetDetailJson",
        data: { id: itemId },
        dataType: "json",
        type: "POST",
        success: function (res) {
            if (res.product != null) {
                var price = res.product.promotionPrice;
                if (price === 0 || price == null) {
                    price = res.product.price;
                }
                var total = price * value.quantity;
                grandTotal += total;
                handleData(grandTotal);
            }
        }
     });
}

function SetCouponCodeAndGrandTotalLabel(ajaxResult) {
    var cartItemsList = JSON.parse(localStorage.getItem("cartItemsList"));
    if (ajaxResult.isExist) {
        if (ajaxResult.couponCode.Quantity > 0) {
            if (ajaxResult.couponCode.ProductId.includes("all")) {
                $('#coupon-code-error-label').removeClass("text-danger");
                $('#coupon-code-error-label').addClass("text-success");
                $('#coupon-code-error-label').html("Success!")
                localStorage.setItem("couponCode", ajaxResult.couponCode.Code);
                $('#cartDiscount').html(ajaxResult.couponCode.DiscountValue.toLocaleString(undefined, { minimumFractionDigits: 0 }) + " vnđ")
                var subTotal = 0;
                $.each(cartItemsList, function (index, value) {
                    $.ajax({
                        url: "/product/GetDetailJson",
                        data: { id: value.itemId },
                        dataType: "json",
                        type: "POST",
                        success: function (res) {
                            if (res.product != null) {
                                var price = res.product.promotionPrice;
                                if (price === 0 || price == null) {
                                    price = res.product.price;
                                }
                                var total = price * value.quantity;
                                subTotal += total;
                            }
                            else {
                                console.log(res.product);
                            }
                        }
                    });
                });
                $(document).ajaxStop(function () {
                    var grandTotal = subTotal - ajaxResult.couponCode.DiscountValue;
                    $('#cartGrandTotal').html(grandTotal.toLocaleString(undefined, { minimumFractionDigits: 0 }) + " vnđ")
                    $('#cartDiscount').html(ajaxResult.couponCode.DiscountValue.toLocaleString(undefined, { minimumFractionDigits: 0 }) + " vnđ")
                });
            }
            else {
                if (cartItemsList == null) {
                    $('#coupon-code-error-label').removeClass("text-success");
                    $('#coupon-code-error-label').addClass("text-danger");
                    $('#coupon-code-error-label').html("No products in the cart!")
                    var subTotal = 0;
                    $.each(cartItemsList, function (index, value) {
                        $.ajax({
                            url: "/product/GetDetailJson",
                            data: { id: value.itemId },
                            dataType: "json",
                            type: "POST",
                            success: function (res) {
                                if (res.product != null) {
                                    var price = res.product.promotionPrice;
                                    if (price === 0 || price == null) {
                                        price = res.product.price;
                                    }
                                    var total = price * value.quantity;
                                    subTotal += total;
                                }
                                else {
                                    console.log(res.product);
                                }
                            }
                        });
                    });
                    $(document).ajaxStop(function () {
                        var grandTotal = subTotal;
                        $('#cartGrandTotal').html(grandTotal.toLocaleString(undefined, { minimumFractionDigits: 0 }) + " vnđ")
                        $('#cartDiscount').html(0 + " vnđ")
                    });
                }
                else {
                    var isExist = false;
                    $.each(cartItemsList, function (index, value) {
                        if (ajaxResult.couponCode.ProductId.includes(value.itemId.toString())) {
                            isExist = true;
                        }
                    });

                    if (isExist == true) {
                        $('#coupon-code-error-label').removeClass("text-danger");
                        $('#coupon-code-error-label').addClass("text-success");
                        $('#coupon-code-error-label').html("Success!")
                        localStorage.setItem("couponCode", ajaxResult.couponCode.Code);
                        var subTotal = 0;
                        $.each(cartItemsList, function (index, value) {
                            $.ajax({
                                url: "/product/GetDetailJson",
                                data: { id: value.itemId },
                                dataType: "json",
                                type: "POST",
                                success: function (res) {
                                    if (res.product != null) {
                                        var price = res.product.promotionPrice;
                                        if (price === 0 || price == null) {
                                            price = res.product.price;
                                        }
                                        var total = price * value.quantity;
                                        subTotal += total;
                                    }
                                    else {
                                        console.log(res.product);
                                    }
                                }
                            });
                        });
                        $(document).ajaxStop(function () {
                            var grandTotal = subTotal - ajaxResult.couponCode.DiscountValue;
                            $('#cartDiscount').html(ajaxResult.couponCode.DiscountValue.toLocaleString(undefined, { minimumFractionDigits: 0 }) + " vnđ")
                            $('#cartGrandTotal').html(grandTotal.toLocaleString(undefined, { minimumFractionDigits: 0 }) + " vnđ")
                        });
                    }
                    else {
                        $('#coupon-code-error-label').removeClass("text-success");
                        $('#coupon-code-error-label').addClass("text-danger");
                        $('#coupon-code-error-label').html("No valid products for coupon code!")
                        var subTotal = 0;
                        $.each(cartItemsList, function (index, value) {
                            $.ajax({
                                url: "/product/GetDetailJson",
                                data: { id: value.itemId },
                                dataType: "json",
                                type: "POST",
                                success: function (res) {
                                    if (res.product != null) {
                                        var price = res.product.promotionPrice;
                                        if (price === 0 || price == null) {
                                            price = res.product.price;
                                        }
                                        var total = price * value.quantity;
                                        subTotal += total;
                                    }
                                    else {
                                        console.log(res.product);
                                    }
                                }
                            });
                        });
                        $(document).ajaxStop(function () {
                            var grandTotal = subTotal;
                            $('#cartGrandTotal').html(grandTotal.toLocaleString(undefined, { minimumFractionDigits: 0 }) + " vnđ")
                            $('#cartDiscount').html(0 + " vnđ")
                        });
                    }
                }
            }
        }
        else {
            $('#coupon-code-error-label').removeClass("text-success");
            $('#coupon-code-error-label').addClass("text-danger");
            $('#coupon-code-error-label').html("Coupon code out of stock!")
            var subTotal = 0;
            $.each(cartItemsList, function (index, value) {
                $.ajax({
                    url: "/product/GetDetailJson",
                    data: { id: value.itemId },
                    dataType: "json",
                    type: "POST",
                    success: function (res) {
                        if (res.product != null) {
                            var price = res.product.promotionPrice;
                            if (price === 0 || price == null) {
                                price = res.product.price;
                            }
                            var total = price * value.quantity;
                            subTotal += total;
                        }
                        else {
                            console.log(res.product);
                        }
                    }
                });
            });
            $(document).ajaxStop(function () {
                var grandTotal = subTotal;
                $('#cartGrandTotal').html(grandTotal.toLocaleString(undefined, { minimumFractionDigits: 0 }) + " vnđ")
                $('#cartDiscount').html(0 + " vnđ")
            }); 
        }
    }
    else {
        $('#coupon-code-error-label').removeClass("text-success");
        $('#coupon-code-error-label').addClass("text-danger");
        $('#coupon-code-error-label').html("Coupon code doesn't exist!")
        var subTotal = 0;
        $.each(cartItemsList, function (index, value) {
            $.ajax({
                url: "/product/GetDetailJson",
                data: { id: value.itemId },
                dataType: "json",
                type: "POST",
                success: function (res) {
                    if (res.product != null) {
                        var price = res.product.promotionPrice;
                        if (price === 0 || price == null) {
                            price = res.product.price;
                        }
                        var total = price * value.quantity;
                        subTotal += total;
                    }
                    else {
                        console.log(res.product);
                    }
                }
            });
        });
        var grandTotal = subTotal;
        $('#cartGrandTotal').html(grandTotal.toLocaleString(undefined, { minimumFractionDigits: 0 }) + " vnđ")
        $('#cartDiscount').html(0 + " vnđ")
    }
}