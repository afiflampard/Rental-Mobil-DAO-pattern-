using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projek
{
    interface PelangganDao
    {
        List<Pelanggan> GetAllPelanggan();
        void addPelanggan(Pelanggan pelanggan);
        int updatePelanggan(Pelanggan pelanggan);
        int deletePelanggan(int id);
    }
}
