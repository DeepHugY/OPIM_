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
   public class BudgetQueryService
    {
        public IEnumerable<BudgetView> FindWithDate(int year,int month,Guid memberShipId)
        {
            using (IRepository<BudgetView> respository=new Repository<BudgetView>(new DBContext()))
            {
                try
                {
                    Expression<Func<BudgetView, bool>> search = null;
                    search = p =>p.Year==year&&p.Month==month&&p.CreateBy==memberShipId;
                    var list = respository.Filter(search).ToList();
                    return list;
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }

        public IEnumerable<BudgetWithTypeView> FindCompleteWithDate(int year, int month, Guid memberShipId)
        {
            using (IRepository<BudgetWithTypeView> respository = new Repository<BudgetWithTypeView>(new DBContext()))
            {
                try
                {
                    Expression<Func<BudgetWithTypeView, bool>> search = null;
                    search = p => p.Year == year && p.Month == month&&p.CreateBy==memberShipId;
                    var list = respository.Filter(search).ToList();
                    return list;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }
}
