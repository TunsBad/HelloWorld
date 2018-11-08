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
        public string ConnectionString;

        public DbHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetValue<string>("ConnectionStrings:Database");
        }

        public List<Car> GetCars()
        {
            List<Car> cars = new List<Car>() { };

            using (SqlConnection openCon = new SqlConnection(ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("getCars");
                cmd.Connection = openCon;
                cmd.CommandType = CommandType.StoredProcedure;

                openCon.Open();

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    while(rdr.Read())
                    {
                        Car car = new Car() { };

                        car.Name = rdr["Name"].ToString();
                        car.Make = rdr["Make"].ToString();
                        car.Year = rdr["Year"].ToString();
                        car.Model = rdr["Model"].ToString();

                        cars.Add(car);
                    }
                }

            }

            return cars;
        }

        public void DeleteCar(int id)
        {
            using (SqlConnection openCon = new SqlConnection(ConnectionString))
            {
                string deleteCar = "DELETE FROM Cars Where Id = @id";

                using (SqlCommand queryDeleteCar = new SqlCommand(deleteCar))
                {
                    queryDeleteCar.Connection = openCon;
                    queryDeleteCar.CommandType = CommandType.Text;

                    queryDeleteCar.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    openCon.Open();

                    queryDeleteCar.ExecuteNonQuery();
                }
            }

        }

        public void StoreCar(Car car)
        {

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

        }

        public void UpdateCar(Car car)
        {
            using (SqlConnection openCon = new SqlConnection(ConnectionString))
            {
                string updateCar = "UPDATE Cars SET Name = @name, Make = @make, Year = @year, Model = @model WHERE Id = @id";

                using (SqlCommand querySaveCar = new SqlCommand(updateCar))
                {
                    querySaveCar.Connection = openCon;
                    querySaveCar.CommandType = CommandType.Text;

                    querySaveCar.Parameters.Add("@id", SqlDbType.Int).Value = car.Id;
                    querySaveCar.Parameters.Add("@name", SqlDbType.VarChar).Value = car.Name;
                    querySaveCar.Parameters.Add("@make", SqlDbType.VarChar).Value = car.Make;
                    querySaveCar.Parameters.Add("@year", SqlDbType.VarChar).Value = car.Year;
                    querySaveCar.Parameters.Add("@model", SqlDbType.VarChar).Value = car.Model;

                    openCon.Open();

                    querySaveCar.ExecuteNonQuery();
                }
            }
        }

        public Car GetCar(int id)
        {
            Car car = new Car();

            using (SqlConnection openCon = new SqlConnection(ConnectionString))
            {
                string getCar = "SELECT * FROM Cars Where Id = @id";

                SqlCommand queryGetCar = new SqlCommand(getCar);
                queryGetCar.Connection = openCon;
                queryGetCar.CommandType = CommandType.Text;

                queryGetCar.Parameters.Add("@id", SqlDbType.Int).Value = id;

                openCon.Open();
                using (SqlDataReader oReader = queryGetCar.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        car.Name = oReader["Name"].ToString();
                        car.Make = oReader["Make"].ToString();
                        car.Year = oReader["Year"].ToString();
                        car.Model = oReader["Model"].ToString();
                    }

                    openCon.Close();
                }
            }

            return car;
        }

    }
}
