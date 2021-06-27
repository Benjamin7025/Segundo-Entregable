using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidad;

namespace Capa_Datos
{
    public class Categorias
    {
        Bolsa_de_EmpleadosEntities db = new Bolsa_de_EmpleadosEntities();

        public void InsertarCategorias(CATEGORIA CATEGORIA)
        {
            db.CATEGORIAS.Add(CATEGORIA);
            db.SaveChanges();
        }
        public List<CATEGORIA> MostrarCategorias()
        {
            return db.CATEGORIAS.OrderByDescending(x => x.id).ToList();
        }


        public void EliminarCategorias(int id)
        {
            CATEGORIA CATEGORIA = db.CATEGORIAS.Find(id);
            db.CATEGORIAS.Remove(CATEGORIA);
            db.SaveChanges();
        }
        public void EditarCategoriass(CATEGORIA CATEGORIA)
        {
            db.Entry(CATEGORIA).State = EntityState.Modified;
            db.SaveChanges();
        }

        public CATEGORIA Edit(int? id)
        {
            CATEGORIA CATEGORIA = db.CATEGORIAS.Find(id);
            return CATEGORIA;
        }
        public CATEGORIA Delete(int? id)
        {
            CATEGORIA CATEGORIA = db.CATEGORIAS.Find(id);
            return CATEGORIA;
        }

    }
}
