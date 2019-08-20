﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System;
using WXQ.InOutPutEntites.Output;
using System.Collections.Generic;
namespace WebApi.Controllers.configmanage
{
    [Route("Api/Configmanage/Init")]
    [ApiController]
    public class InitController : Controller
    {
        /// <summary>
        /// 创建表 初始化数据库  执行完请注释掉该方法
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("CrateTable")]
        public JsonResult CrateTable()
        {

            ResponseResult result = new ResponseResult();
            Logger logger = LogManager.GetLogger("initlog");
            try
            {
       
                WXQ.BusinessCore.systemmanage.InitOp op = new WXQ.BusinessCore.systemmanage.InitOp(0);
                System.Collections.Generic.List<string> lt = new System.Collections.Generic.List<string>();
                op.CreateTable(ref lt);
                result.Data = lt;

            }
            catch (Exception ex)
            {
                result.Data = ex.Message;
                logger.Info("初始化数据库表失败");
                logger.Info(ex.Message);
            }
            return Json(result);
        }

        /// <summary>
        ///清理数据 初始化数据库  执行完请注释掉该方法
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("DeleteTableData")]
        public JsonResult DeleteTableData()
        {

            ResponseResult result = new ResponseResult();
            Logger logger = LogManager.GetLogger("initlog");
            try
            {

                WXQ.BusinessCore.systemmanage.InitOp op = new WXQ.BusinessCore.systemmanage.InitOp(0);
         
                result.Data =  op.DeleteTableData();
              

            }
            catch (Exception ex)
            {
                result.Data = ex.Message;
             
                logger.Info(ex.Message);
            }
            return Json(result);
        }


        /// <summary>
        ///创建基础数据 初始化数据库  执行完请注释掉该方法
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("CreateBaseData")]
        public JsonResult CreateBaseData()
        {

            ResponseResult result = new ResponseResult();
            Logger logger = LogManager.GetLogger("initlog");
            try
            {

                WXQ.BusinessCore.systemmanage.InitOp op = new WXQ.BusinessCore.systemmanage.InitOp(0);
                System.Collections.Generic.List<string> lt = new System.Collections.Generic.List<string>();
                op.CreateDepartment(ref lt);
                op.CreateUser(ref lt);
                op.CreateRole(ref lt);

                op.CreateMenu(ref lt);
                result.Data = lt;

            }
            catch (Exception ex)
            {
                result.Data = ex.Message;

                logger.Info(ex.Message);
            }
            return Json(result);
        }
        /// <summary>
        ///创建关联数据 初始化数据库  执行完请注释掉该方法
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("CreateRefData")]
        public JsonResult CreateRefData()
        {

            ResponseResult result = new ResponseResult();
            Logger logger = LogManager.GetLogger("initlog");
            try
            {

                WXQ.BusinessCore.systemmanage.InitOp op = new WXQ.BusinessCore.systemmanage.InitOp(0);
                System.Collections.Generic.List<string> lt = new System.Collections.Generic.List<string>();
                op.CreateRef(ref lt);
                result.Data = lt;

            }
            catch (Exception ex)
            {
                result.Data = ex.Message;

                logger.Info(ex.Message);
            }
            return Json(result);
        }
     


    }
}