using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Project.Models
{
    [Table("news")]
    public class News
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("news_id")]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(250)]
        [Column("news_title")]
        public string Title { get; set; }

        [Column("news_desc")]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        [Column("content")]
        public string Content { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; } = true;

        [Column("is_deleted")]
        public bool IsDeleted { get; set; } = false;

        [Column("created_date")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Column("modified_date")]
        public DateTime? ModifiedDate { get; set; }

        [Column("deleted_date")]
        public DateTime? DeletedDate { get; set; } // Bổ sung missing column

        [Required]
        [Column("created_by")]
        public Guid CreatedBy { get; set; }

        [Column("modified_by")]
        public Guid? ModifiedBy { get; set; }

        [Column("deleted_by")]
        public Guid? DeletedBy { get; set; }

        [Column("date_publish")]
        public DateTime? DatePublish { get; set; }

        [Column("news_list_id")]
        public Guid? NewsListId { get; set; }

        [MaxLength(250)]
        [Column("picture")]
        public string Picture { get; set; }

        [MaxLength(250)]
        [Column("meta_title")]
        public string MetaTitle { get; set; }

        [MaxLength(150)]
        [Column("meta_keyword")]
        public string MetaKeyword { get; set; }

        [Column("news_type")]
        [MaxLength(30)]
        public string NewsType { get; set; } // Chỉnh lại kiểu dữ liệu

        [Column("news_status")]
        [MaxLength(30)]
        public string NewsStatus { get; set; } // Chỉnh lại kiểu dữ liệu

        [Column("views")]
        public int Views { get; set; } = 0;
    }
}
    