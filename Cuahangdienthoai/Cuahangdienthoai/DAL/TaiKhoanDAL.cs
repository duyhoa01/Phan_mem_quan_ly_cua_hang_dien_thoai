using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuahangdienthoai.DAL
{
    class TaiKhoanDAL
    {
        private static TaiKhoanDAL _Intance;
        public static TaiKhoanDAL Intance
        {
            get
            {
                if (_Intance == null)
                {
                    _Intance = new TaiKhoanDAL();
                }
                return _Intance;
            }
            private set { }
        }
        public TaiKhoanDAL()
        {

        }
        public void xoataikhoandal(int mtk)
        {
            using(PBL3Entities db=new PBL3Entities())
            {
                db.Accounts.Remove(db.Accounts.Find(mtk));
                db.SaveChanges();
            }
        }
        public List<Account> getlisttaikhoandal()
        {
            using (PBL3Entities db = new PBL3Entities())
            {
                return db.Accounts.ToList();
            }
        }
        public List<Account>getlistnameDal(string name)
        {
            List<Account> data = new List<Account>();
            foreach(Account i in getlisttaikhoandal())
            {
                if (i.TenHienThi.Contains(name))
                {
                    data.Add(i);
                }
                
            }
            return data;

        }
    }
}
