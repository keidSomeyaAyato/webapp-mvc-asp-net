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
        [Column("CUST_ID")]
        public string ID { get; set; }

        [Column("CUST_NM")]
        public string Name { get; set; }

        [Column("CUST_TYPE")]
        public string Type { get; set; }

        [Column("TEL_NO")]
        public string PhoneNumber { get; set; }

        [Column("ZIPCODE")]
        public string ZipCode { get; set; }

        [Column("ADDRESS")]
        public string Address { get; set; }
    }

    public class MVCDBContext : DbContext
    {
    }
}