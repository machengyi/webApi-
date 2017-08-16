using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTest.Commen
{
    public class extension
    {

    }

    public static class MvcExtends
    {
        /// <summary>
        /// 将指定类型的数据包裹成JsonResult, 默认 AllowGet
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="allowGet"></param>
        /// <returns></returns>
        public static JsonResult ToJsonResult<T>(this T obj, JsonRequestBehavior allowGet = JsonRequestBehavior.AllowGet, string contentType = "")
        {
            if (string.IsNullOrWhiteSpace(contentType))
            {
                return new JsonResult { Data = obj, JsonRequestBehavior = allowGet };
            }
            else
            {
                return new JsonResult { Data = obj, JsonRequestBehavior = allowGet, ContentType = contentType };
            }
        }
    }
}