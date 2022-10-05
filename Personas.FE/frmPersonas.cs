using Personas.BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Personas.FE
{
    public partial class frmPersonas : Form
    {

        private Personas.BE.Personas personas = new Personas.BE.Personas();
        
        public frmPersonas()
        {
            InitializeComponent();
            dg.DataSource = personas.DT;
            LimpiarPantalla();
        }

        private void btCargar_Click(object sender, EventArgs e)
        {

            Persona persona = new Persona();

            persona.DNI = txtDNI.Text;
            persona.Nombre = txtNombre.Text;
            persona.Apellido = txtApellido.Text;
            persona.Edad = Convert.ToInt32( txtEdad.Text);

            personas.CargarPersona(persona);
        }

        private void LimpiarPantalla()
        {
            txtDNI.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtEdad.Text = "";

            txtDNI.Focus();
        }

        private void btBorrar_Click(object sender, EventArgs e)
        {
            bool res = personas.BorrarPersona(txtDNI.Text);

            if(res)
            {
                LimpiarPantalla();
            }
            else
            {
                txtDNI.Focus();
                txtDNI.SelectAll();
            }
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtEdad.Text = "";

            Persona persona = new Persona();

            persona = personas.BuscarPersona(txtDNI.Text);

            if (persona.DNI != null)
            {
                txtDNI.Text = persona.DNI;
                txtNombre.Text = persona.Nombre;
                txtApellido.Text = persona.Apellido;
                txtEdad.Text = persona.Edad.ToString();
            }

            txtDNI.Focus();
            txtDNI.SelectAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pepe formularionuevo = new pepe("ACA ESTOY", personas.DT);

            formularionuevo.Pepito = new BE.Personas();
            formularionuevo.PropiedadEntera = 10;

            formularionuevo.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MDIPepe OtroFrm = new MDIPepe();

            OtroFrm.Show(); 
        }
    }
}
