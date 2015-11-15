using System.Windows.Forms;
namespace Perceptron
{
    partial class mainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.inputTrainSetPanel = new System.Windows.Forms.Panel();
            this.learningType = new System.Windows.Forms.GroupBox();
            this.btnLearn = new System.Windows.Forms.Button();
            this.gammaLearningChoice = new System.Windows.Forms.RadioButton();
            this.alphaLearningChoice = new System.Windows.Forms.RadioButton();
            this.learningSet = new System.Windows.Forms.GroupBox();
            this.inputSurNameSet = new System.Windows.Forms.RadioButton();
            this.inputNameSet = new System.Windows.Forms.RadioButton();
            this.logBox = new System.Windows.Forms.TextBox();
            this.recognizeCharacter = new System.Windows.Forms.GroupBox();
            this.btnRecognize = new System.Windows.Forms.Button();
            this.InputRecognPanel = new System.Windows.Forms.Panel();
            this.logGroup = new System.Windows.Forms.GroupBox();
            this.learningType.SuspendLayout();
            this.learningSet.SuspendLayout();
            this.recognizeCharacter.SuspendLayout();
            this.logGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // inputTrainSetPanel
            // 
            this.inputTrainSetPanel.AutoScroll = true;
            this.inputTrainSetPanel.Location = new System.Drawing.Point(13, 32);
            this.inputTrainSetPanel.Name = "inputTrainSetPanel";
            this.inputTrainSetPanel.Size = new System.Drawing.Size(199, 150);
            this.inputTrainSetPanel.TabIndex = 0;
            // 
            // learningType
            // 
            this.learningType.Controls.Add(this.btnLearn);
            this.learningType.Controls.Add(this.gammaLearningChoice);
            this.learningType.Controls.Add(this.alphaLearningChoice);
            this.learningType.Location = new System.Drawing.Point(12, 12);
            this.learningType.Name = "learningType";
            this.learningType.Size = new System.Drawing.Size(160, 224);
            this.learningType.TabIndex = 1;
            this.learningType.TabStop = false;
            this.learningType.Text = "Тип обучения";
            // 
            // btnLearn
            // 
            this.btnLearn.Location = new System.Drawing.Point(8, 188);
            this.btnLearn.Name = "btnLearn";
            this.btnLearn.Size = new System.Drawing.Size(142, 30);
            this.btnLearn.TabIndex = 2;
            this.btnLearn.Text = "Обучить";
            this.btnLearn.UseVisualStyleBackColor = true;
            this.btnLearn.Click += new System.EventHandler(this.btnLearn_Click);
            // 
            // gammaLearningChoice
            // 
            this.gammaLearningChoice.AutoSize = true;
            this.gammaLearningChoice.Location = new System.Drawing.Point(16, 89);
            this.gammaLearningChoice.Name = "gammaLearningChoice";
            this.gammaLearningChoice.Size = new System.Drawing.Size(134, 17);
            this.gammaLearningChoice.TabIndex = 1;
            this.gammaLearningChoice.Text = "Гамма подкрепление";
            this.gammaLearningChoice.UseVisualStyleBackColor = true;
            this.gammaLearningChoice.CheckedChanged += new System.EventHandler(this.gammaLearningChoice_CheckedChanged);
            // 
            // alphaLearningChoice
            // 
            this.alphaLearningChoice.AutoSize = true;
            this.alphaLearningChoice.Checked = true;
            this.alphaLearningChoice.Location = new System.Drawing.Point(17, 36);
            this.alphaLearningChoice.Name = "alphaLearningChoice";
            this.alphaLearningChoice.Size = new System.Drawing.Size(133, 17);
            this.alphaLearningChoice.TabIndex = 0;
            this.alphaLearningChoice.TabStop = true;
            this.alphaLearningChoice.Text = "Альфа подкрепление";
            this.alphaLearningChoice.UseVisualStyleBackColor = true;
            this.alphaLearningChoice.CheckedChanged += new System.EventHandler(this.alphaLearningChoice_CheckedChanged);
            // 
            // learningSet
            // 
            this.learningSet.Controls.Add(this.inputSurNameSet);
            this.learningSet.Controls.Add(this.inputNameSet);
            this.learningSet.Controls.Add(this.inputTrainSetPanel);
            this.learningSet.Location = new System.Drawing.Point(178, 12);
            this.learningSet.Name = "learningSet";
            this.learningSet.Size = new System.Drawing.Size(223, 224);
            this.learningSet.TabIndex = 2;
            this.learningSet.TabStop = false;
            this.learningSet.Text = "Обучающая выборка";
            // 
            // inputSurNameSet
            // 
            this.inputSurNameSet.AutoSize = true;
            this.inputSurNameSet.Location = new System.Drawing.Point(110, 188);
            this.inputSurNameSet.Name = "inputSurNameSet";
            this.inputSurNameSet.Size = new System.Drawing.Size(105, 17);
            this.inputSurNameSet.TabIndex = 2;
            this.inputSurNameSet.Text = "буквы фамилии";
            this.inputSurNameSet.UseVisualStyleBackColor = true;
            this.inputSurNameSet.CheckedChanged += new System.EventHandler(this.inputSurNameSet_CheckedChanged);
            // 
            // inputNameSet
            // 
            this.inputNameSet.AutoSize = true;
            this.inputNameSet.Checked = true;
            this.inputNameSet.Location = new System.Drawing.Point(13, 188);
            this.inputNameSet.Name = "inputNameSet";
            this.inputNameSet.Size = new System.Drawing.Size(91, 17);
            this.inputNameSet.TabIndex = 1;
            this.inputNameSet.TabStop = true;
            this.inputNameSet.Text = "буквы имени";
            this.inputNameSet.UseVisualStyleBackColor = true;
            this.inputNameSet.CheckedChanged += new System.EventHandler(this.inputNameSet_CheckedChanged);
            // 
            // logBox
            // 
            this.logBox.Location = new System.Drawing.Point(6, 19);
            this.logBox.Multiline = true;
            this.logBox.Name = "logBox";
            this.logBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logBox.Size = new System.Drawing.Size(538, 204);
            this.logBox.TabIndex = 3;
            // 
            // recognizeCharacter
            // 
            this.recognizeCharacter.Controls.Add(this.btnRecognize);
            this.recognizeCharacter.Controls.Add(this.InputRecognPanel);
            this.recognizeCharacter.Location = new System.Drawing.Point(407, 12);
            this.recognizeCharacter.Name = "recognizeCharacter";
            this.recognizeCharacter.Size = new System.Drawing.Size(160, 224);
            this.recognizeCharacter.TabIndex = 8;
            this.recognizeCharacter.TabStop = false;
            this.recognizeCharacter.Text = "Символ для распознавания";
            // 
            // btnRecognize
            // 
            this.btnRecognize.Enabled = false;
            this.btnRecognize.Location = new System.Drawing.Point(8, 188);
            this.btnRecognize.Name = "btnRecognize";
            this.btnRecognize.Size = new System.Drawing.Size(141, 30);
            this.btnRecognize.TabIndex = 9;
            this.btnRecognize.Text = "Распознать";
            this.btnRecognize.UseVisualStyleBackColor = true;
            this.btnRecognize.Click += new System.EventHandler(this.btnRecognize_Click);
            // 
            // InputRecognPanel
            // 
            this.InputRecognPanel.Location = new System.Drawing.Point(8, 33);
            this.InputRecognPanel.Name = "InputRecognPanel";
            this.InputRecognPanel.Size = new System.Drawing.Size(141, 149);
            this.InputRecognPanel.TabIndex = 0;
            // 
            // logGroup
            // 
            this.logGroup.Controls.Add(this.logBox);
            this.logGroup.Location = new System.Drawing.Point(12, 242);
            this.logGroup.Name = "logGroup";
            this.logGroup.Size = new System.Drawing.Size(555, 235);
            this.logGroup.TabIndex = 9;
            this.logGroup.TabStop = false;
            this.logGroup.Text = "Ход работы";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 485);
            this.Controls.Add(this.logGroup);
            this.Controls.Add(this.recognizeCharacter);
            this.Controls.Add(this.learningSet);
            this.Controls.Add(this.learningType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "mainForm";
            this.Text = "Perceptron";
            this.learningType.ResumeLayout(false);
            this.learningType.PerformLayout();
            this.learningSet.ResumeLayout(false);
            this.learningSet.PerformLayout();
            this.recognizeCharacter.ResumeLayout(false);
            this.logGroup.ResumeLayout(false);
            this.logGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel inputTrainSetPanel;
        private System.Windows.Forms.GroupBox learningType;
        private System.Windows.Forms.RadioButton gammaLearningChoice;
        private System.Windows.Forms.RadioButton alphaLearningChoice;
        private System.Windows.Forms.Button btnLearn;
        private System.Windows.Forms.GroupBox learningSet;
        private System.Windows.Forms.TextBox logBox;
        private System.Windows.Forms.RadioButton inputSurNameSet;
        private System.Windows.Forms.RadioButton inputNameSet;
        private GroupBox recognizeCharacter;
        private Panel InputRecognPanel;
        private Button btnRecognize;
        private GroupBox logGroup;
    }
}

