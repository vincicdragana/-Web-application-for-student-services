using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZadatakGET.Models;

namespace ZadatakGET.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(Zadatak2Context db)
            : base(db)
        {
        }
        public virtual Student FindStudent(int? BI)
        {
            return set.Find(BI);
        }

        public Zadatak2Context StudentContext
        {
            get { return DB as Zadatak2Context; }
        }
    }
}