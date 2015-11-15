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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.inputTrainSetPanel = new System.Windows.Forms.Panel();
            this.learningType = new System.Windows.Forms.GroupBox();
            this.btnLearn = new System.Windows.Forms.Button();
            this.gammaLearningChoice = new System.Windows.Forms.RadioButton();
            this.alphaLearningChoice = new System.Windows.Forms.RadioButton();
            this.learningSet = new System.Windows.Forms.GroupBox();
            this.inputSurNameSet = new System.Windows.Forms.RadioButton();
            this.inputNameSet = new System.Windows.Forms.RadioButton();
            this.logBox = new System.Windows.Forms.TextBox();
            this.processLog = new System.Windows.Forms.GroupBox();
            this.Steps = new System.Windows.Forms.DataGridView();
            this.SA_Weights = new System.Windows.Forms.DataGridView();
            this.AR_Weights = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRecognize = new System.Windows.Forms.Button();
            this.InputRecognPanel = new System.Windows.Forms.Panel();
            this.learningType.SuspendLayout();
            this.learningSet.SuspendLayout();
            this.processLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Steps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SA_Weights)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AR_Weights)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // inputTrainSetPanel
            // 
            this.inputTrainSetPanel.AutoScroll = true;
            this.inputTrainSetPanel.Location = new System.Drawing.Point(13, 19);
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
            this.learningType.Size = new System.Drawing.Size(160, 197);
            this.learningType.TabIndex = 1;
            this.learningType.TabStop = false;
            this.learningType.Text = "Тип обучения";
            // 
            // btnLearn
            // 
            this.btnLearn.Location = new System.Drawing.Point(8, 161);
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
            this.learningSet.Size = new System.Drawing.Size(223, 197);
            this.learningSet.TabIndex = 2;
            this.learningSet.TabStop = false;
            this.learningSet.Text = "Обучающая выборка";
            // 
            // inputSurNameSet
            // 
            this.inputSurNameSet.AutoSize = true;
            this.inputSurNameSet.Location = new System.Drawing.Point(111, 174);
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
            this.inputNameSet.Location = new System.Drawing.Point(13, 175);
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
            this.logBox.Location = new System.Drawing.Point(12, 445);
            this.logBox.Multiline = true;
            this.logBox.Name = "logBox";
            this.logBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logBox.Size = new System.Drawing.Size(543, 178);
            this.logBox.TabIndex = 3;
            // 
            // processLog
            // 
            this.processLog.Controls.Add(this.Steps);
            this.processLog.Location = new System.Drawing.Point(178, 215);
            this.processLog.Name = "processLog";
            this.processLog.Size = new System.Drawing.Size(377, 224);
            this.processLog.TabIndex = 5;
            this.processLog.TabStop = false;
            this.processLog.Text = "Ход обучения";
            // 
            // Steps
            // 
            this.Steps.AllowUserToAddRows = false;
            this.Steps.AllowUserToDeleteRows = false;
            this.Steps.AllowUserToResizeColumns = false;
            this.Steps.AllowUserToResizeRows = false;
            this.Steps.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Steps.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.Steps.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Steps.ColumnHeadersHeight = 20;
            this.Steps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Steps.DefaultCellStyle = dataGridViewCellStyle7;
            this.Steps.Location = new System.Drawing.Point(6, 19);
            this.Steps.MultiSelect = false;
            this.Steps.Name = "Steps";
            this.Steps.ReadOnly = true;
            this.Steps.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.Steps.RowTemplate.Height = 20;
            this.Steps.RowTemplate.ReadOnly = true;
            this.Steps.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.Steps.Size = new System.Drawing.Size(365, 199);
            this.Steps.TabIndex = 7;
            // 
            // SA_Weights
            // 
            this.SA_Weights.AllowUserToAddRows = false;
            this.SA_Weights.AllowUserToDeleteRows = false;
            this.SA_Weights.AllowUserToResizeColumns = false;
            this.SA_Weights.AllowUserToResizeRows = false;
            this.SA_Weights.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.SA_Weights.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.SA_Weights.ColumnHeadersHeight = 20;
            this.SA_Weights.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.SA_Weights.DefaultCellStyle = dataGridViewCellStyle8;
            this.SA_Weights.Location = new System.Drawing.Point(407, 12);
            this.SA_Weights.MultiSelect = false;
            this.SA_Weights.Name = "SA_Weights";
            this.SA_Weights.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SA_Weights.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.SA_Weights.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.SA_Weights.RowTemplate.Height = 20;
            this.SA_Weights.RowTemplate.ReadOnly = true;
            this.SA_Weights.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.SA_Weights.Size = new System.Drawing.Size(406, 197);
            this.SA_Weights.TabIndex = 3;
            // 
            // AR_Weights
            // 
            this.AR_Weights.AllowUserToAddRows = false;
            this.AR_Weights.AllowUserToDeleteRows = false;
            this.AR_Weights.AllowUserToResizeColumns = false;
            this.AR_Weights.AllowUserToResizeRows = false;
            this.AR_Weights.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.AR_Weights.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.AR_Weights.ColumnHeadersHeight = 20;
            this.AR_Weights.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.AR_Weights.Location = new System.Drawing.Point(561, 224);
            this.AR_Weights.MultiSelect = false;
            this.AR_Weights.Name = "AR_Weights";
            this.AR_Weights.ReadOnly = true;
            this.AR_Weights.RowHeadersVisible = false;
            this.AR_Weights.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.AR_Weights.RowTemplate.Height = 20;
            this.AR_Weights.RowTemplate.ReadOnly = true;
            this.AR_Weights.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.AR_Weights.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.AR_Weights.Size = new System.Drawing.Size(188, 59);
            this.AR_Weights.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRecognize);
            this.groupBox1.Controls.Add(this.InputRecognPanel);
            this.groupBox1.Location = new System.Drawing.Point(12, 215);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(160, 224);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Символ для распознавания";
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
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 635);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.AR_Weights);
            this.Controls.Add(this.SA_Weights);
            this.Controls.Add(this.processLog);
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
            this.processLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Steps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SA_Weights)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AR_Weights)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel inputTrainSetPanel;
        private System.Windows.Forms.GroupBox learningType;
        private System.Windows.Forms.RadioButton gammaLearningChoice;
        private System.Windows.Forms.RadioButton alphaLearningChoice;
        private System.Windows.Forms.Button btnLearn;
        private System.Windows.Forms.GroupBox learningSet;
        private System.Windows.Forms.TextBox logBox;
        private System.Windows.Forms.GroupBox processLog;
        private System.Windows.Forms.RadioButton inputSurNameSet;
        private System.Windows.Forms.RadioButton inputNameSet;
        private System.Windows.Forms.DataGridView SA_Weights;
        private DataGridView AR_Weights;
        private DataGridView Steps;
        private GroupBox groupBox1;
        private Panel InputRecognPanel;
        private Button btnRecognize;
    }
}

