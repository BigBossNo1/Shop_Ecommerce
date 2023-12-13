
var cart = {
    init: function () {
        cart.loadData();
        cart.registerEvent();
    },
    registerEvent: function () {
        $('#btnAddToCart').off('click').on('click', function (e) {
            e.preventDefault();
            var productID = parseInt($(this).data('id'));
            cart.addItem(productID);
        })
    },
    //addItem: function (productID) {
    //    $.ajax({
    //        url: '/Cart/Add',
    //        data: {
    //            productID: productID
    //        },
    //        type: 'POST',
    //        dataType: 'json',
    //        success: function (respose) {
    //            if (respose.status) {
    //                alert('Thêm sản phẩm vào giỏ hàng thành công ');
    //            }
    //        }
    //    });
    //},
    addItem: function (productID) {
        $.ajax({
            url: '/Cart/Add',
            data: {
                productID: productID
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    // Hiển thị thông báo thành công bằng Bootstrap Alert
                    $('#alertContainer').html(`
                    <div class="alert alert-success alert-dismissible fade show" role="alert">
                        Thêm sản phẩm vào giỏ hàng thành công.
                        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                    </div>
                `);

                    // Refresh dữ liệu giỏ hàng sau khi thêm vào thành công
                    cart.loadData();
                } else {
                    // Xử lý nếu có lỗi khi thêm vào giỏ hàng
                    console.error('Lỗi khi thêm sản phẩm vào giỏ hàng.');
                }
            }
        });
    },

    loadData: function () {
        $.ajax({
            url: '/Cart/GetAll',
            type: 'GET',
            dataType: 'json',
            success: function (res) {
                if (res.status) {
                    var template = $('#tplCart').html();
                    var html = '';
                    var data = res.data;
                    $.each(data, function (i, item) {
                        html += Mustache.render(template, {
                            ProductID: item.ProductID,
                            ProductName: item.Product.Name,
                            Image: item.Product.Image,
                            ProductPrice: item.Product.Price,
                            Quantity: item.Quantity,
                            Amount: item.Quantity * item.Product.Price
                        });
                    });
                    $('#cartBody').html(html);
                }
            }
        })
    }
}
cart.init();