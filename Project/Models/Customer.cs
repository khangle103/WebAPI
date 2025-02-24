using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Project.Models
{
    [Table("customer")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("customer_id")]
        public Guid CustomerId { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("customer_name")]
        public string CustomerName { get; set; }

        [Required]
        [MaxLength(30)]
        [Column("customer_type")]
        public string CustomerType { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("email")]
        public string Email { get; set; }

        [Required]
        [MaxLength(80)]
        [Column("password")]
        public string Password { get; set; }

        [MaxLength(30)]
        [Column("member_type_code")]
        public string MemberTypeCode { get; set; }

        [MaxLength(11)]
        [Column("phone")]
        public string Phone { get; set; }

        [MaxLength(11)]
        [Column("second_phone")]
        public string SecondPhone { get; set; }

        [Column("balance", TypeName = "numeric(18,2)")]
        public decimal Balance { get; set; }

        [MaxLength(250)]
        [Column("address")]
        public string Address { get; set; }

        [MaxLength(10)]
        [Column("province_code")]
        public string ProvinceCode { get; set; }

        [MaxLength(10)]
        [Column("district_code")]
        public string DistrictCode { get; set; }

        [MaxLength(10)]
        [Column("ward_code")]
        public string WardCode { get; set; }

        [Column("date_of_birth")]
        public DateTime? DateOfBirth { get; set; }

        [Column("gender")]
        public int? Gender { get; set; }

        [Column("reward_points")]
        public int? RewardPoints { get; set; }

        [Column("member_points")]
        public int? MemberPoints { get; set; }

        [MaxLength(11)]
        [Column("referral_code")]
        public string ReferralCode { get; set; }

        [MaxLength(16)]
        [Column("customer_code")]
        public string CustomerCode { get; set; }

        [MaxLength(250)]
        [Column("citizen_id_pic_front")]
        public string CitizenIdPicFront { get; set; }

        [MaxLength(250)]
        [Column("citizen_id_pic_back")]
        public string CitizenIdPicBack { get; set; }

        [Column("is_active")]
        [DefaultValue(true)]
        public bool IsActive { get; set; } = true;

        [Column("is_deleted")]
        [DefaultValue(false)]
        public bool IsDeleted { get; set; } = false;

        [Column("is_lock")]
        [DefaultValue(false)]
        public bool IsLock { get; set; } = false;

        [Column("lock_until")]
        public DateTime? LockUntil { get; set; }

        [MaxLength(250)]
        [Column("lock_reason")]
        public string LockReason { get; set; }

        [Column("verified")]
        public bool Verified { get; set; }

        [MaxLength(30)]
        [Column("account_type")]
        public string AccountType { get; set; }

        [MaxLength(30)]
        [Column("approval_status")]
        public string ApprovalStatus { get; set; }

        [Column("membership_id")]
        public Guid? MembershipId { get; set; }

        [Column("avatar")]
        public string Avatar { get; set; }

        [Column("created_date")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Column("modified_date")]
        public DateTime? ModifiedDate { get; set; }

        [Column("deleted_date")]
        public DateTime? DeletedDate { get; set; }

        [Column("created_by")]
        public Guid CreatedBy { get; set; }

        [Column("modified_by")]
        public Guid? ModifiedBy { get; set; }

        [Column("deleted_by")]
        public Guid? DeletedBy { get; set; }
    }
}
