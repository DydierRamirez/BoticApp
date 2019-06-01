using BoticApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BoticApp.Logica
{
    public class Medicamento : IDisposable
    {
        private boticaapEntities1 db = new boticaapEntities1();
        public Medicamento()
        {
        }
        public void Dispose()
        {
            db.Dispose();
        }
        public DataTable ObtenerMedicamentos(string medicamento)
        {
            var query = (from m in db.MEDICAMENTO where m.MEDICAMENTO1.StartsWith(medicamento)  select new { ID_MEDICAMENTO = m.ID_MEDICAMENTO , MEDICAMENTO= m.MEDICAMENTO1});
            DataTable datos = new DataTable();
            datos.Columns.Add("ID_MEDICAMENTO", typeof(string));
            datos.Columns.Add("MEDICAMENTO", typeof(string));
            // Create a table from the query.
            foreach (var x in query)
            {
                DataRow dr = datos.NewRow();
                dr["ID_MEDICAMENTO"] = x.ID_MEDICAMENTO;
                dr["MEDICAMENTO"] = x.MEDICAMENTO;
                datos.Rows.Add(dr);
                break;
            }
            return datos;
        }
    }
}