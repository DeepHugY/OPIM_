using OPIM_Common;
using OPIM_Common.DataModels;
using OPIM_Dapper.Dappers;
using OPIM_EntityFramework.QueryService;
using OPIM_EntityFramework.Views;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OPIM_BLL.Respository
{
    public class TypesRespository
    {
        private readonly TypesDapper _typesDapper;
        private readonly TypesQueryService _typesQueryService;
        private readonly BudgetQueryService _budgetQueryService;
        public TypesRespository()
        {
            this._typesDapper = new TypesDapper();
            this._typesQueryService = new TypesQueryService();
            this._budgetQueryService = new BudgetQueryService();
        }

        public Results CreateType(Guid id, string name, int inOrOut, DateTime createOn, Guid createBy, string remark)
        {
            if (StringHelper.IsNullOrEmptyOrWhiteSpace(name))
            {
                return new Results("类型名不能为空");
            }
            TypesModel model = new TypesModel();
            model.Id = id;
            model.Name = name;
            model.InOrOut = inOrOut;
            model.CreateOn = createOn;
            model.CreateBy = createBy;
            model.Remark = remark;

            return _typesDapper.Create(model);
        }

        public Results RemoveType(Guid id)
        {
            if (id == null || id == Guid.Empty)
            {
                return new Results("Id不能为空");
            }
            return _typesDapper.Delete(id);
        }

        public Results UpdateType(TypesModel model)
        {
            if (model.Id == null || model.Id == Guid.Empty)
            {
                return new Results("Id不能为空");
            }
            if (model.Name == null)
            {
                return new Results("名称不能为空");
            }
            return _typesDapper.Update(model);
        }

        public List<TypesView> QueryTypesList(string search, Guid memberShipId,out int total, string orderBy, string orderType, int pageIndex, int pageSize)
        {
            var list = _typesQueryService.Find(search,memberShipId, out total, orderBy, orderType, pageIndex, pageSize).ToList();
            return list;
        }

        public List<TypesView> QueryTypesListByCreateBy(Guid memberShipId)
        {
            var list = _typesQueryService.Find(memberShipId).ToList();
            return list;
        }
        public TypesView QueryTypeByName(string name)
        {
            if (name == "" || name == null)
            {
                return null;
            }
            return _typesQueryService.Find(name);
        }

        public List<TypesView> QueryTypesWhickNoBudget(int year, int month,Guid memberShipId)
        {
            var list = _typesQueryService.Find(memberShipId).ToList();
            var budgetList = _budgetQueryService.FindWithDate(year, month,memberShipId);
            for (int i = 0; i < list.Count; i++)
            {
                var budget = budgetList.Where(p => p.TypeId == list[i].Id).ToList();
                if (budget.Count!=0)
                {
                    list.Remove(list[i]);
                }
            }
            return list;
        }
    }
}
