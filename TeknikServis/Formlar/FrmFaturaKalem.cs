using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace TeknikServis.Formlar
{
    public partial class FrmFaturaKalem : Form
    {
        public FrmFaturaKalem()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLFATURADETAY t = new TBLFATURADETAY();
            t.URUN = TxtUrun.Text;
            t.ADET=short.Parse(TxtAdet.Text);
            t.FIYAT = decimal.Parse(TxtFiyat.Text);
            t.TUTAR = decimal.Parse(TxtTutar.Text);
            t.FATURAID = int.Parse(TxtFaturaID.Text);
            db.TBLFATURADETAY.Add(t);
            db.SaveChanges();
            MessageBox.Show("Faturaya Ait Kalem Girişi Tamamlandı","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void FrmFaturaKalem_Load(object sender, EventArgs e)
        {
            var values = from u in db.TBLFATURADETAY
                         select new
                         {
                             u.FATURADETAYID,
                             u.URUN,
                             u.ADET,
                             u.FIYAT,
                             u.TUTAR,
                             u.FATURAID
                         };
            gridControl1.DataSource = values.ToList();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            var values = from u in db.TBLFATURADETAY
                         select new
                         {
                             u.FATURADETAYID,
                             u.URUN,
                             u.ADET,
                             u.FIYAT,
                             u.TUTAR,
                             u.FATURAID
                         };
            gridControl1.DataSource = values.ToList();
        }
    }
}
