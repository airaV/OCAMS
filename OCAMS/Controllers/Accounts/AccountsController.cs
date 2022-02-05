using System.Dynamic;
using System.Web.Mvc;
using OCAMS.Service;
using Microsoft.AspNet.Identity;
using OCAMS.Models;
using System.Collections.Generic;
using OCAMS.Models.Accounts;
using System.Web;
using Microsoft.AspNet.Identity.Owin;

namespace OCAMS.Controllers.Accounts
{
    public class AccountsController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: Accounts
        public ActionResult Index()
        {
            dynamic mymodel = new ExpandoObject();
            AccountService accountService = new AccountService();
            var user = User.Identity.GetUserName();
            //mymodel.Employees = new List<SelectListItem>
            //{ 
            //    new SelectListItem {Text = "Shyju", Value = "1"},
            //    new SelectListItem {Text = "Sean", Value = "2"}
            //};

            if (user == "")
                return Redirect("Account/UserLogin");
            else
            {
                mymodel.CurentInfo = accountService.GetCurrentInfo(user);
                mymodel.AccountsViewAgentList = accountService.GetAllAgentList();
                mymodel.AccountsViewSubAccountList = accountService.GetAllSubAccountList();
                mymodel.AccountsViewMemberList = accountService.GetAllMemberList();
                mymodel.AccountsViewModel = new AccountsViewModel()
                {
                    Account = new AccountsModel(),
                    Person = new PersonModel(),
                    User = new UserModel()
                };
                mymodel.AccountLevelList = accountService.GetAccountLevels();
                mymodel.AccountTypeList = accountService.GetAccountTypes();
                return View(mymodel);
            }


           
        }

        public ActionResult Marks()
        {

            dynamic mymodel = new ExpandoObject();
            AccountService accountService = new AccountService();
            var user = User.Identity.GetUserName();
            mymodel.CurentInfo = accountService.GetCurrentInfo(user);
           // mymodel.AccountsViewList = accountService.GetAllAccounts();
            mymodel.CreateAccountsViewModel = new AccountsViewModel()
            {
                Account = new AccountsModel(),
                Person = new PersonModel(),
                User = new UserModel()
            };
            mymodel.AccountLevelList = accountService.GetAccountLevels();
            mymodel.AccountTypeList = accountService.GetAccountTypes();

            //dynamic expando = new ExpandoObject();

            //var marksModel = expando as IDictionary<string, object>;

            //string studentName = "Alice";
            //marksModel.Add("Name", studentName);
            //marksModel.Add("Physics", 24);
            //marksModel.Add("Chemistry", 45);
            //marksModel.Add("Biology", 31);

            return View(mymodel);

        }
        [HttpPost]
        public ActionResult SubmitMarks(CreateAccountModel model)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Nodes()
        {
            AccountService accountService = new AccountService();
            var user = User.Identity.GetUserName();
            var nodes = accountService.GetAllAccountsByLoginName(user);
            //var nodes = new List<JsTreeModel>();
            //nodes.Add(new JsTreeModel() { id = "101", parent = "#", text = "Simple root node", icon="" });
            //nodes.Add(new JsTreeModel() { id = "102", parent = "#", text = "Root node 1", icon = "" });
            //nodes.Add(new JsTreeModel() { id = "103", parent = "102", text = "Child 1", icon = "" });
            //nodes.Add(new JsTreeModel() { id = "104", parent = "102", text = "Child 2", icon = "" });
            return Json(nodes, JsonRequestBehavior.AllowGet);
        }

        // GET: Accounts/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Accounts/Create
        public ActionResult Create()
        {
           

            return View();
        }

        // POST: Accounts/Create
        [HttpPost]
        public ActionResult Create(CreateAccountModel model)
        {
            try
            {
                var user = User.Identity.GetUserName();
                AccountService accountService = new AccountService();

                accountService.SaveAccount(model, user, UserManager);

                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Accounts/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Accounts/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Accounts/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Accounts/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
