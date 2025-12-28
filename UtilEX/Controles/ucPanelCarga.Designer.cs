namespace UtilEX {
	partial class ucPanelCarga {
		/// <summary> 
		/// Variable del diseñador requerida.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Limpiar los recursos que se estén utilizando.
		/// </summary>
		/// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
		protected override void Dispose( bool disposing ) {
			if ( disposing && ( components != null ) ) {
				components.Dispose( );
			}
			base.Dispose( disposing );
		}

		#region Código generado por el Diseñador de componentes

		/// <summary> 
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent( ) {
			this.pb_Loading = new System.Windows.Forms.PictureBox( );
			( ( System.ComponentModel.ISupportInitialize )( this.pb_Loading ) ).BeginInit( );
			this.SuspendLayout( );
			// 
			// pb_Loading
			// 
			this.pb_Loading.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pb_Loading.Image = global::UtilEX.Properties.Resources.cargando;
			this.pb_Loading.Location = new System.Drawing.Point( 0, 0 );
			this.pb_Loading.Name = "pb_Loading";
			this.pb_Loading.Size = new System.Drawing.Size( 120, 60 );
			this.pb_Loading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pb_Loading.TabIndex = 0;
			this.pb_Loading.TabStop = false;
			// 
			// ucPanelCarga
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 96F, 96F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.Controls.Add( this.pb_Loading );
			this.Name = "ucPanelCarga";
			this.Size = new System.Drawing.Size( 120, 60 );
			( ( System.ComponentModel.ISupportInitialize )( this.pb_Loading ) ).EndInit( );
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.PictureBox pb_Loading;
	}
}
