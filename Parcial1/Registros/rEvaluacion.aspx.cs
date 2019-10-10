using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using BLL;

namespace Parcial1
{
    public partial class rEvaluacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                EvaluacionIdTextBox.Text = "0";
                PrecioTextBox.Text = "0";
                ServicioDropDownList.Text = string.Empty;
                CantidadTextBox.Text = "0";
                PrecioTextBox.Text = "0";
                TotalTextBox.Text = "0";
                EstudianteDropDownList.Text = string.Empty;
                ViewState["Evaluacion"] = new Evaluacion();
           
                BindGrid();

            }

            int ID = Utilitarios.Utils.ToInt(Request.QueryString["id"]);

            if (ID > 0)
            {
                RepositorioBase<Evaluacion> repositorio = new RepositorioBase<Evaluacion>();
                var us = repositorio.Buscar(ID);

                if (us == null)
                {
                    Utilitarios.Utils.ShowToastr(this.Page, "Registro No encontrado", "Error", "error");
                }
                else
                {
                    LlenaCampo(us);
                }
            }

        }

        protected void BindGrid()
        {
            if (ViewState["Evaluacion"] != null)
            {
                Grid.DataSource = ((Evaluacion)ViewState["Evaluacion"]).Detalles;
                Grid.DataBind();


            }
        }

        private void Limpiar()
        {
            EvaluacionIdTextBox.Text = "0";


            ServicioDropDownList.Text = string.Empty;
            CantidadTextBox.Text = "0";
            PrecioTextBox.Text = "0";
            ImporteTextBox.Text = "0";
            EstudianteDropDownList.Text = string.Empty;
            TotalTextBox.Text = "0";

            Grid.DataSource = null;
            Grid.DataBind();


        }

        public Evaluacion LlenaClase()
        {
            Evaluacion evaliacion = (Evaluacion)ViewState["Evaluacion"];
            evaliacion.EvaluacionId = Convert.ToInt32(EvaluacionIdTextBox.Text);
            evaliacion.Total = Convert.ToDecimal(TotalTextBox.Text);
            evaliacion.Estudiante = EstudianteDropDownList.Text;
            evaliacion.Fecha = DateTime.Now;



            return evaliacion;
        }

        private void LlenaCampo(Evaluacion evaluaciones)
        {
            ((Evaluacion)ViewState["Evaluacion"]).Detalles = evaluaciones.Detalles;
            EstudianteDropDownList.Text = evaluaciones.Estudiante.ToString();
            EvaluacionIdTextBox.Text = evaluaciones.EvaluacionId.ToString();
            TotalTextBox.Text = evaluaciones.Total.ToString();
            fechaTextBox.Text = evaluaciones.Fecha.ToString("yyyy-MM-dd");

            this.BindGrid();



        }

        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Evaluacion> db = new RepositorioBase<Evaluacion>();
            Evaluacion evaluacion = db.Buscar(Convert.ToInt32(EvaluacionIdTextBox.Text));
            return (evaluacion != null);

        }



        protected void AgregarButton_Click(object sender, EventArgs e)
        {

            if (ValidarGrid())
            {
                Utilitarios.Utils.ShowToastr(this.Page, "Por Favor llene todos los datos", "Error", "error");
                return;
            }
            Evaluacion evaluacion = new Evaluacion();

            


            evaluacion = (Evaluacion)ViewState["Evaluacion"];

           
            evaluacion.Detalles.Add(new Entidades.EvaluacionDetalle(0, 0,
               ServicioDropDownList.Text,
               Convert.ToInt32(CantidadTextBox.Text), Convert.ToDecimal(PrecioTextBox.Text), Convert.ToDecimal(ImporteTextBox.Text)));


  

            ViewState["Evaluacion"] = evaluacion;

            this.BindGrid();

            Grid.Columns[1].Visible = false;


            decimal Calculador = 0;
            foreach (var item in evaluacion.Detalles)
            {
                Calculador = Calculador + item.Importe;
            }
            TotalTextBox.Text = Calculador.ToString();

            CantidadTextBox.Text = "0";
            PrecioTextBox.Text = "0";
            ImporteTextBox.Text = "0";

        }

        public bool ValidarGrid()
        {
            bool paso = false;

            if (ServicioDropDownList.Text == string.Empty)
            {
                paso = true;
            }
            if (CantidadTextBox.Text == string.Empty || CantidadTextBox.Text =="0")
            {
                paso = true;
            }
            if (PrecioTextBox.Text == string.Empty || PrecioTextBox.Text == "0")
            {
                paso = true;
            }

            return paso;

        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Evaluacion evaluacion;
            bool paso = false;
            if (Validar())
            {
                Utilitarios.Utils.ShowToastr(this.Page, "El Campo Nombre no puede estar vacio", "Error", "error");
                return;
            }
                

            evaluacion = LlenaClase();


            if (EvaluacionIdTextBox.Text == 0.ToString())
            {
                paso = EvaluacionBLL.Guardar(evaluacion);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    Utilitarios.Utils.ShowToastr(this.Page, "Se ha podido modificar", "Error", "error");
                    return;
                }
                paso = EvaluacionBLL.Modificar(evaluacion);
            }

            if (paso)
                Utilitarios.Utils.ShowToastr(this.Page, " Se ha Guardado", "Exito", "success");
            else
                Utilitarios.Utils.ShowToastr(this.Page, "Se profujo un error al guardar", "Error", "error");
            Limpiar();


        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {


            if (Utilitarios.Utils.ToInt(EvaluacionIdTextBox.Text) > 0)
            {
                int id = Convert.ToInt32(EvaluacionIdTextBox.Text);

                if (EvaluacionBLL.Eliminar(id))
                {

                    Utilitarios.Utils.ShowToastr(this.Page, "Eliminado con exito!!", "Eliminado", "info");
                }
                else
                    Utilitarios.Utils.ShowToastr(this.Page, "Fallo al Eliminar :(", "Error", "error");
                Limpiar();
            }
            else
            {
                Utilitarios.Utils.ShowToastr(this.Page, "No se pudo eliminar, Evaluacion existe", "error", "error");
            }

        }

        public bool Validar()
        {
            bool paso = false;

            if(EstudianteDropDownList.Text == string.Empty)
            {
                paso = true;
            }

            return paso;

        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();

        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            int id;

            RepositorioBase<Evaluacion> db = new RepositorioBase<Evaluacion>();
            Evaluacion evaluacio = new Evaluacion();
            int.TryParse(EvaluacionIdTextBox.Text, out id);
            Limpiar();


            evaluacio = db.Buscar(id);

            if (evaluacio != null)
            {

                LlenaCampo(evaluacio);

            }
            else
            {
                Utilitarios.Utils.ShowToastr(this.Page, "No se encontro esa evaluacion", "Error", "error");

            }

        }

        protected void Grid_RowDeleting1(object sender, GridViewDeleteEventArgs e)
        {
            Evaluacion evaluaciones = new Evaluacion();
            evaluaciones = (Evaluacion)ViewState["Evaluacion"];
            ViewState["Evaluaciones"] = evaluaciones.Detalles;

            int Fila = e.RowIndex;

            evaluaciones.Detalles.RemoveAt(Fila);
            this.BindGrid();


            decimal Calculador = 0;
            foreach (var item in evaluaciones.Detalles)
            {
                Calculador = Calculador + item.Importe;
            }
            TotalTextBox.Text = Calculador.ToString();

            CantidadTextBox.Text = "0";
            PrecioTextBox.Text = "0";
            ImporteTextBox.Text = "0";

        }

        protected void PrecioTextBox_TextChanged(object sender, EventArgs e)
        {
            decimal Cantidad = Convert.ToDecimal(CantidadTextBox.Text);
            decimal Precio = Convert.ToDecimal(PrecioTextBox.Text);

            ImporteTextBox.Text = (Cantidad * Precio).ToString();
        }

        protected void CantidadTextBox_TextChanged(object sender, EventArgs e)
        {
            decimal Cantidad = Convert.ToDecimal(CantidadTextBox.Text);
            decimal Precio = Convert.ToDecimal(PrecioTextBox.Text);

            ImporteTextBox.Text = (Cantidad * Precio).ToString();
        }
    }
}