using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TeknikServis.Formlar
{
    public partial class FrmMarkalar : Form
    {
        public FrmMarkalar()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmMarkalar_Load(object sender, EventArgs e)
        {
            var values = db.TBLURUN.OrderBy(x => x.MARKA).GroupBy(y => y.MARKA).
                Select(z => new
            {
                Marka = z.Key,
                Toplam = z.Count()
            });
            gridControl1.DataSource = values.ToList();
            labelControl2.Text=db.TBLURUN.Count().ToString();
            labelControl3.Text = (from x in db.TBLURUN
                                  select x.MARKA).Distinct().Count().ToString();
            labelControl5.Text = (from x in db.TBLURUN
                                   orderby x.SATİSFİYAT descending
                                   select x.MARKA).FirstOrDefault();
            labelControl19.Text = (from x in db.TBLURUN
                                   orderby x.STOK descending
                                   select x.AD).FirstOrDefault();
            labelControl13.Text = (from x in db.TBLURUN
                                   orderby x.STOK ascending
                                   select x.AD).FirstOrDefault();
            labelControl18.Text = (from x in db.TBLURUN
                                   orderby x.SATİSFİYAT ascending
                                   select x.AD).FirstOrDefault();

            labelControl7.Text = db.MAXURUNMARKA1().FirstOrDefault();

            chartControl1.Series["Series 1"].Points.AddPoint("Siemens", 4);
            //chartControl1.Series["Series 1"].Points.AddPoint("Arçelik", 6);
            //chartControl1.Series["Series 1"].Points.AddPoint("Beko", 2);
            //chartControl1.Series["Series 1"].Points.AddPoint("MSI", 1);
            //chartControl1.Series["Series 1"].Points.AddPoint("Lenovo", 1);

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-OP10696\TUN;Initial Catalog=DbTeknikServis;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT MARKA,COUNT(*) FROM TBLURUN GROUP BY MARKA", con);
            SqlDataReader rd= cmd.ExecuteReader();
            while (rd.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(rd[0]),int.Parse(rd[1].ToString()));
            }
            con.Close();

            /*2.CHART*/


            SqlConnection con1 = new SqlConnection(@"Data Source=DESKTOP-OP10696\TUN;Initial Catalog=DbTeknikServis;Integrated Security=True");
            con1.Open();
            SqlCommand komut = new SqlCommand("SELECT TBLKATEGORİ.AD, COUNT(*) FROM TBLURUN INNER JOIN TBLKATEGORİ ON TBLKATEGORİ.ID = TBLURUN.KATEGORİ GROUP BY TBLKATEGORİ.AD", con1);
            SqlDataReader rd2 = komut.ExecuteReader();
            while (rd2.Read())
            {
                chartControl2.Series["Kategoriler"].Points.AddPoint(Convert.ToString(rd2[0]), int.Parse(rd2[1].ToString()));
            }
            con1.Close();
        }
    }
}
