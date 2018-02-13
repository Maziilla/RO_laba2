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

namespace ROLaba2
{
    public partial class Form1 : Form
    {
        public void Chouse()
        {
            

        }
        DataSet Animals;
        
        public void add_animal(DataTable table, double a1, double a2, double a3, double a4,string a5)
        {
            table.Rows.Add(a5,a1, a2, a3, a4);
        }
        public double Evkl_dist(DataRow row, double[] row1)
        {
            return Math.Sqrt(Math.Pow((double)row.ItemArray[1] - row1[0], 2) + Math.Pow((double)row.ItemArray[2] - row1[1], 2) + Math.Pow((double)row.ItemArray[3] -
                row1[2], 2) + Math.Pow((double)row.ItemArray[4] - row1[3], 2));
        }
        public void add_col(DataTable table)
        {
             DataColumn col_bee =
                table.Columns.Add("name", typeof(string));
            table.Columns.Add("sepal length", typeof(double));
            table.Columns.Add("sepal width", typeof(double));
            table.Columns.Add("petal length", typeof(double));
            table.Columns.Add("petal width", typeof(double));
        }
      
        //table.Rows.Add(nUD_pol.Value, nUD_hight.Value, nUD_long.Value);
        public Form1()
        {
            InitializeComponent();
            Animals = new DataSet("Animals");
            double T = 2.55;
           // double T = 0.0001;

            DataRow temp_row =null;
            StreamReader textReader = new StreamReader("C:\\Users\\Mazilaa\\Downloads\\dataset.txt");
            string sLine = "";
            string[] split;
            double[] znach = new double[4];

            textReader.ReadLine();
            sLine = textReader.ReadLine();
            split = sLine.Split('\t');
            for (int i=0;i<znach.Length;i++)
            {
                znach[i] = Convert.ToDouble(split[i]);
            }

            Animals.Tables.Add("1");
            add_col(Animals.Tables[0]);
            add_animal(Animals.Tables[0], Convert.ToDouble(split[0]), Convert.ToDouble(split[1]), Convert.ToDouble(split[2]), Convert.ToDouble(split[3]), split[4]);
            
            while ((sLine = textReader.ReadLine())  != null)
            {               
                 
                split = sLine.Split('\t');
                for (int i = 0; i < znach.Length; i++)
                {
                    znach[i] = Convert.ToDouble(split[i]);
                }
                int j = 0;
                int add_to_tabl=-1;
                double temp_dist=0, min_dist=999;  
                              
                while(j<Animals.Tables.Count)
                {
                    temp_dist = Evkl_dist(Animals.Tables[j].Rows[0], znach);
                    
                    if (temp_dist < T)
                    {
                        if (j == 0)
                        {
                            min_dist = temp_dist;
                            add_to_tabl = 0;
                        }
                        else
                            if (temp_dist < min_dist)
                        {
                            min_dist = temp_dist;
                            add_to_tabl = j;
                        }
                    }
                    j++;
                }
                if(add_to_tabl==-1)
                {
                    Animals.Tables.Add((Animals.Tables.Count+1).ToString());
                    add_col(Animals.Tables[Animals.Tables.Count-1]);
                    add_animal(Animals.Tables[Animals.Tables.Count - 1], znach[0], znach[1], znach[2], znach[3], split[4]);
                }
                else
                    add_animal(Animals.Tables[add_to_tabl], znach[0], znach[1], znach[2], znach[3], split[4]);

            }
            MessageBox.Show(Animals.Tables.Count.ToString());
            foreach(DataTable  tabl in Animals.Tables)
            {
                lb_data.Items.Add(tabl.TableName);
                foreach (DataRow row in tabl.Rows)
                {
                    lb_data.Items.Add("\t" + row[0] + " \t" + row[1] + " \t" + row[2] + " \t" + row[3] + " \t" + row[4]);
                }
            }
        }

        
    }
}
