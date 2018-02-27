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
        public double[] toArr(DataRow row)
        {
            double[] temp = new double[4];
            for (int i = 0; i < 4; i++)
            {
                temp[i] = (double)row.ItemArray[i + 1];
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
                Math.Pow((double)row.ItemArray[3] - (double)row1.ItemArray[3], 2) + Math.Pow((double)row.ItemArray[4] - (double)row1.ItemArray[3], 2));
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
        public void Fill_DatSet()
        {
            for (int i = 0; i < Animals.Tables[0].Rows.Count; i++)
            {
                double min_znach = Evkl_dist(Animals.Tables[0].Rows[i], Data.Tables[0].Rows[0]);
                int index_min = 0;
                for (int j = 1; j < Data.Tables.Count; j++)
                {
                    double new_rast = 0;
                    new_rast = Evkl_dist(Animals.Tables[0].Rows[i], Data.Tables[j].Rows[0]);
                    if (new_rast < min_znach)
                    {
                        min_znach = new_rast;
                        index_min = j;
                    }                    
                }
                add_animal(Data.Tables[index_min], (double)Animals.Tables[0].Rows[i].ItemArray[1],
                        (double)Animals.Tables[0].Rows[i].ItemArray[2], (double)Animals.Tables[0].Rows[i].ItemArray[3],
                        (double)Animals.Tables[0].Rows[i].ItemArray[4], (string)Animals.Tables[0].Rows[i].ItemArray[0]);

            }
        }
        public void tabl_mid_cent(DataTable tabl)
        {
            double[] temp = new double[4];
            for (int i = 0; i < 4; i++)
                temp[i] = 0;
            foreach(DataRow row in tabl.Rows)
            {
                for (int i = 0; i < 4; i++)
                    temp[i] += (double) row.ItemArray[i + 1];
            }
            for (int i = 0; i < 4; i++)
                temp[i] /= tabl.Rows.Count;
            tabl.Rows.Clear();
            add_animal(tabl, temp[0], temp[1], temp[2], temp[3], "");
        }
        public bool exit(double[,] mas)
        {
            bool res = true;
            for(int i = 0;i< Data.Tables.Count && res;i++)
            {
                for(int j=0;j<4 && res;j++)
                {
                    res = mas[i, j] == (double)Data.Tables[i].Rows[0].ItemArray[j + 1];
                }
            }
            return res;
        }
        public void Print_DataSet(DataSet datset)
        {
            foreach (DataTable tabl in datset.Tables)
            {
                lb_data.Items.Add(tabl.TableName);
                foreach (DataRow row in tabl.Rows)
                {
                    lb_data.Items.Add("\t" + row[0] + " \t" + row[1] + " \t" + row[2] + " \t" + row[3] + " \t" + row[4]);
                }
            }
        }
        //table.Rows.Add(nUD_pol.Value, nUD_hight.Value, nUD_long.Value);
        public Form1()
        {
            InitializeComponent();
            gb_K.Enabled = false;
            cb_chus.SelectedIndex = 0;
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_chus.SelectedIndex == 2)
                gb_K.Enabled = true;
            else
                gb_K.Enabled = false;
        }

        private void bt_go_Click(object sender, EventArgs e)
        {
            lb_data.Items.Clear();
            Animals = new DataSet("Animals");

            StreamReader textReader = new StreamReader("C:\\Users\\Mazilaa\\Downloads\\dataset.txt");
            string sLine = "";
            string[] split;
            double[] znach = new double[4];

            if (cb_chus.SelectedIndex == 0)
            {
                //Простой выбор---------------------------------------------------------------------------------------------
                double T = 2.55;
                // double T = 0.0001;

                DataRow temp_row = null;



                textReader.ReadLine();
                sLine = textReader.ReadLine();
                split = sLine.Split('\t');
                for (int i = 0; i < znach.Length; i++)
                {
                    znach[i] = Convert.ToDouble(split[i]);
                }

                Animals.Tables.Add("1");
                add_col(Animals.Tables[0]);
                add_animal(Animals.Tables[0], Convert.ToDouble(split[0]), Convert.ToDouble(split[1]), Convert.ToDouble(split[2]), Convert.ToDouble(split[3]), split[4]);

                while ((sLine = textReader.ReadLine()) != null)
                {

                    split = sLine.Split('\t');
                    for (int i = 0; i < znach.Length; i++)
                    {
                        znach[i] = Convert.ToDouble(split[i]);
                    }
                    int j = 0;
                    int add_to_tabl = -1;
                    double temp_dist = 0, min_dist = 999;

                    while (j < Animals.Tables.Count)
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
                    if (add_to_tabl == -1)
                    {
                        Animals.Tables.Add((Animals.Tables.Count + 1).ToString());
                        add_col(Animals.Tables[Animals.Tables.Count - 1]);
                        add_animal(Animals.Tables[Animals.Tables.Count - 1], znach[0], znach[1], znach[2], znach[3], split[4]);
                    }
                    else
                        add_animal(Animals.Tables[add_to_tabl], znach[0], znach[1], znach[2], znach[3], split[4]);

                }
                MessageBox.Show(Animals.Tables.Count.ToString());
                Print_DataSet(Animals);
                textReader.Close();
                //-----------------------------------------------------------------------------------------
            }
            //-----------------------------максмин-----------------------------------------------------
            else
                if (cb_chus.SelectedIndex == 1)
            {
                Animals.Clear();
                textReader = new StreamReader("C:\\Users\\Mazilaa\\Downloads\\dataset.txt");
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
                double[] temp = null, center = new double[4];
                for (int i = 0; i < 4; i++)
                    center[i] = (double)Animals.Tables[0].Rows[0].ItemArray[i + 1];
                Data = new DataSet("Data");
                Data.Tables.Clear();
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
                double[] min_rast = null;
                do
                {
                    int max_index = 0;
                    max_el = 0;
                    double[] temp_rast = null;
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
                    if (max_el > sum / 2)
                    {
                        Data.Tables.Add((Data.Tables.Count + 1).ToString());
                        add_col(Data.Tables[Data.Tables.Count.ToString()]);
                        add_animal(Data.Tables[Data.Tables.Count - 1], (double)Animals.Tables[0].Rows[max_index].ItemArray[1],
                            (double)Animals.Tables[0].Rows[max_index].ItemArray[2], (double)Animals.Tables[0].Rows[max_index].ItemArray[3],
                            (double)Animals.Tables[0].Rows[max_index].ItemArray[4], (string)Animals.Tables[0].Rows[max_index].ItemArray[0]);
                    }
                } while (/*среднее расстояние между центрами*/max_el > sum / 2);

                Fill_DatSet();
                Print_DataSet(Data);
            }
            //-----------------------------------------------------------------------------------------------------------------
            else
            {
                Animals.Tables.Clear();

                textReader = new StreamReader("C:\\Users\\Mazilaa\\Downloads\\dataset.txt");
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
                Data = new DataSet("Data");
                for (int i = 0; i < (int)nUD_k.Value; i++)
                {
                    Data.Tables.Add((i + 1).ToString());
                    add_col(Data.Tables[Data.Tables.Count - 1]);
                    add_animal(Data.Tables[Data.Tables.Count - 1], (double)Animals.Tables[0].Rows[i].ItemArray[1],
                    (double)Animals.Tables[0].Rows[i].ItemArray[2], (double)Animals.Tables[0].Rows[i].ItemArray[3],
                    (double)Animals.Tables[0].Rows[i].ItemArray[4], (string)Animals.Tables[0].Rows[i].ItemArray[0]);
                }
                Fill_DatSet();
                double[,] old_centers = new double[(int)nUD_k.Value, 4];
                int counter = 0;
                do
                {
                    counter = 0;
                    foreach (DataTable tabl in Data.Tables)
                    {
                        for (int i = 0; i < 4; i++)
                            old_centers[counter, i] = (double)tabl.Rows[0].ItemArray[i + 1];
                        tabl_mid_cent(tabl);
                        counter++;
                    }
                    Fill_DatSet();
                } while (exit(old_centers));
                Print_DataSet(Data);
            }
        }
    }
}
