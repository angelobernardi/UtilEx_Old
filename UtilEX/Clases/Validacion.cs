using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace UtilEX {
	/// <summary>
	/// Contiene funciones de validación de datos y formatos.
	/// </summary>
	public class Validacion {

		#region Variables

		private Exception ex_Error = new Exception( );

		#endregion

		#region Constructor

		/// <summary>
		/// Constructor Vacío.
		/// </summary>
		public Validacion( ) {

		}

		#endregion

		#region Funciones

		/// <summary>
		/// Valida si el valor ingersado es numérico.
		/// </summary>
		/// <param name="p_Numero">Valor a validar.</param>
		/// <returns>booleano</returns>
		public bool Es_Numero( string p_Numero ) {
			try {
				Int64 i = Convert.ToInt64( p_Numero );
				return true;
			} catch ( FormatException ) {
				return false;
			}
		}

		/// <summary>
		/// Valida si la cadena ingresada contiene numeros.
		/// </summary>
		/// <param name="p_Cadena">Cadena a validar</param>
		/// <returns>Booleano</returns>
		public bool Contiene_Numeros( string p_Cadena ) {
			char[ ] c_Caracteres = p_Cadena.ToCharArray( );
			int i_largo = c_Caracteres.Length;
			for ( int i_contador = 0; i_contador < i_largo; i_contador++ ) {
				if ( Es_Numero( c_Caracteres[ i_contador ].ToString( ) ) ) {
					return true;
				}
			}
			return false;

		}

		/// <summary>
		/// Valida si el RUT ingresado es válido.
		/// </summary>
		/// <param name="p_Rut">RUT a validar. Incluye Guión y Dígito Verificador.</param>
		/// <returns>booleano</returns>
		public bool Es_RUT( string p_Rut ) {
			int i_Largo = p_Rut.Length;
			int i_Indice_Guion = p_Rut.IndexOf( "-", 0, i_Largo );
			int i_Digito;
			int i_Contador;
			int i_Multiplo;
			int i_Acumulador;
			string s_Digito_Verificador;
			if ( i_Indice_Guion == -1 ) {
				return false;
			}
			string s_Rut = p_Rut.Substring( 0, i_Indice_Guion );
			int i_Rut;
			if ( Es_Numero( s_Rut ) ) {
				i_Rut = Convert.ToInt32( s_Rut );
			} else {
				return false;
			}

			string s_Digito_Verificador_Original = p_Rut.Substring( ( i_Indice_Guion + 1 ), 1 );

			i_Contador = 2;
			i_Acumulador = 0;

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
			s_Digito_Verificador = i_Digito.ToString( ).Trim( );
			if ( i_Digito == 10 ) {
				s_Digito_Verificador = "K";
			} else if ( i_Digito == 11 ) {
				s_Digito_Verificador = "0";
			}
			if ( s_Digito_Verificador.CompareTo( s_Digito_Verificador_Original.ToString( ).ToUpper( ) ) == 0 ) {
				return true;
			} else {
				return false;
			}
		}
	  		
		/// <summary>
		/// Si un valor es nulo, lo reemplaza por el valor especificado, caso contrario retorna el valor original
		/// </summary>
		/// <param name="p_Valor">Valor a evaluar</param>
		/// <returns>Retorna 0 (int)</returns>
		public object Es_Nulo( object p_Valor ) {
			return Es_Nulo( p_Valor, 0 );
		}

		/// <summary>
		/// Si un valor es nulo, lo reemplaza por el valor especificado, caso contrario retorna el valor original
		/// </summary>
		/// <param name="p_Valor">Valor a evaluar</param>
		/// <param name="p_Retorno">Valor de retorno en caso de que el valor a evaluar sea nulo</param>
		/// <returns>p_Retorno</returns>
		public object Es_Nulo( object p_Valor, object p_Retorno ) {
			if ( Convert.IsDBNull( p_Valor ) ) {
				return p_Retorno;
			} else if ( p_Valor == null ) {
				return p_Retorno;
			} else {
				return p_Valor;
			}
		}

		/// <summary>
		/// Verifica si una cadena corresponde a un correo electrónico válido.
		/// </summary>
		/// <param name="p_email">Cadena a verificar</param>
		/// <returns></returns>
		public bool Es_Email( string p_email ) {
			string s_expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
			if ( Regex.IsMatch( p_email, s_expresion ) ) {
				if ( Regex.Replace( p_email, s_expresion, String.Empty ).Length == 0 ) {
					return true;
				} else {
					return false;
				}
			} else {
				return false;
			}
		}

		#endregion

		#region Propiedades

		//public Exception get_Error {
		//    get {
		//        return this.ex_Error;
		//    }
		//}

		#endregion

	}
}
