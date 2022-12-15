namespace Appoitment.Domain.Responses
{
    public class RepositoryResponse
    {
        public object ObjectResponse { get; set; } = null;
        public bool Error { get; } = false;
        public string Message { get; } = string.Empty;

        public RepositoryResponse(object objectResponse)
        {
            ObjectResponse = objectResponse;
        }

        public RepositoryResponse(bool error = false, string message = "")
        {
            Error = error;
            Message = message;
        }
    }
}