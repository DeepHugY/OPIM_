using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using OPIM_EntityFramework.IQueryService;
using OPIM_Common;

namespace OPIM_EntityFramework.QueryService
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DBContext _dbContext;
        private string _orderBy = "CreateOn";
        private string _orderType = "desc";


        protected DbSet<T> DbSets
        {
            get { return this._dbContext.Set<T>(); }
        }

        public Repository(DBContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public DbSet<T1> GetOtherDbSets<T1>() where T1 : class
        {
            return this._dbContext.Set<T1>();
        }


        public T FirstOrDefault(Expression<Func<T, bool>> expression)
        {
            return this.DbSets.AsQueryable().Where(expression).FirstOrDefault();
        }

        public T FirstOrDefault(Expression<Func<T, bool>> expression, string orderBy, string orderType)
        {
            this.ConfigOrder(orderBy, orderType);
            return this.DbSets.AsQueryable().OrderBy(this._orderBy, this._orderType).Where(expression).FirstOrDefault();
        }


        #region Filter

        public virtual IQueryable<T> Filter()
        {
            return this.DbSets.AsQueryable<T>();
        }

        public virtual IQueryable<T> Filter(Expression<Func<T, bool>> predicate)
        {
            return this.DbSets.Where<T>(predicate).AsQueryable<T>();
        }

        public virtual IQueryable<T> Filter(string filter, params object[] values)
        {
            return this.DbSets.Where<T>(filter, values).AsQueryable<T>();
        }

        public virtual IQueryable<T> Filter(Expression<Func<T, bool>> predicate, out int total, int index = 1,
                                               int size = 50)
        {
            index = index - 1;
            var skipCount = index * size;
            var resetSet = predicate != null
                                ? this.DbSets.Where<T>(predicate).AsQueryable()
                                : this.DbSets.AsQueryable();
            total = resetSet.Count();
            resetSet = skipCount == 0 ? resetSet.Take(size) : resetSet.Skip(skipCount).Take(size);
            return resetSet.AsQueryable();
        }

        public virtual IQueryable<T> Filter(string filter, out int total, int index = 1,
                                              int size = 50, params object[] values)
        {
            index = index - 1;
            var skipCount = index * size;
            var resetSet = !StringHelper.IsNullOrEmptyOrWhiteSpace(filter)
                                ? this.DbSets.Where<T>(filter, values).AsQueryable()
                                : this.DbSets.AsQueryable();
            total = resetSet.Count();
            resetSet = skipCount == 0 ? resetSet.Take(size) : resetSet.Skip(skipCount).Take(size);
            return resetSet.AsQueryable();
        }

        public virtual IQueryable<T> Filter(Expression<Func<T, bool>> predicate, out int total, string orderBy, string orderType,
                                               int index = 1, int size = 50)
        {
            index = index - 1;
            this.ConfigOrder(orderBy, orderType);
            var skipCount = index * size;
            var resetSet = predicate != null
                                ? this.DbSets.Where<T>(predicate).AsQueryable().OrderBy(this._orderBy, this._orderType)
                                : this.DbSets.AsQueryable().OrderBy(this._orderBy, this._orderType);
            total = resetSet.Count();
            resetSet = skipCount == 0 ? resetSet.Take(size) : resetSet.Skip(skipCount).Take(size);
            return resetSet.AsQueryable();
        }

        public virtual IQueryable<T> Filter(string filter, out int total, string orderBy, string orderType,
                                               int index = 1, int size = 50, params object[] values)
        {
            index = index - 1;
            this.ConfigOrder(orderBy, orderType);
            var skipCount = index * size;
            var resetSet = !StringHelper.IsNullOrEmptyOrWhiteSpace(filter)
                                ? this.DbSets.Where<T>(filter, values).AsQueryable().OrderBy(this._orderBy, this._orderType)
                                : this.DbSets.AsQueryable().OrderBy(this._orderBy, this._orderType);
            total = resetSet.Count();
            resetSet = skipCount == 0 ? resetSet.Take(size) : resetSet.Skip(skipCount).Take(size);
            return resetSet.AsQueryable();
        }

        #endregion

        #region SelectAndFilter

        public virtual IEnumerable<TR> SelectAndFilter<TR>(Func<T, TR> selecter) where TR : class
        {
            return this.Filter().AsEnumerable().Select<T, TR>(selecter);
        }

        public virtual IEnumerable<TR> SelectAndFilter<TR>(Expression<Func<T, bool>> predicate, Func<T, TR> selecter) where TR : class
        {
            return this.Filter(predicate).AsEnumerable().Select<T, TR>(selecter);
        }

        public virtual IEnumerable<TR> SelectAndFilter<TR>(string filter, Func<T, TR> selecter, params object[] values) where TR : class
        {
            return this.Filter(filter, values).AsEnumerable().Select<T, TR>(selecter);
        }

        public virtual IEnumerable<TR> SelectAndFilter<TR>(Expression<Func<T, bool>> predicate, Func<T, TR> selecter, out int total, int index = 1,
                                               int size = 50) where TR : class
        {
            return this.Filter(predicate, out total, index, size).AsEnumerable().Select<T, TR>(selecter);
        }

        public virtual IEnumerable<TR> SelectAndFilter<TR>(string filter, Func<T, TR> selecter, out int total, int index = 1,
                                               int size = 50, params object[] values) where TR : class
        {
            return this.Filter(filter, out total, index, size, values).AsEnumerable().Select<T, TR>(selecter);
        }

        public virtual IEnumerable<TR> SelectAndFilter<TR>(Expression<Func<T, bool>> predicate, Func<T, TR> selecter, out int total,
                                                             string orderBy, string orderType, int index = 1, int size = 50) where TR : class
        {
            return this.Filter(predicate, out total, orderBy, orderType, index, size).AsEnumerable().Select<T, TR>(selecter);
        }

        public virtual IEnumerable<TR> SelectAndFilter<TR>(string filter, Func<T, TR> selecter, out int total,
                                                            string orderBy, string orderType, int index = 1, int size = 50, params object[] values) where TR : class
        {
            return this.Filter(filter, out total, orderBy, orderType, index, size, values).AsEnumerable().Select<T, TR>(selecter);
        }

        #endregion SelectAndFilter


        //public virtual void Add(T entity)
        //{
        //    this.Entities.Add(entity);
        //}

        //public virtual void Add<T1>(T1 entity) where T1 : class
        //{
        //    try
        //    {
        //        this._dbContext.Set<T1>().Add(entity);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public virtual void Add<T1>(T entity, T1 otherEntity) where T1 : class
        //{
        //    this.Entities.Add(entity);
        //    this._dbContext.Set<T1>().Add(otherEntity);
        //}

        //public virtual void Add(IEnumerable<T> entity)
        //{
        //    this.Entities.AddRange(entity);
        //}

        //public void Update(T entity)
        //{
        //    try
        //    {
        //        this.Entities.Attach(entity);
        //        this._dbContext.Entry<T>(entity).State = EntityState.Modified;
        //    }
        //    catch (OptimisticConcurrencyException ex)
        //    {
        //        throw ex;
        //    }

        //}


        //public void Delete(T entity)
        //{
        //    this.Entities.Remove(entity);
        //}
        //public void Delete(IEnumerable<T> entity)
        //{
        //    this.Entities.RemoveRange(entity);
        //}
        //public void Delete<T1>(T1 entity) where T1 : class
        //{
        //    DbSet<T1> dbSet = this._dbContext.Set<T1>();
        //    dbSet.Remove(entity);
        //}

        public int ExcuteSql(string sql, params object[] parameters)
        {
            return this._dbContext.Database.ExecuteSqlCommand(sql, parameters);
        }

        public void Dispose()
        {
            if (this._dbContext != null)
            {
                this._dbContext.Dispose();
            }
        }


        private void ConfigOrder(string orderBy, string orderType)
        {
            if (!StringHelper.IsNullOrEmptyOrWhiteSpace(orderBy))
                this._orderType = orderType;
            if (!StringHelper.IsNullOrEmptyOrWhiteSpace(orderType))
                this._orderBy = orderBy;
        }
        public IEnumerable<string> ExcuteFuzzySql(string sql)
        {
            return this._dbContext.Database.SqlQuery<string>(sql).ToList();
        }
    }
}
