<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128537184/13.1.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E426)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Default.aspx](./CS/ManualCellFormatting/Default.aspx) (VB: [Default.aspx](./VB/ManualCellFormatting/Default.aspx))
* [Default.aspx.cs](./CS/ManualCellFormatting/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/ManualCellFormatting/Default.aspx.vb))
<!-- default file list end -->
# Custom formatting in column cells and inplace editors
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e426/)**
<!-- run online end -->


<p>The recommended approach to cell formatting is to create a Text grid column (<a href="http://documentation.devexpress.com/#AspNet/clsDevExpressWebASPxGridViewGridViewDataTextColumntopic">GridViewDataTextColumn</a>) and set its <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxEditorsEditPropertiesBase_DisplayFormatStringtopic">PropertiesTextEdit.DisplayFormatString</a> property.</p><p>If, for some reason, this approach cannot be employed in your application, you can handle grid events to implement custom formatting. This example demonstrates how to use the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxGridViewASPxGridView_CustomColumnDisplayTexttopic">CustomColumnDisplayText</a> and <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxGridViewASPxGridView_CellEditorInitializetopic">CellEditorInitialize</a><br />
events to customize the text displayed in cells and inplace editors.</p>

<br/>


