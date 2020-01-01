using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Turco;
using System.Data.Common;

namespace FreeConnWFA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DataSet ds = new DataSet();
            using (NsConnection nsConn = new NsConnection(NsConnectionTypes.SqlServer, "Data Source=BDYUSER3\\SQLEXPRESS;Initial Catalog=InCareTest;User Id=sa; Password=123123;"))
            {
                nsConn.Open();
                using (DbCommand dbCmd = nsConn.CreateCommand())
                {
                    dbCmd.CommandText = "Select * From OrderSchedules Where ScheduleStatus=@status;";
                    dbCmd.CommandType = CommandType.Text;
                    DbParameter dbParam = dbCmd.CreateParameter();
                    dbParam.ParameterName = "@status";
                    dbParam.Value = 1;
                    dbCmd.Parameters.Add(dbParam);
                    DbDataAdapter dataAdapter = nsConn.GetDataAdapter();
                    dataAdapter.SelectCommand = dbCmd;
                    dataAdapter.Fill(ds);
                }
                nsConn.Close();
            }
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
