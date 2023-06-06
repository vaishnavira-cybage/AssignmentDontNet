using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using System.Text.Json;
using AssignmentMVC.Models;
using Newtonsoft.Json;
//using AssignmentMVC.Models;

namespace Assignment.Controllers
{
    public class MachineController : Controller
    {
        private readonly HttpClient _httpClient;
        public MachineController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("MachineApi");
        }




        public async Task<IActionResult> Index()
        {
            //var response = await _httpClient.GetAsync("/api/Machine");
            var response = await _httpClient.GetAsync("https://localhost:5001/api/Machine");

            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            MachineInfo machineInfo = JsonConvert.DeserializeObject<MachineInfo>(content);

            return View(machineInfo);
        }



        //public async Task<IActionResult> Index()
        //{

        //    //The action calls the ASP .NET Web Api enpoint '/api/machine'
        //    //using instance of HttpClient obtained from injected IHttpClientFactory.
        //    using(HttpClient client =new HttpClient())
        //    {

        //        HttpResponseMessage response = await client.GetAsync("https://localhost:44371/api/Machine");

        //        if (response.IsSuccessStatusCode)
        //        {
        //            string json = await response.Content.ReadAsStringAsync();
        //            //deserialising the json responses into a'Machine' Object
        //            MachineInfo machineInfo = JsonConvert.DeserializeObject<MachineInfo>(json); 
        //            return View(machineInfo);
        //        }
        //        else
        //        {
        //            return View("Error");
        //        }
        //    }
        //}



    }
}

        