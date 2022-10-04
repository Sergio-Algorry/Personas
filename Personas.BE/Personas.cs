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

        public bool BorrarPersona(string dni)
        {
            bool res = false;
            int fila = BuscarFilaPersona(dni);

            if(fila!=-1)
            {
                DT.Rows[fila].Delete();
                DT.WriteXml("Personas.xml");
                res = true;
            }

            return res;
        }

        public int BuscarFilaPersona(string dni)
        {
            int fila = -1;

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                if (DT.Rows[i]["DNI"].ToString() == dni)
                {
                    fila = i;
                    break;
                }
            }

            return fila;
        }

        public Persona BuscarPersona(string dni)
        {
            Persona persona = new Persona();

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                if (DT.Rows[i]["DNI"].ToString() == dni)
                {
                    persona.DNI = DT.Rows[i]["DNI"].ToString();
                    persona.Nombre = DT.Rows[i]["Nombre"].ToString();
                    persona.Apellido = DT.Rows[i]["Apellido"].ToString();
                    persona.Edad = System.Convert.ToInt32( DT.Rows[i]["Edad"]);
                    break;
                }
            }

            return persona;
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

