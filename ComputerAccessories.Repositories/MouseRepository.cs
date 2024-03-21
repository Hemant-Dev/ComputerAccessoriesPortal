using ComputerAccessories.Data;
using ComputerAccessories.IRepositories;
using ComputerAccessories.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerAccessories.Repositories
{
    public class MouseRepository : Repository<Mouse>, IMouseRepository
    {
        public MouseRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
    }
}
