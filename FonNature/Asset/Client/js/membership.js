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
                        location.reload();
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
        $('#password-register, #repeatpassword-register').on('keyup', function () {
            if ($('#password-register').val() == $('#repeatpassword-register').val()) {
                if ($('#repeatpassword-register').hasClass("invalid")) {
                    $('#repeatpassword-register').addClass('valid').removeClass('invalid');
                }
                else {
                    $('#repeatpassword-register').addClass('valid');
                }
            } else {
                if ($('#repeatpassword-register').hasClass("valid")) {
                    $('#repeatpassword-register').addClass('invalid').removeClass('valid');
                }
                else {
                    $('#repeatpassword-register').addClass('invalid')
                }
                if ($('#repeatpassword-register').hasClass("valid") && $('#password-register').hasClass("valid") && $('#email-register').hasClass("valid") && $('#mobilephone-register').hasClass("valid")
                    && $('#last-name-register').hasClass("valid") && $('#first-name-register').hasClass("valid")) {
                    $('#btn-register-form').prop("disabled", false);
                } else {
                    $('#btn-register-form').prop("disabled", true);
                }
            }             
        });

        $('#repeatpassword-register').on('keyup', function () {
            if ($('#repeatpassword-register').hasClass("valid") && $('#password-register').hasClass("valid") && $('#email-register').hasClass("valid") && $('#mobilephone-register').hasClass("valid")
                && $('#last-name-register').hasClass("valid") && $('#first-name-register').hasClass("valid")) {
                $('#btn-register-form').prop("disabled", false);
            }
            else {
                $('#btn-register-form').prop("disabled", true);
            }
        });

        $('#password-register').on('keyup', function () {
            if (/^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$/.test($('#password-register').val())) {
                if ($('#password-register').hasClass("invalid")) {
                    $('#password-register').addClass('valid').removeClass('invalid');
                }
                else {
                    $('#password-register').addClass('valid')
                }
            }
            else {
                if ($('#password-register').hasClass("valid")) {
                    $('#password-register').addClass('invalid').removeClass('valid');
                }
                else {
                    $('#password-register').addClass('invalid');
                }
            }

            if ($('#repeatpassword-register').hasClass("valid") && $('#password-register').hasClass("valid") && $('#email-register').hasClass("valid") && $('#mobilephone-register').hasClass("valid")
                && $('#last-name-register').hasClass("valid") && $('#first-name-register').hasClass("valid")) {
                $('#btn-register-form').prop("disabled", false);
            } else {
                $('#btn-register-form').prop("disabled", true);
            }
        });

        $('#email-register').on('keyup', function () {
            if (/^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/.test($('#email-register').val())) {
                var email = $('#email-register').val();
                $.ajax({
                    url: "/membership/IsExistEmail",
                    data: { email: email },
                    dataType: "json",
                    type: "POST",
                    success: function (result) {
                        if (!result.isError) {
                            if (!result.isExist) {
                                if ($('#email-register').hasClass("invalid")) {
                                    $('#email-register').addClass('valid').removeClass('invalid');
                                }
                                else {
                                    $('#email-register').addClass('valid')
                                }
                            }
                            else {
                                if ($('#email-register').hasClass("valid")) {
                                    $('#email-register').addClass('invalid').removeClass('valid');
                                }
                                else {
                                    $('#email-register').addClass('invalid');
                                }
                            }
                        }
                    }
                });   
            }
            else {
                if ($('#email-register').hasClass("valid")) {
                    $('#email-register').addClass('invalid').removeClass('valid');
                }
                else {
                    $('#email-register').addClass('invalid');
                }
            }

            if ($('#repeatpassword-register').hasClass("valid") && $('#password-register').hasClass("valid") && $('#email-register').hasClass("valid") && $('#mobilephone-register').hasClass("valid")
                && $('#last-name-register').hasClass("valid") && $('#first-name-register').hasClass("valid")) {
                $('#btn-register-form').prop("disabled", false);
            }
            else {
                $('#btn-register-form').prop("disabled", true);
            }
        });

        $('#mobilephone-register').on('keyup', function () {
            if (/(0[5|3|7|8|9]|84[5|3|7|8|9]|\+84[5|3|7|8|9])+([0-9]{8})\b/.test($('#mobilephone-register').val())) {
                var mobilePhone = $('#mobilephone-register').val();
                $.ajax({
                    url: "/membership/IsExistMobilePhone",
                    data: { mobilePhone: mobilePhone},
                    dataType: "json",
                    type: "POST",
                    success: function (result) {
                        if (!result.isError) {
                            if (!result.isExist) {
                                if ($('#mobilephone-register').hasClass("invalid")) {
                                    $('#mobilephone-register').addClass('valid').removeClass('invalid');
                                }
                                else {
                                    $('#mobilephone-register').addClass('valid')
                                }
                            }
                            else {
                                if ($('#mobilephone-register').hasClass("valid")) {
                                    $('#mobilephone-register').addClass('invalid').removeClass('valid');
                                }
                                else {
                                    $('#mobilephone-register').addClass('invalid');
                                }
                            }
                        }
                    }
                });   
            }
            else {
                if ($('#mobilephone-register').hasClass("valid")) {
                    $('#mobilephone-register').addClass('invalid').removeClass('valid');
                }
                else {
                    $('#mobilephone-register').addClass('invalid');
                }
            }

            if ($('#repeatpassword-register').hasClass("valid") && $('#password-register').hasClass("valid") && $('#email-register').hasClass("valid") && $('#mobilephone-register').hasClass("valid")
                && $('#last-name-register').hasClass("valid") && $('#first-name-register').hasClass("valid")) {
                $('#btn-register-form').prop("disabled", false);
            } else {
                $('#btn-register-form').prop("disabled", true);
            }
        });

        $('#last-name-register').on('keyup', function () {
            if ($('#repeatpassword-register').hasClass("valid") && $('#password-register').hasClass("valid") && $('#email-register').hasClass("valid") && $('#mobilephone-register').hasClass("valid")
                && $('#last-name-register').hasClass("valid") && $('#first-name-register').hasClass("valid")) {
                $('#btn-register-form').prop("disabled", false);
            } else {
                $('#btn-register-form').prop("disabled", true);
            }
        });

        $('#first-name-register').on('keyup', function () {
            if ($('#repeatpassword-register').hasClass("valid") && $('#password-register').hasClass("valid") && $('#email-register').hasClass("valid") && $('#mobilephone-register').hasClass("valid")
                && $('#last-name-register').hasClass("valid") && $('#first-name-register').hasClass("valid")) {
                $('#btn-register-form').prop("disabled", false);
            } else {
                $('#btn-register-form').prop("disabled", true);
            }
        });

        $('#btn-register-form').on('click', function () {
            var mobilePhone = $('#mobilephone-register').val();
            var email = $('#email-register').val();
            var password = $('#password-register').val();
            var lastName = $('#last-name-register').val();
            var firstName = $('#first-name-register').val();
            $.ajax({
                url: "/membership/RegisterAccount",
                data: { email: email, mobilePhone: mobilePhone, password: password, lastName: lastName, firstName: firstName },
                dataType: "json",
                type: "POST",
                success: function (result) {
                    if (!result.isError) {
                        $("#modalLRForm").modal('hide');
                        $('#centralModalSuccess').modal('show');
                    }
                }
            });   
        });
    }
}
memberShip.init();

function getCookie(name) {
    const value = `; ${document.cookie}`;
    const parts = value.split(`; ${name}=`);
    if (parts.length === 2) return parts.pop().split(';').shift();
}

$(window).on("load", function () { 
    if (getCookie("isCounted") != 1)
    {   
        $.get('https://www.cloudflare.com/cdn-cgi/trace', function (data) {
            var date = new Date(),
            expires = 'expires=';
            date.setTime(date.getTime() + 31536000000);
            expires += date.toGMTString();
            document.cookie = "isCounted=1+ '; " + expires + "; path=/";
            $.ajax({
                url: "/membership/CountVisistor",
                data: { info: data},
                dataType: "json",
                type: "POST",
                success: function (result) {
                    if (!result.isError) {
                        console.log("cookie write success!")
                    }
                }
            });   
        });     
    }
});



