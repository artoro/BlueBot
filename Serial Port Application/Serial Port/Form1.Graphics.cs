using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Serial_Port
{
    public partial class Form1 : Form
    {
        private void FormGraph_tabGUI(object sender, EventArgs e)
        {
            var size = tabGUI.Size;
            var bounds = new Rectangle(10, 43, size.Width - 9, size.Height - 8);
            int halfWidth = size.Width / 2 - 13;
            int quarterWidth = halfWidth / 2 - 4;
            int oneSixthWidth = halfWidth / 3 - 4;
            int editPanel = (editKeys) ? 45 : 0;

            gbGraphics.Width = halfWidth;
            gbPanel.Width = halfWidth;
            gbPanel.Location = new Point(bounds.Width - gbPanel.Width, bounds.Y);
            gbGraphics.Location = new Point(bounds.X, bounds.Y);

            bRestart.Width = quarterWidth;
            bEdit.Width = quarterWidth;
            bRestart.Location = new Point(bounds.X, bRestart.Location.Y);
            bEdit.Location = new Point(bounds.X + gbGraphics.Width - bEdit.Width, bEdit.Location.Y);

            bAdd.Width = oneSixthWidth;
            cbAdd.Width = oneSixthWidth - 2;
            bSave.Width = oneSixthWidth;
            bLoad.Width = oneSixthWidth;
            bAdd.Location = new Point(bounds.X, bAdd.Location.Y);
            cbAdd.Location = new Point(bounds.X + 1, cbAdd.Location.Y);
            bLoad.Location = new Point(bounds.X + gbGraphics.Width - bLoad.Width, bLoad.Location.Y);
            bSave.Location = new Point((bAdd.Location.X + bLoad.Location.X) / 2, bSave.Location.Y);

            PanelGUI.Update();
            if (editKeys) FormGraph_ShowPanelBackground();
        }

        //Zmiana tła panelu GUI
        private void FormGraph_ShowPanelBackground()
        {
            gbPanel.BackColor = System.Drawing.Color.LightGray;
            gbPanel.BackgroundImage = new Bitmap(gbPanel.Width,gbPanel.Height);
            using (TextureBrush brush = new TextureBrush(Properties.Resources.cell, WrapMode.Tile))
            using (Graphics g = Graphics.FromImage(gbPanel.BackgroundImage))
            {
                brush.TranslateTransform(PanelGUI.WebBoundary.X, PanelGUI.WebBoundary.Y);
                g.FillRectangle(brush, PanelGUI.WebBoundary);
            }
        }
        private void FormGraph_HidePanelBackground()
        {
            gbPanel.BackColor = System.Drawing.Color.Transparent;
            gbPanel.BackgroundImage = new Bitmap(1, 1);
        }

        //Menu edycji GUI
        private void FormGraph_ShowEditMenu()
        {
            gbGraphics.Height = gbGraphics.Height - 45;
            bAdd.Visible = true;
            cbAdd.Visible = true;
            bSave.Visible = true;
            bLoad.Visible = true;
        }
        private void FormGraph_HideEditMenu()
        {
            gbGraphics.Height = gbPanel.Height - 27;
            bAdd.Visible = false;
            cbAdd.Visible = false;
            bSave.Visible = false;
            bLoad.Visible = false;
        }

        //Menu wyboru portu
        private void FormGraph_ShowCbName()
        {
            cbName1.Visible = true;
            butRefresh1.Visible = true;
            cbName2.Visible = true;
            butRefresh2.Visible = true;
        }
        private void FormGraph_HideCbName()
        {
            cbName1.Visible = false;
            butRefresh1.Visible = false;
            cbName2.Visible = false;
            butRefresh2.Visible = false;
        }
    }
}
