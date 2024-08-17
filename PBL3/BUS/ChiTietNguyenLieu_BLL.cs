using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBL3.DTO;

namespace PBL3.BUS
{
    internal class ChiTietNguyenLieu_BLL
    {
        private static ChiTietNguyenLieu_BLL _Instance;
        public static ChiTietNguyenLieu_BLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ChiTietNguyenLieu_BLL();
                }
                return _Instance;
            }
            private set { }
        }
        private ChiTietNguyenLieu_BLL() { }

        public List<ChiTietNguyenLieu> GetListChiTietNguyenLieu()
        {
            QuanCaPhePBL3Entities quanCaPheEntities = new QuanCaPhePBL3Entities();
            return quanCaPheEntities.ChiTietNguyenLieux.ToList();
        }

        public ChiTietNguyenLieu GetChiTietNguyenLieu(int MaNL, DateTime NgayNhap)
        {
            QuanCaPhePBL3Entities quanCaPheEntities = new QuanCaPhePBL3Entities();
            List<ChiTietNguyenLieu> listCTNL = quanCaPheEntities.ChiTietNguyenLieux.ToList();
            for (int i = 0; i < listCTNL.Count; i++)
            {
                if (listCTNL[i].MaNL == MaNL && listCTNL[i].NgayNhap == NgayNhap)
                {
                    return listCTNL[i];
                }
            }
            return null;
        }   

        public List<ChiTietNguyenLieu> GetChiTietNguyenLieuByMaNL(int MaNL)
        {
            QuanCaPhePBL3Entities quanCaPheEntities = new QuanCaPhePBL3Entities();
            List<ChiTietNguyenLieu> listCTNL = quanCaPheEntities.ChiTietNguyenLieux.ToList();
            List<ChiTietNguyenLieu> listCTNLByMaNL = new List<ChiTietNguyenLieu>();
            for (int i = 0; i < listCTNL.Count; i++)
            {
                if (listCTNL[i].MaNL == MaNL)
                {
                    listCTNLByMaNL.Add(listCTNL[i]);
                }
            }
            return listCTNLByMaNL;
        }   
        public bool ValidAdd(int MaNL, string NgayNhap)
        {
            QuanCaPhePBL3Entities quanCaPhePBL3Entities = new QuanCaPhePBL3Entities();
            List<ChiTietNguyenLieu> listCTNL = quanCaPhePBL3Entities.ChiTietNguyenLieux.ToList();
            for (int i = 0; i < listCTNL.Count; i++)
            {
                if (listCTNL[i].MaNL == MaNL && listCTNL[i].NgayNhap.ToString("yyyy-MM-dd") == NgayNhap)
                {
                    return false;
                }
            }
            return true;
        }
        public void AddChiTietNguyenLieu(int MaNL, DateTime NgayNhap, int SLNhap, DateTime NgayHetHan, int giaNhap)
        {
            QuanCaPhePBL3Entities quanCaPheEntities = new QuanCaPhePBL3Entities();
            ChiTietNguyenLieu ctnl = new ChiTietNguyenLieu();
            ctnl.MaNL = MaNL;
            ctnl.NgayNhap = NgayNhap;
            ctnl.SLNhap = SLNhap;
            ctnl.NgayHetHan = NgayHetHan;
            ctnl.GiaNhap = giaNhap;
            quanCaPheEntities.ChiTietNguyenLieux.Add(ctnl);
            quanCaPheEntities.SaveChanges();

            NguyenLieu nl = NguyenLieu_BLL.Instance.GetNguyenLieu(MaNL);
            nl.SLTonKho += SLNhap;
            NguyenLieu_BLL.Instance.EditNguyenLieu(MaNL.ToString(), nl.TenNL, nl.SLTonKho.ToString(), nl.DonViTinh);
        }

        public void UpdateChiTietNguyenLieu(int MaNL, DateTime NgayNhap, int SLNhap)
        {
            QuanCaPhePBL3Entities quanCaPheEntities = new QuanCaPhePBL3Entities();
            List<ChiTietNguyenLieu> listCTNL = quanCaPheEntities.ChiTietNguyenLieux.ToList();
            for (int j = 0; j < listCTNL.Count; j++)
            {
                if (listCTNL[j].MaNL == MaNL && listCTNL[j].NgayNhap == NgayNhap)
                {
                    listCTNL[j].SLNhap = SLNhap;
                    quanCaPheEntities.SaveChanges();
                    break;
                }
            }
        }

        public void DelChiTietNguyenLieu(int MaNL, DateTime NgayNhap)
        {
            QuanCaPhePBL3Entities quanCaPheEntities = new QuanCaPhePBL3Entities();
            List<ChiTietNguyenLieu> listCTNL = quanCaPheEntities.ChiTietNguyenLieux.ToList();
            for (int j = 0; j < listCTNL.Count; j++)
            {
                if (listCTNL[j].MaNL == MaNL && listCTNL[j].NgayNhap == NgayNhap)
                {
                    quanCaPheEntities.ChiTietNguyenLieux.Remove(listCTNL[j]);
                    quanCaPheEntities.SaveChanges();
                    break;
                }
            }
        }

        public void DelChiTietNguyenLieu(int MaNL)
        {
            QuanCaPhePBL3Entities quanCaPheEntities = new QuanCaPhePBL3Entities();
            List<ChiTietNguyenLieu> listCTNL = quanCaPheEntities.ChiTietNguyenLieux.ToList();
            for (int j = 0; j < listCTNL.Count; j++)
            {
                if (listCTNL[j].MaNL == MaNL)
                {
                    quanCaPheEntities.ChiTietNguyenLieux.Remove(listCTNL[j]);
                    quanCaPheEntities.SaveChanges();
                }
            }
        }

        

    }
}
