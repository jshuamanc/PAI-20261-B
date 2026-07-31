namespace VentanaMDI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clientes ventana = new Clientes();
            ventana.MdiParent = this;
            ventana.Show();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Proveedores ventana = new Proveedores();
            ventana.MdiParent = (this);
            ventana.Show();
        }

        private void cascadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirMDI<Ventas>();
        }

        private void AbrirMDI<T>() where T : Form, new()
        {
            foreach(Form v in this.MdiChildren)
            {
                if(v is T)
                {
                    v.WindowState = FormWindowState.Normal;
                    return;
                }
            }
            T ventana = new T();
            ventana.MdiParent = this;
            ventana.Show();
        }
    }
}
