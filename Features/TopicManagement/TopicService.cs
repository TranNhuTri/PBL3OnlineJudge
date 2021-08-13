using System.Collections.Generic;
using System.Linq;
using PBL3.Models;
using PBL3.Repositories;

namespace PBL3.Features.TopicManagement
{
    public class TopicService: ITopicService
    {
        private readonly IRepository<Topic> _topicRepo;
        public TopicService(IRepository<Topic> topicRepo)
        {
            _topicRepo = topicRepo;
        }
        public List<Topic> GetAllTopics() 
        {
            return _topicRepo.GetAll().ToList();
        }

        public Topic GetTopicByID(int topicID)
        {
            return _topicRepo.GetById(topicID);
        }
        public void AddTopic(Topic topic)
        {
            _topicRepo.Insert(topic);
            _topicRepo.Save();
        }
        public void UpdateTopic(Topic topic)
        {
            _topicRepo.Update(topic);
            _topicRepo.Save();
        }

        public void DeleteTopic(int topicID)
        {
            _topicRepo.Delete(topicID);
            _topicRepo.Save();
        }
    }
}