using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using LMS.Entity;

namespace LMS.DAL
{
	/// <summary>
	/// OfficeGoodsRecordsSvr类：OfficeGoodsRecords表的数据操作类
	/// </summary>
	public class OfficeGoodsRecordsSvr
	{
		//查询私有公共方法：所有字段
		private List<EOfficeGoodsRecords> CommQueryOfficeGoodsRecordss(string sql)
		{
			List<EOfficeGoodsRecords> elist = new List<EOfficeGoodsRecords>();
			SqlDataReader dr = DBHelper.GetReader(sql);
			while (dr.Read())
			{
				EOfficeGoodsRecords entity = new EOfficeGoodsRecords();
				entity.SupplyId = Convert.ToInt32(dr["SupplyId"]);
				entity.EmpID = Convert.ToString(dr["EmpID"]);
				entity.SupplyTime = Convert.ToDateTime(dr["SupplyTime"]);
				entity.GoodID = Convert.ToString(dr["GoodID"]);
				entity.Amount = Convert.ToInt32(dr["Amount"]);
				entity.Remark = Convert.ToString(dr["Remark"]);

                entity.GoodName = Convert.ToString(dr["GoodName"]);
				elist.Add(entity);
			}
			return elist;
		}

		//查询所有数据
		public List<EOfficeGoodsRecords> QueryMoreOfficeGoodsRecordss()
		{
			string sql = string.Format("SELECT SupplyId,EmpID,SupplyTime,GoodID,Amount,Remark FROM OfficeGoodsRecords");
			return CommQueryOfficeGoodsRecordss(sql);
		}

        //
        public List<EOfficeGoodsRecords> QueryMoreByEmpId(string empId)
        {
            string sql = string.Format("select ogr.*,ogi.GoodName from OfficeGoodsRecords ogr inner join OfficeGoodsInfo ogi on ogr.GoodID=ogi.GoodID where ogr.EmpID='{0}'",empId);

            return CommQueryOfficeGoodsRecordss(sql);
        }

        //根据ID查询单行数据
        public EOfficeGoodsRecords QueryOneOfficeGoodsRecordsBySupplyId(int supplyId)
		{
			string sql = string.Format("SELECT SupplyId,EmpID,SupplyTime,GoodID,Amount,Remark FROM OfficeGoodsRecords WHERE SupplyId='{0}'",supplyId);
			List<EOfficeGoodsRecords> list = CommQueryOfficeGoodsRecordss(sql);
			if(list.Count>0)
			{
				return list[0];
			}
			return null;
		}

		//插入所有数据
		public bool InsertOfficeGoodsRecords(EOfficeGoodsRecords entity)
		{
			string sql = string.Format("INSERT INTO OfficeGoodsRecords(EmpID,SupplyTime,GoodID,Amount,Remark) VALUES('{0}',getDate(),'{1}','{2}','{3}')", entity.EmpID,entity.GoodID, entity.Amount, entity.Remark);
			return DBHelper.UpdateOpera(sql);
		}

		//根据主键删除数据
		public bool DeleteOfficeGoodsRecords(int supplyId)
		{
			string sql = string.Format("DELETE OfficeGoodsRecords WHERE SupplyId='{0}'", supplyId);
			return DBHelper.UpdateOpera(sql);
		}

		//根据主键更新数据
		public bool UpdateOfficeGoodsRecords(EOfficeGoodsRecords entity)
		{
			string sql = string.Format("UPDATE OfficeGoodsRecords SET GoodID='{1}',Amount='{2}' WHERE SupplyId='{0}'", entity.SupplyId, entity.GoodID, entity.Amount);
			return DBHelper.UpdateOpera(sql);
		}

	}
}