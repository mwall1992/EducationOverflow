using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business {
    
    public class DataSetUtilities {

        private static int EMPTY_TABLE_ROW_COUNT = 0;

        private static int FIRST_ROW_INDEX = 0;

        /// <summary>
        /// Retrieve the first row from a DataTable.
        /// </summary>
        /// <typeparam name="T">The DataRow.</typeparam>
        /// <param name="dataTable">The queried DataTable.</param>
        /// <returns>
        /// If the DataTable is noy empty, a DataRow object containing information 
        /// from the first row in the DataTable; otherwise, null.
        /// </returns>
        public static T GetFirstRow<T>(System.Data.DataTable dataTable) 
        where T : System.Data.DataRow {
            T row = null;

            if (dataTable.Rows.Count != EMPTY_TABLE_ROW_COUNT) {
                row = (T)dataTable.Rows[FIRST_ROW_INDEX];
            }

            return row;
        }
    }
}
