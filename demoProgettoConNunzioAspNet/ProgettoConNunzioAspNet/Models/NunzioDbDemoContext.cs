using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProgettoConNunzioAspNet.Models;

public partial class NunzioDbDemoContext : DbContext
{
    public NunzioDbDemoContext()
    {
    }

    public NunzioDbDemoContext(DbContextOptions<NunzioDbDemoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<NunzioDataDummy> NunzioDataDummies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=NunzioDatabase;User Id=sa;Password=Pa$$w0rd$1;Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NunzioDataDummy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NunzioDa__3214EC270F34C52E");

            entity.ToTable("NunzioDataDummy");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Descrizione)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
