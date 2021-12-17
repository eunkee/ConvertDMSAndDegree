using System;
using System.Windows.Forms;

namespace ConvertDMSAndDegree
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //십진법 -> 도,분,초
        private void ConvertDecdegToDMS(double angle, out int decdeg, out int minsec, out double sec)
        {
            double t_decdeg = angle;
            double t_minsec = (t_decdeg - Math.Truncate(t_decdeg)) * 60;
            double t_sec = (t_minsec - Math.Truncate(t_minsec)) * 60;

            decdeg = (int)Math.Truncate(t_decdeg);
            minsec = (int)Math.Truncate(t_minsec);
            sec = Math.Round(t_sec, 2);
        }

        //도,분,초 -> 십진법
        private void ConvertDMSToDecdeg(int decdeg, int minsec, double sec, out double DMS)
        {
            double t_angle = (double)decdeg + (double)minsec / 60 + sec / 3600;
            DMS = Math.Round(t_angle, 5);
        }

        private void ButtonDMStoDegree_Click(object sender, EventArgs e)
        {
            string textDMSLat1 = textBoxLat1.Text;
            string textDMSLat2 = textBoxLat2.Text;
            string textDMSLat3 = textBoxLat3.Text;
            string textDMSLon1 = textBoxLon1.Text;
            string textDMSLon2 = textBoxLon2.Text;
            string textDMSLon3 = textBoxLon3.Text;

            if (textDMSLat1.Length > 0 && textDMSLat2.Length > 0 && textDMSLat3.Length > 0)
            {
                if (int.TryParse(textDMSLat1, out int dmsLat1)
                    && int.TryParse(textDMSLat1, out int dmsLat2)
                    && int.TryParse(textDMSLat1, out int dmsLat3))
                {
                    ConvertDMSToDecdeg(dmsLat1, dmsLat2, dmsLat3, out double Lat);
                    TextBoxDegreeLat.Text = Lat.ToString();
                }
            }

            if (textDMSLon1.Length > 0 && textDMSLon2.Length > 0 && textDMSLon3.Length > 0)
            {
                if (int.TryParse(textDMSLon1, out int dmsLon1)
                    && int.TryParse(textDMSLon2, out int dmsLon2)
                    && int.TryParse(textDMSLon3, out int dmsLon3))
                {
                    ConvertDMSToDecdeg(dmsLon1, dmsLon2, dmsLon3, out double Lat);
                    TextBoxDegreeLat.Text = Lat.ToString();
                }
            }
        }

        private void ButtonDegreetoDMS_Click(object sender, EventArgs e)
        {
            string textDegreeLat = TextBoxDegreeLat.Text;
            string textDegreeLon = TextBoxDegreeLon.Text;

            if (textDegreeLat.Length > 0)
            {
                if (double.TryParse(textDegreeLat, out double degreeLat))
                {
                    ConvertDecdegToDMS(degreeLat, out int Latdecdeg, out int Latminsec, out double Latsec);
                    textBoxLat1.Text = Latdecdeg.ToString();
                    textBoxLat2.Text = Latminsec.ToString();
                    textBoxLat3.Text = Latsec.ToString();
                }
            }

            if (textDegreeLon.Length > 0)
            {
                if (double.TryParse(textDegreeLon, out double degreeLon))
                {
                    ConvertDecdegToDMS(degreeLon, out int Londecdeg, out int Lonminsec, out double Lonsec);
                    textBoxLon1.Text = Londecdeg.ToString();
                    textBoxLon2.Text = Lonminsec.ToString();
                    textBoxLon3.Text = Lonsec.ToString();
                }
            }
        }

        private void ButtonClearDMS_Click(object sender, EventArgs e)
        {
            textBoxLat1.Text = string.Empty;
            textBoxLat2.Text = string.Empty;
            textBoxLat3.Text = string.Empty;
            textBoxLon1.Text = string.Empty;
            textBoxLon2.Text = string.Empty;
            textBoxLon3.Text = string.Empty;
        }

        private void ButtonClearDegree_Click(object sender, EventArgs e)
        {
            TextBoxDegreeLat.Text = string.Empty;
            TextBoxDegreeLon.Text = string.Empty;
        }
    }
}