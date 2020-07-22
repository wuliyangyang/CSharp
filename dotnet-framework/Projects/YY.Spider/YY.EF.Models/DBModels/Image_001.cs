namespace YY.EF.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    //[Table("Image_001")]
    public partial class Image_001
    {
        public int Id { get; set; }

        [StringLength(500)]
        public string Name { get; set; }

        [StringLength(100)]
        public string ImageId { get; set; }

        [StringLength(200)]
        public string Url { get; set; }

        [Column(TypeName = "image")]
        public byte[] BinaryData { get; set; }
    }
}
