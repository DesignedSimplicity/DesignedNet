<%@ Control Language="c#" AutoEventWireup="false" Codebehind="FacilityList.ascx.cs" Inherits="Storage.Framework.Web.Controls.FacilityList" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>

<asp:DataList ID="list" Runat="server" CssClass="list" HeaderStyle-CssClass="header" ItemStyle-CssClass="listitem" AlternatingItemStyle-CssClass="listitem2" Width="100%"><HeaderTemplate>Facility List</HeaderTemplate><ItemTemplate><a class="keyword" href="<%#_navigateUrl+DataBinder.Eval(Container.DataItem, &quot;FacilityID&quot;)%>"><b>#<%#DataBinder.Eval(Container.DataItem, "FacilityID")%>:</b></a> <b>FacilityName:</b> <%#DataBinder.Eval(Container.DataItem, "FacilityName")%> <b>Address:</b> <%#DataBinder.Eval(Container.DataItem, "Address")%> <b>City:</b> <%#DataBinder.Eval(Container.DataItem, "City")%> <b>State:</b> <%#DataBinder.Eval(Container.DataItem, "State")%> <b>Zip:</b> <%#DataBinder.Eval(Container.DataItem, "Zip")%> <b>Phone:</b> <%#DataBinder.Eval(Container.DataItem, "Phone")%> <b>Fax:</b> <%#DataBinder.Eval(Container.DataItem, "Fax")%> <b>EmailAdd:</b> <%#DataBinder.Eval(Container.DataItem, "EmailAdd")%> <b>TotlSqFoot:</b> <%#DataBinder.Eval(Container.DataItem, "TotlSqFoot")%> <b>UserName:</b> <%#DataBinder.Eval(Container.DataItem, "UserName")%> </ItemTemplate></asp:DataList>