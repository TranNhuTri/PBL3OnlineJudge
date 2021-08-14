using System.Collections.Generic;
using PBL3.Models;

namespace PBL3.Features.AccountManagement
{
    public interface IAccountService
    {
        Account GetAccountByID(int accountID);
        List<Account> GetAllAuthor();
    }
}