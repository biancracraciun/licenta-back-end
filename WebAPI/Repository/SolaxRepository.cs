using System.Collections.Generic;
using System.Linq;
using WebAPI.Models;

namespace WebAPI.Repository
{
    public class SolaxRepository
    {
        private Context _context;

        public SolaxRepository()
        { 
            _context = new Context();
        }

        public void Add(Solax solax)
        { 
            _context.Solax.Add(solax);
            _context.SaveChanges();
        }

        public List<Solax> GetAll()
        {
            var list = _context.Solax.ToList();
            return list;

        }
        public List<int> GetAllData()
        {
            List<int> DataSet = new List<int>() { 11, 6, 20 };
      
            return DataSet;

        }

    }
}
