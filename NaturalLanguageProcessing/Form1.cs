using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Linq;
using Baidu.Aip;
using Newtonsoft.Json.Linq;
using static System.Windows.Forms.Design.AxImporter;

namespace NaturalLanguageProcessing
{
    public partial class Form1 : Form
    {
        private static readonly string API_KEY = "Myqy0ljyiJpYlVXJr4fBJNaw";
        private static readonly string SECRET_KEY = "sBAEETipYCZyGw7lFQULba9mRj9Gmy9q";
        JObject res = null;

        #region ���
        // ���Ա�
        private readonly Dictionary<string, string> POSTable =
            new Dictionary<string, string>() {{"a", "���ݴ�"},
                                               {"ad", "���δ�"},
                                               {"ag", "������"},
                                               {"an", "���δ�"},
                                               {"b", "�����"},
                                               {"c", "����"},
                                               {"d", "����"},
                                               {"dg", "������"},
                                               {"e", "̾��"},
                                               {"f", "��λ����"},
                                               {"g", "����"},
                                               {"h", "ǰ�ӳɷ�"},
                                               {"i", "����"},
                                               {"j", "�������"},
                                               {"k", "��ӳɷ�"},
                                               {"l", "ϰ����"},
                                               {"m", "������"},
                                               {"n", "��ͨ����"},
                                               {"ng", "������"},
                                               {"nr", "����"},
                                               {"ns", "����"},
                                               {"nt", "����������"},
                                               {"nw", "��Ʒ��"},
                                               {"nz", "����ר��"},
                                               {"o", "������"},
                                               {"p", "���"},
                                               {"q", "����"},
                                               {"r", "����"},
                                               {"s", "��������"},
                                               {"t", "ʱ������"},
                                               {"tg", "ʱ����"},
                                               {"u", "����"},
                                               {"un","δ֪��"},
                                               {"v", "��ͨ����"},
                                               {"vd", "������"},
                                               {"vg", "������"},
                                               {"vn", "������"},
                                               {"w", "������"},
                                               {"x", "��������"},
                                               {"xc", "�������"},
                                               {"y", "������"},
                                               {"z", "״̬��"},
                                               {"PER", "����"},
                                               {"LOC", "����"},
                                               {"ORG", "������"},
                                               {"TIME", "ʱ��"},
                                               {"","/"}};

        // ר����д��
        private readonly Dictionary<string, string> NETable =
            new Dictionary<string, string>() {{"PER", "����"},
                                               {"LOC", "����"},
                                               {"ORG", "������"},
                                               {"TIME", "ʱ��"},
                                               {"","/"}};

        // �����ϵ��д
        private readonly Dictionary<string, string> DEPRELTable =
            new Dictionary<string, string>() {{"SBV", "��ν��ϵ"},
                                               {"VOB", "������ϵ"},
                                               {"POB", "�����ϵ"},
                                               {"ADV", "״�й�ϵ"},
                                               {"CMP", "������ϵ"},
                                               {"ATT", "���й�ϵ"},
                                               {"F", "��λ��ϵ"},
                                               {"COO", "���й�ϵ"},
                                               {"DBL", "����ṹ"},
                                               {"DOB", "˫����ṹ"},
                                               {"VV", "��ν�ṹ"},
                                               {"IC", "�Ӿ�ṹ"},
                                               {"MT", "��ʳɷ�"},
                                               {"HED", "���Ĺ�ϵ"},
                                               {"",""}};
        // ��ҵӳ��
        private readonly Dictionary<string, string> INDUSTRYTable =
            new Dictionary<string, string>() {{"�Ƶ�", "1"},
                                               {"KTV", "2"},
                                               {"����", "3"},
                                               {"��ʳ����", "4"},
                                               {"����", "5"},
                                               {"����", "6"},
                                               {"����", "7"},
                                               {"��ҵ", "8"},
                                               {"����", "9"},
                                               {"����", "10"},
                                               {"����", "11"},
                                               {"����", "12"},
                                               {"3C", "13"}};
        // ��д���
        private readonly Dictionary<string, string> EMOTIONTable =
            new Dictionary<string, string>() {{"0", "����"},
                                               {"1", "����"},
                                               {"2", "����"}};

        #endregion


        public Form1()
        {
            // ע������ṩ����
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.Columns.Add("���", 60);
            listView1.Columns.Add("�ִ�", 150);
            listView1.Columns.Add("����", 150);
            listView1.Columns.Add("������", 150);
            listView2.View = View.Details;
            listView2.Columns.Add("���", 60);
            listView2.Columns.Add("�ִ�", 150);
            listView2.Columns.Add("����ֵ", 200);
            comboBox1.Text = "��ʳ����";
            richTextBox1.ScrollBars = (RichTextBoxScrollBars)ScrollBars.Vertical;
        }

