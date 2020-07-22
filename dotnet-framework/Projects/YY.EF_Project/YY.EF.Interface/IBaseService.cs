using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using YY.EF.Model;
using System.Data.SqlClient;

namespace YY.EF.Interface
{
    public interface IBaseService:IDisposable//为了释放context
    {
        #region Query
        /// <summary>
        /// 根据主键id查询
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="id">主键id</param>
        /// <returns></returns>
        T Find<T>(int id) where T:class;

        /// <summary>
        /// 单表的查询
        /// </summary>
        /// <returns>返回IQueryable类型的集合</returns>
        [Obsolete("不建议使用，应为此方法会把整张表暴露在外面，建议用using 表达式目录树")]
        IQueryable<T>Set<T>() where T : class;

        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <returns>返回IQueryable类型的集合</returns>
        IQueryable<T> Query<T>(Expression<Func<T, bool>> expression) where T : class;

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="S"></typeparam>
        /// <param name="funcWhere"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="funcOrderby"></param>
        /// <param name="isAsc">升序</param>
        /// <returns></returns>
        PageResult<T> QueryPage<T, S>(Expression<Func<T, bool>> funcWhere, int pageSize, int pageIndex, Expression<Func<T, S>> funcOrderby, bool isAsc = true) where T : class;
        #endregion

        #region Add
        /// <summary>
        /// 添加数据,并返回带主键的实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        T Insert<T>(T t) where T : class;

        /// <summary>
        /// 添加集合数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tList"></param>
        /// <returns></returns>
        IEnumerable<T> Insert<T>(IEnumerable<T> tList) where T : class;

        #endregion

        #region Update
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        T Update<T>(T t) where T : class;

        /// <summary>
        /// 更新数据集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tList"></param>
        /// <returns></returns>
        IEnumerable<T> Update<T>(IEnumerable<T> tList) where T : class;
        #endregion

        #region Delete
        /// <summary>
        /// 删除实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        void Delete<T>(T t) where T : class;

        /// <summary>
        /// 主键删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        void Delete<T>(int id) where T : class;

        /// <summary>
        /// 删除集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tList"></param>
        void Delete<T>(IEnumerable<T> tList) where T : class;
        #endregion

        #region Others
        /// <summary>
        /// 立即保存，
        /// 把增、删是savechange操作放到这里，保证事务
        /// </summary>
        void Commit();

        /// <summary>
        /// 执行sql语句查询，返回查询结果集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IQueryable<T> ExcuteQuery<T>(string sql, SqlParameter[] parameters) where T : class;

        /// <summary>
        /// 执行sql语句查询，无返回
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        void Excute<T>(string sql, SqlParameter[] parameters) where T : class;
        #endregion
    }
}
