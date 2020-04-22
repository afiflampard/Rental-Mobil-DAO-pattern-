using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projek
{
    interface rentalDao
    {
        void Add(Rental rental);
        int delete(int id);
        int update(Rental rental);
        List<Rental> GetAll();
    }
}
