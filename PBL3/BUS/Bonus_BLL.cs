using PBL3.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3.BUS
{
    public class Bonus_BLL
    {
        private static Bonus_BLL _Instance;
        public static Bonus_BLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Bonus_BLL();
                }
                return _Instance;
            }
            private set { }
        }
        private Bonus_BLL() { }

        public SelectedDrink SearchSelectedDrink(List<SelectedDrink> s, int id)
        {
            SelectedDrink selectedItem = s.Find(item => item.MaSP == id);
            return selectedItem;
        }
        public void RemoveAllSP(List<SelectedDrink> s, int id)
        {
            s.RemoveAll(item => item.MaSP == id);
        }
        public DataRow[] GetRowsNL(DataTable dt, int id)
        {
            DataRow[] rowsToDelete = dt.Select($"MaNL = {id}");
            return rowsToDelete;
        }
                      
    }
}
