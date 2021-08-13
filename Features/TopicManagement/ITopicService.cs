using System.Collections.Generic;
using PBL3.Models;

namespace PBL3.Features.TopicManagement
{
    public interface ITopicService
    {
        List<Topic> GetAllTopics();
        List<Topic> GetAllDeletedTopics();
        Topic GetTopicByID(int topicID);
        void AddTopic(Topic topic);
        void UpdateTopic(Topic topic);
        void ChangeIsDeletedTopic(int topicID);
    }
}