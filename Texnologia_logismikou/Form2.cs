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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Net.Mail;

namespace Texnologia_logismikou
{
    public partial class Form2 : Form
    {
        public static string name_prof;
        public static string id_prof;               
        private int i = 0;
        private Boolean flagexit=true;
        //flag για το mai1l αν υπάρχει
        private Boolean flag = true;    
       
        //δημιουργώ αντικείμενα για τις 2 δικές μου κλάσεις
        Class1 create_pdf = new Class1();
        Class2 connection = new Class2();
        
        public Form2(string username_prof , string name)
        {
            InitializeComponent();
            id_prof = username_prof;
            name_prof = name;            
            label4.Text = label4.Text + name_prof;
            // για να βάλουμε δικό μας τίτλο πάνω δεξιά στην φόρμα κατά την εκτέλεση
            this.Text = "Σύστημα Αυτόματης Δημιουργίας Συστατικών Επιστολών";
        }        

        //κώδικας για την αναζήτηση μαθητή και προβολή του μέσου όρου του αν υπάρχει
        private void button1_Click(object sender, EventArgs e)
        {            
            connection.dtconnection(textBox1, id_prof, label3, label12, label13, label14, label15, label16, label17,this);            
        }

        // koumpi epistrofis
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // kodikas pou xrisimopoihte an klisoume thn forma eite me to X eite me to koumpi piso
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (flagexit == true) 
                {
                    Application.Exit();

                }
                
        }
        //για να εμφανίζονται τα textbox,button
        public void visibility()
        {
            label3.Visible=true;
            label5.Visible=true;
            label7.Visible=true;
            label8.Visible=true;
            label9.Visible=true;
            label10.Visible=true;
            label11.Visible=true;
            label12.Visible=true;
            label13.Visible=true;
            label14.Visible = true;                
            label15.Visible=true;
            label16.Visible = true ;
            button3.Visible = true;
            visibility2();
        }
        //για απόκρυψη textbox,button
        public  void visibility1()
        {
            label3.Visible = false;
            label5.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = false; 
            label15.Visible = false;
            label16.Visible = false;
            button3.Visible = false;
            visibility2();
        }
        //κοινή συνάρτηση για της δύο πάνω συναρτήσεις
        public void visibility2()
        {
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            label6.Visible = false;
            label18.Visible = false;
            pictureBox2.Visible = false;
        }
        //για την δημιουργία pdf
        private void button3_Click(object sender, EventArgs e)
        {
           
            try
            {              
                if (Class2.f=="Γ")
                {
                    //καλεί class1 create_pdf.cs
                    create_pdf.g(label14.Text , label13.Text , float.Parse(label3.Text) , name_prof);
                }
                else
                {
                    //καλεί class1 create_pdf.cs
                    create_pdf.a(label14.Text, label13.Text, float.Parse(label3.Text), name_prof);
                }                
                button3.Visible = false;
                button4.Visible = true;
                button5.Visible = true;
            }
            //σε περίπτωση που έχει σταλεί το pdf
            catch (Exception)
            {
                MessageBox.Show("Η συστατική επιστολή έχει ήδη δημιουργήθει και σταλθεί!!");
            }
        }

        //άνοιγμα του αρχείου pdf που έχω ορίσει
        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(label13.Text + "_" + name_prof +".pdf");
        }
        //το κουμπί που ανοίγει το textbox για να γράψει το gmail του ο καθηγητής
        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = true;
            label6.Visible = true;
            label18.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            button6.Visible = true;
            button5.Visible = false;
        }

        //όταν πατηθεί το κουμπί αποστολή για να σταλθεί το gmail που έχω το pdf 
   
        private void button6_Click(object sender, EventArgs e)
        {
            //για να αλλάζει ο cursor σύμβολο μέχρι να σταλθεί το mail
            Cursor.Current = Cursors.WaitCursor;
            textBox2.Visible = false;
            textBox3.Visible = false;
            label6.Visible = false;
            label18.Visible = false;
            button6.Visible = false;
            label19.Visible = true;
            progressBar1.Visible = true;           
            try
            {
                flag = true;
                MailMessage mail = new MailMessage();                
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");                
                mail.From = new MailAddress(textBox2.Text);
                mail.To.Add(label15.Text);
                mail.Subject = "Συστατική Επιστολή";
                mail.Body = "Σας επισυνάπτω την συστατική σας επιστολή.";

                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(label13.Text + "_" + name_prof + ".pdf");
                mail.Attachments.Add(attachment);                

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(textBox2.Text, textBox3.Text);
                SmtpServer.EnableSsl = true;
                //μηδενίζω την progressBar και καλώ τον timer για 5sec μέχρι να σταλθεί το mail
                progressBar1.Value = 0;
                timer1.Enabled = true;
                SmtpServer.Send(mail);  
                textBox2.Clear();
                textBox3.Clear();
            }          
            catch (Exception)
            {
                flag = false;
                MessageBox.Show("Λάθος Στοιχεία!Παρακαλώ ξαναπροσπαθήστε!");
                Cursor.Current = Cursors.Default;
                progressBar1.Visible = false;
                label19.Visible = false;
                textBox2.Clear();
                textBox3.Clear();
                pictureBox2.Visible = true;
                label6.Visible = true;
                label18.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                button6.Visible = true;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (flag)
            {
                if (i < 5)
                {
                    progressBar1.Value = progressBar1.Value + 20;
                    i++;
                }
                else
                {
                    Cursor.Current = Cursors.Default;
                    i = 0;
                    timer1.Enabled = false;
                    MessageBox.Show("Το e-mail στάλθηκε επιτυχώς!!");
                    progressBar1.Value = 0;
                    progressBar1.Visible = false;
                    label19.Visible = false;
                    pictureBox2.Visible = false;
                }
            }
            else
            {
                timer1.Enabled = false;
            }
        }
        //για exit από το μενού
        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
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
            MessageBox.Show("Γράψτε τον αριθμό μητρώου του φοιτητη βεβαιωθείτε οτι τα στοιχεια ειναι σωστα και δημιουργήστε συστατική επιστολή.Εαν επιθυμείτε πιέστε το κουμπί για άνοιγμα του PDF και αποστολή με e-mail.");
        }
        //για επιστροφή στην αρχική φόρμα
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            flagexit = false;
            this.Close();
            Form1 epistrofi = new Form1();
            epistrofi.Show();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            flagexit = false;
            this.Close();
            Form1 epistrofi = new Form1();
            epistrofi.Show();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
          
        }
    }
}