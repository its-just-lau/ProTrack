using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace ProTrack
{
    public static class ClienteWS
    {
        private static ClientWebSocket _socket = new ClientWebSocket();
        private static CancellationTokenSource _cts = new CancellationTokenSource();

        public static event Action<string> AlRecibirMensaje;
        public static event Action<string, string> AlRecibirRespuestaEstado; // ej. estado = "login_ok", datos = "Bienvenido"

        public static async Task<bool> Conectar(string url)
        {
            if (_socket.State == WebSocketState.Open)
                return true;

            try
            {
                _socket = new ClientWebSocket();
                _cts = new CancellationTokenSource();
                await _socket.ConnectAsync(new Uri(url), _cts.Token);

                _ = EscucharMensajes(); // Escuchar en segundo plano
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private static async Task EscucharMensajes()
        {
            var buffer = new byte[4096];

            while (_socket.State == WebSocketState.Open)
            {
                try
                {
                    var result = await _socket.ReceiveAsync(new ArraySegment<byte>(buffer), _cts.Token);
                    if (result.MessageType == WebSocketMessageType.Close)
                        break;

                    string mensaje = Encoding.UTF8.GetString(buffer, 0, result.Count);

                    try
                    {
                        var objeto = JsonConvert.DeserializeObject<Dictionary<string, object>>(mensaje);
                        if (objeto != null && objeto.ContainsKey("estado") && objeto.ContainsKey("datos"))
                        {
                            string estado = objeto["estado"]?.ToString() ?? "";
                            string datos = objeto["datos"]?.ToString() ?? "";
                            AlRecibirRespuestaEstado?.Invoke(estado, datos);
                        }
                        else
                        {
                            AlRecibirMensaje?.Invoke(mensaje);
                        }
                    }
                    catch
                    {
                        AlRecibirMensaje?.Invoke(mensaje); // JSON inválido, enviar como texto
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al recibir mensaje: {ex.Message}", "WebSocket", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static async Task EnviarAsync(object objeto)
        {
            if (_socket.State != WebSocketState.Open) return;

            string mensaje = JsonConvert.SerializeObject(objeto);
            byte[] bytes = Encoding.UTF8.GetBytes(mensaje);
            await _socket.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, true, _cts.Token);
        }

        public static async Task DesconectarAsync()
        {
            try
            {
                if (_socket.State == WebSocketState.Open)
                {
                    await _socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Cierre desde cliente", CancellationToken.None);
                    MessageBox.Show("Desconectado correctamente del servidor WebSocket.", "Desconexión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ya estabas desconectado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al desconectar: " + ex.Message);
            }
        }

        public static bool EstaConectado => _socket?.State == WebSocketState.Open;
    }
}
