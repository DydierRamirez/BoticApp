using BoticApp.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BoticApp
{
    public partial class @default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            this.lknNuevo.Click += new System.EventHandler(this.lknNuevo_Click);
            this.lknRestablecer.Click += new System.EventHandler(this.lknRestablecer_Click);
            this.lknRegistrar.Click += new System.EventHandler(this.lknRegistrar_Click);
            this.lknRegistrarFarmaia.Click += new System.EventHandler(this.lknRegistrarFarmaia_Click);
            txtUsuario.Attributes.Add("placeholder", "Usuario");
            txtContrasena.Attributes.Add("placeholder", "Contraseña");
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsuario.Text.Equals(string.Empty, StringComparison.OrdinalIgnoreCase))
                    throw new ApplicationException("Usuario no válido");
                if(txtContrasena.Text.Equals(string.Empty,StringComparison.OrdinalIgnoreCase))
                    throw new ApplicationException("Contraseña no válida");

                using (Usuario prcUsuario = new Usuario())
                {
                    Type cstype = this.GetType();
                    decimal tipo = prcUsuario.ValidarUsuario(txtUsuario.Text, txtContrasena.Text);
                    if (tipo != 0)
                    {
                        Session["IDUsuario"] = prcUsuario.ObtenerIDUsuario(txtUsuario.Text);
                        Session["TipoUsuario"] = (tipo.Equals(1) ? "U" : "F");
                        //validar el tipo de 
                        Response.Redirect("~/Home/Index");
                    }
                    else
                        ClientScript.RegisterStartupScript(cstype, "ConfirmarEliminar", "alert('Usuario no existe')");
                }
            }
            catch (Exception ex)
            {
            }
        }
        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtEmail.Text.Equals(StringComparison.OrdinalIgnoreCase))
                {
                    Util.Util.EnviarCorreo(txtEmail.Text);
                    Response.Redirect("~/default.aspx");
                }
                else
                    throw new ApplicationException("Correo no ingresado");
            }
            catch (Exception ex)
            {
            }
        }
        protected void lknRestablecer_Click(object sender, EventArgs e)
        {
            if (pnlInicioSesion.Visible)
            {
                pnlInicioSesion.Visible = false;
                pnlRestablecer.Visible = true;
            }
            else
            {
                pnlInicioSesion.Visible = true;
                pnlRestablecer.Visible = false;
            }
        }
        protected void lknNuevo_Click(object sender, EventArgs e)
        {
            if(pnlNuevo.Visible)
                pnlNuevo.Visible = false;
            else
                pnlNuevo.Visible = true;
        }
        protected void lknRegistrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/USUARIO/Create");
        }
        protected void lknRegistrarFarmaia_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/FARMACIA/Create");
        }
    }
}