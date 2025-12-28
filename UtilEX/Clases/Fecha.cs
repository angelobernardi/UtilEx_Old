using System;
using System.Collections.Generic;
using System.Text;

namespace UtilEX {
	/// <summary>
	/// Contiene funciones para manejo de fechas y horas
	/// </summary>
	public class Fecha {

		#region Variables

		private Exception ex_Error;// = new Exception("No se puede reconocer el parametro como un mes.");

		#endregion

		#region Constructor

		/// <summary>
		/// Constructor Vacio
		/// </summary>
		public Fecha( ) {

		}

		#endregion

		#region Funciones

		/// <summary>
		/// Retorna el nombre del mes
		/// </summary>
		/// <param name="p_Mes">Número de mes</param>
		/// <returns>Nombre del mes consultado</returns>
		public string Nombre_Mes( string p_Mes ) {
			int i_Mes;
			try {
				i_Mes = Convert.ToInt16( p_Mes );
			} catch ( Exception ex ) {
				ex_Error = new Exception( "Debe ingresar un valor numérico. \nERROR: \"" + ex.Message + "\"");
				throw ex_Error;
			}
			return Nombre_Mes( i_Mes );
		}

		/// <summary>
		/// Retorna el nombre del mes
		/// </summary>
		/// <param name="p_Mes">Número de mes</param>
		/// <returns>Nombre del mes consultado</returns>
		public string Nombre_Mes( int p_Mes ) {
			switch ( p_Mes ) {
				case 1:
					return "Enero";
				case 2:
					return "Febrero";
				case 3:
					return "Marzo";
				case 4:
					return "Abril";
				case 5:
					return "Mayo";
				case 6:
					return "Junio";
				case 7:
					return "Julio";
				case 8:
					return "Agosto";
				case 9:
					return "Septiembre";
				case 10:
					return "Octubre";
				case 11:
					return "Noviembre";
				case 12:
					return "Diciembre";
				default:
					ex_Error = new Exception( "Debe ingresar un mes entre 01 y 12" );
					throw ex_Error;
			}
		}

		/// <summary>
		/// Retorna el nombre del mes
		/// </summary>
		/// <param name="p_Mes"></param>
		/// <param name="p_Largo"></param>
		/// <returns></returns>
		public string Nombre_Mes_Corto( string p_Mes, int p_Largo ) {
			int i_Mes = 0;
			try {
				i_Mes = Convert.ToInt16( p_Mes );
			} catch ( Exception ex ) {
				ex_Error = new Exception( "Debe ingresar un valor numérico. \nERROR: \"" + ex.Message + "\"" );
				throw ex_Error;
			}
			return Nombre_Mes_Corto( i_Mes, p_Largo );
		}

		/// <summary>
		/// Retorna el nombre del mes
		/// </summary>
		/// <param name="p_Mes"></param>
		/// <param name="p_Largo"></param>
		/// <returns></returns>
		public string Nombre_Mes_Corto( int p_Mes, int p_Largo ) {
			string s_Mes = Nombre_Mes( p_Mes );
			if ( s_Mes.Length > p_Largo ) {
				return s_Mes.Substring( 0, p_Largo );
			} else {
				return s_Mes;
			}
		}

		/// <summary>
		/// Calcula la diferencia en meses entre 2 fechas.
		/// </summary>
		/// <param name="p_fecha_menor">Fecha de inicio</param>
		/// <param name="p_fecha_mayor">Fecha de término</param>
		/// <returns>Cantidad de meses de diferencia</returns>
		/// 
		public int Diferencia_Meses( DateTime p_fecha_menor, DateTime p_fecha_mayor ) {
			int i_diferencia_en_dias;
			int i_factor = 1;
			//	OBTIENE LA CANTIDAD DE DÍAS DE DIFERENCIA ENTRE AMBAS FECHAS. TRABAJA CON VALORES POSITIVOS.
			if ( p_fecha_menor < p_fecha_mayor ) {
				i_diferencia_en_dias = Convert.ToInt32( ( ( TimeSpan )( p_fecha_mayor - p_fecha_menor ) ).TotalDays );
			} else {
				i_diferencia_en_dias = Convert.ToInt32( ( ( TimeSpan )( p_fecha_menor - p_fecha_mayor ) ).TotalDays );
				i_factor = -1;	//	SI LA SEGUNDA FECHA ES MENOR, EL RESULTADO LO MULTIPLICA POR -1
			}
			int i_contador = -1;	//	INICIAR EN 0 PARA TOMAR COMO 1 MES DESDE 1 DÍA DE DIFERENCIA EN ADELANTE. -1 PARA CUENTA NORMAL.
			while ( i_diferencia_en_dias > 0 ) {
				//	RESTA LA CANTIDAD DE DÍAS DE CADA MES, A PARTIR DEL MES DE INICIO EN ADELANTE, HASTA QUE LA DIFERENCIA SEA < 0 
				i_diferencia_en_dias = i_diferencia_en_dias - DateTime.DaysInMonth( p_fecha_menor.AddMonths( i_contador ).Year, p_fecha_menor.AddMonths( i_contador ).Month );
				//	CADA VUELTA DEL CICLO CORRESPONDE A 1 MES DE DIFERENCIA.
				i_contador++;
			};
			return ( i_contador * i_factor );
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
