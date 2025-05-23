using Application.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Entity;

[Table("Terms")]
public class TermsEntity
{
    [Key]
    public int Id { get; set; }
    public string EventId { get; set; } = null!;
    public List<TermsSection> Section { get; set; } = new();
}
