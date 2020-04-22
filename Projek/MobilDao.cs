using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projek
{
    interface MobilDao
    {
        void Add(Mobil mobil, Rental rental);
        int delete(long id_mobil);
        int update(Mobil mobil);
        List<Mobil> GetAll();
    }
}
