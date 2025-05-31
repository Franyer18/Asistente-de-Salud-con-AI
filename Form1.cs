using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

namespace Servicios_de_Salud
{
    public partial class Form1 : Form
    {
        private string connectionString = "Data Source=DESKTOP-VF4FHTO\\SQLEXPRESS;Initial Catalog=ServiciosSaludDB;Integrated Security=True";
        private string openAiApiKey = "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";

        // Historial de consultas
        private List<HistorialConsulta> historialConsultas = new List<HistorialConsulta>();
        private string rutaHistorial = "historial_consultas.json";

        public Form1()
        {
            InitializeComponent();
            dgvResultados.AutoGenerateColumns = true;
            CargarHistorial();
        }

        private async void btnConsultaIA_Click(object sender, EventArgs e)
        {
            string consulta = txtConsultaIA.Text.Trim();
            if (string.IsNullOrEmpty(openAiApiKey) || string.IsNullOrEmpty(consulta))
            {
                MessageBox.Show("Ingrese la consulta.");
                return;
            }

            // Enfoca la consulta en Jutiapa
            string prompt = $"Responde considerando únicamente información relevante para el departamento de Jutiapa, Guatemala. {consulta}";

            string respuesta = await ConsultarOpenAI(openAiApiKey, prompt);
            var lugares = ExtraerLugaresDeRespuesta(respuesta);

            if (lugares.Count > 0)
            {
                txtRespuestaIA.Text = "Resultados encontrados:\r\n";
                foreach (var lugar in lugares)
                {
                    txtRespuestaIA.Text += $"- {lugar.Nombre}, {lugar.Direccion}, {lugar.Telefono}, {lugar.Coordenadas}\r\n";
                }
            }
            else
            {
                txtRespuestaIA.Text = respuesta;
            }

            dgvResultados.DataSource = null;
            dgvResultados.DataSource = lugares;

            GuardarConsulta(consulta, respuesta, DateTime.Now);

            // Guardar en historial local
            historialConsultas.Add(new HistorialConsulta
            {
                Consulta = consulta,
                Respuesta = respuesta,
                Fecha = DateTime.Now
            });
            GuardarHistorial();
        }

        private async Task<string> ConsultarOpenAI(string apiKey, string pregunta)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

                var requestBody = new
                {
                    model = "gpt-3.5-turbo",
                    messages = new[]
                    {
                        new { role = "user", content = pregunta }
                    }
                };

                var content = new StringContent(JsonConvert.SerializeObject(requestBody), System.Text.Encoding.UTF8, "application/json");
                var response = await client.PostAsync("https://api.openai.com/v1/chat/completions", content);
                var responseString = await response.Content.ReadAsStringAsync();

                dynamic jsonResponse = JsonConvert.DeserializeObject(responseString);

                if (jsonResponse == null || jsonResponse.choices == null || jsonResponse.choices.Count == 0)
                {
                    if (jsonResponse != null && jsonResponse.error != null && jsonResponse.error.message != null)
                        return "Error de OpenAI: " + jsonResponse.error.message.ToString();

                    return "No se recibió una respuesta válida de la IA.";
                }

                return jsonResponse.choices[0].message.content.ToString();
            }
        }

        private void GuardarConsulta(string consulta, string respuestaIA, DateTime fecha)
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    var cmd = new SqlCommand("INSERT INTO Consultas (Consulta, RespuestaIA, Fecha) VALUES (@consulta, @respuestaIA, @fecha)", conn);
                    cmd.Parameters.AddWithValue("@consulta", consulta);
                    cmd.Parameters.AddWithValue("@respuestaIA", (object)respuestaIA ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@fecha", fecha);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la consulta: " + ex.Message);
            }
        }

        private List<LugarSalud> ExtraerLugaresDeRespuesta(string respuesta)
        {
            try
            {
                int start = respuesta.IndexOf('[');
                int end = respuesta.LastIndexOf(']');
                if (start != -1 && end != -1 && end > start)
                {
                    string json = respuesta.Substring(start, end - start + 1);
                    return JsonConvert.DeserializeObject<List<LugarSalud>>(json);
                }
            }
            catch
            {
                // Si falla, usa el método anterior
            }

            var lista = new List<LugarSalud>();
            var lineas = respuesta.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var linea in lineas)
            {
                if (linea.Contains("Nombre:") && linea.Contains("Dirección:"))
                {
                    var lugar = new LugarSalud();
                    var partes = linea.Split(',');
                    foreach (var parte in partes)
                    {
                        if (parte.Contains("Nombre:")) lugar.Nombre = parte.Replace("Nombre:", "").Trim();
                        if (parte.Contains("Dirección:")) lugar.Direccion = parte.Replace("Dirección:", "").Trim();
                        if (parte.Contains("Teléfono:")) lugar.Telefono = parte.Replace("Teléfono:", "").Trim();
                        if (parte.Contains("Coordenadas:")) lugar.Coordenadas = parte.Replace("Coordenadas:", "").Trim();
                    }
                    lista.Add(lugar);
                }
            }
            return lista;
        }

        // Métodos de historial local
        private void GuardarHistorial()
        {
            try
            {
                string json = JsonConvert.SerializeObject(historialConsultas, Formatting.Indented);
                File.WriteAllText(rutaHistorial, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el historial: " + ex.Message);
            }
        }

        private void CargarHistorial()
        {
            try
            {
                if (File.Exists(rutaHistorial))
                {
                    string json = File.ReadAllText(rutaHistorial);
                    historialConsultas = JsonConvert.DeserializeObject<List<HistorialConsulta>>(json) ?? new List<HistorialConsulta>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el historial: " + ex.Message);
                historialConsultas = new List<HistorialConsulta>();
            }
        }

        // Botón para exportar historial manualmente
        private void btnExportarHistorial_Click(object sender, EventArgs e)
        {
            try
            {
                GuardarHistorial();
                MessageBox.Show("Historial exportado correctamente a historial_consultas.json");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar el historial: " + ex.Message);
            }
        }

        // Clases auxiliares
        public class LugarSalud
        {
            public string Nombre { get; set; }
            public string Direccion { get; set; }
            public string Telefono { get; set; }
            public string Coordenadas { get; set; }
        }

        public class HistorialConsulta
        {
            public string Consulta { get; set; }
            public string Respuesta { get; set; }
            public DateTime Fecha { get; set; }
        }
    }
}




