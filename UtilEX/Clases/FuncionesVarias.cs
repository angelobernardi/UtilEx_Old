using System;
using System.Collections.Generic;
using System.Text;

namespace UtilEX {
	/// <summary>
	/// 
	/// </summary>
	public class FuncionesVarias {

		#region VARIABLES

		Exception ex_Error;

		#endregion

		#region CONSTRUCTOR

		/// <summary>
		/// 
		/// </summary>
		public FuncionesVarias( ) {
		}

		#endregion

		#region FUNCIONES

		/// <summary>
		/// Si la cadena ingresada supera el largo máximo deseado, retorna una cadena truncada, caso contrario retorna la cadena completa.
		/// </summary>
		/// <param name="p_Cadena">Cadena a truncar</param>
		/// <param name="p_Largo_Maximo">Largo máximo deseado para la cadena</param>
		/// <returns>Cadena truncada al largo máximo, cuando corresponda.</returns>
		public string Truncar( string p_Cadena, int p_Largo_Maximo ) {
			if ( p_Cadena.Length > p_Largo_Maximo ) {
				return p_Cadena.Substring( 0, p_Largo_Maximo );
			} else {
				return p_Cadena;
			}
		}

		/// <summary>
		/// Formatea un numero, agregando los separadores de miles.
		/// </summary>
		/// <param name="p_Valor">Valor a Formatear</param>
		/// <param name="p_Separador_Miles">Caracter de separador de miles</param>
		/// <param name="p_Separador_Decimal">Caracter de separador de decimales</param>
		/// <returns>Valor formateado.</returns>
		public string Separador_de_Miles( string p_Valor, string p_Separador_Miles, string p_Separador_Decimal ) {
			p_Valor = p_Valor.Replace( p_Separador_Miles, "" );
			string[ ] s_Valor = p_Valor.Split( Convert.ToChar( p_Separador_Decimal ) );

			int i_Largo = s_Valor[ 0 ].Length;

			char[ ] c_Valor = s_Valor[ 0 ].ToCharArray( );
			string s_Resultado1 = string.Empty;
			string s_Resultado2 = string.Empty;
			for ( int i_Contador = i_Largo; i_Contador > 0; i_Contador = i_Contador - 1 ) {
				s_Resultado1 = s_Resultado1 + c_Valor[ i_Contador - 1 ];
			}
			i_Largo = s_Resultado1.Length;
			c_Valor = s_Resultado1.ToCharArray( );
			for ( int i_Contador = i_Largo; i_Contador > 0; i_Contador = i_Contador - 1 ) {
				if ( i_Contador % 3 == 0 && i_Contador != i_Largo ) {
					s_Resultado2 = s_Resultado2 + p_Separador_Miles;
				}
				s_Resultado2 = s_Resultado2 + c_Valor[ i_Contador - 1 ];
			}
			if ( s_Valor.Length > 1 ) {
				return s_Resultado2 + p_Separador_Decimal + s_Valor[ 1 ];
			} else {
				return s_Resultado2;
			}
		}

		/// <summary>
		/// Valida que el largo de la cadena ingresada sea igual o mayor al largo requerido
		/// </summary>
		/// <param name="p_String">Cadena a validar</param>
		/// <param name="p_Largo">Largo mínimo requerido</param>
		/// <returns>Booleano</returns>
		public bool Largo_Cadena( string p_String, long p_Largo ) {
			if ( p_String.Trim( ).Length >= p_Largo ) {
				return true;
			} else {
				return false;
			}
		}

		/// <summary>
		/// Valida que la cantidad de filas (rows) de un datatable sea igual o mayor que lo requerido.
		/// </summary>
		/// <param name="p_DataTable">Datatable a validar.</param>
		/// <param name="p_Cantidad_Elementos">Cantidad mínima de filas.</param>
		/// <returns></returns>
		public bool Filas_Datatable( System.Data.DataTable p_DataTable, long p_Cantidad_Elementos ) {
			if ( p_DataTable.Rows.Count >= p_Cantidad_Elementos ) {
				return true;
			} else {
				return false;
			}
		}

		/// <summary>
		/// Valida que la cantidad de tablas de un dataset sea igual o mayor que lo requerido
		/// </summary>
		/// <param name="p_DataSet">Dataset a validar</param>
		/// <param name="p_Cantidad_Elementos">Cantidad minima de tablas.</param>
		/// <returns></returns>
		public bool Tablas_Dataset( System.Data.DataSet p_DataSet, long p_Cantidad_Elementos ) {
			if ( p_DataSet.Tables.Count >= p_Cantidad_Elementos ) {
				return true;
			} else {
				return false;
			}
		}

		/// <summary>
		/// Retorna el Dígito Verificador de un RUT
		/// </summary>
		/// <param name="p_Rut">RUT, sin puntos ni DV</param>
		/// <returns>Dígito Verificador del RUT ingresado.</returns>
		public string Devuelve_DV( string p_Rut ) {
			int i_Rut;
			p_Rut = p_Rut.Replace( ".", "" );
			Validacion _Valida = new Validacion( );
			if ( p_Rut.Contains( "-" ) ) {
				ex_Error = new Exception( "El RUT ingresado no es válido. \n\tSe debe ingresar un RUT sin guión o Dígito Verificador." );
				throw ex_Error;
			} else {
				if ( _Valida.Es_Numero( p_Rut ) ) {
					i_Rut = Convert.ToInt32( p_Rut );
				} else {
					ex_Error = new Exception( "El RUT ingresado no es válido. \n\tSe debe ingresar un valor numérico." );
					throw ex_Error;
				}
			}
			int i_Largo = p_Rut.Length;
			int i_Digito;
			int i_Contador = 2;
			int i_Multiplo;
			int i_Acumulador = 0;
			

			while ( i_Rut != 0 ) {
				i_Multiplo = ( i_Rut % 10 ) * i_Contador;
				i_Acumulador = i_Acumulador + i_Multiplo;
				i_Rut = i_Rut / 10;
				i_Contador = i_Contador + 1;
				if ( i_Contador == 8 ) {
					i_Contador = 2;
				}
			}

			i_Digito = 11 - ( i_Acumulador % 11 );

			if ( i_Digito == 10 ) {
				return "K";
			} else if ( i_Digito == 11 ) {
				return "0";
			} else {
				return i_Digito.ToString( );
			}
		}

		#endregion

	}
}
