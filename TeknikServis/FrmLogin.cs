using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void BtnGiris_Click(object sender, EventArgs e)
        {
            var query = from x in db.TBLADMIN
                        where x.KULLANICIAD == textBox1.Text && x.SIFRE == textBox2.Text
                        select x;
            if (query.Any())
            {
                Cursor.Current = Cursors.WaitCursor;
                Form1 frm = new Form1();
                frm.Show();
                this.Hide();
                Cursor.Current = Cursors.Default;
            }
            else
            {
                XtraMessageBox.Show("Bilgileri Kontrol Ediniz!", "UYARI!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
