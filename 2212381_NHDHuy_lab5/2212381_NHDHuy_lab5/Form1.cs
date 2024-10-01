using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;

namespace _2212381_NHDHuy_lab5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private List<StudentInfo> LoadJSON(string Path)
        {
            List<StudentInfo> List = new List<StudentInfo>();
            StreamReader r = new StreamReader(Path);
            string json = r.ReadToEnd(); // Đọc hết
                                         // Chuyển về thành mảng các đối tượng
            var array = (JObject)JsonConvert.DeserializeObject(json);
            // Lấy đối tượng sinhvien
            var students = array["sinhvien"].Children();
            foreach (var item in students) // Duyệt mảng
            {
                // Lấy các thành phần
                string mssv = item["MSSV"].Value<string>();
                string hoten = item["hoten"].Value<string>();
                int tuoi = item["tuoi"].Value<int>();
                double diem = item["diem"].Value<double>();
                bool tongiao = item["tongiao"].Value<bool>();
                // Chuyển vào đối tượng StudentInfo
                StudentInfo info = new StudentInfo(mssv, hoten, tuoi, diem,
               tongiao);
                List.Add(info);// Thêm vào danh sách
            }
            return List;
        }
        private void btnJSON_Click_Click(object sender, EventArgs e)
        {
           
                string Str = ""; // chuỗi lưu trữ
                string Path = "Z:\\2212381_NHDHuy_lab5\\2212381_NHDHuy_lab5\\JSONExample.json"; // Đường dẫn tập tin
                List<StudentInfo> List = LoadJSON(Path); // Gọi phương thức
                for (int i = 0; i < List.Count; i++) // Đọc danh sách
                {
                    StudentInfo info = List[i];
                    Str += string.Format( "Sinh viên {0} có MSSV: {1}, họ tên: {2},điểm TB: {3}\r\n", (i + 1), info.MSSV, info.HoTen, info.Diem);
                }
                MessageBox.Show(Str);
          
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
