using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DISEASE_PREDICTION.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model15")
        {
        }

        public virtual DbSet<TBL_ADMIN> TBL_ADMIN { get; set; }
        public virtual DbSet<TBL_APPOINTMENT> TBL_APPOINTMENT { get; set; }
        public virtual DbSet<TBL_DISEASE_SYMPTOM> TBL_DISEASE_SYMPTOM { get; set; }
        public virtual DbSet<TBL_DISEASECATEGORY> TBL_DISEASECATEGORY { get; set; }
        public virtual DbSet<TBL_DOCTOR> TBL_DOCTOR { get; set; }
        public virtual DbSet<TBL_FEEDBACK> TBL_FEEDBACK { get; set; }
        public virtual DbSet<TBL_MEDICINE> TBL_MEDICINE { get; set; }
        public virtual DbSet<TBL_MEDICINECOMPANY> TBL_MEDICINECOMPANY { get; set; }
        public virtual DbSet<TBL_ORDER> TBL_ORDER { get; set; }
        public virtual DbSet<TBL_ORDERDETAIL> TBL_ORDERDETAIL { get; set; }
        public virtual DbSet<TBL_PATIENT> TBL_PATIENT { get; set; }
        public virtual DbSet<TBL_SCH_DAY> TBL_SCH_DAY { get; set; }
        public virtual DbSet<TBL_SCHEDULE> TBL_SCHEDULE { get; set; }
        public virtual DbSet<TBL_SPECIALIZATION> TBL_SPECIALIZATION { get; set; }
        public virtual DbSet<TBL_SYMPTOMS> TBL_SYMPTOMS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TBL_ADMIN>()
                .HasMany(e => e.TBL_ORDER)
                .WithOptional(e => e.TBL_ADMIN)
                .HasForeignKey(e => e.ADMIN_FID);

            modelBuilder.Entity<TBL_DISEASECATEGORY>()
                .HasMany(e => e.TBL_DISEASE_SYMPTOM)
                .WithRequired(e => e.TBL_DISEASECATEGORY)
                .HasForeignKey(e => e.DISEASE_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TBL_DISEASECATEGORY>()
                .HasMany(e => e.TBL_MEDICINE)
                .WithRequired(e => e.TBL_DISEASECATEGORY)
                .HasForeignKey(e => e.DISEASECATEGORY_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TBL_DOCTOR>()
                .HasMany(e => e.TBL_SCHEDULE)
                .WithRequired(e => e.TBL_DOCTOR)
                .HasForeignKey(e => e.DOC_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TBL_MEDICINE>()
                .HasMany(e => e.TBL_ORDERDETAIL)
                .WithRequired(e => e.TBL_MEDICINE)
                .HasForeignKey(e => e.MEDICINE_FID)
                .WillCascadeOnDelete(false);

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
                .HasMany(e => e.TBL_APPOINTMENT)
                .WithRequired(e => e.TBL_PATIENT)
                .HasForeignKey(e => e.PATIENT_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TBL_PATIENT>()
                .HasMany(e => e.TBL_FEEDBACK)
                .WithOptional(e => e.TBL_PATIENT)
                .HasForeignKey(e => e.PATIENT_FID);

            modelBuilder.Entity<TBL_PATIENT>()
                .HasMany(e => e.TBL_ORDER)
                .WithOptional(e => e.TBL_PATIENT)
                .HasForeignKey(e => e.PATIENT_FID);

            modelBuilder.Entity<TBL_SCH_DAY>()
                .HasMany(e => e.TBL_SCHEDULE)
                .WithRequired(e => e.TBL_SCH_DAY)
                .HasForeignKey(e => e.SCH_DAY_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TBL_SCHEDULE>()
                .HasMany(e => e.TBL_APPOINTMENT)
                .WithRequired(e => e.TBL_SCHEDULE)
                .HasForeignKey(e => e.SCH_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TBL_SPECIALIZATION>()
                .HasMany(e => e.TBL_DOCTOR)
                .WithRequired(e => e.TBL_SPECIALIZATION)
                .HasForeignKey(e => e.SP_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TBL_SYMPTOMS>()
                .HasMany(e => e.TBL_DISEASE_SYMPTOM)
                .WithRequired(e => e.TBL_SYMPTOMS)
                .HasForeignKey(e => e.SYMPTOM_FID)
                .WillCascadeOnDelete(false);
        }
    }
}
