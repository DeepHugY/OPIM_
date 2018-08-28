using OPIM_BLL.Respository;
using OPIM_Common.DataModels;
using OPIM_Common.Extensions;
using OPIM_EntityFramework.QueryService;
using System;
using System.Web.Mvc;

namespace OPIM.Controllers
{  // GET: Home
    [Authorize]
    public class RecordController : Controller
    {
        private readonly RecordRespository _recordRespository;
        private readonly TypesRespository _typesRespository;
        private readonly MemberShipsRespository _memberShipsRespository;
        private readonly Authentication _authentication;
        public RecordController()
        {
            this._recordRespository = new RecordRespository();
            this._typesRespository = new TypesRespository();
            this._memberShipsRespository = new MemberShipsRespository();
            this._authentication = new Authentication();
        }

        public ActionResult Index()
        {
            Guid memberShip = _authentication.MemberShipId;
            ViewBag.IsAdmin = _authentication.IsAdmin();
            var typeList = _typesRespository.QueryTypesListByCreateBy(memberShip);
            ViewBag.TypesList = typeList;
            return View();
        }
        public ActionResult Add(RecordsModel model)
        {
            model.Id = Guid.NewGuid();
            model.CreateOn = DateTime.Now.ToString("yyyy/MM/dd");
            model.CreateBy = _authentication.MemberShipId;                  //获得当前登录账户Id
            model.Source = "网站";
            var result = _recordRespository.CreateRecord(model);
            return Json(result);
        }

        public ActionResult Update(RecordsModel model)
        {
            var result = _recordRespository.UpdateRecord(model);
            return Json(result);
        }
        public ActionResult Delete(Guid Id)
        {
            var result = _recordRespository.RemoveRecord(Id);
            return Json(result);
        }
        public ActionResult _RecordsGrid(int pageSize, int pageIndex, string search, string date, string orderType, string orderBy)
        {
            int total;
            Guid memberShip = _authentication.MemberShipId;
            var list = _recordRespository.QueryRecordsListWithDate(search, date, memberShip, out total, orderBy, orderType, pageIndex, pageSize);
            return Json(new { total = total, rows = list, Success = true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddFromCsv(string path)
        {
            Guid memberShipId = _authentication.MemberShipId;

            var result = _recordRespository.CreateFromCsv(memberShipId, path);
            return Json(new { Success=true});
        }
    }
}