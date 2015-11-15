using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Perceptron
{
    public class Perceptron
    {
        public enum NeuronType { Binary, Bipolar };
        static int NeuroActive(NeuronType nt)
        {
            switch (nt)
            {
                case NeuronType.Binary:
                    return 1;
                case NeuronType.Bipolar:
                    return 1;
                default:
                    return 0;
            }
        }

        static int NeuroPassive(NeuronType nt)
        {
            switch (nt)
            {
                case NeuronType.Binary:
                    return 0;
                case NeuronType.Bipolar:
                    return -1;
                default:
                    return 0;
            }
        }

        public delegate void Log(string msg);
        public static DataGridView SAweights;
        public static DataGridView ARweights;
        public static DataGridView Steps;

        // Пара: изображение - вектор ожидаемый на выходе
        public struct PairSet
        {
            // "Изображение"
            public int[] image;
            // Ожидаемый выход
            public int t;
        }

        public Perceptron(int sensorNeurons, int associativeNeurons, int reactionNeurons)
        {
            this.sensor = sensorNeurons;
            this.associative = associativeNeurons;
            this.reaction = reactionNeurons;
            // Создаем слои нейронной сети
            // Сенсорное поле (принимает входное изображение). Используем бинарные нейроны
            //S = new int[sensor];
            
            
        }

        void InitNetwork(List<PairSet> images)
        {
            // Веса связей сенсоров и ассоциативных нейронов. 
            SA_W = new double[sensor, associative];
            // Пороги срабатывания каждого нейрона в скрытом слое
            thetaA = new double[associative];
            // Веса связей слоя ассоциативных нейронов и слоя реагирующих нейронов
            AR_W = new double[associative];
            // Порог/пороги срабатывания нейронов выходного слоя.
            thetaR = 0;
            // Заполняем веса связей случ. числами [0; 1)
            Random rnd = new Random(DateTime.Now.Millisecond);
            log("====================[Инициализация перцептрона]=======================" + Environment.NewLine);
            log("Генерируем веса связей [S->A]..." + Environment.NewLine);
            for (int s = 0; s < sensor; ++s) 
            {
                log("S[" + s + "]" + Environment.NewLine);
                // Заполняем все связи S_i входных нейронов со всеми A_j нейронами скрытого слоя
                for (int a = 0; a < associative; ++a)
                {
                    SA_W[s, a] = rnd.NextDouble();
                    log("A[" + a + "]=" + SA_W[s, a] + "   ");
                }
                log(Environment.NewLine);
            }
            log("=======================================================================" + Environment.NewLine);
            log("Определяем пороги срабатывания каждого из нейронов скрытого слоя..." + Environment.NewLine);
            List<List<double>> allSum = new List<List<double>>();
            for (int img = 0; img < images.Count; ++img)
            {
                allSum.Add(FeedAssocLayer(images[img].image));
            }

            for (int a = 0; a < associative; ++a) 
            {
                double sumAi = 0;
                double minAi = allSum[0][a];
                double maxAi = allSum[0][a];
                for (int img = 0; img < images.Count; ++img)
                {
                    if (maxAi < allSum[img][a]) maxAi = allSum[img][a];
                    if (minAi > allSum[img][a]) minAi = allSum[img][a];
                    sumAi += allSum[img][a];
                }
                // Выбираем в качестве порога отношение взвешенных сумм Ai нейрона к общему количеству изображений
                thetaA[a] = sumAi / images.Count;
                log("Порог активации A[" + a + "] нейрона в скрытом слое: thetaA[" + a + "]=" + thetaA[a] + Environment.NewLine);    
            }
            log("=======================================================================" + Environment.NewLine);
            log("Генерируем веса связей [A->R]..." + Environment.NewLine);
            // Заполняем все связи R_i нейрона со всеми ассоциаторами
            for (int j = 0; j < associative; ++j)
            {
                AR_W[j] = rnd.NextDouble();
                log("AR[" + j + "]=" + AR_W[j] + "    ");
            }
            log(Environment.NewLine);
            // Рассчет порога выходного нейрона

            List<double> Ri = new List<double>();
            for (int img = 0; img < images.Count; ++img)
            {
                double sumR = 0;
                List<double> sumAi = FeedAssocLayer(images[img].image);
                for (int a = 0; a < associative; ++a)
                    sumR += AR_W[a] * ActivateFunc(sumAi[a], thetaA[a], NeuronType.Bipolar);
                Ri.Add(sumR);
            }
            double minRi = Ri.Min();
            double maxRi = Ri.Max();
            thetaR = Ri.Sum() / images.Count;
            log(string.Format("min={0}, max={1}, Пороговое значение активации выходных нейронов R -> theta={2}", minRi, maxRi, thetaR) + Environment.NewLine);
            // Show weights
            Show_SA_Weights();
            Show_AR_Weights();
            // Скармливаем сети все переданные изображения
            ////////////////////////////////////////////////////////////////////
            log("============================================================" + Environment.NewLine);            
            log("Проверка [A->R]..." + Environment.NewLine);
            for (int img = 0; img < images.Count; ++img)
            {
                log("Изображение #" + img + ": " + Environment.NewLine);
                List<double> sumAi = FeedAssocLayer(images[img].image);
                double sumR = 0;
                for (int a = 0; a < associative; ++a)
                {
                    log("A[" + a + "]=" + sumAi[a] + ", "
                        + (ActivateFunc(sumAi[a], thetaA[a], NeuronType.Bipolar) == NeuroActive(NeuronType.Bipolar) ? "active" : "passive")
                        + Environment.NewLine);
                    sumR += AR_W[a] * ActivateFunc(sumAi[a], thetaA[a], NeuronType.Bipolar);
                }
                log("R=" + sumR + Environment.NewLine);
            }
            ////////////////////////////////////////////////////////////////////
            // 
            ////////////////////////////////////////////////////////////////////
            Steps.RowCount = 1;
            log("==================[Инициализация завершена]=================" + Environment.NewLine);
        }
        // Функция активации
        int ActivateFunc(double sum, double threshold, NeuronType neuronType)
        {
            return (sum >= threshold ? NeuroActive(neuronType) : NeuroPassive(neuronType));
        }
        // Обучение
        public void Learn(List<PairSet> images, bool AlphaLearning = true)
        {
            for (int img = 0; img < images.Count; ++img)
                if (images[img].image.Length != sensor) throw new Exception("Image len != sensor len");
            /// Инициализация сети.
            InitNetwork(images);
            // Процесс обучения
            // 
            if (AlphaLearning)
            {
                log("==================[Запуск процесса обучения с альфа подкреплением]=================" + Environment.NewLine);
                // Маркер завершения обучения
                bool processComplete = false;
                // Шаг обучения
                double step = 0.01;
                // Количество итераций
                int iteration = 0;
                // Запуск процесса
                while (!processComplete)
                {
                    iteration++;
                    // Считаем по умолчанию процесс обучения завершенным
                    processComplete = true;
                    // Обрабатываем каждое изображение из обучающей выборки
                    for (int img = 0; img < images.Count; ++img)
                    {
                        log("Изображение #" + img + Environment.NewLine);
                        double sumR = 0;
                        List<int> activeAR = new List<int>();
                        List<double> sumAi = FeedAssocLayer(images[img].image);
                        for (int a = 0; a < associative; ++a)
                        {
                            double w = AR_W[a] * ActivateFunc(sumAi[a], thetaA[a], NeuronType.Bipolar);
                            sumR += w;
                            if (ActivateFunc(sumAi[a], thetaA[a], NeuronType.Bipolar) == NeuroActive(NeuronType.Bipolar))
                            {
                                log("A[" + a + "]=" + sumAi[a] + ", active" + Environment.NewLine);
                                activeAR.Add(a);
                            }
                            else
                            {
                                log("A[" + a + "]=" + sumAi[a] + ", passive" + Environment.NewLine);
                            }
                        }
                        // Получаем результат активации выходного слоя
                        int Rreact = ActivateFunc(sumR, thetaR, NeuronType.Bipolar);
                        log("Порог активации нейрона выходного слоя, thetaR=" + thetaR + Environment.NewLine);
                        log("R=" + sumR + ", " + (ActivateFunc(sumR, thetaR, NeuronType.Bipolar) == NeuroActive(NeuronType.Bipolar) ? "active" : "passive") + Environment.NewLine);
                        log("AR веса связей: " + string.Join(" ", AR_W) + Environment.NewLine);
                        log("Ожидаемая реакция: " + images[img].t + ", Полученная реация: " + Rreact + Environment.NewLine);
                        // Реакция не совпадает с ожидаемой
                        if (Rreact != images[img].t)
                        {
                            // Корректировка активных связей
                            for (int active = 0; active < activeAR.Count; ++active)
                                AR_W[activeAR[active]] -= step * Rreact;
                            // Обучение не завершено
                            processComplete = false;
                        }
                        
                    }
                    log("===========================================================" + Environment.NewLine);            
                    //MessageBox.Show("next?");
                    Application.DoEvents();
                }
                log("[Шаг обучения]=" + step + Environment.NewLine);
                log("=========[Обучение завершено, количество итераций=" + iteration + "]==========" + Environment.NewLine);
            }
            else
            {
            }
            

        }


        List<double> FeedAssocLayer(int[] S)
        {
            if (S.Length != sensor) throw new Exception("Image len != sensor len");

            List<double> assocOutputs = new List<double>();

            for (int a = 0; a < associative; ++a) 
            {
                double sumAi = 0;
                // Скармливаем все входные данные последовательно каждому нейрону скрытого слоя
                for (int si = 0; si < sensor; ++si) 
                {
                    sumAi += SA_W[si, a] * S[si];
                }
                // Запоминаем сумму для Ai нейрона
                assocOutputs.Add(sumAi);
            }

            return assocOutputs;
        }


        void Show_SA_Weights()
        {
            SAweights.RowCount = associative;
            SAweights.ColumnCount = sensor;
            //SAweights.Size = new System.Drawing.Size(sensor * SAweights.Columns[0].Width + 50, associative * SAweights.Rows[0].Height + 40);

            foreach (DataGridViewColumn column in SAweights.Columns)
            {
                column.HeaderText = "S" + column.Index;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            SAweights.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            foreach (DataGridViewRow row in SAweights.Rows)
            {

                row.HeaderCell.Value = "A" + row.Index;// String.Format("A{0}", row.Index + 1);
            }


            for (int i = 0; i < associative; ++i)
            {
                SAweights.Rows[i].HeaderCell.Value = "A" + i;
                for (int j = 0; j < sensor; ++j)
                {
                    SAweights.Rows[i].Cells[j].Value = SA_W[j, i];
                }
            }

        }

        void Show_AR_Weights()
        {
            ARweights.RowCount = reaction;
            ARweights.ColumnCount = associative;
            //SAweights.Size = new System.Drawing.Size(sensor * SAweights.Columns[0].Width + 50, associative * SAweights.Rows[0].Height + 40);

            foreach (DataGridViewColumn column in ARweights.Columns)
            {
                column.HeaderText = "A" + column.Index;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            ARweights.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            foreach (DataGridViewRow row in ARweights.Rows)
            {

                row.HeaderCell.Value = "R" + row.Index;// String.Format("A{0}", row.Index + 1);
            }


            ARweights.Rows[0].HeaderCell.Value = "R0";
            for (int j = 0; j < associative; ++j)
            {
                ARweights.Rows[0].Cells[j].Value = AR_W[j];
            }
        }

        public int Recognize(int[] image)
        {
            List<double> sumAi = FeedAssocLayer(image);
            double sumR = 0;
            for (int a = 0; a < associative; ++a)
            {
                sumR += AR_W[a] * ActivateFunc(sumAi[a], thetaA[a], NeuronType.Bipolar);

            }

            return ActivateFunc(sumR, thetaR, NeuronType.Bipolar);
        }

        public double [, ] AssocWeights() 
        {
            return SA_W;
        }

        public double [] ReactWeights()
        {
            return AR_W;
        }

        public static Log log;

        int sensor, associative, reaction;
        // Сенсорные нейроны
        //int[] S;
        // Веса связей между сенсорными и ассоциативными нейронами
        double[,] SA_W;
        // Пороги срабатывания нейронов скрытого слоя
        double[] thetaA;
        // Веся связей между ассоциативными и реагирующими нейронами
        double[] AR_W;
        // Реагирующие нейроны
        // Пороги срабатывания нейронов выходного слоя
        double thetaR;
    }
}
