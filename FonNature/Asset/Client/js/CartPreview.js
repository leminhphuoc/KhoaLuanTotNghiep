var cartPreview = {
    init: function () {
        cartPreview.registerEvents();
    },
    loadCart: function () {
        var cartItemsList = JSON.parse(localStorage.getItem("cartItemsList"));
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
                        var htmlString = `<tr><td class="pro-thumbnail"><a href="#"><img src="${res.product.image}" alt="Product"></a></td><td class="pro-title"><a href="#">${res.product.name}</a></td><td class="pro-price"><span>${price} Vnđ</span></td><td class="pro-quantity"><div class="pro-qty"><input min="1" max="9999" type="number" value="${value.quantity}"></div></td><td class="pro-subtotal"><span>${totalAmount} vnđ</span></td><td class="pro-remove_${res.product.id}"><a href="#"><i class="fa fa-trash-o"></i></a></td></tr>`;
                        $(".cartPreviewTable").append(htmlString);
                        //$("#amountCart").html(amount.toLocaleString(undefined, { minimumFractionDigits: 0 }) + " vnđ")
                    }
                    else {
                        console.log(res.product);
                    }
                }
            });
        });
    },
    registerEvents: function () {
    }
}
cartPreview.init();