using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace k_presentacion_00
{
    class clsCalendar_Column : DataGridViewColumn
    {

        public clsCalendar_Column() : base(new clsCalendar_Cell())
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
                if (value != null && !value.GetType().IsAssignableFrom(typeof(clsCalendar_Cell)))
                {
                    throw new InvalidCastException("Must be a CalendarCell");
                }

                base.CellTemplate = value;

            }
        }

    }


}
