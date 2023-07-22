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
    public partial class FrmAnaSayfa : Form
    {
        public FrmAnaSayfa()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmAnaSayfa_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TBLURUN
                                       select new
                                       {
                                           x.AD,
                                           x.STOK
                                       }).Where(x => x.STOK < 20).ToList();

            //gridControl2.DataSource= (from x in db.TBLCARI select new
            //{
            //    x.AD,
            //    x.SOYAD,
            //    x.IL,
            //    x.ILCE,
            //    x.TELEFON,
            //    x.MAİL
            //}).ToList();

            //gridControl3.DataSource = db.URUNKATEGORİ().ToList();

            //DateTime dt = DateTime.Today;
            //var value = (from x in db.TBLNOTLAR.OrderBy(y => y.ID)
            //             where (x.TARİH == dt)
            //             select new
            //             {
            //                 x.BASLİK,
            //                 x.İCERİK,
            //                 x.TARİH
            //             });
            //gridControl4.DataSource=value.ToList();


            string konu1, ad1, konu2, ad2, konu3, ad3, konu4, ad4, konu5, ad5, konu6, ad6, konu7, ad7, konu8, ad8, konu9, ad9, konu10, ad10;
            konu1 = db.TBLILETISIM.First(x => x.ID == 1).KONU;
            ad1= db.TBLILETISIM.First(x => x.ID == 1).ADSOYAD;
            labelControl1.Text = konu1 + "---" + ad1;

            konu2 = db.TBLILETISIM.First(x => x.ID == 2).KONU;
            ad2 = db.TBLILETISIM.First(x => x.ID == 2).ADSOYAD;
            labelControl2.Text = konu2 + "---" + ad2;

            konu3 = db.TBLILETISIM.First(x => x.ID == 3).KONU;
            ad3 = db.TBLILETISIM.First(x => x.ID == 3).ADSOYAD;
            labelControl3.Text = konu3 + "---" + ad3;

            konu4 = db.TBLILETISIM.First(x => x.ID == 4).KONU;
            ad4 = db.TBLILETISIM.First(x => x.ID == 4).ADSOYAD;
            labelControl4.Text = konu4 + "---" + ad4;

            konu5 = db.TBLILETISIM.First(x => x.ID == 5).KONU;
            ad5 = db.TBLILETISIM.First(x => x.ID == 5).ADSOYAD;
            labelControl5.Text = konu5 + "---" + ad5;

            konu6 = db.TBLILETISIM.First(x => x.ID == 6).KONU;
            ad6 = db.TBLILETISIM.First(x => x.ID == 6).ADSOYAD;
            labelControl6.Text = konu6 + "---" + ad6;

            konu7 = db.TBLILETISIM.First(x => x.ID == 7).KONU;
            ad7 = db.TBLILETISIM.First(x => x.ID == 7).ADSOYAD;
            labelControl7.Text = konu7 + "---" + ad7;

            konu8 = db.TBLILETISIM.First(x => x.ID == 8).KONU;
            ad8 = db.TBLILETISIM.First(x => x.ID == 8).ADSOYAD;
            labelControl8.Text = konu8 + "---" + ad8;

            konu9 = db.TBLILETISIM.First(x => x.ID == 9).KONU;
            ad9 = db.TBLILETISIM.First(x => x.ID == 9).ADSOYAD;
            labelControl9.Text = konu9 + "---" + ad9;

            konu10 = db.TBLILETISIM.First(x => x.ID == 10).KONU;
            ad10 = db.TBLILETISIM.First(x => x.ID == 10).ADSOYAD;
            labelControl10.Text = konu10 + "---" + ad10;
        }

        private void gridControl2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
