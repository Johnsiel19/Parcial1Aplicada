using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DAL;
using System.Data.Entity;

namespace BLL
{
    public class EvaluacionBLL
    {
        public static bool Modificar(Evaluacion evaluacion)
        {
            bool paso = false;
            Contexto db = new Contexto();
            RepositorioBase<Estudiantes> dbE = new RepositorioBase<Estudiantes>();


            try
            {
                var anterior = new RepositorioBase<Evaluacion>().Buscar(evaluacion.EvaluacionId);
              

            

                foreach (var item in anterior.Detalles)
                {
                    if (!evaluacion.Detalles.Any(A => A.id == item.id))
                    {
                        db.Entry(item).State = EntityState.Deleted;

                    }

                }

                foreach (var item in evaluacion.Detalles)
                {
                    if (item.id == 0)
                    {

                        db.Entry(item).State = EntityState.Added;
                    }

                    else
                        db.Entry(item).State = EntityState.Modified;
                }



            
                db.Entry(evaluacion).State = EntityState.Modified;

                paso = db.SaveChanges() > 0;


            }
            catch (Exception)
            {
                throw;
            }


            return paso;
        }


        public static bool Guardar(Evaluacion evaluacion)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
        
         

                if (db.Evaluacion.Add(evaluacion) != null)
                {
                
                    paso = db.SaveChanges() > 0;
                   
                }


            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            RepositorioBase<Estudiantes> dbEst = new RepositorioBase<Estudiantes>(new DAL.Contexto());
            try
            {
                var evaluaciones = db.Evaluacion.Find(id);
              
               

                db.Entry(evaluaciones).State = EntityState.Deleted;
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }


    }
}
