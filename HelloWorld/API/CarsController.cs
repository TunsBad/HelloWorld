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

        public CarsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet("[action]")]
        public List<Car> GetAllCars()
        {
            List<Car> cars = new List<Car>() { };

            try
            {
                //cars = DbHelper.Instance.GetCars();
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
                //carInfo = DbHelper.Instance.GetCar(id);
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
            //Car carDetails = JsonConvert.DeserializeObject<Car>(car);

            DbHelper helper = new DbHelper(_configuration) { };

            try
            {
                var id = helper.StoreCar(car);
                return "Car details has successfully been stored";
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                var response = "An Error Occured";
                return response;
            }

           
        }

        [HttpPut("[action]")]
        public string UpdateCar([FromBody]Car car)
        {
            var response = "";

            try
            {
                //int id = DbHelper.Instance.UpdateCar(car);
                //if (id > 0)
                    return "Car details Has successfully Been Stored";
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                response = "An Error Occured";
            }

            return response;
        }

        [HttpGet("[action]")]
        public string DeleteCar(int id)
        {
            var response = "";
            try
            {
                //int cardId = DbHelper.Instance.DeleteCar(id);
                //if (id == cardId)
                //{
                //    return "The car has been removed";
                //}
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                response = "An Error Occured";
            }

            return response;
        }
    }
}
