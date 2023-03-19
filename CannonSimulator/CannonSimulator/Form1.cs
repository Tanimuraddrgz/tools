using System.Windows.Forms;

namespace CannonSimulator
{
    public partial class Form1 : Form
    {
        public sealed class CanonInfo
        {
            public string range { get; set; }
            public string angleOfFire6Power { get; set; }
            public string angleOfFire5Power { get; set; }
            public string angleOfFire4Power { get; set; }
            public string angleOfFire3Power { get; set; }
            public string angleOfFire2Power { get; set; }
            public string angleOfFire1Power { get; set; }
            public string angleOfFire0Power { get; set; }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("cannon - data.csv")) //ファイルがないときのエラー回避
            {
                List<CanonInfo> canonGrid = new List<CanonInfo>();
                List<string> ranges = new List<string>();
                StreamReader sr = new StreamReader(@"cannon - data.csv");
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    var row = line.Split(',');
                    // CSVの内容を項目ごとにUserInfoDtoに格納する
                    CanonInfo cI = new CanonInfo();
                    cI.range = row[0];
                    ranges.Add(row[0]);
                    cI.angleOfFire6Power = row[1];
                    cI.angleOfFire5Power = row[2];
                    cI.angleOfFire4Power = row[3];
                    cI.angleOfFire3Power = row[4];
                    cI.angleOfFire2Power = row[5];
                    cI.angleOfFire1Power = row[6];
                    cI.angleOfFire0Power = row[7];
                    canonGrid.Add(cI);

                }
                dataGridView1.DataSource = canonGrid;
                dataGridView1.Columns[0].HeaderText = "距離/射角";
                dataGridView1.Columns[1].HeaderText = "6";
                dataGridView1.Columns[2].HeaderText = "5";
                dataGridView1.Columns[3].HeaderText = "4";
                dataGridView1.Columns[4].HeaderText = "3";
                dataGridView1.Columns[5].HeaderText = "2";
                dataGridView1.Columns[6].HeaderText = "1";
                dataGridView1.Columns[7].HeaderText = "0";
                dataGridView1.AutoResizeColumns();


                dataGridView1.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
                //comboBox1.DataSource = ranges;

            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.TopMost = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}