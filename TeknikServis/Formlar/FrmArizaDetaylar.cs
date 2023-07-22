using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis.Formlar
{
    public partial class FrmArizaDetaylar : Form
    {
        public FrmArizaDetaylar()
        {
            InitializeComponent();
        }
        private void btnıptal_Click(object sender, EventArgs e)
        {
            FrmArizaDetaylar fr = new FrmArizaDetaylar();
            fr.Close();
            this.Close();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            TBLURUNTAKIP t = new TBLURUNTAKIP();
            t.ACIKLAMA = TxtArizaDetay.Text;
            t.SERINO=TxtSerino.Text;
            t.TARIH=DateTime.Parse(TxtTarih.Text);
            db.TBLURUNTAKIP.Add(t);
            //üründurumgüncelleme

            TBLURUNKABUL tb=new TBLURUNKABUL();
            int urunid = int.Parse(id.ToString());
            var value = db.TBLURUNKABUL.Find(urunid);
            value.URUNDURUMDETAY = comboBox1.Text;
            db.SaveChanges();
            MessageBox.Show("Arıza Detayları Eklendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            this.Close();
        }

        private void TxtSerino_Click(object sender, EventArgs e)
        {
            TxtSerino.Text = "";
        }

        private void TxtTarih_Click(object sender, EventArgs e)
        {
            TxtTarih.Text = DateTime.Now.ToShortDateString();
        }

        private void TxtArizaDetay_Click(object sender, EventArgs e)
        {
            TxtArizaDetay.Text = "";
        }
        public string id,serino;
        private void FrmArizaDetaylar_Load(object sender, EventArgs e)
        {
            TxtSerino.Text = serino;
        }
    }
}
