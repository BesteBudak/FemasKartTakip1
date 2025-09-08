using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ApprovalProcessRepository(AppDbContext context):GenericRepository<ApprovalProcess>(context)
    {
    }
}
