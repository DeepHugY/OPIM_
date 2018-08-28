using OPIM_BLL.Respository;
using OPIM_Common;
using OPIM_Common.DataModels;
using OPIM_Common.Enums;
using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Web.Mvc;
using static OPIM.Models.HomeModel;

namespace OPIM.Controllers
{
    public class HomeController : Controller
    {
        private readonly HomeRespository _homeRespository;

        public HomeController()
        {
            this._homeRespository = new HomeRespository();
        }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel registModel, CancellationToken token)
        {
            var memberShipModel = new MemberShipsModel();
            memberShipModel.Id = Guid.NewGuid();
            memberShipModel.Account = registModel.Account;
            memberShipModel.Password = registModel.Password;
            memberShipModel.NickName = registModel.NickName;
            memberShipModel.Phone = registModel.Phone;
            memberShipModel.Email = registModel.Email;
            memberShipModel.CreateOn = DateTime.Now;
            memberShipModel.BirthOn = DateTime.Now;
            memberShipModel.LimitLevel = (int)Permission.User;
            var session = Session["ValidateCode"].ToString().ToLower();
            var result = _homeRespository.Register(registModel.Password, registModel.ConfirmPassword, registModel.VerificationCode,session, memberShipModel);
            return Json(result);
        }
        public ActionResult Login(LoginModel model)
        {
            var result = _homeRespository.Login(model.AccountLogin, model.PasswordLogin);
            return Json(result);
        }
        public ActionResult LoginOff()
        {
            _homeRespository.LoginOff();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult GenerateCode()
        {
            DrawValidationCode code = new DrawValidationCode();
            using (MemoryStream ms = new MemoryStream())
            {
                code.CreateImage(ms);
                Image img = Image.FromStream(ms);
                var s = code.ValidationCode;
                Session["ValidateCode"] = s;
                byte[] bytes = new byte[ms.Length];
                ms.Seek(0, SeekOrigin.Begin);
                ms.Read(bytes, 0, bytes.Length);
                return File(bytes, @"image/jpeg");
            }
        }
    }
}