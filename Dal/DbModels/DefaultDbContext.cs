using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dal.DbModels;

public partial class DefaultDbContext : DbContext
{
    public DefaultDbContext()
    {
    }

    public DefaultDbContext(DbContextOptions<DefaultDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<CarsOrder> CarsOrders { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<ClientsCar> ClientsCars { get; set; }

    public virtual DbSet<ClientsOrder> ClientsOrders { get; set; }

    public virtual DbSet<Competence> Competences { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderPart> OrderParts { get; set; }

    public virtual DbSet<OrderService> OrderServices { get; set; }

    public virtual DbSet<OrdersPart> OrdersParts { get; set; }

    public virtual DbSet<OrdersService> OrdersServices { get; set; }

    public virtual DbSet<Part> Parts { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<ServicePart> ServiceParts { get; set; }

<<<<<<< Updated upstream
=======
    public virtual DbSet<User> Users { get; set; }

>>>>>>> Stashed changes
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=VEX1TPC;Persist Security Info=True;User ID=user;Password=pass;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.Id).IsClustered(false);

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Brand)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.Model)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Vin)
                .IsRequired()
                .HasMaxLength(17)
                .IsUnicode(false)
                .HasColumnName("VIN");

            entity.HasOne(d => d.Client).WithMany(p => p.Cars)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cars_Clients");
        });

        modelBuilder.Entity<CarsOrder>(entity =>
        {
            entity.HasKey(e => new { e.CarsId, e.OrdersId }).HasName("PK__Cars_Ord__3FE3C99896A18BE7");

            entity.ToTable("Cars_Orders");

            entity.HasIndex(e => e.OrdersId, "UK_crw7mk37ioi5o6tptunvfqc6i").IsUnique();

            entity.Property(e => e.CarsId).HasColumnName("Cars_id");
            entity.Property(e => e.OrdersId).HasColumnName("orders_id");

            entity.HasOne(d => d.Cars).WithMany(p => p.CarsOrders)
                .HasForeignKey(d => d.CarsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKpl0exg4mt5la1pvkov0ep9ww2");

            entity.HasOne(d => d.Orders).WithOne(p => p.CarsOrder)
                .HasForeignKey<CarsOrder>(d => d.OrdersId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKqnkhnn31866ms51jr2lxucymx");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).IsClustered(false);

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.PhoneNumber)
                .IsRequired()
                .HasMaxLength(20);
        });

        modelBuilder.Entity<ClientsCar>(entity =>
        {
            entity.HasKey(e => new { e.ClientsId, e.CarsId }).HasName("PK__Clients___F6728589B7FCDD5E");

            entity.ToTable("Clients_Cars");

            entity.HasIndex(e => e.CarsId, "UK_61smxspx93rjqm02qhcoiflj3").IsUnique();

            entity.Property(e => e.ClientsId).HasColumnName("Clients_id");
            entity.Property(e => e.CarsId).HasColumnName("cars_id");

            entity.HasOne(d => d.Cars).WithOne(p => p.ClientsCar)
                .HasForeignKey<ClientsCar>(d => d.CarsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKc4oyro15qbqfmojy564mdvvk0");

            entity.HasOne(d => d.Clients).WithMany(p => p.ClientsCars)
                .HasForeignKey(d => d.ClientsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKocs6s2n24rii5rmsb2hkbahad");
        });

        modelBuilder.Entity<ClientsOrder>(entity =>
        {
            entity.HasKey(e => new { e.ClientsId, e.OrdersId }).HasName("PK__Clients___88BC0144246301E6");

            entity.ToTable("Clients_Orders");

            entity.HasIndex(e => e.OrdersId, "UK_6gbne67wa5v8b8ps2r0jlh9n1").IsUnique();

            entity.Property(e => e.ClientsId).HasColumnName("Clients_id");
            entity.Property(e => e.OrdersId).HasColumnName("orders_id");

            entity.HasOne(d => d.Clients).WithMany(p => p.ClientsOrders)
                .HasForeignKey(d => d.ClientsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKs0flld80rba7udcacyqn87pko");

            entity.HasOne(d => d.Orders).WithOne(p => p.ClientsOrder)
                .HasForeignKey<ClientsOrder>(d => d.OrdersId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK23xnklk5w50jboa0o1tnyae1c");
        });

        modelBuilder.Entity<Competence>(entity =>
        {
            entity.HasKey(e => e.Id).IsClustered(false);

            entity.ToTable("Competence");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.HasOne(d => d.Employee).WithMany(p => p.Competences)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Competence_Employee");

            entity.HasOne(d => d.Service).WithMany(p => p.Competences)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Competence_Services");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).IsClustered(false);

            entity.ToTable("Employee");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Birthday).HasColumnType("date");
            entity.Property(e => e.Experience).HasColumnType("date");
            entity.Property(e => e.JobTitle)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.PhoneNumber)
                .IsRequired()
                .HasMaxLength(20);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PK_Order")
                .IsClustered(false);

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateOfOrder).HasColumnType("datetime");
            entity.Property(e => e.WorkEnd).HasColumnType("datetime");
            entity.Property(e => e.WorkStart).HasColumnType("datetime");

            entity.HasOne(d => d.Car).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CarId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Cars");

            entity.HasOne(d => d.Client).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Clients");
        });

        modelBuilder.Entity<OrderPart>(entity =>
        {
            entity.HasKey(e => e.Id).IsClustered(false);

            entity.ToTable("OrderPart");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Count).HasColumnName("count");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderParts)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderPart_Orders");

            entity.HasOne(d => d.Part).WithMany(p => p.OrderParts)
                .HasForeignKey(d => d.PartId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderPart_Parts");
        });

        modelBuilder.Entity<OrderService>(entity =>
        {
            entity.HasKey(e => e.Id).IsClustered(false);

            entity.ToTable("OrderService");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateEnd).HasColumnType("date");
            entity.Property(e => e.DateStart).HasColumnType("date");

            entity.HasOne(d => d.Employee).WithMany(p => p.OrderServices)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderService_Employee");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderServices)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderService_Orders");

            entity.HasOne(d => d.Service).WithMany(p => p.OrderServices)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderService_Services");
        });

        modelBuilder.Entity<OrdersPart>(entity =>
        {
            entity.HasKey(e => new { e.OrdersId, e.PartsId }).HasName("PK__Orders_P__0544FBE228351FA9");

            entity.ToTable("Orders_Parts");

            entity.HasIndex(e => e.PartsId, "UK_qcr4mt25c674jw3t19y78ofwj").IsUnique();

            entity.Property(e => e.OrdersId).HasColumnName("Orders_id");
            entity.Property(e => e.PartsId).HasColumnName("parts_id");

            entity.HasOne(d => d.Orders).WithMany(p => p.OrdersParts)
                .HasForeignKey(d => d.OrdersId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKtg8dq83kn70toytjkitkgpouj");

            entity.HasOne(d => d.Parts).WithOne(p => p.OrdersPart)
                .HasForeignKey<OrdersPart>(d => d.PartsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKd56k852o18s619uiufffls716");
        });

        modelBuilder.Entity<OrdersService>(entity =>
        {
            entity.HasKey(e => new { e.OrdersId, e.ServicesId }).HasName("PK__Orders_S__14E09FF590F7BF51");

            entity.ToTable("Orders_Services");

            entity.HasIndex(e => e.ServicesId, "UK_t8jx1clxixvmww2nbmras07wq").IsUnique();

            entity.Property(e => e.OrdersId).HasColumnName("Orders_id");
            entity.Property(e => e.ServicesId).HasColumnName("services_id");

            entity.HasOne(d => d.Orders).WithMany(p => p.OrdersServices)
                .HasForeignKey(d => d.OrdersId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKh3hi81cicsxm70dwo2kisjdi3");

            entity.HasOne(d => d.Services).WithOne(p => p.OrdersService)
                .HasForeignKey<OrdersService>(d => d.ServicesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKmlkab05retqb105h5a5gwhtkt");
        });

        modelBuilder.Entity<Part>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PK_Part")
                .IsClustered(false);

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Brand)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.CarBrand)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.VendorCode)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasOne(d => d.Order).WithMany(p => p.Parts)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FKgsrxp6u84hol1v0guga2469yt");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PK_Service")
                .IsClustered(false);

            entity.HasIndex(e => e.Id, "UQ__Services__3213E83EA2DC9B87").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnName("price");

            entity.HasOne(d => d.Order).WithMany(p => p.Services)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FKlh2d8fcdgcs835ei33jnmw6uh");
        });

        modelBuilder.Entity<ServicePart>(entity =>
        {
            entity.HasKey(e => e.Id).IsClustered(false);

            entity.ToTable("ServicePart");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.HasOne(d => d.Part).WithMany(p => p.ServiceParts)
                .HasForeignKey(d => d.PartId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ServicePart_Parts");

            entity.HasOne(d => d.Service).WithMany(p => p.ServiceParts)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ServicePart_Service");
        });

<<<<<<< Updated upstream
=======
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC0703E1C54F");

            entity.Property(e => e.Login)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(250);
            entity.Property(e => e.RegistrationDate).HasColumnType("datetime");
        });

>>>>>>> Stashed changes
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
