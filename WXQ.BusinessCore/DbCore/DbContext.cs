﻿using WXQ.Enties;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

/// <summary>
    /// 读取配置文件
    /// </summary>
    public class AppConfigurtaionServices
    {
        public static IConfiguration Configuration { get; set; }
        static AppConfigurtaionServices()
        {
            //ReloadOnChange = true 当appsettings.json被修改时重新加载            
            Configuration = new ConfigurationBuilder()
            　　.Add(new JsonConfigurationSource { Path = "appsettings.json", ReloadOnChange = true })
            　　.Build();            
        }
    }



public class WXQDbContext <T> where T : class, new()
{


    private string connstr =AppConfigurtaionServices.Configuration.GetConnectionString("wxqconn"); 
    public  WXQDbContext ()
    {

	  

        Db = new SqlSugarClient(new ConnectionConfig()
        {
            ConnectionString = connstr,
            DbType = DbType.SqlServer,
            InitKeyType = InitKeyType.Attribute,//从特性读取主键和自增列信息
            IsAutoCloseConnection = true,//开启自动释放模式和EF原理一样我就不多解释了

        });
        //调式代码 用来打印SQL 
        Db.Aop.OnLogExecuting = (sql, pars) =>
        {
            Console.WriteLine(sql + "\r\n" +
                Db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
            Console.WriteLine();
        };

    }
    //注意：不能写成静态的
    public SqlSugarClient Db;//用来处理事务多表查询和复杂的操作
	public SimpleClient<T> CurrentDb { get { return new SimpleClient<T>(Db); } }//用来操作当前表的数据

   public SimpleClient<nlog> nlogDb { get { return new SimpleClient<nlog>(Db); } }//用来处理nlog表的常用操作
   public SimpleClient<OpLog> OpLogDb { get { return new SimpleClient<OpLog>(Db); } }//用来处理OpLog表的常用操作
   public SimpleClient<Role> RoleDb { get { return new SimpleClient<Role>(Db); } }//用来处理Role表的常用操作
   public SimpleClient<RoleMenu> RoleMenuDb { get { return new SimpleClient<RoleMenu>(Db); } }//用来处理RoleMenu表的常用操作
   public SimpleClient<UserDepartment> UserDepartmentDb { get { return new SimpleClient<UserDepartment>(Db); } }//用来处理UserDepartment表的常用操作
   public SimpleClient<efactorLog> efactorLogDb { get { return new SimpleClient<efactorLog>(Db); } }//用来处理efactorLog表的常用操作
   public SimpleClient<UserRole> UserRoleDb { get { return new SimpleClient<UserRole>(Db); } }//用来处理UserRole表的常用操作
   public SimpleClient<Dict> DictDb { get { return new SimpleClient<Dict>(Db); } }//用来处理Dict表的常用操作
   public SimpleClient<Users> UsersDb { get { return new SimpleClient<Users>(Db); } }//用来处理Users表的常用操作
   public SimpleClient<Department> DepartmentDb { get { return new SimpleClient<Department>(Db); } }//用来处理Department表的常用操作
   public SimpleClient<DepartmentRole> DepartmentRoleDb { get { return new SimpleClient<DepartmentRole>(Db); } }//用来处理DepartmentRole表的常用操作
   public SimpleClient<Menu> MenuDb { get { return new SimpleClient<Menu>(Db); } }//用来处理Menu表的常用操作
   public SimpleClient<MenuPageElement> MenuPageElementDb { get { return new SimpleClient<MenuPageElement>(Db); } }//用来处理MenuPageElement表的常用操作
   public SimpleClient<Metrics> MetricsDb { get { return new SimpleClient<Metrics>(Db); } }//用来处理Metrics表的常用操作


   /// <summary>
    /// 获取所有
    /// </summary>
    /// <returns></returns>
    public virtual List<T> GetList()
    {
        return CurrentDb.GetList();
    }

    /// <summary>
    /// 根据表达式查询
    /// </summary>
    /// <returns></returns>
    public virtual List<T> GetList(Expression<Func<T, bool>> whereExpression)
    {
        return CurrentDb.GetList(whereExpression);
    }


    /// <summary>
    /// 根据表达式查询分页
    /// </summary>
    /// <returns></returns>
    public virtual List<T> GetPageList(Expression<Func<T, bool>> whereExpression, PageModel pageModel)
    {
        return CurrentDb.GetPageList(whereExpression, pageModel);
    }

    /// <summary>
    /// 根据表达式查询分页并排序
    /// </summary>
    /// <param name="whereExpression">it</param>
    /// <param name="pageModel"></param>
    /// <param name="orderByExpression">it=>it.id或者it=>new{it.id,it.name}</param>
    /// <param name="orderByType">OrderByType.Desc</param>
    /// <returns></returns>
    public virtual List<T> GetPageList(Expression<Func<T, bool>> whereExpression, PageModel pageModel, Expression<Func<T, object>> orderByExpression = null, OrderByType orderByType = OrderByType.Asc)
    {
        return CurrentDb.GetPageList(whereExpression, pageModel,orderByExpression,orderByType);
    }


    /// <summary>
    /// 根据主键查询
    /// </summary>
    /// <returns></returns>
    public virtual T GetById(int id)
    {
        return CurrentDb.GetById(id);
    }
	/// <summary>
    /// 根据主键查询
    /// </summary>
    /// <returns></returns>
    public virtual T GetById(string id)
    {
        return CurrentDb.GetById(id);
    }

   /// <summary>
    /// 根据主键删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public virtual bool DeleteById(int id)
    {
        return CurrentDb.DeleteById(id);
    }

    public virtual bool DeleteById(string id)
    {
        return CurrentDb.DeleteById(id);
    }

    /// <summary>
    /// 根据实体删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public virtual bool Delete(T data)
    {
        return CurrentDb.Delete(data);
    }

    /// <summary>
    /// 根据主键删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public virtual bool DeleteByIds(dynamic[] ids)
    {
       return CurrentDb.DeleteByIds(ids);
    }

    /// <summary>
    /// 根据表达式删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public virtual bool Delete(Expression<Func<T, bool>> whereExpression)
    {
        return CurrentDb.Delete(whereExpression);
    }


    /// <summary>
    /// 根据实体更新，实体需要有主键
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public virtual bool Update(T obj)
    {
        return CurrentDb.Update(obj);
    }

    /// <summary>
    ///批量更新
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public virtual bool Update(List<T> objs)
    {
        return CurrentDb.UpdateRange(objs);
    }

    /// <summary>
    /// 插入
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public virtual bool Insert(T obj)
    {
        return CurrentDb.Insert(obj);
    }


    /// <summary>
    /// 批量
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public virtual bool Insert(List<T> objs)
    {
        return CurrentDb.InsertRange(objs);
    }
	    /// <summary>
    /// 返回主键整形id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public virtual int InsertReturnInt(T obj)
    {
        return CurrentDb.AsInsertable(obj).ExecuteReturnIdentity();
    }

    //自已扩展更多方法 
}


