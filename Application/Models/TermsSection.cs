using Application.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Models;

public class TermsSection
{
    // TermsSection from chatgpt to make it work hopefully.
    [Key]
    public int Id { get; set; }

    [ForeignKey("TermsEntity")]
    public int TermsId { get; set; }
    public string Header { get; set; } = null!;
    public int Order { get; set; }
    public List<string> Lines { get; set; } = new();
    public TermsEntity? TermsEntity { get; set; }
}
