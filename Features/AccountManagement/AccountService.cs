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
        public List<Account> GetAllAccounts()
        {
            return _accountRepo.GetAll().Where(p => p.isDeleted == false).ToList();
        }
        public Account GetAccountByEmail(string email)
        {
            return _accountRepo.GetAll().FirstOrDefault(p => p.email == email);
        }
        public Account GetAccountByAccountName(string accountName)
        {
            return _accountRepo.GetAll().FirstOrDefault(p => p.accountName == accountName);
        }
        public void AddAccount(Account account)
        {
            _accountRepo.Insert(account);
            _accountRepo.Save();
        }
        public void UpdateAccount(Account account)
        {
            _accountRepo.Update(account);
            _accountRepo.Save();
        }
        public Account GetAccountByID(int accountID)
        {
            return _accountRepo.GetById(accountID);
        }
        public List<Account> GetAllAuthor()
        {
            return _accountRepo.GetAll().Where(p => (p.roleID == 1 || p.roleID == 2) && p.isDeleted == false).ToList();
        }
        public List<Account> GetAllDeletedAccounts()
        {
            return _accountRepo.GetAll().Where(p => p.isDeleted == true).ToList();
        }
        public void DeleteAccount(int accountID)
        {
            _accountRepo.Delete(accountID);
            _accountRepo.Save();
        }
    }
}