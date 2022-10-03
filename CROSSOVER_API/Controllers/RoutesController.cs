using CROSSOVER_API.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Web.Helpers;
using System.Web.Http;



namespace CROSSOVER_API.Controllers
{
    public class RoutesController : ApiController
    {

        [HttpPost]
        [Route("api/create")]
        public IHttpActionResult Create([FromBody] CreateUsuarioModel.data data)
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

                var resp = JsonConvert.DeserializeObject<CreateUsuarioModel.SAL_RESP>(response.Content);

                return Ok(resp);
            }
            catch (Exception e)
            {
                Console.WriteLine("error: " + e.Message);
                return BadRequest(e.Message);
            }


        }

        [HttpPost]
        [Route("api/iniciosesion")]
        public IHttpActionResult Sesion([FromBody] IniciarSesionModel.data data)
        {
            
            try
            {
                string url = "http://restapi.adequateshop.com/api/authaccount/login";

                var client = new RestClient(url);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", "Bearer " + data.token);
                request.AddHeader("Content-Type", "application/json");

                JObject body = new JObject();
                body.Add("email", data.email);
                body.Add("password", data.password);

                request.AddParameter("application/json", body, ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);

                var resp = JsonConvert.DeserializeObject<IniciarSesionModel.SAL_RESP>(response.Content);

                return Ok(resp);
            }
            catch (Exception e)
            {
                Console.WriteLine("error: " + e.Message);
                return BadRequest(e.Message);
            }

        }

        [HttpGet]
        [Route("api/listar/repositorios")]
        public IHttpActionResult listar()
        {
            try
            {
                string url = "https://api.github.com/repositories";

                List<ListarRepositoriosModel.SAL_RESP_REPOSITORI> repositories = new List<ListarRepositoriosModel.SAL_RESP_REPOSITORI>();

                var client = new RestClient(url);
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                var resp = JsonConvert.DeserializeObject<List<ListarRepositoriosModel.SAL_RESP>>(response.Content);

                int count = 0;

                foreach (var item in resp)
                {
                    if(count < 10)
                    {
                        ListarRepositoriosModel.SAL_RESP_REPOSITORI obj = new ListarRepositoriosModel.SAL_RESP_REPOSITORI()
                        {
                            repos_url = item.owner.repos_url
                        };

                        repositories.Add(obj);
                        count++;
                    }
                }

                return Ok(new { repositories, count = repositories.Count });
            }
            catch (Exception e)
            {
                Console.WriteLine("error: " + e.Message);
                return BadRequest(e.Message);
            }

        }
    }
}
