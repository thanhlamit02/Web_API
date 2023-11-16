using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBH.BLL;
using QLBH.Common.Req;
using QLBH.Common.Rsp;
using QLBH.DAL.Models;

namespace QLBH.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductSvc productSvc;
        public ProductController()
        {
            productSvc = new ProductSvc();
        }

        [HttpPost("search-product")]
        public IActionResult SearchProduct([FromBody] SearchProductReq searchProductReq)
        {
            var res = new SingleRsp();
            var products = productSvc.SearchProduct(searchProductReq);
            res.Data = products;
            return Ok(res);
        }

        [HttpPost("get-product-by-id")]
        public IActionResult GetProductByID([FromBody] SimpleReq simpleReq)
        {
            var res = new SingleRsp();
            res = productSvc.Read(simpleReq.Id);
            return Ok(res);
        }

        [HttpPost("get-all-product")]
        public IActionResult getAllProducts()
        {
            var res = new SingleRsp();
            res.Data = productSvc.All;
            return Ok(res);
        }

        [HttpPost("create-product")]
        public IActionResult CreateProduct([FromBody] ProductReq reqProduct)
        {
            var res = productSvc.CreateProduct(reqProduct);
            return Ok(res);
        }

        [HttpPost("update-product")]
        public IActionResult UpdateProduct([FromBody] ProductReq reqProduct)
        {
            var res = productSvc.UpdateProduct(reqProduct);
            return Ok(res);
        }

        [HttpDelete("delete-product-by-id")]
        public IActionResult DeleteProduct([FromBody] SimpleReq simpleReq)
        {
            var res = new SingleRsp();
            res = productSvc.Delete(simpleReq.Id);
            return Ok(res);
        }
    }
}
