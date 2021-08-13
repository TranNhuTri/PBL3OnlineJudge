using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using PBL3.Models;
using PBL3.Data;
using PBL3.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using PBL3.Features.ArticleManagement;

namespace PBL3.Features.TopicManagement
{
    [Authorize(Roles ="Admin, Author")]
    public class TopicsController : Controller
    {
        private readonly PBL3Context _context; // nho bo di
        private readonly ITopicService _topicService;
        private readonly IArticleService _articleService;
        private IWebHostEnvironment _hostEnvironment;
        public TopicsController(PBL3Context context, IWebHostEnvironment env, ITopicService topicService, IArticleService articleService)
        {
            _context = context;
            _hostEnvironment = env;
            _topicService = topicService;
            _articleService = articleService;
        }
        public IActionResult AddTopic()
        {
            ViewData["ListArticles"] = _articleService.GetAllArticles();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddTopic([Bind("name")]Topic reqTopic, List<int> reqListArticleIds, IFormFile describeImage)
        {
            ViewData["ListArticles"] = _articleService.GetAllArticles();
            ViewData["ListChosenArticleIDs"] = reqListArticleIds;

            if(ModelState.IsValid)
            {
                var topic = _topicService.GetAllTopics().FirstOrDefault(p => p.name.ToLower().Contains(reqTopic.name.ToLower()));

                if(topic != null)
                {
                    ModelState.AddModelError("", "Chủ đề đã tồn tại !");
                    return View();
                }

                if (describeImage != null && describeImage.Length > 0)
                {
                    var InputFileName = Utility.CreateMD5(reqTopic.name);
                    var fileInfor = new FileInfo(describeImage.FileName);
                    if(fileInfor.Extension != ".jpg" && fileInfor.Extension != ".png" && fileInfor.Extension != ".svg")
                    {
                        ModelState.AddModelError("", "File ảnh không đúng định dạng");
                        return View(reqTopic);
                    }
                    InputFileName += fileInfor.Extension;
                    var ServerSavePath = Path.Combine(_hostEnvironment.WebRootPath + "/UploadedFiles/Images/" + InputFileName);
                    var stream = new FileStream(ServerSavePath, FileMode.Create);
                    await describeImage.CopyToAsync(stream);
                    stream.Close();
                    reqTopic.describeImage = "/UploadedFiles/Images/" + InputFileName;
                }

                _topicService.AddTopic(reqTopic);
                foreach(int id in reqListArticleIds)
                {
                    var article = _articleService.GetAllArticles().FirstOrDefault(p => p.ID == id);
                    article.topicID = reqTopic.ID;
                    _articleService.UpdateArticle(article);
                }

                var accountID = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(p => p.Type == "UserID").Value);

                /*_context.Add(new PBL3.Models.Action()
                {
                    account = _context.Accounts.FirstOrDefault(p => p.ID == accountID),
                    objectID = reqTopic.ID,
                    dateTime = DateTime.Now,
                    action = "Tạo mới",
                    typeObject = Convert.ToInt32(TypeObject.Topic)
                });

                await _context.SaveChangesAsync();*/

                return RedirectToAction("Topics", "Admin");
            }
            return View();
        }
        public IActionResult EditTopic(int id)
        {
            ViewData["ListArticles"] = _articleService.GetAllArticles();
            ViewData["ListChosenArticleIds"] = _articleService.GetAllArticles().Where(p => p.topicID == id).Select(p => p.ID).ToList();
            var topic = _topicService.GetAllTopics().FirstOrDefault(p =>p .ID == id);
            return View(topic);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTopic(int id, [Bind("name", "describeImage")] Topic reqTopic, List<int> reqListArticleIds, IFormFile describeImage)
        {
            ViewData["ListArticles"] = _articleService.GetAllArticles();
            ViewData["ListChosenArticleIds"] = reqListArticleIds;
            if(ModelState.IsValid)
            {
                Topic topic = _topicService.GetTopicByID(id);
                if(topic == null)
                    return NotFound();

                if(topic.name != reqTopic.name && _topicService.GetAllTopics().FirstOrDefault(p => p.name == reqTopic.name) != null)
                {
                    ModelState.AddModelError("", "Chủ đề đã tồn tại");
                    return View(reqTopic);
                }

                var accountID = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(p => p.Type == "UserID").Value);
                var listArticleIDs =  _articleService.GetAllArticles().Where(p => p.topicID == id).Select(p => p.ID).ToList();

                /* if(Utility.DifferentList(listArticleIDs, reqListArticleIds))
                {
                    _context.Add(new PBL3.Models.Action()
                    {
                        accountID = accountID,
                        objectID = topicID,
                        dateTime = DateTime.Now,
                        action = "Sửa danh sách bài viết",
                        typeObject = Convert.ToInt32(TypeObject.Topic)
                    });
                } */

                foreach (var item in listArticleIDs)
                {
                    var article = _articleService.GetAllArticles().FirstOrDefault(p => p.ID == item);
                    article.topicID = null;
                   _articleService.UpdateArticle(article);
                }

                foreach(var item in reqListArticleIds)
                {
                    var article = _articleService.GetAllArticles().FirstOrDefault(p => p.ID == item);
                    article.topicID = id;
                   _articleService.UpdateArticle(article);
                }

                /*if(topic.name != reqTopic.name)
                {
                    topic.name = reqTopic.name;
                    _context.Add(new PBL3.Models.Action()
                    {
                        accountID = accountID,
                        objectID = id,
                        dateTime = DateTime.Now,
                        action = "Sửa tên chủ đề",
                        typeObject = Convert.ToInt32(TypeObject.Topic)
                    });
                }*/

                if(describeImage != null && describeImage.Length > 0)
                {
                    var InputFileName = Utility.CreateMD5(reqTopic.name);
                    var fileInfor = new FileInfo(describeImage.FileName);
                    if(fileInfor.Extension != ".jpg" && fileInfor.Extension != ".png" && fileInfor.Extension != ".svg")
                    {
                        ModelState.AddModelError("", "File ảnh không đúng định dạng");
                        return View(reqTopic);
                    }
                    InputFileName += fileInfor.Extension;
                    var ServerSavePath = Path.Combine(_hostEnvironment.WebRootPath + "/UploadedFiles/Images/" + InputFileName);
                    var stream = new FileStream(ServerSavePath, FileMode.Create);
                    await describeImage.CopyToAsync(stream);
                    stream.Close();
                    topic.describeImage = "/UploadedFiles/Images/" + InputFileName;
                }

                _topicService.UpdateTopic(topic);
                return RedirectToAction("Topics", "Admin");
            }

            return View(reqTopic);
        }
        public IActionResult History(int id)
        {
            var topic = _topicService.GetAllTopics().FirstOrDefault(p => p.ID == id);
            if(topic == null)
                return NotFound();
            var listActions = _context.Actions.Where(p => p.objectID == topic.ID && p.typeObject == Convert.ToInt32(TypeObject.Topic)).Include(p => p.account).OrderByDescending(p => p.dateTime).ToList();
            return View(listActions);
        }
        public IActionResult DeleteTopic(int id)
        {
            var topic = _topicService.GetAllTopics().Where(p => p.ID == id).FirstOrDefault();
            if(topic == null)
                return NotFound();
            ViewData["ListArticles"] = _articleService.GetAllArticles();
            ViewData["ListChosenArticleIds"] =  _articleService.GetAllArticles().Where(p => p.topicID == id).Select(p => p.ID).ToList();
            return View(topic);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteTopic(int? id)
        {
            var topic = _topicService.GetTopicByID((int)id);
            if(topic == null)
                return NotFound();
            _topicService.ChangeIsDeletedTopic((int)id);

            /*var accountID = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(p => p.Type == "UserID").Value);
            _context.Add(new PBL3.Models.Action()
            {
                account = _context.Accounts.FirstOrDefault(p => p.ID == accountID),
                objectID = topic.ID,
                dateTime = DateTime.Now,
                action = "Xóa chủ đề",
                typeObject = Convert.ToInt32(TypeObject.Topic)
            });

            _context.SaveChanges(); */

            return RedirectToAction("Topics", "Admin");
        }
        public IActionResult DeletedTopics()
        {
            
            var deletedTopics = _topicService.GetAllDeletedTopics();
            
            /*------------*/
            var listDates = new List<DateTime>();
            foreach(var item in deletedTopics)
            {
                var action = _context.Actions.Where(p => p.objectID == item.ID && p.typeObject == (int)TypeObject.Topic).OrderByDescending(p => p.dateTime).First();
                listDates.Add(action.dateTime);
            }
            
            ViewBag.deleteDates = listDates;
            /*-----*/

            return View(deletedTopics);
        }
        public IActionResult RestoreTopic(int id)
        {
            var topic = _topicService.GetTopicByID(id);
            if(topic == null)
                return NotFound();
            ViewData["ListArticles"] = _articleService.GetAllArticles();
            ViewData["ListChosenArticleIds"] = _articleService.GetAllArticles().Where(p => p.topicID == id).Select(p => p.ID).ToList();
            return View(topic); 
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RestoreTopic(int? id)
        {
            var topic = _topicService.GetTopicByID((int)id);
            if(topic == null)
                return NotFound();
            _topicService.ChangeIsDeletedTopic((int)id);

            /*var accountID = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(p => p.Type == "UserID").Value);
            _context.Add(new PBL3.Models.Action()
            {
                account = _context.Accounts.FirstOrDefault(p => p.ID == accountID),
                objectID = topic.ID,
                dateTime = DateTime.Now,
                action = "Khôi phục chủ đề",
                typeObject = Convert.ToInt32(TypeObject.Topic)
            });

            _context.SaveChanges();
            */

            return RedirectToAction("Topics", "Admin");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
