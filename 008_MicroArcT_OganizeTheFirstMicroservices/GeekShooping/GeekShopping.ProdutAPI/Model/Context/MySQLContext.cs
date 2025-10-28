using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProdutAPI.Model.Context
{
    public class MySQLContext: DbContext
    {
        public MySQLContext(){}
        public MySQLContext(DbContextOptions<MySQLContext> options): base(options){}
        public DbSet<Productc> Productcs { get; set; }
    }
}
