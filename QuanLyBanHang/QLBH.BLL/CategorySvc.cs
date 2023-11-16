using QLBH.Common.BLL;
using QLBH.Common.Rsp;
using QLBH.DAL;
using QLBH.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.BLL
{
    public class CategorySvc : GenericSvc<CategoryRep, Category>
    {
        private CategoryRep categoryRep;
        public CategorySvc() 
        { 
            categoryRep = new CategoryRep();
        }

        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            res.Data = _rep.Read(id);
            return res;
        }

        public override SingleRsp Update(Category m)
        {
            var res = new SingleRsp();
            var m1 = m.CategoryId > 0 ? _rep.Read(m.CategoryId) : _rep.Read(m.Description);
            if (m1 == null)
            {
                res.SetError("EZ103", "No data");
            }
            else
            {
                res = base.Update(m);
                res.Data = m;
            }
            return base.Update(m);
        }
    }
}
