namespace CinemaSite.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CategoryFilm")]
    public partial class CategoryFilm
    {
        [Key]
        [Column(Order = 0)]
        public Guid FilmId { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid CategoryId { get; set; }
    }
}
