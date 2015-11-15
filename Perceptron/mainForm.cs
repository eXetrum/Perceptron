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
        static int inputGuiCount = 2;
        static int gridRows = 6;
        static int gridCols = 4;
        static int sensorCount = gridRows * gridCols;
        static int associativeCount = 2;//sensorCount + 1;
        static int reactionCount = 1;

        InputGUI []gui = new InputGUI[inputGuiCount];
        InputGUI userGui = new InputGUI(gridRows, gridCols, true);

        Perceptron perceptron = new Perceptron(sensorCount, associativeCount, reactionCount);

        static int[] ResultKeys = { +1, -1 };
        static string[] ResultMessage = { "Первое изображение", "Второе изображение" };
        static Dictionary<int, string> result = new Dictionary<int, string>()
        {
            {ResultKeys[0], ResultMessage[0]},
            {ResultKeys[1], ResultMessage[1]}
        };

        // Текущая выборка: 0 - буквы имени, 1 - буквы фамилии
        static int currentImgSet = -1;
        // Текущий способ обучения: 0 - альфа подкрепления, 1 - гамма подкрепления
        static int currentLearningType = -1;

        /*static KeyValuePair<int, string> Result = new KeyValuePair<int,string>[] 
        {
            new KeyValuePair<int, string>(+1, 
            new KeyValuePair<int, string>(-1, 
        };*/
        // Бинарное представление букв имени
        List<Perceptron.PairSet> name = new List<Perceptron.PairSet>() {
            // Буква "А"
            new Perceptron.PairSet() {
                // Бинарное изображение
                image = new int[] {
                    0, 1, 1, 0,
                    1, 0, 0, 1,
                    1, 0, 0, 1,
                    1, 1, 1, 1,
                    1, 0, 0, 1,
                    1, 0, 0, 1,
                }, 
                // Ожидаемый вектор результат
                t = ResultKeys[0]
            }, 
            // Буква "Н"
            new Perceptron.PairSet() {
                // Бинарное изображение
                image = new int[] {
                    1, 0, 0, 1,
                    1, 0, 0, 1,
                    1, 0, 0, 1,
                    1, 1, 1, 1,
                    1, 0, 0, 1,
                    1, 0, 0, 1,
                },
                // Ожидаемый вектор результат
                t = ResultKeys[1]
            }
        };
        // Буквы фамилии
        List<Perceptron.PairSet> surname = new List<Perceptron.PairSet>() {
            // Буква "Р"
            new Perceptron.PairSet() {
                image = new int[] {
                    1, 1, 1, 0,
                    1, 0, 0, 1,
                    1, 0, 0, 1,
                    1, 1, 1, 0,
                    1, 0, 0, 0,
                    1, 0, 0, 0,
                },
                // Ожидаемый вектор результат
                t = ResultKeys[0]
            },
            // Буква "Я"
            new Perceptron.PairSet() {
                image = new int[] {
                    1, 1, 1, 1,
                    1, 0, 0, 1,
                    1, 1, 1, 1,
                    0, 0, 1, 1,
                    0, 1, 0, 1,
                    1, 1, 0, 1,
                },
                t = ResultKeys[1]
            }
        };

        
        public mainForm()
        {
            InitializeComponent();
            for (int i = 0; i < inputGuiCount; ++i)
            {
                gui[i] = new InputGUI(gridRows, gridCols);
                gui[i].attachTo(inputTrainSetPanel);
                gui[i].SetImage(name[i].image);
            }


            
            userGui.attachTo(InputRecognPanel, true);

            Perceptron.log = new Perceptron.Log(logBox.AppendText);

            // 
            // dataGridView
            // 
            
            ///////////////////            
            ///////////////////
            ///////////////////
            SA_Weights.RowCount = associativeCount;
            SA_Weights.ColumnCount = sensorCount;


            foreach (DataGridViewColumn column in SA_Weights.Columns)
            {
                column.HeaderText = "S" + column.Index;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.Width = 30;
            }

            foreach (DataGridViewRow row in SA_Weights.Rows)
            {
                row.HeaderCell.Value = "A" + row.Index;
            }
            /////////////////////
            AR_Weights.RowCount = reactionCount;
            AR_Weights.ColumnCount = associativeCount;

            foreach (DataGridViewColumn column in AR_Weights.Columns)
            {
                column.HeaderText = "A" + column.Index;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.Width = 30;
            }

            /////////////////////////
            Steps.ColumnCount = associativeCount + 2;
            Steps.RowCount = 1;


            //Steps.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            //foreach (DataGridViewRow row in Steps.Rows)
            //{

            //    row.HeaderCell.Value = "W" + row.Index;
            //}
            //Steps.Rows[associativeCount].HeaderCell.Value = "img #0";
            //Steps.Rows[associativeCount + 1].HeaderCell.Value = "img #1";

            foreach (DataGridViewColumn column in Steps.Columns)
            {
                column.HeaderText = "Wi[" + column.Index + "]";
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.Width = 30;
            }
            Steps.Columns[0].HeaderText = "img #0";
            Steps.Columns[1].HeaderText = "img #1";
            

            Perceptron.SAweights = SA_Weights;
            Perceptron.ARweights = AR_Weights;
            Perceptron.Steps = Steps;

        }

        private void btnLearn_Click(object sender, EventArgs e)
        {
            learningSet.Enabled = false;
            learningType.Enabled = false;

            List<Perceptron.PairSet> images = new List<Perceptron.PairSet>();
            for (int img = 0; img < gui.Length; ++img)
            {
                images.Add(new Perceptron.PairSet()
                {
                    image = gui[img].GetImage(),
                    t = ResultKeys[img]
                });
            }

            if (alphaLearningChoice.Checked)
            {
                MessageBox.Show("Alpha");
                perceptron.Learn(images, true);
                currentImgSet = inputNameSet.Checked ? 0 : 1;
                currentLearningType = 0;
            }
            else
            {
                MessageBox.Show("Gamma");
                perceptron.Learn(images, false);
                currentImgSet = inputNameSet.Checked ? 0 : 1;
                currentLearningType = 1;
            }


            learningSet.Enabled = true;
            learningType.Enabled = true;
            btnRecognize.Enabled = true;
            
        }

        private void inputNameSet_CheckedChanged(object sender, EventArgs e)
        {

            if (inputNameSet.Checked)
            {
                btnRecognize.Enabled = AllowRecognize();
                for (int i = 0; i < inputGuiCount; ++i)
                    gui[i].SetImage(name[i].image);
            }
            else
            {
                btnRecognize.Enabled = AllowRecognize();
                for (int i = 0; i < inputGuiCount; ++i)
                    gui[i].SetImage(surname[i].image);
            }
        }

        private void inputSurNameSet_CheckedChanged(object sender, EventArgs e)
        {
            if (inputSurNameSet.Checked)
            {
                btnRecognize.Enabled = AllowRecognize();
                for (int i = 0; i < inputGuiCount; ++i)
                    gui[i].SetImage(surname[i].image);
            }
            else
            {
                btnRecognize.Enabled = AllowRecognize();

                for (int i = 0; i < inputGuiCount; ++i)
                    gui[i].SetImage(name[i].image);
            }
        }

        private void btnRecognize_Click(object sender, EventArgs e)
        {
            MessageBox.Show(result[perceptron.Recognize(userGui.GetImage())]);
        }

        private void alphaLearningChoice_CheckedChanged(object sender, EventArgs e)
        {
            btnRecognize.Enabled = AllowRecognize();
            
        }

        private void gammaLearningChoice_CheckedChanged(object sender, EventArgs e)
        {
            btnRecognize.Enabled = AllowRecognize();
        }

        bool AllowRecognize()
        {
            return
                ((inputNameSet.Checked && currentImgSet == 0) || (inputSurNameSet.Checked && currentImgSet == 1))
                &&
                ((alphaLearningChoice.Checked && currentLearningType == 0) || (gammaLearningChoice.Checked && currentLearningType == 1));
        }

    }
}
