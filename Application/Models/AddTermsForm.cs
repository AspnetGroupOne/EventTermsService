using System.ComponentModel.DataAnnotations;

namespace Application.Models;

public class AddTermsForm
{
    public string EventId { get; set; } = null!;
    public List<TermsSection> Section { get; set; } = new();
}
