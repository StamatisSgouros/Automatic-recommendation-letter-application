using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Texnologia_logismikou
{
    class Class2
    {              
        //φύλο μαθητή
        public static string f;

        //connection για φόρμα1
        public void login(TextBox textBox1,TextBox textBox2,Form1 this_form)
        {            
            //σύνδεση
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=db.mdb;Persist Security Info=False;";
            connection.Open();
            // αναζήτηση αν υπάρχει ο καθηγητής            
            string query = "SELECT * FROM professors WHERE id_prof ='" + textBox1.Text + "' AND password ='" + textBox2.Text + "'";
            OleDbCommand cmd = new OleDbCommand(query, connection);
            OleDbDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                // δίνω σαν όρισμα το id και το name               
                Form2 eisodos = new Form2(rdr.GetString(0), rdr.GetString(1));
                eisodos.Show();
                this_form.Visible = false;
            }
            else
            {
                MessageBox.Show("Λάθος στοιχεία!");
                textBox1.Text = "";
                //το ίδιο με το πάνω καθαρίζει το περιεχόμενο
                textBox2.Clear();
            }
            connection.Close();         
        }
        public void dtconnection(TextBox textBox1,string id_prof,Label label3,Label label12,Label label13, Label label14, Label label15, Label label16, Label label17 , Form2 form2)
        {
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=db.mdb;Persist Security Info=False;";
            connection.Open();

            // αναζήτηση μαθητή αν υπάρχει
            string query1 = "SELECT * FROM students WHERE am = '" + textBox1.Text + "'";
            OleDbCommand cmd1 = new OleDbCommand(query1, connection);
            OleDbDataReader rdr1 = cmd1.ExecuteReader();
            if (rdr1.Read())
            {
                //string query2 = "SELECT  cast(avg(grade) as decimal(4,2)) FROM professors natural join courses natural join grades natural join students WHERE professors.id_prof = '" + id_prof + "' and students.am = '" + textBox1.Text + "' and grade>4";

                // υπολογισμός μέσου όρου
                string query2 = "SELECT avg(grade) FROM professors,courses,grades,students where professors.id_prof = courses.id_prof and courses.id = grades.id and grades.am = students.am and professors.id_prof = '" + id_prof + "' and students.am = '" + textBox1.Text + "'and grade>4";
                OleDbCommand cmd2 = new OleDbCommand(query2, connection);
                OleDbDataReader rdr2 = cmd2.ExecuteReader();
                rdr2.Read();
                // έλεγχος αν ειναι το avg null
                if (rdr2.IsDBNull(0))
                {                    
                    form2.visibility1();
                    MessageBox.Show("Δεν έχει περασμένα μαθήματα ο μαθητής  " + rdr1.GetString(1));
                }
                else
                {
                    f = rdr1.GetString(5);                    
                    form2.visibility();
                    label12.Text = rdr1.GetString(0);
                    label13.Text = rdr1.GetString(1);
                    label14.Text = rdr1.GetString(2);
                    label15.Text = rdr1.GetString(3);
                    label16.Text = rdr1.GetInt32(4).ToString();
                    label3.Text = rdr2.GetDouble(0).ToString();
                    if (rdr2.GetDouble(0) >= 8.5)
                    {
                        label17.Text = "(Άριστος)";
                    }
                    else if (rdr2.GetDouble(0) >= 7.5)
                    {
                        label17.Text = "(Λίαν Καλώς)";
                    }
                    else
                    {
                        label17.Text = "(Καλός)";
                    }
                }
            }
            else
            {                
                form2.visibility1();
                MessageBox.Show("Λάθος A.M. μαθητή");
            }

            connection.Close();
            //για να σβηνεται οτι υπαρχει στο textbox
            textBox1.Text = "";
        }
    }
}
