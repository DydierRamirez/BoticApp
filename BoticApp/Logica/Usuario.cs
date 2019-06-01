using BoticApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BoticApp.Logica
{
    public class Usuario:IDisposable
    {
        private boticaapEntities1 db = new boticaapEntities1();
        public Usuario()
        {
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public decimal ValidarUsuario(string Usuario, string Contrasena)
        {
            Contrasena = Util.Util.Encriptar(Contrasena).ToString();
            var usuario = (from u in db.USUARIO
                       where u.USUARIO1 == Usuario && u.CLAVE == Contrasena
                           select u).FirstOrDefault();
            var farmacia = (from f in db.FARMACIA where f.USUARIO == Usuario && f.CLAVE == Contrasena select f).FirstOrDefault();
            if (farmacia != null)
                return 2;
            else if (usuario != null)
                return 1;
            else
                return 0;
            //return (max != null ? true : false);
        }
        public decimal ObtenerIDUsuario(string Usuario)
        {
            var usuario = (from u in db.USUARIO
                           where u.USUARIO1 == Usuario  //Util.Util.Encriptar(Contrasena)
                           select u).FirstOrDefault();
            if (usuario != null)
                return usuario.ID_USUARIO;
            else
                return 0;
        }
        public bool ActualizarContrasena(decimal IdUsuario, string Clave)
        {
            var usuario = (from u in db.USUARIO
                           where u.ID_USUARIO==IdUsuario
                           select u).FirstOrDefault();
            if (usuario != null)
            {
                usuario.CLAVE = Util.Util.Encriptar(Clave);
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            else
                return false;
        }
    }
}