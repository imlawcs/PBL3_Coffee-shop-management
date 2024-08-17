using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3.DTO
{
    public class SelectedDrink
    {
        public int MaSP { get; set; }
        public string TenMon { get; set; }
        public string LoaiSP { get; set; }
        public int SoLuong { get; set; }
        public long GiaSP { get; set; }
        public SelectedDrink(SelectedDrink i)
        {
            MaSP = i.MaSP;
            TenMon = i.TenMon;
            LoaiSP = i.LoaiSP;
            SoLuong = i.SoLuong;
            GiaSP = i.GiaSP;
        }
        public SelectedDrink()
        {
            // Khởi tạo các thuộc tính mặc định
            MaSP = 0;
            TenMon = "";
            LoaiSP = "";
            SoLuong = 0;
            GiaSP = 0;
        }
    }
}
