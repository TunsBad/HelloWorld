using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using HelloWorld.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace HelloWorld.DBHelper
{
    public class DbHelper
    {
        private readonly IConfiguration _configuration;

        public DbHelper(IConfiguration configuration) {
            _configuration = configuration;
        }
        public string StoreCar(Car car)
        {
            var ConnectionString = _configuration.GetValue<string>("ConnectionStrings:Database");
            using (SqlConnection openCon = new SqlConnection(ConnectionString))
            {
                string saveStaff = "INSERT into Cars (Name,Make,Year,Model) VALUES (@Name,@Make,@Year,@Model)";

                using (SqlCommand querySaveStaff = new SqlCommand(saveStaff))
                {
                    querySaveStaff.Connection = openCon;
                    querySaveStaff.CommandType = CommandType.Text;

                    querySaveStaff.Parameters.Add("@Name", SqlDbType.VarChar).Value = car.Name;
                    querySaveStaff.Parameters.Add("@Make", SqlDbType.VarChar).Value = car.Make;
                    querySaveStaff.Parameters.Add("@Year", SqlDbType.VarChar).Value = car.Year;
                    querySaveStaff.Parameters.Add("@Model", SqlDbType.VarChar).Value = car.Model;

                    openCon.Open();

                    querySaveStaff.ExecuteNonQuery();
                }
            }

            return "";
        }
    }
}
