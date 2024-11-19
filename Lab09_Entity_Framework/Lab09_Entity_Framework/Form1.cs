using Lab09_Entity_Framework.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab09_Entity_Framework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private List<Category> GetCategories()
        {
            //khởi tạo đối tượng context
            var dbContext = new RestaurantContext();
            // Lấy danh sách tất cả nhóm thức ăn, sắp xếp theo tên 
            return dbContext.Category.OrderBy(x=>x.Name).ToList();
        }

        private void ShowCategory()
        {
            //Xóa tất cả các nút hiện có trên cây
            tvwCategory.Nodes.Clear();
            //Tạo danh sách loại nhóm thức ăn, đồ uống
            //Tên của các loại này được hiển thị trên các nút mức 2 
            var cateMap = new Dictionary<CategoryType, string>()
            {
                [CategoryType.Food]="Đồ ăn",
                [CategoryType.Drink]="Đồ uống"
            };
            // Tạo nút gốc ở cây
            var rootNode = tvwCategory.Nodes.Add("Tất cả");
            //Lấy danh sách nhóm đồ ăn, thức uống
            var categories = GetCategories();
            //Duyệt qua các loại nhóm thức ăn
            foreach (var cateType in cateMap)
            {
                //Tạo các nút tương ứng với loại nhóm thức ăn
                var childNode = rootNode.Nodes.Add(cateType.Key.ToString(), cateType.Value);
                childNode.Tag = cateType.Key;

                //Duyệt qua các nhóm thức ăn
                foreach (var category in categories)
                {
                    //Nếu nhóm đang xét không cùng loại thì bỏ qua
                    if (category.Type != cateType.Key) continue;
                    //Ngược lại, tạo các nút tương ứng trên cây 
                    var grantChildNode = childNode.Nodes.Add(category.Id.ToString(),category.Name);
                    grantChildNode.Tag = category;
                }
            }

            //Mở rộng các nhánh của cây để thấy hết tất cả các nhóm thức ăn
            tvwCategory.ExpandAll();
            //Đánh dấu nút gốc đang được chọn
            tvwCategory.SelectedNode = rootNode;
        }

        private List<FoodModel> GetFoodByCategory(int? categoryId)
        {
            //khởi tạo đối tượng context
            var dbContext = new RestaurantContext();
            // tạo truy vấn lấy danh sách món ăn 
            var foods = dbContext.Foods.AsQueryable();

            //Nếu mã nhóm món ăn khác null và hợp lệ 
            if(categoryId != null && categoryId > 0 )
            {
                //Thì tìm theo mã số nhóm thức ăn
                foods= foods.Where(x=>x.FoodCategoryId== categoryId);
            }
            //sắp xếp đồ ăn, thức uống theo tên và trả về 
            //danh sách chứa đầy đủ thông tin về món ăn 
            return foods 
                .OrderBy(x=> x.Name)
                .Select(x=> new FoodModel()
                { 
                   Id = x.Id,
                   Name = x.Name,
                   Unit = x.Unit,
                   Price = x.Price,
                   Notes = x.Notes,
                   CategoryName = x.Category.Name,
                })
                .ToList();
        }

        private List<FoodModel> GetFoodByCategoryType(CategoryType cateType)
        {
            var dbContext = new RestaurantContext();
            //Tìm các món ăn theo loại nhóm thức ăn (Category Type).
            //Sắp xếp đồ ăn, thức uống theo tên và trả về
            //danh sách chứa đầy đủ thông tin về món ăn.
            return dbContext.Foods
                .Where(x=>x.Category.Type== cateType)
                .OrderBy(x=>x.Name)
                .Select(x=> new FoodModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Unit = x.Unit,
                    Price = x.Price,
                    Notes = x.Notes,
                    CategoryName = x.Category.Name,
                })
                .ToList();
        }

        private void ShowFoodsForNode(TreeNode node)
        {
            //Xóa danh sách thực đơn hiện tại khỏi ListView
            lvwFood.Items.Clear();

            //Nếu node= null, không cần xử lý gì thêm
            if (node == null)  return;

            //Tạo danh sách để chứa danh sách các món ăn tìm được
            List<FoodModel> foods = null;

            //Nếu nút được chọn TreeView tương ứng với 
            //loại nhóm thức ăn(Category Type)(mức thứ 2 trên cây)
            if (node.Level==1)
            {
                //Thì lấy danh sách món ăn theo loại món
                var categoryType =(CategoryType)node.Tag;
                foods = GetFoodByCategoryType(categoryType);
            }    
            else
            {
                //Ngược lại, lấy danh sách món ăn theo thể loại
                //Nếu nút được chọn là 'Tất cả' thì lấy hế
                var category = node.Tag as Category;
                foods = GetFoodByCategory(category?.Id);
            }


            //Gọi hàm để hiển thị các món ăn lên ListView
            ShowFoodsOnListView(foods);
        }

        private void ShowFoodsOnListView(List<FoodModel> foods)
        {
            foreach (var foodItem in foods)
            {
                //Tạo Item tương ứng trên listView
                var item=lvwFood.Items.Add(foodItem.Id.ToString());
                //và hiển thị các thông tin của món ăn
                item.SubItems.Add(foodItem.Name);
                item.SubItems.Add(foodItem.Unit);
                item.SubItems.Add(foodItem.Price.ToString("##,###"));
                item.SubItems.Add(foodItem.CategoryName);
                item.SubItems.Add(foodItem.Notes);
            }    
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ShowCategory();
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            
        }

        private void btnReloadCategory_Click(object sender, EventArgs e)
        {
            ShowCategory();
        }

        private void tvwCategory_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ShowFoodsForNode(e.Node);
        }
    }
}
