using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tributrek.Infraestructura.AccesoDatos;

namespace tributrek.Dominio.Modelo.Abstracciones
{
    public interface ICategoriaRepositorio:IRepositorio<tri_categoria>
    {

        Task<List<tri_categoria>> ListarCategorias();


    }
}
