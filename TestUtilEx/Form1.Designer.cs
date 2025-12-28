namespace TestUtilEx {
    partial class frm_Form1 {
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent( ) {
			this.tb_Texto = new System.Windows.Forms.TextBox( );
			this.btn_button1 = new System.Windows.Forms.Button( );
			this.lbl_texto = new System.Windows.Forms.Label( );
			this.SuspendLayout( );
			// 
			// tb_Texto
			// 
			this.tb_Texto.Location = new System.Drawing.Point( 12, 12 );
			this.tb_Texto.Name = "tb_Texto";
			this.tb_Texto.Size = new System.Drawing.Size( 268, 20 );
			this.tb_Texto.TabIndex = 0;
			this.tb_Texto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tb_Texto.TextChanged += new System.EventHandler( this.tb_Texto_TextChanged );
			// 
			// btn_button1
			// 
			this.btn_button1.Location = new System.Drawing.Point( 106, 75 );
			this.btn_button1.Name = "btn_button1";
			this.btn_button1.Size = new System.Drawing.Size( 75, 23 );
			this.btn_button1.TabIndex = 1;
			this.btn_button1.Text = "button1";
			this.btn_button1.UseVisualStyleBackColor = true;
			this.btn_button1.Click += new System.EventHandler( this.button1_Click );
			// 
			// lbl_texto
			// 
			this.lbl_texto.AutoSize = true;
			this.lbl_texto.Location = new System.Drawing.Point( 12, 35 );
			this.lbl_texto.Name = "lbl_texto";
			this.lbl_texto.Size = new System.Drawing.Size( 35, 13 );
			this.lbl_texto.TabIndex = 2;
			this.lbl_texto.Text = "label1";
			// 
			// frm_Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 292, 110 );
			this.Controls.Add( this.lbl_texto );
			this.Controls.Add( this.btn_button1 );
			this.Controls.Add( this.tb_Texto );
			this.Name = "frm_Form1";
			this.Text = "Form1";
			this.ResumeLayout( false );
			this.PerformLayout( );

        }

        #endregion

        private System.Windows.Forms.TextBox tb_Texto;
        private System.Windows.Forms.Button btn_button1;
		private System.Windows.Forms.Label lbl_texto;
    }
}

