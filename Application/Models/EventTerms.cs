namespace Application.Models;

public class EventTerms
{
    public string EventId { get; set; } = null!;
    public List<TermsSection> Section { get; set; } = new();
}
