using OPIM_Common;
using OPIM_Common.DataModels;
using OPIM_Common.Service;
using OPIM_Dapper.Dappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPIM_BLL.Respository
{
    public class HomeRespository
    {
        private readonly MemberShipDapper _memberShipDapper;
        private readonly AuthenticationService _authenticationService;
        public HomeRespository()
        {
            this._memberShipDapper = new MemberShipDapper();
            this._authenticationService = new AuthenticationService();
        }
        public Results Register(string password, string rePassword, string vCode, string seesion, MemberShipsModel model)
        {
            if (StringHelper.IsNullOrEmptyOrWhiteSpace(model.Account) || StringHelper.IsNullOrEmptyOrWhiteSpace(password))
            {
                return new Results("帐号和密码不能为空");
            }
            if (password != rePassword)
            {
                return new Results("两次密码不一致");
            }
            if (vCode == null || seesion == null || seesion != vCode.ToLower())
            {
                return new Results("验证码有误");
            }
            model.Password = EncryptHelper.CreateHash(model.Password);
            return _memberShipDapper.Create(model);
        }
        public Results Login(string account, string password)
        {
            if (StringHelper.IsNullOrEmptyOrWhiteSpace(account) || StringHelper.IsNullOrEmptyOrWhiteSpace(password))
            {
                return new Results("帐号和密码不能为空");
            }
            var memberShip = _memberShipDapper.GetMemberShipByAccount(account);
            if (memberShip == null)
            {
                return new Results("不存在此帐号");
            }
            if (!EncryptHelper.ValidatePassword(password, memberShip.Password))
            {
                return new Results("密码错误");
            }
            _authenticationService.SignIn(memberShip.Id, memberShip.Account, memberShip.LimitLevel, false);
            return new Results();
        }
        public void LoginOff()
        {
            if (this._authenticationService != null)
                _authenticationService.SignOut();
        }
    }
}
