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
    public partial class Frmİstatistik : Form
    {
        public Frmİstatistik()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db=new DbTeknikServisEntities();
        private void Frmİstatistik_Load(object sender, EventArgs e)
        {
          labelControl2.Text=db.TBLURUN.Count().ToString();
          labelControl5.Text=db.TBLKATEGORİ.Count().ToString();
          labelControl3.Text=db.TBLURUN.Sum(x=> x.STOK).ToString();
            labelControl7.Text = "10";
          labelControl19.Text=(from x in db.TBLURUN
                               orderby x.STOK descending
                               select x.AD).FirstOrDefault();
          labelControl16.Text=(from x in db.TBLURUN
                               orderby x.STOK ascending
                               select x.AD).FirstOrDefault();
          labelControl13.Text=(from x in db.TBLURUN
                               orderby x.SATİSFİYAT descending
                               select x.AD).FirstOrDefault();
          labelControl12.Text=(from x in db.TBLURUN
                               orderby x.SATİSFİYAT ascending
                               select x.AD).FirstOrDefault();
          labelControl23.Text=db.TBLURUN.Count(x=> x.KATEGORİ==4).ToString();
          labelControl27.Text=db.TBLURUN.Count(x=> x.KATEGORİ==1).ToString();
          labelControl29.Text=db.TBLURUN.Count(x=> x.KATEGORİ==3).ToString();
          labelControl35.Text=(from x in db.TBLURUN
                               select x.MARKA).Distinct().Count().ToString(); 
            
          labelControl39.Text=db.TBLURUNKABUL.Count().ToString();
          labelControl18.Text=db.maxkategorıurun().FirstOrDefault();


            /*
             5.panel
             8.panel
             12.panel
            14.panel
            15.panel
            16.panel
            17.panel

             */
        }
    }
}
