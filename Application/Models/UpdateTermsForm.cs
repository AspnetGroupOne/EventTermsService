namespace Application.Models;

public class UpdateTermsForm
{
    public string EventId { get; set; } = null!;
    public List<TermsSection> Section { get; set; } = new();
}
