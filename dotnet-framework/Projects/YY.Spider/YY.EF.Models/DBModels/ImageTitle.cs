namespace YY.EF.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ImageTitle")]
    public partial class ImageTitle
    {
        public int Id { get; set; }

        [Column("ImageTitle")]
        [StringLength(500)]
        public string ImageTitle1 { get; set; }

        public DateTime? CreatTime { get; set; }
    }
}
