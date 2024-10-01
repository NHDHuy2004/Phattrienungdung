using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;

namespace _2212381_NHDHuy_lab5
{
    internal class StudentInfo
    {

        //Các thuộc tính
        public string MSSV {  get; set; }
        public string HoTen { get; set; }
        public int Tuoi { get; set; }
        public double Diem {  get; set; }
        public bool TonGiao { get; set; }

        //Phương pháp tạo lập
        public StudentInfo(string mssv, string hoten, int tuoi, double diem,bool tongiao)
        {
            this.MSSV = mssv;
            this.HoTen = hoten;
            this.Tuoi = tuoi;
            this.Diem = diem;   
            this.TonGiao = tongiao;
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
    }


}
