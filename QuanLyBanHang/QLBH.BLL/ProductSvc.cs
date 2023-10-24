using QLBH.Common.BLL;
using QLBH.Common.Req;
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
    public class ProductSvc : GenericSvc<ProductRep, Product>
    {
        private ProductRep productRep;
        public ProductSvc() 
        {
            productRep = new ProductRep();
        }

        #region -- Overrides --
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            var m = _rep.Read(id);
            res.Data = m;
            return res;
        }

        public override SingleRsp Update(Product m)
        {
            var res = new SingleRsp();
            var m1 = m.ProductId > 0 ? _rep.Read(m.ProductId) : _rep.Read(m.ProductName);
            if (m1 == null) 
            {
                res.SetError("EZ103", "No data.");
            }
            else
            {
                res = base.Update(m);
                res.Data = m;
            }
            return res;
        }

        #endregion

        #region -- Methods --
        public SingleRsp CreateProduct(ProductReq productReq)
        {
            var res = new SingleRsp();
            Product product = new Product();
            product.ProductId = productReq.ProductId;
            product.ProductName = productReq.ProductName;
            product.UnitPrice = productReq.UnitPrice;
            product.UnitsInStock = productReq.UnitsInStock;
            res = productRep.CreateProduct(product);
            return res;
        }

        public SingleRsp SearchProduct(SearchProductReq s)
        {
            var res = new SingleRsp();
            // Lấy danh sách sản phẩm theo từ khóa
            var products = productRep.SearchProduct(s.Keyword);
            // Xử lý phân trang
            int pCount, totalPages, offset;
            offset = s.Size * (s.Page - 1);
            pCount = products.Count;
            totalPages = (pCount % s.Size) == 0 ? pCount / s.Size : 1 + (pCount / s.Size);
            var obj = new
            {
                Data = products.Skip(offset).Take(s.Size).ToList(),
                Page = s.Page,
                Size = s.Size
            };

            res.Data = obj;
            return res;
        }
        #endregion
    }
}
