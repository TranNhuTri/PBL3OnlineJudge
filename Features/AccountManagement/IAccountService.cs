using System.Collections.Generic;
using PBL3.Models;

namespace PBL3.Features.AccountManagement
{
    public interface IAccountService
    {
        List<Account> GetAllAccounts();
        Account GetAccountByID(int accountID);
        Account GetAccountByAccountName(string accountName);
        Account GetAccountByEmail(string email);
        void AddAccount(Account account);
        void UpdateAccount(Account account);
        List<Account> GetAllAuthor();
        List<Account> GetAllDeletedAccounts();
        void DeleteAccount(int accountID);
    }
}