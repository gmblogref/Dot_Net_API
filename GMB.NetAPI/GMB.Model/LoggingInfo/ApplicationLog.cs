
namespace GMB.Model.LoggingInfo
{
    public class ApplicationLog
    {
        public short AppId { get; set; }
        public string ErrorLevel { get; set; }
        public string ExceptionMessge { get; set; }
        public string StackTrace { get; set; }
    }
}
