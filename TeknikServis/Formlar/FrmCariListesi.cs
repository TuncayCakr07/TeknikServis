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
    public partial class FrmCariListesi : Form
    {
        public FrmCariListesi()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        int choose;
        void listele()
        {
            var values = from x in db.TBLCARI
                         select new
                         {
                             x.ID,
                             x.AD,
                             x.SOYAD,
                             x.MAİL,
                             x.TELEFON,
                             x.IL,
                             x.ILCE
                         };
            gridControl1.DataSource = values.ToList();
        }
        private void FrmCariListesi_Load(object sender, EventArgs e)
        {
            listele();
            labelControl12.Text = db.TBLCARI.Count().ToString();

            lookUpEdit1.Properties.DataSource = (from x in db.TBLILLER
                                                 select new
                                                 {
                                                     x.id,
                                                     x.sehir,
                                                 }).ToList();

            labelControl16.Text = db.TBLCARI.Select(x => x.IL).Distinct().Count().ToString();
            labelControl18.Text = db.TBLCARI.Select(x => x.ILCE).Distinct().Count().ToString();
            labelControl14.Text = db.enfazlacariil().FirstOrDefault();
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            choose = int.Parse(lookUpEdit1.EditValue.ToString());
            lookUpEdit2.Properties.DataSource = (from y in db.TBLILCELER
                                                 select new
                                                 {
                                                     y.id,
                                                     y.ilce,
                                                     y.sehir
                                                 }).Where(z => z.sehir == choose).ToList();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (Txtad.Text != "" && TxtSoyad.Text != "" && Txtad.Text.Length <= 20)
            {
                TBLCARI t = new TBLCARI();
                t.AD = Txtad.Text;
                t.SOYAD = TxtSoyad.Text;
                t.IL = lookUpEdit1.Text;
                t.ILCE = lookUpEdit2.Text;
                db.TBLCARI.Add(t);
                db.SaveChanges();
                MessageBox.Show("Cari Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
            }
            else
            {
                MessageBox.Show("Bilgileri Kontrol Ediniz !", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var value = db.TBLCARI.Find(id);
            db.TBLCARI.Remove(value);
            db.SaveChanges();
            MessageBox.Show("Cari Başarıyla Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            var values = db.TBLCARI.ToList();
            gridControl1.DataSource = values;
            listele();
        }

        private void gridView1_FocusedRowChanged_1(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                TxtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
                Txtad.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
                TxtSoyad.Text = gridView1.GetFocusedRowCellValue("SOYAD").ToString();
                TxtMaıl.Text = gridView1.GetFocusedRowCellValue("MAİL").ToString();
                TxtTelefon.Text = gridView1.GetFocusedRowCellValue("TELEFON").ToString();
                lookUpEdit1.Text = gridView1.GetFocusedRowCellValue("IL").ToString();
                lookUpEdit2.Text = gridView1.GetFocusedRowCellValue("ILCE").ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Hata!");
            }

        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            TxtID.Text = "";
            Txtad.Text = "";
            TxtSoyad.Text = "";
            TxtMaıl.Text = "";
            TxtTelefon.Text = "";
            lookUpEdit1.Text = "";
            lookUpEdit2.Text = "";
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var value = db.TBLCARI.Find(id);
            value.AD = Txtad.Text;
            value.SOYAD = TxtSoyad.Text;
            value.MAİL = TxtMaıl.Text;
            value.IL = lookUpEdit1.Text;
            value.ILCE = lookUpEdit2.Text;
            db.SaveChanges();
            MessageBox.Show("Cari Başarıyla Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }
    }
}
