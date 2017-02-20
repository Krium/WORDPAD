using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Exam_winform_WORDPAD
{
    public class ChildForm: Form
    {
        virtual public DialogResult OpenFile()
        {
            return DialogResult.OK;
        }

        virtual public void SaveFile()
        {

        }

        virtual public void SaveFileAs()
        {

        }

    }
}
