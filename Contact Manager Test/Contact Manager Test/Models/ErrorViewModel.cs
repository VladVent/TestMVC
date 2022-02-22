namespace Contact_Manager_Test.Models
{
    public class ErrorViewModel
    {
        public ErrorViewModel()
        {
        }
        public ErrorViewModel(int code)
        {
            StatusCode = code;
        }

        public string? RequestId { get; set; }

        public int StatusCode { get; set; }
        public string Message { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}