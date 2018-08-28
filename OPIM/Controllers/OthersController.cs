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
    public class OthersController : Controller
    {
        private readonly ShareRespository _shareRespository;
        private readonly MemberShipsRespository _memberShipsRespository;
        private readonly Authentication _authentication;
        private readonly AnnouncementRespository _announcementRespository;
        public OthersController()
        {
            this._shareRespository = new ShareRespository();
            this._authentication = new Authentication();
            this._memberShipsRespository = new MemberShipsRespository();
            this._announcementRespository = new AnnouncementRespository();
        }
        // GET: Others
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LockScreen()
        {
            return View(@"~/Views/Shared/lockScreen.cshtml");
        }

        public ActionResult GetShareDatas()
        {
            var memberShipId = _authentication.MemberShipId;
            var memberShip = _shareRespository.GetShareDates(memberShipId);
            var annList = _announcementRespository.QueryAll();
            return Json(new { MemberShip = memberShip, AnnList = annList, Success = true });
        }

        public ActionResult GetTypesWithRecordSum()
        {
            var memberShipId = _authentication.MemberShipId;
            var list = _shareRespository.GetRecordOfCurrentMonth(memberShipId);
            return Json(new { Success = true, List = list });
        }
    }
}