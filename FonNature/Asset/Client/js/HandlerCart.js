var cart = {
    init: function () {
        cart.registerEvents();
    },
    registerEvents: function () {
        $('.addToCart').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            var cartItemsList = JSON.parse(localStorage.getItem("cartItemsList"));
            var quantity = 1;
            var addedQuantity = 1; 
            if ($('#productDetailQuantity').val() > 1) {
                addedQuantity = $('#productDetailQuantity').val();
                addedQuantity = Number(addedQuantity.replace(/[^0-9.-]+/g, ""));
            }
            var oldQuantity = $(".cartcounter").html();
            $(".cartcounter").html(Number(oldQuantity) + addedQuantity);
            var n = new Noty({
                text: 'Bạn đã thêm sản phẩm vào giỏ hàng thành công',
                animation: {
                    open: 'animated bounceInRight', // Animate.css class names
                    close: 'animated bounceOutRight' // Animate.css class names
                },
                type: 'success',
                layout: 'topLeft',
                theme: 'metroui',
                timeout: 2000,
                progressBar: true
            }).show();

            var totalQuantityInCart = 0;
            var oldAmount = 0;
            var checkExits = false;
            if (cartItemsList == null) {
                cartItemsList = new Array();
                var cartItem = {
                    itemId: id,
                    quantity: addedQuantity
                };
                totalQuantityInCart = 1;
                cartItemsList.push(cartItem);
                localStorage.setItem("cartItemsList", JSON.stringify(cartItemsList))
            }
            else {
                oldAmount = $("#amountCart").text();
                $.each(cartItemsList, function (index, value) {
                    if (value.itemId == id) {
                        value.quantity += addedQuantity;
                        quantity = value.quantity;
                        localStorage.setItem("cartItemsList", JSON.stringify(cartItemsList));
                        checkExits = true;
                    }
                    totalQuantityInCart += 1;
                });
                if (checkExits == false) {
                    var cartItem = {
                        itemId: id,
                        quantity: addedQuantity
                    };
                    totalQuantityInCart += 1;
                    cartItemsList.push(cartItem);
                    localStorage.setItem("cartItemsList", JSON.stringify(cartItemsList));
                }
            }
           
            $.ajax({
                url: "/product/GetDetailJson",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function (res) {
                    if (res.product != null) {
                        var price = res.product.promotionPrice;
                        if (price === 0 || price == null) {
                            price = res.product.price;
                        }
                        if (oldAmount != 0) {
                            oldAmount = oldAmount.slice(0, oldAmount.indexOf("v") - 1);
                            oldAmount = Number(oldAmount.replace(/[^0-9.-]+/g, ""));
                        }
                        if (checkExits == true) {
                            $("#quantityCart_" + res.product.id).html(quantity.toString() + " x ");
                            var totalAmount = oldAmount + (price * addedQuantity);
                            $("#amountCart").html(totalAmount.toLocaleString(undefined, { minimumFractionDigits: 0 }) + " vnđ");
                            //$("#amountCart").html(totalAmount.toLocaleString(undefined, { minimumFractionDigits: 0 }) + " ");
                            return;
                        }
                        var htmlString = `<li id="cartItem_${res.product.id}" class="single-cart-item"><div class="cart-img"> <a href="/product/Detail?id=${id}"><img style="max-height: 71px;" src="${res.product.image}"></a> </div><div class="cart-content"><h5 class="product-name"><a href="single-product.html">${res.product.name}</a></h5><span id="quantityCart_${res.product.id}" class="product-quantity">${addedQuantity} ×</span><span class="product-price">${price.toLocaleString(undefined, { minimumFractionDigits: 0 })} vnđ</span> </div><div class="cart-item-remove"><a onClick="removeFunction(this)" data-id="${id}" class="removeMiniCart" title="Remove" href="javascript:void(0);"><i class="fa fa-trash"></i></a></div> </li>`;
                        $(".cart-items").append(htmlString);
                        var totalAmount = oldAmount + (price * addedQuantity);
                        console.log(totalAmount);
                        $(document).ajaxStop(function () {
                            $("#amountCart").html(totalAmount.toLocaleString(undefined, { minimumFractionDigits: 0 }) + " vnđ");
                        });
                        $(".cartcounter").removeAttr('hidden');
                    }
                    else {
                        console.log(res.product);
                    }
                }
            });
        });
    }
}
cart.init();

