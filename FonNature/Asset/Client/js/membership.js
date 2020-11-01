var memberShip = {
    init: function () {
        memberShip.registerEvents();
    },
    registerEvents: function () {
        $("#login-dropdown-option").off('click').on('click', function (e) {
            e.preventDefault();
            $("#loginTab").click();
        });
        $("#btn-login").off('click').on('click', function (e) {
            e.preventDefault();
            var email = $("#email-login").val();
            var password = $("#password-login").val();   
            $.ajax({
                url: "/membership/login",
                data: { email: email, password : password },
                dataType: "json",
                type: "POST",
                success: function (result) {
                    if (result.status) {
                        $("#modalLRForm").modal('hide');
                        var fullName = result.account.FirstName + " " + result.account.LastName;
                        var htmlLogin = `<a class="dropdown-toggle" style="color: #000000 !important" href="#" id="dropdownMenu2" data-toggle="dropdown"
                        aria-haspopup="true" aria-expanded="true"><i class="fa fa-user-circle-o"></i> Hi! ${fullName}</a>
                        <div class="dropdown-menu dropdown-primary login-button-header">
                            <a class="dropdown-item" href="/membership/mytransactions">My Transactions</a>
                            <a class="dropdown-item" href="/membership/myprofile">My Profile</a>
                            <a class="dropdown-item" href="/membership/logout">LogOut</a>
                        </div>`
                        $("#account-top-nav").html(htmlLogin);
                    }
                    else {
                        $("#message-login").html(result.message);
                    }
                }
            });
        });
        $("#register-dropdown-option").off('click').on('click', function (e) {
            e.preventDefault();
            $("#registerTab").click();
        });
        $('#modalLRForm').on('hidden.bs.modal', function () {
                location.reload();
        })
    }
}
memberShip.init();

