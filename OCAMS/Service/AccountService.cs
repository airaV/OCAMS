using OCAMS.Context;
using OCAMS.Models;
using OCAMS.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OCAMS.Service
{
    public class AccountService
    {
        OCAMSDBEntities db = new OCAMSDBEntities();


        public List<OCAMS_AccountLevel> GetAccountLevels()
        {
            return db.OCAMS_AccountLevel.ToList();
        }

        public List<OCAMS_AccountType> GetAccountTypes()
        {
            return db.OCAMS_AccountType.ToList();
        }

        public List<OCAMS_UserType> GetUserTypes()
        {
            return db.OCAMS_UserType.ToList();
        }
        public List<OCAMS_Currency> GetCurrencies()
        {
            return db.OCAMS_Currency.ToList();
        }
        public AccountsViewModel GetCurrentInfo(string username)
        {
            var user = db.OCAMS_User.FirstOrDefault(x => x.Username == username);
            var account = db.OCAMS_Account.FirstOrDefault(x => x.UserId == user.Id);
            var person = db.OCAMS_Person.FirstOrDefault(x => x.Id == account.PersonId);

            AccountsViewModel accountsViewModel = new AccountsViewModel()
            {
                Account = new AccountsModel()
                {
                    Id = account.Id,
                    PersonId = account.PersonId,
                    UserId = account.UserId,
                    AccountLevelId = account.AccountLevelId,
                    AccountTypeId = account.AccountTypeId,
                    CreditLimit = account.CreditLimit,
                    CurrencyId = account.CurrencyId,
                    CasinoBalance = account.CasinoBalance,
                    TotalCasinoBalance = account.TotalCasinoBalance,
                    Commission = account.Commission,
                    Deposit = account.Deposit,
                    Withdrawal = account.Withdrawal,
                    IsActive = account.IsActive,
                    IsActiveDescription = (bool)account.IsActive ? "Active" : "Inactive"
                },
                Person = new PersonModel
                {
                    Id = person.Id,
                    Firstname = person.Firstname,
                    Middlename = person.Middlename,
                    Lastname = person.Lastname,
                    Address = person.Address,
                    Birthdate = person.Birthdate,
                    ContactNumber = person.ContactNumber,
                    Email = person.Email,
                    IsActive = person.IsActive
                },
                User = new UserModel()
                {
                    Id = user.Id,
                    PersonId = user.PersonId,
                    Username = user.Username,
                    Password = user.Password,
                    IsOTPEnable = user.IsOTPEnable,
                    UserTypeId = user.UserTypeId,
                    IsActive = user.IsActive
                },
                Fullname = person.Firstname + " " + person.Middlename + " " + person.Lastname
            };

            return accountsViewModel;
        }
        public List<AccountsViewModel> GetAllAgentList()
        {
            List<AccountsViewModel> accountsViewModels = new List<AccountsViewModel>();
            var accountTypeId = db.OCAMS_AccountType.FirstOrDefault(x => x.Name == "Agent");

            foreach (var items in db.OCAMS_Account.Where(x => x.AccountTypeId == accountTypeId.Id))
            {
                var person = db.OCAMS_Person.FirstOrDefault(x => x.Id == items.PersonId);
                var user = db.OCAMS_User.FirstOrDefault(x => x.Id == items.UserId);
                var levelName = db.OCAMS_AccountLevel.FirstOrDefault(x => x.Id == items.AccountLevelId).Name;
                var currencyName = db.OCAMS_Currency.FirstOrDefault(x => x.Id == items.CurrencyId).CurrencySign;
                AccountsViewModel accountsViewModel = new AccountsViewModel()
                {
                    Account = new AccountsModel()
                    {
                        Id = items.Id,
                        PersonId = items.PersonId,
                        UserId = items.UserId,
                        AccountLevelId = items.AccountLevelId,
                        AccountTypeId = items.AccountTypeId,
                        CreditLimit = items.CreditLimit,
                        CurrencyId = items.CurrencyId,
                        CasinoBalance = items.CasinoBalance,
                        TotalCasinoBalance = items.TotalCasinoBalance,
                        Commission = items.Commission,
                        Deposit = items.Deposit,
                        Withdrawal = items.Withdrawal,
                        IsActive = items.IsActive
                    },
                    Person = new PersonModel
                    {
                        Id = person.Id,
                        Firstname = person.Firstname,
                        Middlename = person.Middlename,
                        Lastname = person.Lastname,
                        Address = person.Address,
                        Birthdate = person.Birthdate,
                        ContactNumber = person.ContactNumber,
                        Email = person.Email,
                        IsActive = person.IsActive
                    },
                    User = new UserModel()
                    {
                        Id = user.Id,
                        PersonId = user.PersonId,
                        Username = user.Username,
                        Password = user.Password,
                        IsOTPEnable = user.IsOTPEnable,
                        UserTypeId = user.UserTypeId,
                        IsActive = user.IsActive
                    },
                    Fullname = person.Firstname + " " + person.Middlename + " " + person.Lastname,
                    LevelName = levelName,
                    CurrencyName = currencyName

                };

                accountsViewModels.Add(accountsViewModel);
            }

            return accountsViewModels;
        }


        public List<AccountsViewModel> GetAllSubAccountList()
        {
            List<AccountsViewModel> accountsViewModels = new List<AccountsViewModel>();
            var accountTypeId = db.OCAMS_AccountType.FirstOrDefault(x => x.Name == "Sub-Account");

            foreach (var items in db.OCAMS_Account.Where(x => x.AccountTypeId == accountTypeId.Id))
            {
                var person = db.OCAMS_Person.FirstOrDefault(x => x.Id == items.PersonId);
                var user = db.OCAMS_User.FirstOrDefault(x => x.Id == items.UserId);
                var levelName = db.OCAMS_AccountLevel.FirstOrDefault(x => x.Id == items.AccountLevelId).Name;
                var currencyName = db.OCAMS_Currency.FirstOrDefault(x => x.Id == items.CurrencyId).CurrencySign;
                AccountsViewModel accountsViewModel = new AccountsViewModel()
                {
                    Account = new AccountsModel()
                    {
                        Id = items.Id,
                        PersonId = items.PersonId,
                        UserId = items.UserId,
                        AccountLevelId = items.AccountLevelId,
                        AccountTypeId = items.AccountTypeId,
                        CreditLimit = items.CreditLimit,
                        CurrencyId = items.CurrencyId,
                        CasinoBalance = items.CasinoBalance,
                        TotalCasinoBalance = items.TotalCasinoBalance,
                        Commission = items.Commission,
                        Deposit = items.Deposit,
                        Withdrawal = items.Withdrawal,
                        IsActive = items.IsActive
                    },
                    Person = new PersonModel
                    {
                        Id = person.Id,
                        Firstname = person.Firstname,
                        Middlename = person.Middlename,
                        Lastname = person.Lastname,
                        Address = person.Address,
                        Birthdate = person.Birthdate,
                        ContactNumber = person.ContactNumber,
                        Email = person.Email,
                        IsActive = person.IsActive
                    },
                    User = new UserModel()
                    {
                        Id = user.Id,
                        PersonId = user.PersonId,
                        Username = user.Username,
                        Password = user.Password,
                        IsOTPEnable = user.IsOTPEnable,
                        UserTypeId = user.UserTypeId,
                        IsActive = user.IsActive
                    },
                    Fullname = person.Firstname + " " + person.Middlename + " " + person.Lastname,
                    LevelName = levelName,
                    CurrencyName = currencyName

                };

                accountsViewModels.Add(accountsViewModel);
            }

            return accountsViewModels;
        }

        public List<AccountsViewModel> GetAllMemberList()
        {
            List<AccountsViewModel> accountsViewModels = new List<AccountsViewModel>();
            var accountTypeId = db.OCAMS_AccountType.FirstOrDefault(x => x.Name == "Member");

            foreach (var items in db.OCAMS_Account.Where(x => x.AccountTypeId == accountTypeId.Id))
            {
                var person = db.OCAMS_Person.FirstOrDefault(x => x.Id == items.PersonId);
                var user = db.OCAMS_User.FirstOrDefault(x => x.Id == items.UserId);
                var levelName = db.OCAMS_AccountLevel.FirstOrDefault(x => x.Id == items.AccountLevelId).Name;
                var currencyName = db.OCAMS_Currency.FirstOrDefault(x => x.Id == items.CurrencyId).CurrencySign;
                AccountsViewModel accountsViewModel = new AccountsViewModel()
                {
                    Account = new AccountsModel()
                    {
                        Id = items.Id,
                        PersonId = items.PersonId,
                        UserId = items.UserId,
                        AccountLevelId = items.AccountLevelId,
                        AccountTypeId = items.AccountTypeId,
                        CreditLimit = items.CreditLimit,
                        CurrencyId = items.CurrencyId,
                        CasinoBalance = items.CasinoBalance,
                        TotalCasinoBalance = items.TotalCasinoBalance,
                        Commission = items.Commission,
                        Deposit = items.Deposit,
                        Withdrawal = items.Withdrawal,
                        IsActive = items.IsActive
                    },
                    Person = new PersonModel
                    {
                        Id = person.Id,
                        Firstname = person.Firstname,
                        Middlename = person.Middlename,
                        Lastname = person.Lastname,
                        Address = person.Address,
                        Birthdate = person.Birthdate,
                        ContactNumber = person.ContactNumber,
                        Email = person.Email,
                        IsActive = person.IsActive
                    },
                    User = new UserModel()
                    {
                        Id = user.Id,
                        PersonId = user.PersonId,
                        Username = user.Username,
                        Password = user.Password,
                        IsOTPEnable = user.IsOTPEnable,
                        UserTypeId = user.UserTypeId,
                        IsActive = user.IsActive
                    },
                    Fullname = person.Firstname + " " + person.Middlename + " " + person.Lastname,
                    LevelName = levelName,
                    CurrencyName = currencyName

                };

                accountsViewModels.Add(accountsViewModel);
            }

            return accountsViewModels;
        }

        public List<JsTreeModel> GetAllAccountsByLoginName(string username)
        {
            var user = db.OCAMS_User.FirstOrDefault(x => x.Username == username);
            var account = db.OCAMS_Account.FirstOrDefault(x => x.UserId == user.Id);
            var person = db.OCAMS_Person.FirstOrDefault(x => x.Id == account.PersonId);
            var accountId = db.OCAMS_AccountParentChild.FirstOrDefault(x => x.AccountId == account.Id).Id;
            var rootAccountId = GetParentRoot(accountId);

            account = db.OCAMS_Account.FirstOrDefault(x => x.Id == rootAccountId);
            user = db.OCAMS_User.FirstOrDefault(x => x.Id == account.UserId);


            var nodes = new List<JsTreeModel>();

            nodes.Add(new JsTreeModel() { id = account.Id.ToString(), parent = "#", text = user.Username, icon = "false" });

            nodes = GetParentAndChild(account.Id, nodes);


            //nodes.Add(new JsTreeModel() { id = "101", parent = "#", text = "Simple root node", icon = "" });
            //nodes.Add(new JsTreeModel() { id = "102", parent = "#", text = "Root node 1", icon = "" });
            //nodes.Add(new JsTreeModel() { id = "103", parent = "102", text = "Child 1", icon = "" });
            //nodes.Add(new JsTreeModel() { id = "104", parent = "102", text = "Child 2", icon = "" });

            return nodes;
        }



        private long GetParentRoot(long? accountId)
        {
            var accountParentChild = db.OCAMS_AccountParentChild.FirstOrDefault(x => x.AccountId == accountId);

            long id = 0;

            if (accountParentChild != null)
                if (accountParentChild.ParentAccountId != null)
                {

                    id = GetParentRoot(accountParentChild.ParentAccountId);
                }
                else
                {
                    id = accountParentChild.AccountId;
                }

            return id;
            //var currentId = 
            //(from parents in db.OCAMS_AccountParentChild
            // from all in db.OCAMS_AccountParentChild
            // where
            //     parents.ParentAccountId == null &&
            //     (all.ParentAccountId == null || all.ParentAccountId == parents.Id)
            // select all).Distinct();
        }

        public void SaveAccount(CreateAccountModel model, string username, ApplicationUserManager userManager)
        {
            try
            {
                var currentUser = db.OCAMS_User.FirstOrDefault(x => x.Username == username);
                var userASP = new ApplicationUser { UserName = model.Username, Email = model.Email };
                var result = userManager.CreateAsync(userASP, model.Password);
                var datetime = System.DateTime.Now;
                if (result.Result.Succeeded)
                {
                    var aspnetUserId = userASP.Id;

                    var person = new OCAMS_Person()
                    {
                        Firstname = model.Firstname,
                        Middlename = model.Middlename,
                        Lastname = model.Lastname,
                        Address = model.Address ?? "Sample",
                        Birthdate = model.Birthdate,
                        ContactNumber = model.ContactNumber,
                        Email = model.Email,
                        IsActive = true,
                        CreatedBy = currentUser.Id,
                        CreatedDate = datetime
                    };

                    db.OCAMS_Person.Add(person);
                    db.SaveChanges();

                    var user = new OCAMS_User()
                    {
                        PersonId = person.Id,
                        Username = model.Username,
                        Password = model.Password,
                        AspNetUserId = aspnetUserId,
                        UserTypeId = 2,
                        CreatedBy = currentUser.Id,
                        CreatedDate = datetime
                    };
                    db.OCAMS_User.Add(user);
                    db.SaveChanges();
                    var account = new OCAMS_Account()
                    {
                        PersonId = person.Id,
                        UserId = user.Id,
                        AccountLevelId = 8,
                        AccountTypeId = 1,
                        CreditLimit = model.CreditLimit,
                        CurrencyId = 1,
                        CasinoBalance = model.CasinoBalance,
                        TotalCasinoBalance = model.TotalCasinoBalance,
                        Commission = model.Commission,
                        Deposit = model.Deposit,
                        Withdrawal = model.Withdrawal,
                        IsActive = true,
                        CreatedBy = currentUser.Id,
                        CreatedDate = datetime
                    };
                    db.SaveChanges();
                    db.OCAMS_Account.Add(account);
                    var accountParentChild = new OCAMS_AccountParentChild()
                    {
                        AccountId = account.Id,
                        ParentAccountId = 1,
                        CreatedBy = currentUser.Id,
                        CreatedDate = datetime

                    };

                    db.OCAMS_AccountParentChild.Add(accountParentChild);

                    db.SaveChanges();

                }
            }
            catch (Exception ex)
            {

            }
            
        }

        //Update Account
        public void UpdateAccount(CreateAccountModel model, string username, ApplicationUserManager userManager)
        {
            try
            {
                var currentUser = db.OCAMS_User.FirstOrDefault(x => x.Username == username);
                var userASP = new ApplicationUser { UserName = model.Username, Email = model.Email };
                var result = userManager.CreateAsync(userASP, model.Password);
                var datetime = System.DateTime.Now;
                if (result.Result.Succeeded)
                {
                    var aspnetUserId = userASP.Id;

                    var person = new OCAMS_Person()
                    {
                        Firstname = model.Firstname,
                        Middlename = model.Middlename,
                        Lastname = model.Lastname,
                        Address = model.Address ?? "Sample",
                        Birthdate = model.Birthdate,
                        ContactNumber = model.ContactNumber,
                        Email = model.Email,
                        IsActive = true,
                        CreatedBy = currentUser.Id,
                        CreatedDate = datetime
                    };

                    db.OCAMS_Person.Add(person);
                    db.SaveChanges();

                    var user = new OCAMS_User()
                    {
                        PersonId = person.Id,
                        Username = model.Username,
                        Password = model.Password,
                        AspNetUserId = aspnetUserId,
                        UserTypeId = 2,
                        CreatedBy = currentUser.Id,
                        CreatedDate = datetime
                    };
                    db.OCAMS_User.Add(user);
                    db.SaveChanges();
                    var account = new OCAMS_Account()
                    {
                        PersonId = person.Id,
                        UserId = user.Id,
                        AccountLevelId = 8,
                        AccountTypeId = 1,
                        CreditLimit = model.CreditLimit,
                        CurrencyId = 1,
                        CasinoBalance = model.CasinoBalance,
                        TotalCasinoBalance = model.TotalCasinoBalance,
                        Commission = model.Commission,
                        Deposit = model.Deposit,
                        Withdrawal = model.Withdrawal,
                        IsActive = true,
                        CreatedBy = currentUser.Id,
                        CreatedDate = datetime
                    };
                    db.SaveChanges();
                    db.OCAMS_Account.Add(account);
                    var accountParentChild = new OCAMS_AccountParentChild()
                    {
                        AccountId = account.Id,
                        ParentAccountId = 1,
                        CreatedBy = currentUser.Id,
                        CreatedDate = datetime

                    };

                    db.OCAMS_AccountParentChild.Add(accountParentChild);

                    db.SaveChanges();

                }
            }
            catch (Exception ex)
            {

            }

        }
        //end update Account


        private List<JsTreeModel> GetParentAndChild(long accountId, List<JsTreeModel> jsTreeModels = null)
        {

            var child = db.OCAMS_AccountParentChild.Where(x => x.ParentAccountId == accountId);

            foreach (var items in child)
            {

                var account = db.OCAMS_Account.FirstOrDefault(x => x.Id == items.AccountId);
                var user = db.OCAMS_User.FirstOrDefault(x => x.Id == account.UserId);
                jsTreeModels.Add(new JsTreeModel() { id = account.Id.ToString(), parent = accountId.ToString(), text = user.Username, icon = "false" });

                GetParentAndChild(items.AccountId, jsTreeModels);

            }

            return jsTreeModels;

        }
    }
}