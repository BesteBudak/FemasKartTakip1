using DataAccess.Repositories;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface ICardRepository:IGenericRepository<Card>
    {
        Task SaveChangesAsync();
    }
}
