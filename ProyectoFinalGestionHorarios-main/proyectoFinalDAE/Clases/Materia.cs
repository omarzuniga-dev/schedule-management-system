using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoFinalDAE.Clases
{
    internal class Materia
    {
        public string carrera { get; set; }
        public string materia { get; set; }
        public string aula { get; set; }
        public string docente { get; set; }
        public string grupo { get; set; }
        public string fechaInicio { get; set; }
        public string fechaFin { get; set; }
        public string horario { get; set; }
        public string dia { get; set; }

        public Materia(string materia, string carrera, string grupo, string docente, string fechaInicio, string fechaFin, string dia, string horario, string aula)
        {
            this.materia = materia;
            this.carrera = carrera;
            this.grupo = grupo;
            this.docente = docente;
            this.fechaInicio = fechaInicio;
            this.fechaFin = fechaFin;
            this.dia = dia;
            this.horario = horario;
            this.aula = aula;
        }
    }
}
