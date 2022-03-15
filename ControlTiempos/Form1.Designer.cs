namespace ControlTiempos
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtTarea = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTiempoEmpleado = new System.Windows.Forms.Label();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.cmbClientes = new System.Windows.Forms.ComboBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.chkAlwaysOnTop = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbReferencia = new System.Windows.Forms.ComboBox();
            this.btnAgregarReferencia = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtTarea
            // 
            resources.ApplyResources(this.txtTarea, "txtTarea");
            this.txtTarea.Name = "txtTarea";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblTiempoEmpleado
            // 
            resources.ApplyResources(this.lblTiempoEmpleado, "lblTiempoEmpleado");
            this.lblTiempoEmpleado.ForeColor = System.Drawing.Color.Red;
            this.lblTiempoEmpleado.Name = "lblTiempoEmpleado";
            this.lblTiempoEmpleado.Click += new System.EventHandler(this.lblTiempoEmpleado_Click);
            // 
            // btnIniciar
            // 
            resources.ApplyResources(this.btnIniciar, "btnIniciar");
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // cmbClientes
            // 
            this.cmbClientes.FormattingEnabled = true;
            resources.ApplyResources(this.cmbClientes, "cmbClientes");
            this.cmbClientes.Name = "cmbClientes";
            // 
            // btnAgregar
            // 
            resources.ApplyResources(this.btnAgregar, "btnAgregar");
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // chkAlwaysOnTop
            // 
            resources.ApplyResources(this.chkAlwaysOnTop, "chkAlwaysOnTop");
            this.chkAlwaysOnTop.Checked = true;
            this.chkAlwaysOnTop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAlwaysOnTop.Name = "chkAlwaysOnTop";
            this.chkAlwaysOnTop.UseVisualStyleBackColor = true;
            this.chkAlwaysOnTop.CheckedChanged += new System.EventHandler(this.chkAlwaysOnTop_CheckedChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // cmbReferencia
            // 
            this.cmbReferencia.FormattingEnabled = true;
            resources.ApplyResources(this.cmbReferencia, "cmbReferencia");
            this.cmbReferencia.Name = "cmbReferencia";
            // 
            // btnAgregarReferencia
            // 
            resources.ApplyResources(this.btnAgregarReferencia, "btnAgregarReferencia");
            this.btnAgregarReferencia.Name = "btnAgregarReferencia";
            this.btnAgregarReferencia.UseVisualStyleBackColor = true;
            this.btnAgregarReferencia.Click += new System.EventHandler(this.bnAgregarReferencia_Click);
            // 
            // frmMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAgregarReferencia);
            this.Controls.Add(this.cmbReferencia);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkAlwaysOnTop);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.cmbClientes);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.lblTiempoEmpleado);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTarea);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmMain";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private TextBox txtTarea;
        private Label label1;
        private Label label2;
        private Label lblTiempoEmpleado;
        private Button btnIniciar;
        private ComboBox cmbClientes;
        private Button btnAgregar;
        private CheckBox chkAlwaysOnTop;
        private Label label3;
        private ComboBox cmbReferencia;
        private Button btnAgregarReferencia;
    }
}