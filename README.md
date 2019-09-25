# DesignedNet.Framework
## Microsoft .NET v2.0 Code Generation Framework

### The DesignedNet Framework reduces development effort with automated code generation of database entites

DesignedNet is an application framework and code generation engine built using the Microsoft .NET Framework. This framework has been optimized to provide high performance and scalability for enterprise level software applications based on ASP.NET and Windows technologies. This framework has been leveraged on numerous projects for clients in a variety of industries with great success to deliver quality solutions in limited time and and on budget.

The ability to generate this amount of code substantially reduces the number of bugs due to the reuse of tested and proven base classes and the automation of the tedious operations of matching table and column names with display controls and user input validation. Examples of implementations of this framework are documented below for your review.

## Documentation

[Detailed Requirments](../master/Documentation/Requirements.pdf)
[Layer Specifications](../master/Documentation/Specifications.pdf)

## Code Example

[Business Entity](../master/Output/Biz/BizComment.cs)
[Database Access](../master/Output/Dal/DalComment.cs)
[SQL Scripts](../master/Output/Sql/SqlComment.cs)

## User Interface

```ascx
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="CommentList.ascx.cs" Inherits="Harkins.Web.Controls.CommentList" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>

<asp:DataList ID="list" Runat="server" CssClass="list" HeaderStyle-CssClass="header" ItemStyle-CssClass="listitem" AlternatingItemStyle-CssClass="listitem2" Width="100%"><HeaderTemplate>Comment List</HeaderTemplate><ItemTemplate><a class="keyword" href="<%#_navigateUrl+DataBinder.Eval(Container.DataItem, &quot;CommentID&quot;)%>"><b>#<%#DataBinder.Eval(Container.DataItem, "CommentID")%>:</b></a> <b>CommentTypeID:</b> <%#DataBinder.Eval(Container.DataItem, "CommentTypeID")%> <b>ProjectID:</b> <%#DataBinder.Eval(Container.DataItem, "ProjectID")%> <b>CompanyID:</b> <%#DataBinder.Eval(Container.DataItem, "CompanyID")%> <b>ContactID:</b> <%#DataBinder.Eval(Container.DataItem, "ContactID")%> <b>CreatedByID:</b> <%#DataBinder.Eval(Container.DataItem, "CreatedByID")%> <b>AssignedToID:</b> <%#DataBinder.Eval(Container.DataItem, "AssignedToID")%> <b>Priority:</b> <%#DataBinder.Eval(Container.DataItem, "Priority")%> <b>Thread:</b> <%#DataBinder.Eval(Container.DataItem, "Thread")%> <b>Subject:</b> <%#DataBinder.Eval(Container.DataItem, "Subject")%> <b>Comment:</b> <%#DataBinder.Eval(Container.DataItem, "Comment")%> <b>Created:</b> <%#DataBinder.Eval(Container.DataItem, "Created")%> <b>Updated:</b> <%#DataBinder.Eval(Container.DataItem, "Updated")%> <b>Reminder:</b> <%#DataBinder.Eval(Container.DataItem, "Reminder")%> <b>Completed:</b> <%#DataBinder.Eval(Container.DataItem, "Completed")%> </ItemTemplate></asp:DataList>
```
