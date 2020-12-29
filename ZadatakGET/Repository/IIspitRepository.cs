using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZadatakGET.Models;

namespace ZadatakGET.Repository
{
    public interface IIspitRepository : IRepository<Ispit>
    {
        Ispit FindIspit(int? BI, int? PredmetId);
    }
}
