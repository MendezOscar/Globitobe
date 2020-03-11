using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace globitobe.Models
{
    public partial class globitodbContext : DbContext
    {
        public globitodbContext()
        {
        }

        public globitodbContext(DbContextOptions<globitodbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Activity> Activity { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Interest> Interest { get; set; }
        public virtual DbSet<Itinerary> Itinerary { get; set; }
        public virtual DbSet<Itinerarydetails> Itinerarydetails { get; set; }
        public virtual DbSet<Place> Place { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=mendezserver.database.windows.net;Database=globitodb;User Id=mendez; Password=M3nd3z2020; Trusted_Connection=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>(entity =>
            {
                entity.ToTable("activity");

                entity.Property(e => e.Activityid).HasColumnName("activityid");

                entity.Property(e => e.Categoryid).HasColumnName("categoryid");

                entity.Property(e => e.Categoryname)
                    .HasColumnName("categoryname")
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .IsUnicode(false);

                entity.Property(e => e.Duration).HasColumnName("duration");

                entity.Property(e => e.Imgurl)
                    .HasColumnName("imgurl")
                    .IsUnicode(false);

                entity.Property(e => e.Message)
                    .HasColumnName("message")
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .IsUnicode(false);

                entity.Property(e => e.Placeid).HasColumnName("placeid");

                entity.Property(e => e.Placename)
                    .HasColumnName("placename")
                    .IsUnicode(false);

                entity.Property(e => e.Schedule)
                    .HasColumnName("schedule")
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Activity)
                    .HasForeignKey(d => d.Categoryid)
                    .HasConstraintName("FK__activity__catego__5812160E");

                entity.HasOne(d => d.Place)
                    .WithMany(p => p.Activity)
                    .HasForeignKey(d => d.Placeid)
                    .HasConstraintName("FK__activity__placei__571DF1D5");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.Property(e => e.Categoryid).HasColumnName("categoryid");

                entity.Property(e => e.Icon)
                    .HasColumnName("icon")
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("city");

                entity.Property(e => e.Cityid).HasColumnName("cityid");

                entity.Property(e => e.Imgurl)
                    .HasColumnName("imgurl")
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .HasColumnName("location")
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Interest>(entity =>
            {
                entity.ToTable("interest");

                entity.Property(e => e.Interestid).HasColumnName("interestid");

                entity.Property(e => e.Categoryid).HasColumnName("categoryid");

                entity.Property(e => e.Categoryname)
                    .HasColumnName("categoryname")
                    .IsUnicode(false);

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Interest)
                    .HasForeignKey(d => d.Categoryid)
                    .HasConstraintName("FK__interest__catego__5070F446");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Interest)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("FK__interest__userid__4F7CD00D");
            });

            modelBuilder.Entity<Itinerary>(entity =>
            {
                entity.ToTable("itinerary");

                entity.Property(e => e.Itineraryid).HasColumnName("itineraryid");

                entity.Property(e => e.Cityid).HasColumnName("cityid");

                entity.Property(e => e.Enddate)
                    .HasColumnName("enddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Startdate)
                    .HasColumnName("startdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Itinerary)
                    .HasForeignKey(d => d.Cityid)
                    .HasConstraintName("FK__itinerary__cityi__5BE2A6F2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Itinerary)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("FK__itinerary__useri__5AEE82B9");
            });

            modelBuilder.Entity<Itinerarydetails>(entity =>
            {
                entity.HasKey(e => e.Itinerarydetailid)
                    .HasName("PK__itinerar__14CC9C72B5B13C39");

                entity.ToTable("itinerarydetails");

                entity.Property(e => e.Itinerarydetailid).HasColumnName("itinerarydetailid");

                entity.Property(e => e.Activityid).HasColumnName("activityid");

                entity.Property(e => e.Activityname)
                    .HasColumnName("activityname")
                    .IsUnicode(false);

                entity.Property(e => e.Itineraryid).HasColumnName("itineraryid");

                entity.Property(e => e.Priority).HasColumnName("priority");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.Itinerarydetails)
                    .HasForeignKey(d => d.Activityid)
                    .HasConstraintName("FK__itinerary__activ__5EBF139D");

                entity.HasOne(d => d.Itinerary)
                    .WithMany(p => p.Itinerarydetails)
                    .HasForeignKey(d => d.Itineraryid)
                    .HasConstraintName("FK__itinerary__itine__5FB337D6");
            });

            modelBuilder.Entity<Place>(entity =>
            {
                entity.ToTable("place");

                entity.Property(e => e.Placeid).HasColumnName("placeid");

                entity.Property(e => e.Cityid).HasColumnName("cityid");

                entity.Property(e => e.Imgurl)
                    .HasColumnName("imgurl")
                    .IsUnicode(false);

                entity.Property(e => e.Message)
                    .HasColumnName("message")
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .IsUnicode(false);

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Place)
                    .HasForeignKey(d => d.Cityid)
                    .HasConstraintName("FK__place__cityid__5441852A");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Place)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("FK__place__userid__534D60F1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
