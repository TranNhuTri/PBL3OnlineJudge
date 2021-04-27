using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PBL3.Models;
using PBL3.Data;
using System.Net.Http;
using System.Net.Http.Json;
using Newtonsoft.Json;

namespace PBL3.Controllers
{
    public class ProblemController : Controller
    {
        private readonly PBL3Context _context;
        public ProblemController(PBL3Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Submit(string id)
        {
            var problem = _context.Problems.FirstOrDefault(m => m.ID == id);
            return View(problem);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Submit(string id, string ProblemSolution)
        {
            var test = _context.TestCases.FirstOrDefault(t => t.Problem.ID == id);
            var code = new code{
                script = ProblemSolution,
                stdin = test.Input
            };
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.jdoodle.com");
            var result = await client.PostAsJsonAsync("/v1/execute", code);
            var returnValue = JsonConvert.DeserializeObject<codeResult>(result.Content.ReadAsStringAsync().Result);
            if(returnValue.statusCode == 200 && returnValue.output == test.Output)
            {
                Console.WriteLine("Accept");
            }
            else
            {
                Console.WriteLine("WA");
            }
            return View("SubmitStatus");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
class code
{
    public string script{get; set;}
    public string language {get; set;} = "cpp17";
    public int versionIndex{get; set;}
    public string stdin{get; set;}
    public string clientId{get; set;} = "672651acf3fa819a1e0c27a9fb272658";
    public string clientSecret{get; set;} = "14aec224d7ad63e9c036929fbd7b356d4e043f80cb5993daabd855b184e076e1";
}
class codeResult
{
    public string output{get; set;}
    public int statusCode{get; set;}
    public int memory{get; set;}
    public float cpuTime{get; set;}
}