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
    
    public partial class Form1 : Form
    {
        //δημιουργώ αντικείμενα για τις 2 δικές μου κλάσεις
        Class2 connection = new Class2();
        public Form1()
        {
            InitializeComponent();
            this.Text = "Log In";
        }
        private void button1_Click(object sender, EventArgs e)
        {          
            //χρησιμοποιώ την κλάση connection για να κάνει ο χρήστης login
            connection.login(textBox1 , textBox2,this); 
        }
        // kodikas pou xrisimopoihte an klisoume thn forma me to X 
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        //για exit από το μενού
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //για restart από το μενού
        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
        //για help από το μενού
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Εισάγεται το όνομα χρήστη και τον κωδικό σας για είσοδο στην εφαρμογή!");
        }
    }
}
