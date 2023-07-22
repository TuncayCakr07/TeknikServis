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
    public partial class FrmFaturaListesi : Form
    {
        public FrmFaturaListesi()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmFaturaListesi_Load(object sender, EventArgs e)
        {
            var values = from u in db.TBLFATURABILGI
                         select new
                         {
                             u.ID,
                             u.SERI,
                             u.SIRANO,
                             u.TARIH,
                             u.SAAT,
                             u.VERGIDAIRESI,
                             CARI = u.TBLCARI.AD + " " + u.TBLCARI.SOYAD,
                             PERSONEL = u.TBLPERSONEL.AD + " " + u.TBLPERSONEL.SOYAD

                         };
            gridControl1.DataSource = values.ToList();


            lookUpEdit1.Properties.DataSource = (from x in db.TBLCARI
                                                 select new
                                                 {
                                                     x.ID,
                                                     AD = x.AD +" "+ x.SOYAD,
                                                 }).ToList();
            lookUpEdit2.Properties.DataSource = (from x in db.TBLPERSONEL
                                                 select new
                                                 {
                                                     x.ID,
                                                     AD = x.AD + " " + x.SOYAD,
                                                 }).ToList();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var values = from u in db.TBLFATURABILGI
                         select new
                         {
                             u.ID,
                             u.SERI,
                             u.SIRANO,
                             u.TARIH,
                             u.SAAT,
                             u.VERGIDAIRESI,
                             CARI = u.TBLCARI.AD + " " + u.TBLCARI.SOYAD,
                             PERSONEL = u.TBLPERSONEL.AD + " " + u.TBLPERSONEL.SOYAD

                         };
            gridControl1.DataSource = values.ToList();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLFATURABILGI t = new TBLFATURABILGI();
            t.SERI=TxtSerino.Text;
            t.SIRANO=TxtSiraNo.Text;
            t.TARIH = Convert.ToDateTime(TxtTarih.Text);
            t.SAAT=TxtSaat.Text;
            t.VERGIDAIRESI=TxtVergiDairesi.Text;
            t.CARI=int.Parse(lookUpEdit1.EditValue.ToString());
            t.PERSONEL=short.Parse(lookUpEdit2.EditValue.ToString());
            db.TBLFATURABILGI.Add(t);
            db.SaveChanges();
            MessageBox.Show("Fatura Sisteme Kaydedilmiştir, Kalem Girişi Yapabilirsiniz.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        public string id;
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmFaturaKalemleriPopup fr = new FrmFaturaKalemleriPopup();
            fr.id =int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
            fr.Show();
        }
    }
}
