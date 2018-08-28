using OPIM_BLL.Respository;
using OPIM_Common.DataModels;
using OPIM_Common.Extensions;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OPIM.Controllers
{
    [Authorize]
    public class TypesController : Controller
    {
        private readonly TypesRespository _typesRespository;
        private readonly MemberShipsRespository _memberShipsRespository;
        private readonly Authentication _authentication;
        public TypesController()
        {
            this._typesRespository = new TypesRespository();
            this._memberShipsRespository = new MemberShipsRespository();
            this._authentication = new Authentication();
        }
        // GET: Types
        public ActionResult Index()
        {
            ViewBag.IsAdmin = _authentication.IsAdmin();
            return View();
        }

        public ActionResult Add(TypesModel model)
        {
            model.CreateOn = DateTime.Now;
            model.CreateBy = _authentication.MemberShipId;
            var result = _typesRespository.CreateType(Guid.NewGuid(), model.Name, model.InOrOut, DateTime.Now, model.CreateBy, model.Remark);
            return Json(result);
        }
        public ActionResult Delete(Guid id)
        {
            var _typesRespository = new TypesRespository();
            var result = _typesRespository.RemoveType(id);
            return Json(result);
        }

        public ActionResult Update(TypesModel model)
        {
            var result = _typesRespository.UpdateType(model);
            return Json(result);
        }

        public ActionResult _TypesGrid(int pageSize, int pageIndex, string search, string orderType, string orderBy)
        {
            int total;
            var membershipId = _authentication.MemberShipId;
            var list = _typesRespository.QueryTypesList(search, membershipId, out total,orderBy, orderType, pageIndex, pageSize);
            return Json(new { total = total, rows = list, Success = true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetTypesWithoutBudget(int year,int month)
        {
            var membershipId = _authentication.MemberShipId;
            var result = _typesRespository.QueryTypesWhickNoBudget(year, month,membershipId);
            return Json(new { Success = true, Count = result.Count, List = result });
        }
    }
}