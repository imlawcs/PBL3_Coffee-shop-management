using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBL3.DTO;

namespace PBL3.BUS
{
    internal class DonHang_BLL
    {
        private static DonHang_BLL _Instance;
        public static DonHang_BLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DonHang_BLL();
                }
                return _Instance;
            }
            private set { }
        }

        public void AddDonHang(int MaDH, int MaSP, int SoLuongSP)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            DonHang dh = new DonHang();
            dh.MaDH = MaDH;
            dh.MaSP = MaSP;
            dh.SoLuongSP = SoLuongSP;
            db.DonHangs.Add(dh);
            db.SaveChanges();
        }

        public void AddDonHang(int MaDH, int[] MaSP, int[] SoLuongSP)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            for(int i = 0; i < MaSP.Length; i++)
            {
                DonHang dh = new DonHang();
                dh.MaDH = MaDH;
                dh.MaSP = MaSP[i];
                dh.SoLuongSP = SoLuongSP[i];
                db.DonHangs.Add(dh);
                db.SaveChanges();
            }
        }
        public int GetmaDHTieptheo()
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            var t = db.DonHangs.OrderByDescending(p => p.MaDH).FirstOrDefault();
            return t.MaDH + 1;
        }
        public List<DonHang> GetListDonHang()
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            return db.DonHangs.ToList();
        }
        public List<Object> getListObjectMaDH()
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            List<DonHang> listDH = db.DonHangs.ToList();
            List<Object> listObjectDH = new List<Object>();
            for(int i=0; i<listDH.Count; i++)
            {
                Object obj = new
                {
                    MaDH = listDH[i].MaDH,
                };
                listObjectDH.Add(obj);
            }
            List<Object> listMaDH = listObjectDH.Distinct().ToList();
            return listMaDH;
        }

        public List<Object> getListObjectMaDH(int maDH)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            List<DonHang> listDH = db.DonHangs.ToList();
            List<Object> listObjectDH = new List<Object>();
            for (int i = 0; i < listDH.Count; i++)
            {
                if (listDH[i].MaDH == maDH) { 
                    Object obj = new
                    {
                        MaDH = listDH[i].MaDH,
                    };
                    listObjectDH.Add(obj);
                    break;
                }
            }
            return listObjectDH;
        }


        public List<Object> GetListDonHangByID(int MaDH)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            List<DonHang> listDH = db.DonHangs.ToList();
            List<Object> listObjectDH = new List<Object>();
            for (int i = 0; i < listDH.Count; i++)
            {
                if (listDH[i].MaDH == MaDH)
                {
                    Object obj = new
                    {
                        MaSP = listDH[i].MaSP,
                        SoLuongSP = listDH[i].SoLuongSP,
                        TenSP = SanPham_BLL.Instance.getTenSP(listDH[i].MaSP),
                        GiaSP = SanPham_BLL.Instance.getGiaSP(listDH[i].MaSP),
                    };
                    listObjectDH.Add(obj);
                }
            }
            return listObjectDH;
        }   

        public DonHang GetDonHang(int maDH, int maSP, int SoLuongSP)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            List<DonHang> list = db.DonHangs.ToList();
            for(int i=0; i<list.Count; i++)
            {
                if (list[i].MaDH==maDH && list[i].MaSP==maSP && list[i].SoLuongSP==SoLuongSP)
                {
                    return list[i];
                }
            }
            return null;
        }

 
        public void UpdateDonHang(int MaDH, int MaSP, int SoLuongSP)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            List<DonHang> listDH = db.DonHangs.ToList();
            for(int i=0;i<listDH.Count;i++)
            {
                if (listDH[i].MaDH==MaDH && listDH[i].MaSP == MaSP) 
                {
                    listDH[i].SoLuongSP = SoLuongSP;
                    db.SaveChanges();
                    return;
                }
            }
        }

        public void DeleteDonHang(int MaDH, int MaSP)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            List<DonHang> listDH = db.DonHangs.ToList();
            for (int i = 0; i < listDH.Count; i++)
            {
                if (listDH[i].MaDH == MaDH && listDH[i].MaSP == MaSP)
                {
                    db.DonHangs.Remove(listDH[i]);
                    db.SaveChanges();
                    return;
                }
            }
        }

        public void DelDonHang(int MaDH)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            List<DonHang> listDH = db.DonHangs.ToList();
            for (int i = 0; i < listDH.Count; i++)
            {
                if (listDH[i].MaDH == MaDH )
                {
                    db.DonHangs.Remove(listDH[i]);
                    db.SaveChanges();
                }
            }
        }



    }
}
