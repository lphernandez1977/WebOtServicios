using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebOtServicios.controls
{
    public partial class espere : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //int a = 1;

            //this.pnlProgress.Visible = true;
        }

        public enum tipoMensaje
        {
            Cargando = 1,
            Grabando = 2
        }

        public void ShowMessage(string titulo, string Message, tipoMensaje tipo)
        {
            this.lblMensaje.Text = Message;
            this.LblTitle.Text = "Trabajando";
            if (string.IsNullOrEmpty(titulo)== false)
                this.LblTitle.Text = titulo;

            if (tipo == tipoMensaje.Cargando)
            {
                //imgicono.ImageUrl = "~/css/images-controls/loading.gif";
                imgicono.ImageUrl = "~/Img/loading.gif";
            }
            else
            {
                //imgicono.ImageUrl = "~/css/images-controls/loading8.gif";
                imgicono.ImageUrl = "~/Img/loading8.gif";
            }
         }
    }
}