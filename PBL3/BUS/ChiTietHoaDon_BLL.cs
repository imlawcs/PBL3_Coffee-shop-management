using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using PBL3.DTO;

namespace PBL3.BUS
{
    internal class ChiTietHoaDon_BLL
    {
        private static ChiTietHoaDon_BLL _Instance;
        public static ChiTietHoaDon_BLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ChiTietHoaDon_BLL();
                }
                return _Instance;
            }
            private set { }
        }
        private ChiTietHoaDon_BLL() { }

        public List<ChiTietHoaDon> GetListChiTietHoaDon()
        {
            QuanCaPhePBL3Entities quanCaPheEntities = new QuanCaPhePBL3Entities();
            return quanCaPheEntities.ChiTietHoaDons.ToList();
        }

        public List<ChiTietHoaDon> GetListChiTietHoaDonById(int maHD)
        {
            QuanCaPhePBL3Entities quanCaPhePBL3Entities = new QuanCaPhePBL3Entities();
            List<ChiTietHoaDon> listChiTietHD = quanCaPhePBL3Entities.ChiTietHoaDons.ToList();
            List<ChiTietHoaDon> listChiTietHDById = new List<ChiTietHoaDon>();  
            for(int i = 0; i < listChiTietHD.Count; i++)
            {
                if (listChiTietHD[i].MaHD == maHD)
                {
                    listChiTietHDById.Add(listChiTietHD[i]);
                }
            }
            return listChiTietHDById;
        }

        public ChiTietHoaDon GetChiTietHoaDon(int maHD, int maSP)
        {
            QuanCaPhePBL3Entities quanCaPhePBL3Entities = new QuanCaPhePBL3Entities();
            List<ChiTietHoaDon> listChiTietHD = GetListChiTietHoaDonById(maHD);
            for (int i = 0; i < listChiTietHD.Count; i++)
            {
                if (listChiTietHD[i].MaSP == maSP)
                {
                    return listChiTietHD[i];
                }
            }
            return null;
        }
        public void Add_1_ChiTietHoaDon(int MaHD, int MaBan, int MaNV, int MaSP, int MaKM, int SLSP)
        {
            ChiTietHoaDon cthd = new ChiTietHoaDon
            {
                MaHD = MaHD,
                MaBan = MaBan,
                MaNV = MaNV,
                MaSP = MaSP,
                MaKM = MaKM,
                SoLuongSP = SLSP
            };
            QuanCaPhePBL3Entities quanCaPheEntities = new QuanCaPhePBL3Entities();
            quanCaPheEntities.ChiTietHoaDons.Add(cthd);
            quanCaPheEntities.SaveChanges();
        }
        //add ChiTietHoaDon của 1 hóa đơn
        public void AddChiTietHoaDon(int MaHD, int MaBan, int MaNV, int[] MaSP, int MaKM, int[] SLSP) 
        {
            QuanCaPhePBL3Entities quanCaPheEntities = new QuanCaPhePBL3Entities();
            ChiTietHoaDon cthd = new ChiTietHoaDon();
            cthd.MaHD = MaHD;
            cthd.MaBan = MaBan;
            cthd.MaNV = MaNV;
            cthd.MaKM = MaKM;
            for(int i = 0; i < MaSP.Length; i++)
            {
                cthd.MaSP = MaSP[i];
                cthd.SoLuongSP = SLSP[i];
                quanCaPheEntities.ChiTietHoaDons.Add(cthd);
                quanCaPheEntities.SaveChanges();
            }
        }

        public void DelChiTietHoaDon(int MaHD, int MaSP)
        {
            QuanCaPhePBL3Entities quanCaPheEntities = new QuanCaPhePBL3Entities();
            List<ChiTietHoaDon> listCTHD = quanCaPheEntities.ChiTietHoaDons.ToList();
            for (int j = 0; j < listCTHD.Count; j++)
            {
                if (listCTHD[j].MaHD == MaHD && listCTHD[j].MaSP == MaSP)
                {
                    quanCaPheEntities.ChiTietHoaDons.Remove(listCTHD[j]);
                    quanCaPheEntities.SaveChanges();
                    break;
                }
            }
        }

        public void DelChiTietHoaDon(int MaHD)
        {
            QuanCaPhePBL3Entities quanCaPheEntities = new QuanCaPhePBL3Entities();
            List<ChiTietHoaDon> listCTHD = quanCaPheEntities.ChiTietHoaDons.ToList();
            for (int j = 0; j < listCTHD.Count; j++)
            {
                if (listCTHD[j].MaHD == MaHD)
                {
                    quanCaPheEntities.ChiTietHoaDons.Remove(listCTHD[j]);
                    quanCaPheEntities.SaveChanges();
                }
            }
        }

        public void UpdateChiTietHoaDon(int MaHD, int MaSP, int SoLuongSP, int Ban, int KhuyenMai, int MaNV)
        {
            QuanCaPhePBL3Entities quanCaPheEntities = new QuanCaPhePBL3Entities();
            List<ChiTietHoaDon> listCTHD = quanCaPheEntities.ChiTietHoaDons.ToList();
            for (int i = 0; i < listCTHD.Count; i++)
            {
                if (listCTHD[i].MaHD == MaHD && listCTHD[i].MaSP == MaSP)
                {
                    listCTHD[i].SoLuongSP = SoLuongSP;
                    listCTHD[i].MaBan = Ban;
                    listCTHD[i].MaKM = KhuyenMai;
                    listCTHD[i].MaNV = MaNV;
                    quanCaPheEntities.SaveChanges();
                }
            }
        }

        public List<ChiTietHoaDon> GetListChiTietHoaDonByMaHD(int MaHD)
        {
            QuanCaPhePBL3Entities quanCaPheEntities = new QuanCaPhePBL3Entities();
            List<ChiTietHoaDon> listCTHD = quanCaPheEntities.ChiTietHoaDons.ToList();
            List<ChiTietHoaDon> listCTHDByMaHD = new List<ChiTietHoaDon>();
            for (int i = 0; i < listCTHD.Count; i++)
            {
                if (listCTHD[i].MaHD == MaHD)
                {
                    listCTHDByMaHD.Add(listCTHD[i]);
                }
            }
            return listCTHDByMaHD;
        }

        public List<Object> GetListObjectCTHDByMaHD(int MaHD)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            List<ChiTietHoaDon> listCTHD = db.ChiTietHoaDons.ToList();
            List<Object> res = new List<Object>();
            foreach (ChiTietHoaDon cthd in listCTHD)
            {
                if (cthd.MaHD == MaHD)
                {
                    res.Add(new { cthd.MaSP, cthd.SanPham.TenSP, cthd.SoLuongSP, cthd.SanPham.GiaSP, cthd.SanPham.LoaiSP, cthd.SanPham.NhomSP});
                }
            }
            return res;
        }
    }
}
