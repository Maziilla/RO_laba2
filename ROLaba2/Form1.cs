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
        DataSet Data;        
        public string ToStr(double[] n)
        {
            string temp = n[0].ToString();
            for (int i = 1; i < n.Length; i++)
                temp += " " + n[i].ToString();
            return temp;
        }
        public double[] toArr(DataTable table)
        {
            double[] temp = new double[4];
            for(int i=0;i<4;i++)
            {
                temp[i] = (double)table.Rows[0].ItemArray[i+1];
            }
            return temp;
        }
        public void add_animal(DataTable table, double a1, double a2, double a3, double a4, string a5)
        {
            table.Rows.Add(a5, a1, a2, a3, a4);
        }
        public double Evkl_dist(DataRow row, double[] row1)
        {
            return Math.Sqrt(Math.Pow((double)row.ItemArray[1] - row1[0], 2) + Math.Pow((double)row.ItemArray[2] - row1[1], 2) + Math.Pow((double)row.ItemArray[3] -
                row1[2], 2) + Math.Pow((double)row.ItemArray[4] - row1[3], 2));
        }
    public double Evkl_dist(DataRow row, DataRow row1)
        {
            return Math.Sqrt(Math.Pow((double)row.ItemArray[1] - (double)row1.ItemArray[1], 2) + Math.Pow((double)row.ItemArray[2] - (double)row1.ItemArray[2], 2) +
                Math.Pow((double)row.ItemArray[3] - (double)row1.ItemArray[3], 2) + Math.Pow((double)row.ItemArray[4] - (double)row1.ItemArray[4], 2));
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

        public double[] all_dist(double[] row, DataTable tabl)
        {
            List<double> res=new List<double>();
            foreach(DataRow t_row in tabl.Rows)
            {
                res.Add(Math.Sqrt(Math.Pow((double)t_row.ItemArray[1] - row[0], 2) + Math.Pow((double)t_row.ItemArray[2] - row[1], 2) + Math.Pow((double)t_row.ItemArray[3] -
                row[2], 2) + Math.Pow((double)t_row.ItemArray[4] - row[3], 2)));
            }
            return res.ToArray();            
        }
      
        public double[] min(double[] row1, double[] row2)
        {
            double[] temp=new double [row1.Length];
            for(int i=0;i<row1.Length;i++)
            {
                if (row1[i] < row2[i])
                    temp[i] = row1[i];
                else
                    temp[i] = row2[i];
            }
            return temp;
        }
        public double min(double row1, double row2)
        {           
            if (row1 < row2)
                return row1;
            else
                return row2;           
        }
        public int Max(double[] row)
        {
            int max = 0;
            double max_val = row[0];
            for(int i=1;i<row.Length;i++)
            {
                if(row[i]>max_val)
                {
                    max = i;
                    max_val = row[i];
                }
            }
            return max;
        }
        //table.Rows.Add(nUD_pol.Value, nUD_hight.Value, nUD_long.Value);
        public Form1()
        {
            InitializeComponent();
            Animals = new DataSet("Animals");
            //Простой выбор---------------------------------------------------------------------------------------------
            double T = 2.55;
            // double T = 0.0001;

            DataRow temp_row = null;
            StreamReader textReader = new StreamReader("D:\\Универ\\РО\\RO_lab2\\dataset.txt");
            string sLine = "";
            string[] split;
            double[] znach = new double[4];

            //textReader.ReadLine();
            //sLine = textReader.ReadLine();
            //split = sLine.Split('\t');
            //for (int i=0;i<znach.Length;i++)
            //{
            //    znach[i] = Convert.ToDouble(split[i]);
            //}

            //Animals.Tables.Add("1");
            //add_col(Animals.Tables[0]);
            //add_animal(Animals.Tables[0], Convert.ToDouble(split[0]), Convert.ToDouble(split[1]), Convert.ToDouble(split[2]), Convert.ToDouble(split[3]), split[4]);

            //while ((sLine = textReader.ReadLine())  != null)
            //{               

            //    split = sLine.Split('\t');
            //    for (int i = 0; i < znach.Length; i++)
            //    {
            //        znach[i] = Convert.ToDouble(split[i]);
            //    }
            //    int j = 0;
            //    int add_to_tabl=-1;
            //    double temp_dist=0, min_dist=999;  

            //    while(j<Animals.Tables.Count)
            //    {
            //        temp_dist = Evkl_dist(Animals.Tables[j].Rows[0], znach);

            //        if (temp_dist < T)
            //        {
            //            if (j == 0)
            //            {
            //                min_dist = temp_dist;
            //                add_to_tabl = 0;
            //            }
            //            else
            //                if (temp_dist < min_dist)
            //            {
            //                min_dist = temp_dist;
            //                add_to_tabl = j;
            //            }
            //        }
            //        j++;
            //    }
            //    if(add_to_tabl==-1)
            //    {
            //        Animals.Tables.Add((Animals.Tables.Count+1).ToString());
            //        add_col(Animals.Tables[Animals.Tables.Count-1]);
            //        add_animal(Animals.Tables[Animals.Tables.Count - 1], znach[0], znach[1], znach[2], znach[3], split[4]);
            //    }
            //    else
            //        add_animal(Animals.Tables[add_to_tabl], znach[0], znach[1], znach[2], znach[3], split[4]);

            //}
            //MessageBox.Show(Animals.Tables.Count.ToString());
            //foreach(DataTable  tabl in Animals.Tables)
            //{
            //    lb_data.Items.Add(tabl.TableName);
            //    foreach (DataRow row in tabl.Rows)
            //    {
            //        lb_data.Items.Add("\t" + row[0] + " \t" + row[1] + " \t" + row[2] + " \t" + row[3] + " \t" + row[4]);
            //    }
            //}
            //textReader.Close();
            //-----------------------------------------------------------------------------------------
            textReader = new StreamReader("D:\\Универ\\РО\\RO_lab2\\dataset.txt");
            sLine = "";
            Animals.Tables.Add("1");
            add_col(Animals.Tables[0]);
            textReader.ReadLine();
            while ((sLine = textReader.ReadLine()) != null)
            {
                split = sLine.Split('\t');
                for (int i = 0; i < znach.Length; i++)
                {
                    znach[i] = Convert.ToDouble(split[i]);
                }
                add_animal(Animals.Tables[0], znach[0], znach[1], znach[2], znach[3], split[4]);
            }
           
            textReader.Close();
            double max_dist = 0;
            int tek_m;
            double[] temp=null,center = new double[4];
            for (int i = 0; i < 4; i++)
                center[i] = (double)Animals.Tables[0].Rows[0].ItemArray[i+1];
            Data = new DataSet("Data");
            Data.Tables.Add("1");
            add_col(Data.Tables[0]);
            add_animal(Data.Tables[0], center[0], center[1],
                center[2], center[3], (string)Animals.Tables[0].Rows[0].ItemArray[0]);

            tek_m = Max(all_dist(center, Animals.Tables[0]));

            Data.Tables.Add((Data.Tables.Count + 1).ToString());
            add_col(Data.Tables[Data.Tables.Count.ToString()]);
            add_animal(Data.Tables[Data.Tables.Count - 1], (double)Animals.Tables[0].Rows[tek_m].ItemArray[1],
                (double)Animals.Tables[0].Rows[tek_m].ItemArray[2], (double)Animals.Tables[0].Rows[tek_m].ItemArray[3],
                (double)Animals.Tables[0].Rows[tek_m].ItemArray[4], (string)Animals.Tables[0].Rows[tek_m].ItemArray[0]);

            //int kol_centr = 1;
            double sum;
            double max_el;
            double[] min_rast=null;
            do
            {
                int max_index = 0;
                max_el = 0;
                double[] temp_rast=null;
                sum = 0;
                int delitel = 1;
                for (int i = 0; i < Data.Tables.Count; i++)
                {
                    for (int j = i + 1; j < Data.Tables.Count; j++)
                    {
                        delitel++;
                        sum += Evkl_dist(Data.Tables[i].Rows[0], Data.Tables[j].Rows[0]);
                    }
                    temp_rast = all_dist(toArr(Data.Tables[i]), Animals.Tables[0]);
                    if (i == 0)
                        min_rast = (double[])temp_rast.Clone();
                    else
                        min_rast = min(min_rast, temp_rast);
                }
                sum /= delitel;
                max_index = Max(min_rast);
                max_el = min_rast[max_index];
                if(max_el>sum/2)
                {
                    Data.Tables.Add((Data.Tables.Count + 1).ToString());
                    add_col(Data.Tables[Data.Tables.Count.ToString()]);
                    add_animal(Data.Tables[Data.Tables.Count - 1], (double)Animals.Tables[0].Rows[max_index].ItemArray[1],
                        (double)Animals.Tables[0].Rows[max_index].ItemArray[2], (double)Animals.Tables[0].Rows[max_index].ItemArray[3],
                        (double)Animals.Tables[0].Rows[max_index].ItemArray[4], (string)Animals.Tables[0].Rows[max_index].ItemArray[0]);
                }
            } while(/*среднее расстояние между центрами*/max_el > sum / 2);
            for (int i = 0; i < Animals.Tables[0].Rows.Count;i++)
            {
                double min_znach = Evkl_dist(Animals.Tables[0].Rows[i],Data.Tables[0].Rows[0]);
                int index_min=0;                  
                for(int j=1;j<Data.Tables.Count;j++)
                {
                    double new_rast = 0;
                    new_rast = Evkl_dist(Animals.Tables[0].Rows[i], Data.Tables[j].Rows[0]);
                    if(new_rast < min_znach)
                    {
                        min_znach = new_rast;
                        index_min = j;
                    }
                    
                }
                if (min_znach > 0.0)
                    add_animal(Data.Tables[index_min], (double)Animals.Tables[0].Rows[i].ItemArray[1],
                        (double)Animals.Tables[0].Rows[i].ItemArray[2], (double)Animals.Tables[0].Rows[i].ItemArray[3],
                        (double)Animals.Tables[0].Rows[i].ItemArray[4], (string)Animals.Tables[0].Rows[i].ItemArray[0]);

            }
            foreach (DataTable tabl in Data.Tables)
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
