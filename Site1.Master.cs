using ExammenII.clases;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExammenII
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
            }
        }
        public void alertas(String texto)
        {
            string message = texto;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type='text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            Page.ClientScript.RegisterClientScriptBlock(typeof(Type), "key", sb.ToString());
        }
        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM tipo"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            datagrid.DataSource = dt;
                            datagrid.DataBind();  // actualizar el grid view
                        }
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                int equipoId = Convert.ToInt32(TextBoxEquipoId.Text);
                string tipoEquipo = TextBoxTipoEquipo.Text;
                string modelo = TextBoxModelo.Text;
                int usuarioId = Convert.ToInt32(TextBoxUsuarioId.Text);

                // instancia de la clase EQUIPOS con los valores obtenidos
                EQUIPOS equipo = new EQUIPOS(equipoId, tipoEquipo, modelo, usuarioId);

                // operación de agregar un equipo
                equipo.Agregar();

                // Muestra un mensaje
                MostrarMensaje("Equipo agregado exitosamente");
            }
            catch (Exception ex)
            {
                // Manejo de errores
                MostrarMensaje("Error al agregar equipo: " + ex.Message);


            }


            protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
              
        protected void tcodigo_TextChanged(object sender, EventArgs e)
        {
            // Puedes agregar lógica adicional si es necesario
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            // Puedes agregar lógica adicional si es necesario
        }

        protected void Bconsulta_Click(object sender, EventArgs e)
        {
            try
            {
                int codigo = int.Parse(tcodigo.Text);
                string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM USUARIO WHERE Codigo = @Codigo"))
                    {
                        cmd.Parameters.AddWithValue("@Codigo", codigo);

                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                datagrid.DataSource = dt;
                                datagrid.DataBind();  // actualizar el grid view
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                MostrarMensaje("Error al realizar la consulta: " + ex.Message);
            }
        }

        protected void datagrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Obtén el índice de la fila seleccionada
                int index = datagrid.SelectedIndex;

                // Verifica si hay una fila seleccionada
                if (index >= 0 && index < datagrid.Rows.Count)
                {
                    // valores de las celdas de la fila seleccionada
                    GridViewRow selectedRow = datagrid.Rows[index];
                    string valorColumna1 = selectedRow.Cells[0].Text; // Cambia 0 por el índice de la columna que deseas obtener
                    string valorColumna2 = selectedRow.Cells[1].Text; // Cambia 1 por el índice de la siguiente columna que deseas obtener

                  
                    MostrarMensaje($"Fila seleccionada: Columna1={valorColumna1}, Columna2={valorColumna2}");
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                MostrarMensaje("Error al manejar la selección de la fila: " + ex.Message);
            }
        }

        private void MostrarMensaje(string mensaje)
        {
            LabelMensaje.Text = mensaje;
        }
    }
}
