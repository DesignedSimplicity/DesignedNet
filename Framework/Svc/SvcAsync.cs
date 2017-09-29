using System;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.Remoting.Messaging;

namespace DesignedNet.Framework.Svc
{
	/// <summary>Base class for asynchronous callback process</summary>
	/// ================================================================================
	/// Object:		DesignedNet.Framework.Svc.SvcAsync
	/// Language:	C# ASP.NET 
	//--------------------------------------------------------------------------------
	/// Author:		KHutchens
	/// Created:	01.16.03
	/// Modified:	03.17.03
	//--------------------------------------------------------------------------------
	/// Designed Simplicity, Inc.
	/// Copyright (c) 2001, 2002, 2003, 2004
	/// ================================================================================
	public class SvcAsync
	{
		//========================================================
		//Variables
		//========================================================
		private Control _control;
		private AsyncLoadingDelegate _begin;
		private AsyncLoadingDelegate _finish;
		public delegate void AsyncLoadingDelegate();
		public delegate void AsyncExceptionDelegate(Exception e);


		//========================================================
		//Constructors
		//========================================================
		public SvcAsync(Control control, AsyncLoadingDelegate begin, AsyncLoadingDelegate finish)
		{
			_control = control;
			_begin = begin;		
			_finish = finish;
		}


		//========================================================
		//Public methods
		//========================================================
		public void BeginLoadData()
		{
			// Create the callback delegate
			AsyncCallback cb = new AsyncCallback(LoadingComplete);

			// make async call
			IAsyncResult ar = _begin.BeginInvoke(cb, null); 
		}

		public void LoadingComplete(IAsyncResult ar)
		{			
			AsyncLoadingDelegate dlg = (AsyncLoadingDelegate) ((AsyncResult)ar).AsyncDelegate;

			try
			{
				// try to end the call
				dlg.EndInvoke(ar);
			}
			catch (Exception e)
			{
				// exception will be raised if there was an exception on the worker thread
				ThrowAsyncException(e);
				return;
			}

			// call the user's callback function
			if (_finish != null) _control.BeginInvoke(_finish);
		}
		
		public void ThrowAsyncException(Exception e)
		{
			// check to see if we're on the UI thread
			if (!_control.InvokeRequired)
			{
				throw new Exception("Asynchronous loading failed", e);
			}
				// otherwise send async message from worker thread
			else
			{
				AsyncExceptionDelegate dlg = new AsyncExceptionDelegate(ThrowAsyncException);
				_control.BeginInvoke(dlg, new object[1] {e});
			}
		}
	}
}
