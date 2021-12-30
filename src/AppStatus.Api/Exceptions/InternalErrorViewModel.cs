using System.Runtime.Serialization;
using AppStatus.Api.ViewModels;

namespace AppStatus.Api.Exceptions
{
    [DataContract]
    public class InternalErrorViewModel : ErrorViewModel
    {
        [DataMember(Name = "trace_id")]
        public string TraceId { get; set; }

        [DataMember(Name = "error_detail")]
        public string ErrorDetail { get; set; }
        public InternalErrorViewModel(string errorDescription, string traceId, string errorDetail)
        {
            ErrorCode = "internal_error";
            ErrorDescription = errorDescription;
            ErrorDetail = errorDetail;
            TraceId = traceId;
        }
    }
}
