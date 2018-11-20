using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using LMS.Entity;

namespace LMS.DAL
{
	/// <summary>
	/// OfficeGoodsInfoSvr�ࣺOfficeGoodsInfo������ݲ�����
	/// </summary>
	public class OfficeGoodsInfoSvr
	{
		//��ѯ˽�й��������������ֶ�
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

		//��ѯ��������
		public List<EOfficeGoodsInfo> QueryMoreOfficeGoodsInfos()
		{
			string sql = string.Format("SELECT GoodID,GoodName FROM OfficeGoodsInfo");
			return CommQueryOfficeGoodsInfos(sql);
		}

		//����ID��ѯ��������
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

		//������������
		public bool InsertOfficeGoodsInfo(EOfficeGoodsInfo entity)
		{
			string sql = string.Format("INSERT INTO OfficeGoodsInfo(GoodID,GoodName) VALUES('{0}','{1}')", entity.GoodID, entity.GoodName);
			return DBHelper.UpdateOpera(sql);
		}

		//��������ɾ������
		public bool DeleteOfficeGoodsInfo(string goodID)
		{
			string sql = string.Format("DELETE OfficeGoodsInfo WHERE GoodID='{0}'", goodID);
			return DBHelper.UpdateOpera(sql);
		}

		//����������������
		public bool UpdateOfficeGoodsInfo(EOfficeGoodsInfo entity)
		{
			string sql = string.Format("UPDATE OfficeGoodsInfo SET GoodName='{1}' WHERE GoodID='{0}'", entity.GoodID, entity.GoodName);
			return DBHelper.UpdateOpera(sql);
		}

	}
}