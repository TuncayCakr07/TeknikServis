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
    public partial class FrmUrunListesi : Form
    {
        public FrmUrunListesi()
        {
            InitializeComponent();
        }

        private void List()
        {
            var values = from u in db.TBLURUN
                         select new
                         {
                             u.ID,
                             u.AD,
                             KATEGORI = u.TBLKATEGORİ.AD,
                             u.MARKA,
                             u.STOK,
                             u.ALİSFİYAT,
                             u.SATİSFİYAT
                         };
            gridControl1.DataSource = values.ToList();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmUrunListesi_Load(object sender, EventArgs e)
        {
            //var values=db.TBLURUN.ToList();
            List();
            lookUpEdit1.Properties.DataSource = (from x in db.TBLKATEGORİ
                                                 select new
                                                 {
                                                     x.ID,
                                                     x.AD,
                                                 }).ToList();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                TxtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
                TxtUrunAd.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
                TxtMarka.Text = gridView1.GetFocusedRowCellValue("MARKA").ToString();
                TxtAlisFiyat.Text = gridView1.GetFocusedRowCellValue("ALİSFİYAT").ToString();
                TxtSatisFiyat.Text = gridView1.GetFocusedRowCellValue("SATİSFİYAT").ToString();
                TxtStok.Text = gridView1.GetFocusedRowCellValue("STOK").ToString();
                lookUpEdit1.Text = gridView1.GetFocusedRowCellValue("KATEGORI").ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Hata!");
            }

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLURUN t = new TBLURUN();
            t.AD = TxtUrunAd.Text;
            t.MARKA = TxtMarka.Text;
            t.ALİSFİYAT = decimal.Parse(TxtAlisFiyat.Text);
            t.SATİSFİYAT = decimal.Parse(TxtSatisFiyat.Text);
            t.STOK = short.Parse(TxtStok.Text);
            t.KATEGORİ = byte.Parse(lookUpEdit1.EditValue.ToString());
            t.DURUM = false;
            db.TBLURUN.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            var values = db.TBLURUN.ToList();
            gridControl1.DataSource = values;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            List();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var value = db.TBLURUN.Find(id);
            db.TBLURUN.Remove(value);
            db.SaveChanges();
            MessageBox.Show("Ürün Başarıyla Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            var values = db.TBLURUN.ToList();
            gridControl1.DataSource = values;
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var value = db.TBLURUN.Find(id);
            value.AD = TxtUrunAd.Text;
            value.STOK = short.Parse(TxtStok.Text);
            value.MARKA = TxtMarka.Text;
            value.ALİSFİYAT = decimal.Parse(TxtAlisFiyat.Text);
            value.SATİSFİYAT = decimal.Parse(TxtSatisFiyat.Text);
            value.KATEGORİ = byte.Parse(lookUpEdit1.EditValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Ürün Başarıyla Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            TxtID.Text = "";
            TxtUrunAd.Text = "";
            TxtStok.Text = "";
            TxtMarka.Text = "";
            TxtAlisFiyat.Text = "";
            TxtSatisFiyat.Text = "";

        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
