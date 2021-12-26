using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DISEASE_PREDICTION.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<TBL_ADMIN> TBL_ADMIN { get; set; }
        public virtual DbSet<TBL_DISEASECATEGORY> TBL_DISEASECATEGORY { get; set; }
        public virtual DbSet<TBL_FEEDBACK> TBL_FEEDBACK { get; set; }
        public virtual DbSet<TBL_MEDICINE> TBL_MEDICINE { get; set; }
        public virtual DbSet<TBL_MEDICINECOMPANY> TBL_MEDICINECOMPANY { get; set; }
        public virtual DbSet<TBL_ORDER> TBL_ORDER { get; set; }
        public virtual DbSet<TBL_ORDERDETAIL> TBL_ORDERDETAIL { get; set; }
        public virtual DbSet<TBL_PATIENT> TBL_PATIENT { get; set; }
        public virtual DbSet<TBL_SYMPTOMS> TBL_SYMPTOMS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TBL_DISEASECATEGORY>()
                .HasMany(e => e.TBL_MEDICINE)
                .WithRequired(e => e.TBL_DISEASECATEGORY)
                .HasForeignKey(e => e.DISEASECATEGORY_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TBL_FEEDBACK>()
                .Property(e => e.FEEDBACK_DETAIL)
                .IsFixedLength();

            modelBuilder.Entity<TBL_MEDICINE>()
                .HasMany(e => e.TBL_ORDERDETAIL)
                .WithRequired(e => e.TBL_MEDICINE)
                .HasForeignKey(e => e.MEDICINE_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TBL_MEDICINE>()
                .HasMany(e => e.TBL_SYMPTOMS)
                .WithRequired(e => e.TBL_MEDICINE)
                .HasForeignKey(e => e.MED_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TBL_MEDICINECOMPANY>()
                .Property(e => e.COMPANY_NAME)
                .IsFixedLength();

            modelBuilder.Entity<TBL_MEDICINECOMPANY>()
                .HasMany(e => e.TBL_MEDICINE)
                .WithRequired(e => e.TBL_MEDICINECOMPANY)
                .HasForeignKey(e => e.MED_COMPANY_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TBL_ORDER>()
                .HasMany(e => e.TBL_ORDERDETAIL)
                .WithRequired(e => e.TBL_ORDER)
                .HasForeignKey(e => e.ORDER_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TBL_PATIENT>()
                .Property(e => e.PATIENT_GENDER)
                .IsFixedLength();

            modelBuilder.Entity<TBL_PATIENT>()
                .HasMany(e => e.TBL_FEEDBACK)
                .WithOptional(e => e.TBL_PATIENT)
                .HasForeignKey(e => e.PATIENT_FID);

            modelBuilder.Entity<TBL_PATIENT>()
                .HasMany(e => e.TBL_ORDER)
                .WithRequired(e => e.TBL_PATIENT)
                .HasForeignKey(e => e.PATIENT_FID)
                .WillCascadeOnDelete(false);
        }
    }
}
