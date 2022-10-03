using CROSSOVER_API.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Web.Http;



namespace CROSSOVER_API.Controllers
{
    public class RoutesController : ApiController
    {

        [HttpPost]
        [Route("api/create")]
        public IHttpActionResult Create([FromBody] CreateUsuarioModel.obj data)
        {

            try
            {
                string url = "http://restapi.adequateshop.com/api/authaccount/registration";

                var client = new RestClient(url);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");

                JObject body = new JObject();
                body.Add("name", data.name);
                body.Add("email", data.email);
                body.Add("password", data.password);

                request.AddParameter("application/json", body, ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);

                var resp = JsonConvert.DeserializeObject<CreateUsuarioModel.SAL_Header>(response.Content);

                return Ok(resp);
            }
            catch (Exception e )
            {
                Console.WriteLine("error: "+e.Message);
                return BadRequest(e.Message);
            }
            

        }

        [HttpPost]
        [Route("api/iniciosesion")]
        public IHttpActionResult Sesion([FromBody] IniciarSesionModel.dataSesion data)
        {
            /*
                    {
	                    "email":"eclipce.callejero122@gmail.com",
	                    "password":123456,
                        "token":"7ea2a9ae-c306-4553-ab20-776a46706b89"
                    }
             */

            try
            {
                string url = "http://restapi.adequateshop.com/api/authaccount/login";

                var client = new RestClient(url);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", "Bearer "+data.token);
                request.AddHeader("Content-Type", "application/json");

                JObject body = new JObject();
                body.Add("email", data.email);
                body.Add("password", data.password);

                request.AddParameter("application/json", body, ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);

                var resp = JsonConvert.DeserializeObject<IniciarSesionModel.SAL_Header>(response.Content);

                return Ok(resp);
            }
            catch (Exception e)
            {
                Console.WriteLine("error: " + e.Message);
                return BadRequest(e.Message);
            }

        }

    }
}
