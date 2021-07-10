using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebOtServicios.controls
{
    public partial class informacion : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            this.btnAceptar.OnClientClick = String.Format("fnClickOK('{0}','{1}')", this.btnAceptar.UniqueID, "");

        }

        public enum tipoMensaje
        {
            advertencia=1,
            Mensaje=2
        }

        public void ShowMessage(string Message,tipoMensaje tipo)
        {
            this.lblMensaje.Text = Message;
            this.LblTitle.Text = "INFORMACIÓN";
            if (tipo == tipoMensaje.advertencia)
            {
                imgicono.ImageUrl = "../Img/advertencia.png";
            }
            else
            {
                imgicono.ImageUrl = "../Img/mensaje.png";
            }

            this.ModalPopupInfo.Show();
            //Session["InfoOk"] = 0;
        }
        public void ShowMessage(string Titulo, string Message, tipoMensaje tipo)
        {
            this.lblMensaje.Text = Message;
            if (Titulo == "")
            {
                this.LblTitle.Text = "INFORMACIÓN";
            }
            else
            {
                this.LblTitle.Text = Titulo.ToUpper();
            }

            if (tipo == tipoMensaje.advertencia)
            {
                imgicono.ImageUrl = "~/Img/advertencia.png";
            }
            else
            {
                imgicono.ImageUrl = "~/Img/mensaje.png";
            }
            this.ModalPopupInfo.Show();
            //Session["InfoOk"] = 0;
        }

        private void Hide()
        {
            LblTitle.Text = "";
            lblMensaje.Text = "";
            this.ModalPopupInfo.Hide();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            //al hacer click sobre el boton okay llama al siguiente delegado
            OnAceptarButtonPressed(e);
        }

        //Delegado del Boton
        public delegate void AceptarButtonPressedHandler(object sender, EventArgs args);
        public event AceptarButtonPressedHandler AceptarButtonPressed;
        protected virtual void OnAceptarButtonPressed(EventArgs e)
        {
            if (AceptarButtonPressed != null)
                AceptarButtonPressed(this.btnAceptar, e);
        }      
    }
}