using Application.Entity;
using Microsoft.EntityFrameworkCore;

namespace Application.Data.Context;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public virtual DbSet<TermsEntity> Terms { get; set; }

}
