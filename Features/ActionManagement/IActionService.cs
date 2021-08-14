using System.Collections.Generic;
using PBL3.Models;

namespace PBL3.Features.ActionManagemant
{
    public interface IActionService
    {
        List<Action> GetAllActions();
        List<Action> GetActionsByArticleID(int id);
        List<Action> GetActionsByObject(int objectID, int typeID);
        Action GetActionByID(int ActionID);
        void AddAction(Action Action);
    }
}