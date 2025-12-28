using System;
using System.Collections.Generic;
using System.Text;

namespace UtilEX.Controles {
	/// <summary>
	/// Instancia e incorpora el panel de carga.
	/// </summary>
	public class cfgPanelCarga {
		ucPanelCarga pnl_Carga = new ucPanelCarga( );

		#region Constructores

		/// <summary>
		/// Crea un panel que utiliza toda el area visible del formulario.
		/// </summary>
		/// <param name="_Formulario">Formulario al que se incorporará el control.</param>
		public cfgPanelCarga( System.Windows.Forms.Form _Formulario ) {
			pnl_Carga.Dock = System.Windows.Forms.DockStyle.Fill;
			pnl_Carga.Visible = false;
			_Formulario.Controls.Add( pnl_Carga );
		}

		/// <summary>
		/// Crea un panel en la ubicacion ubicación y con el tamaño indicados.
		/// </summary>
		/// <param name="f_Formulario">Formulario al que se incorporará el control.</param>
		/// <param name="i_Ancho">Ancho del control.</param>
		/// <param name="i_Alto">Alto del control.</param>
		/// <param name="i_X">Posición X del control.</param>
		/// <param name="i_Y">Posición Y del control.</param>
		public cfgPanelCarga( System.Windows.Forms.Form f_Formulario, Int32 i_Ancho, Int32 i_Alto, Int32 i_X, Int32 i_Y ) {
			System.Drawing.Size s_Tamanio = new System.Drawing.Size( i_Ancho, i_Alto );
			System.Drawing.Point s_Ubicacion = new System.Drawing.Point( i_X, i_Y );
			pnl_Carga.Location = s_Ubicacion;
			pnl_Carga.Size = s_Tamanio;
			pnl_Carga.Visible = false;
			f_Formulario.Controls.Add( pnl_Carga );
		}

		/// <summary>
		/// Crea un panel en la ubicacion ubicación y con el tamaño indicados.
		/// </summary>
		/// <param name="f_Formulario">Formulario al que se incorporará el control.</param>
		/// <param name="s_Tamano">Tamaño del control.</param>
		/// <param name="p_Ubicacion">Ubicación del control.</param>
		public cfgPanelCarga( System.Windows.Forms.Form f_Formulario, System.Drawing.Size s_Tamano, System.Drawing.Point p_Ubicacion ) {
			pnl_Carga.Location = p_Ubicacion;
			pnl_Carga.Size = s_Tamano;
			pnl_Carga.Visible = false;
			f_Formulario.Controls.Add( pnl_Carga );
		}

		#endregion

		#region Procedimientos

		/// <summary>
		/// Muestra el panel con la animación.
		/// </summary>
		public void MuestraPanel( ) {
			pnl_Carga.Visible = true;
		}

		/// <summary>
		/// Oculta el panel con la animación.
		/// </summary>
		public void OcultaPanel( ) {
			pnl_Carga.Visible = false;
		}

		#endregion

	}
}