        //����ǰУ��ͷ������
        private Boolean checkAndInit(int max, string text, string obj = "")
        {
            //�ǿ�У��
            if (text == string.Empty)
            {
                MessageBox.Show("������" + obj + "�ı���");
                return false;
            }
            //У���ı�����
            Encoding gbkEncoding = Encoding.GetEncoding("GBK");
            int byteCount = gbkEncoding.GetByteCount(text);
            MessageBox.Show(byteCount.ToString());
            if (byteCount > max)
            {
                MessageBox.Show(obj + "�ı�̫�������ܳ���" + max + "�ֽڣ�");
                return false;
            }
            return true;
        }

        //�ʷ�����
        private void button1_Click(object sender, EventArgs e)
        {
            Boolean flag = checkAndInit(20000, textBox1.Text.Trim());
            if (!flag)
            {
                return;
            }
            //���÷���
            var client = new Baidu.Aip.Nlp.Nlp(API_KEY, SECRET_KEY);
            try
            {
                res = client.Lexer(textBox1.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("�ʷ�������������: " + ex.Message);
                return;
            }

            listView1.Items.Clear();
            //�ʷ��������
            int i = 1;
            foreach (var item in res["items"])
            {
                string word = item["item"].ToString(); // �ִ�
                string pos = POSTable[item["pos"].ToString()];   // ����
                string basicWord = item["basic_words"][0].ToString(); // ������

                var listViewItem = new ListViewItem(i.ToString()); // ���
                listViewItem.SubItems.Add(word);
                listViewItem.SubItems.Add(pos);
                listViewItem.SubItems.Add(basicWord);

                // ��ӵ� ListView
                listView1.Items.Add(listViewItem);
                i++;
            }

        }

        //����䷨����
        private void button2_Click(object sender, EventArgs e)
        {
            Boolean flag = checkAndInit(128, textBox1.Text.Trim());
            if (!flag)
            {
                return;
            }
            //���÷���
            var client = new Baidu.Aip.Nlp.Nlp(API_KEY, SECRET_KEY);
            try
            {
                res = client.Depparser(textBox1.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("����䷨������������: " + ex.Message);
                return;
            }
            List<JToken> items = res["items"].ToList();
            //���ҵ����ڵ�
            var rootNodes = items.Where(item => item["head"].ToString() == "0").ToList();
            var rootNode = rootNodes.First();
            var treeRoot = new TreeNode($"{rootNode["word"]} ({DEPRELTable[rootNode["deprel"].ToString()]})");

            // �ݹ鹹������
            AddChildren(treeRoot, rootNode["id"].ToString(), items);
            treeView1.Nodes.Add(treeRoot);
            treeView1.ExpandAll();
        }

        private void AddChildren(TreeNode parentNode, string parentId, List<JToken> items)
        {
            var children = items.Where(item => item["head"].ToString() == parentId).ToList();
            if (children.Count > 0)
            {
                foreach (var child in children)
                {
                    var treeNode = new TreeNode($"{child["word"]} ({DEPRELTable[child["deprel"].ToString()]})");
                    parentNode.Nodes.Add(treeNode);

                    // �ݹ�����ӽڵ�
                    AddChildren(treeNode, child["id"].ToString(), items);
                }
            }

        }
        //DNN����ģ��
        private void button3_Click(object sender, EventArgs e)
        {
            Boolean flag = checkAndInit(20000, textBox1.Text.Trim());
            if (!flag)
            {
                return;
            }
            //���÷���
            var client = new Baidu.Aip.Nlp.Nlp(API_KEY, SECRET_KEY);
            try
            {
                res = client.DnnlmCn(textBox1.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("DNN����ģ�ͷ�����������: " + ex.Message);
                return;
            }
            textBox2.Text = res["ppl"].ToString();
            int i = 1;
            foreach (var item in res["items"])
            {
                string word = item["word"].ToString(); // �ִ�
                string prob = item["prob"].ToString(); // ����ֵ
                var listViewItem = new ListViewItem(i.ToString()); // ���
                listViewItem.SubItems.Add(word);
                listViewItem.SubItems.Add(prob);

                // ��ӵ� ListView
                listView2.Items.Add(listViewItem);
                i++;
            }
        }

        //���ı����ƶ�
        private void button4_Click(object sender, EventArgs e)
        {
            Boolean flag = checkAndInit(512, textBox3.Text.Trim());
            if (!flag)
            {
                return;
            }
            flag = checkAndInit(512, textBox4.Text.Trim());
            if (!flag)
            {
                return;
            }
            var client = new Baidu.Aip.Nlp.Nlp(API_KEY, SECRET_KEY);
            try
            {
                res = client.Simnet(textBox3.Text.Trim(), textBox4.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("�ı����ƶȷ�����������: " + ex.Message);
                return;
            }
            textBox5.Text = res["score"].ToString();
        }

        //���۹۵��ȡ
        private void button5_Click(object sender, EventArgs e)
        {
            Boolean flag = checkAndInit(10240, textBox8.Text.Trim());
            if (!flag)
            {
                return;
            }
            var client = new Baidu.Aip.Nlp.Nlp(API_KEY, SECRET_KEY);
            var options = new Dictionary<string, object>
            {
                { "type" , int.Parse(INDUSTRYTable[comboBox1.Text]) }
            };
            try
            {
                res = client.CommentTag(textBox8.Text.Trim(), options);
                //MessageBox.Show(res.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("���۹۵��ȡ��������: " + ex.Message);
                return;
            }
            richTextBox1.Text = "";
            foreach (var item in res["items"])
            {
                richTextBox1.Text += "�۵�����" + EMOTIONTable[item["sentiment"].ToString()] + "\n";
                richTextBox1.Text += "�̾�ժҪ��" + item["abstract"] + "\n";
                richTextBox1.Text += "ƥ�����Դʣ�" + item["prop"] + "\n";
                richTextBox1.Text += "ƥ�������ʣ�" + item["adj"] + "\n";
                richTextBox1.Text += "---------------------------------------\n";
            }
            richTextBox1.Text = richTextBox1.Text.Replace("<span>", "[");
            richTextBox1.Text = richTextBox1.Text.Replace("</span>", "]");
            richTextBox1.Text = richTextBox1.Text.Replace("[]", "");
        }


        //����������
        private void button6_Click(object sender, EventArgs e)
        {
            Boolean flag = checkAndInit(2048, textBox8.Text.Trim());
            if (!flag)
            {
                return;
            }
            var client = new Baidu.Aip.Nlp.Nlp(API_KEY, SECRET_KEY);
            try
            {
                res = client.SentimentClassify(textBox8.Text.Trim());
                //MessageBox.Show(res.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("������������������: " + ex.Message);
                return;
            }
            richTextBox1.Text = "";
            foreach (var item in res["items"])
            {
                richTextBox1.Text += "��м��Է�������" + EMOTIONTable[item["sentiment"].ToString()] + "\n";
                richTextBox1.Text += "��������Ŷȣ�" + item["confidence"].ToString() + "\n";
                richTextBox1.Text += "���ڻ������ĸ��ʣ�" + item["positive_prob"].ToString() + "\n";
                richTextBox1.Text += "�����������ĸ��ʣ�" + item["negative_prob"].ToString() + "\n";
                richTextBox1.Text += "---------------------------------------\n";
            }
        }

        //���±�ǩ
        private void button7_Click(object sender, EventArgs e)
        {
            Boolean flag = checkAndInit(80, textBox7.Text.Trim(), "���±���");
            if (!flag)
            {
                return;
            }
            flag = checkAndInit(65535, textBox6.Text.Trim(), "��������");
            if (!flag)
            {
                return;
            }
            var client = new Baidu.Aip.Nlp.Nlp(API_KEY, SECRET_KEY);
            try
            {
                res = client.Keyword(textBox7.Text.Trim(), textBox6.Text.Trim());
                //MessageBox.Show(res.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("���±�ǩ��ȡ��������: " + ex.Message);
                return;
            }
            richTextBox2.Text = "";
            foreach (var item in res["items"])
            {
                richTextBox2.Text += item["tag"] + ":" + item["score"].ToString() + "\n";
            }
            //MessageBox.Show(richTextBox2.Text);

        }

        //���·���
        private void button8_Click(object sender, EventArgs e)
        {
            Boolean flag = checkAndInit(80, textBox7.Text.Trim(), "���±���");
            if (!flag)
            {
                return;
            }
            flag = checkAndInit(65535, textBox6.Text.Trim(), "��������");
            if (!flag)
            {
                return;
            }
            var client = new Baidu.Aip.Nlp.Nlp(API_KEY, SECRET_KEY);
            try
            {
                res = client.Topic(textBox7.Text.Trim(), textBox6.Text.Trim());
                //MessageBox.Show(res.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("���·��෢������: " + ex.Message);
                return;
            }
            richTextBox2.Text = "һ��������(����/Ȩ��):\n      " + res["item"]["lv1_tag_list"][0]["tag"] + ":" + res["item"]["lv1_tag_list"][0]["score"].ToString() + "\n����������(����/Ȩ��)��\n";
            foreach (var item in res["item"]["lv2_tag_list"])
            {
                richTextBox2.Text += "      " + item["tag"] + ":" + item["score"].ToString() + "\n";
            }
        }
    }

}


      