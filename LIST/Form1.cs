using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LIST
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        ClsList List = new ClsList();
        private void btnInsert_Click(object sender, EventArgs e)
        {
            btnInsert.Enabled = true;
            ClsNode objNodo = new ClsNode();
            objNodo.Code = int.Parse(txtCode.Text);
            objNodo.Name = txtName.Text;
            objNodo.Proccess = txtProcess.Text;
            List.Insert(objNodo);
            
            if (rdbAsc.Checked) 
            {
                List.ShowDgvAsc(dgvData);
                List.ShowList(lstList);
                List.ShowCboAsc(cbocode);
                List.ShowEx();
            }
            else
            {
                List.ShowDgvDesc(dgvData);
                List.ShowListDesc(lstList);
                List.ShowCboDesc(cbocode);
                List.ShowEx();

            }

            txtCode.Text = "";
            txtName.Text = "";
            txtProcess.Text = "";
            btnDelete.Enabled = true;
        }
       
        

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (List.FIRST != null)
            {
                Int32 x = Convert.ToInt32(cbocode.Text);
                List.Delete(x);

                List.ShowDgvAsc(dgvData);
                List.ShowList(lstList);
                List.ShowCboAsc(cbocode);
                List.ShowEx();
            }
            else
            {
                MessageBox.Show("The list is empty");

            }
            btnDelete.Enabled = false;
        }

       
    }
}


