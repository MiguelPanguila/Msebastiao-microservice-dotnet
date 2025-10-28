using AutoMapper;
using GeekShopping.ProdutAPI.Data.ValueObejects;
using GeekShopping.ProdutAPI.Model;
using GeekShopping.ProdutAPI.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProdutAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MySQLContext  _context;
        private readonly IMapper     _mapper;

        public ProductRepository(MySQLContext context,IMapper mapper)
        {
                _context = context;
                _mapper = mapper;
        }public  async Task<IEnumerable<ProductVO>> FindAll()
        {
            var products = await _context.Productcs.ToListAsync();
            return _mapper.Map<List<ProductVO>>(products);
        }

        public async Task<ProductVO> FindById(long id)
        {
            var product = 
                await
                _context.Productcs.Where(a => a.Id == id)
                .FirstAsync();
            return _mapper.Map<ProductVO>(product);
        }
        public async Task<ProductVO> Create(ProductVO vo)
        {
            var product = _mapper.Map<Productc>(vo);
            _context.Productcs.Add(product);
           await _context.SaveChangesAsync();
               
            return _mapper.Map<ProductVO>(product);
        }
        public async Task<ProductVO> Update(ProductVO vo)
        {
            var product = _mapper.Map<Productc>(vo);
            _context.Productcs.Update(product);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProductVO>(product);
        }
        public async Task<bool> Delete(long id)
        {
            try
            {
                var product =
               await
               _context.Productcs.Where(a => a.Id == id)
               .FirstAsync();
                if (product == null) return false;
                _context.Productcs.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        

       
    }
}
