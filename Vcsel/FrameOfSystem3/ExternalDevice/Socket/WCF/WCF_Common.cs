using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

using System.ServiceModel;
using System.ServiceModel.Channels;

using WCF_.Contract;
using System.Text;

namespace WCF_.Common
{
	// 비동기 동작으로 받을 데이터 클래스 
	public class ReceiveAsyncResult : AsyncResult
    {
        #region PROPERTY
		public DataResult ResultData { get; set; }
		public Exception Exception { get; set; }
        #endregion

        #region CONSTRUCTOR
		public ReceiveAsyncResult(DataResult resultData, AsyncCallback callback, object state)
			: base(callback, state)
		{
            this.ResultData = resultData;
        }
        #endregion
    }

	public class ProxyFactory<T> : ClientBase<T> where T : class
	{
		public ProxyFactory(Binding binding, EndpointAddress remoteAddress)
			: base(binding, remoteAddress)
		{
		}

		public ProxyFactory(string endpoint)
			: base(endpoint)
		{
		}

		public T CreateProxy()
		{
			T interFce = base.CreateChannel();

			return interFce;
		}

		public void CloseProxy()
		{
			try
			{
				try
				{
					this.Close();
				}
				catch { }
				finally
				{
					this.Abort();
				}
			}
			catch
			{
			}
		}
	}

	// 비동기 동작을 위한 데이터 클래스
	public class AsyncResult : IAsyncResult, IDisposable
	{
		AsyncCallback callback;
		object state;
		ManualResetEvent manualResentEvent;

		public AsyncResult(AsyncCallback callback, object state)
		{
			this.callback = callback;
			this.state = state;
			this.manualResentEvent = new ManualResetEvent(false);
		}

		object IAsyncResult.AsyncState
		{
			get { return state; }
		}

		public ManualResetEvent AsyncWait
		{
			get
			{
				return manualResentEvent;
			}
		}

		WaitHandle IAsyncResult.AsyncWaitHandle
		{
			get { return this.AsyncWait; }
		}

		bool IAsyncResult.CompletedSynchronously
		{
			get { return false; }
		}

		bool IAsyncResult.IsCompleted
		{
			get { return manualResentEvent.WaitOne(0, false); }
		}

		public void Complete()
		{
			manualResentEvent.Set();
			if (callback != null)
				callback(this);
		}

		public void Dispose()
		{
			manualResentEvent.Close();
			manualResentEvent = null;
			state = null;
			callback = null;
		}
	}
}
