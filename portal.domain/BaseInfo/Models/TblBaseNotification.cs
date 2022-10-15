// using System;
// using System.Collections.Generic;
// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;
// using Microsoft.EntityFrameworkCore;

// namespace portal.infrastructure.Models
// {
//     [Table("tbl_base_notification")]
//     [Index("NotifierGroupId", Name = "tbl_base_notification_notifier_group_id_fbdda524")]
//     [Index("NotifierUserId", Name = "tbl_base_notification_notifier_user_id_3230b9b6")]
//     public partial class TblBaseNotification
//     {
//         [Key]
//         [Column("id")]
//         public int Id { get; set; }
//         [Column("type")]
//         public short? Type { get; set; }
//         [Column("title")]
//         [StringLength(50)]
//         public string Title { get; set; } = null!;
//         [Column("description")]
//         [StringLength(500)]
//         public string Description { get; set; } = null!;
//         [Column("created_date", TypeName = "date")]
//         public DateTime CreatedDate { get; set; }
//         [Column("expired_date", TypeName = "date")]
//         public DateTime ExpiredDate { get; set; }
//         [Column("read_status")]
//         public bool? ReadStatus { get; set; }
//         [Column("notifier_group_id")]
//         public int? NotifierGroupId { get; set; }
//         [Column("notifier_user_id")]
//         public int? NotifierUserId { get; set; }

//         [ForeignKey("NotifierUserId")]
//         [InverseProperty("TblBaseNotifications")]
//         public virtual AuthUser? NotifierUser { get; set; }
//     }
// }
