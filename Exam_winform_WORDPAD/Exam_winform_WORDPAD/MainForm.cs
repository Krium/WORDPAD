using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Text;

namespace Exam_winform_WORDPAD
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InstalledFontCollection fonts = new InstalledFontCollection();
            foreach (FontFamily family in fonts.Families)
            {
                tscbFontStyles.Items.Add(family.Name);
            }
                     
            for (int i = 2; i <= 72; i+=2)
            {
                tscbFontSize.Items.Add(i);
            }                                 
        }

        

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form cf = this.ActiveMdiChild;
            if (cf != null) ((ChildForm)cf).SaveFile();
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void opentxtFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TxtEditor txt = new TxtEditor() { MdiParent = this };

            if (txt.OpenFile() == DialogResult.OK)
            {
                txt.Show();
                tscbFontStyles.Text = txt.TxbFontName;
                tscbFontSize.Text = txt.TxbFontSize.ToString();    
            }
        }

        private void openrtfFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RtfEditor rtf = new RtfEditor() {MdiParent = this};
            if (rtf.OpenFile() == DialogResult.OK)
            {
                rtf.Show();
                tscbFontStyles.Text = rtf.RtdFontName;
                tscbFontSize.Text = rtf.RtdFontSize.ToString(); 
            }
        }

        private void createNewtxtFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TxtEditor txt = new TxtEditor();
            txt.MdiParent = this;
            txt.Show();
            txt.TxbSelectionFont = new Font ("Times New Roman", 12);
            tscbFontStyles.Text = txt.TxbFontName;
            tscbFontSize.Text = txt.TxbFontSize.ToString();
        }

        private void createNewrtfFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RtfEditor rtf = new RtfEditor() { MdiParent = this };
            rtf.Show();
            rtf.GetSetRtdFont = new Font("Times New Roman", 12);
            tscbFontStyles.Text = rtf.RtdFontName;
            tscbFontSize.Text = rtf.RtdFontSize.ToString(); 
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form cf = this.ActiveMdiChild;
            if (cf != null) ((ChildForm)cf).SaveFileAs();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bCut_Click(object sender, EventArgs e)
        {
           Form tmp = this.ActiveMdiChild;
           if (tmp is RtfEditor)
           {
               RtfEditor rtf = (RtfEditor)tmp;
               rtf.rtbCut_Click();
           }
           else
           {
               TxtEditor txt = (TxtEditor)tmp;
               txt.rtbCut_Click();           
           }

        }

        private void bPaste_Click(object sender, EventArgs e)
        {
            Form tmp = this.ActiveMdiChild;
            if (tmp is RtfEditor)
            {
                RtfEditor rtf = (RtfEditor)tmp;
                rtf.Paste_Click();
            }
            else
            {
                TxtEditor txt = (TxtEditor)tmp;
                txt.Paste_Click();
            }
        }

        private void bCopy_Click(object sender, EventArgs e)
        {
            Form tmp = this.ActiveMdiChild;
            if (tmp is RtfEditor)
            {
                RtfEditor rtf = (RtfEditor)tmp;
                rtf.Copy_Click();
            }
            else
            {
                TxtEditor txt = (TxtEditor)tmp;
                txt.Copy_Click();
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bCut_Click(sender,e);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bCopy_Click(sender, e);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bPaste_Click(sender, e);
        }

        private void bwyrnyi_Click(object sender, EventArgs e)
        {
            Form tmp = this.ActiveMdiChild;
            if (tmp is RtfEditor)
            {
                RtfEditor rtf = (RtfEditor)tmp;
                rtf.Wyrnyi_Click();
            }
            else
            {
                TxtEditor txt = (TxtEditor)tmp;
                txt.Wyrnyi_Click();
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {           
            Form tmp = this.ActiveMdiChild;
            if (tmp == null)
            {
                return;
            }

            if (tmp is RtfEditor)
            {
                RtfEditor rtf = (RtfEditor)tmp;
                fontDialog1.Font = rtf.RtdSelectionFont;
                if (fontDialog1.ShowDialog() == DialogResult.OK)
                {
                    rtf.RtdSelectionFont = fontDialog1.Font;
                }

            }
            else
            {
                TxtEditor txt = (TxtEditor)tmp;               
                fontDialog1.Font = txt.TxbSelectionFont;
                if (fontDialog1.ShowDialog() == DialogResult.OK)
                {
                    txt.TxbSelectionFont = fontDialog1.Font;
                }

            }
            
            
            
        }

        private void bKursiv_Click(object sender, EventArgs e)
        {
            Form tmp = this.ActiveMdiChild;
            if (tmp is RtfEditor)
            {
                RtfEditor rtf = (RtfEditor)tmp;
                rtf.Kursiv_Click();
            }
            else
            {
                TxtEditor txt = (TxtEditor)tmp;
                txt.Kursiv_Click();
            }
        }

        private void bPodcherk_Click(object sender, EventArgs e)
        {
            Form tmp = this.ActiveMdiChild;
            if (tmp is RtfEditor)
            {
                RtfEditor rtf = (RtfEditor)tmp;
                rtf.Podcherk_Click();
            }
            else
            {
                TxtEditor txt = (TxtEditor)tmp;
                txt.Podcherk_Click();
            }
        }

        private void tscbFontStyles_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form tmp = this.ActiveMdiChild;
            if (tmp is RtfEditor)
            {
                RtfEditor rtf = (RtfEditor)tmp;
                if (tscbFontStyles.SelectedIndex != -1 && tscbFontSize.SelectedIndex != -1)
                {
                    rtf.RtdSelectionFont = new Font(tscbFontStyles.SelectedItem.ToString(), int.Parse(tscbFontSize.SelectedItem.ToString()), rtf.RdtStyle);
                }

            }
            else
            {
                TxtEditor txt = (TxtEditor)tmp;
                if (tscbFontStyles.SelectedIndex != -1 && tscbFontSize.SelectedIndex != -1)
                {
                    txt.TxbSelectionFont = new Font(tscbFontStyles.SelectedItem.ToString(), int.Parse(tscbFontSize.SelectedItem.ToString()), txt.TxbStyle);
                }
            }
        }

        private void tscbFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form tmp = this.ActiveMdiChild;
            if (tmp is RtfEditor)
            {
                RtfEditor rtf = (RtfEditor)tmp;
                if (tscbFontStyles.SelectedIndex != -1 && tscbFontSize.SelectedIndex != -1)
                {
                    rtf.RtdSelectionFont = new Font(tscbFontStyles.SelectedItem.ToString(), int.Parse(tscbFontSize.SelectedItem.ToString()), rtf.RdtStyle);
                }

            }
            else
            {
                TxtEditor txt = (TxtEditor)tmp;
                if (tscbFontStyles.SelectedIndex != -1 && tscbFontSize.SelectedIndex != -1)
                {
                    txt.TxbSelectionFont = new Font(tscbFontStyles.SelectedItem.ToString(), int.Parse(tscbFontSize.SelectedItem.ToString()), txt.TxbStyle);
                }

            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form tmp = this.ActiveMdiChild;
            if (tmp is RtfEditor)
            {
                RtfEditor rtf = (RtfEditor)tmp;
                colorDialog1.Color = rtf.GetSetRtdSelectionColor;
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                {
                    rtf.GetSetRtdSelectionColor = colorDialog1.Color;
                }

            }
            else
            {
                TxtEditor txt = (TxtEditor)tmp;
                colorDialog1.Color = txt.GetSetTxtColor;
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                {
                    txt.GetSetTxtColor = colorDialog1.Color;
                }

            }
            
        }

        
        
    }
}
