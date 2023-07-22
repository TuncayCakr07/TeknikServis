using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis.Formlar
{
    public partial class FrmArizaListesi : Form
    {
        public FrmArizaListesi()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmArizaListesi_Load(object sender, EventArgs e)
        {
            var values = from x in db.TBLURUNKABUL
                         select new
                         {
                             x.ISLEMID,
                             CARİ = x.TBLCARI.AD + " "+ x.TBLCARI.SOYAD,
                             PERSONEL = x.TBLPERSONEL.AD+ " " + x.TBLPERSONEL.SOYAD,
                             x.GELISTARIH,
                             x.CIKISTARIH,
                             x. URUNSERINO,
                             x.URUNDURUMDETAY
                         };
            gridControl1.DataSource = values.ToList();

            labelControl5.Text = db.TBLURUNKABUL.Count(x=> x.URUNDURUM==true).ToString(); 
            labelControl3.Text = db.TBLURUNKABUL.Count(x=> x.URUNDURUM==false).ToString(); 
            labelControl18.Text = db.TBLURUN.Count().ToString(); 
            labelControl7.Text=db.TBLURUNKABUL.Count(x=> x.URUNDURUMDETAY=="Parça Bekliyor").ToString();
            labelControl13.Text=db.TBLURUNKABUL.Count(x=> x.URUNDURUMDETAY=="Cevap Bekleniyor").ToString();
            labelControl11.Text=db.TBLURUNKABUL.Count(x=> x.URUNDURUMDETAY=="İptal Edildi").ToString();

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-OP10696\TUN;Initial Catalog=DbTeknikServis;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT URUNDURUMDETAY,COUNT(*) FROM TBLURUNKABUL GROUP BY URUNDURUMDETAY", con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(rd[0]), int.Parse(rd[1].ToString()));
            }
            con.Close();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmArizaDetaylar fr= new FrmArizaDetaylar();
            fr.id = gridView1.GetFocusedRowCellValue("ISLEMID").ToString();
            fr.serino = gridView1.GetFocusedRowCellValue("URUNSERINO").ToString();
            fr.Show();
        }
    }
}
