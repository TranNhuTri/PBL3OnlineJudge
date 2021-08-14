using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using PBL3.Models;
using PBL3.Repositories;
using PBL3.General;
using System;
using PBL3.Features.ArticleManagement;
using PBL3.Features.ActionManagemant;

namespace PBL3.Features.TopicManagement
{
    public class TopicService: ITopicService
    {
        private readonly IRepository<Topic> _topicRepo;
        private readonly IArticleService _articleService;
        private readonly IActionService _actionService;
        public TopicService(IRepository<Topic> topicRepo, IArticleService articleService, IActionService actionService)
        {
            _topicRepo = topicRepo;
            _articleService = articleService;
            _actionService = actionService;
        }
        public List<Topic> GetAllTopics() 
        {
            return _topicRepo.GetAll().Where(p => p.isDeleted == false).ToList();
        }
        public List<Topic> GetAllDeletedTopics()
        {
            return _topicRepo.GetAll().Where(p => p.isDeleted == true).ToList();
        }
        public Topic GetTopicByID(int topicID)
        {
            return _topicRepo.GetById(topicID);
        }
        public Topic GetTopicByName(string topicName)
        {
            return _topicRepo.GetAll().Where(p => p.name == topicName).FirstOrDefault();
        }
        public void AddTopic(Topic topic, List<int> reqListArticleIds, string inputFileName, int accountID)
        {
            foreach(int id in reqListArticleIds)
            {
                var article = _articleService.GetArticleByID(id);
                article.topicID = topic.ID;
                _articleService.UpdateArticle(article);
            }

            _actionService.AddAction(new PBL3.Models.Action()
            {
                accountID = accountID,
                objectID = topic.ID,
                dateTime = DateTime.Now,
                action = "Tạo mới",
                typeObject = Convert.ToInt32(TypeObject.Topic)
            });

            if(inputFileName != null)
                topic.describeImage = "/UploadedFiles/Images/" + inputFileName;

            _topicRepo.Insert(topic);
            _topicRepo.Save();
        }
        public void UpdateTopic(int id, Topic reqTopic, List<int> reqListArticleIds, string inputFileName, int accountID)
        {
            var listArticleIDs =  _articleService.GetAllArticles().Where(p => p.topicID == id).Select(p => p.ID).ToList();

            var topic = _topicRepo.GetById(id);

            var action =new PBL3.Models.Action()
            {
                accountID = accountID,
                objectID = id,
                dateTime = DateTime.Now,
                action = "Sửa ",
                typeObject = Convert.ToInt32(TypeObject.Topic)
            };

            if(PBL3.General.Utility.DifferentList(listArticleIDs, reqListArticleIds))
                action.action += "danh sách bài viết, ";

            foreach (var item in listArticleIDs)
            {
                var article = _articleService.GetArticleByID(item);
                article.topicID = null;
                _articleService.UpdateArticle(article);
            }

            foreach(var item in reqListArticleIds)
            {
                var article = _articleService.GetArticleByID(item);
                article.topicID = id;
                _articleService.UpdateArticle(article);
            }

            if(topic.name != reqTopic.name)
                action.action += "tên chủ đề, ";
            
            action.action = action.action.Substring(0, action.action.Length - 2);

            _actionService.AddAction(action);

            if(inputFileName != null)
                topic.describeImage = inputFileName;
            topic.name = reqTopic.name;
            _topicRepo.Update(topic);
            _topicRepo.Save();
        }
        public void ChangeIsDeletedTopic(int topicID)
        {
            Topic topic = GetTopicByID(topicID);
            topic.isDeleted = !topic.isDeleted;
            _topicRepo.Save();
        }
    }
}