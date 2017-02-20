using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exam_winform_WORDPAD
{
    public partial class TxtEditor : ChildForm
    {
        private TextDocument document;
        public string TxbFontName
        {
            get
            {
                return txtb.Font.FontFamily.Name;
            }
        }
        public float TxbFontSize
        {
            get
            {
                return txtb.Font.Size;
            }
        }

        public Font TxbSelectionFont
        {
            get
            {
                return txtb.Font;
            }
            set
            {
                txtb.Font = value;
            }
        }

        public FontStyle TxbStyle
        {
            get
            {
                return txtb.Font.Style;
            }
        }

        public Color GetSetTxtColor
        {
            get
            {
                return txtb.ForeColor;
            }

            set
            {
                txtb.ForeColor = value;
            }
        }
        
        
        public TxtEditor()
        {
            InitializeComponent();
            document = new TextDocument();
            document.TextChanged += new EventHandler(document_TextChanged);

        }

        void document_TextChanged(object sender, EventArgs e)
        {
            if (txtb.Text != document.Text) txtb.Text = document.Text;
        }

        private void tbxText_TextChanged(object sender, EventArgs e)
        {
            if (txtb.Text != document.Text) document.Text = txtb.Text;
        }



        override public DialogResult OpenFile()
        {
            return TxtLoader.OpenFile(document);
        }
        override public void SaveFile() 
        { 
            TxtSaver.SaveFile(document);
        }
        override public void SaveFileAs() 
        {
            TxtSaver.SaveFileAs(document);
        }

        private void TxtEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!document.IsSaved)
            {
                DialogResult dr = MessageBox.Show("Сохранить файл?", "Файл не сохранен!", MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                switch (dr)
                {
                    case DialogResult.Yes: TxtSaver.SaveFile(document); break;
                    case DialogResult.No: break;
                    case DialogResult.Cancel: e.Cancel = true; break;
                }
            }
        }

        public void rtbCut_Click()
        {
            Clipboard.SetDataObject(this.txtb.SelectedText);
            this.txtb.SelectedText = String.Empty;
        }

        public void Paste_Click()
        {
            IDataObject data = Clipboard.GetDataObject();

            if (data.GetDataPresent(DataFormats.Text))
                txtb.SelectedText = data.GetData(DataFormats.Text).ToString();
        }

        public void Copy_Click()
        {
            Clipboard.SetDataObject(txtb.SelectedText);
        }

        public void Wyrnyi_Click()
        {
            
            if (txtb.Font != null)
            {
                Font currentFont = txtb.Font;
                FontStyle newFontStyle;

                if (txtb.Font.Bold == true)
                {
                    newFontStyle = FontStyle.Regular;
                    if (txtb.Font.Underline == true)
                    {
                        newFontStyle = FontStyle.Underline;
                    }
                    if (txtb.Font.Italic == true)
                    {
                        newFontStyle = FontStyle.Italic;
                    }
                    if (txtb.Font.Italic == true && txtb.Font.Underline == true)
                    {
                        newFontStyle = FontStyle.Underline | FontStyle.Italic;
                    }
                }
               
                else
                {
                     newFontStyle = FontStyle.Bold;
                     if (txtb.Font.Italic == true) 
                     {
                     newFontStyle = FontStyle.Bold|FontStyle.Italic;
                     }
                     if (txtb.Font.Underline == true)
                     {
                     newFontStyle = FontStyle.Bold|FontStyle.Underline;
                     }
                     if (txtb.Font.Underline == true && txtb.Font.Italic == true)
                     {
                         newFontStyle = FontStyle.Italic | FontStyle.Underline | FontStyle.Bold;
                     }
                     
                }
                txtb.Font = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);

            }

        }

        public void Kursiv_Click()
        {

            if (txtb.Font != null)
            {
                Font currentFont = txtb.Font;
                FontStyle newFontStyle = FontStyle.Regular;

                if (txtb.Font.Italic == true)
                {
                    newFontStyle = FontStyle.Regular;
                    if (txtb.Font.Underline == true)
                    {
                        newFontStyle = FontStyle.Underline;
                    }
                    if (txtb.Font.Bold == true)
                    {
                        newFontStyle = FontStyle.Bold;
                    }
                    if (txtb.Font.Underline == true && txtb.Font.Bold == true)
                    {
                        newFontStyle = FontStyle.Underline | FontStyle.Italic;
                    }
                }

                else
                {
                    newFontStyle = FontStyle.Italic;
                    if (txtb.Font.Bold == true)
                    {
                        newFontStyle = FontStyle.Bold | FontStyle.Italic;
                    }
                    if (txtb.Font.Underline == true)
                    {
                        newFontStyle = FontStyle.Italic| FontStyle.Underline;
                    }
                    if (txtb.Font.Bold == true && txtb.Font.Underline == true)
                    {
                        newFontStyle = FontStyle.Italic | FontStyle.Underline | FontStyle.Bold;
                    }

                }
                txtb.Font = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);

            }

        }

        public void Podcherk_Click()
        {

            if (txtb.Font != null)
            {
                Font currentFont = txtb.Font;
                FontStyle newFontStyle = FontStyle.Regular;

                if (txtb.Font.Underline == true)
                {
                    newFontStyle = FontStyle.Regular;
                    if (txtb.Font.Italic == true)
                    {
                        newFontStyle = FontStyle.Italic;
                    }
                    if (txtb.Font.Bold == true)
                    {
                        newFontStyle = FontStyle.Bold;
                    }
                    if (txtb.Font.Italic == true && txtb.Font.Bold == true)
                    {
                        newFontStyle = FontStyle.Bold | FontStyle.Italic;
                    }
                }

                else
                {
                    newFontStyle = FontStyle.Italic;
                    if (txtb.Font.Bold == true)
                    {
                        newFontStyle = FontStyle.Bold | FontStyle.Underline;
                    }
                    if (txtb.Font.Italic == true)
                    {
                        newFontStyle = FontStyle.Italic | FontStyle.Underline;
                    }
                    if (txtb.Font.Bold == true && txtb.Font.Italic == true)
                    {
                        newFontStyle = FontStyle.Italic | FontStyle.Underline | FontStyle.Bold;
                    }

                }
                txtb.Font = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);

            }

        }

    }
}
