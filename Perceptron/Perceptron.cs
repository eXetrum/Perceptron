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
                //thetaA[a] = sumAi / new Random(DateTime.Now.Millisecond).Next(sensor);
                //thetaA[a] = temp.Max() /  / temp.Count;
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
            //thetaR = (minRi + maxRi) / 2.0;
            //thetaR = Ri.Max();
            log(string.Format("min={0}, max={1}, Пороговое значение активации выходных нейронов R -> theta={2}", minRi, maxRi, thetaR) + Environment.NewLine);
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
            /// 
init:
            InitNetwork(images);
            // Процесс обучения
            // 
            log("==================[Запуск процесса обучения с " + (AlphaLearning ? "альфа" : "гамма" ) + " подкреплением]=================" + Environment.NewLine);
            // Маркер завершения обучения
            bool processComplete = false;
            // Шаг обучения
            double step = 0.01;
            // Количество итераций
            int iteration = 0;
            int maxIterCount = 500;

            List<int> imgActiveConnections = new List<int>();

            for (int img = 0; img < images.Count; ++img)
            {
                imgActiveConnections.Add(0);
                List<double> sumAi = FeedAssocLayer(images[img].image);

                for (int a = 0; a < associative; ++a)
                {
                    if (ActivateFunc(sumAi[a], thetaA[a], NeuronType.Bipolar) == NeuroActive(NeuronType.Bipolar))
                    {
                        imgActiveConnections[img]++;
                    }
                }
            }
            // Рассчитываем приращение для активных и пассивных весов
            List<double> dwActive = new List<double>();
            List<double> dwPassive = new List<double>();
            int N = images.Count;
            for (int img = 0; img < N; ++img)
            {
                dwActive.Add(N * ( - (imgActiveConnections[img] * step) / associative));
                dwPassive.Add(N * ( - (imgActiveConnections[img] * step) / associative));
            }             
            // Запуск процесса
            while (!processComplete)
            {
                iteration++;
                if (iteration >= maxIterCount)
                {
                    MessageBox.Show("Достигнут предел количества итераций...Перезапуск");
                    goto init;
                }
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
                            //log("A[" + a + "]=" + sumAi[a] + ", active" + Environment.NewLine);
                            activeAR.Add(a);
                        }
                        else
                        {
                            //log("A[" + a + "]=" + sumAi[a] + ", passive" + Environment.NewLine);
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
                        // Корректировка - альфа подкрепления
                        if (AlphaLearning)
                        {
                            // Корректировка активных связей
                            for (int active = 0; active < activeAR.Count; ++active)
                                AR_W[activeAR[active]] -= step * Rreact;
                        }
                        // Корректировка - гамма подкрепления
                        else
                        {
                            double totalRsum = 0;
                            for (int _img = 0; _img < images.Count; ++_img)
                            {
                                List<double> Ai = FeedAssocLayer(images[_img].image);
                                for (int a = 0; a < associative; ++a)
                                    totalRsum += AR_W[a] * ActivateFunc(Ai[a], thetaA[a], NeuronType.Bipolar);
                            }
                            log("Общая сумма на R=" + totalRsum + Environment.NewLine);

                            

                            double wMin = NeuroPassive(NeuronType.Bipolar);
                            double wMax = NeuroActive(NeuronType.Bipolar);



                            for (int a = 0; a < associative; ++a)
                            {
                                // Активная связь
                                if (activeAR.Contains(a))
                                {
                                    AR_W[a] += dwActive[img] * Rreact;
                                }
                                else
                                {
                                    AR_W[a] -= dwPassive[img] * Rreact;
                                }                               
                            }
                            //MessageBox.Show("next?");
                        }
                        // Обучение не завершено
                        processComplete = false;
                    }
                        
                }
                log("===========================================================" + Environment.NewLine);            
                Application.DoEvents();
            }
            log("[Шаг обучения]=" + step + Environment.NewLine);
            log("=========[Обучение завершено, количество итераций=" + iteration + "]==========" + Environment.NewLine);
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

        public int Recognize(int[] image)
        {
            List<double> sumAi = FeedAssocLayer(image);
            double sumR = 0;
            for (int a = 0; a < associative; ++a)
            {
                sumR += AR_W[a] * ActivateFunc(sumAi[a], thetaA[a], NeuronType.Bipolar);

            }
            log("Sum R=" + sumR + Environment.NewLine);
            log("Порог активации нейрона выходного слоя, thetaR=" + thetaR + Environment.NewLine);
            log("Результат: " + ActivateFunc(sumR, thetaR, NeuronType.Bipolar) + Environment.NewLine);

            return ActivateFunc(sumR, thetaR, NeuronType.Bipolar);
        }


        public static Log log;
        // Количество сенсоров, нейронов скрытого слоя, нейронов выходного слоя
        int sensor, associative, reaction;
        // Веса связей между сенсорными и ассоциативными нейронами
        double[,] SA_W;
        // Пороги срабатывания нейронов скрытого слоя
        double[] thetaA;
        // Веся связей между ассоциативными и реагирующими нейронами
        double[] AR_W;
        // Пороги срабатывания нейронов выходного слоя
        double thetaR;
    }
}
