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
    }
}
