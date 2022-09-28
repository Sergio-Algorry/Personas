using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas.BE
{
    public class Personas
    {
        public DataTable DT { get; set; } = new DataTable();

        public Personas()
        {
            DT.TableName = "Personas";
            DT.Columns.Add("DNI", typeof(string));
            DT.Columns.Add("Nombre", typeof(string));
            DT.Columns.Add("Apellido", typeof(string));
            DT.Columns.Add("Edad", typeof(int));

            Leer_DT();
        }

        public bool CargarPersona(Persona persona)
        {
            bool res = false;

            //CARGAR DT CON LAS PROPIEDADES DEL OBJETO persona
            DT.Rows.Add();
            int i = DT.Rows.Count - 1;

            DT.Rows[i]["DNI"] = persona.DNI;
            DT.Rows[i]["Nombre"] = persona.Nombre;
            DT.Rows[i]["Apellido"] = persona.Apellido;
            DT.Rows[i]["Edad"] = persona.Edad;

            DT.WriteXml("Personas.xml");
            return res;
        }
        private void Leer_DT()
        {
            if (System.IO.File.Exists("Personas.xml"))
            {
                DT.ReadXml("Personas.xml");
            }
        }
    }
}

