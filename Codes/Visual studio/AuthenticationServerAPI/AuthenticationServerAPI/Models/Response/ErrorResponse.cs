namespace AuthenticationServerAPI.Models.Response
{
    public class ErrorResponse
    {
        public IEnumerable<string> ErrorsMessages { get; set; }
        public ErrorResponse(string errorMessage) : this(new List<string>() { errorMessage }) { }
     
        public ErrorResponse(IEnumerable<string> errorMessages)
        {
            ErrorsMessages = errorMessages;
        }
    }
}
