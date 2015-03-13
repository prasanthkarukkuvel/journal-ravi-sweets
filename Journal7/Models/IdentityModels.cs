using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Journal7.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public DbSet<Journal> Journals { get; set; }
        public DbSet<Stock> Stocks { get; set; }
    }

    public class AppIntilizer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {

    }

    public class DateTimeStamp
    {
        [Required, DataType(DataType.Date), ScaffoldColumn(false)]
        public DateTime CreatedAt { get; set; }
        [Required, DataType(DataType.Date), ScaffoldColumn(false)]
        public DateTime UpdatedAt { get; set; }
        [Timestamp, ScaffoldColumn(false)]
        public Byte[] TimeStamp { get; set; }
        [Required, ScaffoldColumn(false)]
        public bool ActiveFlag { get; set; }
    }

    public class AppBaseStamp : DateTimeStamp
    {
        [Key, Column(Order = 1), Required, MaxLength(40), ScaffoldColumn(false)]
        public string Key { get; set; }
        [Required, ScaffoldColumn(false)]
        public string UserCreated { get; set; }
        [Required, ScaffoldColumn(false)]
        public string UserModified { get; set; }
    }

    public class Particulars : AppBaseStamp
    {
        [Required, MaxLength(50), Index(IsUnique = true)]
        public string Name { get; set; }
    }

    public class MetaBase : AppBaseStamp
    {
        [Required]
        public DateTime Date { get; set; }

        public string Comments { get; set; }
    }

    public class Journal : MetaBase
    {        
        public virtual ICollection<JournalEntry> JournalEntries { get; set; }
    }

    public class JournalEntry : AppBaseStamp
    {
        [Required, Range(typeof(double), "0", "2147483647")]
        public double Credit { get; set; }

        [Required, Range(typeof(double), "0", "2147483647")]
        public double Debit { get; set; }

        [Required]
        public virtual Particulars Particulars { get; set; }
    }

    public class Stock : MetaBase
    {
        public virtual ICollection<StockEntry> StockEntries { get; set; }
    }

    public class StockEntry : AppBaseStamp
    {
        [Required, Range(typeof(double), "0", "2147483647")]
        public double Quantity { get; set; }

        [Required]
        public virtual Particulars Particulars { get; set; }
    }
}