using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using PBL3.Models;
using PBL3.Data;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace PBL3.Controllers
{
    public class DataController : Controller
    {
        private readonly PBL3Context _context;
        public DataController(PBL3Context context)
        {
            _context = context;
        }
        public string Submission(int? id)
        {
            var submission  = _context.Submissions.Include(s => s.account)
                                                .Include(s => s.problem)
                                                .Include(s => s.submissionResults)
                                                .ThenInclude(sr => sr.testCase)
                                                .Select(s => new{s.ID, s.account.accountName, s.problem.title, s.code, s.submissionResults, s.status, s.memory, s.time})
                                                .FirstOrDefault(s => s.ID == id);
            return JsonConvert.SerializeObject(submission, new JsonSerializerSettings() { 
		        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
	        });
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
