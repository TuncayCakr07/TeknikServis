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
    public partial class FrmUrunSatis : Form
    {
        public FrmUrunSatis()
        {
            InitializeComponent();
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            FrmUrunSatis fr = new FrmUrunSatis();
            fr.Close();
            this.Close();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLURUNHAREKET t = new TBLURUNHAREKET();
            t.URUN = int.Parse(lookUpEdit1.EditValue.ToString());
            t.URUN = int.Parse(lookUpEdit1.EditValue.ToString());
            t.MUSTERI  = int.Parse(lookUpEdit2.EditValue.ToString());
            t.PERSONEL= short.Parse(lookUpEdit3.EditValue.ToString());
            t.TARİH = DateTime.Parse(TxtTarih.Text);
            t.ADET=short.Parse(TxtAdet.Text);
            t.FIYAT=decimal.Parse(TxtSatisfiyat.Text);
            t.URUNSERINO=TxtSerino.Text;
            db.TBLURUNHAREKET.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün Satışı Tamamlandı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void FrmUrunSatis_Load(object sender, EventArgs e)
        {
            lookUpEdit1.Properties.DataSource = (from x in db.TBLURUN
                                                 select new
                                                 {
                                                     x.ID,
                                                     x.AD,
                                                 }).ToList();
            lookUpEdit2.Properties.DataSource = (from x in db.TBLCARI
                                                 select new
                                                 {
                                                     x.ID,
                                                     AD=x.AD+" "+x.SOYAD,
                                                 }).ToList();
            lookUpEdit3.Properties.DataSource = (from x in db.TBLPERSONEL
                                                 select new
                                                 {
                                                     x.ID,
                                                    AD= x.AD+" "+x.SOYAD,
                                                 }).ToList();
        }
    }
}
