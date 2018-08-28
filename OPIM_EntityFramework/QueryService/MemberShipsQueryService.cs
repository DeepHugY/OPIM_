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
    public class MemberShipsQueryService
    {
        public MemberShipsView Find(Guid id)
        {
            using (IRepository<MemberShipsView> respository = new Repository<MemberShipsView>(new DBContext()))
            {
                try
                {
                    return respository.FirstOrDefault(p => p.Id == id);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public IEnumerable<MemberShipsView> Find(string value, out int total, string orderBy, string orderType, int index, int size)
        {
            using (IRepository<MemberShipsView> respository = new Repository<MemberShipsView>(new DBContext()))
            {
                Expression<Func<MemberShipsView, bool>> search = null;
                search = p => p.Account.Contains(value) || p.NickName.Contains(value);
                var list= respository.Filter(search, out total, orderBy, orderType, index, size).ToList();
                return list;
            }
        }
    }
}
