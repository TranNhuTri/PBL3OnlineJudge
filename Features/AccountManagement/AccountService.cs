using System.Collections.Generic;
using System.Linq;
using PBL3.Models;
using PBL3.Repositories;

namespace PBL3.Features.AccountManagement
{
    public class AccountService: IAccountService
    {
        private readonly IRepository<Account> _accountRepo;
        public AccountService(IRepository<Account> accountRepo)
        {
            _accountRepo = accountRepo;
        }
        public Account GetAccountByID(int accountID)
        {
            return _accountRepo.GetById(accountID);
        }
        public List<Account> GetAllAuthor()
        {
            return _accountRepo.GetAll().Where(p => (p.roleID == 1 || p.roleID == 2) && p.isDeleted == false).ToList();
        }
    }
}