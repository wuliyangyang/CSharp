namespace YY.EF.Core.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Xingganmote")]
    public partial class Xingganmote
    {
        public int Id { get; set; }

        [StringLength(500)]
        public string Name { get; set; }

        [StringLength(100)]
        public string ImageId { get; set; }

        [StringLength(300)]
        public string Url { get; set; }

        [Column(TypeName = "image")]
        public byte[] BinaryData { get; set; }

        [StringLength(10)]
        public string Category { get; set; }
    }
}
