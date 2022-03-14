namespace ControlTiempos
{
    public partial class frmMain : Form
    {
        public Boolean activo = false;
        public DateTime horaIni;
        public string tiempoEmpleado = "";

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
                    btnIniciar.Text = "INICIAR";
                    timer1.Stop();
                    string ruta = @"historial.csv";
                    using (StreamWriter sw = File.AppendText(ruta))
                    {
                        sw.WriteLine(horaIni.ToString() + ";" + cmbClientes.Text + ";" + txtTarea.Text + ";" + tiempoEmpleado) ;
                    }
                    txtTarea.Text = "";
                    cmbClientes.Text = "";
                }
                else
                {
                    tiempoEmpleado = "";
                    activo = true;
                    cmbClientes.Enabled = false;
                    txtTarea.Enabled = false;
                    btnAgregar .Enabled = false;
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
            
            tiempoEmpleado = (DateTime.Now - horaIni).ToString().Substring(0, 5);
            lblTiempoEmpleado.Text = tiempoEmpleado;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

            string ruta = @"clientes.txt";
            using (StreamReader sr = File.OpenText(ruta))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    cmbClientes.Items.Add(s);
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

                cmbClientes.Items.Clear();

                Int16 indice = 0;

                using (StreamReader sr = File.OpenText(ruta))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        cmbClientes.Items.Add(s);
                        indice++;
                    }
                }

                cmbClientes.SelectedIndex = indice-1;
            }
            else
            {
                MessageBox.Show("El cliente que has introducido ya esiste.");
            }
                
        }
    }
}