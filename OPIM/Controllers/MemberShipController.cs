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
    public class MemberShipController : Controller
    {
        private readonly MemberShipsRespository _memberShipsRespository;
        private readonly ImageRespository _imageRespository;
        private readonly Authentication _authentication;
        // GET: ChangeInfo
        public MemberShipController()
        {
            this._memberShipsRespository = new MemberShipsRespository();
            this._imageRespository = new ImageRespository();
            this._authentication = new Authentication();
        }
        public ActionResult ChangeInformation()
        {
            Guid memberShipId = _authentication.MemberShipId;
            ViewBag.IsAdmin = _authentication.IsAdmin();
            var memberShip = _memberShipsRespository.GetSingleMemberShipById(memberShipId);
            ViewBag.MemberShip = memberShip;
            return View();
        }

        public ActionResult Manage()
        {
            ViewBag.IsAdmin = _authentication.IsAdmin();
            return View();
        }
        public ActionResult Delete(Guid id)
        {
            var result = _memberShipsRespository.RemoveMemberShip(id);
            return Json(result);
        }
        public ActionResult UpdateInformation(MemberShipsModel model)
        {
            var result = _memberShipsRespository.ChangeInfomation(model);
            return Json(result);
        }

        public ActionResult ChangePassword(string id, string password, string newPassword, string reNewPassword)
        {
            var result = _memberShipsRespository.ChangePassword(Guid.Parse(id), password, newPassword, reNewPassword);
            return Json(result);
        }

        public ActionResult UploadIcon()
        {
            var memberShipId = Request.Form["memberShipId"];
            var data = Request.Form["data"];
            var result = _imageRespository.UploadMemberShipIcon(Guid.Parse(memberShipId), data);
            return Json(new Results());
        }

        public ActionResult _MemberShipsGrid(int pageSize, int pageIndex, string search, string orderType, string orderBy)
        {
            int total;
            var list = _memberShipsRespository.QueryMemberShipsList(search, out total, orderBy, orderType, pageIndex, pageSize);
            return Json(new { total = total, rows = list, Success = true }, JsonRequestBehavior.AllowGet);
        }
    }
}