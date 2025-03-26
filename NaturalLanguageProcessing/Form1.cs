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

        #region 查表
        // 词性表
        private readonly Dictionary<string, string> POSTable =
            new Dictionary<string, string>() {{"a", "形容词"},
                                               {"ad", "副形词"},
                                               {"ag", "形语素"},
                                               {"an", "名形词"},
                                               {"b", "区别词"},
                                               {"c", "连词"},
                                               {"d", "副词"},
                                               {"dg", "副语素"},
                                               {"e", "叹词"},
                                               {"f", "方位名词"},
                                               {"g", "语素"},
                                               {"h", "前接成分"},
                                               {"i", "成语"},
                                               {"j", "简称略语"},
                                               {"k", "后接成分"},
                                               {"l", "习惯语"},
                                               {"m", "数量词"},
                                               {"n", "普通名词"},
                                               {"ng", "名语素"},
                                               {"nr", "人名"},
                                               {"ns", "地名"},
                                               {"nt", "机构团体名"},
                                               {"nw", "作品名"},
                                               {"nz", "其他专名"},
                                               {"o", "拟声词"},
                                               {"p", "介词"},
                                               {"q", "量词"},
                                               {"r", "代词"},
                                               {"s", "处所名词"},
                                               {"t", "时间名词"},
                                               {"tg", "时语素"},
                                               {"u", "助词"},
                                               {"un","未知词"},
                                               {"v", "普通动词"},
                                               {"vd", "动副词"},
                                               {"vg", "动语素"},
                                               {"vn", "动名词"},
                                               {"w", "标点符号"},
                                               {"x", "非语素字"},
                                               {"xc", "其他虚词"},
                                               {"y", "语气词"},
                                               {"z", "状态词"},
                                               {"PER", "人名"},
                                               {"LOC", "地名"},
                                               {"ORG", "机构名"},
                                               {"TIME", "时间"},
                                               {"","/"}};

        // 专名缩写表
        private readonly Dictionary<string, string> NETable =
            new Dictionary<string, string>() {{"PER", "人名"},
                                               {"LOC", "地名"},
                                               {"ORG", "机构名"},
                                               {"TIME", "时间"},
                                               {"","/"}};

        // 依存关系缩写
        private readonly Dictionary<string, string> DEPRELTable =
            new Dictionary<string, string>() {{"SBV", "主谓关系"},
                                               {"VOB", "动宾关系"},
                                               {"POB", "介宾关系"},
                                               {"ADV", "状中关系"},
                                               {"CMP", "动补关系"},
                                               {"ATT", "定中关系"},
                                               {"F", "方位关系"},
                                               {"COO", "并列关系"},
                                               {"DBL", "兼语结构"},
                                               {"DOB", "双宾语结构"},
                                               {"VV", "连谓结构"},
                                               {"IC", "子句结构"},
                                               {"MT", "虚词成分"},
                                               {"HED", "核心关系"},
                                               {"",""}};
        // 行业映射
        private readonly Dictionary<string, string> INDUSTRYTable =
            new Dictionary<string, string>() {{"酒店", "1"},
                                               {"KTV", "2"},
                                               {"丽人", "3"},
                                               {"美食餐饮", "4"},
                                               {"旅游", "5"},
                                               {"健康", "6"},
                                               {"教育", "7"},
                                               {"商业", "8"},
                                               {"房产", "9"},
                                               {"汽车", "10"},
                                               {"生活", "11"},
                                               {"购物", "12"},
                                               {"3C", "13"}};
        // 情感搭配
        private readonly Dictionary<string, string> EMOTIONTable =
            new Dictionary<string, string>() {{"0", "消极"},
                                               {"1", "中性"},
                                               {"2", "积极"}};

        #endregion


        public Form1()
        {
            // 注册编码提供程序
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.Columns.Add("序号", 60);
            listView1.Columns.Add("分词", 150);
            listView1.Columns.Add("词性", 150);
            listView1.Columns.Add("基本词", 150);
            listView2.View = View.Details;
            listView2.Columns.Add("序号", 60);
            listView2.Columns.Add("分词", 150);
            listView2.Columns.Add("概率值", 200);
            comboBox1.Text = "美食餐饮";
            richTextBox1.ScrollBars = (RichTextBoxScrollBars)ScrollBars.Vertical;
        }

        //功能前校验和服务调用
        private Boolean checkAndInit(int max, string text, string obj = "")
        {
            //非空校验
            if (text == string.Empty)
            {
                MessageBox.Show("请输入" + obj + "文本！");
                return false;
            }
            //校验文本长度
            Encoding gbkEncoding = Encoding.GetEncoding("GBK");
            int byteCount = gbkEncoding.GetByteCount(text);
            MessageBox.Show(byteCount.ToString());
            if (byteCount > max)
            {
                MessageBox.Show(obj + "文本太长，不能超过" + max + "字节！");
                return false;
            }
            return true;
        }

        //词法分析
        private void button1_Click(object sender, EventArgs e)
        {
            Boolean flag = checkAndInit(20000, textBox1.Text.Trim());
            if (!flag)
            {
                return;
            }
            //调用服务
            var client = new Baidu.Aip.Nlp.Nlp(API_KEY, SECRET_KEY);
            try
            {
                res = client.Lexer(textBox1.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("词法分析发生错误: " + ex.Message);
                return;
            }

            listView1.Items.Clear();
            //词法分析结果
            int i = 1;
            foreach (var item in res["items"])
            {
                string word = item["item"].ToString(); // 分词
                string pos = POSTable[item["pos"].ToString()];   // 词性
                string basicWord = item["basic_words"][0].ToString(); // 基本词

                var listViewItem = new ListViewItem(i.ToString()); // 序号
                listViewItem.SubItems.Add(word);
                listViewItem.SubItems.Add(pos);
                listViewItem.SubItems.Add(basicWord);

                // 添加到 ListView
                listView1.Items.Add(listViewItem);
                i++;
            }

        }

        //依存句法分析
        private void button2_Click(object sender, EventArgs e)
        {
            Boolean flag = checkAndInit(128, textBox1.Text.Trim());
            if (!flag)
            {
                return;
            }
            //调用服务
            var client = new Baidu.Aip.Nlp.Nlp(API_KEY, SECRET_KEY);
            try
            {
                res = client.Depparser(textBox1.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("依存句法分析发生错误: " + ex.Message);
                return;
            }
            List<JToken> items = res["items"].ToList();
            //先找到根节点
            var rootNodes = items.Where(item => item["head"].ToString() == "0").ToList();
            var rootNode = rootNodes.First();
            var treeRoot = new TreeNode($"{rootNode["word"]} ({DEPRELTable[rootNode["deprel"].ToString()]})");

            // 递归构建子树
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

                    // 递归添加子节点
                    AddChildren(treeNode, child["id"].ToString(), items);
                }
            }

        }
        //DNN语言模型
        private void button3_Click(object sender, EventArgs e)
        {
            Boolean flag = checkAndInit(20000, textBox1.Text.Trim());
            if (!flag)
            {
                return;
            }
            //调用服务
            var client = new Baidu.Aip.Nlp.Nlp(API_KEY, SECRET_KEY);
            try
            {
                res = client.DnnlmCn(textBox1.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("DNN语言模型分析发生错误: " + ex.Message);
                return;
            }
            textBox2.Text = res["ppl"].ToString();
            int i = 1;
            foreach (var item in res["items"])
            {
                string word = item["word"].ToString(); // 分词
                string prob = item["prob"].ToString(); // 概率值
                var listViewItem = new ListViewItem(i.ToString()); // 序号
                listViewItem.SubItems.Add(word);
                listViewItem.SubItems.Add(prob);

                // 添加到 ListView
                listView2.Items.Add(listViewItem);
                i++;
            }
        }

        //短文本相似度
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
                MessageBox.Show("文本相似度分析发生错误: " + ex.Message);
                return;
            }
            textBox5.Text = res["score"].ToString();
        }

        //评论观点抽取
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
                MessageBox.Show("评论观点抽取发生错误: " + ex.Message);
                return;
            }
            richTextBox1.Text = "";
            foreach (var item in res["items"])
            {
                richTextBox1.Text += "观点倾向：" + EMOTIONTable[item["sentiment"].ToString()] + "\n";
                richTextBox1.Text += "短句摘要：" + item["abstract"] + "\n";
                richTextBox1.Text += "匹配属性词：" + item["prop"] + "\n";
                richTextBox1.Text += "匹配描述词：" + item["adj"] + "\n";
                richTextBox1.Text += "---------------------------------------\n";
            }
            richTextBox1.Text = richTextBox1.Text.Replace("<span>", "[");
            richTextBox1.Text = richTextBox1.Text.Replace("</span>", "]");
            richTextBox1.Text = richTextBox1.Text.Replace("[]", "");
        }


        //情感倾向分析
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
                MessageBox.Show("情感倾向分析发生错误: " + ex.Message);
                return;
            }
            richTextBox1.Text = "";
            foreach (var item in res["items"])
            {
                richTextBox1.Text += "情感极性分类结果：" + EMOTIONTable[item["sentiment"].ToString()] + "\n";
                richTextBox1.Text += "分类的置信度：" + item["confidence"].ToString() + "\n";
                richTextBox1.Text += "属于积极类别的概率：" + item["positive_prob"].ToString() + "\n";
                richTextBox1.Text += "属于消极类别的概率：" + item["negative_prob"].ToString() + "\n";
                richTextBox1.Text += "---------------------------------------\n";
            }
        }

        //文章标签
        private void button7_Click(object sender, EventArgs e)
        {
            Boolean flag = checkAndInit(80, textBox7.Text.Trim(), "文章标题");
            if (!flag)
            {
                return;
            }
            flag = checkAndInit(65535, textBox6.Text.Trim(), "文章内容");
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
                MessageBox.Show("文章标签获取发生错误: " + ex.Message);
                return;
            }
            richTextBox2.Text = "";
            foreach (var item in res["items"])
            {
                richTextBox2.Text += item["tag"] + ":" + item["score"].ToString() + "\n";
            }
            //MessageBox.Show(richTextBox2.Text);

        }

        //文章分类
        private void button8_Click(object sender, EventArgs e)
        {
            Boolean flag = checkAndInit(80, textBox7.Text.Trim(), "文章标题");
            if (!flag)
            {
                return;
            }
            flag = checkAndInit(65535, textBox6.Text.Trim(), "文章内容");
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
                MessageBox.Show("文章分类发生错误: " + ex.Message);
                return;
            }
            richTextBox2.Text = "一级分类结果(名称/权重):\n      " + res["item"]["lv1_tag_list"][0]["tag"] + ":" + res["item"]["lv1_tag_list"][0]["score"].ToString() + "\n二级分类结果(名称/权重)：\n";
            foreach (var item in res["item"]["lv2_tag_list"])
            {
                richTextBox2.Text += "      " + item["tag"] + ":" + item["score"].ToString() + "\n";
            }
        }
    }

}


      