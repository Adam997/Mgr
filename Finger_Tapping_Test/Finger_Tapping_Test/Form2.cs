using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace Finger_Tapping_Test
{
    public partial class Form2 : Form
    {
        SerialPort serialPort = new SerialPort("COM3");
        Queue<int> dataBuffor = new Queue<int>();
        byte[] data;
        double timer;


        public Form2()
        {
            InitializeComponent();
            serialPort.BaudRate = 9600;
            serialPort.ReadBufferSize = 16384;

            data = new byte[serialPort.ReadBufferSize];
            timer = 0;

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort.Open();

                if (serialPort.IsOpen)
                {
                    //timer1.Start(); to nie tutaj, tylko dopiero gdy bedzie pierwszy spadek napięcia i za chwilę kolejne
                    backgroundWorker1.RunWorkerAsync();

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Nie nawiązano połączenia, spróbuj ponownie...");
            }

        }

        public int count = 0;
        public string[,] voltage = new string[300, 4];
        public int counter = 0;
        public int row = 0;
        public int col = 0;
        public int colHelp = 0;
        public bool start = false;
        public bool startExamination = false;
        public int whichRow = 0;
        public bool flaga = false;

        //public int[,] arrayOfZero=null;
        public List<int> zeroRow = new List<int>();
        public List<int> zeroCol = new List<int>();

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                while (backgroundWorker1.IsBusy)
                {
                    count = serialPort.BytesToRead;

                    if (count != 0)
                    {
                        string POT = serialPort.ReadExisting();

                        // serialPort.Read(data, 0, count & (0x4000 - 1)); 

                        if (data.Length != 0)
                        {
                            //zapewnienie czytania danych, i pozbycie sie dodatkowych elementow
                            char[] separator = { '\n', '\t', '\r', /*'O',*/ ' ' };
                            string[] value = POT.Split(separator);
                            // usunięcie pustych elementów z tablicy
                            value = value.Where(x => !string.IsNullOrEmpty(x)).ToArray();

                            // tutaj if/else bo wiem ze jakieś dane są zaczytane
                            // należy pomyśleć jak rozwiązać problem kończenia ramek. nie zawsze wysyła od razu z wszystkich palcy, może skończyć na środkowym i
                            // w następnym dopiero przeslać pozostałe. Co z tym zrobić? Czy to rozwiązanie jest wystarczające?

                            for (int i = 0; i < value.Length; i = i + 5)
                            {
                                if (start == false && i < value.Length)
                                {
                                    while (value[i] != "n" && i < value.Length - 1)
                                    {
                                        i++;
                                    }
                                    i++;
                                    start = true;
                                }
                                if (start)
                                {
                                    //jeżeli nie ma informacji, że nie zdekodował całkowitej ramki, to poniższe
                                    if (colHelp == 0)
                                    {
                                        if (i + 5 /*+4*/ < value.Length)
                                        {
                                            if (value[i + 4] == "n")
                                            {
                                                voltage[row, col] = value[i];
                                                voltage[row, col + 1] = value[i + 1];
                                                voltage[row, col + 2] = value[i + 2];
                                                voltage[row, col + 3] = value[i + 3];
                                                row++;
                                                flaga = true;
                                            }

                                        }
                                        else
                                        {
                                            while (i < value.Length && col < 4)
                                            {
                                                if (value[i] != "n")
                                                {
                                                    voltage[row, col] = value[i];
                                                    i++;
                                                    col++;
                                                    colHelp = col;
                                                }
                                                else i++;
                                            }
                                        }
                                        col = 0;
                                    }
                                    else
                                    {
                                        col = colHelp;
                                        colHelp = 0;
                                        while (col < 4 && i < value.Length)
                                        {
                                            try
                                            {
                                                if (value[i] != "n")
                                                {
                                                    voltage[row, col] = value[i];
                                                    col++;
                                                    i++;
                                                }
                                                else i++;
                                            }
                                            catch (Exception ex)
                                            {
                                                MessageBox.Show(ex.ToString());
                                            }

                                        }
                                        col = 0;
                                    }
                                }
                                counter = row;
                                if (counter == 299)
                                {
                                    //tutaj poszukiwanie??
                                    counter = 0;
                                    row = 0;
                                    #region dziala ale probuje inaczej
                                    //    row = 0;
                                    //    int j = 0;
                                    //    int k = 0;
                                    //    #region przeszukiwanie if if if if if....
                                    //    //while (jRow < voltage.GetLength(0))
                                    //    //{
                                    //    //    if (int.Parse(voltage[jRow, 0]) == 0 && startExamination == false)
                                    //    //    {
                                    //    //        timer1.Start();
                                    //    //        startExamination = true;
                                    //    //        jRow++;
                                    //    //        #region przeszukiwanie if if if
                                    //    //        //while (jRow < voltage.GetLength(0))
                                    //    //        //{
                                    //    //        //    if (int.Parse(voltage[jRow, 1]) == 0 || int.Parse(voltage[jRow, 2]) == 0 || int.Parse(voltage[jRow, 3]) == 0)
                                    //    //        //    {
                                    //    //        //        if (int.Parse(voltage[jRow,1])==0)
                                    //    //        //        {
                                    //    //        //            jRow++;
                                    //    //        //            while (jRow<voltage.GetLength(0))
                                    //    //        //            {
                                    //    //        //                if (int.Parse(voltage[jRow, 2]) == 0 || int.Parse(voltage[jRow, 3]) == 0)
                                    //    //        //                {
                                    //    //        //                    if (int.Parse(voltage[jRow,2])==0)
                                    //    //        //                    {
                                    //    //        //                        jRow++;
                                    //    //        //                        //znowu while

                                    //    //        //                    }
                                    //    //        //                    else
                                    //    //        //                    {
                                    //    //        //                        MessageBox.Show("Niepoprawna kolejność wykonywania ćwiczenia!");
                                    //    //        //                        timer1.Stop();
                                    //    //        //                    }
                                    //    //        //                }

                                    //    //        //            }

                                    //    //        //        }
                                    //    //        //        else
                                    //    //        //        {
                                    //    //        //            MessageBox.Show("Niepoprawna kolejność wykonywania ćwiczenia!");
                                    //    //        //            timer1.Stop();
                                    //    //        //        }
                                    //    //        //    }
                                    //    //        //    else jRow++;
                                    //    //        //}
                                    //    //        #endregion
                                    //    //    }
                                    //    //    else jRow++;
                                    //    //}
                                    //    #endregion

                                    //    while (j < voltage.GetLength(0) - 1)
                                    //    {
                                    //        while (k < voltage.GetLength(1))
                                    //        {
                                    //            int a = Int32.Parse(voltage[j, k]);
                                    //            if (a == 0)
                                    //            {
                                    //                zeroCol.Add(k); 
                                    //                zeroRow.Add(j);
                                    //                // czy potrzebne są mi te listy?
                                    //                if (zeroCol[k]==0 && startExamination==false)
                                    //                {
                                    //                    startExamination = true;
                                    //                    timer1.Start();
                                    //                }
                                    //            }
                                    //            k++;
                                    //        }
                                    //        k = 0;
                                    //        j++;
                                    //    }
                                    //    Array.Clear(voltage, 0, 300 * 4);
                                    //}
                                    #endregion
                                    Array.Clear(voltage, 0, 300 * 4);
                                }

                                int k = 0;
                                if (flaga)
                                {
                                    whichRow++;
                                }
                                while (k < voltage.GetLength(1) && start && flaga)
                                {
                                    int a = Int32.Parse(voltage[whichRow - 1, k]);
                                    if (a == 0)
                                    {
                                        zeroCol.Add(k);
                                        zeroRow.Add(whichRow - 1);
                                        // czy potrzebne są mi te listy?
                                        if (zeroCol[k] == 0 && startExamination == false)
                                        {
                                            startExamination = true;
                                            timer1.Start();
                                        }
                                    }
                                    k++;
                                }
                                flaga = false;
                            }
                        }
                    }

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer = timer + 1;
        }

        Operation o = new Operation();

        private void btnTime_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            IEnumerable<int> liIDs = zeroCol.Distinct().ToList();

            List<int> list = o.DeleteRepeated(zeroCol);
            //tutaj sprawdzanie dopiero poprawności zadania
            string text = o.Validation(list);

            MessageBox.Show(text);
            #region if if if...
            //int wskazujacy = 0;
            //int srodkowy = 0;
            //int serdeczny = 0;
            //int maly = 0;
            //int last = 0;
            //int i = 0;
            //// to sie da zrobic operacjami bitowymi....
            //while (i < zeroCol.Count)
            //{
            //    if (zeroCol[i] == 0)
            //    {
            //        if (i + 1 < zeroCol.Count && zeroCol[i] == zeroCol[i + 1])
            //        {
            //            i++;
            //        }
            //        else
            //        {
            //            i++;
            //            if (zeroCol[i] == 1)
            //            {
            //                if (i + 1 < zeroCol.Count && zeroCol[i] == zeroCol[i + 1])
            //                {
            //                    i++;
            //                }
            //                else
            //                {
            //                    i++;
            //                    if (zeroCol[i] == 2)
            //                    {

            //                        if (i + 1 < zeroCol.Count && zeroCol[i] == zeroCol[i + 1])
            //                        {
            //                            i++;
            //                        }
            //                        else
            //                        {
            //                            i++;
            //                            if (zeroCol[i] == 3)
            //                            {
            //                                if (i + 1 < zeroCol.Count && zeroCol[i] == zeroCol[i + 1])
            //                                {
            //                                    i++;
            //                                }
            //                                else
            //                                {
            //                                    //tutaj znowu poszukiwanie czy jest to 2 czy nie itd.
            //                                }

            //                            }
            //                            else
            //                            {
            //                                MessageBox.Show("Niepoprawna kolejność ruchów");
            //                            }
            //                        }

            //                    }
            //                    else
            //                    {
            //                        MessageBox.Show("Niepoprawna kolejność ruchów");
            //                    }

            //                }
            //            }
            //            else
            //            {
            //                MessageBox.Show("Niepoprawna kolejność ruchów");
            //            }
            //        }
            //    }

            //}
            #endregion

        }
    }
}
