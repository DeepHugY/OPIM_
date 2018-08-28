using OPIM_BLL.Respository;
using OPIM_Common.DataModels;
using OPIM_Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OPIM.Controllers
{
    [Authorize]
    public class BudgetController : Controller
    {
        private readonly BudgetRespository _budgetRespository;

        private readonly Authentication _authentication;
        // GET: Budget
        public BudgetController()
        {
            this._budgetRespository = new BudgetRespository();
            this._authentication = new Authentication();
        }
        public ActionResult Index()
        {
            ViewBag.IsAdmin = _authentication.IsAdmin();
            return View();
        }

        public ActionResult Add(BudgetModel model)
        {
            model.Id = Guid.NewGuid();
            model.CreateBy = _authentication.MemberShipId;
            var result = _budgetRespository.AddBudget(model);
            return Json(result);
        }
        public ActionResult Update(Guid id, decimal money)
        {
            var result = _budgetRespository.Update(id,money);
            return Json(result);
        }
        public ActionResult Delete(Guid id)
        {
            var result = _budgetRespository.Remove(id);
            return Json(result);
        }

        public ActionResult GetBudgetList(int year, int month)
        {
            var memberShipId = _authentication.MemberShipId;
            var result = _budgetRespository.GetBudgetCompleteList(year, month, memberShipId);
            List<ShowBudgetModel> list = new List<ShowBudgetModel>();
            foreach (var item in result)
            {

                ShowBudgetModel showBudget = new ShowBudgetModel();
                showBudget.Id = item.Id;
                showBudget.InOrOut = item.InOrOut;
                showBudget.Money = item.Money;
                showBudget.TypeName = item.TypeName;
                showBudget.IsEdit = false;

                //获取本月已经消费额
                //showBudget.Expense = item;
                list.Add(showBudget);
            }
            return Json(new { Success = true, Count = list.Count, List = list });
        }
    }
}