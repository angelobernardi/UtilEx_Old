using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace UtilEX {
	/// <summary>
	/// Contiene funciones para envío de E-Mails
	/// </summary>
	public class Email {

		#region Variables

		private string s_Servidor_SMTP;
		private string s_Usuario_SMTP;
		private string s_Contrasena_SMTP;
		private int i_Puerto_SMTP;
		private bool b_Usa_Credenciales = false;
		private bool b_Usa_SSL = false;
		private Exception ex_Error = new Exception();

		#endregion

		#region Constructor

		/// <summary>
		/// Permite envío de E-Mails
		/// </summary>
		/// <param name="p_Servidor_SMTP">URL o IP del servidor de correos</param>
		public Email( string p_Servidor_SMTP ) {
			this.s_Servidor_SMTP = p_Servidor_SMTP;
			this.i_Puerto_SMTP = 0;
		}

		/// <summary>
		/// Permite envío de E-Mails, especificando un puerto diferente del puerto por defecto, además de indicar el uso de SSL
		/// </summary>
		/// <param name="p_Servidor_SMTP">URL o IP del servidor de correos</param>
		/// <param name="p_Puerto_SMTP">Puerto SMTP del servidor de correos</param>
		/// <param name="p_Usa_SSL">Indica si el servidor utiliza cifrado de conexión SSL</param>
		public Email( string p_Servidor_SMTP, int p_Puerto_SMTP, bool p_Usa_SSL ) {
			this.s_Servidor_SMTP = p_Servidor_SMTP;
			this.i_Puerto_SMTP = p_Puerto_SMTP;
			this.b_Usa_SSL = p_Usa_SSL;
		}

		/// <summary>
		/// Permite envío de E-Mails utilizando autentificación.
		/// </summary>
		/// <param name="p_Servidor_SMTP">URL o IP del servidor de correos</param>
		/// <param name="p_Usuario">Usuario del servidor de correos (Requerido para enviar email con Credenciales)</param>
		/// <param name="p_Contrasena">Contraseña del servidor de correos (Requerido para enviar email con Credenciales)</param>
		public Email( string p_Servidor_SMTP, string p_Usuario, string p_Contrasena ) {
			this.s_Servidor_SMTP = p_Servidor_SMTP;
			this.s_Usuario_SMTP = p_Usuario;
			this.s_Contrasena_SMTP = p_Contrasena;
			this.i_Puerto_SMTP = 0;
			this.b_Usa_Credenciales = true;
		}

		/// <summary>
		/// Permite envío de E-Mails utilizando autentificación, especificando un puerto diferente del puerto por defecto, además de indicar el uso de SSL
		/// </summary>
		/// <param name="p_Servidor_SMTP">URL o IP del servidor de correos</param>
		/// <param name="p_Usuario">Usuario del servidor de correos (Requerido para enviar email con Credenciales)</param>
		/// <param name="p_Contrasena">Contraseña del servidor de correos (Requerido para enviar email con Credenciales)</param>
		/// <param name="p_Puerto_SMTP">Puerto SMTP del servidor de correos</param>
		/// <param name="p_Usa_SSL">Indica si el servidor utiliza cifrado de conexión SSL</param>
		public Email( string p_Servidor_SMTP, string p_Usuario, string p_Contrasena, int p_Puerto_SMTP, bool p_Usa_SSL ) {
			this.s_Servidor_SMTP = p_Servidor_SMTP;
			this.s_Usuario_SMTP = p_Usuario;
			this.s_Contrasena_SMTP = p_Contrasena;
			this.i_Puerto_SMTP = p_Puerto_SMTP;
			this.b_Usa_Credenciales = true;
			this.b_Usa_SSL = p_Usa_SSL;
		}

		#endregion

		#region Funciones

		/// <summary>
		/// Envía un Correo Electrónico
		/// </summary>
		/// <param name="p_Remitente">Remitente</param>
		/// <param name="p_Destinatarios">Detsinatarios, separados por ';'</param>
		/// <param name="p_Asunto">Asunto del mensaje</param>
		/// <param name="p_Cuerpo_Mensaje">Cuerpo del mensaje</param>
		/// <param name="p_adjuntos">Rutas físicas o de red de los adjuntos a enviar, separados por ';'</param>
		/// <param name="p_Usa_HTML">Indica si el mensaje se enviara utilizando HTML o texto plano.</param>
		/// <returns></returns>
		public string Enviar_Email( string p_Remitente, string p_Destinatarios, string p_Asunto, string p_Cuerpo_Mensaje, string p_adjuntos, bool p_Usa_HTML ) {
			MailMessage mm_Mensaje = new MailMessage( );
			MailAddress ma_Remitente = new MailAddress( p_Remitente );
			SmtpClient sc_SMTP = new SmtpClient( this.s_Servidor_SMTP );
			char c_Separador = ';'; //Convert.ToChar( ";" );

			mm_Mensaje.From = ma_Remitente;
			mm_Mensaje.ReplyTo = ma_Remitente;
			mm_Mensaje.Sender = ma_Remitente;
			mm_Mensaje.Body = p_Cuerpo_Mensaje;
			mm_Mensaje.Subject = p_Asunto;
			mm_Mensaje.IsBodyHtml = p_Usa_HTML;

			string[ ] s_StringDestinatarios = p_Destinatarios.Split( c_Separador );
			foreach ( string s_recipiente in s_StringDestinatarios ) {
				if ( s_recipiente.CompareTo( "" ) != 0 ) {
					mm_Mensaje.To.Add( s_recipiente.Trim( ) );
				}
			}

			string[ ] s_Attach = p_adjuntos.Split( c_Separador );
			foreach ( string s_archivo in s_Attach ) {
				if ( s_archivo.CompareTo( "" ) != 0 ) {
					Attachment a_Attch = new Attachment( s_archivo.Trim( ) );
					mm_Mensaje.Attachments.Add( a_Attch );
				}
			}

			if ( b_Usa_Credenciales ) {
				NetworkCredential nc_Credenciales = new NetworkCredential( this.s_Usuario_SMTP, this.s_Contrasena_SMTP );
				sc_SMTP.Credentials = nc_Credenciales;
			}
			if ( this.i_Puerto_SMTP > 0 ) {
				sc_SMTP.Port = this.i_Puerto_SMTP;
			}

			sc_SMTP.EnableSsl = b_Usa_SSL;

			try {
				sc_SMTP.Send( mm_Mensaje );
			} catch ( Exception ex ) {
				return "Ha ocurrido un error al intentar enviar el correo: " + ex.Message;
			}
			return "Correo enviado satisfactoriamente";
		}

		/// <summary>
		/// Envía un Correo Electrónico
		/// </summary>
		/// <param name="p_Remitente">Remitente</param>
		/// <param name="p_Destinatarios">Detsinatarios, separados por ';'</param>
		/// <param name="p_Asunto">Asunto del mensaje</param>
		/// <param name="p_Cuerpo_Mensaje">Cuerpo del mensaje</param>
		/// <param name="p_Usa_HTML">Indica si el mensaje se enviara utilizando HTML o texto plano.</param>
		/// <returns></returns>
		public string Enviar_Email( string p_Remitente, string p_Destinatarios, string p_Asunto, string p_Cuerpo_Mensaje, bool p_Usa_HTML ) {
			return Enviar_Email( p_Remitente, p_Destinatarios, p_Asunto, p_Cuerpo_Mensaje, string.Empty, p_Usa_HTML );
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

		#region Funciones por eliminar
		///// <summary>
		///// Permite enviar E-Mails a múltiples destinatarios.
		///// </summary>
		///// <param name="p_Remitente">Remitente</param>
		///// <param name="p_Destinatarios">Destinatarios, separados por ;</param>
		///// <param name="p_Asunto">Asunto</param>
		///// <param name="p_Cuerpo_Mensaje">Mensaje</param>
		///// <param name="p_Usa_Credenciales">Usa Credenciales</param>
		///// <returns></returns>		
		//public string Enviar_Email( string p_Remitente, string p_Destinatarios, string p_Asunto, string p_Cuerpo_Mensaje, bool p_Usa_HTML ) {
		//    MailMessage mm_Mensaje = new MailMessage( );
		//    MailAddress ma_Remitente = new MailAddress( p_Remitente );
		//    SmtpClient sc_SMTP = new SmtpClient( this.s_Servidor_SMTP );
		//    char c_Separador = Convert.ToChar( ";" );

		//    mm_Mensaje.From = ma_Remitente;
		//    mm_Mensaje.ReplyTo = ma_Remitente;
		//    mm_Mensaje.Sender = ma_Remitente;
		//    mm_Mensaje.Body = p_Cuerpo_Mensaje;
		//    mm_Mensaje.Subject = p_Asunto;

		//    if ( p_Usa_HTML ) {
		//        mm_Mensaje.IsBodyHtml = true;
		//    } else {
		//        mm_Mensaje.IsBodyHtml = false;
		//    }

		//    string[ ] s_StringDestinatarios = p_Destinatarios.Split( c_Separador );
		//    foreach ( string s_recipiente in s_StringDestinatarios ) {
		//        if ( s_recipiente.CompareTo( "" ) != 0 ) {
		//            mm_Mensaje.To.Add( s_recipiente.Trim( ) );
		//        }
		//    }

		//    if ( b_Usa_Credenciales ) {
		//        NetworkCredential nc_Credenciales = new NetworkCredential( this.s_Usuario_SMTP, this.s_Contrasena_SMTP );
		//        sc_SMTP.Credentials = nc_Credenciales;
		//    }

		//    try {
		//        sc_SMTP.Send( mm_Mensaje );
		//    } catch ( Exception ex ) {
		//        return "Ha ocurrido un error al intentar enviar el correo: " + ex.Message;
		//    }
		//    return "Correo enviado satisfactoriamente";
		//}

		///// <summary>
		///// Permite enviar E-Mails a múltiples destinatarios. Puede utilizar un puerto no estandar para el envío.
		///// </summary>
		///// <param name="p_Remitente">Remitente</param>
		///// <param name="p_Destinatarios">Destinatarios, separados por ;</param>
		///// <param name="p_Asunto">Asunto</param>
		///// <param name="p_Cuerpo_Mensaje">Mensaje</param>
		///// <param name="p_Usa_Credenciales">Usa Credenciales</param>
		///// <param name="p_Puerto_SMTP">Puerto Servidor SMTP</param>
		///// <returns></returns>
		//public string Enviar_Email( string p_Remitente, string p_Destinatarios, string p_Asunto, string p_Cuerpo_Mensaje, int p_Puerto_SMTP, bool p_Usa_HTML ) {
		//    MailMessage mm_Mensaje = new MailMessage( );
		//    MailAddress ma_Remitente = new MailAddress( p_Remitente );
		//    SmtpClient sc_SMTP = new SmtpClient( this.s_Servidor_SMTP );
		//    char c_Separador = Convert.ToChar( ";" );

		//    mm_Mensaje.From = ma_Remitente;
		//    mm_Mensaje.ReplyTo = ma_Remitente;
		//    mm_Mensaje.Sender = ma_Remitente;
		//    mm_Mensaje.Body = p_Cuerpo_Mensaje;
		//    mm_Mensaje.Subject = p_Asunto;

		//    if ( p_Usa_HTML ) {
		//        mm_Mensaje.IsBodyHtml = true;
		//    } else {
		//        mm_Mensaje.IsBodyHtml = false;
		//    }

		//    string[ ] s_StringDestinatarios = p_Destinatarios.Split( c_Separador );
		//    foreach ( string s_recipiente in s_StringDestinatarios ) {
		//        if ( s_recipiente.CompareTo( "" ) != 0 ) {
		//            mm_Mensaje.To.Add( s_recipiente.Trim( ) );
		//        }
		//    }

		//    if ( b_Usa_Credenciales ) {
		//        NetworkCredential nc_Credenciales = new NetworkCredential( this.s_Usuario_SMTP, this.s_Contrasena_SMTP );
		//        sc_SMTP.Credentials = nc_Credenciales;
		//    }
		//    sc_SMTP.Port = p_Puerto_SMTP;

		//    try {
		//        sc_SMTP.Send( mm_Mensaje );
		//    } catch ( Exception ex ) {
		//        return "Ha ocurrido un error al intentar enviar el correo: " + ex.Message;
		//    }
		//    return "Correo enviado satisfactoriamente";
		//}

		///// <summary>
		///// Permite enviar E-Mails a múltiples destinatarios, incorporando archivos adjuntos.
		///// </summary>
		///// <param name="p_Remitente">Remitente</param>
		///// <param name="p_Destinatarios">Destinatarios, separados por ;</param>
		///// <param name="p_Asunto">Asunto</param>
		///// <param name="p_Cuerpo_Mensaje">Mensaje</param>
		///// <param name="p_Adjuntos">Archivos Adjuntos, separados por ;</param>
		///// <param name="p_Usa_Credenciales">Usa Credenciales</param>
		///// <returns></returns>
		//public string Enviar_Email( string p_Remitente, string p_Destinatarios, string p_Asunto, string p_Cuerpo_Mensaje, string p_Adjuntos, bool p_Usa_HTML ) {
		//    MailMessage mm_Mensaje = new MailMessage( );
		//    MailAddress ma_Remitente = new MailAddress( p_Remitente );
		//    SmtpClient sc_SMTP = new SmtpClient( this.s_Servidor_SMTP );
		//    char c_Separador = Convert.ToChar( ";" );

		//    mm_Mensaje.From = ma_Remitente;
		//    mm_Mensaje.ReplyTo = ma_Remitente;
		//    mm_Mensaje.Sender = ma_Remitente;
		//    mm_Mensaje.Body = p_Cuerpo_Mensaje;
		//    mm_Mensaje.Subject = p_Asunto;

		//    if ( p_Usa_HTML ) {
		//        mm_Mensaje.IsBodyHtml = true;
		//    } else {
		//        mm_Mensaje.IsBodyHtml = false;
		//    }

		//    string[ ] s_StringDestinatarios = p_Destinatarios.Split( c_Separador );
		//    foreach ( string s_recipiente in s_StringDestinatarios ) {
		//        if ( s_recipiente.CompareTo( "" ) != 0 ) {
		//            mm_Mensaje.To.Add( s_recipiente.Trim( ) );
		//        }
		//    }

		//    string[ ] s_Attach = p_Adjuntos.Split( c_Separador );
		//    foreach ( string s_archivo in s_Attach ) {
		//        if ( s_archivo.CompareTo( "" ) != 0 ) {
		//            Attachment a_Attch = new Attachment( s_archivo.Trim( ) );
		//            mm_Mensaje.Attachments.Add( a_Attch );
		//        }
		//    }

		//    if ( b_Usa_Credenciales ) {
		//        NetworkCredential nc_Credenciales = new NetworkCredential( this.s_Usuario_SMTP, this.s_Contrasena_SMTP );
		//        sc_SMTP.Credentials = nc_Credenciales;
		//    }

		//    try {
		//        sc_SMTP.Send( mm_Mensaje );
		//    } catch ( Exception ex ) {
		//        return "Ha ocurrido un error al intentar enviar el correo: " + ex.Message;
		//    }
		//    return "Correo enviado satisfactoriamente";
		//}
		#endregion
	}
}
