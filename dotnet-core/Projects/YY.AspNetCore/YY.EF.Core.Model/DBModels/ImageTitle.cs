namespace YY.EF.Core.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ImageTitle")]
    public partial class ImageTitle
    {
        public int Id { get; set; }

        [Column("ImageTitle")]
        [StringLength(500)]
        public string ImageTitle1 { get; set; }

        public DateTime? CreatTime { get; set; }

        [StringLength(50)]
        public string ImageGroup { get; set; }

        public int? TotalCount { get; set; }

        public DateTime? UpdateTime { get; set; }
    }
}
