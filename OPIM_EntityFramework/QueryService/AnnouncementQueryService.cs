using OPIM_Common.DataModels;
using OPIM_EntityFramework.IQueryService;
using OPIM_EntityFramework.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OPIM_EntityFramework.QueryService
{
    public class AnnouncementQueryService
    {
        public IEnumerable<AnnouncemrntsView> Find(string value, out int total, string orderBy, string orderType, int index, int size)
        {
            using (IRepository<AnnouncemrntsView> respository = new Repository<AnnouncemrntsView>(new DBContext()))
            {
                Expression<Func<AnnouncemrntsView, bool>> search = null;
                search = p => p.Title.Contains(value) || p.Contents.Contains(value);
                var list = respository.Filter(search, out total, orderBy, orderType, index, size).ToList();
                return list;
            }
        }
        public IEnumerable<AnnouncemrntsView> Find()
        {
            using (IRepository<AnnouncemrntsView> respository = new Repository<AnnouncemrntsView>(new DBContext()))
            {
                var list = respository.Filter().ToList();
                return list;
            }
        }
    }
}
