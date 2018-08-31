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
    public class TypesQueryService
    {
        public IEnumerable<TypesView> Find(string value, Guid memberShipId, out int total, string orderBy, string orderType, int index, int size)
        {
            using (IRepository<TypesView> respository = new Repository<TypesView>(new DBContext()))
            {
                Expression<Func<TypesView, bool>> search = null;
                search = p => (p.Remark.Contains(value) || p.Name.Contains(value)) && p.CreateBy == memberShipId;
                return respository.Filter(search, out total, orderBy, orderType, index, size).ToList();
            }
        }
        public IEnumerable<TypesView> Find(Guid memberShipId)
        {
            using (IRepository<TypesView> respository = new Repository<TypesView>(new DBContext()))
            {
                Expression<Func<TypesView, bool>> search = null;
                search = p => p.CreateBy == memberShipId;
                return respository.Filter(search).ToList();
            }
        }
        public TypesView Find(string name)
        {
            using (IRepository<TypesView> respository = new Repository<TypesView>(new DBContext()))
            {
                return respository.FirstOrDefault(p => p.Name == name);
            }
        }
    }
}
