using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LMS.BLL;
using LMS.Entity;

public partial class OfficeGoodsAdmin_Admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDdl();
        }
    }

    private void BindDdl()
    {
        ddlOfficeGoodsInfo.DataTextField = "GoodName";
        ddlOfficeGoodsInfo.DataValueField = "GoodID";

        ddlOfficeGoodsInfo.DataSource = OfficeGoodsInfoMgr.QueryMoreOfficeGoodsInfos();
        ddlOfficeGoodsInfo.DataBind();
    }

    protected void btnInsert_Click(object sender, EventArgs e)
    {
        EOfficeGoodsRecords eogr = new EOfficeGoodsRecords
        {
            EmpID = txtEmpID.Text,
            GoodID = ddlOfficeGoodsInfo.SelectedValue,
            Amount = Convert.ToInt32(txtAmount.Text),
            Remark = txtRemark.Text
        };
        try
        {
            if (OfficeGoodsRecordsMgr.InsertOfficeGoodsRecords(eogr))
            {
                ClientScript.RegisterStartupScript(GetType(), "msg", "alert('添加成功！！！');", true);
                //清空
                txtEmpID.Text = txtAmount.Text = txtRemark.Text = "";
                ddlOfficeGoodsInfo.SelectedIndex = 0;       //选中第一项
            }
        }
        catch
        {
            ClientScript.RegisterStartupScript(GetType(), "msg", "alert('添加异常！！！！！！');", true);
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string empId = txtSearchEmpID.Text.Trim();
        if (string.IsNullOrEmpty(empId))
        {
            ClientScript.RegisterStartupScript(GetType(), "msg", "alert('请输入查询的员工编号！');", true);
            return;
        }

        //
        List<EOfficeGoodsRecords> ogrlist = OfficeGoodsRecordsMgr.QueryMoreByEmpId(empId);

        gvwRecords.DataSource = ogrlist;
        gvwRecords.DataBind();
    }

    protected void gvwRecords_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int supplyId = Convert.ToInt32(e.Keys[0]);

        if (OfficeGoodsRecordsMgr.DeleteOfficeGoodsRecords(supplyId))
        {
            ClientScript.RegisterStartupScript(GetType(), "msg", "alert('删除成功！！！');", true);
            btnSearch_Click(null, null);
        }
    }

    protected void gvwRecords_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvwRecords.EditIndex = e.NewEditIndex;
        btnSearch_Click(null, null);

        DropDownList ddl = gvwRecords.Rows[e.NewEditIndex].FindControl("ddlGoods") as DropDownList;
        ddl.DataSource = OfficeGoodsInfoMgr.QueryMoreOfficeGoodsInfos();
        ddl.DataBind();

        ddl.SelectedValue = (gvwRecords.Rows[e.NewEditIndex].FindControl("hfdGoodId") as HiddenField).Value;
    }

    protected void gvwRecords_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        
        DropDownList ddl = gvwRecords.Rows[e.RowIndex].FindControl("ddlGoods") as DropDownList;
        TextBox txt = gvwRecords.Rows[e.RowIndex].FindControl("txtAmount") as TextBox;

        EOfficeGoodsRecords eogr = new EOfficeGoodsRecords
        {
            SupplyId = Convert.ToInt32(e.Keys[0]),
            GoodID = ddl.SelectedValue,
            Amount = Convert.ToInt32(txt.Text)
        };

        try
        {
            if (OfficeGoodsRecordsMgr.UpdateOfficeGoodsRecords(eogr))
            {
                ClientScript.RegisterStartupScript(GetType(), "msg", "alert('修改成功！！！');", true);
                gvwRecords.EditIndex = -1;
                btnSearch_Click(null, null);
            }
        }
        catch
        {
            ClientScript.RegisterStartupScript(GetType(), "msg", "alert('修改异常！！！');", true);
        }
    }        


    protected void gvwRecords_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvwRecords.EditIndex = -1;
        btnSearch_Click(null, null);
    }
}