using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProTrack; // Asegúrate de tener el namespace correcto

static class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        try
        {
            Config.Cargar(); // Intenta cargar configuración (IP y puerto)

            string url = $"ws://{Config.IP}:{Config.Puerto}";

            // Usamos Task.Run + .Result porque Main no puede ser async
            bool conectado = Task.Run(() => ClienteWS.Conectar(url)).Result;

            if (conectado)
            {
                // Mostrar el login si se conectó correctamente
                Application.Run(new FRMLogin());
            }
            else
            {
                MessageBox.Show("No se pudo establecer conexión con el servidor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
        catch (Exception ex)
        {
            // Si falla al cargar configuración o al conectar, abrimos configurador de red
            MessageBox.Show("No se pudo conectar al servidor o cargar configuración.\n" + ex.Message, "Configuración", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Application.Run(new Configuracion()); // Aquí abres el formulario para cambiar IP/puerto
        }
    }
}
