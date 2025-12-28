using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UtilEX;

namespace TestUtilEx {
	public partial class frm_Form1 : Form {
		Validacion v_valida = new Validacion( );
		Fecha f_date = new Fecha( );
		FuncionesVarias f_func = new FuncionesVarias( );
		SistemaArchivos s_files = new SistemaArchivos( );
		System.Threading.Thread t_hilo;
		UtilEX.Controles.cfgPanelCarga pnl_panel;

		public frm_Form1( ) {
			pnl_panel = new UtilEX.Controles.cfgPanelCarga( this );
			InitializeComponent( );
			tb_Texto.Leave += new EventHandler( this.tb_Texto_Leave );
		}

		private void button1_Click( object sender, EventArgs e ) {
			pnl_panel.MuestraPanel( );
			s_files.RutaArchivo = tb_Texto.Text;
			t_hilo = new System.Threading.Thread( Carga );
			t_hilo.Start( );
		}

		private void tb_Texto_TextChanged( object sender, EventArgs e ) {
		}

		private void tb_Texto_Leave( object sender, EventArgs e ) {
		}

		private void Carga( ) {
			CheckForIllegalCrossThreadCalls = false;
			while ( !s_files.Archivo_Esta_Bloqueado( ) ) {
				System.Threading.Thread.Sleep( 1000 );
			}
			pnl_panel.OcultaPanel( );
		}
		//C:\Documents and Settings\angelo.bernardi\Escritorio\Proyectos\IPP Carga Productos\IPP_Cobertura_Pruebas.xls
	}
}