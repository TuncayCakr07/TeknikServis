using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis.Formlar
{
    public partial class FrmFaturaKalemleriPopup : Form
    {
        public FrmFaturaKalemleriPopup()
        {
            InitializeComponent();
        }
        public int id;
        private void FrmFaturaKalemleriPopup_Load(object sender, EventArgs e)
        {
            //label1.Text = id.ToString();
            DbTeknikServisEntities db=new DbTeknikServisEntities();
            gridControl1.DataSource =(from x in db.TBLFATURADETAY
                                        select new
                                        {
                                            x.FATURAID,
                                            x.URUN,
                                            x.ADET,
                                            x.FIYAT
                                        }).ToList();
           
            gridControl2.DataSource = (from x in db.TBLFATURABILGI
                                       select new
                                       {
                                           x.ID,
                                           x.SERI,
                                           x.SIRANO,
                                          ad= x.TBLCARI.AD +" "+x.TBLCARI.SOYAD,
                                           x.PERSONEL,
                                           x.TARIH,
                                           x.SAAT,
                                       }).ToList();
        }

        private void pictureEdit3_Click(object sender, EventArgs e)
        {
            try
            {
                // Masaüstü klasörünün yolu
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                // Oluşturulacak PDF dosyasının adı
                string fileName = "Dosya1.pdf";

                // Masaüstü klasörü ile dosya adını birleştirerek tam yol oluştur
                string fullPath = Path.Combine(desktopPath, fileName);

                // gridControl1'deki verileri PDF dosyasına aktar ve masaüstüne kaydet
                gridControl1.ExportToPdf(fullPath);

                // Başarılı bir şekilde oluşturulduysa kullanıcıya bir mesaj gösterelim
                MessageBox.Show("PDF dosyası başarıyla oluşturuldu ve masaüstüne kaydedildi: " + fullPath, "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Hata oluştuğunda kullanıcıya bir hata mesajı gösterelim
                MessageBox.Show("PDF dosyası oluşturulurken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureEdit4_Click(object sender, EventArgs e)
        {
            try
            {
                // Masaüstü klasörünün yolu
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                // Oluşturulacak Excel dosyasının adı
                string fileName = "Dosya1.xls";

                // Masaüstü klasörü ile dosya adını birleştirerek tam yol oluştur
                string fullPath = Path.Combine(desktopPath, fileName);

                // gridControl1'deki verileri Excel dosyasına aktar ve masaüstüne kaydet
                gridControl1.ExportToXls(fullPath);

                // Başarılı bir şekilde oluşturulduysa kullanıcıya bir mesaj gösterelim
                MessageBox.Show("Excel dosyası başarıyla oluşturuldu ve masaüstüne kaydedildi: " + fullPath, "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Hata oluştuğunda kullanıcıya bir hata mesajı gösterelim
                MessageBox.Show("Excel dosyası oluşturulurken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
