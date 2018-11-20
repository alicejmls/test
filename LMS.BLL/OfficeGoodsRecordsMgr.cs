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
		static OfficeGoodsRecordsSvr svr = new OfficeGoodsRecordsSvr(); //DAL������ʵ��

		//��ѯ��������
		public static List<EOfficeGoodsRecords> QueryMoreOfficeGoodsRecordss()
		{
			return svr.QueryMoreOfficeGoodsRecordss();
		}

		//����ID��ѯ��������
		public static EOfficeGoodsRecords QueryOneOfficeGoodsRecordsBySupplyId(int supplyId)
		{
			return svr.QueryOneOfficeGoodsRecordsBySupplyId(supplyId);
		}

		//���������ֶ�
		public static bool InsertOfficeGoodsRecords(EOfficeGoodsRecords entity)
		{
			return svr.InsertOfficeGoodsRecords(entity);
		}

		//��������ɾ������
		public static bool DeleteOfficeGoodsRecords(int supplyId)
		{
			return svr.DeleteOfficeGoodsRecords(supplyId);
		}

		//����������������
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