using BoticApp.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BoticApp
{
    public partial class Restaurar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page.Request["ID_USUARIO"] != null)
                hdID_USUARIO.Value = Page.Request["ID_USUARIO"];
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            //txtUsuario.Attributes.Add("placeholder", "Usuario");
            txtContrasena.Attributes.Add("placeholder", "Contraseña");
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                //if (txtUsuario.Text.Equals(string.Empty, StringComparison.OrdinalIgnoreCase))
                //    throw new ApplicationException("Usuario no válido");
                if(txtContrasena.Text.Equals(string.Empty,StringComparison.OrdinalIgnoreCase))
                    throw new ApplicationException("Contraseña no válida");
                if(!txtContrasena.Text.Equals(txtConfirmarContrasena.Text))
                    throw new ApplicationException("Contraseñas no coinciden");
                using (Usuario prcUsuario = new Usuario())
                {
                    if (!hdID_USUARIO.Value.ToString().Equals(string.Empty, StringComparison.OrdinalIgnoreCase))
                    {
                        if (prcUsuario.ActualizarContrasena(decimal.Parse(hdID_USUARIO.Value), txtContrasena.Text))
                        {
                            Response.Redirect("~/default.aspx");
                        }
                        else
                            throw new ApplicationException("");
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}