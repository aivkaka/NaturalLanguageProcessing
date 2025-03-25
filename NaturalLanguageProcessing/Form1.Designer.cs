namespace NaturalLanguageProcessing
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            groupBox1 = new GroupBox();
            textBox2 = new TextBox();
            label2 = new Label();
            listView2 = new ListView();
            button3 = new Button();
            treeView1 = new TreeView();
            listView1 = new ListView();
            button2 = new Button();
            columnHeader1 = new ColumnHeader();
            序号 = new ColumnHeader();
            groupBox2 = new GroupBox();
            textBox5 = new TextBox();
            label3 = new Label();
            button4 = new Button();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            groupBox3 = new GroupBox();
            richTextBox1 = new RichTextBox();
            button6 = new Button();
            comboBox1 = new ComboBox();
            label5 = new Label();
            button5 = new Button();
            textBox8 = new TextBox();
            groupBox4 = new GroupBox();
            richTextBox2 = new RichTextBox();
            textBox6 = new TextBox();
            label8 = new Label();
            button8 = new Button();
            button7 = new Button();
            label7 = new Label();
            label6 = new Label();
            label4 = new Label();
            textBox7 = new TextBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1074, 120);
            label1.Name = "label1";
            label1.Size = new Size(0, 31);
            label1.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(17, 37);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(537, 76);
            textBox1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(404, 132);
            button1.Name = "button1";
            button1.Size = new Size(150, 46);
            button1.TabIndex = 2;
            button1.Text = "词法分析";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(listView2);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(treeView1);
            groupBox1.Controls.Add(listView1);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(button1);
            groupBox1.Location = new Point(12, 23);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(567, 1039);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "词法分析/依存句法分析/DNN语言模型";
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.ControlDark;
            textBox2.Location = new Point(154, 728);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(157, 38);
            textBox2.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 728);
            label2.Name = "label2";
            label2.Size = new Size(134, 31);
            label2.TabIndex = 9;
            label2.Text = "句子通顺值";
            // 
            // listView2
            // 
            listView2.Enabled = false;
            listView2.Location = new Point(17, 797);
            listView2.Name = "listView2";
            listView2.Size = new Size(537, 218);
            listView2.TabIndex = 8;
            listView2.UseCompatibleStateImageBehavior = false;
            listView2.View = View.Details;
            // 
            // button3
            // 
            button3.Location = new Point(360, 720);
            button3.Name = "button3";
            button3.Size = new Size(194, 46);
            button3.TabIndex = 7;
            button3.Text = "DNN语言模型";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // treeView1
            // 
            treeView1.Location = new Point(17, 485);
            treeView1.Name = "treeView1";
            treeView1.ShowLines = false;
            treeView1.Size = new Size(537, 211);
            treeView1.TabIndex = 6;
            // 
            // listView1
            // 
            listView1.Enabled = false;
            listView1.Location = new Point(17, 200);
            listView1.Name = "listView1";
            listView1.Size = new Size(537, 205);
            listView1.TabIndex = 5;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // button2
            // 
            button2.Location = new Point(360, 421);
            button2.Name = "button2";
            button2.Size = new Size(194, 46);
            button2.TabIndex = 4;
            button2.Text = "依存句法分析";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(textBox5);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(button4);
            groupBox2.Controls.Add(textBox4);
            groupBox2.Controls.Add(textBox3);
            groupBox2.Location = new Point(602, 23);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(747, 341);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "短文本相似度";
            // 
            // textBox5
            // 
            textBox5.BackColor = SystemColors.ControlDark;
            textBox5.Location = new Point(555, 276);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(172, 38);
            textBox5.TabIndex = 11;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(472, 276);
            label3.Name = "label3";
            label3.Size = new Size(62, 31);
            label3.TabIndex = 3;
            label3.Text = "结果";
            // 
            // button4
            // 
            button4.Location = new Point(273, 276);
            button4.Name = "button4";
            button4.Size = new Size(178, 46);
            button4.TabIndex = 2;
            button4.Text = "短文本相似度";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(407, 53);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(320, 195);
            textBox4.TabIndex = 1;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(19, 53);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(320, 195);
            textBox3.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(richTextBox1);
            groupBox3.Controls.Add(button6);
            groupBox3.Controls.Add(comboBox1);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(button5);
            groupBox3.Controls.Add(textBox8);
            groupBox3.Location = new Point(602, 397);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(747, 665);
            groupBox3.TabIndex = 12;
            groupBox3.TabStop = false;
            groupBox3.Text = "评论观点抽取";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(19, 231);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(708, 410);
            richTextBox1.TabIndex = 15;
            richTextBox1.Text = "";
            // 
            // button6
            // 
            button6.Location = new Point(515, 162);
            button6.Name = "button6";
            button6.Size = new Size(212, 46);
            button6.TabIndex = 14;
            button6.Text = "情感倾向分析";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "酒店", "KTV", "丽人", "美食餐饮", "旅游", "健康", "教育", "商业", "房产", "汽车", "生活", "购物", "3C" });
            comboBox1.Location = new Point(87, 169);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(167, 39);
            comboBox1.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(19, 172);
            label5.Name = "label5";
            label5.Size = new Size(62, 31);
            label5.TabIndex = 12;
            label5.Text = "行业";
            // 
            // button5
            // 
            button5.Location = new Point(288, 164);
            button5.Name = "button5";
            button5.Size = new Size(212, 46);
            button5.TabIndex = 2;
            button5.Text = "评论观点抽取";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // textBox8
            // 
            textBox8.Location = new Point(19, 53);
            textBox8.Multiline = true;
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(708, 93);
            textBox8.TabIndex = 0;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(richTextBox2);
            groupBox4.Controls.Add(textBox6);
            groupBox4.Controls.Add(label8);
            groupBox4.Controls.Add(button8);
            groupBox4.Controls.Add(button7);
            groupBox4.Controls.Add(label7);
            groupBox4.Controls.Add(label6);
            groupBox4.Controls.Add(label4);
            groupBox4.Controls.Add(textBox7);
            groupBox4.Location = new Point(1372, 36);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(529, 1026);
            groupBox4.TabIndex = 11;
            groupBox4.TabStop = false;
            groupBox4.Text = "文章标签/文章分类";
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(26, 647);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(488, 355);
            richTextBox2.TabIndex = 16;
            richTextBox2.Text = "";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(17, 197);
            textBox6.Multiline = true;
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(497, 310);
            textBox6.TabIndex = 12;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(26, 607);
            label8.Name = "label8";
            label8.Size = new Size(168, 31);
            label8.TabIndex = 18;
            label8.Text = "标签/分类结果";
            // 
            // button8
            // 
            button8.Location = new Point(318, 530);
            button8.Name = "button8";
            button8.Size = new Size(196, 46);
            button8.TabIndex = 17;
            button8.Text = "文章分类";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button7
            // 
            button7.Location = new Point(17, 530);
            button7.Name = "button7";
            button7.Size = new Size(202, 46);
            button7.TabIndex = 16;
            button7.Text = "文章标签";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(17, 154);
            label7.Name = "label7";
            label7.Size = new Size(110, 31);
            label7.TabIndex = 12;
            label7.Text = "文章内容";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(17, 43);
            label6.Name = "label6";
            label6.Size = new Size(110, 31);
            label6.TabIndex = 11;
            label6.Text = "文章标题";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 728);
            label4.Name = "label4";
            label4.Size = new Size(0, 31);
            label4.TabIndex = 9;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(17, 84);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(497, 38);
            textBox7.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1913, 1087);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "自然语言处理演示程序";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Button button1;
        private GroupBox groupBox1;
        private Button button2;
        private ListView listView1;
        private ColumnHeader 序号;
        private ListView listView2;
        private ColumnHeader columnHeader1;
        private Button button3;
        private TreeView treeView1;
        private Label label2;
        private TextBox textBox2;
        private GroupBox groupBox2;
        private TextBox textBox5;
        private Label label3;
        private Button button4;
        private TextBox textBox4;
        private TextBox textBox3;
        private GroupBox groupBox3;
        private Button button5;
        private TextBox textBox8;
        private Button button6;
        private ComboBox comboBox1;
        private Label label5;
        private RichTextBox richTextBox1;
        private GroupBox groupBox4;
        private Label label7;
        private Label label6;
        private Label label4;
        private TextBox textBox7;
        private Button button8;
        private Button button7;
        private Label label8;
        private TextBox textBox6;
        private RichTextBox richTextBox2;
    }
}
