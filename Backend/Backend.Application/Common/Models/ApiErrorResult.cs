namespace Backend.Application.Common.Models
{
    public class ApiErrorResult<T> : ApiResult<T>
    {
        private string[] ValidationErrors { get; set; }

        public ApiErrorResult(string message)
        {
            IsSuccessed = false;
            Message = message;
        }

        public ApiErrorResult(string[] validationErrors)
        {
            IsSuccessed = false;
            ValidationErrors = validationErrors;
        }
    }
}
