$(function() {
    $('#register').validate({
        errorElement: 'span',
        errorClass: 'help-block',
        focusInvalid: false,
        rules: {
            Account: {
                required: true,
                minlength: 6,
                maxlength: 20
            },
            NickName: {
                required: true,
                maxlength: 10
            },
            Password: {
                required: true,
                minlength: 8,
                maxlength: 30
            },
            ConfirmPassword: {
                required: true,
                equalTo: "#Password"
            },
            Email: {
                required: true,
                email: true
            },
            Phone: {
                required: true,
                digits: true,
                range: [10000000000, 20000000000]
            },
            IsRead: 'required'
        },
        messages: {
            Account: {
                required: '请输入账户。',
                minlength: '账户最少5个字符。',
                maxlength: '账户最多允许20个字符'

            },
            NickName: {
                required: '请输入账户。',
                maxlength: '账户最多允许10个字符'

            },
            Password: {
                required: '请输入密码。',
                minlength: '密码最少8个字符。',
                maxlength: '密码最多30个字符'
            },
            ConfirmPassword: {
                required: '请输入确认密码',
                equalTo: '两次输入密码不一致。'
            },
            Email: {
                required: '请输入电子邮件。',
                email: '请输入标准的邮件格式（xx@xx.com）'
            },
            Phone: {
                required: '请输入手机号。',
                digits: '手机号码必须是数字。',
                range: '请输入正确的手机号码。'
            },
            IsRead: '请详细了解注册协议，并同意其条款才能继续注册。'
        },
        highlight: function (element) {
            $(element).closest('.form-group').addClass('has-error');
        },
        success: function (label) {
            label.closest('.form-group').removeClass('has-error');
            label.remove();
        },
        errorPlacement: function (error, element) {
            element.parent('div').parent('div').append(error);
        }
    })
});