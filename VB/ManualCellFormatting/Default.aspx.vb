Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports DevExpress.Web.ASPxGridView
Imports DevExpress.Web.ASPxEditors

Namespace ManualCellFormatting
	Partial Public Class _Default
		Inherits System.Web.UI.Page
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			ASPxGridView1.DataSource = GetData()
			ASPxGridView1.KeyFieldName = "ID"
			ASPxGridView1.SettingsEditing.Mode = GridViewEditingMode.Inline

			If (Not IsPostBack) AndAlso (Not IsCallback) Then
				CreateColumns()
				ASPxGridView1.DataBind()
			End If
		End Sub

		Private Function GetData() As Object
			Dim table As New DataTable()
			Dim key As DataColumn = table.Columns.Add("ID", GetType(Integer))
			table.PrimaryKey = New DataColumn() { key }
			table.Columns.Add("Weight", GetType(Decimal))
			table.Columns.Add("Price", GetType(Decimal))
			table.Rows.Add(1, 0.33333D, 1.75D)
			table.Rows.Add(2, 0.5D, 3.008D)
			table.Rows.Add(3, 2.71828D, 9.98D)
			Return table
		End Function
		Private Sub CreateColumns()
			Dim colEdit As New GridViewCommandColumn()
			colEdit.EditButton.Visible = True
			ASPxGridView1.Columns.Add(colEdit)

			Dim colWeight As New GridViewDataColumn()
			colWeight.FieldName = "Weight"
			ASPxGridView1.Columns.Add(colWeight)

			Dim colPrice As New GridViewDataColumn()
			colPrice.FieldName = "Price"
			ASPxGridView1.Columns.Add(colPrice)
		End Sub
		Protected Sub ASPxGridView1_CustomColumnDisplayText(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewColumnDisplayTextEventArgs)

			Select Case e.Column.FieldName
				Case "Weight"
					e.DisplayText = FormatWeight(e.Value)
				Case "Price"
					e.DisplayText = FormatPrice(e.Value)
			End Select
		End Sub

		Private Function FormatWeight(ByVal val As Object) As String
			Return String.Format("{0:n3} oz.", val)
		End Function
		Private Function FormatPrice(ByVal val As Object) As String
			Return String.Format("{0:c2}", val)
		End Function

		Protected Sub ASPxGridView1_CellEditorInitialize(ByVal sender As Object, ByVal e As ASPxGridViewEditorEventArgs)
			Select Case e.Column.FieldName
				Case "Weight"
					CType(e.Editor, ASPxTextEdit).Text = FormatWeight(e.Value)
				Case "Price"
					CType(e.Editor, ASPxTextEdit).Text = FormatPrice(e.Value)
			End Select
		End Sub

		Protected Sub ASPxGridView1_ParseValue(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxParseValueEventArgs)
			' TODO: parse editors' text and convert it to decimal values
			e.Value = 0.0D
		End Sub

		Protected Sub ASPxGridView1_RowUpdating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs)
			' editing is not implemented in this sample project
			e.Cancel = True
			ASPxGridView1.CancelEdit()
		End Sub
	End Class
End Namespace
