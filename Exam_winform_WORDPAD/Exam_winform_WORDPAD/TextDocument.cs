using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam_winform_WORDPAD
{
    public class TextDocument
    {
        public event EventHandler TextChanged;

        private String location = "";
        public String Location
        {
            get { return location; }
            set { location = value; }
        }

        public Boolean isSaved = true;
        public Boolean IsSaved
        {
            get { return isSaved; }
        }

        private Encoding textEncoding = Encoding.Default;
        public Encoding TextEncoding
        {
            get { return textEncoding; }
            set { textEncoding = value; }
        }

        private String text = "";
        public String Text
        {
            get { return text; }
            set
            {
                if (text != value)
                {
                    text = value;
                    isSaved = false;
                    if (TextChanged != null) TextChanged(this, EventArgs.Empty);
                }
            }
        }
    }
}
