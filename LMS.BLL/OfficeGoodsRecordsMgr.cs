using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using LMS.Entity;
using LMS.DAL;

namespace LMS.BLL
{
	public class OfficeGoodsRecordsMgr
	{
		static OfficeGoodsRecordsSvr svr = new OfficeGoodsRecordsSvr(); //DAL操作的实例

		//查询所有数据
		public static List<EOfficeGoodsRecords> QueryMoreOfficeGoodsRecordss()
		{
			return svr.QueryMoreOfficeGoodsRecordss();
		}

		//根据ID查询单行数据
		public static EOfficeGoodsRecords QueryOneOfficeGoodsRecordsBySupplyId(int supplyId)
		{
			return svr.QueryOneOfficeGoodsRecordsBySupplyId(supplyId);
		}

		//插入所有字段
		public static bool InsertOfficeGoodsRecords(EOfficeGoodsRecords entity)
		{
			return svr.InsertOfficeGoodsRecords(entity);
		}

		//根据主键删除数据
		public static bool DeleteOfficeGoodsRecords(int supplyId)
		{
			return svr.DeleteOfficeGoodsRecords(supplyId);
		}

		//根据主键更新数据
		public static bool UpdateOfficeGoodsRecords(EOfficeGoodsRecords entity)
		{
			return svr.UpdateOfficeGoodsRecords(entity);
		}

        public static List<EOfficeGoodsRecords> QueryMoreByEmpId(string empId)
        {
            return svr.QueryMoreByEmpId(empId);
        }
    }
}