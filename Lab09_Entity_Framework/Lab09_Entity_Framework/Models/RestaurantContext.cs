using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab09_Entity_Framework.Models
{
    public class RestaurantContext : DbContext
    {
        //Tham chiếu tới các nhóm món ăn trong bản Category
        public DbSet<Category> Category { get; set; }

        //Tham chiếu tới các món ăn, đồ uống trong bảng Food
        public DbSet<Food> Foods { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Xóa bỏ các quy tắc sử dụng danh từ số nhiều cho tên bảng
            //Lúc này, thuộc tính Categories ánh xạ tới bảng Category trong Db
            //Và thuộc tính Foods tương ứng với bảng Food trong cơ sở dữ liệu 
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();

            //Định nghĩa mối quan hệ một chiều giữa hai bảng Category và Food
            modelBuilder.Entity<Food>()
                .HasRequired(x => x.Category)
                .WithMany()
                .HasForeignKey(x => x.FoodCategoryId)
                .WillCascadeOnDelete(true);

        }
    }
}
