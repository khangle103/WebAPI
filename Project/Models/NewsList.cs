using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    [Table("news_list")]
    public class NewsList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("news_list_id")]
        public Guid NewsListId { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("news_list_name")]
        public string NewsListName { get; set; }

        [Column("sort")]
        public int? Sort { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; } = true;

        [Column("is_deleted")]
        public bool IsDeleted { get; set; } = false;

        [Column("created_date")]
        public DateTime? CreatedDate { get; set; }

        [Column("modified_date")]
        public DateTime? ModifiedDate { get; set; }

        [Column("deleted_date")]
        public DateTime? DeletedDate { get; set; }

        [Column("created_by")]
        public Guid? CreatedBy { get; set; }

        [Column("modified_by")]
        public Guid? ModifiedBy { get; set; }

        [Column("deleted_by")]
        public Guid? DeletedBy { get; set; }
    }
}
