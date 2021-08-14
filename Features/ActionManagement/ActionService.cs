using System.Collections.Generic;
using System.Linq;
using PBL3.General;
using PBL3.Models;
using PBL3.Repositories;

namespace PBL3.Features.ActionManagemant
{
    public class ActionService: IActionService
    {
        private readonly IRepository<Action> _ActionRepo;
        public ActionService(IRepository<Action> ActionRepo)
        {
            _ActionRepo = ActionRepo;
        }
        public List<Action> GetAllActions()
        {
            return _ActionRepo.GetAll().ToList();
        }
        
        public List<Action> GetActionsByArticleID(int id)
        {
            return _ActionRepo.GetAll().Where(p => p.objectID == id && p.typeObject == 2).ToList();
        }

        public List<Action> GetActionsByObject(int objectID, int typeID)
        {
            return _ActionRepo.GetAll().Where(p => p.objectID == objectID && p.typeObject == typeID).ToList();
        }
        public Action GetActionByID(int ActionID)
        {
            return _ActionRepo.GetById(ActionID);
        }

        public void AddAction(Action Action)
        {
            _ActionRepo.Insert(Action);
            _ActionRepo.Save();
        }
    }
}