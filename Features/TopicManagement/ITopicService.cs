using System.Collections.Generic;
using PBL3.Models;

namespace PBL3.Features.TopicManagement
{
    public interface ITopicService
    {
        List<Topic> GetAllTopics();
        Topic GetTopicByID(int topicID);
        void AddTopic(Topic topic);
        void UpdateTopic(Topic topic);
        void DeleteTopic(int topicID);
    }
}