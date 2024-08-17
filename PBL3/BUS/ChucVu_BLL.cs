using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBL3.DTO;

namespace PBL3.BUS
{
    internal class ChucVu_BLL
    {
        private static ChucVu_BLL _Instance;
        public static ChucVu_BLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ChucVu_BLL();
                }
                return _Instance;
            }
            private set { }
        }
        private ChucVu_BLL() { }

        public List<Object> GetListChucVu()
        {
            QuanCaPhePBL3Entities quanCaPheEntities = new QuanCaPhePBL3Entities();
            List<Object> result = new List<Object>();
            foreach (ChucVu i in quanCaPheEntities.ChucVus)
            {
                result.Add(new
                {
                    MaCV = i.MaCV,
                    TenCV = i.TenCV
                });
            }
            return result;
        }
        public string getTenChucVu(int maCV)
        {
            QuanCaPhePBL3Entities db = new QuanCaPhePBL3Entities();
            return db.ChucVus.Where(p => p.MaCV == maCV).Select(p => p.TenCV).FirstOrDefault();
        }
        public ChucVu GetChucVu(int MaCV)
        {
            QuanCaPhePBL3Entities quanCaPheEntities = new QuanCaPhePBL3Entities();
            List<ChucVu> listCV = quanCaPheEntities.ChucVus.ToList();
            for (int i = 0; i < listCV.Count; i++)
            {
                if (listCV[i].MaCV == MaCV)
                {
                    return listCV[i];
                }
            }
            return null;
        }

        public void AddChucVu(int MaCV, string TenCV)
        {
            QuanCaPhePBL3Entities quanCaPheEntities = new QuanCaPhePBL3Entities();
            ChucVu cv = new ChucVu();
            cv.MaCV = MaCV;
            cv.TenCV = TenCV;
            quanCaPheEntities.ChucVus.Add(cv);
            quanCaPheEntities.SaveChanges();
        }

        public void DelChucVu(int MaCV)
        {
            QuanCaPhePBL3Entities quanCaPheEntities = new QuanCaPhePBL3Entities();
            List<ChucVu> listCV = quanCaPheEntities.ChucVus.ToList();
            for (int j = 0; j < listCV.Count; j++)
            {
                if (listCV[j].MaCV == MaCV)
                {
                    quanCaPheEntities.ChucVus.Remove(listCV[j]);
                    quanCaPheEntities.SaveChanges();
                    break;
                }
            }
        }

    }
}
