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
    public partial class FrmSatisHareketListesi : Form
    {
        public FrmSatisHareketListesi()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmSatisHareketListesi_Load(object sender, EventArgs e)
        {
            var values = from x in db.TBLURUNHAREKET
                         select new
                         {
                             x.HAREKETID,
                             x.TBLURUN.AD,
                             musteri = x.TBLCARI.AD +" "+ x.TBLCARI.SOYAD,
                             personel = x.TBLPERSONEL.AD +" " + x.TBLPERSONEL.SOYAD,
                             x.TARİH,
                             x.ADET,
                             x.FIYAT,
                             x.URUNSERINO,
                         };
            gridControl1.DataSource=values.ToList();
        }
    }
}
