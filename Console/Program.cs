using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MySQL.Data.EntityFrameworkCore.Extensions;

namespace MyConsole
{
    public class Demo
    {
        public int Key { get; set; }
        public int? Id { get; set; }
    }

    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Demo> Demos { get; set; }

    }

    class Program
    {
        private static async Task AsyncCode(Context context)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                var row = await context.Demos.FirstOrDefaultAsync(x => x.Id == 666);

                if (row == null)
                {
                    row = new Demo { Id = 666 };
                }

                context.Demos.Add(row);

                context.SaveChanges();

                transaction.Commit();
            }
        }

        static void Main(string[] args)
        {
            var builder = new DbContextOptionsBuilder<Context>()
                .UseMySQL("server=localhost;user=root;password=root;Database=bugdemo;port=3306;SslMode=None;default command timeout=1800");

            var context = new Context(builder.Options);

            AsyncCode(context).Wait();
        }
    }
}
 