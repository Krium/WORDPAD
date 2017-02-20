using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exam_winform_WORDPAD
{
    public static class RtdLoader
    {
        public static DialogResult OpenFile(RichTextDocument doc)
        {
            OpenFileDialog ofg = new OpenFileDialog()
            {
                CheckFileExists = true,
                CheckPathExists = true,
                ValidateNames = true,
                Title = "Open File - MDI Sample",
                Filter = "Text files (*.rtf)|*.rtf"
            };

            if (ofg.ShowDialog() == DialogResult.OK)
            {
                doc.Location = ofg.FileName;

                try
                {
                    TextReader textReader = new StreamReader(ofg.FileName, Encoding.Default, true);
                    doc.Text = textReader.ReadToEnd();
                    textReader.Close();

                    return DialogResult.OK;
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Ошибка открытия файла!/n" + exception.Message, "MDI Sample", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return DialogResult.Cancel;
        }

    }
}
