using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace BLL.Tests
{
    [TestClass()]
    public class EvaluacionBLLTests
    {
        [TestClass()]
        public class CobroBLLTests
        {
            [TestMethod()]
            public void GuardarTest()
            {



                Evaluacion ve = new Evaluacion()
                {
                    EvaluacionId = 5,
                    Estudiante = "Juan",
                    Total = 3,

                    Fecha = DateTime.Now
                };
                Assert.IsTrue(EvaluacionBLL.Guardar(ve));
            }

            [TestMethod()]
            public void ModificarTest()
            {


                Evaluacion ve = new Evaluacion()
                {
                    EvaluacionId = 5,
                    Estudiante = "Johnsiel",
                    Total = 2,

                
                    Fecha = DateTime.Now
                };

                Assert.IsTrue(EvaluacionBLL.Modificar(ve));
            }


            [TestMethod()]
            public void EliminarTest()
            {


                Assert.IsTrue(EvaluacionBLL.Eliminar(5));
            }

        }
    } }