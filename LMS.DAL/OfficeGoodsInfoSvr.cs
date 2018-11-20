using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using LMS.Entity;

namespace LMS.DAL
{
	/// <summary>
	/// OfficeGoodsInfoSvr类：OfficeGoodsInfo表的数据操作类
	/// </summary>
	public class OfficeGoodsInfoSvr
	{
		//查询私有公共方法：所有字段
		private List<EOfficeGoodsInfo> CommQueryOfficeGoodsInfos(string sql)
		{
			List<EOfficeGoodsInfo> elist = new List<EOfficeGoodsInfo>();
			SqlDataReader dr = DBHelper.GetReader(sql);
			while (dr.Read())
			{
				EOfficeGoodsInfo entity = new EOfficeGoodsInfo();
				entity.GoodID = Convert.ToString(dr["GoodID"]);
				entity.GoodName = Convert.ToString(dr["GoodName"]);
				elist.Add(entity);
			}
			return elist;
		}

		//查询所有数据
		public List<EOfficeGoodsInfo> QueryMoreOfficeGoodsInfos()
		{
			string sql = string.Format("SELECT GoodID,GoodName FROM OfficeGoodsInfo");
			return CommQueryOfficeGoodsInfos(sql);
		}

		//根据ID查询单行数据
		public EOfficeGoodsInfo QueryOneOfficeGoodsInfoByGoodID(string goodID)
		{
			string sql = string.Format("SELECT GoodID,GoodName FROM OfficeGoodsInfo WHERE GoodID='{0}'",goodID);
			List<EOfficeGoodsInfo> list = CommQueryOfficeGoodsInfos(sql);
			if(list.Count>0)
			{
				return list[0];
			}
			return null;
		}

		//插入所有数据
		public bool InsertOfficeGoodsInfo(EOfficeGoodsInfo entity)
		{
			string sql = string.Format("INSERT INTO OfficeGoodsInfo(GoodID,GoodName) VALUES('{0}','{1}')", entity.GoodID, entity.GoodName);
			return DBHelper.UpdateOpera(sql);
		}

		//根据主键删除数据
		public bool DeleteOfficeGoodsInfo(string goodID)
		{
			string sql = string.Format("DELETE OfficeGoodsInfo WHERE GoodID='{0}'", goodID);
			return DBHelper.UpdateOpera(sql);
		}

		//根据主键更新数据
		public bool UpdateOfficeGoodsInfo(EOfficeGoodsInfo entity)
		{
			string sql = string.Format("UPDATE OfficeGoodsInfo SET GoodName='{1}' WHERE GoodID='{0}'", entity.GoodID, entity.GoodName);
			return DBHelper.UpdateOpera(sql);
		}

	}
}