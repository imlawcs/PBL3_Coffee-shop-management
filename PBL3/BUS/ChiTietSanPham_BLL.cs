using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBL3.DTO;

namespace PBL3.BUS
{
    internal class ChiTietSanPham_BLL
    {
        private static ChiTietSanPham_BLL _Instance;
        public static ChiTietSanPham_BLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ChiTietSanPham_BLL();
                }
                return _Instance;
            }
            private set { }
        }
        private ChiTietSanPham_BLL() { }

        public List<ChiTietSanPham> GetListChiTietSanPham()
        {
            QuanCaPhePBL3Entities quanCaPheEntities = new QuanCaPhePBL3Entities();
            return quanCaPheEntities.ChiTietSanPhams.ToList();
        }

        public List<ChiTietSanPham> GetListChiTietSanPhamByMaSP(int MaSP)
        {
            QuanCaPhePBL3Entities quanCaPheEntities = new QuanCaPhePBL3Entities();
            List<ChiTietSanPham> listCTSP = quanCaPheEntities.ChiTietSanPhams.ToList();
            List<ChiTietSanPham> listCTSPByMaSP = new List<ChiTietSanPham>();
            for (int i = 0; i < listCTSP.Count; i++)
            {
                if (listCTSP[i].MaSP == MaSP)
                {
                    listCTSPByMaSP.Add(listCTSP[i]);
                }
            }
            return listCTSPByMaSP;
        }

        public ChiTietSanPham GetChiTietSanPham(int MaSP, int MaNL)
        {
            QuanCaPhePBL3Entities quanCaPheEntities = new QuanCaPhePBL3Entities();
            List<ChiTietSanPham> listCTSP = quanCaPheEntities.ChiTietSanPhams.ToList();
            for (int i = 0; i < listCTSP.Count; i++)
            {
                if (listCTSP[i].MaSP == MaSP && listCTSP[i].MaNL == MaNL)
                {
                    return listCTSP[i];
                }
            }
            return null;
        }

        public void AddChiTietSanPham(int MaSP, int MaNL, decimal SLNL)
        {
            QuanCaPhePBL3Entities quanCaPheEntities = new QuanCaPhePBL3Entities();
            ChiTietSanPham ctsanpham = new ChiTietSanPham();
            ctsanpham.MaSP = MaSP;
            ctsanpham.MaNL = MaNL;
            ctsanpham.SLNguyenLieu = SLNL;
            quanCaPheEntities.ChiTietSanPhams.Add(ctsanpham);
            quanCaPheEntities.SaveChanges();
        }
        public void AddChiTietSanPhamFromListNL(int MaSP, List<int> MaNL, List<decimal> SLNL)
        {
            QuanCaPhePBL3Entities quanCaPheEntities = new QuanCaPhePBL3Entities();
            for (int i = 0; i < MaNL.Count; i++)
            {
                ChiTietSanPham ctsanpham = new ChiTietSanPham();
                ctsanpham.MaSP = MaSP;
                ctsanpham.MaNL = MaNL[i];
                ctsanpham.SLNguyenLieu = SLNL[i];
                quanCaPheEntities.ChiTietSanPhams.Add(ctsanpham);
                quanCaPheEntities.SaveChanges();
            }
        }

        public void DelChiTietSanPham(int MaSP, int MaNL)
        {
            QuanCaPhePBL3Entities quanCaPheEntities = new QuanCaPhePBL3Entities();
            List<ChiTietSanPham> listCTSP = quanCaPheEntities.ChiTietSanPhams.ToList();
            for (int j = 0; j < listCTSP.Count; j++)
            {
                if (listCTSP[j].MaSP == MaSP && listCTSP[j].MaNL == MaNL)
                {
                    quanCaPheEntities.ChiTietSanPhams.Remove(listCTSP[j]);
                    quanCaPheEntities.SaveChanges();
                    break;
                }
            }
        }

        public void DelChiTietSanPhamFromOneSP(int MaSP)
        {
            QuanCaPhePBL3Entities quanCaPhePBL3Entities = new QuanCaPhePBL3Entities();
            List<ChiTietSanPham> listCTSP = quanCaPhePBL3Entities.ChiTietSanPhams.ToList();
            for (int j = 0; j < listCTSP.Count; j++)
            {
                if (listCTSP[j].MaSP == MaSP)
                {
                    quanCaPhePBL3Entities.ChiTietSanPhams.Remove(listCTSP[j]);
                    quanCaPhePBL3Entities.SaveChanges();
                }
            }
        }

        public void UpdateChiTietSanPham(int MaSP, int MaNL, decimal SLNL)
        {
            QuanCaPhePBL3Entities quanCaPheEntities = new QuanCaPhePBL3Entities();
            List<ChiTietSanPham> listCTSP = quanCaPheEntities.ChiTietSanPhams.ToList();
            for (int j = 0; j < listCTSP.Count; j++)
            {
                if (listCTSP[j].MaSP == MaSP && listCTSP[j].MaNL == MaNL)
                {
                    listCTSP[j].SLNguyenLieu = SLNL;
                    quanCaPheEntities.SaveChanges();
                    break;
                }
            }
        }
    }
}
