using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models.Customer
{
    public class FormCustomerSearchModel
    {
        [Range(0, 99999999, ErrorMessage = "8桁以内の数値を入力してください。")]
        public int? CondCustomerIdFrom { get; set; }

        [Range(0, 99999999, ErrorMessage = "8桁以内の数値を入力してください。")]
        public int? CondCustomerIdTo { get; set; }

        public bool chkCustomerType0 { get; set; }

        public bool chkCustomerType1 { get; set; }

        public bool chkCustomerType2 { get; set; }
        public string CondKeyword { get; set; }
    }
}