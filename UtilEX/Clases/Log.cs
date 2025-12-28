using System.IO;
using System;
using System.Collections.Generic;
using System.Text;

namespace UtilEX {
	/// <summary>
	/// Proporciona funciones para el manejo de archivos de registro (logs)
	/// </summary>
	public class Log {

		#region Variables

		private string s_Extension_Archivo;
		private string s_Ruta_Archivo;
		private StreamWriter sw_Archivo_Log;
		private StringBuilder sb_Contenido_Log;
		private Exception ex_Error = new Exception( );

		#endregion

		#region Constructor

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="p_Ruta_Archivo">Ruta donde se escribirá el archivo.</param>
		/// <param name="p_Nombre_Archivo">Nombre del archivo.</param>
		/// <param name="p_Extension_Archivo">Extensión que se le dará al archivo.</param>
		public Log( string p_Ruta_Archivo, string p_Nombre_Archivo, string p_Extension_Archivo ) {
			if ( this.s_Extension_Archivo.Substring( 0, 1 ).CompareTo( "." ) == 0 ) {
				this.s_Extension_Archivo = p_Extension_Archivo;
			} else {
				this.s_Extension_Archivo = "." + p_Extension_Archivo;
			}
			this.s_Ruta_Archivo = @p_Ruta_Archivo + @p_Nombre_Archivo;
			sw_Archivo_Log = new StreamWriter( s_Ruta_Archivo + s_Extension_Archivo );
			sb_Contenido_Log = new StringBuilder( );
		}

		#endregion

		#region Funciones

		/// <summary>
		/// Agrega una linea al log
		/// </summary>
		/// <param name="p_texto">linea a agregar</param>
		public void Agrega_Linea( string p_texto ) {
			sb_Contenido_Log.AppendLine( p_texto );
		}

		/// <summary>
		/// Escribe el archivo.
		/// </summary>
		/// <returns>booleano</returns>
		public bool Escribe_Log( ) {
			bool b_Respuesta = true;
			try {
				sw_Archivo_Log.Write( sb_Contenido_Log );
				sw_Archivo_Log.Close( );
			} catch ( Exception e ) {
				b_Respuesta = false;
				ex_Error = e;
			} finally {
				GC.WaitForPendingFinalizers( );
				GC.Collect( );
			}
			return b_Respuesta;
		}

		#endregion

		#region Propiedades

		/// <summary>
		/// Retorna el ultimo error producido
		/// </summary>
		public Exception get_Error {
			get {
				return this.ex_Error;
			}
		}

		#endregion

	}
}