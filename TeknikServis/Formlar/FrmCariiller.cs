using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TeknikServis.Formlar
{
    public partial class FrmCariiller : Form
    {
        public FrmCariiller()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        SqlConnection conn=new SqlConnection(@"Data Source=DESKTOP-OP10696\TUN;Initial Catalog=DbTeknikServis;Integrated Security=True");
        private void FrmCariiller_Load(object sender, EventArgs e)
        {
            //chartControl1.Series["Series 1"].Points.AddPoint("Antalya", 17);
            //chartControl1.Series["Series 1"].Points.AddPoint("İstanbul", 22);
            //chartControl1.Series["Series 1"].Points.AddPoint("Ankara", 11);
            //chartControl1.Series["Series 1"].Points.AddPoint("İzmir", 9);


            gridControl1.DataSource=db.TBLCARI.OrderBy(x=> x.IL).
                GroupBy(x=>x.IL).
                Select(z=> new {İL=z.Key,TOPLAM=z.Count()}).ToList();

            conn.Open();
            SqlCommand cmd = new SqlCommand("select IL,COUNT(*) FROM TBLCARI group by IL",conn);
            SqlDataReader read=cmd.ExecuteReader();
            while(read.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(read[0]), int.Parse(read[1].ToString()));
            }
            conn.Close();
        }
    }
}
