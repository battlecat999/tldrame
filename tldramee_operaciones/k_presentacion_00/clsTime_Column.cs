using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace k_presentacion_00
{

    public class clsTime_Column : DataGridViewColumn
    {
        public clsTime_Column() : base(new clsTime_Cell())
        {
        }

        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                // Ensure that the cell used for the template is a CalendarCell.
                if (value != null &&
                    !value.GetType().IsAssignableFrom(typeof(clsTime_Cell)))
                {
                    throw new InvalidCastException("Must be a TimeCell");
                }
                base.CellTemplate = value;
            }
        }
    }


}
