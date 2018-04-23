using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DevExpress.Web;

namespace ManualCellFormatting {
    public partial class _Default : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            ASPxGridView1.DataSource = GetData();
            ASPxGridView1.KeyFieldName = "ID";
            ASPxGridView1.SettingsEditing.Mode = GridViewEditingMode.Inline;

            if(!IsPostBack && !IsCallback) {
                CreateColumns();
                ASPxGridView1.DataBind();
            }
        }

        private object GetData() {
            DataTable table = new DataTable();
            DataColumn key = table.Columns.Add("ID", typeof(int));
            table.PrimaryKey = new DataColumn[] { key };
            table.Columns.Add("Weight", typeof(decimal));
            table.Columns.Add("Price", typeof(decimal));
            table.Rows.Add(1, 0.33333m, 1.75m);
            table.Rows.Add(2, 0.5m, 3.008m);
            table.Rows.Add(3, 2.71828m, 9.98m);
            return table;
        }
        private void CreateColumns() {
            GridViewCommandColumn colEdit = new GridViewCommandColumn();
            colEdit.ShowEditButton = true;
            ASPxGridView1.Columns.Add(colEdit);

            GridViewDataColumn colWeight = new GridViewDataColumn();
            colWeight.FieldName = "Weight";
            ASPxGridView1.Columns.Add(colWeight);

            GridViewDataColumn colPrice = new GridViewDataColumn();
            colPrice.FieldName = "Price";
            ASPxGridView1.Columns.Add(colPrice);
        }
        protected void ASPxGridView1_CustomColumnDisplayText(object sender, DevExpress.Web.ASPxGridViewColumnDisplayTextEventArgs e) {

            switch(e.Column.FieldName) {
                case "Weight":
                    e.DisplayText = FormatWeight(e.Value);
                    break;
                case "Price":
                    e.DisplayText = FormatPrice(e.Value);
                    break;
            }
        }

        private string FormatWeight(object val) {
            return string.Format("{0:n3} oz.", val);
        }
        private string FormatPrice(object val) {
            return string.Format("{0:c2}", val);
        }

        protected void ASPxGridView1_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e) {
            switch(e.Column.FieldName) {
                case "Weight":
                    ((ASPxTextEdit)e.Editor).Text = FormatWeight(e.Value);
                    break;
                case "Price":
                    ((ASPxTextEdit)e.Editor).Text = FormatPrice(e.Value);
                    break;
            }
        }

        protected void ASPxGridView1_ParseValue(object sender, DevExpress.Web.Data.ASPxParseValueEventArgs e) {
            // TODO: parse editors' text and convert it to decimal values
            e.Value = 0.0m;
        }

        protected void ASPxGridView1_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e) {
            // editing is not implemented in this sample project
            e.Cancel = true;
            ASPxGridView1.CancelEdit();
        }
    }
}
