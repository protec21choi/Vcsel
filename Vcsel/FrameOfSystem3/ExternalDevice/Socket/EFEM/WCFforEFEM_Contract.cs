using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;

using System.Text;

namespace WCF_Contract_
{
	[ServiceContract(SessionMode = SessionMode.Required)]
	public interface IServiceEquipment
	{
        // 동기 메서드
		[OperationContract]
		void RegisteredClient();

        // 비동기 메서드
		[OperationContract(AsyncPattern = true)]
		IAsyncResult BeginRequest(string sPortName, string sFunction, AsyncCallback callback, object state);
		ReceiveResult EndRequest(IAsyncResult ar);

        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginResponse(ResponseResult sResult, AsyncCallback callback, object state);
        ReceiveResult EndResponse(IAsyncResult ar);

		[OperationContract(AsyncPattern = true)]
		IAsyncResult BeginSecsGemParameter(string type, Dictionary<string, string> dataList, AsyncCallback callback, object state);
		SecsGemParameter EndSecsGemParameter(IAsyncResult ar);

		[OperationContract(AsyncPattern = true)]
		IAsyncResult BeginSecsGemEvent(string type, string sFunction, Dictionary<string, string> dataList, AsyncCallback callback, object state);
		SecsGemEvent EndSecsGemEvent(IAsyncResult ar);
	}
	
	#region ContractList
	
	[DataContract]
	public class ReceiveResult
	{
		[DataMember(Order = 0)]
		public string PortName { get; set; }

        [DataMember(Order = 1)]
        public string Function { get; set; }

		[DataMember(Order = 2)]
		public string Result { get; set; }

		[DataMember(Order = 3)]
		public string Description { get; set; }
	}

    [DataContract]
    public class ResponseResult
    {
        [DataMember(Order = 0)]
        public string PortName { get; set; }

        [DataMember(Order = 1)]
        public string Function { get; set; }

        [DataMember(Order = 2)]
        public string Result { get; set; }

        [DataMember(Order = 3)]
        public string Description { get; set; }
    }

	[DataContract]
	public class SecsGemParameter	// VID, ECID
	{
		[DataMember(Order = 0)]
		public string Type { get; set; }

		[DataMember(Order = 1)]
		public Dictionary<string, string> DataList { get; set; }

		[DataMember(Order = 2)]
		public string Result { get; set; }

		[DataMember(Order = 3)]
		public string Description { get; set; }
	}

	[DataContract]
	public class SecsGemEvent		// EVENT, ALARM, RCMD, RMS
	{
		[DataMember(Order = 0)]
		public string Type { get; set; }

		[DataMember(Order = 1)]
		public string Function { get; set; }

		[DataMember(Order = 2)]
		public Dictionary<string, string> DataList { get; set; }

		[DataMember(Order = 3)]
		public string Result { get; set; }

		[DataMember(Order = 4)]
		public string Description { get; set; }
	}

	[DataContract]
	public class SubjectInfo	// WAFER SYNC
	{
		[DataMember(Order = 0)]
		public string LotID { get; set; }

		[DataMember(Order = 1)]
		public string WaferID { get; set; }

		[DataMember(Order = 2)]
		public int SlotNo { get; set; }

		[DataMember(Order = 3)]
		public string Result { get; set; }

		[DataMember(Order = 4)]
		public string Description { get; set; }
	}

	[DataContract]
	public class SecsGemRMS		// RECIPE UPLOAD, DOWNLOAD
	{
		[DataMember(Order = 0)]
		public string Function { get; set; }

		[DataMember(Order = 1)]
		public string RecipeID { get; set; }

		[DataMember(Order = 2)]
		public int RecipePath { get; set; }

		[DataMember(Order = 3)]
		public string Result { get; set; }

		[DataMember(Order = 4)]
		public string Description { get; set; }
	}

	#endregion
}
