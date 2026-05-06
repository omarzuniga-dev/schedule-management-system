using ClosedXML.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using proyectoFinalDAE.Clases;
using proyectoFinalDAE.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectoFinalDAE
{
    public partial class añadirReporte : Form
    {
        Gestor gest = new Gestor();
        //Al usar otro metodo que no es EFC se necesita la cadena de conexion
        private string connectionString = "Server=localhost;Database=Horario_Escuela_Computacion;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False;";
        public añadirReporte()
        {
            InitializeComponent();
        }

        //Al cargar el formulario dependiendo del tipo de reporte se mostrara o no el combobox de filtro
        private void añadirReporte_Load(object sender, EventArgs e)
        {
            comboBoxTipoReporte.SelectedIndex = 0;
            comboBoxFormato.SelectedIndex = 0;
            if (comboBoxTipoReporte.Text == "Seleccione una opción")
            {
                cmbFiltro.Visible = false;
                lblFiltro.Visible = false;
            }
            else
            {
                cmbFiltro.Visible = true;
                lblFiltro.Visible = true;
            }
        }
        // Generar el reporte dependiendo de las selecciones realizadas
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            string tipoReporte = comboBoxTipoReporte.SelectedItem?.ToString();
            string formato = comboBoxFormato.SelectedItem?.ToString();

            // Validaciones basicas
            if (tipoReporte == "Seleccione una opción" || formato == "Seleccione una opción")
            {
                MessageBox.Show("Seleccione el tipo de reporte y el formato.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Generar el reporte de docentes
            if (tipoReporte == "Horarios Docentes")
            {
                string docenteSeleccionado = cmbFiltro.Text;
                if (string.IsNullOrEmpty(docenteSeleccionado))
                {
                    MessageBox.Show("Seleccione un docente para generar el horario.", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                GenerarHorarioDocenteReporte("dbo.vw_HorariosDetallados", "Horario_" + docenteSeleccionado.Replace(" ", "_"), formato);
            }
            //Generar reporte de materias
            else if (tipoReporte == "Reporte de Materias")
            {
                if (cmbFiltro.Text == "")
                {
                    MessageBox.Show("Seleccione si la materia es Técnica o Transversal.",
                        "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string tabla = cmbFiltro.SelectedItem.ToString() == "Materia Técnica"
                    ? "dbo.vw_Materias_Tecnicas"
                    : "dbo.vw_Materias_Transversales";

                GenerarReporte(tabla, "Materias_" + cmbFiltro.SelectedItem.ToString().Replace(" ", "_"), formato);
                return;
            }
            else if(tipoReporte == "Reporte por grupos")
            {
                string seccionSeleccionado = cmbFiltro.Text;
                if (string.IsNullOrEmpty(seccionSeleccionado))
                {
                    MessageBox.Show("Seleccione una seccion para generar el horario.", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                GenerarHorarioSeccion("dbo.vw_HorariosDetallados", "Horario_" + seccionSeleccionado.Replace(" ", "_"), formato);

            }
            else
            {
                string tabla = "";
                //Al contrario si no es ningun reporte especial se elige la tabla segun el tipo de reporte
                switch (tipoReporte)
                {
                    case "Plan de Carrera":
                        tabla = "dbo.Periodo";
                        break;
                    case "Detalle de carreras":
                        tabla = "dbo.Carrera";
                        break;
                    default:
                        tabla = "";
                        break;
                }

                if (!string.IsNullOrEmpty(tabla))
                    GenerarReporte(tabla, tipoReporte.Replace(" ", "_"), formato);
            }
        }

        //metodo para mostrar u ocultar el combobox de filtro dependiendo del tipo de reporte
        private void comboBoxTipoReporte_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string tipo = comboBoxTipoReporte.Text;
            if (tipo == "Seleccione una opción")
            {
                return;
            }
            if (tipo == "Horarios Docentes")
            {
                cmbFiltro.Visible = true;
                lblFiltro.Visible = true;
                cargarDocentes();
            }
            else if (tipo == "Reporte de Materias")
            {
                cmbFiltro.Visible = true;
                lblFiltro.Visible = true;
                cargarTipoMaterias();
                return;
            }
            else if (tipo == "Reporte por grupos")
            {
                cmbFiltro.Visible = true;
                lblFiltro.Visible = true;
                cargarSecciones();
                return;
            }
            else
            {
                cmbFiltro.Visible = false;
                lblFiltro.Visible = false;
            }
        }
        //Metodo para generar el reporte de horario docente
        private void GenerarHorarioDocenteReporte(string tabla, string nombreArchivoBase, string formato)
        {
            DataTable dt = new DataTable();
            string docenteSeleccionado = cmbFiltro.Text;
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string query = $@"
                SELECT docente, nombreAsignatura, nombreSeccion, dia, horaInicio, horaFin 
                FROM {tabla} 
                WHERE docente = @docente 
                AND Activo = 'Activo' 
                ORDER BY dia, horaInicio";


                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    
                    cmd.Parameters.AddWithValue("@docente", docenteSeleccionado);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        try { da.Fill(dt); }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al consultar la tabla {tabla}:\n{ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show($"No se encontraron registros para {docenteSeleccionado}.",
                    "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (formato != "PDF")
            {
                if (formato == "Excel") ExportarExcel(dt, nombreArchivoBase);
                else ExportarCSV(dt, nombreArchivoBase);
                return;
            }

            // Diseño del PDF a crear
            ExportarPDFConEstilo(dt, nombreArchivoBase);
        }

        private void GenerarHorarioSeccion(string tabla, string nombreArchivoBase, string formato)
        {
            DataTable dt = new DataTable();
            string seccionSeleccionada = cmbFiltro.Text;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string query = @"
                SELECT NombreSeccion, NombreAsignatura, Docente, dia, horaInicio, horaFin, codigoAula, modalidadClase
                FROM vw_HorariosDetallados
                WHERE NombreSeccion = @seccion 
                AND Activo = 'Activo' 
                ORDER BY dia, horaInicio";

                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    // 3. Cambiamos el parámetro para pasar la sección
                    cmd.Parameters.AddWithValue("@seccion", seccionSeleccionada);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        try
                        {
                            da.Fill(dt);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al consultar la vista vw_HorariosDetallados:\n{ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show($"No se encontraron registros para la sección {seccionSeleccionada}.",
                    "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (formato != "PDF")
            {
                if (formato == "Excel") ExportarExcel(dt, nombreArchivoBase);
                else ExportarCSV(dt, nombreArchivoBase);
                return;
            }

            // Diseño del PDF a crear
            ExportarPDFConEstiloSecciones(dt, nombreArchivoBase);
        }

        // Metodo para generar reportes generales
        private void GenerarReporte(string tabla, string nombreArchivoBase, string formato)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string query = $"SELECT * FROM {tabla}";
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    try { da.Fill(dt); }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al consultar la tabla {tabla}:\n{ex.Message}",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show($"No se encontraron registros en la tabla {tabla}.",
                    "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (formato == "PDF") ExportarPDFConEstilo(dt, nombreArchivoBase);
            else if (formato == "Excel") ExportarExcel(dt, nombreArchivoBase);
            else ExportarCSV(dt, nombreArchivoBase);
        }
        //metodo ppara exportar el PDF con estilo

        /*
                             { "NombreSeccion", "Familia" },
                    { "NombreAsignatura", "Materia" },
                    { "Dia", "Día" },
                    { "codigoAula", "Aula" },
                    { "modalidadClase", "Modalidad" },
         
         */
        private void ExportarPDFConEstilo(DataTable dt, string nombreArchivoBase)
        {
            string docenteSeleccionado = cmbFiltro.Text;
            using (SaveFileDialog sfd = new SaveFileDialog { Filter = "Archivo PDF|*.pdf", FileName = nombreArchivoBase + ".pdf" })
            {
                if (sfd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    using (FileStream fs = new FileStream(sfd.FileName, FileMode.Create))
                    {
                        Document doc = new Document(PageSize.A4, 25, 25, 50, 50);
                        PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                        doc.Open();

                        // Codigo para agregar logo desde una URL
                        try
                        {
                            string logoUrl = "https://www.itca.edu.sv/wp-content/uploads/2025/01/LogoITCA_Web.png";
                            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(new Uri(logoUrl));

                            float maxWidth = doc.PageSize.Width * 0.30f;
                            float maxHeight = 80f;
                            logo.ScaleToFit(maxWidth, maxHeight);

                            // Centrado horizontal arriba
                            float xPos = (doc.PageSize.Width - logo.ScaledWidth) / 2;
                            float yPos = doc.PageSize.Height - 100;

                            logo.SetAbsolutePosition(xPos, yPos);

                            doc.Add(logo);

                            // Espacio extra debajo del logo
                            doc.Add(new Paragraph("\n\n\n"));
                        }
                        catch
                        {
                            MessageBox.Show("No se pudo cargar el logo desde la URL.");
                        }


                        string categoriaDocente = "";

                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            string sqlCat = "SELECT categoria FROM dbo.Docente WHERE nombres + ' ' + apellidos = @doc";
                            using (SqlCommand cmd = new SqlCommand(sqlCat, conn))
                            {
                                cmd.Parameters.AddWithValue("@doc", docenteSeleccionado);
                                conn.Open();
                                var result = cmd.ExecuteScalar();
                                categoriaDocente = result?.ToString() ?? "";
                            }
                        }

                        string textoCategoria = categoriaDocente == "DocentePlanta"
                            ? "Docente de planta"
                            : "Docente por horas";


                        // Diseño del encabezado del reporte
                        Paragraph encabezado = new Paragraph { Alignment = Element.ALIGN_CENTER };
                        encabezado.Add(new Chunk("ITCA-FEPADE\n",
                            FontFactory.GetFont("Helvetica", 14, iTextSharp.text.Font.BOLD, BaseColor.RED)));

                        encabezado.Add(new Chunk("Escuela de Computación\n",
                            FontFactory.GetFont("Helvetica", 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));

                        // Este codigo se mostrara cuando el reporte sea de Horario Docente
                        if (nombreArchivoBase.ToLower().Contains("horario") || nombreArchivoBase.ToLower().Contains("docente"))
                        {
                            encabezado.Add(new Chunk("Nombre de profesor: " + docenteSeleccionado + "\n",
                                FontFactory.GetFont("Helvetica", 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));

                            encabezado.Add(new Chunk(textoCategoria + "\n\n",
                                FontFactory.GetFont("Helvetica", 10, iTextSharp.text.Font.NORMAL, BaseColor.DARK_GRAY)));
                        }


                        doc.Add(encabezado);



                        // Configuracion de la tabla
                        PdfPTable table = new PdfPTable(dt.Columns.Count) { WidthPercentage = 100f, SpacingBefore = 10f };
                        table.HeaderRows = 1;




                        // Diccionario de palabras para sustituir los encabezados de las tablas
                        Dictionary<string, string> encabezadosAmigables = new Dictionary<string, string>()
                {
                    { "docente", "Docente" },
                    { "nombreAsignatura", "Asignatura" },
                    { "nombreSeccion", "Familia" },
                    { "dia", "Día" },
                    { "horaInicio", "Hora Inicio" },
                    { "horaFin", "Hora Fin" },
                    { "idCarrera", "ID Carrera" },
                    { "nombreCarrera", "Nombre Carrera" },
                    { "tipo", "Tipo" },
                    { "idAsignatura", "ID Asignatura" },
                    { "codigoAsignatura", "Codigo Asignatura" },
                    { "naturaleza", "Naturaleza" },
                    { "creditos", "Creditos" },

                };

                        // Encabezados de la tabla
                        BaseColor headerColor = new BaseColor(200, 0, 0); // Rojo fuerte
                        BaseColor headerFontColor = BaseColor.WHITE;     // Texto blanco

                        foreach (DataColumn col in dt.Columns)
                        {
                            string nombreAmigable = encabezadosAmigables.ContainsKey(col.ColumnName)
                                ? encabezadosAmigables[col.ColumnName]
                                : col.ColumnName;

                            PdfPCell cell = new PdfPCell(new Phrase(nombreAmigable, FontFactory.GetFont("Helvetica", 10, iTextSharp.text.Font.BOLD, headerFontColor)))
                            {
                                BackgroundColor = headerColor,
                                HorizontalAlignment = Element.ALIGN_CENTER,
                                Padding = 5,
                                NoWrap = false // Este codigo ajusta el texto al ancho de la celda
                            };
                            table.AddCell(cell);
                        }

                        // Diseño de ls filas de las tablas
                        BaseColor rowColor1 = BaseColor.WHITE;
                        BaseColor rowColor2 = new BaseColor(230, 230, 230);
                        int fila = 0;

                        float[] columnWidths = new float[dt.Columns.Count];
                        for (int c = 0; c < dt.Columns.Count; c++)
                        {
                            int maxLength = dt.Columns[c].ColumnName.Length;
                            foreach (DataRow row in dt.Rows)
                            {
                                int len = row[c]?.ToString().Length ?? 0;
                                if (len > maxLength) maxLength = len;
                            }
                            columnWidths[c] = maxLength;
                        }
                        table.SetWidths(columnWidths);

                        foreach (DataRow row in dt.Rows)
                        {
                            foreach (var item in row.ItemArray)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(item?.ToString() ?? "", FontFactory.GetFont("Helvetica", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)))
                                {
                                    BackgroundColor = (fila % 2 == 0) ? rowColor1 : rowColor2,
                                    Padding = 5,
                                    NoWrap = false // Autoajusta el texto
                                };
                                table.AddCell(cell);
                            }
                            fila++;
                        }

                        doc.Add(table);
                        doc.Close();
                        writer.Close();
                    }

                    MessageBox.Show("PDF generado correctamente.", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error generando PDF:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ExportarPDFConEstiloSecciones(DataTable dt, string nombreArchivoBase)
        {
            string seccionSeleccionada = cmbFiltro.Text;
            if (dt.Columns.Contains("horaInicio") && dt.Columns.Contains("horaFin"))
            {
                dt.Columns.Add("Horario", typeof(string));

                foreach (DataRow row in dt.Rows)
                {
                    string inicioRaw = row["horaInicio"].ToString();
                    string finRaw = row["horaFin"].ToString();
                    DateTime dInicio, dFin;
                    if (DateTime.TryParse(inicioRaw, out dInicio) && DateTime.TryParse(finRaw, out dFin))
                    {
                        string horarioFormateado = $"{dInicio.ToString("h:mmtt")}-{dFin.ToString("h:mmtt")}";
                        row["Horario"] = horarioFormateado;
                    }
                    else
                    {
                        row["Horario"] = $"{inicioRaw} - {finRaw}";
                    }
                }
                if (dt.Columns.Contains("dia"))
                    dt.Columns["Horario"].SetOrdinal(dt.Columns.IndexOf("dia") + 1);
                dt.Columns.Remove("horaInicio");
                dt.Columns.Remove("horaFin");
            }
            using (SaveFileDialog sfd = new SaveFileDialog { Filter = "Archivo PDF|*.pdf", FileName = nombreArchivoBase + ".pdf" })
            {
                if (sfd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    using (FileStream fs = new FileStream(sfd.FileName, FileMode.Create))
                    {
                        Document doc = new Document(PageSize.A4.Rotate(), 10, 10, 30, 30); 
                        PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                        doc.Open();
                        try
                        {
                            string logoUrl = "https://www.itca.edu.sv/wp-content/uploads/2025/01/LogoITCA_Web.png";
                            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(new Uri(logoUrl));
                            float maxWidth = 150f;
                            logo.ScaleToFit(maxWidth, 80f);

                            // Posicionar logo
                            logo.SetAbsolutePosition((doc.PageSize.Width - logo.ScaledWidth) / 2, doc.PageSize.Height - 90);
                            doc.Add(logo);
                            doc.Add(new Paragraph("\n\n\n\n"));
                        }
                        catch { /* Ignorar si falla logo */ }
                        Paragraph encabezado = new Paragraph { Alignment = Element.ALIGN_CENTER };
                        encabezado.Add(new Chunk("ITCA-FEPADE\n", FontFactory.GetFont("Helvetica", 14, iTextSharp.text.Font.BOLD, BaseColor.RED)));
                        encabezado.Add(new Chunk("Escuela de Computación\n", FontFactory.GetFont("Helvetica", 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));

                        encabezado.Add(new Chunk($"Horario de Sección: {seccionSeleccionada}\n",
                            FontFactory.GetFont("Helvetica", 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));


                        encabezado.Add(new Chunk($"Generado el: {DateTime.Now.ToShortDateString()}\n\n",
                            FontFactory.GetFont("Helvetica", 8, iTextSharp.text.Font.NORMAL, BaseColor.GRAY)));

                        doc.Add(encabezado);


                        PdfPTable table = new PdfPTable(dt.Columns.Count) { WidthPercentage = 100f, SpacingBefore = 5f };

                        Dictionary<string, string> encabezadosAmigables = new Dictionary<string, string>()
                {
                    { "docente", "Docente" },
                    { "NombreAsignatura", "Materia" },
                    { "NombreSeccion", "Familia" },
                    { "dia", "Día" },
                    { "Horario", "Horario" }, 
                    { "codigoAula", "Aula" },
                    { "modalidadClase", "Modalidad" }
                };


                        BaseColor headerColor = new BaseColor(178, 34, 34);
                        BaseColor headerFontColor = BaseColor.WHITE;

                        foreach (DataColumn col in dt.Columns)
                        {
                            string nombreAmigable = encabezadosAmigables.ContainsKey(col.ColumnName)
                                ? encabezadosAmigables[col.ColumnName]
                                : col.ColumnName;

                            PdfPCell cell = new PdfPCell(new Phrase(nombreAmigable, FontFactory.GetFont("Helvetica", 9, iTextSharp.text.Font.BOLD, headerFontColor)))
                            {
                                BackgroundColor = headerColor,
                                HorizontalAlignment = Element.ALIGN_CENTER,
                                Padding = 6,
                                BorderColor = BaseColor.GRAY
                            };
                            table.AddCell(cell);
                        }

                        BaseColor rowColor1 = BaseColor.WHITE;
                        BaseColor rowColor2 = new BaseColor(240, 240, 240);
                        int fila = 0;

                        foreach (DataRow row in dt.Rows)
                        {
                            foreach (var item in row.ItemArray)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(item?.ToString() ?? "", FontFactory.GetFont("Helvetica", 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)))
                                {
                                    BackgroundColor = (fila % 2 == 0) ? rowColor1 : rowColor2,
                                    Padding = 5,
                                    HorizontalAlignment = Element.ALIGN_CENTER,
                                    VerticalAlignment = Element.ALIGN_MIDDLE
                                };
                                table.AddCell(cell);
                            }
                            fila++;
                        }

                        doc.Add(table);
                        doc.Close();
                        writer.Close();
                    }

                    MessageBox.Show("Reporte de Sección generado correctamente.", "PDF Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error generando PDF:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Reporte de Excel
        private void ExportarExcel(DataTable dt, string nombreArchivoBase)
        {
            using (SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Archivo Excel|*.xlsx",
                FileName = nombreArchivoBase + ".xlsx"
            })
            {
                if (sfd.ShowDialog() != DialogResult.OK) return;
                try
                {
                    using (var wb = new XLWorkbook())
                    {
                        var ws = wb.Worksheets.Add(nombreArchivoBase);
                        ws.Cell(1, 1).Value = nombreArchivoBase.Replace("_", " ");
                        ws.Cell(1, 1).Style.Font.Bold = true;
                        ws.Cell(1, 1).Style.Font.FontSize = 14;
                        ws.Range(1, 1, 1, dt.Columns.Count).Merge();
                        ws.Cell(3, 1).InsertTable(dt, "Tabla" + nombreArchivoBase, true);
                        ws.Columns().AdjustToContents();
                        wb.SaveAs(sfd.FileName);
                    }
                    MessageBox.Show("Excel generado correctamente.", "Listo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error generando Excel:\n" + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Reporte CSV
        private void ExportarCSV(DataTable dt, string nombreArchivoBase)
        {
            using (SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Archivo CSV|*.csv",
                FileName = nombreArchivoBase + ".csv"
            })
            {
                if (sfd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    using (StreamWriter sw = new StreamWriter(sfd.FileName))
                    {
                        // Encabezados
                        string[] columnNames = dt.Columns.Cast<DataColumn>()
                            .Select(c => c.ColumnName).ToArray();
                        sw.WriteLine(string.Join(",", columnNames));

                        // Filas
                        foreach (DataRow row in dt.Rows)
                        {
                            string[] fields = row.ItemArray.Select(f => f.ToString().Replace(",", " ")).ToArray();
                            sw.WriteLine(string.Join(",", fields));
                        }
                    }
                    MessageBox.Show("CSV generado correctamente.", "Listo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error generando CSV:\n" + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //metodo para cargar los docentes en el combobox
        private async void cargarDocentes()
        {
            try
            {
                List<Docente> datosDocentes = await gest.listarDocentes();
                cmbFiltro.DataSource = datosDocentes;
                cmbFiltro.DisplayMember = "NombreCompleto";
                cmbFiltro.ValueMember = "IdDocente";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        //metodo para cargar los tipos de materias en el combobox
        private void cargarTipoMaterias()
        {
            cmbFiltro.DataSource = null;
            cmbFiltro.Items.Clear();
            cmbFiltro.Items.AddRange(new string[]
            {
                "Materia Técnica",
                "Materia Transversal",
            });
        }
        private async void cargarSecciones()
        {
            try
            {
                List<Seccion> datosSeccion = await gest.listarSeccion();
                cmbFiltro.DataSource = datosSeccion;
                cmbFiltro.DisplayMember = "grupoBase";
                cmbFiltro.ValueMember = "IdSeccion";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        
    }
}
