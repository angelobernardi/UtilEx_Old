using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace UtilEX {

	/// <summary>
	/// Contiene funciones para manejo de archivos e información de disco.
	/// </summary>
	public class SistemaArchivos {

		#region Variables

		private Exception ex_Error = new Exception();
		private string s_RutaArchivo = string.Empty;

		#endregion

		#region Constructor

		/// <summary>
		/// Constructor Vacío
		/// </summary>
		public SistemaArchivos( ) {

		}

		#endregion

		#region Funciones

		/// <summary>
		/// Devuelve el tamaño en bytes del disco
		/// </summary>
		/// <param name="p_Unidad">Unidad a consultar</param>
		/// <returns></returns>
		public long Obtiene_Espacio_En_Disco( string p_Unidad ) {
			DriveInfo di_InfoDisco = new DriveInfo( p_Unidad );
			if ( di_InfoDisco.IsReady ) {   //  EL DISCO DEBE ESTAR LISTO, SINO LANZA UNA EXCEPCIÓN
				return di_InfoDisco.TotalSize;
			} else {
				return 0;
			}
		}

		/// <summary>
		/// Devuelve el espacio libre en bytes del disco
		/// </summary>
		/// <param name="p_Unidad">Unidad a consultar</param>
		/// <returns></returns>
		public long Obtiene_Espacio_Libre_En_Disco( string p_Unidad ) {
			DriveInfo di_InfoDisco = new DriveInfo( p_Unidad );
			if ( di_InfoDisco.IsReady ) {
				return di_InfoDisco.TotalFreeSpace;
			} else {
				return 0;
			}
		}

		/// <summary>
		/// Devuelve el espacio utilizado en bytes del disco
		/// </summary>
		/// <param name="p_Unidad">Unidad a consultar</param>
		/// <returns></returns>
		public long Obtiene_Espacio_Utilizado_En_Disco( string p_Unidad ) {
			DriveInfo di_InfoDisco = new DriveInfo( p_Unidad );
			if ( di_InfoDisco.IsReady ) {
				return di_InfoDisco.TotalSize - di_InfoDisco.TotalFreeSpace;
			} else {
				return 0;
			}
		}

		/// <summary>
		/// Valida si el archivo se puede abrir para lectura/escritura, o está tomado por algún proceso.
		/// </summary>
		/// <param name="p_Ruta_Archivo">Archivo a validar</param>
		/// <returns>Verdadero o Falso</returns>
		public bool Archivo_Esta_Bloqueado( string p_Ruta_Archivo ) {
			FileInfo fi_Archivo = new FileInfo( p_Ruta_Archivo );
			Stream sw;
			try {
				sw = fi_Archivo.Open( FileMode.Open, FileAccess.Read, FileShare.None );
				sw.Close( );
				return true;
			} catch {
				return false;
			}
		}

		/// <summary>
		/// Valida si el archivo se puede abrir para lectura/escritura, o está tomado por algún proceso.
		/// </summary>
		/// <returns>Verdadero o Falso</returns>
		public bool Archivo_Esta_Bloqueado( ) {
			FileInfo fi_Archivo = new FileInfo(this.s_RutaArchivo);
			Stream sw;
			try {
				sw = fi_Archivo.Open( FileMode.Open, FileAccess.Read, FileShare.None );
				sw.Close( );
				return true;
			} catch {
				return false;
			}
		}

		/// <summary>
		/// Entrega el listado de archivos de un directorio/carpeta local o de red.
		/// </summary>
		/// <param name="p_Directorio">Ruta del directorio</param>
		/// <param name="p_Opciones">Opciones de búsqueda</param>
		/// <param name="p_Filtro">Filtro de búsqueda. Si se especifica "string.empty" lista todos los archivos.</param>
		/// <returns></returns>
		public string[ ] Listado_Archivos_Directorio( string p_Directorio, SearchOption p_Opciones, string p_Filtro ) {
			string s_filtro = string.Empty;
			if ( p_Filtro.CompareTo( string.Empty ) == 0 ) {
				s_filtro = "*.*";
			} else {
				s_filtro = p_Filtro;
			}
			return Directory.GetFiles( p_Directorio, s_filtro, p_Opciones );
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

		public string RutaArchivo{
			get {
				return s_RutaArchivo;
			}
			set {
				this.s_RutaArchivo = value;
			}
		
		}

		#endregion

	}
}
