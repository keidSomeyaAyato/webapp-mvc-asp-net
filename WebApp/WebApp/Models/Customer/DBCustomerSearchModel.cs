using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApp.Models.Customer
{
    [Table("MST_CUSTOMER")]
    public class DBCustomerSearchModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string Type { get; set; }

        public string PhoneNumber { get; set; }

        public string ZipCode { get; set; }

        public string Address { get; set; }
    }

    public class MVCDBContext : DbContext
    {
    }
}