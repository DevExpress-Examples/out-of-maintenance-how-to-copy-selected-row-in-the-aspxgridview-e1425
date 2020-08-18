<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="WebApplication10._Default" %>

<%@ Register assembly="DevExpress.Web.v14.1"  namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.v14.1" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>

<%@ Register assembly="DevExpress.Web.v14.1"  namespace="DevExpress.Web.ASPxCallbackPanel" tagprefix="dxcp" %>
<%@ Register assembly="DevExpress.Web.v14.1" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
	<title></title>
	<script type="text/javascript">
		function ProcessSelect(grid,args) {
			if (args.isSelected) {
				callbackPanel.PerformCallback(args.visibleIndex.toString() + ";y");
			}
			else {
				callbackPanel.PerformCallback(args.visibleIndex.toString() + ";n");

			}
		} 
	</script>
</head>
<body>
	<form id="form1" runat="server">
	<div>
	Please select a row in the Grid1 to copy it in the Grid2. Please unselect a row in Grid1 to remove it from the Grid2.
	</div>



	<dxcp:aspxcallbackpanel ID="ASPxCallbackPanel1" runat="server" Width="200px" 
		ClientInstanceName="callbackPanel" oncallback="ASPxCallbackPanel1_Callback" 
		style="margin-bottom: 0px">
		<PanelCollection>
<dxp:PanelContent runat="server">
	<table cellspacing = "5px">
	<tr>
	<td>
	Grid1:<br />
	   <dxwgv:aspxgridview ID="ASPxGridView1" runat="server" KeyFieldName="ID">
	   <clientsideevents SelectionChanged = "function(s,e){ProcessSelect(s,e);}" />
	   <columns>
	   <dxwgv:gridviewcommandcolumn ShowSelectCheckbox="true">
	   </dxwgv:gridviewcommandcolumn>
	   <dxwgv:gridviewdatacolumn FieldName = "ID">
	   </dxwgv:gridviewdatacolumn>
	   <dxwgv:gridviewdatacolumn FieldName = "Data">
	   </dxwgv:gridviewdatacolumn>
	   </columns>
	   </dxwgv:aspxgridview>
	</td>
	<td>
	Grid2:<br />
		<dxwgv:aspxgridview ID="ASPxGridView2" runat="server">
		</dxwgv:aspxgridview>
	</td>

	</tr>
	</table>
</dxp:PanelContent>
</PanelCollection>
	</dxcp:aspxcallbackpanel>


	</form>
</body>
</html>

