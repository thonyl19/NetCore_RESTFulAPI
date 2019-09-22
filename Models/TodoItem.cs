using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NetCore_RESTFulAPI.Models
{
    public class TodoItem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long SN { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
 

    public class DBSContext : DbContext
    {
        public DBSContext(DbContextOptions<DBSContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }
        
    }
}