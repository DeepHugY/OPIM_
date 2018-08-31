using OPIM_Common;
using OPIM_Common.DataModels;
using OPIM_Common.Enums;
using OPIM_Dapper.Dappers;
using OPIM_EntityFramework.QueryService;
using OPIM_EntityFramework.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPIM_BLL.Respository
{
    public class MemberShipsRespository
    {
        private readonly MemberShipDapper _memberShipDapper;
        private readonly MemberShipsQueryService _memberShipsQueryService;
        public MemberShipsRespository()
        {
            this._memberShipDapper = new MemberShipDapper();
            this._memberShipsQueryService = new MemberShipsQueryService();
        }

        public Results RemoveMemberShip(Guid id)
        {
            if (id == null || id == Guid.Empty)
            {
                return null;
            }
            return _memberShipDapper.Delete(id);
        }
        public Results ChangeInfomation(MemberShipsModel model)
        {
            if (model.Id == null || model.Id == Guid.Empty)
            {
                return new Results("Id不能为空");
            }
            return _memberShipDapper.Update(model);
        }
        public Results ChangePassword(Guid id, string password, string newPassword, string reNewPassword)
        {
            var memberShip = _memberShipDapper.GetMemberShipById(id);
            if (memberShip == null)
            {
                return new Results("为检测到用户");
            }

            if (!EncryptHelper.ValidatePassword(password, memberShip.Password))
            {
                return new Results("原密码输入错误");
            }
            if (newPassword != reNewPassword)
            {
                return new Results("两次新密码输入不一致");
            }
            newPassword = EncryptHelper.CreateHash(newPassword);
            return _memberShipDapper.UpdatePassword(id, newPassword);
        }

        public MemberShipsModel GetSingleMemberShipById(Guid id)
        {
            if (id == null || id == Guid.Empty)
            {
                return null;
            }
            var memberShip = _memberShipDapper.GetMemberShipById(id);
            memberShip.Icon = PathHelper.GetRelativePath(memberShip.Icon);
            return memberShip;
        }

        public List<MemberShipsView> QueryMemberShipsList(string search, out int total, string orderBy, string orderType, int pageIndex, int pageSize)
        {
            var list = _memberShipsQueryService.Find(search, out total, orderBy, orderType, pageIndex, pageSize).ToList();
            return list;
        }
    }
}
