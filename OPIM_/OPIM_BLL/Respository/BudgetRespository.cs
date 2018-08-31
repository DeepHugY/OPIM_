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
    public class BudgetRespository
    {
        private readonly BudgetDapper _budgetDapper;
        private readonly BudgetQueryService _budgetQueryService;

        public BudgetRespository()
        {
            this._budgetDapper = new BudgetDapper();
            this._budgetQueryService = new BudgetQueryService();
        }
        public Results AddBudget(BudgetModel model)
        {
            if (model.TypeId == null || model.TypeId == Guid.Empty)
            {
                return new Results("类型不能为空");
            }
            if (model.Month == 0 || model.Year == 0)
            {
                return new Results("时间不能为空");
            }
            return _budgetDapper.Create(model);
        }
        public Results Update(Guid id,decimal money)
        {
            if (id == null || id == Guid.Empty)
            {
                return new Results("Id不能为空");
            }
            else
            {
              
                if (money == 0)
                {
                    return new Results();
                }
                else
                {
                    return _budgetDapper.Update(id,money);
                }
            }

        }
        public Results Remove(Guid id)
        {
            if (id == null || id == Guid.Empty)
            {
                return new Results("Id不能为空");
            }
            return _budgetDapper.Delete(id);
        }
        public List<BudgetWithTypeView> GetBudgetCompleteList(int year, int month, Guid memberShipId)
        {
            if (year == 0 || month == 0||memberShipId==Guid.Empty)
            {
                return null;
            }
            return _budgetQueryService.FindCompleteWithDate(year,month,memberShipId).ToList();
        }

    }
}
