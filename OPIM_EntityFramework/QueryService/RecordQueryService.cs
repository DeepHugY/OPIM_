using OPIM_Common.Enums;
using OPIM_EntityFramework.IQueryService;
using OPIM_EntityFramework.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace OPIM_EntityFramework.QueryService
{
    public class RecordQueryService
    {
        /// <summary>
        /// 根据查询条件和金额、类型名称、备注匹配
        /// </summary>
        /// <param name="value"></param>
        /// <param name="total"></param>
        /// <param name="orderBy"></param>
        /// <param name="orderType"></param>
        /// <param name="index"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public IEnumerable<RecordView> FindWithDate(string value, string date, Guid memberShipId, out int total, string orderBy, string orderType, int index, int size)
        {
            using (IRepository<RecordView> respository = new Repository<RecordView>(new DBContext()))
            {
                Expression<Func<RecordView, bool>> search = null;
                search = p => p.CreateBy == memberShipId && (p.Remark.Contains(value) || p.Money.ToString().Contains(value) || p.TypesName.Contains(value)) && p.CreateOn.Contains(date);
                return respository.Filter(search, out total, orderBy, orderType, index, size).ToList();
            }
        }
        public IEnumerable<RecordView> FindWithDateAndInOrOut(string value, string date, int inOrOut, Guid memberShipId, out int total, string orderBy, string orderType, int index, int size)
        {
            using (IRepository<RecordView> respository = new Repository<RecordView>(new DBContext()))
            {
                Expression<Func<RecordView, bool>> search = null;
                search = p => p.CreateBy == memberShipId && (p.Remark.Contains(value) || p.Money.ToString().Contains(value) || p.TypesName.Contains(value)) && p.CreateOn.Contains(date) && p.InOrOut == inOrOut;
                return respository.Filter(search, out total, orderBy, orderType, index, size).ToList();
            }
        }
        public IEnumerable<RecordView> Find(Guid memberShipId)
        {
            using (IRepository<RecordView> respository = new Repository<RecordView>(new DBContext()))
            {
                Expression<Func<RecordView, bool>> search = null;
                search = p => p.CreateBy == memberShipId;
                var filter = respository.Filter(search).ToList();


                return filter;
            }
        }

        public IEnumerable<RecordView> Find(Guid memberShipId,string date, int state)
        {
            using (IRepository<RecordView> respository = new Repository<RecordView>(new DBContext()))
            {
                Expression<Func<RecordView, bool>> search = null;
                search = p => p.CreateBy == memberShipId && p.InOrOut == state&&p.CreateOn.Contains(date);
                var filter = respository.Filter(search).ToList();
                return filter;
            }
        }
        public IEnumerable<RecordView> Find(Guid memberShipId, string date)
        {
            using (IRepository<RecordView> respository = new Repository<RecordView>(new DBContext()))
            {
                Expression<Func<RecordView, bool>> search = null;
                search = p => p.CreateBy == memberShipId && p.CreateOn.Contains(date);
                var filter = respository.Filter(search).ToList();
                return filter;
            }
        }
    }
}
