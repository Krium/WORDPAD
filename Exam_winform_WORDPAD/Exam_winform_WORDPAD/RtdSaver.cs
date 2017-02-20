﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exam_winform_WORDPAD
{
    public static class RtdSaver
    {
        private static void Save(RichTextDocument doc)
        {
            try
            {
                TextWriter textWriter = new StreamWriter(doc.Location, false);
                textWriter.Write(doc.Text);
                textWriter.Close();

                doc.isSaved = true;
            }
            catch
            {
                MessageBox.Show("Ошибка сохранения файла!", "MDI Sample", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void SaveFileAs(RichTextDocument doc)
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                CheckPathExists = true,
                ValidateNames = true,
                AddExtension = true,
                Title = "Save File - MDI Sample",
                Filter = "Text files (*.rtf)|*.rtf"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                doc.Location = sfd.FileName;
                RtdSaver.Save(doc);
            }
        }

        public static void SaveFile(RichTextDocument doc)
        {
            if (doc.Location != String.Empty) Save(doc);
            else SaveFileAs(doc);
        }

    }
}
