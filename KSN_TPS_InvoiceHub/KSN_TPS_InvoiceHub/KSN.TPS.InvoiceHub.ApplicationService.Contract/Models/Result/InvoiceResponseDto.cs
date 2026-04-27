namespace KSN.TPS.InvoiceHub.ApplicationService.Dto
{
    public class InvoiceResponseDto
    {
        public string TrackingId { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public bool IsValid { get; set; }
        public Dictionary<string, List<string>> Errors { get; set; } = new();
    }
}
