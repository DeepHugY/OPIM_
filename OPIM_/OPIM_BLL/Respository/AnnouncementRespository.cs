using OPIM_Common.DataModels;
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
    public class AnnouncementRespository
    {
        private readonly AnnouncementDapper _announcementDapper;
        private readonly AnnouncementQueryService _aunouncementQueryService;
        public AnnouncementRespository()
        {
            this._announcementDapper = new AnnouncementDapper();
            this._aunouncementQueryService = new AnnouncementQueryService();
        }
        public Results CreateAnnounment(AnnouncementsView model)
        {
            if (model.Title == null || model.Contents == null)
            {
                return new Results("标题和内容均不能为空");
            }
            return _announcementDapper.Create(model);
        }
        public Results UpdateAnnouncement(AnnouncementsView model)
        {
            if (model.Id == null || model.Id == Guid.Empty)
            {
                return new Results("Id不能为空");
            }
            if (model.Title == null || model.Title == "")
            {
                return new Results("标题不能为空");
            }
            if (model.Contents == null || model.Contents == "")
            {
                return new Results("内容不能为空");
            }
            return _announcementDapper.Update(model);
        }
        public Results RemoveAnnouncement(Guid id)
        {
            if (id == null || id == Guid.Empty)
            {
                return new Results("Id不能为空");
            }
           
            return _announcementDapper.Delete(id);
        }
        public List<AnnouncemrntsView> QueryAnnouncementList(string search, out int total, string orderBy, string orderType, int pageIndex, int pageSize)
        {
            var list = _aunouncementQueryService.Find(search, out total, orderBy, orderType, pageIndex, pageSize).ToList();
            return list;
        }
        public List<AnnouncemrntsView> QueryAll()
        {
            var list = _aunouncementQueryService.Find().ToList();
            return list;
        }
    }
}



