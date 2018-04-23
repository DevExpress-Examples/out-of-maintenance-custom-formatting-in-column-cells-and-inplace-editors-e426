# Custom formatting in column cells and inplace editors


<p>The recommended approach to cell formatting is to create a Text grid column (<a href="http://documentation.devexpress.com/#AspNet/clsDevExpressWebASPxGridViewGridViewDataTextColumntopic">GridViewDataTextColumn</a>) and set its <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxEditorsEditPropertiesBase_DisplayFormatStringtopic">PropertiesTextEdit.DisplayFormatString</a> property.</p><p>If, for some reason, this approach cannot be employed in your application, you can handle grid events to implement custom formatting. This example demonstrates how to use the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxGridViewASPxGridView_CustomColumnDisplayTexttopic">CustomColumnDisplayText</a> and <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxGridViewASPxGridView_CellEditorInitializetopic">CellEditorInitialize</a><br />
events to customize the text displayed in cells and inplace editors.</p>

<br/>


