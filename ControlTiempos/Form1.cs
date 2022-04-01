namespace ControlTiempos
{
    public partial class frmMain : Form
    {
        public Boolean activo = false;
        public Boolean pausa = false;
        public Boolean segundos = false;
        public DateTime horaIni;
        public DateTime pausaIni;
        public TimeSpan tiempoEmpleado = new TimeSpan();
        public TimeSpan pausaAcumulada = new TimeSpan();
        public TimeSpan tiempoPausa = new TimeSpan();
        Boolean cambioPausa = false;
        public string rutaHistorial = @"historial.csv";

        public frmMain()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblTiempoEmpleado_Click(object sender, EventArgs e)
        {

        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            Boolean ejecutar = true;
            
            if (cmbClientes.Text == "" || txtTarea.Text == "")
            {
                ejecutar = false;
            }

            if (ejecutar)
            {
                if (activo)
                {
                    activo = false;
                    cmbClientes.Enabled = true;
                    txtTarea.Enabled = true;
                    btnAgregar.Enabled = true;
                    cmbReferencia.Enabled = true;
                    btnAgregarReferencia.Enabled = true;
                    btnPausa.Visible = false;
                    btnPausa.Enabled = false;
                    chkMostrarContadorPausa.Enabled = false;
                    chkMostrarContadorPausa.Visible = false;
                    lblEtiquetaPausaAcumulada.Visible = false;
                    lblEtiquetaUltimaPausa.Visible=false;
                    lblPausaAcumulada.Visible=false;
                    lblContadorUltimaPausa.Visible=false;
                    btnIniciar.Text = "INICIAR";
                    timer1.Stop();
                    using (StreamWriter sw = File.AppendText(rutaHistorial))
                    {
                        sw.WriteLine(horaIni.ToString() + ";" + cmbClientes.Text + ";" + cmbReferencia.Text + ";" + txtTarea.Text + ";" + tiempoEmpleado) ;
                    }
                    txtTarea.Text = "";
                    cmbClientes.Text = "";
                    cmbReferencia.Text = "";
                    lblTiempoEmpleado.Text ="00:00";
                    lblContadorUltimaPausa.Text = "00:00";
                    lblPausaAcumulada.Text = "00:00";
                    chkMostrarContadorPausa.Checked = false;
                }
                else
                {
                   //tiempoEmpleado = "";
                    activo = true;
                    cmbClientes.Enabled = false;
                    txtTarea.Enabled = false;
                    btnAgregar .Enabled = false;
                    cmbReferencia.Enabled = false;
                    btnAgregarReferencia .Enabled = false;
                    btnPausa.Visible = true;
                    btnPausa.Enabled = true;
                    chkMostrarContadorPausa.Enabled = true;
                    chkMostrarContadorPausa.Visible = true;
                    btnIniciar.Text = "PARAR";
                    horaIni = DateTime.Now;
                    lblTiempoEmpleado.Visible = true;
                    timer1.Start();
                }
            } else
            {
                MessageBox.Show("Falta el cliente o la tarea.");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Int16 digitosSubstring = 5;
            if (segundos)
            {
                digitosSubstring = 8;
            }   
            
            if (!pausa)
            {
                tiempoEmpleado = ((DateTime.Now-horaIni)-pausaAcumulada);
                lblTiempoEmpleado.Text = tiempoEmpleado.ToString().Substring(0, digitosSubstring);
            } else
            {
                tiempoPausa = (DateTime.Now - pausaIni);
                lblContadorUltimaPausa.Text=tiempoPausa.ToString().Substring(0, digitosSubstring);
            }

            if (cambioPausa)
            {
                if (!pausa)
                {
                    pausaAcumulada += tiempoPausa;
                    lblPausaAcumulada.Text = pausaAcumulada.ToString().Substring(0, 5);
                    cambioPausa = false;
                }
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            cargarCombos(-1, -1);
            Size = new Size(601, 228);
            string ruta = @"configuracion.txt";
            using (StreamReader sr = File.OpenText(ruta))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Int32 longitud = s.Length;
                    if (s.Substring(0, 1) == "1")
                    {
                        chkAlwaysOnTop.Checked = true;
                    } else
                    {
                        chkAlwaysOnTop.Checked = false;
                    }

                    if (s.Substring(2, 1) == "1")
                    {
                        chkSegundos.Checked = true;
                    }
                    else
                    {
                        chkSegundos.Checked = false;
                    }

                    if (s.Substring(4, 1) == "1")
                    {
                        chkMostrarContadorPausa.Checked = true;
                    }
                    else
                    {
                        chkMostrarContadorPausa.Checked = false;
                    }

                    if (s.Substring(6, 1) == "1")
                    {
                        chkPosicion.Checked = true;
                        StartPosition = FormStartPosition.Manual;
                        Int32 X = Int32.Parse(s.Substring(8, 4));
                        Int32 Y = Int32.Parse(s.Substring(13,4));
                        Location = new Point(X, Y);
                    }
                    else
                    {
                        chkPosicion.Checked = false;
                        StartPosition = FormStartPosition.CenterScreen;
                    }

                    txtArchivoHistorial.Text = s.Substring(18,longitud-18);
                    rutaHistorial = s.Substring(18, longitud - 18) + ".csv";

                }
            }

        }

        private void cargarCombos (Int16 clientes, Int16 referencia)
        {

            // CARGA COMBO CLIENTES
            cmbClientes.Items.Clear();
            Int16 contadorClientes = 0;
            string ruta = @"clientes.txt";
            using (StreamReader sr = File.OpenText(ruta))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    cmbClientes.Items.Add(s);
                    contadorClientes++;
                }
            }

            if (clientes != -1)
            {
                if (clientes == -2)
                {
                    cmbClientes.SelectedIndex = contadorClientes - 1;
                }
                else
                {
                    cmbClientes.SelectedIndex = clientes;
                }
            }

            // CARGA COMBO REFRENCIAS
            cmbReferencia.Items.Clear();
            Int16 contadorReferencia = 0;
            ruta = @"referencias.txt";
            using (StreamReader sr = File.OpenText(ruta))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    cmbReferencia.Items.Add(s);
                    contadorReferencia++;
                }
            }

            if (referencia != -1)
            {
                if (referencia == -2)
                {
                    cmbReferencia.SelectedIndex = contadorReferencia - 1;
                }
                else
                {
                    cmbReferencia.SelectedIndex = referencia;
                }
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nuevoCliente = cmbClientes.Text;
            Boolean existe = false;
            foreach (var item in cmbClientes.Items)
            {
                if (item.Equals(nuevoCliente))
                {
                    existe = true;
                }
            }

            if (!existe)
            {
                string ruta = @"clientes.txt";
                using (StreamWriter sw = File.AppendText(ruta))
                {
                    sw.WriteLine(nuevoCliente);
                }

                Int16 indice = 0;
                if (cmbReferencia.Text != "")
                {
                    indice = (short)cmbReferencia.SelectedIndex;
                }
                cargarCombos(-2, indice);
            }
            else
            {
                MessageBox.Show("El cliente que has introducido ya esiste.");
            }
                
        }

        private void chkAlwaysOnTop_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAlwaysOnTop.Checked)
            {
                TopMost=true;
            } else
            {
                TopMost = false;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void bnAgregarReferencia_Click(object sender, EventArgs e)
        {
            string nuevaReferencia = cmbReferencia.Text;
            Boolean existe = false;
            foreach (var item in cmbReferencia.Items)
            {
                if (item.Equals(nuevaReferencia))
                {
                    existe = true;
                }
            }

            if (!existe)
            {
                string ruta = @"referencias.txt";
                using (StreamWriter sw = File.AppendText(ruta))
                {
                    sw.WriteLine(nuevaReferencia);
                }

                Int16 indice = 0;
                if (cmbClientes.Text != "")
                {
                    indice = (short)cmbClientes.SelectedIndex;
                }
                cargarCombos(indice,-2);
            }
            else
            {
                MessageBox.Show("La referencia que has introducido ya esiste.");
            }
        }

        private void btnPausa_Click(object sender, EventArgs e)
        {
            cambioPausa = true;
            if (pausa)
            {
                pausa = false;
                btnPausa.BackgroundImage=Properties.Resources.pausa;
                lblTiempoEmpleado.Enabled=true;
                lblContadorUltimaPausa.Enabled=false;
                lblEtiquetaUltimaPausa.Enabled = false;
                lblEtiquetaUltimaPausa.Text = "Última Pausa:";
                lblEtiquetaUltimaPausa.Location = new System.Drawing.Point(163, 120);
                lblPausaAcumulada.Enabled = false;
                lblEtiquetaPausaAcumulada.Enabled=false;
            } else
            {
                pausaIni = DateTime.Now;
                pausa = true;
                btnPausa.BackgroundImage = Properties.Resources.boton_de_play;
                lblTiempoEmpleado.Enabled = false;
                lblContadorUltimaPausa.Enabled = true;
                lblEtiquetaUltimaPausa.Enabled = true;
                lblEtiquetaUltimaPausa.Text = "En Pausa:";
                lblEtiquetaUltimaPausa.Location = new System.Drawing.Point(191, 120);
                lblPausaAcumulada.Enabled = true;
                lblEtiquetaPausaAcumulada.Enabled = true;
            }
        }

        private void chkMostrarContadorPausa_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMostrarContadorPausa.Checked)
            {
                lblContadorUltimaPausa.Visible = true;
                lblPausaAcumulada.Visible = true;
                lblEtiquetaPausaAcumulada.Visible=true;
                lblEtiquetaUltimaPausa .Visible = true;
            } else
            {
                lblContadorUltimaPausa.Visible = false;
                lblPausaAcumulada.Visible = false;
                lblEtiquetaPausaAcumulada.Visible = false;
                lblEtiquetaUltimaPausa.Visible = false;
            }
        }

        private void lblEtiquetaUltimaPausa_Click(object sender, EventArgs e)
        {

        }

        private void btnConfigurar_Click(object sender, EventArgs e)
        {
            Size = new Size(601, 418);
        }

        private void chkSegundos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSegundos.Checked)
            {
                segundos = true;
            } else
            {
                segundos = false;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string ruta = @"configuracion.txt";
            Int16 visible = 0;
            Int16 segundosg = 0;
            Int16 pausa = 0;
            Int16 posicion = 0;

            if (chkAlwaysOnTop.Checked)
            {
                visible = 1;
            }

            if (chkMostrarContadorPausa.Checked)
            {
                pausa = 1;
            }

            if (chkSegundos.Checked)
            {
                segundosg = 1;
            }

            if (chkPosicion.Checked)
            {
                posicion = 1;
            }
            
            using (StreamWriter sw = File.CreateText(ruta))
            {
                sw.WriteLine(visible.ToString() + ";" + segundosg.ToString() + ";" + pausa.ToString() + ";" + posicion + ";" + txtPosicionX.Text + ";" +txtPosicionY.Text+ ";" + txtArchivoHistorial.Text);
            }

            rutaHistorial = txtArchivoHistorial.Text + ".csv";
            Size = new Size(601, 228);
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAlwaysOnTop.Checked)
            {
                String posicionX = Location.X.ToString();
                if (posicionX.Length < 4)
                {
                    if (posicionX.Length < 3)
                    {
                        if (posicionX.Length < 2)
                        {
                            posicionX = "000" + posicionX;
                        } else
                        {
                            posicionX = "00" + posicionX;
                        }
                    } else
                    {
                        posicionX = "0" + posicionX;
                    }
                }

                String posicionY = Location.Y.ToString();
                if (posicionY.Length < 4)
                {
                    if (posicionY.Length < 3)
                    {
                        if (posicionY.Length < 2)
                        {
                            posicionY = "000" + posicionY;
                        }
                        else
                        {
                            posicionY = "00" + posicionY;
                        }
                    }
                    else
                    {
                        posicionY = "0" + posicionY;
                    }
                }

                txtPosicionX.Text = posicionX;
                txtPosicionY.Text = posicionY;
            }
        }

    }
}