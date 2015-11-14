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
            this.inputPanel = new System.Windows.Forms.Panel();
            this.learningType = new System.Windows.Forms.GroupBox();
            this.btnLearn = new System.Windows.Forms.Button();
            this.gammaLearningChoice = new System.Windows.Forms.RadioButton();
            this.alphaLearningChoice = new System.Windows.Forms.RadioButton();
            this.learningSet = new System.Windows.Forms.GroupBox();
            this.logBox = new System.Windows.Forms.TextBox();
            this.assocWeightsTable = new System.Windows.Forms.GroupBox();
            this.learningType.SuspendLayout();
            this.learningSet.SuspendLayout();
            this.assocWeightsTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // inputPanel
            // 
            this.inputPanel.AutoScroll = true;
            this.inputPanel.Location = new System.Drawing.Point(9, 19);
            this.inputPanel.Name = "inputPanel";
            this.inputPanel.Size = new System.Drawing.Size(520, 150);
            this.inputPanel.TabIndex = 0;
            // 
            // learningType
            // 
            this.learningType.Controls.Add(this.btnLearn);
            this.learningType.Controls.Add(this.gammaLearningChoice);
            this.learningType.Controls.Add(this.alphaLearningChoice);
            this.learningType.Location = new System.Drawing.Point(554, 12);
            this.learningType.Name = "learningType";
            this.learningType.Size = new System.Drawing.Size(160, 178);
            this.learningType.TabIndex = 1;
            this.learningType.TabStop = false;
            this.learningType.Text = "Тип обучения";
            // 
            // btnLearn
            // 
            this.btnLearn.Location = new System.Drawing.Point(17, 139);
            this.btnLearn.Name = "btnLearn";
            this.btnLearn.Size = new System.Drawing.Size(134, 30);
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
            // 
            // learningSet
            // 
            this.learningSet.Controls.Add(this.inputPanel);
            this.learningSet.Location = new System.Drawing.Point(12, 12);
            this.learningSet.Name = "learningSet";
            this.learningSet.Size = new System.Drawing.Size(536, 178);
            this.learningSet.TabIndex = 2;
            this.learningSet.TabStop = false;
            this.learningSet.Text = "Обучающая выборка";
            // 
            // logBox
            // 
            this.logBox.Location = new System.Drawing.Point(9, 19);
            this.logBox.Multiline = true;
            this.logBox.Name = "logBox";
            this.logBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logBox.Size = new System.Drawing.Size(677, 389);
            this.logBox.TabIndex = 3;
            // 
            // assocWeightsTable
            // 
            this.assocWeightsTable.Controls.Add(this.logBox);
            this.assocWeightsTable.Location = new System.Drawing.Point(12, 196);
            this.assocWeightsTable.Name = "assocWeightsTable";
            this.assocWeightsTable.Size = new System.Drawing.Size(692, 414);
            this.assocWeightsTable.TabIndex = 5;
            this.assocWeightsTable.TabStop = false;
            this.assocWeightsTable.Text = "Веса скрытого слоя";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 622);
            this.Controls.Add(this.assocWeightsTable);
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
            this.assocWeightsTable.ResumeLayout(false);
            this.assocWeightsTable.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel inputPanel;
        private System.Windows.Forms.GroupBox learningType;
        private System.Windows.Forms.RadioButton gammaLearningChoice;
        private System.Windows.Forms.RadioButton alphaLearningChoice;
        private System.Windows.Forms.Button btnLearn;
        private System.Windows.Forms.GroupBox learningSet;
        private System.Windows.Forms.TextBox logBox;
        private System.Windows.Forms.GroupBox assocWeightsTable;
    }
}

