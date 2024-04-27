using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace senac.projetoIntegrador.Repositories.BancoDeDados
{
    public class BaseRepository
    {
        protected IDbConnection db;

        protected DateTime? ValidarDataSQL(DateTime? data)
        {
            return data > DateTime.MinValue ? data : null;
        }
    }
}
