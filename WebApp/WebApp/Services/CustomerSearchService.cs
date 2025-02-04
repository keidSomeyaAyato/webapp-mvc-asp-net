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
            string sql = @"
                SELECT TOP 10 
                    CUST_ID AS ID, 
                    CUST_NM AS Name, 
                    CUST_TYPE AS Type, 
                    TEL_NO AS PhoneNumber, 
                    ZIPCODE AS ZipCode, 
                    ADDRESS AS Address
                FROM MST_CUSTOMER 
                ORDER BY CUST_ID ASC";

            return _dbContext.Database.SqlQuery<DBCustomerSearchModel>(sql).ToList();
        }
    }
}
