using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LIST
{
    internal class ClsList
    {

        private ClsNode first;
        private ClsNode last;

        public ClsNode FIRST
        {
            get { return first; }
            set { first = value; }
        }

        public ClsNode LAST
        {
            get { return last; }
            set { last = value; }
        }

        public void Insert(ClsNode New)
        {
            if (FIRST == null)
            {
                FIRST = New;
                LAST = New;

            }
            else
            {
                if (New.Code > LAST.Code)
                {
                    LAST.NEXT = New;
                    New.previous = LAST;
                    LAST = New;
                }
                else
                {
                    ClsNode next = FIRST;
                    ClsNode prev = FIRST;
                    while (next.Code < New.Code)
                    {
                        prev = next;
                         next=next.NEXT;
                    }
                    prev.NEXT = New;
                    New.NEXT = next;
                    next.previous = New;
                    New.previous = prev;
                }
            }

        }
        public void Delete(Int32 CODE)
        {
            if (FIRST.Code == CODE && LAST == FIRST)
            {
                FIRST = null; LAST = FIRST;
                LAST = null; LAST = FIRST;
            }
            else
            {
                if (FIRST.Code == CODE)
                {
                    FIRST = FIRST.NEXT;
                    FIRST.previous = null;
                }
                else
                {
                    if (LAST.Code == CODE)
                    {
                        LAST = LAST.previous;
                        LAST.NEXT = null;
                    }
                    else
                    {
                        ClsNode aux = FIRST;
                        ClsNode prev = FIRST;
                        while (aux.Code < CODE)
                        {
                            prev = aux;
                            aux = aux.NEXT;
                        }
                        prev.NEXT = aux.NEXT;
                        aux = aux.NEXT;
                        aux.previous = prev;
                    }
                }
            }

        }
        public void ShowList(ListBox Lista) //listbox
        {

            ClsNode aux = FIRST;
            Lista.Items.Clear();
            while (aux != null)
            {
                Lista.Items.Add(aux.Code);
                aux = aux.NEXT;
            }

        }
        public void ShowListDesc(ListBox Lista) //  desc listbox 
        {
            ClsNode aux = LAST;
            Lista.Items.Clear();
            while (aux != null)
            {
                Lista.Items.Add(aux.Code);
                aux = aux.previous;
            }
        }
        public void ShowCboAsc(ComboBox combo) //cbo ascd
        {

            ClsNode aux = FIRST;
            combo.Items.Clear();
            while (aux != null)
            {
                combo.Items.Add(aux.Code);
                aux = aux.NEXT;
            }

        }
        public void ShowCboDesc(ComboBox combo)    //cbo  desc
        {
            ClsNode aux = LAST;
            combo.Items.Clear();
            while (aux != null)
            {
                combo.Items.Add(aux.Code);
                aux = aux.previous;
            }
        }
        public void ShowDgvAsc(DataGridView DGV) //dgv asc
        {

            ClsNode aux = FIRST;
            DGV.Rows.Clear();

            while (aux != null)
            {
                DGV.Rows.Add(aux.Code, aux.Name, aux.Proccess);
                aux = aux.NEXT;
            }

        }
        public void ShowDgvDesc(DataGridView DGV) //dgv desc
        {

            ClsNode aux = LAST;
            DGV.Rows.Clear();

            while (aux != null)
            {
                DGV.Rows.Add(aux.Code, aux.Name, aux.Proccess);
                aux = aux.previous;
            }

        }
        public void ShowEx() // export excel 
        {

            ClsNode aux = FIRST;
            StreamWriter AD = new StreamWriter("LIST.csv", false, Encoding.UTF8);
            AD.WriteLine("Waiting list \n");
            AD.WriteLine("Code;Name;Process");
            while (aux != null)
            {
                AD.Write(aux.Code);
                AD.Write(";");
                AD.Write(aux.Name);
                AD.Write(";");
                AD.WriteLine(aux.Proccess);
                aux = aux.NEXT;

            }
            AD.Close();


        }
    }
}
