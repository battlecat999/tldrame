using k_negocio_00;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace k_presentacion_00
{
    public partial class frm_Trafico_a_Designar : Form
    {
        #region Field Names
        const string COLUMN_FECHA = "fecha";
        const string COLUMN_IDEMPRESA = "IdEmpresa";
        const string COLUMN_IDOT = "idOT";
        const string COLUMN_ITEM = "item";
        const string COLUMN_IDCORREDOR = "idCorredor";
        const string COLUMN_COSTO = "costo";
        const string COLUMN_POSICIONAMIENTOFECHA = "PosicionamientoFecha";
        const string COLUMN_RETIROHORA = "RetiroHora";
        const string COLUMN_ID = "id";
        const string COLUMN_RAZONSOCIAL = "razon_Social";
        const string COLUMN_TIPOSERVICIO = "Tipo_Servicio";
        const string COLUMN_PMIENTO = "Pmiento";
        const string COLUMN_CONTENEDOR = "Contenedor";
        const string COLUMN_RUTA = "Ruta";
        const string COLUMN_BLBOOKING = "BL_Booking";
        const string COLUMN_NROOTMASCARA = "Nro_OT_Con_Mascara";
        const string COLUMN_INDTIPO = "IndTipo";
        const string COLUMN_COLOR = "Color";
        #endregion
        guardar_datos_login datos = guardar_datos_login.Instance();
        public int _Empresa { get; set; }
        public frm_Trafico_a_Designar()
        {
            InitializeComponent();
        }
        
        private void frm_Trafico_a_Designar_Load(object sender, EventArgs e)
        {
            RefreshDataGridView();
            timer.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }

        /// <summary>
        /// Carga la grilla
        /// </summary>
        private void RefreshDataGridView()
        {
            dg.Columns.Clear();
            dg.Rows.Clear();

            DataTable dt = GetData();

            if (dt.Rows.Count == 0)
                return;

            List<List<DataRow>> result = GetRowsByDay(dt, out int max);
            ProccessRows(result, max);

            HideColumns(dt);

            dg.AutoResizeColumnHeadersHeight();
            dg.Refresh();
        }

        /// <summary>
        /// Obtiene los datos del SP
        /// </summary>
        /// <returns></returns>
        private DataTable GetData()
        {
            //DataTable dt = new DataTable();
            //using (MySqlConnection connection = new MySqlConnection("Data Source=190.228.29.57;Initial Catalog=logisticamm_pop;User=programadorphp;Password=Venezuela2020"))
            //{
            //    using (MySqlCommand command = new MySqlCommand("SP_Viajes_A_Nominar_Prueba", connection))
            //    {
            //        command.CommandType = CommandType.StoredProcedure;

            //        command.Parameters.AddWithValue("@pIdEmpresa", "1");
            //        command.Parameters.AddWithValue("@intNominados", "0");

            //        connection.Open();

            //        MySqlDataAdapter adapter = new MySqlDataAdapter(command);

            //        adapter.Fill(dt);
            //    }
            //}

            //return dt;
            DataTable dt;

            //dt = c.DN_Trafico_Grillas(datos.g_idEmpresa, "SP_Viajes_A_Nominar");

            //funciones_Varias o = new funciones_Varias();
            DNTablas_Gral lista = new DNTablas_Gral();

            //BindingSource bindingSource = new BindingSource();

            //System.Data.DataSet dsOTs = new System.Data.DataSet("OTs");

            var parameters = new[]
            {
                new MySqlParameter(){ ParameterName="intIdEmpresa", Value = _Empresa  }
            };

            dt = lista.Get_Datos("SP_Viajes_A_Nominar", parameters);
            return dt;

        }

        /// <summary>
        /// Obtiene los registros por cada dia y agrega las columnas a la grilla
        /// </summary>
        /// <param name="dt">Datatble cargado con los resultados</param>
        /// <param name="max">Cantidad de registros maximos en un dia</param>
        /// <returns></returns>
        private List<List<DataRow>> GetRowsByDay(DataTable dt, out int max)
        {
            var days = dt.AsEnumerable().Select(x => new { fecha = x.Field<DateTime>("fecha") }).Distinct();

            int i = 0;
            max = 0;
            List<List<DataRow>> result = new List<List<DataRow>>();
            foreach (var day in days)
            {
                AddColumns(day.fecha, i);
                List<DataRow> cells = dt.AsEnumerable().Where(x => x.Field<DateTime>("Fecha") == day.fecha).ToList();

                if (max < cells.Count)
                    max = cells.Count;

                result.Add(cells);
                i++;
            }

            return result;
        }

        /// <summary>
        /// Carga las filas en la grilla y setea el color si es necesario
        /// </summary>
        /// <param name="result"></param>
        /// <param name="max"></param>
        private void ProccessRows(List<List<DataRow>> result, int max)
        {
            List<string> row = new List<string>();
            for (int i = 0; i < max; i++)
            {
                row.Clear();

                foreach (List<DataRow> dataRows in result)
                {
                    if (dataRows.Count > i)
                        row.AddRange(GetCells(dataRows[i]));
                    else
                        row.AddRange(GetEmptyCells());
                }

                dg.Rows.Add(row.ToArray());

                for (int j = 0; j < result.Count; j++)
                {
                    SetColor(dg.Rows.Count - 2, j);
                }
            }
        }

        /// <summary>
        /// Agrega las columnas a la grilla para un dia
        /// </summary>
        /// <param name="date">Dia a procesar</param>
        /// <param name="i">Indice del dia</param>
        private void AddColumns(DateTime date, int i)
        {
            dg.Columns.Add($"{i}_fecha", date.ToString("ddd, dd MMM"));

            dg.Columns.Add($"{i}_{COLUMN_IDEMPRESA}", "Empresa");
            dg.Columns.Add($"{i}_{COLUMN_IDOT}", "OT");
            dg.Columns.Add($"{i}_{COLUMN_ITEM}", "Ítem");
            dg.Columns.Add($"{i}_{COLUMN_IDCORREDOR}", "idCorredor");
            dg.Columns.Add($"{i}_{COLUMN_COSTO}", "Costo");
            dg.Columns.Add($"{i}_{COLUMN_POSICIONAMIENTOFECHA}", "Fecha Posic.");
            dg.Columns.Add($"{i}_{COLUMN_RETIROHORA}", "Hora");
            dg.Columns.Add($"{i}_{COLUMN_ID}", "Id");
            dg.Columns.Add($"{i}_{COLUMN_RAZONSOCIAL}", "Cliente");
            dg.Columns.Add($"{i}_{COLUMN_BLBOOKING}", "BL");
            dg.Columns.Add($"{i}_{COLUMN_TIPOSERVICIO}", "Tipo Servicio");
            dg.Columns.Add($"{i}_{COLUMN_PMIENTO}", "Pmiento");
            dg.Columns.Add($"{i}_{COLUMN_RUTA}", "Ruta");
            dg.Columns.Add($"{i}_{COLUMN_CONTENEDOR}", "Tipo Cont.");
            dg.Columns.Add($"{i}_{COLUMN_NROOTMASCARA}", "OT");
            dg.Columns.Add($"{i}_{COLUMN_INDTIPO}", "Ind. Tipo");
            dg.Columns.Add($"{i}_{COLUMN_COLOR}", "Color");
        }

        /// <summary>
        /// Convierte el Datarow en una lista de strings que van a representar las celdas
        /// </summary>
        /// <param name="row">Row a procesar</param>
        /// <returns></returns>
        private List<string> GetCells(DataRow row)
        {
            List<string> cells = new List<string>
            {
                "",
                row.Field<int>(COLUMN_IDEMPRESA).ToString(),
                row.Field<int>(COLUMN_IDOT).ToString(),
                row.Field<int>(COLUMN_ITEM).ToString(),
                row.Field<string>(COLUMN_IDCORREDOR),
                row.Field<decimal>(COLUMN_COSTO).ToString(),
                row.Field<string>(COLUMN_POSICIONAMIENTOFECHA),
                row.Field<string>(COLUMN_RETIROHORA),
                row.Field<int>(COLUMN_ID).ToString(),
                row.Field<string>(COLUMN_RAZONSOCIAL),
                row.Field<string>(COLUMN_BLBOOKING),
                row.Field<string>(COLUMN_TIPOSERVICIO),
                row.Field<string>(COLUMN_PMIENTO),
                row.Field<string>(COLUMN_RUTA),
                row.Field<string>(COLUMN_CONTENEDOR),                
                row.Field<string>(COLUMN_NROOTMASCARA),
                row.Field<int>(COLUMN_INDTIPO).ToString(),
                row.Field<string>(COLUMN_COLOR)
            };

            return cells;
        }

        /// <summary>
        /// Obtiene una lista de strings vacios que representan una fila para un dia que no tienen datos
        /// </summary>
        /// <returns></returns>
        private List<string> GetEmptyCells()
        {            
            List<string> cells = new List<string>
            {
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                ""
            };

            return cells;
        }
        

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {            
            string index = dg.Columns[e.ColumnIndex].Name.Split('_')[0];

            CallPopup(e.RowIndex, index);            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectDayRow(e.RowIndex, e.ColumnIndex);
        }

        /// <summary>
        /// Selecciona todas las celdas correspondientes a una celda
        /// </summary>
        /// <param name="rowIndex">Indice de la celda</param>
        /// <param name="columnIndex">Indice de la columna</param>
        private void SelectDayRow(int rowIndex, int columnIndex)
        {
            if (columnIndex < 0 || rowIndex < 0)
                return;

            string columnName = dg.Columns[columnIndex].Name;
            int index = Convert.ToInt32(columnName.Split('_')[0]);

            DataGridViewRow row = dg.Rows[rowIndex];

            row.Cells[$"{index}_{COLUMN_IDOT}"].Selected = true;
            row.Cells[$"{index}_{COLUMN_BLBOOKING}"].Selected = true;
            row.Cells[$"{index}_{COLUMN_CONTENEDOR}"].Selected = true;
            row.Cells[$"{index}_{COLUMN_ITEM}"].Selected = true;
            row.Cells[$"{index}_{COLUMN_NROOTMASCARA}"].Selected = true;
            row.Cells[$"{index}_{COLUMN_RAZONSOCIAL}"].Selected = true;
            row.Cells[$"{index}_{COLUMN_POSICIONAMIENTOFECHA}"].Selected = true;
            row.Cells[$"{index}_{COLUMN_RUTA}"].Selected = true;
            row.Cells[$"{index}_{COLUMN_TIPOSERVICIO}"].Selected = true;
            row.Cells[$"{index}_{COLUMN_RETIROHORA}"].Selected = true;            
        }

        /// <summary>
        /// Obtiene el valor de una celda especifica
        /// </summary>
        /// <param name="rowIndex">Indice de la fila</param>
        /// <param name="columnName">Nombre de la columna</param>
        /// <returns></returns>
        private string GetRowValue(int rowIndex, string columnName)
        {
            DataGridViewRow row = dg.Rows[rowIndex];
            
             return row.Cells[columnName].Value.ToString();
        }

        /// <summary>
        /// Oculta las columnas innecesarias
        /// </summary>
        /// <param name="dt">Datatable cargado</param>
        private void HideColumns(DataTable dt)
        {
            var daysCount = dt.AsEnumerable().Select(x => new { fecha = x.Field<DateTime>("fecha") }).Distinct().Count();

            for (int i = 0; i < daysCount; i++) 
            {
                dg.Columns[$"{i}_{COLUMN_IDEMPRESA}"].Visible = false;
                dg.Columns[$"{i}_{COLUMN_IDCORREDOR}"].Visible = false;
                dg.Columns[$"{i}_{COLUMN_COSTO}"].Visible = false;
                dg.Columns[$"{i}_{COLUMN_RETIROHORA}"].Visible = false;
                dg.Columns[$"{i}_{COLUMN_ID}"].Visible = false;
                dg.Columns[$"{i}_{COLUMN_PMIENTO}"].Visible = false;
                dg.Columns[$"{i}_{COLUMN_INDTIPO}"].Visible = false;
                dg.Columns[$"{i}_{COLUMN_COLOR}"].Visible = false;
                dg.Columns[$"{i}_{COLUMN_NROOTMASCARA}"].Visible = false;

            }
        }

        /// <summary>
        /// Obtiene los datos necesarios, llama el popup y refresca la grilla
        /// </summary>
        /// <param name="rowIndex">Indice de la fila</param>
        /// <param name="columnNameIndex">Indice del nombre de la columna</param>
        private void CallPopup(int rowIndex, string columnNameIndex)
        {
            timer.Stop();
            frm_PopUp_Designa_Viaje frm_PopUp_Designa_Viaje = new frm_PopUp_Designa_Viaje();

            string intEmpresa = GetRowValue(rowIndex, $"{columnNameIndex}_{COLUMN_IDEMPRESA}");
            string intOT = GetRowValue(rowIndex, $"{columnNameIndex}_{COLUMN_IDOT}");
            string intItem = GetRowValue(rowIndex, $"{columnNameIndex}_{COLUMN_ITEM}");
            string intId_Corredor = GetRowValue(rowIndex, $"{columnNameIndex}_{COLUMN_IDCORREDOR}");
            string decCosto = GetRowValue(rowIndex, $"{columnNameIndex}_{COLUMN_COSTO}");
            string strDescripcion_Item = GetRowValue(rowIndex, $"{columnNameIndex}_{COLUMN_RAZONSOCIAL}");
            string intId_Cliente = GetRowValue(rowIndex, $"{columnNameIndex}_{COLUMN_ID}");
            string intIndTipo = GetRowValue(rowIndex, $"{columnNameIndex}_{COLUMN_INDTIPO}");
            string strBooking = GetRowValue(rowIndex, $"{columnNameIndex}_{COLUMN_BLBOOKING}");

            //Llamar POPUP
            frm_PopUp_Designa_Viaje._Empresa = Convert.ToInt32(intEmpresa);
            frm_PopUp_Designa_Viaje._OT = Convert.ToInt32(intOT);
            frm_PopUp_Designa_Viaje._Item = Convert.ToInt32(intItem);
            frm_PopUp_Designa_Viaje._Corredor = Convert.ToInt32(intId_Corredor);
            frm_PopUp_Designa_Viaje._Costo = Convert.ToDecimal(decCosto);
            frm_PopUp_Designa_Viaje._Descripcion_Item = strDescripcion_Item;
            frm_PopUp_Designa_Viaje._IdCliente = Convert.ToInt32(intId_Cliente);
            frm_PopUp_Designa_Viaje._IndTipo = Convert.ToInt32(intIndTipo);
            frm_PopUp_Designa_Viaje._strBooking = strBooking;

            frm_PopUp_Designa_Viaje.ShowDialog(this);

            RefreshDataGridView();

            timer.Start();
        }

        /// <summary>
        /// Ananliza la situacion y modifica el color de la fila si corresponde
        /// </summary>
        /// <param name="rowIndex">Indice de la fila</param>
        /// <param name="columnNameIndex">Indice del nombre de la columna</param>
        private void SetColor(int rowIndex, int columnNameIndex)
        {
            if (columnNameIndex < 0 || rowIndex < 0)
                return;
                       
            DataGridViewRow row = dg.Rows[rowIndex];

            row.Cells[$"{columnNameIndex}_{COLUMN_FECHA}"].Style.BackColor = Color.Black;

            if (row.Cells[$"{columnNameIndex}_{COLUMN_IDOT}"].Value == null || row.Cells[$"{columnNameIndex}_{COLUMN_IDOT}"].Value.ToString() == "")
                return;

            bool containsIM = false;
            
            if (row.Cells[$"{columnNameIndex}_{COLUMN_TIPOSERVICIO}"].Value != null)
                containsIM = row.Cells[$"{columnNameIndex}_{COLUMN_TIPOSERVICIO}"].Value.ToString().Contains("IM -");

            if (containsIM)
            {
                row.Cells[$"{columnNameIndex}_{COLUMN_IDOT}"].Style.BackColor = Color.PaleGoldenrod;
                row.Cells[$"{columnNameIndex}_{COLUMN_BLBOOKING}"].Style.BackColor = Color.PaleGoldenrod;
                row.Cells[$"{columnNameIndex}_{COLUMN_CONTENEDOR}"].Style.BackColor = Color.PaleGoldenrod;
                row.Cells[$"{columnNameIndex}_{COLUMN_ITEM}"].Style.BackColor = Color.PaleGoldenrod;
                row.Cells[$"{columnNameIndex}_{COLUMN_NROOTMASCARA}"].Style.BackColor = Color.PaleGoldenrod;
                row.Cells[$"{columnNameIndex}_{COLUMN_RAZONSOCIAL}"].Style.BackColor = Color.PaleGoldenrod;
                row.Cells[$"{columnNameIndex}_{COLUMN_POSICIONAMIENTOFECHA}"].Style.BackColor = Color.PaleGoldenrod;
                row.Cells[$"{columnNameIndex}_{COLUMN_RUTA}"].Style.BackColor = Color.PaleGoldenrod;
                row.Cells[$"{columnNameIndex}_{COLUMN_TIPOSERVICIO}"].Style.BackColor = Color.PaleGoldenrod;
                row.Cells[$"{columnNameIndex}_{COLUMN_RETIROHORA}"].Style.BackColor = Color.PaleGoldenrod;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
          RefreshDataGridView();
        }

        private void dg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}