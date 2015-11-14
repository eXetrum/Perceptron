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
        public delegate void Log(string msg);

        // Пара: изображение - вектор ожидаемый на выходе
        public struct PairSet
        {
            // "Изображение"
            public int[] image;
            // Ожидаемый выход
            public int[] t;
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
            // Первый индекс - номер A_i нейрона в ассоциативном слое,
            // Второй индекс - связь A_i нейрона с S_j нейроном в сенсорном слое
            w1 = new double[associative, sensor];
            // Ассоциативный слой бинарных нейронов
            // Для каждого изображения набор выходных значений нейронов ассоциативного слоя
            A = new List<double[]>(images.Count);
            // Веса связей слоя ассоциативных нейронов и слоя реагирующих нейронов
            w2 = new double[reaction, associative];
            // Пороги срабатывания нейронов выходного слоя. Для каждого нейрона разный порог срабатывания
            thetaR = new double[reaction];
            // Заполняем веса случ. числами
            Random rnd = new Random(DateTime.Now.Millisecond);

            log("============================================================" + Environment.NewLine);
            log("Веса между сенсорным слоем и скрытым [S->A]: " + Environment.NewLine);
            for (int i = 0; i < associative; ++i)
            {
                log("A[" + i + "]=");
                // Заполняем все связи A_i нейрона со всеми сенсорными
                for (int j = 0; j < sensor; ++j)
                {
                    w1[i, j] = rnd.Next(1, 10) / 10.0;
                    log(w1[i, j] + " ");
                }
                log(Environment.NewLine);
            }
            // Последний слой
            log("============================================================" + Environment.NewLine);
            log("Веса между скрытым и реагирующим(выходным) слоем [A->R]: " + Environment.NewLine);
            for (int i = 0; i < reaction; ++i)
            {
                log("R[" + i + "]=");
                // Заполняем все связи R_i нейрона со всеми ассоциаторами
                for (int j = 0; j < associative; ++j)
                {
                    w2[i, j] = rnd.Next(1, 10) / 10.0;
                    log(w2[i, j] + " ");
                }
                log(Environment.NewLine);
            }



            // Скармливаем сети все переданные изображения
            List<List<double>> assocAllImgOutputs = new List<List<double>>();
            List<List<double>> reactAllImgOutputs = new List<List<double>>();



            for (int img = 0; img < images.Count; ++img)
            {
                log("============================================================" + Environment.NewLine);
                log("Изображение #" + img + Environment.NewLine);
                List<double> assocOut = FeedAssocLayer(images[img].image);

                A.Add(new double[assocOut.Count]);
                Array.Copy(assocOut.ToArray(), A[img], assocOut.Count);

                assocAllImgOutputs.Add(assocOut);
                

                string SA = "";
                for (int aOut = 0; aOut < assocOut.Count; ++aOut)
                {
                    SA += assocOut[aOut] + " ";
                }
                
                log("[S->A]" + SA + Environment.NewLine);

                /*string AR = "";

                for (int rOut = 0; rOut < reactOut.Count; ++rOut)
                {
                    AR += reactOut[rOut] + " ";
                }

                log("[A->R]" + AR + Environment.NewLine);
                */
            }



            double minA = assocAllImgOutputs.SelectMany(x => x).ToList().Min();
            double maxA = assocAllImgOutputs.SelectMany(x => x).ToList().Max();
            List<double> lst = assocAllImgOutputs.SelectMany(x => x).ToList();
            thetaA = (minA + maxA) / 2.0;
            thetaA = lst.Sum() / lst.Count;
            log(string.Format("min={0}, max={1}, Пороговое значение активации нейронов скрытого слоя A -> theta={2}", minA, maxA, thetaA));
            log(Environment.NewLine);


            // Рассчитываем пороговое значение для нейронов ассоциативного слоя
            //for (int a = 0; a < associative; ++a)
            //{
            //    List<double> Ai = new List<double>();
            //    for (int img = 0; img < images.Count; ++img)
            //    {
            //        Ai.Add(A[img][a]);
            //    }
            //    double minA = Ai.Min();// assocAllImgOutputs.SelectMany(x => x).ToList().Min();
            //    double maxA = Ai.Max();// assocAllImgOutputs.SelectMany(x => x).ToList().Max();
            //    thetaA[a] = Ai.Sum() / images.Count;// (minA + maxA) / 2.0;
            //    log(string.Format("min={0}, max={1}, Пороговое значение активации нейрона скрытого слоя A[{2}] -> theta={3}", minA, maxA, a, thetaA[a]));
            //    log(Environment.NewLine);
            //}




            
                bool done = false;
                Dictionary<double, int> thetas = new Dictionary<double, int>();
                for (thetaA = minA; thetaA <= maxA && !done; thetaA += 0.1)
                {
                    List<List<int>> imgAssoc = new List<List<int>>();
                    log("============================================================" + Environment.NewLine);
                    log("theta=" + thetaA);
                    for (int img = 0; img < images.Count; ++img)
                    {
                        log("Изображение #" + img + Environment.NewLine);
                        List<double> assocOut = FeedAssocLayer(images[img].image);
                        List<int> Aindex = new List<int>();
                        for (int a = 0; a < associative; ++a)
                        {
                            if (assocOut[a] >= thetaA)
                                Aindex.Add(a);
                            log((assocOut[a] >= thetaA ? "A[" + a + "]" : ""));
                        }
                        if (Aindex.Count == 0)
                        {
                            done = true;
                            break;
                        }
                        log(Environment.NewLine);
                        imgAssoc.Add(Aindex);
                    }
                    HashSet<int> activeNeuronsIntersection = new HashSet<int>(imgAssoc[0]);
                    for (int i = 1; i < imgAssoc.Count; ++i)
                        activeNeuronsIntersection.IntersectWith(imgAssoc[i]);

                    thetas.Add(thetaA, activeNeuronsIntersection.ToList().Count);

                    /*log(string.Format("intersect count={0}, theta={1}", activeNeuronsIntersection.ToList().Count, thetaA));
                    log(Environment.NewLine);*/
                }

                int min = thetas.Values.Min();
                thetaA = thetas.First(x => x.Value == min).Key;
                log(string.Format("[Optimal theta] intersect count={0}, theta={1}", min, thetaA));
                log(Environment.NewLine);
                MessageBox.Show("next A");


            for (int img = 0; img < images.Count; ++img)
            {
                log("Изображение #" + img );
                List<double> assocOut = FeedAssocLayer(images[img].image);
                for (int a = 0; a < associative; ++a)
                {
                    log((assocOut[a] >= thetaA ? "A[" + a + "]" : ""));
                }
                log(Environment.NewLine);
            }
            MessageBox.Show("Next");


            /*
            double minA = assocAllImgOutputs.SelectMany(x => x).ToList().Min();
            double maxA = assocAllImgOutputs.SelectMany(x => x).ToList().Max();
            thetaA = (minA + maxA) / 2.0;
            
            log(string.Format("min={0}, max={1}, Пороговое значение активации нейронов `A уровня`, [A]theta={2}", minA, maxA, thetaA));
            log(Environment.NewLine);*/
            ////////////////////////////////////////////////////////////////////
            
            for (int r = 0; r < reaction; ++r)
            {
                List<double> Ri = new List<double>();
                log("============================== Нейрон R[" + r + "]: ==============================" + Environment.NewLine);
                
                for (int img = 0; img < images.Count; ++img)
                {
                    double sumR = 0;

                    for (int a = 0; a < associative; ++a)
                    {
                        sumR += w2[r, a] * (A[img][a] >= thetaA ? 1 : 0);
                    }
                    log("Изображение #" + img + Environment.NewLine);
                    log("R=" + sumR + Environment.NewLine);
                    Ri.Add(sumR);
                }
                double minRi = Ri.Min();
                double maxRi = Ri.Max();
                double sum = Ri.Sum();
                thetaR[r] = Ri.Sum() / Ri.Count;//(minRi + maxRi) / 2.0;
                log(string.Format("min={0}, max={1}, Пороговое значение активации выходных нейронов R -> theta={2}", minRi, maxRi, thetaR[r]));
                log(Environment.NewLine);
                MessageBox.Show("Next");
                
            }
            

            //double sig = thetaR.Sum() / thetaR.Length;
            //thetaR[0] = sig;
            //thetaR[1] = sig;
            



            
            
            
            //List<double> reactOut = FeedReactLayer(assocOut);
            //reactAllImgOutputs.Add(reactOut);




            // Рассчитываем пороговое значение активации нейронов выходного слоя
            //for(int r = 0; r < reaction; ++r) {
            //    List<double> Ri = new List<double>();
            //    for (int img = 0; img < images.Count; ++img)
            //    {
            //        Ri.Add(reactAllImgOutputs[img][r]);
            //    }
            //    double minRi = Ri.Min();
            //    double maxRi = Ri.Max();
            //    thetaR[r] = (minRi + maxRi) / 2.0;
            //    log(string.Format("min={0}, max={1}, Пороговое значение активации нейронов `Ri уровня`, [R{2}]theta={3}", minRi, maxRi, r, thetaR[r]));
            //    log(Environment.NewLine);
            //}
            /*List<double> rct = reactAllImgOutputs.SelectMany(x => x.ToList()).ToList();
            double minR = 0;//.Min();
            double maxR = reactAllImgOutputs.SelectMany(x => x.ToList()).Max();
            thetaR[0] = (minR + maxR) / 2.0;

            log(string.Format("min={0}, max={1}, Пороговое значение активации нейронов `R уровня`, [R]theta={2}", minR, maxR, thetaR[0]));
            */
            // Четыре сивола кодируем {+1, +1}, {-1, -1}, {-1, +1}, {+1, -1}
            // Первые два символа обрабатывает R1
            // Вторые два символа обрабатывает R2

        }

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
                bool learDone = false;
                double step = 0.1;
                while (!learDone)
                {
                    learDone = true;
                    for (int img = 0; img < images.Count; ++img)
                    {

                        log("Изображение #" + img + Environment.NewLine);

                        string s = "";
                        for(int i = 0; i < reaction; i++) {
                            s += "r=" + i;
                            for(int j = 0; j < associative; ++j) {
                                s += w2[i, j] + " ";
                            }
                            s += Environment.NewLine;
                        }

                        log(s);
                        log("Ожидаемая реация: " + String.Join(" ", images[img].t) + Environment.NewLine);
                        for (int r = 0; r < reaction; ++r)
                        {
                            //log("Нейрон R[" + r + "]: " + Environment.NewLine);
                            double sumR = 0;
                            List<int> activeAR = new List<int>();
                            List<double> asOut = FeedAssocLayer(images[img].image);
                            for (int a = 0; a < associative; ++a)
                            {
                                if (asOut[a] >= thetaA)
                                {
                                    sumR += w2[r, a];
                                    activeAR.Add(a);
                                }
                            }
                            int Rreact = 0;
                            Rreact = (sumR >= thetaR[r] ? 1 : -1);
                            
                            //log(Rreact + " ");
                            if (Rreact != images[img].t[r])
                            {
                                log("R[" + r + "] wrong reaction, correction..." + Rreact + Environment.NewLine);

                                int p = 1;
                                if(Rreact > images[img].t[r])
                                    p *= (-1);

                                for (int active = 0; active < activeAR.Count; ++active)
                                {
                                    w2[r, active] += step * p;
                                    //w2[r, active] = Math.Ceiling(w2[r, active]);
                                }
                                // Recalc A sums
                                //RecalcAsums(images);
                                learDone = false;
                            }
                            else
                            {
                                log("R[" + r + "] OK" + Environment.NewLine);
                            }
                            //log( + Environment.NewLine);
                        }
                        
                        
                    }
                    MessageBox.Show("next?");
                    Application.DoEvents();
                }
            }
            else
            {
            }           

        }


        void RecalcAsums(List<PairSet> images)
        {
            A = new List<double[]>();
            for (int img = 0; img < images.Count; ++img)
            {
                List<double> assocOut = FeedAssocLayer(images[img].image);

                A.Add(new double[assocOut.Count]);
                Array.Copy(assocOut.ToArray(), A[img], assocOut.Count);

            }
        }

        List<double> FeedReactLayer(List<double> assoc)
        {
            List<double> reactNeuro = new List<double>();
            for (int r = 0; r < reaction; ++r)
            {
                double sumR = 0;
                for (int a = 0; a < associative; ++a)
                {
                    //sumR += w2[r, a] * assoc[a];
                    sumR += w2[r, a] * (assoc[a] >= thetaA ? 1 : 0);
                }
                reactNeuro.Add(sumR);
            }
            return reactNeuro;
        }

        List<double> FeedAssocLayer(int[] S)
        {
            if (S.Length != sensor) throw new Exception("Image len != sensor len");

            List<double> assocOutputs = new List<double>();

            for (int a = 0; a < associative; ++a)
            {
                double sumA = 0;
                for (int si = 0; si < sensor; ++si)
                {
                    sumA += w1[a, si] * S[si];
                }
                assocOutputs.Add(sumA);
            }

            return assocOutputs;
        }

        public double [, ] AssocWeights() 
        {
            return w1;
        }

        public double [, ] ReactWeights()
        {
            return w2;
        }

        public static Log log;

        int sensor, associative, reaction;
        // Сенсорные нейроны
        //int[] S;
        // Веса связей между сенсорными и ассоциативными нейронами
        double[,] w1;
        // Ассоциативные нейроны. Значения взвешенных сумм на всех нейронах для каждого изображения
        List<double[]> A;
        // Пороги срабатывания нейронов скрытого слоя
        double thetaA;
        // Веся связей между ассоциативными и реагирующими нейронами
        double[,] w2;
        // Реагирующие нейроны
        // Пороги срабатывания нейронов выходного слоя
        double []thetaR;
    }
}
