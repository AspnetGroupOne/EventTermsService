using Application.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Entity;

[Table("Terms")]
[Index(nameof(EventId), IsUnique = true)]
public class TermsEntity
{
    // Entity made with the help of chatgpt to make it easier to store the different sections.

    [Key]
    public int Id { get; set; }
    public string EventId { get; set; } = null!;
    public List<TermsSection> Section { get; set; } = new();
}
