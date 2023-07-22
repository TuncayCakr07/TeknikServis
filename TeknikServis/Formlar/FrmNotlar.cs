using DevExpress.XtraEditors;
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
    public partial class FrmNotlar : Form
    {
        public FrmNotlar()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmNotlar_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = db.TBLNOTLAR.Where(x=> x.DURUM==false).ToList();
            gridControl2.DataSource=db.TBLNOTLAR.Where(x=> x.DURUM==true).ToList();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLNOTLAR t=new TBLNOTLAR();
            t.BASLİK = TxtBaslik.Text;
            t.İCERİK=TxtIcerik.Text;
            t.DURUM = false;
            t.TARİH = DateTime.Parse(textEdit1.Text);
            db.TBLNOTLAR.Add(t);
            db.SaveChanges();
            MessageBox.Show("Yeni Not Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = db.TBLNOTLAR.Where(x => x.DURUM == false).ToList();
            gridControl2.DataSource = db.TBLNOTLAR.Where(x => x.DURUM == true).ToList();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (checkEdit1.Checked==true)
            {
                int id = int.Parse(TxtID.Text);
                var value = db.TBLNOTLAR.Find(id);
                value.DURUM = true;
                db.SaveChanges();
                MessageBox.Show("Not Durumu Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var value = db.TBLNOTLAR.Find(id);
            db.TBLNOTLAR.Remove(value);
            db.SaveChanges();
            MessageBox.Show("Not Başarıyla Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            var values = db.TBLNOTLAR.ToList();
            gridControl1.DataSource = values;
        }
    }
}
