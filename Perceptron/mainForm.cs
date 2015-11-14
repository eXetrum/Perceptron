using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Perceptron
{
    public partial class mainForm : Form
    {
        static int inputGuiCount = 4;
        static int gridRows = 6;
        static int gridCols = 5;
        static int sensorCount = gridRows * gridCols;
        static int associativeCount = sensorCount;
        static int reactionCount = 4;

        InputGUI []gui = new InputGUI[inputGuiCount];
        Perceptron perceptron = new Perceptron(sensorCount, associativeCount, reactionCount);
        // Бинарное представление букв
        List<Perceptron.PairSet> M = new List<Perceptron.PairSet>() {
            // Буква "А"
            new Perceptron.PairSet() {
                // Бинарное изображение
                image = new int[] {
                    0, 1, 1, 1, 0,
                    1, 0, 0, 0, 1,
                    1, 0, 0, 0, 1,
                    1, 1, 1, 1, 1,                
                    1, 0, 0, 0, 1,
                    1, 0, 0, 0, 1
                }, 
                // Ожидаемый вектор результат
                t = new int[] {+1, -1, -1, -1}
            }, 
            // Буква "Н"
            new Perceptron.PairSet() {
                // Бинарное изображение
                image = new int[] {
                    1, 0, 0, 0, 1,
                    1, 0, 0, 0, 1,
                    1, 1, 1, 1, 1,
                    1, 1, 1, 1, 1,                
                    1, 0, 0, 0, 1,
                    1, 0, 0, 0, 1
                },
                // Ожидаемый вектор результат
                t = new int[] {-1, +1, -1, -1}
            },
            // Буква "Р"
            new Perceptron.PairSet() {
                image = new int[] {
                    1, 1, 1, 1, 0,
                    1, 0, 0, 0, 1,
                    1, 0, 0, 0, 1,                
                    1, 1, 1, 1, 0,
                    1, 0, 0, 0, 0,
                    1, 0, 0, 0, 0
                },
                // Ожидаемый вектор результат
                t = new int[] {-1, -1, +1, -1}
            },
            // Буква "Я"
            new Perceptron.PairSet() {
                image = new int[] {
                    1, 1, 1, 1, 1,
                    1, 0, 0, 0, 1,
                    1, 1, 1, 1, 1,                
                    0, 0, 1, 1, 1,
                    0, 1, 1, 0, 1,
                    1, 1, 0, 0, 1
                },
                t = new int[] {-1, -1, -1, +1}
            }
        };

        
        public mainForm()
        {
            InitializeComponent();
            for (int i = 0; i < inputGuiCount; ++i)
            {
                gui[i] = new InputGUI(gridRows, gridCols);
                gui[i].attachTo(inputPanel);
                gui[i].SetImage(M[i].image);
            }
            Perceptron.log = new Perceptron.Log(logBox.AppendText);
        }

        private void btnLearn_Click(object sender, EventArgs e)
        {
            
            List<Perceptron.PairSet> images = new List<Perceptron.PairSet>();
            for (int img = 0; img < gui.Length; ++img)
            {
                images.Add(new Perceptron.PairSet()
                {
                    image = gui[img].GetImage(),
                    t = M[img].t
                });
            }

            perceptron.Learn(images);

            /*
            if (alphaLearningChoice.Checked)
            {
                MessageBox.Show("Alpha");
            }
            else
            {
                MessageBox.Show("Gamma");
            }
            */
        }
    }
}
