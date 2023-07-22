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
    public partial class FrmPersonel : Form
    {
        public FrmPersonel()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmPersonel_Load(object sender, EventArgs e)
        {
            var values = from u in db.TBLPERSONEL
                         select new
                         {
                             u.ID,
                             u.AD,
                             u.SOYAD,
                             u.MAIL,
                             u.TELEFON

                         };
            gridControl1.DataSource = values.ToList();


            lookUpEdit1.Properties.DataSource = (from x in db.TBLDEPARTMAN
                                                select new
                                                {
                                                    x.ID,
                                                    x.AD,
                                                }).ToList();
            

            string ad1, soyad1,ad2,soyad2,ad3,soyad3,ad4,soyad4;
            //PERSONEL1
            ad1 = db.TBLPERSONEL.First(x => x.ID == 1).AD;
            soyad1 = db.TBLPERSONEL.First(x => x.ID == 1).SOYAD;
            labelControl4.Text=db.TBLPERSONEL.First(x=> x.ID == 1).TBLDEPARTMAN.AD;
            labelControl7.Text=db.TBLPERSONEL.First(x=> x.ID==1).MAIL;
            labelControl3.Text = ad1 + " " + soyad1;
            //PERSONEL2
            ad2 = db.TBLPERSONEL.First(x => x.ID == 2).AD;
            soyad2 = db.TBLPERSONEL.First(x => x.ID == 2).SOYAD;
            labelControl11.Text = db.TBLPERSONEL.First(x => x.ID == 2).TBLDEPARTMAN.AD;
            labelControl9.Text = db.TBLPERSONEL.First(x => x.ID == 2).MAIL;
            labelControl14.Text = ad2 + " " + soyad2;
            //PERSONEL3
            ad3 = db.TBLPERSONEL.First(x => x.ID == 3).AD;
            soyad3 = db.TBLPERSONEL.First(x => x.ID == 3).SOYAD;
            labelControl18.Text = db.TBLPERSONEL.First(x => x.ID == 3).TBLDEPARTMAN.AD;
            labelControl16.Text = db.TBLPERSONEL.First(x => x.ID == 3).MAIL;
            labelControl20.Text = ad3 + " " + soyad3;
            //PERSONEL4
            ad4 = db.TBLPERSONEL.First(x => x.ID == 4).AD;
            soyad4 = db.TBLPERSONEL.First(x => x.ID == 4).SOYAD;
            labelControl24.Text = db.TBLPERSONEL.First(x => x.ID == 4).TBLDEPARTMAN.AD;
            labelControl22.Text = db.TBLPERSONEL.First(x => x.ID == 4).MAIL;
            labelControl26.Text = ad4 + " " + soyad4;
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (TxtAd.Text != "" && TxtSoyad.Text != "" && TxtTelefon.Text!="" && TxtMaıl.Text!="" &&TxtAd.Text.Length >= 2 )
            {
                TBLPERSONEL t = new TBLPERSONEL();
                t.AD = TxtAd.Text;
                t.SOYAD = TxtSoyad.Text;
                t.DEPARTMAN = byte.Parse(lookUpEdit1.EditValue.ToString());
                t.MAIL = TxtMaıl.Text;
                db.TBLPERSONEL.Add(t);
                db.SaveChanges();
                MessageBox.Show("Personel Kayıt Edildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Bilgileri Kontrol Ediniz!", "UYARI!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var values = from u in db.TBLPERSONEL
                         select new
                         {
                             u.ID,
                             u.AD,
                             u.SOYAD,
                             u.MAIL,
                             u.TELEFON

                         };
            gridControl1.DataSource = values.ToList();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var value = db.TBLPERSONEL.Find(id);
            db.TBLPERSONEL.Remove(value);
            db.SaveChanges();
            MessageBox.Show("Personel Başarıyla Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            var values = db.TBLPERSONEL.ToList();
            gridControl1.DataSource = values;
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var value = db.TBLPERSONEL.Find(id);
            value.AD = TxtAd.Text;
            value.SOYAD = TxtSoyad.Text;
            value.DEPARTMAN = byte.Parse(lookUpEdit1.EditValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Personel Başarıyla Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            TxtID.Text = "";
            TxtAd.Text = "";
            TxtSoyad.Text = "";
            TxtTelefon.Text = "";
            TxtMaıl.Text = "";
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                TxtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
                TxtAd.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
                TxtSoyad.Text = gridView1.GetFocusedRowCellValue("SOYAD").ToString();
                TxtTelefon.Text = gridView1.GetFocusedRowCellValue("TELEFON").ToString();
                TxtMaıl.Text = gridView1.GetFocusedRowCellValue("MAIL").ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Hata!");
            }
        }
    }
}
