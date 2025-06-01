using Application.Entity;
using Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Data.Context;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    // Got help from chatgpt to make this work. Had a discussion with chatgpt to figure
    // out a good way of handling the amount of different sections. 

    public DbSet<TermsEntity> Terms { get; set; }
    public DbSet<TermsSection> Sections { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<TermsEntity>()
            .HasMany(t => t.Section)
            .WithOne(s => s.TermsEntity)
            .HasForeignKey(s => s.TermsId);
    }
}
