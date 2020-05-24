var cart = {
    init: function () {
        cart.loadCart();
        cart.registerEvents();
    },
    loadCart: function () {
        var cartItemsList = JSON.parse(localStorage.getItem("cartItemsList"));
        if (cartItemsList == null) return;
        var amount = 0;
        var totalQuantityInCart = 0;
        $.each(cartItemsList, function (index, value) {
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
                        var htmlString = `<li id="cartItem_${res.product.id}" class="single-cart-item"><div class="cart-img"> <a href="cart.html"><img src="${res.product.image}"></a> </div><div class="cart-content"><h5 class="product-name"><a href="single-product.html">${res.product.name}</a></h5><span id="quantityCart_${res.product.id}" class="product-quantity">${value.quantity} ×</span><span class="product-price">${price.toLocaleString(undefined, { minimumFractionDigits: 0 })} vnđ</span> </li>`;
                        $(".cart-items").append(htmlString);
                        $("#amountCart").html(amount.toLocaleString(undefined, { minimumFractionDigits: 0}) + " vnđ")
                    }
                    else {
                        console.log(res.product);
                    }
                }
            });
        });
        $(".cartcounter").html(totalQuantityInCart);
    },
    registerEvents: function () {
        $('.addToCart').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            var cartItemsList = JSON.parse(localStorage.getItem("cartItemsList"));
            console.log(cartItemsList);
            var quantity = 1;
            var totalQuantityInCart = 0;
            var oldAmount = 0;
            var checkExits = false;
            if (cartItemsList == null) {
                cartItemsList = new Array();
                var cartItem = {
                    itemId: id,
                    quantity: 1
                };
                totalQuantityInCart = 1;
                cartItemsList.push(cartItem);
                localStorage.setItem("cartItemsList", JSON.stringify(cartItemsList))
            }
            else {
                oldAmount = $("#amountCart").text();
                $.each(cartItemsList, function (index, value) {
                    if (value.itemId == id) {
                        value.quantity += 1;
                        quantity = value.quantity;
                        localStorage.setItem("cartItemsList", JSON.stringify(cartItemsList));
                        checkExits = true;
                    }
                    totalQuantityInCart += 1;
                });
                if (checkExits == false) {
                    var cartItem = {
                        itemId: id,
                        quantity: 1
                    };
                    totalQuantityInCart += 1;
                    cartItemsList.push(cartItem);
                    localStorage.setItem("cartItemsList", JSON.stringify(cartItemsList));
                }
            }
            $(".cartcounter").html(totalQuantityInCart);
           
            
            
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
                            console.log(quantity);
                            $("#quantityCart_" + res.product.id).html(quantity.toString() + " x ");
                            var totalAmount = oldAmount + price;
                            $("#amountCart").html(totalAmount.toLocaleString(undefined, { minimumFractionDigits: 0 }) + " vnđ");
                            //$("#amountCart").html(totalAmount.toLocaleString(undefined, { minimumFractionDigits: 0 }) + " vnđ");
                            return;
                        }

                        var htmlString = `<li class="single-cart -item"><div class="cart-img"> <a href="cart.html"><img src="${res.product.image}"></a> </div><div class="cart-content"><h5 class="product-name"><a href="single-product.html">${res.product.name}</a></h5><span id="quantityCart_${res.product.id}" class="product-quantity">${quantity} ×</span><span class="product-price">${price.toLocaleString(undefined, { minimumFractionDigits: 0 })} vnđ</span> </div></li>`;
                        $(".cart-items").append(htmlString);
                        var totalAmount = oldAmount + price;
                        //console.log("a");
                        //if (oldAmount != NaN) {
                        //    totalAmount += oldAmount;
                        //}
                        //console.log("a");
                        $("#amountCart").html(totalAmount.toLocaleString(undefined, { minimumFractionDigits: 0 }) + " vnđ");
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