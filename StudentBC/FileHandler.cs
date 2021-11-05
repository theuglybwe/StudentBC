using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace StudentBC
{
    class FileHandler
    {
        //Write
        public void Write(List<string> formatedData)
        {
            try
            {
                File.WriteAllLines("DCdetails.txt", formatedData);
                MessageBox.Show("User has been added successfully");
                Form1 d1 = new Form1();
            }
            catch(Exception ex)
            {
                MessageBox.Show("USer was not created because"+ex);
            }
            
        }

        //Read
        public List<string> Read()
        {
            List<string> data = new List<string>();

            data = File.ReadAllLines("DCdetails.txt").ToList();

            return data;
        }
        
    }
}
