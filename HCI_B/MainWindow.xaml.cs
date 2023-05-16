using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


using System.Windows.Threading;
namespace HCI_B
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer gameTimer = new DispatcherTimer();

        string myfile =  @"score.txt";
        string username = "";
        bool goLeft, goRight, goDown, goUp; 
        bool noLeft, noRight, noDown, noUp; //
        int zbir = 0;
        int speed = 8; // player speed

        Rect jagodicaHitBox; 

        int ghostSpeed = 2; 
        int ghostMoveStep = 100; 
        int currentGhostStep;
        private int score = 0;
        private int sum = 0;
        int sscore = 1;
        Random rnd = new Random();



        public MainWindow()
        {
            InitializeComponent();

            btnSave.Visibility = Visibility.Hidden;
            monster.Visibility = Visibility.Hidden;
            monster2.Visibility = Visibility.Hidden;
            monster3.Visibility = Visibility.Hidden;
            monster4.Visibility = Visibility.Hidden;
            jagoda.Visibility = Visibility.Hidden;
            jagoda2.Visibility = Visibility.Hidden;
            jagoda3.Visibility = Visibility.Hidden;
            jagoda4.Visibility = Visibility.Hidden;
            jagoda5.Visibility = Visibility.Hidden;
            jagoda6.Visibility = Visibility.Hidden;
            jagoda7.Visibility = Visibility.Hidden;
            jagoda8.Visibility = Visibility.Hidden;
            jagoda9.Visibility = Visibility.Hidden;
            jagoda10.Visibility = Visibility.Hidden;
            jagodica.Visibility = Visibility.Hidden;
            txtLevel.Content = "";
            txtScore.Content = "";






        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {

            username = txtusername.Text.ToString();
            if (!string.IsNullOrEmpty(username))
            {
                GameSetUp();
                
                monster.Visibility = Visibility.Visible;
                monster2.Visibility = Visibility.Visible;
                monster3.Visibility = Visibility.Visible;
                monster4.Visibility = Visibility.Visible;
                jagoda.Visibility = Visibility.Visible;
                jagoda2.Visibility = Visibility.Visible;
                jagoda3.Visibility = Visibility.Visible;
                jagoda4.Visibility = Visibility.Visible;
                jagoda5.Visibility = Visibility.Visible;
                jagoda6.Visibility = Visibility.Visible;
                jagoda7.Visibility = Visibility.Visible;
                jagoda8.Visibility = Visibility.Visible;
                jagoda9.Visibility = Visibility.Visible;
                jagoda10.Visibility = Visibility.Visible;
                jagodica.Visibility = Visibility.Visible;
               
                labelName.Visibility = Visibility.Hidden;
                txtusername.Visibility = Visibility.Hidden;
                btnStart.Visibility = Visibility.Hidden;
            }
            else
                MessageBox.Show("Please enter your name ");
        }


        private void CanvasKeyDown(object sender, KeyEventArgs e)
        {
            // this is the key down event

            if (e.Key == Key.Left && noLeft == false)
            {
                goRight = goUp = goDown = false; 
                noRight = noUp = noDown = false;

                goLeft = true; // set go left true

                jagodica.RenderTransform = new RotateTransform(-180, jagodica.Width / 2, jagodica.Height / 2);
            }

            if (e.Key == Key.Right && noRight == false)
            {
                
                noLeft = noUp = noDown = false; 
                goLeft = goUp = goDown = false;
                goRight = true; 

                jagodica.RenderTransform = new RotateTransform(0, jagodica.Width / 2, jagodica.Height / 2); 

            }

            if (e.Key == Key.Up && noUp == false)
            {
               
                noRight = noDown = noLeft = false; 
                goRight = goDown = goLeft = false; 

                goUp = true; 

                jagodica.RenderTransform = new RotateTransform(-90, jagodica.Width / 2, jagodica.Height / 2);
            }

            if (e.Key == Key.Down && noDown == false)
            {
               
                noUp = noLeft = noRight = false; 
                goUp = goLeft = goRight = false; 

                goDown = true; 
                jagodica.RenderTransform = new RotateTransform(90, jagodica.Width / 2, jagodica.Height / 2);
            }


        }




        private void GameSetUp()
        {
          

            MyCanvas.Focus(); 
            gameTimer.Tick += GameLoop;
            gameTimer.Interval = TimeSpan.FromMilliseconds(20);
            // set time to tick every 20 milliseconds
            gameTimer.Start(); 
            currentGhostStep = ghostMoveStep;
            
            ImageBrush jagodicaImage = new ImageBrush();
            jagodicaImage.ImageSource = new BitmapImage(new Uri("C:/Users/Korisnik/source/repos/HCI_B/HCI_B/images/jag.png"));
            jagodica.Fill = jagodicaImage;

            ImageBrush jagodaImage = new ImageBrush();
            jagodaImage.ImageSource = new BitmapImage(new Uri("C:/Users/Korisnik/source/repos/HCI_B/HCI_B/images/jagoda.png"));

            jagoda.Fill = jagodaImage;
            jagoda2.Fill = jagodaImage;
            jagoda3.Fill = jagodaImage;
            jagoda4.Fill = jagodaImage;
            jagoda5.Fill = jagodaImage;
            jagoda6.Fill = jagodaImage;
            jagoda7.Fill = jagodaImage;
            jagoda8.Fill = jagodaImage;
            jagoda9.Fill = jagodaImage;
            jagoda10.Fill = jagodaImage;


            ImageBrush monsterImage = new ImageBrush();
            monsterImage.ImageSource = new BitmapImage(new Uri("C:/Users/Korisnik/source/repos/HCI_B/HCI_B/images/monster.png"));
            monster.Fill = monsterImage;


            ImageBrush monsterImage2 = new ImageBrush();
            monsterImage2.ImageSource = new BitmapImage(new Uri("C:/Users/Korisnik/source/repos/HCI_B/HCI_B/images/monster.png"));
            monster2.Fill = monsterImage2;

            ImageBrush monsterImage3 = new ImageBrush();
            monsterImage3.ImageSource = new BitmapImage(new Uri("C:/Users/Korisnik/source/repos/HCI_B/HCI_B/images/monster.png"));
            monster3.Fill = monsterImage3;


            monster4.Fill = monsterImage3;


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
       
            Window1 pom = new Window1();
            pom.Show();

       
        }

        Random rand = new Random();


       

        private void GameLoop(object sender, EventArgs e)
        {

           
            txtScore.Content = "Score: " + score; 
            txtLevel.Content = "Level: " + sscore;           

            if (goRight)
            {
                Canvas.SetLeft(jagodica, Canvas.GetLeft(jagodica) + speed);
            }
            if (goLeft)
            {
                
                Canvas.SetLeft(jagodica, Canvas.GetLeft(jagodica) - speed);
            }
            if (goUp)
            {
                
                Canvas.SetTop(jagodica, Canvas.GetTop(jagodica) - speed);
            }
            if (goDown)
            {
                
                Canvas.SetTop(jagodica, Canvas.GetTop(jagodica) + speed);
            }
           


            if (goDown && Canvas.GetTop(jagodica) + 80 > Application.Current.MainWindow.Height)
            {
               
                noDown = true;
                goDown = false;
            }
            if (goUp && Canvas.GetTop(jagodica) < 1)
            {
                
                noUp = true;
                goUp = false;
            }
            if (goLeft && Canvas.GetLeft(jagodica) - 10 < 1)
            {
               
                noLeft = true;
                goLeft = false;
            }
            if (goRight && Canvas.GetLeft(jagodica) + 70 > Application.Current.MainWindow.Width)
            {
               
                noRight = true;
                goRight = false;
            }

            jagodicaHitBox = new Rect(Canvas.GetLeft(jagodica), Canvas.GetTop(jagodica), jagodica.Width, jagodica.Height); 

           
            foreach (var x in MyCanvas.Children.OfType<Rectangle>())
            {
               


                Rect hitBox = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height); 

              

                
                if ((string)x.Tag == "coin")
                {
                    
                    if (jagodicaHitBox.IntersectsWith(hitBox) && x.Visibility == Visibility.Visible)
                    {
                        x.Visibility = Visibility.Hidden;
                        
                        score++;
                        sum++;

                    }

                }
                if (x.Name.ToString() == "monster")
                {


                  


                    if (Canvas.GetTop(monster)  < 0 || Canvas.GetTop(monster) > Application.Current.MainWindow.Height)
                    {

                        Canvas.SetTop(monster, Canvas.GetTop(monster) + ghostSpeed);

                        
                    }

                    if (Canvas.GetLeft(monster)< 0 || Canvas.GetLeft(monster) > Application.Current.MainWindow.Width)
                    {
        
                        Canvas.SetLeft(monster, Canvas.GetLeft(monster) - ghostSpeed);

                       
                    }
                }

                   
                    if ((string)x.Tag == "ghost")
                {
                    
                    if (jagodicaHitBox.IntersectsWith(hitBox))
                    {
                        GameOver("GAME OVER");
                        
                    }

                  
                    if (x.Name.ToString() == "monster")
                    {

                      int  i = rand.Next(-5, 5);

                        Canvas.SetTop(x, Canvas.GetTop(x) - ghostSpeed);
                        Canvas.SetLeft(x, Canvas.GetLeft(x) - (i * -1));


                        if (Canvas.GetTop(monster) < 0 || Canvas.GetTop(monster)> Application.Current.MainWindow.Width)
                        {
                        
                            Canvas.SetTop(monster, Canvas.GetTop(monster) + ghostSpeed);

                        }

                        if (Canvas.GetLeft(monster) < 0 || Canvas.GetLeft(monster) > Application.Current.MainWindow.Height)
                        {
                          
                            Canvas.SetLeft(monster, Canvas.GetLeft(monster) - ghostSpeed);
                           
                        }
                       

                    }
                    else
                    {
                       
                        Canvas.SetLeft(x, Canvas.GetLeft(x) + ghostSpeed);
                    }



                   
                    currentGhostStep--;


                    // if the current ghost step integer goes below 1 
                    if (currentGhostStep < 1)
                    {
                        
                        currentGhostStep = ghostMoveStep;
                        // reverse the ghost speed integer
                        ghostSpeed = -ghostSpeed;

                    }
                }
            }


           
            if (score == 10)
            {
                sscore+=1;
                gameTimer.Stop(); 

                txtNext.Text = "CONGRATULATIONS";
                
                btnRestart.Visibility = Visibility.Visible;
                btnNextLevel.Visibility = Visibility.Visible;
               

                score = 0;
              

            
            }


        }

        private void End_Click_1(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
           Application.Current.Shutdown();

        }

        private void NextLevel()
        {

            txtGameOver.Text = "";
            txtNext.Text = "";


            btnNextLevel.Visibility = Visibility.Hidden;
            btnRestart.Visibility = Visibility.Hidden;

            score = 0;
            txtScore.Content = "Score: " + score;
            txtLevel.Content = "Level: " + sscore;
     
            ghostSpeed =2*sscore;
            
            currentGhostStep = ghostMoveStep;
          
           

            Canvas.SetTop(jagodica, 188);
            Canvas.SetLeft(jagodica, 10);

           Canvas.SetTop(monster, 250);
            Canvas.SetLeft(monster, 500);

          //  Canvas.SetTop(monster4, Canvas.GetTop(monster2) + 82);
           // Canvas.SetLeft(monster4, Canvas.GetTop(monster2) + 82);

           // Canvas.SetTop(monster2, GetRandomValue());
          //  Canvas.SetLeft(monster2, GetRandomValue());

            Canvas.SetTop(monster3, GetRandomValue());
            Canvas.SetLeft(monster3, GetRandomValue()); ;

            foreach (var x in MyCanvas.Children.OfType<Rectangle>())
            {

                if ((string)x.Tag == "coin")
                {
                    
                    if (x.Visibility == Visibility.Hidden)
                    {
                      

                       
                        x.Visibility = Visibility.Visible;
                       
                    }

                }
            }

            int pom = rnd.Next(10);
          //  int tmp = 0;
          double  GetRandomValue()
            {
                double pom = 0;
                pom = rnd.Next(500);
                return pom;
            }


            double GetRandom()
            {
                double pom = 0;
                pom = rnd.Next(700);
                return pom;
            }


            Canvas.SetTop(jagoda9, GetRandomValue());
                Canvas.SetLeft(jagoda9,GetRandom());
          
            Canvas.SetTop(jagoda2, GetRandomValue());
            Canvas.SetLeft(jagoda2, GetRandom());

            Canvas.SetTop(jagoda8, GetRandomValue());
            Canvas.SetLeft(jagoda8,GetRandom());

            Canvas.SetTop(jagoda, GetRandomValue());
            Canvas.SetLeft(jagoda, GetRandom());

            Canvas.SetTop(jagoda3, GetRandomValue());
            Canvas.SetLeft(jagoda3, GetRandom());

            Canvas.SetTop(jagoda4, GetRandomValue());
            Canvas.SetLeft(jagoda4, GetRandom());

            Canvas.SetTop(jagoda5, GetRandomValue());
            Canvas.SetLeft(jagoda5, GetRandomValue());

            Canvas.SetTop(jagoda6, GetRandomValue());
            Canvas.SetLeft(jagoda6, GetRandom());

            Canvas.SetTop(jagoda7, GetRandomValue());
            Canvas.SetLeft(jagoda7, GetRandom());

            gameTimer.Start();
        }
        private void btnNextLevel_Click(object sender, RoutedEventArgs e)
        {
           
           NextLevel();
          
        }

        private void btnRestart_Click(object sender, RoutedEventArgs e)
        {
           // upisi();
            MainWindow hal1 = new MainWindow();
            hal1.Show();
            this.Close();
         

         //   System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
         //   Application.Current.Shutdown();

        }



        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            zbir+=1;
            upisi();
 

        }


        private void GameOver(string message)
        {

            btnSave.Visibility = Visibility.Visible;
            
            gameTimer.Stop(); 
                            
            txtGameOver.Text = message;
           
            btnRestart.Visibility = Visibility.Visible;


           
               
            
            }

        private void upisi()
        {

            // MessageBox.Show("");
           labelSaved.Content = "Saved";
            labelSaved.Visibility = Visibility.Visible;
            if (zbir <= 1)
            {
                DateTime dt = DateTime.Now;
                if (!File.Exists(myfile))
                {
                    using (StreamWriter sw = File.CreateText(myfile))
                    {
                        sw.WriteLine(username + ", " + dt + ", " + sscore + ", " + sum);
                        sw.Close();
                    }
                }
                using (StreamWriter sw = File.AppendText(myfile))
                {
                    sw.WriteLine(username + ", " + dt + "," + sscore + "," + sum);
                    sw.Close();
                }
            }
        }
        
    }
}
