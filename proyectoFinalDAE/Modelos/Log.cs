using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Logs")]
public class Log
{
    [Key]
    public int IdLogs { get; set; } 

    public string Usuario { get; set; }

    public DateTime Fecha { get; set; }

    public string Accion { get; set; }

    public string TablaAfectada { get; set; }

    public string Descripcion { get; set; }
}
