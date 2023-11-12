namespace LightweightToDoLesson11.Models
{
    public class ErrorViewModele
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
