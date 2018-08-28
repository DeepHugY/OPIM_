using OPIM_BLL.Respository;
using OPIM_Common.Extensions;
using OPIM_EntityFramework.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OPIM.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {
        private readonly MemberShipsRespository _memberShipsRespository;
        private readonly ReportRespository _reportRespository;
        private readonly Authentication _authentication;
        private readonly TypesRespository _typesRespository;
        private readonly RecordRespository _recordRespository;
        // GET: Report
        public ReportController()
        {
            this._reportRespository = new ReportRespository();
            this._memberShipsRespository = new MemberShipsRespository();
            this._authentication = new Authentication();
            this._typesRespository = new TypesRespository();
            this._recordRespository = new RecordRespository();
        }
        public ActionResult Index()
        {
            ViewBag.IsAdmin = _authentication.IsAdmin();
            Guid memberShip = _authentication.MemberShipId;
            return View();
        }

        public ActionResult _RecordsOfReportGrid(int pageSize, int pageIndex, string search,string date,int inOrOut, string orderType, string orderBy)
        {
            int total;
            Guid memberShip = _authentication.MemberShipId;
            var list = _recordRespository.QueryRecordsList(search,date,inOrOut, memberShip,out total, orderBy, orderType, pageIndex, pageSize);
            return Json(new { total = total, rows = list, Success = true }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAnnulInRecords(int pageSize, int pageIndex, string search, string orderType, string orderBy)
        {
            Guid memberShip = _authentication.MemberShipId;
            var list = _reportRespository.QueryAnnulRecordView(memberShip, int.Parse(search));
            List<AnnulRecordView> inList = new List<AnnulRecordView>();
            foreach (var item in list)
            {
                var type = _typesRespository.QueryTypeByName(item.TypeName);
                if (type.InOrOut == 0)
                {
                    inList.Add(item);
                }
            }
            inList.Add(_reportRespository.GetTotal(inList));
            return Json(new { total = inList.Count, rows = inList, Success = true }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAnnulOutRecords(int pageSize, int pageIndex, string search, string orderType, string orderBy)
        {

            Guid memberShip = _authentication.MemberShipId;
            var list = _reportRespository.QueryAnnulRecordView(memberShip, int.Parse(search));
            List<AnnulRecordView> outList = new List<AnnulRecordView>();
            foreach (var item in list)
            {
                var type = _typesRespository.QueryTypeByName(item.TypeName);
                if (type.InOrOut == 1)
                {
                    outList.Add(item);
                }
            }
            outList.Add(_reportRespository.GetTotal(outList));
            return Json(new { total = outList.Count, rows = outList, Success = true }, JsonRequestBehavior.AllowGet);
        }
    }
}