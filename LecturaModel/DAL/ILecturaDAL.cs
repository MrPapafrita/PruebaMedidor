using LecturaModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecturaModel.DAL
{
    public interface ILecturaDAL
    {
        void AgregarLecturas(Consumo consumo);
        List<Consumo> ObtenerLecturas();

    }
}
