//Copyright (C) 2013 <copyright holders>
//
//Permission is hereby granted, free of charge, to any person obtaining a copy of this 
//software and associated documentation files (the "Software"), to deal in the Software without 
//restriction, including without limitation the rights to use, copy, modify, merge, publish, 
//distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom 
//the Software is furnished to do so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in all copies or 
//substantial portions of the Software.
//
//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
//INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR 
//PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR 
//ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, 
//ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE 
//SOFTWARE.

//Author: Alex Rodrigues

namespace Task_Manager
{
    partial class EditTaskForm
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
            this.editTaskTitle = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.editDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.editTagLabel = new System.Windows.Forms.Label();
            this.editTagBox = new System.Windows.Forms.ComboBox();
            this.editTaskNamelabel = new System.Windows.Forms.Label();
            this.editTaskBox = new System.Windows.Forms.TextBox();
            this.saveEditButton = new System.Windows.Forms.Button();
            this.cancelEditButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // editTaskTitle
            // 
            this.editTaskTitle.AutoSize = true;
            this.editTaskTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editTaskTitle.Location = new System.Drawing.Point(83, 18);
            this.editTaskTitle.Name = "editTaskTitle";
            this.editTaskTitle.Size = new System.Drawing.Size(151, 37);
            this.editTaskTitle.TabIndex = 0;
            this.editTaskTitle.Text = "Edit Task";
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateLabel.Location = new System.Drawing.Point(35, 73);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(53, 24);
            this.dateLabel.TabIndex = 1;
            this.dateLabel.Text = "Date:";
            // 
            // editDateTimePicker
            // 
            this.editDateTimePicker.Location = new System.Drawing.Point(103, 75);
            this.editDateTimePicker.Name = "editDateTimePicker";
            this.editDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.editDateTimePicker.TabIndex = 2;
            // 
            // editTagLabel
            // 
            this.editTagLabel.AutoSize = true;
            this.editTagLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editTagLabel.Location = new System.Drawing.Point(35, 129);
            this.editTagLabel.Name = "editTagLabel";
            this.editTagLabel.Size = new System.Drawing.Size(48, 24);
            this.editTagLabel.TabIndex = 3;
            this.editTagLabel.Text = "Tag:";
            // 
            // editTagBox
            // 
            this.editTagBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.editTagBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.editTagBox.FormattingEnabled = true;
            this.editTagBox.Location = new System.Drawing.Point(103, 134);
            this.editTagBox.Name = "editTagBox";
            this.editTagBox.Size = new System.Drawing.Size(121, 21);
            this.editTagBox.TabIndex = 4;
            // 
            // editTaskNamelabel
            // 
            this.editTaskNamelabel.AutoSize = true;
            this.editTaskNamelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editTaskNamelabel.Location = new System.Drawing.Point(35, 187);
            this.editTaskNamelabel.Name = "editTaskNamelabel";
            this.editTaskNamelabel.Size = new System.Drawing.Size(55, 24);
            this.editTaskNamelabel.TabIndex = 5;
            this.editTaskNamelabel.Text = "Task:";
            // 
            // editTaskBox
            // 
            this.editTaskBox.Location = new System.Drawing.Point(103, 192);
            this.editTaskBox.Name = "editTaskBox";
            this.editTaskBox.Size = new System.Drawing.Size(140, 20);
            this.editTaskBox.TabIndex = 6;
            // 
            // saveEditButton
            // 
            this.saveEditButton.Location = new System.Drawing.Point(39, 240);
            this.saveEditButton.Name = "saveEditButton";
            this.saveEditButton.Size = new System.Drawing.Size(81, 32);
            this.saveEditButton.TabIndex = 7;
            this.saveEditButton.Text = "Save";
            this.saveEditButton.UseVisualStyleBackColor = true;
            this.saveEditButton.Click += new System.EventHandler(this.SaveEditButton_Click);
            // 
            // cancelEditButton
            // 
            this.cancelEditButton.Location = new System.Drawing.Point(222, 240);
            this.cancelEditButton.Name = "cancelEditButton";
            this.cancelEditButton.Size = new System.Drawing.Size(81, 32);
            this.cancelEditButton.TabIndex = 8;
            this.cancelEditButton.Text = "Cancel";
            this.cancelEditButton.UseVisualStyleBackColor = true;
            this.cancelEditButton.Click += new System.EventHandler(this.CancelEditButton_Click);
            // 
            // editTaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(332, 284);
            this.Controls.Add(this.cancelEditButton);
            this.Controls.Add(this.saveEditButton);
            this.Controls.Add(this.editTaskBox);
            this.Controls.Add(this.editTaskNamelabel);
            this.Controls.Add(this.editTagBox);
            this.Controls.Add(this.editTagLabel);
            this.Controls.Add(this.editDateTimePicker);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.editTaskTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "editTaskForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label editTaskTitle;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label editTagLabel;
        private System.Windows.Forms.Label editTaskNamelabel;
        private System.Windows.Forms.Button saveEditButton;
        private System.Windows.Forms.Button cancelEditButton;
        public System.Windows.Forms.DateTimePicker editDateTimePicker;
        public System.Windows.Forms.ComboBox editTagBox;
        public System.Windows.Forms.TextBox editTaskBox;
    }
}