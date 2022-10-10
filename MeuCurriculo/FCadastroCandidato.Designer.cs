namespace MeuCurriculo
{
    partial class FCadastroCandidato
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCadastroCandidato));
            this.txtNome = new System.Windows.Forms.TextBox();
            this.gbInformacoesPessoais = new System.Windows.Forms.GroupBox();
            this.lblSexo = new System.Windows.Forms.Label();
            this.lblEstadoCivil = new System.Windows.Forms.Label();
            this.lblNascimento = new System.Windows.Forms.Label();
            this.rdbOutro = new System.Windows.Forms.RadioButton();
            this.txtCelular = new System.Windows.Forms.MaskedTextBox();
            this.txtNacionalidade = new System.Windows.Forms.TextBox();
            this.rdbMasculino = new System.Windows.Forms.RadioButton();
            this.rdbFeminino = new System.Windows.Forms.RadioButton();
            this.cboEstadoCivil = new System.Windows.Forms.ComboBox();
            this.dtpNascimento = new System.Windows.Forms.DateTimePicker();
            this.gbEndereco = new System.Windows.Forms.GroupBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.txtBairro = new System.Windows.Forms.TextBox();
            this.txtRua = new System.Windows.Forms.TextBox();
            this.txtCidade = new System.Windows.Forms.TextBox();
            this.txtCEP = new System.Windows.Forms.MaskedTextBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.gbConta = new System.Windows.Forms.GroupBox();
            this.pictureHide = new System.Windows.Forms.PictureBox();
            this.pictureView = new System.Windows.Forms.PictureBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtDicaSenha = new System.Windows.Forms.TextBox();
            this.txtSenha2 = new System.Windows.Forms.TextBox();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.opcoesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizarCurriculoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.editarCurriculoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.contaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.sairToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.gbCursoEtec = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboCurso = new System.Windows.Forms.ComboBox();
            this.lblCurso = new System.Windows.Forms.Label();
            this.lblPeriodo = new System.Windows.Forms.Label();
            this.lblModulo = new System.Windows.Forms.Label();
            this.cboPeriodo = new System.Windows.Forms.ComboBox();
            this.cboModulo = new System.Windows.Forms.ComboBox();
            this.lblTerminoEtec = new System.Windows.Forms.Label();
            this.dtpInicioEtec = new System.Windows.Forms.DateTimePicker();
            this.txtInstituicao = new System.Windows.Forms.TextBox();
            this.lblInicioEtec = new System.Windows.Forms.Label();
            this.dtpTerminoEtec = new System.Windows.Forms.DateTimePicker();
            this.btnRefazer = new System.Windows.Forms.Button();
            this.gbInformacoesPessoais.SuspendLayout();
            this.gbEndereco.SuspendLayout();
            this.gbConta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureHide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.gbCursoEtec.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNome
            // 
            this.txtNome.BackColor = System.Drawing.Color.White;
            this.txtNome.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtNome.Location = new System.Drawing.Point(65, 49);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(309, 23);
            this.txtNome.TabIndex = 0;
            this.txtNome.Text = "Nome";
            this.txtNome.Enter += new System.EventHandler(this.txtNome_Enter);
            this.txtNome.Leave += new System.EventHandler(this.txtNome_Leave);
            // 
            // gbInformacoesPessoais
            // 
            this.gbInformacoesPessoais.Controls.Add(this.lblSexo);
            this.gbInformacoesPessoais.Controls.Add(this.lblEstadoCivil);
            this.gbInformacoesPessoais.Controls.Add(this.lblNascimento);
            this.gbInformacoesPessoais.Controls.Add(this.rdbOutro);
            this.gbInformacoesPessoais.Controls.Add(this.txtCelular);
            this.gbInformacoesPessoais.Controls.Add(this.txtNacionalidade);
            this.gbInformacoesPessoais.Controls.Add(this.rdbMasculino);
            this.gbInformacoesPessoais.Controls.Add(this.rdbFeminino);
            this.gbInformacoesPessoais.Controls.Add(this.cboEstadoCivil);
            this.gbInformacoesPessoais.Controls.Add(this.dtpNascimento);
            this.gbInformacoesPessoais.Controls.Add(this.txtNome);
            this.gbInformacoesPessoais.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbInformacoesPessoais.Location = new System.Drawing.Point(50, 68);
            this.gbInformacoesPessoais.Name = "gbInformacoesPessoais";
            this.gbInformacoesPessoais.Size = new System.Drawing.Size(438, 203);
            this.gbInformacoesPessoais.TabIndex = 0;
            this.gbInformacoesPessoais.TabStop = false;
            this.gbInformacoesPessoais.Text = "Informações Pessoais";
            // 
            // lblSexo
            // 
            this.lblSexo.AutoSize = true;
            this.lblSexo.Location = new System.Drawing.Point(62, 169);
            this.lblSexo.Name = "lblSexo";
            this.lblSexo.Size = new System.Drawing.Size(41, 17);
            this.lblSexo.TabIndex = 9;
            this.lblSexo.Text = "Sexo:";
            // 
            // lblEstadoCivil
            // 
            this.lblEstadoCivil.AutoSize = true;
            this.lblEstadoCivil.Location = new System.Drawing.Point(62, 113);
            this.lblEstadoCivil.Name = "lblEstadoCivil";
            this.lblEstadoCivil.Size = new System.Drawing.Size(88, 17);
            this.lblEstadoCivil.TabIndex = 13;
            this.lblEstadoCivil.Text = "Estado Civil:";
            // 
            // lblNascimento
            // 
            this.lblNascimento.AutoSize = true;
            this.lblNascimento.Location = new System.Drawing.Point(62, 81);
            this.lblNascimento.Name = "lblNascimento";
            this.lblNascimento.Size = new System.Drawing.Size(143, 17);
            this.lblNascimento.TabIndex = 13;
            this.lblNascimento.Text = "Data de Nacimento:";
            // 
            // rdbOutro
            // 
            this.rdbOutro.AutoSize = true;
            this.rdbOutro.Location = new System.Drawing.Point(311, 165);
            this.rdbOutro.Name = "rdbOutro";
            this.rdbOutro.Size = new System.Drawing.Size(63, 21);
            this.rdbOutro.TabIndex = 7;
            this.rdbOutro.TabStop = true;
            this.rdbOutro.Text = "Outro";
            this.rdbOutro.UseVisualStyleBackColor = true;
            this.rdbOutro.CheckedChanged += new System.EventHandler(this.RdbOutro_CheckedChanged);
            // 
            // txtCelular
            // 
            this.txtCelular.BackColor = System.Drawing.Color.White;
            this.txtCelular.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtCelular.Location = new System.Drawing.Point(65, 136);
            this.txtCelular.Name = "txtCelular";
            this.txtCelular.Size = new System.Drawing.Size(146, 23);
            this.txtCelular.TabIndex = 3;
            this.txtCelular.Text = "Celular";
            this.txtCelular.Click += new System.EventHandler(this.txtCelular_Click);
            this.txtCelular.Enter += new System.EventHandler(this.txtCelular_Enter);
            this.txtCelular.Leave += new System.EventHandler(this.txtCelular_Leave);
            // 
            // txtNacionalidade
            // 
            this.txtNacionalidade.BackColor = System.Drawing.Color.White;
            this.txtNacionalidade.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtNacionalidade.Location = new System.Drawing.Point(217, 136);
            this.txtNacionalidade.Name = "txtNacionalidade";
            this.txtNacionalidade.Size = new System.Drawing.Size(157, 23);
            this.txtNacionalidade.TabIndex = 4;
            this.txtNacionalidade.Text = "Nacionalidade";
            this.txtNacionalidade.Enter += new System.EventHandler(this.txtNacionalidade_Enter);
            this.txtNacionalidade.Leave += new System.EventHandler(this.txtNacionalidade_Leave);
            // 
            // rdbMasculino
            // 
            this.rdbMasculino.AutoSize = true;
            this.rdbMasculino.Location = new System.Drawing.Point(205, 165);
            this.rdbMasculino.Name = "rdbMasculino";
            this.rdbMasculino.Size = new System.Drawing.Size(90, 21);
            this.rdbMasculino.TabIndex = 6;
            this.rdbMasculino.TabStop = true;
            this.rdbMasculino.Text = "Masculino";
            this.rdbMasculino.UseVisualStyleBackColor = true;
            this.rdbMasculino.CheckedChanged += new System.EventHandler(this.RdbMasculino_CheckedChanged);
            // 
            // rdbFeminino
            // 
            this.rdbFeminino.AutoSize = true;
            this.rdbFeminino.Location = new System.Drawing.Point(112, 165);
            this.rdbFeminino.Name = "rdbFeminino";
            this.rdbFeminino.Size = new System.Drawing.Size(84, 21);
            this.rdbFeminino.TabIndex = 5;
            this.rdbFeminino.TabStop = true;
            this.rdbFeminino.Text = "Feminino";
            this.rdbFeminino.UseVisualStyleBackColor = true;
            this.rdbFeminino.CheckedChanged += new System.EventHandler(this.RdbFeminino_CheckedChanged);
            // 
            // cboEstadoCivil
            // 
            this.cboEstadoCivil.BackColor = System.Drawing.Color.White;
            this.cboEstadoCivil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstadoCivil.FormattingEnabled = true;
            this.cboEstadoCivil.Items.AddRange(new object[] {
            "Solteiro(a)",
            "Casado(a)",
            "Divorciado(a)",
            "Viúvo(a)",
            "Separado(a)"});
            this.cboEstadoCivil.Location = new System.Drawing.Point(156, 105);
            this.cboEstadoCivil.Name = "cboEstadoCivil";
            this.cboEstadoCivil.Size = new System.Drawing.Size(217, 25);
            this.cboEstadoCivil.TabIndex = 2;
            this.cboEstadoCivil.SelectedIndexChanged += new System.EventHandler(this.CboEstadoCivil_SelectedIndexChanged);
            // 
            // dtpNascimento
            // 
            this.dtpNascimento.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtpNascimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNascimento.Location = new System.Drawing.Point(211, 76);
            this.dtpNascimento.Name = "dtpNascimento";
            this.dtpNascimento.Size = new System.Drawing.Size(163, 23);
            this.dtpNascimento.TabIndex = 1;
            // 
            // gbEndereco
            // 
            this.gbEndereco.Controls.Add(this.txtNumero);
            this.gbEndereco.Controls.Add(this.txtBairro);
            this.gbEndereco.Controls.Add(this.txtRua);
            this.gbEndereco.Controls.Add(this.txtCidade);
            this.gbEndereco.Controls.Add(this.txtCEP);
            this.gbEndereco.Controls.Add(this.lblEstado);
            this.gbEndereco.Controls.Add(this.cboEstado);
            this.gbEndereco.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbEndereco.Location = new System.Drawing.Point(50, 311);
            this.gbEndereco.Name = "gbEndereco";
            this.gbEndereco.Size = new System.Drawing.Size(438, 178);
            this.gbEndereco.TabIndex = 1;
            this.gbEndereco.TabStop = false;
            this.gbEndereco.Text = "Endereço";
            // 
            // txtNumero
            // 
            this.txtNumero.BackColor = System.Drawing.Color.White;
            this.txtNumero.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtNumero.Location = new System.Drawing.Point(292, 98);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(72, 23);
            this.txtNumero.TabIndex = 5;
            this.txtNumero.Text = "Número";
            this.txtNumero.Enter += new System.EventHandler(this.txtNumero_Enter);
            this.txtNumero.Leave += new System.EventHandler(this.txtNumero_Leave);
            // 
            // txtBairro
            // 
            this.txtBairro.BackColor = System.Drawing.Color.White;
            this.txtBairro.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtBairro.Location = new System.Drawing.Point(65, 69);
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(172, 23);
            this.txtBairro.TabIndex = 2;
            this.txtBairro.Text = "Bairro";
            this.txtBairro.Enter += new System.EventHandler(this.txtBairro_Enter);
            this.txtBairro.Leave += new System.EventHandler(this.txtBairro_Leave);
            // 
            // txtRua
            // 
            this.txtRua.BackColor = System.Drawing.Color.White;
            this.txtRua.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtRua.Location = new System.Drawing.Point(65, 98);
            this.txtRua.Name = "txtRua";
            this.txtRua.Size = new System.Drawing.Size(221, 23);
            this.txtRua.TabIndex = 4;
            this.txtRua.Text = "Rua";
            this.txtRua.Enter += new System.EventHandler(this.txtRua_Enter);
            this.txtRua.Leave += new System.EventHandler(this.txtRua_Leave);
            // 
            // txtCidade
            // 
            this.txtCidade.BackColor = System.Drawing.Color.White;
            this.txtCidade.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtCidade.Location = new System.Drawing.Point(170, 40);
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.Size = new System.Drawing.Size(194, 23);
            this.txtCidade.TabIndex = 1;
            this.txtCidade.Text = "Cidade";
            this.txtCidade.Enter += new System.EventHandler(this.txtCidade_Enter);
            this.txtCidade.Leave += new System.EventHandler(this.txtCidade_Leave);
            // 
            // txtCEP
            // 
            this.txtCEP.BackColor = System.Drawing.Color.White;
            this.txtCEP.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtCEP.Location = new System.Drawing.Point(65, 40);
            this.txtCEP.Name = "txtCEP";
            this.txtCEP.Size = new System.Drawing.Size(99, 23);
            this.txtCEP.TabIndex = 0;
            this.txtCEP.Text = "CEP";
            this.txtCEP.Click += new System.EventHandler(this.TxtCEP_Click);
            this.txtCEP.TextChanged += new System.EventHandler(this.TxtCEP_TextChanged);
            this.txtCEP.Enter += new System.EventHandler(this.txtCEP_Enter);
            this.txtCEP.Leave += new System.EventHandler(this.txtCEP_Leave);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(245, 75);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(56, 17);
            this.lblEstado.TabIndex = 13;
            this.lblEstado.Text = "Estado:";
            // 
            // cboEstado
            // 
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Items.AddRange(new object[] {
            "AC",
            "AL",
            "AP",
            "AM",
            "BA",
            "CE",
            "DF",
            "ES",
            "GO",
            "MA",
            "MT",
            "MS",
            "MG",
            "PA",
            "PB",
            "PR",
            "PE",
            "PI",
            "RJ",
            "RN",
            "RS",
            "RO",
            "RR",
            "SC",
            "SP",
            "SE",
            "TO"});
            this.cboEstado.Location = new System.Drawing.Point(307, 69);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(58, 25);
            this.cboEstado.TabIndex = 3;
            this.cboEstado.SelectedIndexChanged += new System.EventHandler(this.CboEstado_SelectedIndexChanged);
            // 
            // gbConta
            // 
            this.gbConta.Controls.Add(this.pictureHide);
            this.gbConta.Controls.Add(this.pictureView);
            this.gbConta.Controls.Add(this.txtEmail);
            this.gbConta.Controls.Add(this.txtDicaSenha);
            this.gbConta.Controls.Add(this.txtSenha2);
            this.gbConta.Controls.Add(this.txtSenha);
            this.gbConta.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbConta.Location = new System.Drawing.Point(512, 311);
            this.gbConta.Name = "gbConta";
            this.gbConta.Size = new System.Drawing.Size(438, 178);
            this.gbConta.TabIndex = 3;
            this.gbConta.TabStop = false;
            this.gbConta.Text = "Conta";
            // 
            // pictureHide
            // 
            this.pictureHide.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureHide.BackColor = System.Drawing.Color.Transparent;
            this.pictureHide.Image = global::MeuCurriculo.Properties.Resources.hide;
            this.pictureHide.Location = new System.Drawing.Point(368, 71);
            this.pictureHide.Name = "pictureHide";
            this.pictureHide.Size = new System.Drawing.Size(20, 20);
            this.pictureHide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureHide.TabIndex = 15;
            this.pictureHide.TabStop = false;
            this.pictureHide.Click += new System.EventHandler(this.PictureHide_Click);
            // 
            // pictureView
            // 
            this.pictureView.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureView.BackColor = System.Drawing.Color.Transparent;
            this.pictureView.Image = ((System.Drawing.Image)(resources.GetObject("pictureView.Image")));
            this.pictureView.Location = new System.Drawing.Point(368, 71);
            this.pictureView.Name = "pictureView";
            this.pictureView.Size = new System.Drawing.Size(20, 20);
            this.pictureView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureView.TabIndex = 15;
            this.pictureView.TabStop = false;
            this.pictureView.Visible = false;
            this.pictureView.Click += new System.EventHandler(this.PictureView_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.White;
            this.txtEmail.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtEmail.Location = new System.Drawing.Point(77, 40);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(285, 23);
            this.txtEmail.TabIndex = 0;
            this.txtEmail.Text = "E-mail";
            this.txtEmail.TextChanged += new System.EventHandler(this.TxtEmail_TextChanged);
            this.txtEmail.Enter += new System.EventHandler(this.txtEmail_Enter);
            this.txtEmail.Leave += new System.EventHandler(this.txtEmail_Leave);
            // 
            // txtDicaSenha
            // 
            this.txtDicaSenha.BackColor = System.Drawing.Color.White;
            this.txtDicaSenha.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtDicaSenha.Location = new System.Drawing.Point(77, 129);
            this.txtDicaSenha.Name = "txtDicaSenha";
            this.txtDicaSenha.Size = new System.Drawing.Size(285, 23);
            this.txtDicaSenha.TabIndex = 3;
            this.txtDicaSenha.Text = "Dica de senha";
            this.txtDicaSenha.Enter += new System.EventHandler(this.txtDicaSenha_Enter);
            this.txtDicaSenha.Leave += new System.EventHandler(this.txtDicaSenha_Leave);
            // 
            // txtSenha2
            // 
            this.txtSenha2.BackColor = System.Drawing.Color.White;
            this.txtSenha2.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtSenha2.Location = new System.Drawing.Point(77, 100);
            this.txtSenha2.Name = "txtSenha2";
            this.txtSenha2.Size = new System.Drawing.Size(285, 23);
            this.txtSenha2.TabIndex = 2;
            this.txtSenha2.Text = "Confirme a senha";
            this.txtSenha2.TextChanged += new System.EventHandler(this.TxtSenha2_TextChanged);
            this.txtSenha2.Enter += new System.EventHandler(this.txtSenha2_Enter);
            this.txtSenha2.Leave += new System.EventHandler(this.txtSenha2_Leave);
            // 
            // txtSenha
            // 
            this.txtSenha.BackColor = System.Drawing.Color.White;
            this.txtSenha.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtSenha.Location = new System.Drawing.Point(77, 71);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(285, 23);
            this.txtSenha.TabIndex = 1;
            this.txtSenha.Text = "Senha";
            this.txtSenha.TextChanged += new System.EventHandler(this.TxtSenha_TextChanged);
            this.txtSenha.Enter += new System.EventHandler(this.txtSenha_Enter);
            this.txtSenha.Leave += new System.EventHandler(this.txtSenha_Leave);
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnFinalizar.FlatAppearance.BorderSize = 0;
            this.btnFinalizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinalizar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalizar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnFinalizar.Location = new System.Drawing.Point(839, 495);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(111, 34);
            this.btnFinalizar.TabIndex = 6;
            this.btnFinalizar.Text = "Cadastrar";
            this.btnFinalizar.UseVisualStyleBackColor = false;
            this.btnFinalizar.Click += new System.EventHandler(this.BtnFinalizar_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcoesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(868, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // opcoesToolStripMenuItem
            // 
            this.opcoesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.visualizarCurriculoToolStripMenuItem,
            this.toolStripSeparator1,
            this.editarCurriculoToolStripMenuItem,
            this.toolStripSeparator3,
            this.contaToolStripMenuItem,
            this.toolStripSeparator4,
            this.sairToolStripMenuItem1});
            this.opcoesToolStripMenuItem.Name = "opcoesToolStripMenuItem";
            this.opcoesToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.opcoesToolStripMenuItem.Text = "Opções";
            // 
            // visualizarCurriculoToolStripMenuItem
            // 
            this.visualizarCurriculoToolStripMenuItem.Name = "visualizarCurriculoToolStripMenuItem";
            this.visualizarCurriculoToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.visualizarCurriculoToolStripMenuItem.Text = "Visualizar Currículo";
            this.visualizarCurriculoToolStripMenuItem.Click += new System.EventHandler(this.VisualizarCurriculoToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(172, 6);
            // 
            // editarCurriculoToolStripMenuItem
            // 
            this.editarCurriculoToolStripMenuItem.Name = "editarCurriculoToolStripMenuItem";
            this.editarCurriculoToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.editarCurriculoToolStripMenuItem.Text = "Editar Currículo";
            this.editarCurriculoToolStripMenuItem.Click += new System.EventHandler(this.EditarCurriculoToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(172, 6);
            // 
            // contaToolStripMenuItem
            // 
            this.contaToolStripMenuItem.Enabled = false;
            this.contaToolStripMenuItem.Name = "contaToolStripMenuItem";
            this.contaToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.contaToolStripMenuItem.Text = "Conta";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(172, 6);
            // 
            // sairToolStripMenuItem1
            // 
            this.sairToolStripMenuItem1.Name = "sairToolStripMenuItem1";
            this.sairToolStripMenuItem1.Size = new System.Drawing.Size(175, 22);
            this.sairToolStripMenuItem1.Text = "Sair";
            this.sairToolStripMenuItem1.Click += new System.EventHandler(this.SairToolStripMenuItem1_Click);
            // 
            // gbCursoEtec
            // 
            this.gbCursoEtec.Controls.Add(this.label1);
            this.gbCursoEtec.Controls.Add(this.cboCurso);
            this.gbCursoEtec.Controls.Add(this.lblCurso);
            this.gbCursoEtec.Controls.Add(this.lblPeriodo);
            this.gbCursoEtec.Controls.Add(this.lblModulo);
            this.gbCursoEtec.Controls.Add(this.cboPeriodo);
            this.gbCursoEtec.Controls.Add(this.cboModulo);
            this.gbCursoEtec.Controls.Add(this.lblTerminoEtec);
            this.gbCursoEtec.Controls.Add(this.dtpInicioEtec);
            this.gbCursoEtec.Controls.Add(this.txtInstituicao);
            this.gbCursoEtec.Controls.Add(this.lblInicioEtec);
            this.gbCursoEtec.Controls.Add(this.dtpTerminoEtec);
            this.gbCursoEtec.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCursoEtec.Location = new System.Drawing.Point(512, 68);
            this.gbCursoEtec.Name = "gbCursoEtec";
            this.gbCursoEtec.Size = new System.Drawing.Size(438, 203);
            this.gbCursoEtec.TabIndex = 2;
            this.gbCursoEtec.TabStop = false;
            this.gbCursoEtec.Text = "Curso na Etec";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 27;
            this.label1.Text = "Escola:";
            // 
            // cboCurso
            // 
            this.cboCurso.BackColor = System.Drawing.Color.White;
            this.cboCurso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCurso.FormattingEnabled = true;
            this.cboCurso.Items.AddRange(new object[] {
            "Técnico em Automação Industrial",
            "Técnico em Desenvolvimento de Sistemas ",
            "Técnico em Eletromecânica",
            "Técnico em Eletrotécnico",
            "Técnico em Enfermagem",
            "Técnico em Informática ",
            "Técnico em Mecânica",
            "Técnico em Mecatrônica",
            "Técnico em Recursos Humanos"});
            this.cboCurso.Location = new System.Drawing.Point(106, 78);
            this.cboCurso.Name = "cboCurso";
            this.cboCurso.Size = new System.Drawing.Size(297, 25);
            this.cboCurso.TabIndex = 0;
            this.cboCurso.SelectedIndexChanged += new System.EventHandler(this.CboCurso_SelectedIndexChanged);
            // 
            // lblCurso
            // 
            this.lblCurso.AutoSize = true;
            this.lblCurso.Location = new System.Drawing.Point(38, 86);
            this.lblCurso.Name = "lblCurso";
            this.lblCurso.Size = new System.Drawing.Size(49, 17);
            this.lblCurso.TabIndex = 26;
            this.lblCurso.Text = "Curso:";
            // 
            // lblPeriodo
            // 
            this.lblPeriodo.AutoSize = true;
            this.lblPeriodo.Location = new System.Drawing.Point(38, 115);
            this.lblPeriodo.Name = "lblPeriodo";
            this.lblPeriodo.Size = new System.Drawing.Size(62, 17);
            this.lblPeriodo.TabIndex = 26;
            this.lblPeriodo.Text = "Período:";
            // 
            // lblModulo
            // 
            this.lblModulo.AutoSize = true;
            this.lblModulo.Location = new System.Drawing.Point(218, 115);
            this.lblModulo.Name = "lblModulo";
            this.lblModulo.Size = new System.Drawing.Size(61, 17);
            this.lblModulo.TabIndex = 22;
            this.lblModulo.Text = "Módulo:";
            // 
            // cboPeriodo
            // 
            this.cboPeriodo.BackColor = System.Drawing.Color.White;
            this.cboPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPeriodo.FormattingEnabled = true;
            this.cboPeriodo.Location = new System.Drawing.Point(106, 109);
            this.cboPeriodo.Name = "cboPeriodo";
            this.cboPeriodo.Size = new System.Drawing.Size(106, 25);
            this.cboPeriodo.TabIndex = 2;
            this.cboPeriodo.SelectedIndexChanged += new System.EventHandler(this.CboPeriodo_SelectedIndexChanged);
            // 
            // cboModulo
            // 
            this.cboModulo.BackColor = System.Drawing.Color.White;
            this.cboModulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModulo.FormattingEnabled = true;
            this.cboModulo.Location = new System.Drawing.Point(286, 109);
            this.cboModulo.Name = "cboModulo";
            this.cboModulo.Size = new System.Drawing.Size(106, 25);
            this.cboModulo.TabIndex = 4;
            this.cboModulo.SelectedIndexChanged += new System.EventHandler(this.CboModulo_SelectedIndexChanged);
            // 
            // lblTerminoEtec
            // 
            this.lblTerminoEtec.AutoSize = true;
            this.lblTerminoEtec.Location = new System.Drawing.Point(218, 147);
            this.lblTerminoEtec.Name = "lblTerminoEtec";
            this.lblTerminoEtec.Size = new System.Drawing.Size(62, 17);
            this.lblTerminoEtec.TabIndex = 19;
            this.lblTerminoEtec.Text = "Término:";
            // 
            // dtpInicioEtec
            // 
            this.dtpInicioEtec.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtpInicioEtec.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicioEtec.Location = new System.Drawing.Point(106, 142);
            this.dtpInicioEtec.Name = "dtpInicioEtec";
            this.dtpInicioEtec.Size = new System.Drawing.Size(106, 23);
            this.dtpInicioEtec.TabIndex = 1;
            // 
            // txtInstituicao
            // 
            this.txtInstituicao.BackColor = System.Drawing.Color.White;
            this.txtInstituicao.Enabled = false;
            this.txtInstituicao.Location = new System.Drawing.Point(106, 49);
            this.txtInstituicao.Name = "txtInstituicao";
            this.txtInstituicao.Size = new System.Drawing.Size(297, 23);
            this.txtInstituicao.TabIndex = 15;
            this.txtInstituicao.Text = "Etec Sylvio de Mattos Carvalho";
            // 
            // lblInicioEtec
            // 
            this.lblInicioEtec.AutoSize = true;
            this.lblInicioEtec.Location = new System.Drawing.Point(40, 147);
            this.lblInicioEtec.Name = "lblInicioEtec";
            this.lblInicioEtec.Size = new System.Drawing.Size(46, 17);
            this.lblInicioEtec.TabIndex = 18;
            this.lblInicioEtec.Text = "Início:";
            // 
            // dtpTerminoEtec
            // 
            this.dtpTerminoEtec.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtpTerminoEtec.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTerminoEtec.Location = new System.Drawing.Point(286, 142);
            this.dtpTerminoEtec.Name = "dtpTerminoEtec";
            this.dtpTerminoEtec.Size = new System.Drawing.Size(106, 23);
            this.dtpTerminoEtec.TabIndex = 3;
            this.dtpTerminoEtec.Value = new System.DateTime(2019, 4, 29, 19, 57, 0, 0);
            // 
            // btnRefazer
            // 
            this.btnRefazer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnRefazer.FlatAppearance.BorderSize = 0;
            this.btnRefazer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefazer.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefazer.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRefazer.Location = new System.Drawing.Point(722, 495);
            this.btnRefazer.Name = "btnRefazer";
            this.btnRefazer.Size = new System.Drawing.Size(111, 34);
            this.btnRefazer.TabIndex = 14;
            this.btnRefazer.Text = "Refazer";
            this.btnRefazer.UseVisualStyleBackColor = false;
            this.btnRefazer.Visible = false;
            this.btnRefazer.Click += new System.EventHandler(this.BtnRefazer_Click);
            // 
            // FCadastroCandidato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1004, 584);
            this.Controls.Add(this.btnRefazer);
            this.Controls.Add(this.gbCursoEtec);
            this.Controls.Add(this.btnFinalizar);
            this.Controls.Add(this.gbConta);
            this.Controls.Add(this.gbEndereco);
            this.Controls.Add(this.gbInformacoesPessoais);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FCadastroCandidato";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastrar-se";
            this.Load += new System.EventHandler(this.FCadastroCandidato_Load);
            this.gbInformacoesPessoais.ResumeLayout(false);
            this.gbInformacoesPessoais.PerformLayout();
            this.gbEndereco.ResumeLayout(false);
            this.gbEndereco.PerformLayout();
            this.gbConta.ResumeLayout(false);
            this.gbConta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureHide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbCursoEtec.ResumeLayout(false);
            this.gbCursoEtec.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.GroupBox gbInformacoesPessoais;
        private System.Windows.Forms.DateTimePicker dtpNascimento;
        private System.Windows.Forms.RadioButton rdbFeminino;
        private System.Windows.Forms.ComboBox cboEstadoCivil;
        private System.Windows.Forms.TextBox txtNacionalidade;
        private System.Windows.Forms.RadioButton rdbMasculino;
        private System.Windows.Forms.GroupBox gbEndereco;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.TextBox txtBairro;
        private System.Windows.Forms.TextBox txtRua;
        private System.Windows.Forms.MaskedTextBox txtCEP;
        private System.Windows.Forms.TextBox txtCidade;
        private System.Windows.Forms.GroupBox gbConta;
        private System.Windows.Forms.TextBox txtDicaSenha;
        private System.Windows.Forms.TextBox txtSenha2;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.MaskedTextBox txtCelular;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem opcoesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visualizarCurriculoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem editarCurriculoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem contaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem1;
        private System.Windows.Forms.RadioButton rdbOutro;
        private System.Windows.Forms.Label lblSexo;
        private System.Windows.Forms.Label lblEstadoCivil;
        private System.Windows.Forms.Label lblNascimento;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.GroupBox gbCursoEtec;
        private System.Windows.Forms.Label lblPeriodo;
        private System.Windows.Forms.Label lblModulo;
        private System.Windows.Forms.ComboBox cboPeriodo;
        private System.Windows.Forms.ComboBox cboModulo;
        private System.Windows.Forms.Label lblTerminoEtec;
        private System.Windows.Forms.Label lblInicioEtec;
        private System.Windows.Forms.DateTimePicker dtpTerminoEtec;
        private System.Windows.Forms.DateTimePicker dtpInicioEtec;
        private System.Windows.Forms.TextBox txtInstituicao;
        private System.Windows.Forms.Label lblCurso;
        private System.Windows.Forms.ComboBox cboCurso;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Button btnRefazer;
        private System.Windows.Forms.PictureBox pictureView;
        private System.Windows.Forms.PictureBox pictureHide;
        private System.Windows.Forms.Label label1;
    }
}