using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models.Login
{
    public class FormLoginModel
    {
        [Required(ErrorMessage = "ログインIDを入力してください。")]
        [StringLength(20, ErrorMessage = "ログインIDは20字以内で入力してください")]
        public string LoginID {  get; set; }

        [Required(ErrorMessage = "パスワードはを入力してください")]
        [StringLength(20, ErrorMessage = "パスワードは20字以内で入力してください")]
        public string Password { get; set; }
    }
}