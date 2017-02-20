using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Exam_winform_WORDPAD
{
   public static class TxtLoader
    {
       public static DialogResult OpenFile(TextDocument doc)
       {
           OpenFileDialog ofd = new OpenFileDialog()
           {
               CheckFileExists = true,
               CheckPathExists = true,
               ValidateNames = true,
               Title = "Open File - MDI Sample",
               Filter = "Text files (*.txt)|*.txt"
           };

           if (ofd.ShowDialog() == DialogResult.OK)
           {
               doc.Location = ofd.FileName;

               try
               {
                   TextReader textReader = new StreamReader(doc.Location, doc.TextEncoding, true);
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

       private static void ReloadFile(TextDocument doc)
       {
           try
           {
               TextReader textReader = new StreamReader(doc.Location, doc.TextEncoding, true);
               doc.Text = textReader.ReadToEnd();
               textReader.Close();
           }
           catch (Exception exception)
           {
               MessageBox.Show("Ошибка открытия файла!/n" + exception.Message, "MDI Sample", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
       }

       public static void ReloadFile(TextDocument doc, Encoding encoding)
       {
           doc.TextEncoding = encoding;

           if (doc.Location != String.Empty) ReloadFile(doc);
           else OpenFile(doc);
       }       
    }
}