function myFunction() {
    var cartItemsList = JSON.parse(localStorage.getItem("cartItemsList"));
    if (cartItemsList == null) return;
    var amount = 0;
    var totalQuantityEachProduct = 0;
    var totalQuantityInCart = 0;
    $.each(cartItemsList, function (index, value) {
        totalQuantityEachProduct += value.quantity;
        totalQuantityInCart += 1;
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
                    var htmlString = `<li id="cartItem_${res.product.id}" class="single-cart-item"><div class="cart-img"> <a href="/product/Detail?id=${value.itemId}"><img style="max-height: 71px;" src="${res.product.image}"></a> </div><div class="cart-content"><h5 class="product-name"><a href="single-product.html">${res.product.name}</a></h5><span id="quantityCart_${res.product.id}" class="product-quantity">${value.quantity} ×</span><span class="product-price">${price.toLocaleString(undefined, { minimumFractionDigits: 0 })} vnđ</span><div class="cart-item-remove"><a onClick="removeFunction(this)" data-id="${value.itemId}" class="removeMiniCart" title="Remove" href="javascript:void(0);"><i class="fa fa-trash"></i></a></div> </li>`;
                    $(".cart-items").append(htmlString);
                    $("#amountCart").html(amount.toLocaleString(undefined, { minimumFractionDigits: 0 }) + " vnđ")
                }
                else {
                    console.log(res.product);
                }
            }
        });
    });
    if (totalQuantityInCart > 0) $(".cartcounter").removeAttr('hidden');
    $(".cartcounter").html(totalQuantityEachProduct);

    //Load cart Preview Item
    var pathname = window.location.pathname;
    if (pathname === "/product/CartPreview") {
        var totalAmount = 0;
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
                        var amount = price * value.quantity;
                        var htmlString = `<tr id="previewItemRow_${value.itemId}"><td class="pro-thumbnail"><a href="#"><img src="${res.product.image}" alt="Product"></a></td><td class="pro-title"><a href="#">${res.product.name}</a></td><td class="pro-price"><span class="cartPreviewPrice_${value.itemId}">${price.toLocaleString(undefined, { minimumFractionDigits: 0 })} vnđ</span></td><td class="pro-quantity"><div class="pro-qty"><input data-id="${value.itemId}" onchange="changeQuantity(this)" min="1" max="9999" type="number" value="${value.quantity}"></div></td><td class="pro-subtotal"><span class="cartPreviewTotal_${value.itemId}">${amount.toLocaleString(undefined, { minimumFractionDigits: 0 })} vnđ</span></td><td class="pro-remove_${res.product.id}"><a data-ispreviewitem="true" data-id="${res.product.id}" onClick="removeFunction(this)" href="javascript:void(0);"><i class="fa fa-trash-o"></i></a></td></tr>`;
                        $(".cartPreviewTable").append(htmlString);
                        totalAmount += amount;
                        //$("#amountCart").html(amount.toLocaleString(undefined, { minimumFractionDigits: 0 }) + "")
                    }
                    else {
                        console.log(res.product);
                    }
                }
            });
        });
        $(document).ajaxStop(function () {
            $("#cartSubTotal").html(totalAmount.toLocaleString(undefined, { minimumFractionDigits: 0 }) + " vnđ")
            $("#cartGrandTotal").html(totalAmount.toLocaleString(undefined, { minimumFractionDigits: 0 }) + " vnđ")
        });
    }

    //Load cart item in checkout
    if (pathname.toUpperCase() === "/Product/CheckOut".toUpperCase()) {
        var totalAmount = 0;
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
                        var amount = price * value.quantity;
                        var htmlString = `<li>${res.product.name} X ${value.quantity} <span>${amount.toLocaleString(undefined, { minimumFractionDigits: 0 })} vnđ</span></li>`;
                        $("#checkoutCartItem").append(htmlString);
                        totalAmount += amount;
                        //$("#amountCart").html(amount.toLocaleString(undefined, { minimumFractionDigits: 0 }) + " ")
                    }
                    else {
                        console.log(res.product);
                    }
                }
            });
        });

        var couponCode = localStorage.getItem("couponCode");
        var coupon = {}
        $.ajax({
            url: "/product/GetCoupon",
            data: { code: couponCode },
            dataType: "json",
            type: "POST",
            success: function (res) {
                if (res.isExist) {
                    coupon = res.couponCode
                }
                else {
                    console.log(res);
                }
            }
        });

        $(document).ajaxStop(function () {
            var couponValue = 0;
            if (coupon != null) {
                couponValue = coupon.DiscountValue;
            }
            var subTotal = totalAmount;
            var grandTotal = subTotal;
            if (couponValue != null && couponValue != undefined) {
                var grandTotal = subTotal - couponValue;
            }
            
            $("#subTotalInCheckout").html(subTotal.toLocaleString(undefined, { minimumFractionDigits: 0 }) + " vnđ")
            if (couponValue != null && couponValue != undefined) {
                $("#discount-value").html(couponValue.toLocaleString(undefined, { minimumFractionDigits: 0 }) + " vnđ")
            }
            $("#grandTotalInCheckout").html(grandTotal.toLocaleString(undefined, { minimumFractionDigits: 0 }) + " vnđ")
        });
    }
}

