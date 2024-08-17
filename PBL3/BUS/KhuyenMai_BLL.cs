using PBL3.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3.BUS
{
    internal class KhuyenMai_BLL
    {
        private static KhuyenMai_BLL _Instance;
        public static KhuyenMai_BLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new KhuyenMai_BLL();
                }
                return _Instance;
            }
            private set { }
        }
        private KhuyenMai_BLL() { }
        public List<Object> GetListKhuyenMai(DateTime tgianbd, DateTime tgiankt, string name)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            var l = db.KhuyenMais.Where(p => p.TenCT.Contains(name) && p.TGBatDau >= tgianbd && p.TGKetThuc <= tgiankt)
                .Select(p => new { p.MaKM, p.TenCT, p.TGBatDau, p.TGKetThuc, p.MoTa, p.GiaTriKM, p.GiaTriDHToiThieu });
            return l.ToList<Object>();
        }

        public List<Object> GetListKhuyenMaiTheoTGian(DateTime BatDau, DateTime KetThuc)
        {
            QuanCaPhePBL3Entities quanCaPhePBL3Entities = new QuanCaPhePBL3Entities();
            List<Object> list = new List<Object>();
            foreach (KhuyenMai i in quanCaPhePBL3Entities.KhuyenMais)
            {
                if ((i.TGBatDau<=BatDau && i.TGKetThuc>BatDau)||(i.TGBatDau>=BatDau && i.TGBatDau<KetThuc)||(i.TGKetThuc==i.TGBatDau && i.TGBatDau==BatDau)||(i.TGBatDau==i.TGKetThuc && i.TGBatDau==KetThuc))
                {
                    list.Add(new
                    {
                        MaKM= i.MaKM,
                        TenCT = i.TenCT,
                        TGBatDau = i.TGBatDau,
                        TGKetThuc = i.TGKetThuc,
                        MoTa = i.MoTa,
                        GiaTriKM = i.GiaTriKM,
                        GiaTriDHToiThieu = i.GiaTriDHToiThieu
                    });
                }
            }
            return list;
        }
        public List<KhuyenMai> GetKMchoKH(KhachHang k, long tien)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            LoaiKhachHang t = KhachHang_BLL.Instance.GetLKH(k);
            var l = t.KhuyenMais.Where(p => p.GiaTriDHToiThieu <= tien).Select(p => p);
            return l.ToList();
        }
        public KhuyenMai GetKMbymaKM(int maKM)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            return db.KhuyenMais.Find(maKM);
        }
        public List<Object> GetAllKM()
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            var l1 = db.KhuyenMais.Select(p => new { p.MaKM, p.TenCT, p.TGBatDau, p.TGKetThuc, p.MoTa, p.GiaTriKM , p.GiaTriDHToiThieu});
            return l1.ToList<Object>();
        }
        public void AddKhuyenMai(string maso, string ten, DateTime BD, DateTime KT, string mota, string gtri)
        {

            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            int maKM = db.KhuyenMais.Count() + 1;
            KhuyenMai s = new KhuyenMai
            {
                MaKM = maKM,
                TenCT = ten,
                TGBatDau = BD,
                TGKetThuc = KT,
                MoTa = mota,
                GiaTriKM = Convert.ToDecimal(gtri)
            };
            db.KhuyenMais.Add(s);
            db.SaveChanges();
        }
        public void EditKhuyenMai(string maso, string tenct, DateTime tgianbd, DateTime tgiankt, string mota, string gtri, string tonghoadon, bool KHTT, bool KHM, bool KH)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            KhuyenMai sedit = db.KhuyenMais.Find(Convert.ToInt32(maso));
            sedit.TenCT = tenct;
            sedit.TGBatDau = tgianbd;
            sedit.TGKetThuc = tgiankt;
            sedit.MoTa = mota;
            sedit.GiaTriKM = Convert.ToDecimal(gtri);
            sedit.GiaTriDHToiThieu = Convert.ToInt32(tonghoadon);

            sedit.LoaiKhachHangs.Clear();
            if (KHTT)
            {
                sedit.LoaiKhachHangs.Add(db.LoaiKhachHangs.Find(1));
            }
            if (KH)
            {
                sedit.LoaiKhachHangs.Add(db.LoaiKhachHangs.Find(3));
            }
            if (KHM)
            {
                sedit.LoaiKhachHangs.Add(db.LoaiKhachHangs.Find(2));
            }
            db.SaveChanges();
        }
        public void DeleteKM(int id)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            KhuyenMai Delete = db.KhuyenMais.Find(id);
            Delete.LoaiKhachHangs.Clear();
            db.KhuyenMais.Remove(Delete);
            db.SaveChanges();
        }
        public void LayThongTinKM(int s, ref string makm, ref string tenct, ref DateTime tgianbd, ref DateTime tgiankt, ref string mota, ref string gtri)
        {
            makm = s.ToString();
            using (QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities())
            {
                foreach (KhuyenMai i in db.KhuyenMais)
                {
                    if (i.MaKM.ToString() == makm)
                    {
                        tenct = i.TenCT;
                        tgianbd = Convert.ToDateTime(i.TGBatDau);
                        tgiankt = Convert.ToDateTime(i.TGKetThuc);
                        mota = i.MoTa;
                        gtri = i.GiaTriKM.ToString();
                    }
                }
            }
        }
        public int Check(string s)
        {
            int d = 0;
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            {
                foreach (KhuyenMai i in db.KhuyenMais)
                {
                    if (i.MaKM.ToString() == s)
                        d += 1;
                    break;
                }
            }
            return d;
        }

        public KhuyenMai GetKhuyenMai(int maKM)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            return db.KhuyenMais.Find(maKM);
        }

        internal void AddKhuyenMai(string ten, string moTa, DateTime startDay, DateTime endDay, decimal GTKM, int GTDHTT, bool KHTT, bool KH, bool KHM)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            int maKM = db.KhuyenMais.Count() + 1;
            KhuyenMai s = new KhuyenMai
            {
                MaKM = maKM,
                TenCT = ten,
                TGBatDau = startDay,
                TGKetThuc = endDay,
                MoTa = moTa,
                GiaTriKM = GTKM,
                GiaTriDHToiThieu = GTDHTT
            };
            if(KHTT)
            {
                s.LoaiKhachHangs.Add(db.LoaiKhachHangs.Find(1));
            }
            if(KH)
            {
                s.LoaiKhachHangs.Add(db.LoaiKhachHangs.Find(3));
            }
            if(KHM)
            {
                s.LoaiKhachHangs.Add(db.LoaiKhachHangs.Find(2));
            }
            db.KhuyenMais.Add(s);
            db.SaveChanges();

        }

        public int getMaKM()
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            return db.KhuyenMais.Count() + 1;
        }
    }
}
