using OPIM_Common.DataModels;
using OPIM_EntityFramework.QueryService;
using OPIM_EntityFramework.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPIM_BLL.Respository
{
    public class ShareRespository
    {
        private readonly MemberShipsQueryService _memberShipsQueryService;
        private readonly AnnouncementQueryService _announcementQueryService;
        public readonly RecordQueryService _recordQueryService;
        public ShareRespository()
        {
            this._memberShipsQueryService = new MemberShipsQueryService();
            this._announcementQueryService = new AnnouncementQueryService();
            this._recordQueryService = new RecordQueryService();
        }
        public ShareModel GetShareDates(Guid memberShipId)
        {
            ShareModel shareModel = new ShareModel();
            var memberShip = _memberShipsQueryService.Find(memberShipId);
            shareModel.NickName = memberShip.NickName;
            shareModel.Icon = memberShip.Icon;
            DateTime now = DateTime.Now;
            TimeSpan days = now - memberShip.CreateOn;
            shareModel.OPIMAge = days.Days;
            var time = DateTime.Now.ToString("yyyy/MM/dd").Substring(0, 7);
            shareModel.CurrMonthIn = _recordQueryService.Find(memberShipId, time, 0).Sum(p => p.Money);
            shareModel.CurrMonthOut = _recordQueryService.Find(memberShipId, time, 1).Sum(p => p.Money);
            return shareModel;
        }

        public List<TypesWithRecordSumModel> GetRecordOfCurrentMonth(Guid memberShipId)
        {
            var data = DateTime.Now.ToString("yyyy/MM/dd").Substring(0, 7);
            var recordList = _recordQueryService.Find(memberShipId, data).ToList();
            var types = recordList.GroupBy(p => p.TypesName).ToList();
            List<TypesWithRecordSumModel> typesWithRecordSumModelList = new List<TypesWithRecordSumModel>();
            for (int i = 0; i < types.Count; i++)
            {
                TypesWithRecordSumModel typesWithRecordSumModel = new TypesWithRecordSumModel();
                typesWithRecordSumModel.Type = types[i].Key;
                typesWithRecordSumModel.Sum = recordList.Where(p => p.TypesName == types[i].Key).ToList().Sum(p => p.Money);
                typesWithRecordSumModelList.Add(typesWithRecordSumModel);
            }
            return typesWithRecordSumModelList;
        }
    }
}
