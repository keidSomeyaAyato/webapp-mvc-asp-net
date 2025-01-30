using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Customer
{
    public class FormCustomerSearchModel
    {
        public string CondCustomerIdFrom { get; set; }

        public string CondCustomerIdTo { get; set; }

        public int chkCustomerType { get; set; }

        public string CondKeyword { get; set; }
    }
}