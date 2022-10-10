namespace MeuCurriculo
{
    partial class FRecrutador
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cboModulo = new System.Windows.Forms.ComboBox();
            this.cboCurso = new System.Windows.Forms.ComboBox();
            this.cboPeriodo = new System.Windows.Forms.ComboBox();
            this.dtConsulta = new System.Windows.Forms.DataGridView();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.lblCurso = new System.Windows.Forms.Label();
            this.lblPeriodo = new System.Windows.Forms.Label();
            this.lblModulo = new System.Windows.Forms.Label();
            this.btnConsultar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtConsulta)).BeginInit();
            this.SuspendLayout();
            // 
            // cboModulo
            // 
            this.cboModulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModulo.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboModulo.FormattingEnabled = true;
            this.cboModulo.Location = new System.Drawing.Point(439, 32);
            this.cboModulo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboModulo.Name = "cboModulo";
            this.cboModulo.Size = new System.Drawing.Size(140, 24);
            this.cboModulo.TabIndex = 0;
            this.cboModulo.SelectedIndexChanged += new System.EventHandler(this.CboModulo_SelectedIndexChanged);
            // 
            // cboCurso
            // 
            this.cboCurso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCurso.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.cboCurso.FormattingEnabled = true;
            this.cboCurso.Items.AddRange(new object[] {
            "Técnico em Automação Industrial",
            "Técnico em Desenvolvimento de Sistemas",
            "Técnico em Eletromecânica",
            "Técnico em Eletrotécnico",
            "Técnico em Enfermagem",
            "Técnico em Informática",
            "Técnico em Mecânica",
            "Técnico em Mecatrônica",
            "Técnico em Recursos Humanos"});
            this.cboCurso.Location = new System.Drawing.Point(14, 32);
            this.cboCurso.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboCurso.Name = "cboCurso";
            this.cboCurso.Size = new System.Drawing.Size(273, 25);
            this.cboCurso.TabIndex = 1;
            this.cboCurso.SelectedIndexChanged += new System.EventHandler(this.CboCurso_SelectedIndexChanged);
            // 
            // cboPeriodo
            // 
            this.cboPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPeriodo.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.cboPeriodo.FormattingEnabled = true;
            this.cboPeriodo.Location = new System.Drawing.Point(293, 32);
            this.cboPeriodo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboPeriodo.Name = "cboPeriodo";
            this.cboPeriodo.Size = new System.Drawing.Size(140, 25);
            this.cboPeriodo.TabIndex = 2;
            this.cboPeriodo.SelectedIndexChanged += new System.EventHandler(this.CboPeriodo_SelectedIndexChanged);
            // 
            // dtConsulta
            // 
            this.dtConsulta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtConsulta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtConsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtConsulta.Location = new System.Drawing.Point(14, 65);
            this.dtConsulta.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtConsulta.Name = "dtConsulta";
            this.dtConsulta.ReadOnly = true;
            this.dtConsulta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtConsulta.Size = new System.Drawing.Size(1447, 766);
            this.dtConsulta.TabIndex = 4;
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnSalvar.FlatAppearance.BorderSize = 0;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.btnSalvar.ForeColor = System.Drawing.Color.White;
            this.btnSalvar.Location = new System.Drawing.Point(702, 22);
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(111, 34);
            this.btnSalvar.TabIndex = 8;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.BtnSalvar_Click);
            // 
            // lblCurso
            // 
            this.lblCurso.AutoSize = true;
            this.lblCurso.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.lblCurso.Location = new System.Drawing.Point(12, 11);
            this.lblCurso.Name = "lblCurso";
            this.lblCurso.Size = new System.Drawing.Size(45, 17);
            this.lblCurso.TabIndex = 10;
            this.lblCurso.Text = "Curso";
            // 
            // lblPeriodo
            // 
            this.lblPeriodo.AutoSize = true;
            this.lblPeriodo.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.lblPeriodo.Location = new System.Drawing.Point(290, 11);
            this.lblPeriodo.Name = "lblPeriodo";
            this.lblPeriodo.Size = new System.Drawing.Size(58, 17);
            this.lblPeriodo.TabIndex = 11;
            this.lblPeriodo.Text = "Período";
            // 
            // lblModulo
            // 
            this.lblModulo.AutoSize = true;
            this.lblModulo.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.lblModulo.Location = new System.Drawing.Point(436, 11);
            this.lblModulo.Name = "lblModulo";
            this.lblModulo.Size = new System.Drawing.Size(57, 17);
            this.lblModulo.TabIndex = 12;
            this.lblModulo.Text = "Módulo";
            // 
            // btnConsultar
            // 
            this.btnConsultar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnConsultar.FlatAppearance.BorderSize = 0;
            this.btnConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultar.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.btnConsultar.ForeColor = System.Drawing.Color.White;
            this.btnConsultar.Location = new System.Drawing.Point(585, 22);
            this.btnConsultar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(111, 34);
            this.btnConsultar.TabIndex = 22;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = false;
            this.btnConsultar.Click += new System.EventHandler(this.BtnConsultar_Click);
            // 
            // FRecrutador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1475, 844);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.lblModulo);
            this.Controls.Add(this.lblPeriodo);
            this.Controls.Add(this.lblCurso);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.dtConsulta);
            this.Controls.Add(this.cboPeriodo);
            this.Controls.Add(this.cboCurso);
            this.Controls.Add(this.cboModulo);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FRecrutador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultar Currículos";
            ((System.ComponentModel.ISupportInitialize)(this.dtConsulta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboModulo;
        private System.Windows.Forms.ComboBox cboCurso;
        private System.Windows.Forms.ComboBox cboPeriodo;
        private System.Windows.Forms.DataGridView dtConsulta;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Label lblCurso;
        private System.Windows.Forms.Label lblPeriodo;
        private System.Windows.Forms.Label lblModulo;
        private System.Windows.Forms.Button btnConsultar;
    }
}