function removeFunction(elem) {
    var btn = $(elem);
    var id = btn.data('id');
    var isPreviewItem = btn.data('ispreviewitem');
    var cartItemsList = JSON.parse(localStorage.getItem("cartItemsList"));
    var totalQuantityInCart = 0;
    $.each(cartItemsList, function (index, value) {
        totalQuantityInCart += 1;
        if (value !== undefined) {
            if (value.itemId == id) {
                cartItemsList.splice(index, 1);
                $('#cartItem_' + id).remove();
                $.ajax({
                    url: "/product/GetDetailJson",
                    data: { id: id },
                    dataType: "json",
                    type: "POST",
                    success: function (res) {
                        if (res.product != null) {
                            var price = res.product.promotionPrice;
                            if (price === 0 || price == null) {
                                price = res.product.price;
                            }
                            var oldAmount = $("#amountCart").text();
                            oldAmount = oldAmount.slice(0, oldAmount.indexOf("v") - 1);
                            oldAmount = Number(oldAmount.replace(/[^0-9.-]+/g, ""));
                            var totalAmount = oldAmount - (price * value.quantity);
                            $("#amountCart").html(totalAmount.toLocaleString(undefined, { minimumFractionDigits: 0 }) + " vnđ");
                        }
                        else {
                            console.log(res.product);
                        }
                    }
                });
            }
        }
    });
    $(".cartcounter").html(totalQuantityInCart - 1);
    if (totalQuantityInCart - 1 == 0) $(".cartcounter").attr('hidden', true);
    localStorage.setItem("cartItemsList", JSON.stringify(cartItemsList));
    updateGrandTotalFromStorage();
    $('#previewItemRow_' + id).remove();
}

function changeQuantity(elem) {
    var input = $(elem);
    var id = input.data('id');
    var priceText = $('.cartPreviewPrice_' + id).text();
    var price = changeTextToNumber(priceText);
    var quantity = input.val();
    var total = price * quantity;
    $('.cartPreviewTotal_' + id).html(total.toLocaleString(undefined, { minimumFractionDigits: 0 }) + " vnđ")
    var cartItemsList = JSON.parse(localStorage.getItem("cartItemsList"));
    if (cartItemsList == null) return;
    $.each(cartItemsList, function (index, value) {
        if (value.itemId == id) {
            cartItemsList[index].quantity = Number(quantity.replace(/[^0-9.-]+/g, ""));
            localStorage.setItem("cartItemsList", JSON.stringify(cartItemsList));
        }
    });
    $("#quantityCart_" + id).html(quantity.toString() + " x ");
    updateGrandTotalFromStorage();
}

function changeTextToNumber(text) {
    return Number(text.replace(/[^0-9.-]+/g, ""));
}

function updateGrandTotalFromStorage() {
    var cartItemsList = JSON.parse(localStorage.getItem("cartItemsList"));
    if (cartItemsList == null) return;
    var grandTotal = 0;
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
                    grandTotal += total;
                }
                else {
                    console.log(res.product);
                }
            }
        });
    });
    $(document).ajaxStop(function () {
        $("#cartSubTotal").html(grandTotal.toLocaleString(undefined, { minimumFractionDigits: 0 }) + " vnđ")
        $("#cartGrandTotal").html(grandTotal.toLocaleString(undefined, { minimumFractionDigits: 0 }) + " vnđ")
        $("#amountCart").html(grandTotal.toLocaleString(undefined, { minimumFractionDigits: 0 }) + " vnđ");
    });
}
