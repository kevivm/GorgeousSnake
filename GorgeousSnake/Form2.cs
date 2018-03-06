using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GorgeousSnake
{
    public partial class Form2 : Form
    {
        public Form2()
        {
           
            InitializeComponent();
            dataGridView1.RowCount = 1;
            dataGridView1.ColumnCount = 3;
            dataGridView1.ReadOnly = true;
            // dataGridView1.Rows.Add("Name", "Score", "Level");
            dataGridView1.Columns[0].HeaderText = "Name";
            dataGridView1.Columns[1].HeaderText = "Score";
            dataGridView1.Columns[2].HeaderText = "Level";

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        public void SetlblStat(string name, string score, string level)
        {
            if(Convert.ToInt32(score) > 0)
            {
                dataGridView1.Rows.Add(name, score, level);
            }
            dataGridView1.Sort(dataGridView1.Columns[2],ListSortDirection.Descending);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
