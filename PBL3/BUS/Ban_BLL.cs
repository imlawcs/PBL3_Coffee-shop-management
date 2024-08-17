using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBL3.DTO;

namespace PBL3.BUS
{
    internal class Ban_BLL
    {
        private static Ban_BLL _Instance;
        public static Ban_BLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Ban_BLL();
                }
                return _Instance;
            }
            private set { }
        }
        private Ban_BLL() { }

        public List<Object> GetListBan()
        {
            QuanCaPhePBL3Entities quanCaPheEntities = new QuanCaPhePBL3Entities();
            List<Ban> list2 = quanCaPheEntities.Bans.ToList();
            var l1 = from p in list2 select new { p.MaBan, p.TrangThai, p.ViTri, p.SDT};
            return l1.ToList<Object>();
        }

        public List<Object> GetBanByID(int MaBan)
        {
            QuanCaPhePBL3Entities quanCaPheEntities = new QuanCaPhePBL3Entities();
            List<Ban> list2 = quanCaPheEntities.Bans.ToList();
            var l1 = from p in list2 where p.MaBan == MaBan select new { p.MaBan, p.TrangThai, p.ViTri };
            return l1.ToList<Object>();
        }
        public Ban GetbanBySDT(string sdt)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            return db.Bans.Where(p => p.SDT == sdt).FirstOrDefault();
        }
        public int GetTrangThaiBan(int MaBan)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            Ban ban = db.Bans.Find(MaBan);
            if(ban.TrangThai == "Bàn trống")
            {
                return 0;
            }
            else if(ban.TrangThai=="Bàn bận")
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }
        public Ban GetBan(int MaBan)
        {
            QuanCaPhePBL3Entities quanCaPheEntities = new QuanCaPhePBL3Entities();
            Ban ban = quanCaPheEntities.Bans.Find(MaBan);
            return ban;
        }
        public List<Object> GetListBanFree()
        {
            QuanCaPhePBL3Entities quanCaPhePBL3Entities = new QuanCaPhePBL3Entities();
            List<Ban> list2 = quanCaPhePBL3Entities.Bans.ToList();
            var l1 = from p in list2 where p.TrangThai == "Bàn trống" select new { p.MaBan, p.TrangThai, p.ViTri };
            return l1.ToList<Object>();
        }
        public void Changesdt(int maBan, string sdt)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            Ban i = db.Bans.Find(maBan);
            i.SDT = sdt;
            db.SaveChanges();
        }
        public void AddBan(Ban b)
        {
            QuanCaPhePBL3Entities quanCaPheEntities = new QuanCaPhePBL3Entities();
            quanCaPheEntities.Bans.Add(b);
            quanCaPheEntities.SaveChanges();
        }
        public void EditBan(Ban b)
        {
            QuanCaPhePBL3Entities quanCaPheEntities = new QuanCaPhePBL3Entities();
            Ban banEdit = quanCaPheEntities.Bans.Find(b.MaBan);
            banEdit.TrangThai = b.TrangThai;
            banEdit.ViTri = b.ViTri;
            quanCaPheEntities.SaveChanges();
        }

        public void EditBan(int MaBan, string TrangThai)
        {
            QuanCaPhePBL3Entities quanCaPheEntities = new QuanCaPhePBL3Entities();
            Ban banEdit = quanCaPheEntities.Bans.Find(MaBan);
            banEdit.TrangThai = TrangThai;
            quanCaPheEntities.SaveChanges();
        }

        public void EditBan(int MaBan, string TrangThai, string sdt)
        {
            QuanCaPhePBL3Entities quanCaPheEntities = new QuanCaPhePBL3Entities();
            Ban banEdit = quanCaPheEntities.Bans.Find(MaBan);
            banEdit.TrangThai = TrangThai;
            banEdit.SDT =sdt;
            quanCaPheEntities.SaveChanges();
            

        }
        public void DeleteBan(int id)
        {
            QuanCaPhePBL3Entities quanCaPheEntities = new QuanCaPhePBL3Entities();
            Ban banDelete = quanCaPheEntities.Bans.Find(id);
            quanCaPheEntities.Bans.Remove(banDelete);
            quanCaPheEntities.SaveChanges();
        }
    }
}
