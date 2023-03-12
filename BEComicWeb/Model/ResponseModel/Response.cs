namespace BEComicWeb.Model.ResponseModel
{
    public class Response<DataType>
    {
        public string Status { get; set; }
        public string? Message { get; set; }
        DataType? Data { get; set; }
        public Response(string status, string message, DataType data) 
        { 
            Status = status;
            Message = message;
            Data = data;
        }
    }
    public class Response
    {
        public string Status { get; set; }
        public string? Message { get; set; }
        public Response(string status, string message)
        {
            Status = status;
            Message = message;
        }
    }
}
