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
    public partial class FrmFaturaKalemleri : Form
    {
        public FrmFaturaKalemleri()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void BtnAra_Click(object sender, EventArgs e)
        {
            var id = TxtID.Text=="" ? 0:Convert.ToInt32(TxtID.Text);
            var seriNo =  TxtSeri.Text;
            var siraNo = TxtSira.Text;

            var values = (from detay in db.TBLFATURADETAY
                          join ftr in db.TBLFATURABILGI on detay.FATURAID equals ftr.ID
                          select new
                          {
                              detay.FATURADETAYID,
                              ftr.SIRANO,
                              ftr.SERI,
                              detay.ADET,
                              detay.FIYAT,
                              detay.TUTAR,
                              detay.FATURAID
                          }).Where(x => (x.FATURAID == id || id==0) && (x.SERI == seriNo || seriNo=="") &&  (x.SIRANO == siraNo || siraNo ==""));

            gridControl1.DataSource = values.ToList();
        }
    }
}
