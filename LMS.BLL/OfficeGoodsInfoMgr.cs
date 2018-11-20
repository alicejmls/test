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
		static OfficeGoodsInfoSvr svr = new OfficeGoodsInfoSvr(); //DAL������ʵ��

		//��ѯ��������
		public static List<EOfficeGoodsInfo> QueryMoreOfficeGoodsInfos()
		{
			return svr.QueryMoreOfficeGoodsInfos();
		}

		//����ID��ѯ��������
		public static EOfficeGoodsInfo QueryOneOfficeGoodsInfoByGoodID(string goodID)
		{
			return svr.QueryOneOfficeGoodsInfoByGoodID(goodID);
		}

		//���������ֶ�
		public static bool InsertOfficeGoodsInfo(EOfficeGoodsInfo entity)
		{
			return svr.InsertOfficeGoodsInfo(entity);
		}

		//��������ɾ������
		public static bool DeleteOfficeGoodsInfo(string goodID)
		{
			return svr.DeleteOfficeGoodsInfo(goodID);
		}

		//����������������
		public static bool UpdateOfficeGoodsInfo(EOfficeGoodsInfo entity)
		{
			return svr.UpdateOfficeGoodsInfo(entity);
		}

	}
}