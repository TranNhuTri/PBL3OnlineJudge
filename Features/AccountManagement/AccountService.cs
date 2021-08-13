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
    }
}