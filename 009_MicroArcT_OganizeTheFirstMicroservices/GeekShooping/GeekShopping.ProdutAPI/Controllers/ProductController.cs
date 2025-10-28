

using GeekShopping.ProdutAPI.Data.ValueObejects;
using GeekShopping.ProdutAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProdutAPI.Controllers
{
    [Route("api/v1/[Controller]")]
    public class ProductController : ControllerBase
    {
       private IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new 
                ArgumentNullException (nameof(productRepository));
        }
        [HttpGet]
        public async Task<ActionResult<ProductVO>> Find()
        {
            var product = await _productRepository.FindAll();        
            return Ok(product);
        }

        [HttpGet ("{id}")]
        public async Task<ActionResult<IEnumerable<ProductVO>>> FindById(long id)
        {
            var product = await _productRepository.FindById(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductVO>> Create([FromBody] ProductVO vo)
        {
           if(vo == null) return BadRequest();
            var product = await _productRepository.Create(vo);
            return Ok(product);
        }

        [HttpPut]
        public async Task<ActionResult<ProductVO>> Update([FromBody] ProductVO vo)
        {
            if (vo == null) return BadRequest();
            var product = await _productRepository.Update(vo);
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var status = await _productRepository.Delete(id);
            if (!status) return BadRequest();
            return Ok(status);
        }
    }
}
