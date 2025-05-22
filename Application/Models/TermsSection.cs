namespace Application.Models;

public class TermsSection
{
    public string Header { get; set; } = null!;
    public int Order { get; set; }
    public List<string> Lines { get; set; } = new();
}