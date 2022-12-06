using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaultLocator
{
    public partial class Form2 : Form
    {
        private readonly IHeuristic _heuristic;

        public Form2()
        {
            InitializeComponent();

            List<Input> inputList = new List<Input>();

            string[] lines = File.ReadAllLines(FilePath.filepath);

            foreach (string line in lines)
            {
                string[] col = line.Split(',');
                Input input = new Input();
                input.line = col[0];
                input.passed = Convert.ToInt32(col[1]);
                input.failed = Convert.ToInt32(col[2]);
                inputList.Add(input);
            }
            int i = 1;
            foreach (var input in inputList)
            {
                input.score = CalculateHeuristic(input);
            }

            List<Input> sortedList = inputList.OrderBy(x => x.score).Reverse().ToList();

            foreach (var input in sortedList)
            {
                input.rank = i++;
            }

            //foreach (var item in sortedList)
            //{
            //    richTextBox1.AppendText(item.line.ToString() + "\n");
            //}

            DataTable dt = new DataTable();
            dt.Columns.Add("Rank", typeof(int));
            dt.Columns.Add("Line", typeof(string));
            dt.Columns.Add("Score", typeof(double));

            foreach (var input in sortedList)
            {
                dt.Rows.Add(input.rank, input.line, input.score);
            }
            //dt.Rows.Add(inputList);
            //dt.Rows.Add(new object[] { "Book B", DateTime.Parse("1/2/2016"), "Author B" });

            dataGridView1.DataSource = dt;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            var form1 = new Form1();
            form1.Show();
            this.Hide();
        }
        public double CalculateHeuristic(Input input)
        {
            if (input.passed < 3)
            {
                return input.failed - input.passed;
            }
            else if (input.passed > 2 && input.passed < 11)
            {
                return input.failed - 2 + (input.passed - 2) * 0.1;
            }
            else
            {
                return input.failed - 2.8 + (input.passed - 10) * 0.01;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //List<Input> inputList = new List<Input>();

            //string[] lines = File.ReadAllLines(FilePath.filepath);

            //foreach (string line in lines)
            //{
            //    string[] col = line.Split(',');
            //    Input input = new Input();
            //    input.line = col[0];
            //    input.passed = Convert.ToInt32(col[1]);
            //    input.failed = Convert.ToInt32(col[2]);
            //    inputList.Add(input);
            //}
            //int i = 1;
            //foreach (var input in inputList)
            //{
            //    input.score = CalculateHeuristic(input);
            //}

            //List<Input> sortedList = inputList.OrderBy(x => x.score).Reverse().ToList();

            //foreach (var input in sortedList)
            //{
            //    input.rank = i++;
            //}

            ////foreach (var item in sortedList)
            ////{
            ////    richTextBox1.AppendText(item.line.ToString() + "\n");
            ////}

            //DataTable dt = new DataTable();
            //dt.Columns.Add("Rank", typeof(int));
            //dt.Columns.Add("Line", typeof(string));
            //dt.Columns.Add("Score", typeof(double));

            //foreach (var input in sortedList)
            //{
            //    dt.Rows.Add(input.rank,input.line,input.score);
            //}
            ////dt.Rows.Add(inputList);
            ////dt.Rows.Add(new object[] { "Book B", DateTime.Parse("1/2/2016"), "Author B" });

            //dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //List<Input> inputList = new List<Input>();

            //string[] lines = File.ReadAllLines(FilePath.filepath);

            //foreach (string line in lines)
            //{
            //    string[] col = line.Split(',');
            //    Input input = new Input();
            //    input.line = col[0];
            //    input.passed = Convert.ToInt32(col[1]);
            //    input.failed = Convert.ToInt32(col[2]);
            //    inputList.Add(input);
            //}
            //int i = 1;
            //foreach (var input in inputList)
            //{
            //    input.score = CalculateHeuristic(input);
            //}

            //List<Input> sortedList = inputList.OrderBy(x => x.score).Reverse().ToList();

            //foreach (var input in sortedList)
            //{
            //    input.rank = i++;
            //}

            ////foreach (var item in sortedList)
            ////{
            ////    richTextBox1.AppendText(item.line.ToString() + "\n");
            ////}

            //DataTable dt = new DataTable();
            //dt.Columns.Add("Rank", typeof(int));
            //dt.Columns.Add("Line", typeof(string));
            //dt.Columns.Add("Score", typeof(double));

            //foreach (var input in sortedList)
            //{
            //    dt.Rows.Add(input.rank, input.line, input.score);
            //}
            ////dt.Rows.Add(inputList);
            ////dt.Rows.Add(new object[] { "Book B", DateTime.Parse("1/2/2016"), "Author B" });

            //dataGridView1.DataSource = dt;
        }
    }
}
