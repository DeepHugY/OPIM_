using System;
using System.ComponentModel.DataAnnotations;

namespace OPIM.Models
{
    public class HomeModel
    {
        public class RegisterModel
        {
            [Required(ErrorMessage = "请输入账号。")]
            [StringLength(20, ErrorMessage = "{0} 必须至少包含 {2} 个字符。", MinimumLength = 5)]
            [Display(Name = "账号")]
            public string Account { get; set; }

            [Required(ErrorMessage = "请输入密码。")]
            [StringLength(30, ErrorMessage = "{0} 必须至少包含 {2} 个字符。", MinimumLength = 8)]
            [DataType(DataType.Password)]
            [Display(Name = "密码")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "确认密码")]
            [Compare("Password", ErrorMessage = "密码和确认密码不匹配。")]
            public string ConfirmPassword { get; set; }

            [DataType(DataType.DateTime)]
            [Display(Name = "出生日期")]
            public DateTime BirthOn { get; set; }

            [Required(ErrorMessage = "请输入电子邮件地址。")]
            [EmailAddress(ErrorMessage = "请输入合法的电子邮件地址。")]
            [Display(Name = "电子邮件")]
            public string Email { get; set; }

            [Required(ErrorMessage = "请输入手机号码。")]
            [Phone(ErrorMessage = "请输入11位手机号码。")]
            [Display(Name = "手机号码")]
            public string Phone { get; set; }

            public string NickName { get; set; }

            [Required(ErrorMessage = "同意注册协议?")]
            public bool IsRead { get; set; }

            public string VerificationCode { get; set; }
        }

        public class LoginModel
        {
            [Required(ErrorMessage = "请输入账号。")]
            [StringLength(20, ErrorMessage = "{0} 必须至少包含 {2} 个字符。", MinimumLength = 5)]
            [Display(Name = "账号")]
            public string AccountLogin { get; set; }
            [Required]
            [StringLength(30, ErrorMessage = "{0} 必须至少包含 {2} 个字符。", MinimumLength = 8)]
            [DataType(DataType.Password)]
            [Display(Name = "密码")]
            public string PasswordLogin { get; set; }
            public bool RememberMe { get; set; }
            //public string VerificationCode { get; set; }
        }

        public class ReLoginModel
        {
            [Required(ErrorMessage = "请输入账号。")]
            [StringLength(20, ErrorMessage = "{0} 必须至少包含 {2} 个字符。", MinimumLength = 5)]
            [Display(Name = "账号")]
            public string AccountLogin { get; set; }
            [Required]
            [StringLength(30, ErrorMessage = "{0} 必须至少包含 {2} 个字符。", MinimumLength = 10)]
            [DataType(DataType.Password)]
            [Display(Name = "密码")]
            public string PasswordLogin { get; set; }
        }

    }

}