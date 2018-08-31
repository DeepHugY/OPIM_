using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace OPIM_EntityFramework.IQueryService
{
    public interface IRepository<T> : IDisposable
      where T : class
    {
        //void Add(System.Collections.Generic.IEnumerable<T> entity);
        //void Add(T entity);
        //void Add<T1>(T entity, T1 otherEntity) where T1 : class;
        //void Add<T1>(T1 entity) where T1 : class;
        //void Delete(System.Collections.Generic.IEnumerable<T> entity);
        //void Delete(T entity);
        //void Delete<T1>(T1 entity) where T1 : class;
        DbSet<T1> GetOtherDbSets<T1>() where T1 : class;
        int ExcuteSql(string sql, params object[] parameters);
        System.Linq.IQueryable<T> Filter();
        System.Linq.IQueryable<T> Filter(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
        System.Linq.IQueryable<T> Filter(System.Linq.Expressions.Expression<Func<T, bool>> predicate, out int total, int index = 0, int size = 50);
        System.Linq.IQueryable<T> Filter(System.Linq.Expressions.Expression<Func<T, bool>> predicate, out int total, string orderBy, string orderType, int index = 0, int size = 50);
        System.Linq.IQueryable<T> Filter(string filter, out int total, int index = 0, int size = 50, params object[] values);
        System.Linq.IQueryable<T> Filter(string filter, out int total, string orderBy, string orderType, int index = 0, int size = 50, params object[] values);
        System.Linq.IQueryable<T> Filter(string filter, params object[] values);
        T FirstOrDefault(System.Linq.Expressions.Expression<Func<T, bool>> expression);
        T FirstOrDefault(System.Linq.Expressions.Expression<Func<T, bool>> expression, string orderBy, string orderType);
        IEnumerable<TR> SelectAndFilter<TR>(Func<T, TR> selecter) where TR : class;
        IEnumerable<TR> SelectAndFilter<TR>(System.Linq.Expressions.Expression<Func<T, bool>> predicate, Func<T, TR> selecter) where TR : class;
        IEnumerable<TR> SelectAndFilter<TR>(System.Linq.Expressions.Expression<Func<T, bool>> predicate, Func<T, TR> selecter, out int total, int index = 0, int size = 50) where TR : class;
        IEnumerable<TR> SelectAndFilter<TR>(System.Linq.Expressions.Expression<Func<T, bool>> predicate, Func<T, TR> selecter, out int total, string orderBy, string orderType, int index = 0, int size = 50) where TR : class;
        IEnumerable<TR> SelectAndFilter<TR>(string filter, Func<T, TR> selecter, out int total, int index = 0, int size = 50, params object[] values) where TR : class;
        IEnumerable<TR> SelectAndFilter<TR>(string filter, Func<T, TR> selecter, out int total, string orderBy, string orderType, int index = 0, int size = 50, params object[] values) where TR : class;
        IEnumerable<TR> SelectAndFilter<TR>(string filter, Func<T, TR> selecter, params object[] values) where TR : class;
        //void Update(T entity);
        IEnumerable<string> ExcuteFuzzySql(string sql);
    }
}
