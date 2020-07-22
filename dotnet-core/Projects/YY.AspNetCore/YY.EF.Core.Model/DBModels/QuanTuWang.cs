namespace YY.EF.Core.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("QuanTuWang")]
    public partial class QuanTuWang
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Url { get; set; }

        [StringLength(100)]
        public string ImgSrc { get; set; }

        [Column(TypeName = "image")]
        public byte[] BinaryData { get; set; }

        [StringLength(20)]
        public string Category { get; set; }
    }
}
