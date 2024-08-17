using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using PBL3.BUS;
using PBL3.DTO;
using PBL3.GUI;

namespace PBL3
{
    internal static class Program
    {
        private static System.Timers.Timer timer;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            CaTruc_BLL.Instance.AddCaTruc();

            // Khởi tạo và thiết lập timer
            timer = new System.Timers.Timer();
            timer.Interval = 300000; // 5 phút
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
            OnTimedEvent(null, null);

           

            Application.EnableVisualStyles();

            Application.Run(new GUI.DangNhap());
            
        }
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            // Xác định thời gian kết thúc ca làm việc
            DateTime endTimeCa1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 0, 0);
            DateTime endTimeCa2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 17, 0, 0);
            DateTime endTimeCa3 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 22, 0, 0);
            // Kiểm tra xem đã đến thời điểm kết thúc ca làm việc chưa
            if (DateTime.Now >= endTimeCa1)
            {
                CaTruc_BLL.Instance.TinhDoanhThuCa(endTimeCa1.ToString("yyyy-MM-dd"), 1);
            }
            if (DateTime.Now >= endTimeCa2)
            {
                CaTruc_BLL.Instance.TinhDoanhThuCa(endTimeCa2.ToString("yyyy-MM-dd"), 2);
            }
            if (DateTime.Now >= endTimeCa3)
            {
                CaTruc_BLL.Instance.TinhDoanhThuCa(endTimeCa3.ToString("yyyy-MM-dd"), 3);
            }
            KhachHang_BLL.Instance.UpdateListKHTT();

        }
    }
}
