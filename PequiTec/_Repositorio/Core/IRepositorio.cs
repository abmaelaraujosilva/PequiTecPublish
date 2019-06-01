using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PequiTec._Repositorio.Core
{
    interface IRepositorio<T>
    {
        void Adicionar(T Titen);
        void Deletar(T Titen);
        void Update(T Titen);
        T GetById(int ID);
        IEnumerable<T> Listar();
    }
}
