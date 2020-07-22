using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YY.EF.Core.Interface;
using YY.EF.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace YY.EF.Core.Service
{
    public class BaseService : IBaseService
    {
        protected DbContext Context { get; private set; }

        public BaseService(DbContext context)
        {
            this.Context = context;
           // this.Context.Database.Log += c => Console.WriteLine($"{c}");
        }

        #region Others
        public virtual void Dispose()
        {
            if (this.Context != null)
            {
                this.Context.Dispose();
            }
        }
        public void Commit()
        {
                this.Context.SaveChanges();
        }

        public void Excute<T>(string sql, SqlParameter[] parameters) where T : class
        {
            IDbContextTransaction trans = null;
            try
            {
                trans = this.Context.Database.BeginTransaction();
                this.Context.Database.ExecuteSqlRaw(sql, parameters);
                //this.Context.Database.ExecuteSqlCommand(sql, parameters);
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null)
                    trans.Rollback();
                throw ex;
            }
        }

        public IQueryable<T> ExcuteQuery<T>(string sql, SqlParameter[] parameters) where T : class
        {
            //return this.Context.Database.SqlQuery<T>(sql, parameters).AsQueryable();
            return this.Context.Set<T>().FromSqlRaw<T>(sql, parameters);
        }
        #endregion

        #region Delete
        public void Delete<T>(T t) where T : class
        {
            if (t == null) throw new Exception("t is null");
            this.Context.Set<T>().Attach(t);
            this.Context.Set<T>().Remove(t);
            this.Commit();
        }

        public void Delete<T>(int id) where T : class
        {
            T t = this.Find<T>(id);
            if (t == null) throw new Exception("t is null");
            this.Context.Set<T>().Remove(t);
            this.Commit();
        }

        public void Delete<T>(IEnumerable<T> tList) where T : class
        {
            if (tList == null) throw new Exception("tList is null");
            foreach (var t in tList)
            {
                this.Context.Set<T>().Attach(t);
               //this.Context.Set<T>().Remove(t);
            }
            this.Context.Set<T>().RemoveRange(tList);
            this.Commit();
        }
        #endregion

        #region Add
        public T Insert<T>(T t) where T : class
        {
                this.Context.Set<T>().Add(t);
                this.Commit();
                return t;
        }

        public IEnumerable<T> Insert<T>(IEnumerable<T> tList) where T : class
        {
            this.Context.Set<T>().AddRange(tList);
            this.Commit();
            return tList;
        }
        #endregion

        #region Query
        public T Find<T>(int id) where T : class
        {
                return this.Context.Set<T>().Find(id);
        }
        public IQueryable<T> Query<T>(Expression<Func<T, bool>> expression) where T : class
        {
                var query = this.Context.Set<T>().Where(expression);
                return query;
        }

        public PageResult<T> QueryPage<T, S>(Expression<Func<T, bool>> funcWhere, int pageSize, int pageIndex, Expression<Func<T, S>> funcOrderby, bool isAsc = true) where T : class
        {
            var list = this.Set<T>();
            if (funcWhere!=null)
            {
                list = list.Where(funcWhere);
            }

            list = isAsc == true ? list.OrderBy(funcOrderby) : list.OrderByDescending(funcOrderby);

            PageResult<T> pageResult = new PageResult<T>()
            {
                TotalCount = list.Count(),//this.Context.Set<T>().Count(funcWhere),
                PageSize = pageSize,
                PageIndex = pageIndex,
                DataList = list.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList(),
            };
            return pageResult;   
        }

        public IQueryable<T> Set<T>() where T : class
        {
            return this.Context.Set<T>();
        }
        #endregion

        #region Update
        /// <summary>
        /// 是没有实现查询，直接更新的,需要Attach和State
        /// 
        /// 如果是已经在context，只能再封装一个(在具体的service)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        public T Update<T>(T t) where T : class
        {
            if (t == null) throw new Exception("t is null");
            this.Context.Set<T>().Attach(t);// 把数据添加到上下文，支持实体修改和新实体
            this.Context.Entry<T>(t).State = EntityState.Modified;
            this.Commit();
            return t;
        }

        public IEnumerable<T> Update<T>(IEnumerable<T> tList) where T : class
        {
            if (tList == null) throw new Exception("tList is null");
            foreach (var t in tList)
            {
                this.Context.Set<T>().Attach(t);// 把数据添加到上下文，支持实体修改和新实体
                this.Context.Entry<T>(t).State = EntityState.Modified;
            }
            this.Commit();
            return tList;
        }
        #endregion
    }
}
