/********************************************************************************/
using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Web;
using System.Web.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace DesignedNet.Framework.Web
{
	/// <summary>Common base web form library</summary>
	/// ================================================================================
	/// Object:	    DesignedNet.Framework.Web.Common
	/// Language:	C# ASP.NET 
	//--------------------------------------------------------------------------------
	/// Author:	    KHutchens
	/// Created:	07.28.03
	/// Modified:	01.24.04
	//--------------------------------------------------------------------------------
	/// Designed Simplicity, Inc.
	/// Copyright (c) 2001, 2002, 2003, 2004
	/// ================================================================================
	public class Common
	{
		//========================================================
		//Module level enumerations
		//========================================================
		public enum PageMode { New, List, View, Edit, Delete, Error }


		//========================================================
		//Module level variables
		//========================================================


		//========================================================
		//Public constructor
		//========================================================
		public Common() { }


		//========================================================
		//Validation methods
		//========================================================
		#region Validation methods

		//--------------------------------------------------------
		/// <summary>Resets the text box and clears any error messages</summary>
		public static void ResetTextBox(TextBox txt)
		{
			if (txt.CssClass == "required") txt.CssClass = "input";
			txt.ReadOnly = false;
			txt.Enabled = true;
		}

		//--------------------------------------------------------
		/// <summary>Validates a required text field, changes display type if error</summary>
		public static bool RequiredText(TextBox txt)
		{
			bool error = (txt.Text.Length == 0);
			if (error) txt.CssClass = "required"; else txt.CssClass = "input";
			
			// return error code
			return error;
		}

		//--------------------------------------------------------
		/// <summary>Validates a required integer text field, changes display type if error</summary>
		public static bool RequiredInteger(TextBox txt) { return RequiredInteger(txt, false); }
		public static bool RequiredInteger(TextBox txt, bool positive)
		{
			bool error = (txt.Text.Length == 0);
			if (error)
				txt.CssClass = "required";
			else
				return OptionalInteger(txt, positive);
			
			// return error code
			return error;
		}

		//--------------------------------------------------------
		/// <summary>Validates a required integer text field, changes display type if error</summary>
		public static bool OptionalInteger(TextBox txt) { return OptionalInteger(txt, false); }
		public static bool OptionalInteger(TextBox txt, bool positive)
		{
			bool error = false;
			txt.CssClass = "input";
			if (txt.Text.Length > 0)
			{
				int num;
				try
				{
					num = Convert.ToInt32(txt.Text);
					if ((positive) && (num < 0)) error = true;
				}
				catch
				{
					txt.CssClass = "required";
					error = true;
				}
			}
			
			// return error code
			return error;
		}

		//--------------------------------------------------------
		/// <summary>Validates a required decimal text field, changes display type if error</summary>
		public static bool RequiredDecimal(TextBox txt) { return RequiredDecimal(txt, false); }
		public static bool RequiredDecimal(TextBox txt, bool positive)
		{
			bool error = (txt.Text.Length == 0);
			if (error)
				txt.CssClass = "required";
			else
				return OptionalDecimal(txt, positive);
			
			// return error code
			return error;
		}

		//--------------------------------------------------------
		/// <summary>Validates a required decimal text field, changes display type if error</summary>
		public static bool OptionalDecimal(TextBox txt) { return OptionalDecimal(txt, false); }
		public static bool OptionalDecimal(TextBox txt, bool positive)
		{
			bool error = false;
			txt.CssClass = "input";
			if (txt.Text.Length > 0)
			{
				decimal num;
				try
				{
					num = Convert.ToDecimal(txt.Text);
					if ((positive) && (num < 0)) error = true;
				}
				catch
				{
					txt.CssClass = "required";
					error = true;
				}
			}
			
			// return error code
			return error;
		}

		//--------------------------------------------------------
		/// <summary>Validates a required date text field, changes display type if error</summary>
		public static bool RequiredDate(TextBox txt)
		{
			bool error = (txt.Text.Length == 0);
			if (error)
				txt.CssClass = "required";
			else
				return OptionalDate(txt);
			
			// return error code
			return error;
		}

		//--------------------------------------------------------
		/// <summary>Validates an optional date text field, changes display type if error</summary>
		public static bool OptionalDate(TextBox txt)
		{
			bool error = false;
			txt.CssClass = "input";
			if (txt.Text.Length > 0)
			{
				DateTime date;
				try { date = Convert.ToDateTime(txt.Text); }
				catch
				{
					txt.CssClass = "required";
					error = true;
				}
			}
			
			// return error code
			return error;
		}

		//--------------------------------------------------------
		/// <summary>Validates a required email text field, changes display type if error</summary>
		public static bool RequiredEmail(TextBox txt)
		{
			bool error = (txt.Text.Length == 0);
			if (error)
				txt.CssClass = "required";
			else
				return OptionalEmail(txt);
			
			// return error code
			return error;
		}

		//--------------------------------------------------------
		/// <summary>Validates an optional email text field, changes display type if error</summary>
		public static bool OptionalEmail(TextBox txt)
		{
			bool error = false;
			txt.CssClass = "input";
			int length = txt.Text.Length;
			if (length > 0)
			{
				// make sure no spaces
				if ((length != txt.Text.Replace(" ", "").Length) || (txt.Text.IndexOf("@") <= 0) || (txt.Text.IndexOf(".") <= 0))
				{
					txt.CssClass = "required";
					error = true;
				}
			}
			
			// return error code
			return error;
		}

		//--------------------------------------------------------
		/// <summary>Validates an optional phone text field, changes display type if error</summary>
		public static bool OptionalPhone(TextBox txt)
		{
			bool error = false;
			txt.CssClass = "input";
			int length = txt.Text.Length;
			if (length > 0)
			{
				string number = "";
				foreach(char c in txt.Text)
				{
					if (Char.IsDigit(c)) number += c;
				}

				if ((number.Length == 11) && number.StartsWith("1")) number = number.Substring(1, 10);
				if (number.Length < 10)
				{
					txt.CssClass = "required";
					error = true;
				}
				else
				{
					txt.Text = "(" + number.Substring(0, 3) + ") " + number.Substring(3, 3) + "-" + number.Substring(6, 4);
					if (number.Length > 10) txt.Text += " x" + number.Substring(10);
				}
			}
			
			// return error code
			return error;
		}

		#endregion


		//========================================================
		//Conversion methods
		//========================================================
		#region Conversion methods

		//--------------------------------------------------------
		/// <summary>Extracts an interger from a text box control</summary>
		public static int GetInteger(TextBox txt) { return GetInteger(txt, 0); }
		public static int GetInteger(TextBox txt, int defaultValue)
		{
			try { return Convert.ToInt32(txt.Text); }
			catch { return defaultValue; }
		}

		//--------------------------------------------------------
		/// <summary>Extracts an decimal from a text box control</summary>
		public static decimal GetDecimal(TextBox txt) { return GetDecimal(txt, 0); }
		public static decimal GetDecimal(TextBox txt, decimal defaultValue)
		{
			try { return Convert.ToDecimal(txt.Text); }
			catch { return defaultValue; }
		}

		//--------------------------------------------------------
		/// <summary>Extracts an double from a text box control</summary>
		public static double GetDouble(TextBox txt) { return GetDouble(txt, 0); }
		public static double GetDouble(TextBox txt, double defaultValue)
		{
			try { return Convert.ToDouble(txt.Text); }
			catch { return defaultValue; }
		}

		//--------------------------------------------------------
		/// <summary>Extracts an date time from a text box control</summary>
		public static DateTime GetDateTime(TextBox txt) { return GetDateTime(txt, DateTime.MinValue); }
		public static DateTime GetDateTime(TextBox txt, DateTime defaultValue)
		{
			try { return Convert.ToDateTime(txt.Text); }
			catch { return defaultValue; }
		}

		//--------------------------------------------------------
		/// <summary>Extracts the string from the object</summary>
		public static string GetString(object obj)
		{
			try { return Convert.ToString(obj); }
			catch { return ""; }
		}

		//--------------------------------------------------------
		/// <summary>Extracts the interger id from the object</summary>
		public static int GetID(object id)
		{
			try { return Convert.ToInt32(id); }
			catch { return -1; }
		}

		//--------------------------------------------------------
		/// <summary>Extracts the interger id from named value collection</summary>
		public static int GetID(NameValueCollection collection, string id)
		{
			try { return Convert.ToInt32(collection[id]); }
			catch { return -1; }
		}

		//--------------------------------------------------------
		/// <summary>Extracts the interger id from viewstate collection</summary>
		public static int GetID(StateBag collection, string id)
		{
			try { return Convert.ToInt32(collection[id]); }
			catch { return -1; }
		}

		//--------------------------------------------------------
		/// <summary>Extracts the interger id from viewstate collection</summary>
		public static int GetID(HttpCookieCollection collection, string id)
		{
			try { return Convert.ToInt32(collection[id].Value); }
			catch { return -1; }
		}

		//--------------------------------------------------------
		/// <summary>Extracts the interger id from viewstate collection</summary>
		public static int GetID(object collection, string id)
		{
			try { return Convert.ToInt32(DataBinder.Eval(collection, id)); }
			catch { return -1; }
		}

		#endregion


		//========================================================
		//Population methods
		//========================================================
		#region Population methods

		//--------------------------------------------------------
		/// <summary>Creates a Select one... item at the top of a list</summary>
		public static void CreateSelectOneItem(ListItemCollection list)
		{
			list.Insert(0, new ListItem("Select one...", ""));
		}

		//--------------------------------------------------------
		/// <summary>Clears the currently selected item</summary>
		public static void ClearSelection(DropDownList list)
		{
			try { list.SelectedItem.Selected = false; }
			catch { }
		}

		//--------------------------------------------------------
		/// <summary>Selects a list item given the display value</summary>
		/// <returns>True if value was located and selected</returns>
		public static bool SelectItemByText(ListItemCollection list, string text)
		{
			try 
			{
				list.FindByText(text).Selected = true; 
				return true;
			}
			catch 
			{
				return false;
			}
		}

		//--------------------------------------------------------
		/// <summary>Selects a list item given the value</summary>
		/// <returns>True if value was located and selected</returns>
		public static bool SelectItemByValue(ListItemCollection list, int val)
		{
			try { return SelectItemByValue(list, val.ToString()); }
			catch { return false; }
		}
		
		//--------------------------------------------------------
		/// <summary>Selects a list item given the value</summary>
		/// <returns>True if value was located and selected</returns>
		public static bool SelectItemByValue(ListItemCollection list, string val)
		{
			try 
			{
				list.FindByValue(val).Selected = true; 
				return true;
			}
			catch 
			{
				return false;
			}
		}

		#endregion


		//========================================================
		//Common methods
		//========================================================
		#region Common methods

		//--------------------------------------------------------
		/// <summary>Sends an email with the specified parameters</summary>
		public static void SendEmail(string to, string from, string subject, string body) { SendEmail(to, from, subject, body, "localhost"); }
		public static void SendEmail(string to, string from, string subject, string body, string server)
		{
			// create message
			MailMessage eMail = new MailMessage();
			eMail.To = to;
			eMail.From = from;
			eMail.Subject = subject;
			//eMail.BodyFormat = System.Web.Mail.MailFormat.Html;
			eMail.BodyFormat = System.Web.Mail.MailFormat.Text;
			eMail.Body = body;

			// send mail if on server or local machine
			if (server.ToLower().StartsWith("http://" + server))
			{
				SmtpMail.SmtpServer = server;
				SmtpMail.Send(eMail);
			}
			else
				SmtpMail.Send(eMail);
		}
		
		//--------------------------------------------------------
		/// <summary>Generates a random password of a specified lenght</summary>
		public static string RandomPassword(int length)
		{
			string pass = "";
			Random rnd = new System.Random();

			// create 3 char password
			for(int i=0;i<length;i++)
			{
				int c = rnd.Next(35);
				if (c < 10)
					pass += c.ToString();
				else
					pass += (char)(c + 55);
			}

			// return new password
			return pass;
		}

		#endregion
	}
}