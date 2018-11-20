using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using LMS.Entity;
using LMS.DAL;

namespace LMS.BLL
{
	public class OfficeGoodsInfoMgr
	{
		static OfficeGoodsInfoSvr svr = new OfficeGoodsInfoSvr(); //DAL操作的实例

		//查询所有数据
		public static List<EOfficeGoodsInfo> QueryMoreOfficeGoodsInfos()
		{
			return svr.QueryMoreOfficeGoodsInfos();
		}

		//根据ID查询单行数据
		public static EOfficeGoodsInfo QueryOneOfficeGoodsInfoByGoodID(string goodID)
		{
			return svr.QueryOneOfficeGoodsInfoByGoodID(goodID);
		}

		//插入所有字段
		public static bool InsertOfficeGoodsInfo(EOfficeGoodsInfo entity)
		{
			return svr.InsertOfficeGoodsInfo(entity);
		}

		//根据主键删除数据
		public static bool DeleteOfficeGoodsInfo(string goodID)
		{
			return svr.DeleteOfficeGoodsInfo(goodID);
		}

		//根据主键更新数据
		public static bool UpdateOfficeGoodsInfo(EOfficeGoodsInfo entity)
		{
			return svr.UpdateOfficeGoodsInfo(entity);
		}

	}
}