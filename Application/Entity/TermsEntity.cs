using Application.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Entity;

[Table("Terms")]
[Index(nameof(EventId), IsUnique = true)]
public class TermsEntity
{
    [Key]
    public int Id { get; set; }
    public string EventId { get; set; } = null!;
    public List<TermsSection> Section { get; set; } = new();
}
