using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    [Table("MST_USER")]
    public class MST_USER
    {
        [Key]
        public string USER_CD { get; set; }

        public string USER_NM { get; set; }

        public string PASSWORD { get; set; }

        public DateTime? LAST_LOGIN_TIME { get; set; }

        public DateTime? LAST_LOGOUT_TIME { get; set; }

        public string USER_IP_ADDR { get; set; }
    }

    public class MST_USERDBContext : DbContext
    {
        public DbSet<MST_USER> USER { get; set; }
    }
}