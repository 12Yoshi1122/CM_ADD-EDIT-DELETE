using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsForms_Calling_Method
{
    public partial class Form1 : Form
    {
        static string conString = "Server = localhost; database = db_cm; username = root; password = #Pass1122";
        MySqlConnection con = new MySqlConnection(conString);
        MySqlCommand cmd;

        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            comboBox1.Items.Add("MATH");
            comboBox1.Items.Add("SCIENCE");
            comboBox1.Items.Add("ENGLISH");
            label12.Visible = false;
            label13.Visible = false;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            insert();
            reset();
            reload();
            
        }

        private void insert()
        {

            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                double prelim;
                prelim = Convert.ToDouble(textBox5.Text);
                if (prelim < 50)
                {
                    DialogResult d;
                    d = MessageBox.Show("Grades input ranges from 50 to 100", "My Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (prelim > 100)
                {
                    DialogResult d;
                    d = MessageBox.Show("Grades input ranges from 50 to 100", "My Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                }

                double midterm;
                midterm = Convert.ToDouble(textBox6.Text);
                if (midterm < 50)
                {
                    DialogResult d;
                    d = MessageBox.Show("Grades input ranges from 50 to 100", "My Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (midterm > 100)
                {
                    DialogResult d;
                    d = MessageBox.Show("Grades input ranges from 50 to 100", "My Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                }


                double prefinals;
                prefinals = Convert.ToDouble(textBox7.Text);
                if (prefinals < 50)
                {
                    DialogResult d;
                    d = MessageBox.Show("Grades input ranges from 50 to 100", "My Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (prefinals > 100)
                {
                    DialogResult d;
                    d = MessageBox.Show("Grades input ranges from 50 to 100", "My Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                }

                double finals;
                finals = Convert.ToDouble(textBox8.Text);
                if (finals < 50)
                {
                    DialogResult d;
                    d = MessageBox.Show("Grades input ranges from 50 to 100", "My Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (finals > 100)
                {
                    DialogResult d;
                    d = MessageBox.Show("Grades input ranges from 50 to 100", "My Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                }

                double gwa;
                gwa = (prelim + midterm + prefinals + finals) / 4;
                string E = "EXCELLENT";
                string V = "VERY GOOD";
                string G = "GOOD";
                string S = "SATISFACTORY";
                string P = "PASS";
                string C = "CONDITIONAL";
                string F = "FAIL";
                

                
                label12.Text = gwa.ToString();

                if (gwa >= 99)
                {
                    label13.Text = E.ToString();
                }
                else if (gwa >= 96)
                {
                    label13.Text = V.ToString();
                }
                else if (gwa >= 93)
                {
                    label13.Text = V.ToString();
                }
                else if (gwa >= 90)
                { 
                    label13.Text = G.ToString();
                }
                else if (gwa >= 87)
                {
                    label13.Text = G.ToString();
                }
                else if (gwa >= 84)
                {
                    label13.Text = S.ToString();
                }
                else if (gwa >= 81)
                {
                    label13.Text = S.ToString();
                }
                else if (gwa >= 78)
                {
                    label13.Text = P.ToString();
                }
                else if (gwa >= 75)
                {
                    label13.Text = P.ToString();
                }
                else if (gwa <= 74)
                {
                    label13.Text = F.ToString();
                }
                else
                {

                }
                cmd = con.CreateCommand();
                cmd.CommandText = "Insert into tbl_cm set STUDENT_ID = '" + textBox1.Text + "', STUDENT_LNAME = '" + textBox2.Text + "', STUDENT_FNAME = '" + textBox3.Text + "', STUDENT_MNAME = '" + textBox4.Text + "', STUDENT_SUBJECT = '" + comboBox1.Text + "', " +
                    " PRELIM = '" + textBox5.Text + "', MIDTERM = '" + textBox6.Text + "', PRE_FINALS = '" + textBox7.Text + "', FINALS = '" + textBox8.Text + "', GWA = '" + label12.Text + "', REMARKS = '" + label13.Text + "'";

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("INSERTED", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }

            }
        }

        private void reset()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            comboBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            reload();
        }

        private void reload()
        {
            cmd = con.CreateCommand();
            cmd.CommandText = "select * from tbl_cm";
            try
            {
                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from tbl_cm", con);
                DataSet ds = new DataSet();
                da.Fill(ds, "tbl_cm");
                dataGridView1.DataSource = ds.Tables["tbl_cm"];
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            delete();
            reset();
            reload();
        }
        private void delete()
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                cmd = con.CreateCommand();
                cmd.CommandText = "delete from tbl_cm where STUDENT_ID = '" + textBox1.Text + "'";
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("DELETED", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            edit();
            reset();
            reload();
        }
        private void edit()
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                double prelim;
                prelim = Convert.ToDouble(textBox5.Text);
                if (prelim < 50)
                {
                    DialogResult d;
                    d = MessageBox.Show("Grades input ranges from 50 to 100", "My Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (prelim > 100)
                {
                    DialogResult d;
                    d = MessageBox.Show("Grades input ranges from 50 to 100", "My Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                }

                double midterm;
                midterm = Convert.ToDouble(textBox6.Text);
                if (midterm < 50)
                {
                    DialogResult d;
                    d = MessageBox.Show("Grades input ranges from 50 to 100", "My Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (midterm > 100)
                {
                    DialogResult d;
                    d = MessageBox.Show("Grades input ranges from 50 to 100", "My Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                }


                double prefinals;
                prefinals = Convert.ToDouble(textBox7.Text);
                if (prefinals < 50)
                {
                    DialogResult d;
                    d = MessageBox.Show("Grades input ranges from 50 to 100", "My Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (prefinals > 100)
                {
                    DialogResult d;
                    d = MessageBox.Show("Grades input ranges from 50 to 100", "My Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                }

                double finals;
                finals = Convert.ToDouble(textBox8.Text);
                if (finals < 50)
                {
                    DialogResult d;
                    d = MessageBox.Show("Grades input ranges from 50 to 100", "My Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (finals > 100)
                {
                    DialogResult d;
                    d = MessageBox.Show("Grades input ranges from 50 to 100", "My Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                }

                double gwa;
                gwa = (prelim + midterm + prefinals + finals) / 4;
                string E = "EXCELLENT";
                string V = "VERY GOOD";
                string G = "GOOD";
                string S = "SATISFACTORY";
                string P = "PASS";
                string C = "CONDITIONAL";
                string F = "FAIL";



                label12.Text = gwa.ToString();

                if (gwa >= 99)
                {
                    label13.Text = E.ToString();
                }
                else if (gwa >= 96)
                {
                    label13.Text = V.ToString();
                }
                else if (gwa >= 93)
                {
                    label13.Text = V.ToString();
                }
                else if (gwa >= 90)
                {
                    label13.Text = G.ToString();
                }
                else if (gwa >= 87)
                {
                    label13.Text = G.ToString();
                }
                else if (gwa >= 84)
                {
                    label13.Text = S.ToString();
                }
                else if (gwa >= 81)
                {
                    label13.Text = S.ToString();
                }
                else if (gwa >= 78)
                {
                    label13.Text = P.ToString();
                }
                else if (gwa >= 75)
                {
                    label13.Text = P.ToString();
                }
                else if (gwa <= 74)
                {
                    label13.Text = F.ToString();
                }
                else
                {

                }
                cmd = con.CreateCommand();
                cmd.CommandText = "update tbl_cm set STUDENT_LNAME = '" + textBox2.Text + "', STUDENT_FNAME = '" + textBox3.Text + "', STUDENT_MNAME = '" + textBox4.Text + "', STUDENT_SUBJECT = '" + comboBox1.Text + "', " +
                    " PRELIM = '" + textBox5.Text + "', MIDTERM = '" + textBox6.Text + "', PRE_FINALS = '" + textBox7.Text + "', FINALS = '" + textBox8.Text + "', GWA = '" + label12.Text + "', REMARKS = '" + label13.Text + "' where STUDENT_ID='" + textBox1.Text + "'";

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("EDITED", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }

            }
        }
    }
}
