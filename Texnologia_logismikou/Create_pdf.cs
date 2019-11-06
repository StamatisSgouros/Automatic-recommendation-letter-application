using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Windows.Forms;

namespace Texnologia_logismikou
{
    class Class1
    {       

        //δημιουργεία pdf για άνδρα
        public void a(string surname,string name,float mo,string name_prof)
        {           
            //σύνδεση
            Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(name + "_" + name_prof + ".pdf", FileMode.Create));
            doc.Open();
            //ορισμός ελληνικών , γραμματοσειράς αριαλ και μέγεθος γραμματων
            string ARIALUNI_TFF = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIALUNI.TTF");
            BaseFont bf = BaseFont.CreateFont(ARIALUNI_TFF, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font titleFont = new iTextSharp.text.Font(bf, 32);
            iTextSharp.text.Font paragraphFont = new iTextSharp.text.Font(bf, 14);

            iTextSharp.text.Image img1 = iTextSharp.text.Image.GetInstance("fonto_blue.jpg");
            iTextSharp.text.Image img2 = iTextSharp.text.Image.GetInstance("sima.jpg");
            //μέγεθος εικόνας
            img1.ScaleAbsolute(600, 850);
            img2.ScaleAbsolute(80, 80);
            //θέση εικόνας , στο ύψος ξεκινάει το 1 από το τέλος της σελίδας και όσο ανεβαίνουμε μεγαλώνει
            img1.SetAbsolutePosition(1, 1);
            img2.SetAbsolutePosition(255, 610);
            Paragraph t1 = new Paragraph("Συστατική Επιστολή \n\n\n\n\n", titleFont);
            t1.Alignment = Element.ALIGN_CENTER;
            Paragraph p1 = new Paragraph("ΠΑΝΕΠΙΣΤΗΜΙΟ ΠΕΙΡΑΙΩΣ\n\n", paragraphFont);
            Paragraph p2 = new Paragraph("Εμπιστευτικό\n\n", paragraphFont);
            Paragraph p3 = new Paragraph("Συστατική επιστολή για " + surname + " " + name + "\n\n", paragraphFont);
            Paragraph p4 = new Paragraph(" ");
            Paragraph p5 = new Paragraph(" ");
            if (mo >= 8.5)
            {
                p4 = new Paragraph("Ο " + surname + " " + name + " είναι άριστος φοιτητής. Είναι ικανός να συλλαμβάνει γρήγορα νέες έννοιες και να εφαρμόζει αυτή τη γνώση στην πρακτική. Επιπλέον, εργάζεται καλά τόσο ανεξάρτητα όσο και με άλλους.\n\n", paragraphFont);
                p5 = new Paragraph("Θεωρώ ότι είναι ένας πολύ ώριμος φοιτητής, έχει κίνητρα, εργάζεται σκληρά και έχει σαφείς στόχους.Προσαρμόζεται καλά σε νέες καταστάσεις και είναι αγαπητός μεταξύ των συμφοιτητών του.\n\n", paragraphFont);
            }
            else if (mo >= 7.5)
            {
                p4 = new Paragraph("Ο " + surname + " " + name + " είναι λίαν καλώς φοιτητής. Είναι ικανός να συλλαμβάνει νέες έννοιες και να εφαρμόζει αυτή τη γνώση στην πρακτική. Επιπλέον, εργάζεται καλά τόσο ανεξάρτητα όσο και με άλλους.\n\n", paragraphFont);
                p5 = new Paragraph("Θεωρώ ότι είναι ένας πολύ ώριμος φοιτητής, έχει κίνητρα, εργάζεται σκληρά και έχει σαφείς στόχους.\n\n", paragraphFont);
            }
            else
            {
                p4 = new Paragraph("Ο " + surname + " " + name + " είναι καλός φοιτητής. Είναι ικανός να συλλαμβάνει νέες έννοιες. Επιπλέον, εργάζεται καλά τόσο ανεξάρτητα όσο και με άλλους.\n\n", paragraphFont);
                p5 = new Paragraph("Θεωρώ ότι εργάζεται σκληρά και έχει σαφείς στόχους.\n\n", paragraphFont);
            }
            Paragraph p6 = new Paragraph("Ο " + surname + " " + name + " συνίσταται ανεπιφύλακτα για μεταπτυχιακές σπουδές στο πανεπιστήμιό σας και ελπίζω η αίτησή του να είναι επιτυχής.\n\n", paragraphFont);
            Paragraph p7 = new Paragraph("Υπογραφή\n\n", paragraphFont);
            Paragraph p8 = new Paragraph(name_prof + "\n\n", paragraphFont);
            Paragraph p9 = new Paragraph("Καθηγητής Τμήματος Πληροφορικής", paragraphFont);
            doc.Add(t1);
            doc.Add(p1);
            doc.Add(p2);
            doc.Add(p3);
            doc.Add(p4);
            doc.Add(p5);
            doc.Add(p6);
            doc.Add(p7);
            doc.Add(p8);
            doc.Add(p9);
            doc.Add(img1);
            doc.Add(img2);
            doc.Close();
            MessageBox.Show("Η συστατική επιστολή δημιουργήθηκε!!");
        }
        public void g(string surname, string name, float mo, string name_prof)
        {
            //σύνδεση
            Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(name + "_" + name_prof + ".pdf", FileMode.Create));
            doc.Open();
            //ορισμός ελληνικών , γραμματοσειράς αριαλ και μέγεθος γραμματων
            string ARIALUNI_TFF = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIALUNI.TTF");
            BaseFont bf = BaseFont.CreateFont(ARIALUNI_TFF, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font titleFont = new iTextSharp.text.Font(bf, 32);
            iTextSharp.text.Font paragraphFont = new iTextSharp.text.Font(bf, 14);

            iTextSharp.text.Image img1 = iTextSharp.text.Image.GetInstance("fonto_blue.jpg");
            iTextSharp.text.Image img2 = iTextSharp.text.Image.GetInstance("sima.jpg");
            //μέγεθος εικόνας
            img1.ScaleAbsolute(600, 850);
            img2.ScaleAbsolute(80, 80);
            //θέση εικόνας , στο ύψος ξεκινάει το 1 από το τέλος της σελίδας και όσο ανεβαίνουμε μεγαλώνει
            img1.SetAbsolutePosition(1, 1);
            img2.SetAbsolutePosition(255, 610);
            Paragraph t1 = new Paragraph("Συστατική Επιστολή \n\n\n\n\n", titleFont);
            t1.Alignment = Element.ALIGN_CENTER;
            Paragraph p1 = new Paragraph("ΠΑΝΕΠΙΣΤΗΜΙΟ ΠΕΙΡΑΙΩΣ\n\n", paragraphFont);
            Paragraph p2 = new Paragraph("Εμπιστευτικό\n\n", paragraphFont);
            Paragraph p3 = new Paragraph("Συστατική επιστολή για " + surname + " " + name + "\n\n", paragraphFont);
            Paragraph p4 = new Paragraph(" ");
            Paragraph p5 = new Paragraph(" ");
            if (mo >= 8.5)
            {
                p4 = new Paragraph("Η " + surname + " " + name + " είναι άριστη φοιτήτρια. Είναι ικανή να συλλαμβάνει γρήγορα νέες έννοιες και να εφαρμόζει αυτή τη γνώση στην πρακτική. Επιπλέον, εργάζεται καλά τόσο ανεξάρτητα όσο και με άλλους.\n\n", paragraphFont);
                p5 = new Paragraph("Θεωρώ ότι είναι μία πολύ ώριμη φοιτήτρια, έχει κίνητρα, εργάζεται σκληρά και έχει σαφείς στόχους.Προσαρμόζεται καλά σε νέες καταστάσεις και είναι αγαπητή μεταξύ των συμφοιτητών της.\n\n", paragraphFont);
            }
            else if (mo >= 7.5)
            {
                p4 = new Paragraph("Η " + surname + " " + name + " είναι λίαν καλή φοιτήτρια. Είναι ικανή να συλλαμβάνει νέες έννοιες και να εφαρμόζει αυτή τη γνώση στην πρακτική. Επιπλέον, εργάζεται καλά τόσο ανεξάρτητα όσο και με άλλους.\n\n", paragraphFont);
                p5 = new Paragraph("Θεωρώ ότι είναι μία πολύ ώριμη φοιτήτρια, έχει κίνητρα, εργάζεται σκληρά και έχει σαφείς στόχους.\n\n", paragraphFont);
            }
            else
            {
                p4 = new Paragraph("Η " + surname + " " + name + " είναι καλή φοιτήτρια. Είναι ικανή να συλλαμβάνει νέες έννοιες. Επιπλέον, εργάζεται καλά τόσο ανεξάρτητα όσο και με άλλους.\n\n", paragraphFont);
                p5 = new Paragraph("Θεωρώ ότι εργάζεται σκληρά και έχει σαφείς στόχους.\n\n", paragraphFont);
            }
            Paragraph p6 = new Paragraph("Η " + surname + " " + name + " συνίσταται ανεπιφύλακτα  για μεταπτυχιακές σπουδές στο πανεπιστήμιό σας και ελπίζω η αίτησή της να είναι επιτυχής.\n\n", paragraphFont);
            Paragraph p7 = new Paragraph("Υπογραφή\n\n", paragraphFont);
            Paragraph p8 = new Paragraph(name_prof + "\n\n", paragraphFont);
            Paragraph p9 = new Paragraph("Καθηγητής Τμήματος Πληροφορικής", paragraphFont);
            doc.Add(t1);
            doc.Add(p1);
            doc.Add(p2);
            doc.Add(p3);
            doc.Add(p4);
            doc.Add(p5);
            doc.Add(p6);
            doc.Add(p7);
            doc.Add(p8);
            doc.Add(p9);
            doc.Add(img1);
            doc.Add(img2);
            doc.Close();
            MessageBox.Show("Η συστατική επιστολή δημιουργήθηκε!!");
        }
    }
}
