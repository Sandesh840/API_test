using API_Front.Data;
using API_Front.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using System.Text.Json.Serialization;

namespace API_Front.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ViewUser()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://localhost:7226/api/Home/getalluser");
            var resposeString=response.Content.ReadAsStringAsync();
            List<User> users = new List<User>();
            if (response.IsSuccessStatusCode)
            {
                users = JsonConvert.DeserializeObject<List<User>>(resposeString.Result);
            }
            return View(users);
        }
      
        public async Task<IActionResult> AddUser()
        {
            return View();
        }
       
        public async Task<IActionResult> SaveUser(User user)
        {
            HttpClient client=new HttpClient();
            var jsonContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

            //Make the POST request
            var response = await client.PostAsync("https://localhost:7226/api/Home/adduser", jsonContent);
            if (response.IsSuccessStatusCode)
            {
                //Request was successful
                string responseBody=await response.Content.ReadAsStringAsync();
            }
            else
            {
                string errorMessage=await response.Content.ReadAsStringAsync();
            }
            return RedirectToAction("AddUser");
        }
        public async Task<IActionResult> DeleteUserById(User user)
        {
            HttpClient client = new HttpClient();
            var jsonContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

            //Make the POST request
            var response = await client.DeleteAsync("https://localhost:7226/api/Home/" + user.Id);
            if (response.IsSuccessStatusCode)
            {
                //Request was successful
                string responseBody = await response.Content.ReadAsStringAsync();
            }
            else
            {
                string errorMessage = await response.Content.ReadAsStringAsync();
            }
            return RedirectToAction("ViewUser");
        }
        public async Task<IActionResult> UpdateUser(int id)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://localhost:7226/api/Home/" + id);      
            User users = new User();
            if (response.IsSuccessStatusCode)
            {
                var resposeString =await response.Content.ReadAsStringAsync();
                users = JsonConvert.DeserializeObject<User>(resposeString);
            }
            if(users != null)
            {
                return View(users);
            }
            else
            {
                return RedirectToAction("ViewUser");
            }
            
        }
        public async Task<IActionResult> UpdateUserById(User user)
        {
            HttpClient client = new HttpClient();
            var jsonContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

            //Make the POST request
            var response = await client.PutAsync("https://localhost:7226/api/Home/" + user.Id, jsonContent);
            if (response.IsSuccessStatusCode)
            {
                //Request was successful
                string responseBody = await response.Content.ReadAsStringAsync();
            }
            else
            {
                string errorMessage = await response.Content.ReadAsStringAsync();
            }
            return RedirectToAction("ViewUser");
        }
    }
}