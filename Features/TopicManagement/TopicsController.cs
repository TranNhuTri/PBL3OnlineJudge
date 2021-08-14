using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using PBL3.Models;
using PBL3.General;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using PBL3.Features.ArticleManagement;
using PBL3.Features.ActionManagemant;
using PBL3.Features.AccountManagement;

namespace PBL3.Features.TopicManagement
{
    [Authorize(Roles ="Admin, Author")]
    public class TopicsController : Controller
    {
        private readonly ITopicService _topicService;
        private readonly IArticleService _articleService;
        private readonly IActionService _actionService;
        private readonly IAccountService _accountService;
        private IWebHostEnvironment _hostEnvironment;
        public TopicsController(IWebHostEnvironment env, ITopicService topicService, 
        IArticleService articleService, IActionService actionService, IAccountService accountService)
        {
            _hostEnvironment = env;
            _topicService = topicService;
            _articleService = articleService;
            _actionService = actionService;
            _accountService = accountService;
        }
        public IActionResult AddTopic()
        {
            ViewData["ListArticles"] = _articleService.GetAllArticles();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddTopic([Bind("name")]Topic reqTopic, List<int> reqListArticleIds, IFormFile describeImage)
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

                string InputFileName = null;
                if (describeImage != null && describeImage.Length > 0)
                {
                    InputFileName = Utility.CreateMD5(reqTopic.name);
                    var fileInfor = new FileInfo(describeImage.FileName);
                    if(fileInfor.Extension != ".jpg" && fileInfor.Extension != ".png" && fileInfor.Extension != ".svg")
                    {
                        ModelState.AddModelError("", "File ảnh không đúng định dạng");
                        return View(reqTopic);
                    }
                    InputFileName += fileInfor.Extension;
                    var ServerSavePath = Path.Combine(_hostEnvironment.WebRootPath + "/UploadedFiles/Images/" + InputFileName);
                    var stream = new FileStream(ServerSavePath, FileMode.Create);
                    describeImage.CopyTo(stream);
                    stream.Close();
                }

                _topicService.AddTopic(reqTopic, reqListArticleIds, InputFileName, Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(p => p.Type == "UserID").Value));

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
        public IActionResult EditTopic(int id, [Bind("name", "describeImage")] Topic reqTopic, List<int> reqListArticleIds, IFormFile describeImage)
        {
            ViewData["ListArticles"] = _articleService.GetAllArticles();
            ViewData["ListChosenArticleIds"] = reqListArticleIds;
            if(ModelState.IsValid)
            {
                Topic topic = _topicService.GetTopicByID(id);
                if(topic == null)
                    return NotFound();

                if(topic.name != reqTopic.name && _topicService.GetTopicByName(reqTopic.name) != null)
                {
                    ModelState.AddModelError("", "Chủ đề đã tồn tại");
                    return View(reqTopic);
                }
                string InputFileName = null;
                if(describeImage != null && describeImage.Length > 0)
                {
                    InputFileName = Utility.CreateMD5(reqTopic.name);
                    var fileInfor = new FileInfo(describeImage.FileName);
                    if(fileInfor.Extension != ".jpg" && fileInfor.Extension != ".png" && fileInfor.Extension != ".svg")
                    {
                        ModelState.AddModelError("", "File ảnh không đúng định dạng");
                        return View(reqTopic);
                    }
                    InputFileName += fileInfor.Extension;
                    var ServerSavePath = Path.Combine(_hostEnvironment.WebRootPath + "/UploadedFiles/Images/" + InputFileName);
                    var stream = new FileStream(ServerSavePath, FileMode.Create);
                    describeImage.CopyTo(stream);
                    stream.Close();
                    topic.describeImage = "/UploadedFiles/Images/" + InputFileName;
                }

                _topicService.UpdateTopic(id, reqTopic, reqListArticleIds, InputFileName, Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(p => p.Type == "UserID").Value));
                return RedirectToAction("Topics", "Admin");
            }

            return View(reqTopic);
        }
        public IActionResult History(int id)
        {
            var topic = _topicService.GetTopicByID(id);
            if(topic == null)
                return NotFound();
            var listActions = _actionService.GetAllActions()
            .Where(p => p.objectID == topic.ID && p.typeObject == Convert.ToInt32(TypeObject.Topic)).OrderByDescending(p => p.dateTime).ToList();
            List<PBL3.Models.Action> listActionsIncludeAccount = new List<PBL3.Models.Action>();
            foreach(PBL3.Models.Action action in listActions) 
            {
                action.account = _accountService.GetAccountByID(action.accountID);
                listActionsIncludeAccount.Add(action);
            }
            return View(listActionsIncludeAccount);
        }
        public IActionResult DeleteTopic(int id)
        {
            var topic = _topicService.GetTopicByID(id);
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

            var accountID = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(p => p.Type == "UserID").Value);
            _actionService.AddAction(new PBL3.Models.Action()
            {
                account = _accountService.GetAccountByID(accountID),
                objectID = topic.ID,
                dateTime = DateTime.Now,
                action = "Xóa chủ đề",
                typeObject = Convert.ToInt32(TypeObject.Topic)
            });

            return RedirectToAction("Topics", "Admin");
        }
        public IActionResult DeletedTopics()
        {
            
            var deletedTopics = _topicService.GetAllDeletedTopics();
            
            var listDates = new List<DateTime>();
            foreach(var item in deletedTopics)
            {
                var action = _actionService.GetAllActions().
                Where(p => p.objectID == item.ID && p.typeObject == (int)TypeObject.Topic).OrderByDescending(p => p.dateTime).First();
                listDates.Add(action.dateTime);
            }
            ViewBag.deleteDates = listDates;
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

            var accountID = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(p => p.Type == "UserID").Value);
            _actionService.AddAction(new PBL3.Models.Action()
            {
                account = _accountService.GetAccountByID(accountID),
                objectID = topic.ID,
                dateTime = DateTime.Now,
                action = "Khôi phục chủ đề",
                typeObject = Convert.ToInt32(TypeObject.Topic)
            });

            return RedirectToAction("Topics", "Admin");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
