using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;

using System.Text;

namespace WCF_.Contract
{
	[ServiceContract(SessionMode = SessionMode.Required, Namespace = "FrameOfSystem3")]
	public interface IService
	{
        // 동기 메서드
		[OperationContract]
		void RegisteredClient();

        // 비동기 메서드
		[OperationContract(AsyncPattern = true)]
		IAsyncResult BeginReceive(string title, Dictionary<string, string> dataList, AsyncCallback callback, object state);
		DataResult EndReceive(IAsyncResult ar);
	}
	
	#region ContractList
	[DataContract(Namespace = "FrameOfSystem3")]
	public class DataResult
	{
		[DataMember(Order = 0)]
		public string Title { get; set; }

		[DataMember(Order = 1)]
		public Dictionary<string, string> DataList { get; set; }

		[DataMember(Order = 2)]
		public string Result { get; set; }

		[DataMember(Order = 3)]
		public string Description { get; set; }
	}
	#endregion
}
