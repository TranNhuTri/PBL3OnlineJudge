using System.Collections.Generic;
using System.IO;
using PBL3.Models;

namespace PBL3.Features.TopicManagement
{
    public interface ITopicService
    {
        List<Topic> GetAllTopics();
        List<Topic> GetAllDeletedTopics();
        Topic GetTopicByID(int topicID);
        Topic GetTopicByName(string topicName);
        void AddTopic(Topic topic, List<int> reqListArticleIds, string inputFileName, int accountID);
        void UpdateTopic(int id, Topic topic, List<int> reqListArticleIds, string inputFileName, int accountID);
        void ChangeIsDeletedTopic(int topicID);
    }
}