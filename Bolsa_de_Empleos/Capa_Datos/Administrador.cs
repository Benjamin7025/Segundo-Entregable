using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidad;

namespace Capa_Datos
{
    public class Administrador
    {
        Bolsa_de_EmpleadosEntities db = new Bolsa_de_EmpleadosEntities();

        public void InsertarLoginPoster(ADMINISTRADOR loginAdmin)
        {
            db.ADMINISTRADORs.Add(loginAdmin);
            db.SaveChanges();
        }

        public ADMINISTRADOR Comparar(string Correo_Administrador, string Contraseña_Administrador)
        {
            var user = db.ADMINISTRADORs.FirstOrDefault(a => a.Correo_Administrador == Correo_Administrador && a.Contraseña_Administrador == Contraseña_Administrador);
            return user;
        }
    }
}
