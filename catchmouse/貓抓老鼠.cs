using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace catchmouse
{
    public partial class 貓抓老鼠 : Form
    {
        public 貓抓老鼠()
        {
            InitializeComponent();
            this.Load+=new EventHandler(Form2_Load);
            this.BackColor = Color.LightSkyBlue;
            
            
        }
        protected void Form2_Load(object sender,EventArgs e)
        {
            Button newButton = new Button();
            newButton.Text = "Select";// 設定按鈕上顯示的文字
            newButton.Location = new Point(50, 200);// 設定按鈕在視窗中的位置
            newButton.Size = new Size(50, 50);
            newButton.BackColor = Color.Red;
            this.Controls.Add(newButton);// 將按鈕新增到 Form 中
            newButton.Click += new EventHandler(button_Click);
            PictureBox welcome = new PictureBox();
            welcome.Image = Image.FromFile("C:\\Users\\012614\\source\\repos\\catchmouse\\catchmouse\\image\\歡迎光臨.png");
            welcome.SizeMode = PictureBoxSizeMode.StretchImage;// 将图像缩放以适应 PictureBox 大小
            welcome.Size = new Size(350,350);
            welcome.Location = new Point(210, 50);
            this.Controls.Add(welcome);
        }
        private void button_Click(object sender,EventArgs e)
        {
            Form messageForm = new Form();
            messageForm.Size = new Size(300,200);
            messageForm.StartPosition = FormStartPosition.CenterParent;//显示该窗体时，它会相对于父窗体的中心位置进行定位

            Label label = new Label();
            label.Text = "請選擇挑戰難度:";
            label.Location = new Point(10,10);
            messageForm.Controls.Add(label);

            Button button1 = new Button();
            button1.Text = "速度10";
            button1.Location = new Point(110,60);
            button1.Size = new Size(100,30);
            button1.Click += (s, args) => messageForm.Close();
            button1.Click += new EventHandler(button1_Click);
            messageForm.Controls.Add(button1);
            Button button2 = new Button();
            button2.Text = "速度100";
            button2.Location = new Point(110, 95);
            button2.Size = new Size(100, 30);
            button2.Click += (s, args) => messageForm.Close();
            button2.Click += new EventHandler(button2_Click);
            messageForm.Controls.Add(button2);
            messageForm.ShowDialog();
            

        }
        private void button1_Click(object sender,EventArgs e)
        {
            // 关闭当前的 Form2
            this.Hide();
            // 新增現有的Form1實例
            速度10 form1 = new 速度10();

            //关闭 Form2 当 Form1 关闭时
            form1.FormClosed += (s, args) => this.Close();
            form1.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            // 关闭当前的 Form2
            this.Hide();
            // 新增現有的Form1實例
            速度100 form3 = new 速度100();

            //关闭 Form2 当 Form1 关闭时
            form3.FormClosed += (s, args) => this.Close();
            form3.Show();
        }
    }
}
