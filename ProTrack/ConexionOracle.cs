using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;

namespace ProTrack
{
    public class ConexionOracle
    {
        private readonly string _walletLocation = @"C:\path\to\your\wallet"; // Reemplaza con la ruta real
        private readonly string _connectionString =
            "User Id=your_username;Password=your_password;" +
            "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=tcps)(HOST=your_db_host)(PORT=your_db_port)))" +
            "(CONNECT_DATA=(SERVICE_NAME=your_service_name)))";

        public OracleConnection AbrirConexion()
        {
            try
            {
                OracleConfiguration.WalletLocation = _walletLocation;

                OracleConnection conexion = new OracleConnection(_connectionString);
                conexion.Open();
                return conexion;
            }
            catch (OracleException ex)
            {
                Console.WriteLine("Error al conectar a Oracle: " + ex.Message);
                return null;
            }
        }

        public void CerrarConexion(OracleConnection conexion)
        {
            if (conexion != null && conexion.State == ConnectionState.Open)
            {
                conexion.Close();
                conexion.Dispose();
            }
        }

        public DataTable EjecutarConsulta(string consulta)
        {
            using (OracleConnection conexion = AbrirConexion())
            {
                if (conexion == null) return null;

                OracleCommand comando = new OracleCommand(consulta, conexion);
                OracleDataAdapter adaptador = new OracleDataAdapter(comando);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                CerrarConexion(conexion);
                return tabla;
            }
        }
    }
}
