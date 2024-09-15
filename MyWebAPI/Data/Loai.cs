    using System.ComponentModel.DataAnnotations;

    namespace MyWebAPI.Data
    {
        public class Loai
        {
            [Key]
            public int MaLoai { get; set; }


            [Required]
            [MaxLength(50)]
            public String TenLoai { get; set; }

            public virtual ICollection<HangHoa> HangHoas { get; set; }

    

        }
    }
