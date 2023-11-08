using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace catchmouse
{
    public partial class 速度10 : Form
    {
        private PictureBox cat;
        private PictureBox mouse;
        private System.Windows.Forms.Timer timerMouseMovement;//是 Windows 窗体应用程序中用于处理定时器功能的类
        // 假设mouseSpeedX和mouseSpeedY分别是老鼠在X和Y方向上的移动速度(初始速度)
        Random random = new Random();
        int mouseSpeedX = 10;
        int mouseSpeedY = 10;
        
        public 速度10()
        {
            InitializeComponent();
            InitializeGame();
            this.Load += new EventHandler(Form1_Load);// 将Form1_Load方法与窗体的Load事件相关联
            //初始化timerMouseMovement對象
            timerMouseMovement = new System.Windows.Forms.Timer();
            timerMouseMovement.Interval = 1000;// 设置定时器间隔，单位为毫秒，1000 毫秒（即 1 秒）触发一次 Tick 事件
            timerMouseMovement.Tick += new EventHandler(timerMouseMovement_Tick);// 将定时器事件处理程序关联到事件
            timerMouseMovement.Start();// 启动定时器
        }
        private void InitializeGame()
        {
            // 创建猫
            cat = new PictureBox();
            cat.Image = Image.FromFile("C:\\Users\\012614\\source\\repos\\catchmouse\\catchmouse\\image\\cat.jpg"); // 请确保图片存在于相应位置
            cat.SizeMode = PictureBoxSizeMode.StretchImage;
            cat.Size = new Size(50, 50);
            cat.Location = new Point(50, 50);
            this.Controls.Add(cat);

            // 创建老鼠
            mouse = new PictureBox();
            mouse.Image = Image.FromFile("C:/Users/012614/source/repos/catchmouse/catchmouse/image/mouse.jpg"); // 请确保图片存在于相应位置
            mouse.SizeMode = PictureBoxSizeMode.StretchImage;//设置了 PictureBox 控件中图像的显示方式为拉伸（StretchImage），Zoom為壓縮
            mouse.Size = new Size(30, 30);

            //生成隨機位置
            
            int maxX = this.ClientSize.Width - mouse.Width;
            int maxY = this.ClientSize.Height - mouse.Height;
            int randomX = random.Next(0, maxX);
            int randomY = random.Next(0, maxY); 

            //設置老鼠隨機位置
            mouse.Location = new Point(randomX, randomY);
            this.Controls.Add(mouse);


            // 添加键盘事件
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            this.Focus();//用户可以直接与窗体交互，而不需要先点击窗体才能开始使用键盘
        }
        private void Form1_Load(object sender,EventArgs e)
        {
            this.BackgroundImage = Image.FromFile("C:\\Users\\012614\\source\\repos\\catchmouse\\catchmouse\\image\\背景.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;// 设置图片布局，可根据需要调整
            
        }
        private void timerMouseMovement_Tick(object sender, EventArgs e)
        {
            //以一定概率改變速度方向
            if(random.Next(100)<20) //例如、20%概率改變方向
            {
                mouseSpeedX = random.Next(-5, 6);//隨機X方向速度
                mouseSpeedY = random.Next(-5, 6);//隨機Y方向速度
            }
            
            // 更新老鼠的位置
            mouse.Left += mouseSpeedX;
            mouse.Top += mouseSpeedY;
            if(mouse.Left<=0||mouse.Right>=this.ClientSize.Width)
            {
                mouseSpeedX = -mouseSpeedX;
            }
            if(mouse.Top<=0||mouse.Bottom>=this.ClientSize.Height)
            {
                mouseSpeedY = -mouseSpeedY;
            }
            if(cat.Bounds.IntersectsWith(mouse.Bounds))
            {
                timerMouseMovement.Stop();
            }
        }   
        private void Form1_KeyDown(object sender, KeyEventArgs e)//KeyDown 事件处理程序中，可以检查 e.KeyCode 的值来确定用户按下了哪个键，并相应地执行相应的操作。
        {
            // 移动猫
            int step = 10;
            if (e.KeyCode == Keys.Left)
            {
                cat.Left -= step;
            }
            else if (e.KeyCode == Keys.Right)
            {
                cat.Left += step;
            }
            else if (e.KeyCode == Keys.Up)
            {
                cat.Top -= step;
            }
            else if (e.KeyCode == Keys.Down)
            {
                cat.Top += step;
            }

            // 检查猫和老鼠的碰撞
            if (cat.Bounds.IntersectsWith(mouse.Bounds))
            {
                MessageBox.Show("猫抓到了老鼠！");
            }
        }

    }
}
