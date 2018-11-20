using System;
using System.Collections.Generic;
using System.Web;

namespace LMS.Entity
{
	/// <summary>
	/// EOfficeGoodsRecords�ࣺOfficeGoodsRecords���Ӧ��ʵ����
	/// </summary>
	public class EOfficeGoodsRecords
	{
		public int SupplyId{ get; set; }

		public string EmpID{ get; set; }

		public DateTime SupplyTime{ get; set; }

		public string GoodID{ get; set; }

		public int Amount{ get; set; }

		public string Remark{ get; set; }

        public string GoodName { get; set; }

    }
}