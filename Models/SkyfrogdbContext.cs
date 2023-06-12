using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TestApi.Models;

public partial class SkyfrogdbContext : DbContext
{
    public SkyfrogdbContext()
    {
    }

    public SkyfrogdbContext(DbContextOptions<SkyfrogdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbExpense> TbExpenses { get; set; }

    public virtual DbSet<TbHandheld> TbHandhelds { get; set; }

    public virtual DbSet<TbJobprefix> TbJobprefixes { get; set; }

    public virtual DbSet<TbJobtype> TbJobtypes { get; set; }

    public virtual DbSet<TbQuality> TbQualities { get; set; }

    public virtual DbSet<TbReason> TbReasons { get; set; }

    public virtual DbSet<TbVehicle> TbVehicles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Database=skyfrogdb;Username=postgres;Password=123456");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbExpense>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tb_expense_pkey");

            entity.ToTable("tb_expense");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Isactive).HasColumnName("isactive");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<TbHandheld>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("tb_handheld_pkey");

            entity.ToTable("tb_handheld");

            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .HasColumnName("code");
            entity.Property(e => e.Isactive).HasColumnName("isactive");
            entity.Property(e => e.StatusName)
                .HasMaxLength(50)
                .HasColumnName("status_name");
        });

        modelBuilder.Entity<TbJobprefix>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tb_jobprefix_pkey");

            entity.ToTable("tb_jobprefix");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.DateFormat).HasColumnName("date_format");
            entity.Property(e => e.Delimiter).HasColumnName("delimiter");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnName("description");
            entity.Property(e => e.DigitRunning)
                .HasMaxLength(10)
                .HasColumnName("digit_running");
            entity.Property(e => e.Format)
                .HasMaxLength(30)
                .HasColumnName("format");
            entity.Property(e => e.FormatType).HasColumnName("format_type");
            entity.Property(e => e.Isactive).HasColumnName("isactive");
            entity.Property(e => e.Isdefault).HasColumnName("isdefault");
            entity.Property(e => e.Prefix)
                .HasMaxLength(10)
                .HasColumnName("prefix");
        });

        modelBuilder.Entity<TbJobtype>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("tb_jobtype_pkey");

            entity.ToTable("tb_jobtype");

            entity.Property(e => e.Code)
                .ValueGeneratedNever()
                .HasColumnName("code");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnName("description");
            entity.Property(e => e.Isactive).HasColumnName("isactive");
            entity.Property(e => e.Isdefault).HasColumnName("isdefault");
            entity.Property(e => e.LoadingTime).HasColumnName("loading_time");
            entity.Property(e => e.MaxLoading).HasColumnName("max_loading");
            entity.Property(e => e.MaxUnloading).HasColumnName("max_unloading");
            entity.Property(e => e.Owner)
                .HasMaxLength(20)
                .HasColumnName("owner");
            entity.Property(e => e.Prefix)
                .HasMaxLength(10)
                .HasColumnName("prefix");
            entity.Property(e => e.Subtype).HasColumnName("subtype");
            entity.Property(e => e.UnloadingTime).HasColumnName("unloading_time");
        });

        modelBuilder.Entity<TbQuality>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tb_quality_pkey");

            entity.ToTable("tb_quality");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Isactive).HasColumnName("isactive");
            entity.Property(e => e.QaName)
                .HasMaxLength(50)
                .HasColumnName("qa_name");
        });

        modelBuilder.Entity<TbReason>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("tb_reason_pkey");

            entity.ToTable("tb_reason");

            entity.Property(e => e.Code)
                .HasColumnType("character varying")
                .HasColumnName("code");
            entity.Property(e => e.Isactive).HasColumnName("isactive");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.ReasonType).HasColumnName("reason_type");
        });

        modelBuilder.Entity<TbVehicle>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("tb_vehicle_pkey");

            entity.ToTable("tb_vehicle");

            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .HasColumnName("code");
            entity.Property(e => e.AvgUsage)
                .HasDefaultValueSql("0")
                .HasColumnName("avg_usage");
            entity.Property(e => e.FixedCost)
                .HasDefaultValueSql("0")
                .HasColumnName("fixed_cost");
            entity.Property(e => e.Frequency)
                .HasDefaultValueSql("0")
                .HasColumnName("frequency");
            entity.Property(e => e.FuelCost)
                .HasDefaultValueSql("0")
                .HasColumnName("fuel_cost");
            entity.Property(e => e.Isactive).HasColumnName("isactive");
            entity.Property(e => e.MaxHeight)
                .HasDefaultValueSql("0")
                .HasColumnName("max_height");
            entity.Property(e => e.SpeedLimit).HasColumnName("speed_limit");
            entity.Property(e => e.TimeCost)
                .HasDefaultValueSql("0")
                .HasColumnName("time_cost");
            entity.Property(e => e.VehicleName)
                .HasMaxLength(50)
                .HasColumnName("vehicle_name");
            entity.Property(e => e.VolunmC)
                .HasDefaultValueSql("0")
                .HasColumnName("volunm_c");
            entity.Property(e => e.WeightC)
                .HasDefaultValueSql("0")
                .HasColumnName("weight_c");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
