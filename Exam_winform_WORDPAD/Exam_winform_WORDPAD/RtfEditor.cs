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
    public partial class RtfEditor : ChildForm
    {
        private RichTextDocument document;

        public string RtdFontName 
        { 
            get 
            { 
               return richTextBox1.Font.FontFamily.Name;
            }             
        }
        public float RtdFontSize
        {
            get
            {
                return richTextBox1.Font.Size;
            }
        }
        
        public Font RtdSelectionFont
        {
            get
            {
                return richTextBox1.SelectionFont;
            }
            set
            {
                richTextBox1.SelectionFont =value;
            }
        }

        public Font GetSetRtdFont
        {
            get
            {
                return richTextBox1.Font;
            }
            set
            {
                richTextBox1.Font = value;
            }
        }

        public FontStyle RdtStyle
        {
            get
            {
                return richTextBox1.SelectionFont.Style;
            }
        }

        public Color GetSetRtdSelectionColor
        {
            get
            {
                return richTextBox1.SelectionColor;
            }

            set
            {
                richTextBox1.SelectionColor = value;
            }
        }

        public RtfEditor()
        {
            InitializeComponent();
            document = new RichTextDocument();
            document.TextChanged += new EventHandler(document_TextChanged);
        }

        void document_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Rtf != document.Text)
            {
                richTextBox1.Rtf = document.Text;                
            }
        }
       
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Rtf != document.Text)
            {
                document.Text = richTextBox1.Rtf;                
            }
        }

        override public DialogResult OpenFile()
        { 
           return RtdLoader.OpenFile(document); 
        }

        override public void SaveFile() 
        {
            RtdSaver.SaveFile(document); 
        }
        override public void SaveFileAs() 
        { 
            RtdSaver.SaveFileAs(document); 
        }

        public void rtbCut_Click()
        {                     
            Clipboard.SetDataObject(this.richTextBox1.SelectedText);
            this.richTextBox1.SelectedText = String.Empty;
       }

        public void Paste_Click()
        {
            IDataObject data = Clipboard.GetDataObject();

            if (data.GetDataPresent(DataFormats.Text))
            richTextBox1.SelectedText = data.GetData(DataFormats.Text).ToString();
        }

        public void Copy_Click()
        {
            Clipboard.SetDataObject(richTextBox1.SelectedText);
        }

        public void Wyrnyi_Click()
        {

            if (richTextBox1.SelectionFont != null)
            {
                Font currentFont = richTextBox1.SelectionFont;
                FontStyle newFontStyle;

                if (richTextBox1.SelectionFont.Bold == true)
                {
                    newFontStyle = FontStyle.Regular;
                    if(richTextBox1.SelectionFont.Underline == true)
                    {
                    newFontStyle = FontStyle.Underline;
                    }
                    if(richTextBox1.SelectionFont.Italic == true)
                    {
                    newFontStyle = FontStyle.Italic;
                    }
                    if(richTextBox1.SelectionFont.Italic == true&& richTextBox1.SelectionFont.Underline == true)
                    {
                    newFontStyle = FontStyle.Italic|FontStyle.Underline;
                    }

                }
                else
                {
                    newFontStyle = FontStyle.Bold;
                    if(richTextBox1.SelectionFont.Underline == true)
                    {
                    newFontStyle = FontStyle.Underline|FontStyle.Bold;
                    }
                    if(richTextBox1.SelectionFont.Italic == true)
                    {
                    newFontStyle = FontStyle.Italic|FontStyle.Bold;
                    }
                    if(richTextBox1.SelectionFont.Italic == true&& richTextBox1.SelectionFont.Underline == true)
                    {
                    newFontStyle = FontStyle.Italic|FontStyle.Underline|FontStyle.Bold;
                    }
                }
                richTextBox1.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);

            }
        }
               
        public void Kursiv_Click()
        {

            if (richTextBox1.SelectionFont != null)
            {
                Font currentFont = richTextBox1.SelectionFont;
                FontStyle newFontStyle;

                if (richTextBox1.SelectionFont.Italic == true)
                {
                    newFontStyle = FontStyle.Regular;
                    if(richTextBox1.SelectionFont.Underline == true)
                    {
                    newFontStyle = FontStyle.Underline;
                    }
                    if(richTextBox1.SelectionFont.Bold == true)
                    {
                    newFontStyle = FontStyle.Bold;
                    }
                    if(richTextBox1.SelectionFont.Bold == true&& richTextBox1.SelectionFont.Underline == true)
                    {
                    newFontStyle = FontStyle.Bold|FontStyle.Underline;
                    }

                }
                else
                {
                    newFontStyle = FontStyle.Italic;
                    if(richTextBox1.SelectionFont.Underline == true)
                    {
                        newFontStyle = FontStyle.Underline | FontStyle.Italic;
                    }
                    if(richTextBox1.SelectionFont.Bold == true)
                    {
                    newFontStyle = FontStyle.Italic|FontStyle.Bold;
                    }
                    if(richTextBox1.SelectionFont.Bold == true&& richTextBox1.SelectionFont.Underline == true)
                    {
                    newFontStyle = FontStyle.Italic|FontStyle.Underline|FontStyle.Bold;
                    }
                }
                richTextBox1.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);

            }
        }

        public void Podcherk_Click()
        {

            if (richTextBox1.SelectionFont != null)
            {
                Font currentFont = richTextBox1.SelectionFont;
                FontStyle newFontStyle;

                if (richTextBox1.SelectionFont.Underline == true)
                {
                    newFontStyle = FontStyle.Regular;
                    if (richTextBox1.SelectionFont.Italic == true)
                    {
                        newFontStyle = FontStyle.Italic;
                    }
                    if (richTextBox1.SelectionFont.Bold == true)
                    {
                        newFontStyle = FontStyle.Bold;
                    }
                    if (richTextBox1.SelectionFont.Bold == true && richTextBox1.SelectionFont.Italic == true)
                    {
                        newFontStyle = FontStyle.Bold | FontStyle.Italic;
                    }

                }
                else
                {
                    newFontStyle = FontStyle.Underline;
                    if (richTextBox1.SelectionFont.Italic == true)
                    {
                        newFontStyle = FontStyle.Underline | FontStyle.Italic;
                    }
                    if (richTextBox1.SelectionFont.Bold == true)
                    {
                        newFontStyle = FontStyle.Underline | FontStyle.Bold;
                    }
                    if (richTextBox1.SelectionFont.Bold == true && richTextBox1.SelectionFont.Italic == true)
                    {
                        newFontStyle = FontStyle.Italic | FontStyle.Underline | FontStyle.Bold;
                    }
                }
                richTextBox1.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);

            }


        }

    }
}
