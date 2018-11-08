using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HelloWorld.Models;
using HelloWorld.DBHelper;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace HelloWorld.API
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CarsController : Controller
    {
        private readonly IConfiguration _configuration;
        private DbHelper helper;

        public CarsController(IConfiguration configuration)
        {
            _configuration = configuration;
            helper = new DbHelper(_configuration) { };
        }


        [HttpGet("[action]")]
        public List<Car> GetAllCars()
        {
            List<Car> cars = new List<Car>() { };

            try
            {
                cars = helper.GetCars();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            };

            return cars;
        }


        [HttpGet("[action]")]
        public Car GetCar(int id)
        {
            Car carInfo = new Car { };

            try
            {
                carInfo = helper.GetCar(id);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }

            return carInfo;
        }

        [HttpPost("[action]")]
        public string StoreCar([FromBody] Car car)
        {

            try
            {
                helper.StoreCar(car);
                return "Car details has successfully been stored";
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return "An Error Occured";
            }

           
        }

        [HttpPut("[action]")]
        public string UpdateCar([FromBody]Car car)
        {

            try
            {
                helper.UpdateCar(car);
                return "Car details Has successfully Been Stored";
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return "An Error Occured "+ ex;
            }
           
        }

        [HttpDelete("[action]")]
        public string DeleteCar(int id)
        {

            try
            {
                helper.DeleteCar(id);
                return "The car has been removed";
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return "An Error Occured " + ex;
            }

        }
    }
}
