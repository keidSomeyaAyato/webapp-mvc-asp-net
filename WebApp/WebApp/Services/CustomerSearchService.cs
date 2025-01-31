using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Models.Customer;

namespace WebApp.Services
{
    public class CustomerSearchService
    {
        private readonly MVCDBContext _dbContext;

        public CustomerSearchService()
        {
            _dbContext = new MVCDBContext();
        }

        public List<DBCustomerSearchModel> GetCustomerFirstToTen()
        {
            string sql = "SELECT TOP 10 * FROM MST_CUSTOMER ORDER BY CUST_ID ASC";

            return _dbContext.Database.SqlQuery<DBCustomerSearchModel>(sql).ToList();
        }
    }
}