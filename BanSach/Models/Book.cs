namespace BanSach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        
        public int ID { get; set; }

        [StringLength(100,ErrorMessage ="Tiêu đề không được quá 100 kí tự!")]
        [Required(ErrorMessage ="Tiêu đề không được để trống")]
        public string Tittle { get; set; }

        //[StringLength(50)]
        [Required(ErrorMessage = "Mô tả không được để trống")]
        public string Description { get; set; }

        [StringLength(30,ErrorMessage ="Tác giả không được quá 30 kí tự!")]
        [Required(ErrorMessage = "Tắc giả không được để trống")]
        public string Author { get; set; }

        [StringLength(10)]
        [Required(ErrorMessage = "Hình ảnh không được để trống")]
        public string Image { get; set; }
        [Required(ErrorMessage = "Giá sách không được để trống")]
        [Range(1000,1000000,ErrorMessage ="Giá sách từ 1000 đến 1000000")]
        public int? Price { get; set; }
    }
}
