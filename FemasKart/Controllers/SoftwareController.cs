using Entities.Models;
using FemasKart.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace FemasKart.Controllers
{
    public class SoftwareController : BaseController
    {
        private readonly HttpClient _httpClient;

        public SoftwareController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7170/api/"); // API adresi
        }

        public IActionResult Index()
        {
            var redirect = RequireLogin();
            if (redirect != null) return redirect;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetSoftwares()
        {
            var response = await _httpClient.GetAsync("software");
            if (!response.IsSuccessStatusCode) return BadRequest();

            var content = await response.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<List<Software>>(content);
            return Json(list);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Software model)
        {
            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("software/Create", content);
            if (!response.IsSuccessStatusCode) return BadRequest();

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] Software model)
        {
            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"software/{model.Id}", content);
            if (!response.IsSuccessStatusCode) return BadRequest();

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"software/{id}");
            if (!response.IsSuccessStatusCode) return BadRequest();

            return Ok();
        }
    }
}
