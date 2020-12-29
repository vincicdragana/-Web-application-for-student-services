using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadatakGET.Repository
{
   public interface IUnitOfWork : IDisposable
    {
        IStudentRepository Studenti { get; set; }
        IIspitRepository Ispiti { get; set; }
        IPredmetRepository Predmeti { get; set; }

        int SaveChanges();
    }
}
