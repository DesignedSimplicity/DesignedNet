<%@ Control Language="c#" AutoEventWireup="false" Codebehind="CommentEdit.ascx.cs" Inherits="Harkins.Web.Controls.CommentEdit" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>

<table class="form" border="0" cellpadding="1" cellspacing="0"><tr><td colspan="2" class="header"><asp:Label ID="lblTitle" Runat="server">Comment Form</asp:Label></td></tr><tr><td class="field">CommentTypeID:</td><td><asp:DropDownList ID="selCommentTypeID" Runat="server" CssClass="select"><asp:ListItem Value="">SELECT ONE...</asp:ListItem></asp:DropDownList></td></tr><tr><td class="field">ProjectID:</td><td><asp:DropDownList ID="selProjectID" Runat="server" CssClass="select"><asp:ListItem Value="">SELECT ONE...</asp:ListItem></asp:DropDownList></td></tr><tr><td class="field">CompanyID:</td><td><asp:DropDownList ID="selCompanyID" Runat="server" CssClass="select"><asp:ListItem Value="">SELECT ONE...</asp:ListItem></asp:DropDownList></td></tr><tr><td class="field">ContactID:</td><td><asp:DropDownList ID="selContactID" Runat="server" CssClass="select"><asp:ListItem Value="">SELECT ONE...</asp:ListItem></asp:DropDownList></td></tr><tr><td class="field">CreatedByID:</td><td><asp:TextBox ID="txtCreatedByID" Runat="server" CssClass="input" MaxLength="25"></asp:TextBox></td></tr><tr><td class="field">AssignedToID:</td><td><asp:TextBox ID="txtAssignedToID" Runat="server" CssClass="input" MaxLength="25"></asp:TextBox></td></tr><tr><td class="field">Priority:</td><td><asp:TextBox ID="txtPriority" Runat="server" CssClass="input" MaxLength="25"></asp:TextBox></td></tr><tr><td class="field">Thread:</td><td><asp:TextBox ID="txtThread" Runat="server" CssClass="input" MaxLength="50"></asp:TextBox></td></tr><tr><td class="field">Subject:</td><td><asp:TextBox ID="txtSubject" Runat="server" CssClass="input" MaxLength="500"></asp:TextBox></td></tr><tr><td class="field">Comment:</td><td><asp:TextBox ID="txtComment" Runat="server" CssClass="input" MaxLength="5000"></asp:TextBox></td></tr><tr><td class="field">Reminder:</td><td><asp:TextBox ID="txtReminder" Runat="server" CssClass="input" MaxLength="25"></asp:TextBox></td></tr><tr><td class="field">Completed:</td><td><asp:TextBox ID="txtCompleted" Runat="server" CssClass="input" MaxLength="25"></asp:TextBox></td></tr></table>