using QLBH.Common.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLBH.DAL.Models;

namespace QLBH.DAL
{
    public class CategoryRep : GenericRep<NorthwindContext, Category>
    {
        public CategoryRep()
        {

        }
        /*
        public override Category Read(int id)
        {
            var res = All.FirstOrDefault(c => c.CategoryId == id);
            return res;
        }
        */
        public override Category Read(int id)
        {
            return base.Read(id);
        }

        public int Remove(int id) 
        {
            var m = base.All.First(i => i.CategoryId == id);
            m = base.Delete(m);
            return m.CategoryId;
        }
    }
}
