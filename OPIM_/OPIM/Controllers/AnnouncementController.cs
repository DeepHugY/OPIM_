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
    public class AnnouncementController : Controller
    {
        // GET: Announcement
        private readonly AnnouncementRespository _announcementRespository;
        private readonly MemberShipsRespository _memberShipsRespository;
        private readonly Authentication _authentication;
        public AnnouncementController()
        {
            this._announcementRespository = new AnnouncementRespository();
            this._memberShipsRespository = new MemberShipsRespository();
            this._authentication = new Authentication();
        }
        public ActionResult Index()
        {
            ViewBag.IsAdmin = _authentication.IsAdmin();
            return View();
        }
        public ActionResult Add(AnnouncementsView model)
        {
            model.CreateOn = DateTime.Now;
            model.CreateBy = _authentication.MemberShipId;
            model.Id = Guid.NewGuid();
            var result = _announcementRespository.CreateAnnounment(model);
            return Json(result);
        }
        public ActionResult Delete(Guid id)
        {
            var result = _announcementRespository.RemoveAnnouncement(id);
            return Json(result);
        }
        public ActionResult Update(AnnouncementsView model)
        {
            var result = _announcementRespository.UpdateAnnouncement(model);
            return Json(result);
        }

        public ActionResult _AnnouncementGrid(int pageSize, int pageIndex, string search, string orderType, string orderBy)
        {
            int total;
            var list = _announcementRespository.QueryAnnouncementList(search, out total, orderBy, orderType, pageIndex, pageSize);
            return Json(new { total = total, rows = list, Success = true }, JsonRequestBehavior.AllowGet);
        }
    }
}