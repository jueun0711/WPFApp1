using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private RadioButton gender;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        public void BtnPress(object sender, RoutedEventArgs e)
        {
            if(IsVaild() == true)
            {
                var user = new User(ID.Text, PW.Password, PWCheck.Password, Name.Text, gender.Name.ToString(), Year.Text, Month.Text, Day.Text);
                MessageBox.Show("가입이 완료 되었습니다.");
            }
            
        }

        public void IDBoxHint(object sender, TextChangedEventArgs e)
        {
            if(ID.Text.Length == 0)
            {
                ImageBrush imageBrush = new ImageBrush();
                imageBrush.ImageSource = 
                    new BitmapImage(new Uri(@"C:\Users\user\source\repos\WpfApp1\WpfApp1\Image\IDBackground.jpg", UriKind.Relative));
                imageBrush.AlignmentX = AlignmentX.Left;
                imageBrush.Stretch = Stretch.Uniform;
                ID.Background = imageBrush;
            }
            else
            {
                ID.Background = null;
            }
        }

        //public void IDBoxFocusOn(object sender, RoutedEventArgs e)
        //{
        //    ID.Background = null;
        //}

        public void PWBoxHint(object sender, RoutedEventArgs e)
        {
            if (PW.Password.Length == 0)
            {
                ImageBrush imageBrush = new ImageBrush();
                imageBrush.ImageSource =
                    new BitmapImage(new Uri(@"C:\Users\user\source\repos\WpfApp1\WpfApp1\Image\PWBackground.jpg", UriKind.Relative));
                imageBrush.AlignmentX = AlignmentX.Left;
                imageBrush.Stretch = Stretch.Uniform;
                PW.Background = imageBrush;
            }
            else
            {
                PW.Background = null;
            }
        }

        public void PWCheckBoxHint(object sender, RoutedEventArgs e)
        {
            if (PWCheck.Password.Length == 0)
            {
                ImageBrush imageBrush = new ImageBrush();
                imageBrush.ImageSource =
                    new BitmapImage(new Uri(@"C:\Users\user\source\repos\WpfApp1\WpfApp1\Image\PWCheckBackground.jpg", UriKind.Relative));
                imageBrush.AlignmentX = AlignmentX.Left;
                imageBrush.Stretch = Stretch.Uniform;
                PWCheck.Background = imageBrush;
            }
            else
            {
                PWCheck.Background = null;
            }
        }

        public void NameBoxHint(object sender, TextChangedEventArgs e)
        {
            if (Name.Text.Length == 0)
            {
                ImageBrush ImageBrush = new ImageBrush();
                ImageBrush.ImageSource =
                    new BitmapImage(new Uri(@"C:\Users\user\source\repos\WpfApp1\WpfApp1\Image\NameBackground.jpg", UriKind.Relative));
                ImageBrush.AlignmentX = AlignmentX.Left;
                ImageBrush.Stretch = Stretch.Uniform;
                Name.Background = ImageBrush;
            }
            else
            {
                Name.Background = null;
            }
        }

        private void changeGender(object sender, RoutedEventArgs e)
        {
            gender = (sender as RadioButton);
        }

        private void InputOnlyInt(object sender, TextCompositionEventArgs e)
        {
            Regex re = new Regex("[^0-9]+");
            e.Handled = re.IsMatch(e.Text);
        }

        public bool IsVaild()
        {
            string msg;

            if (ID.Text.Length == 0)
            {
                msg = "아이디를 입력해주세요.";
            }
            else if (PW.Password.Length == 0)
            {
                msg = "비밀번호를 입력해주세요.";
            }
            else if (PWCheck.Password.Length == 0)
            {
                msg = "비밀번호를 재확인해주세요.";
            }
            else if (Name.Text.Length == 0)
            {
                msg = "이름을 입력해주세요.";
            }
            else if (gender == null)
            {
                msg = "성별을 선택해주세요.";
            }
            else if (Year.Text.Length == 0 || Month.Text.Length == 0 || Day.Text.Length == 0)
            {
                msg = "생일을 입력해주세요.";
            }
            else if (PW.Password != PWCheck.Password)
            {
                msg = "비밀번호가 일치하지 않습니다.\n입력하신 내용을 다시 확인해주세요.";
            }
            else
            {
                try
                {
                    var birth = new DateTime(Convert.ToInt32(Year.Text), Convert.ToInt32(Month.Text), Convert.ToInt32(Day.Text));
                    var minVal = new DateTime(1850, 1, 1);
                    var maxVal = DateTime.Now;
                    if (birth < minVal || birth > maxVal)
                        msg = "생일을 잘못 입력하셨습니다.\n입력하신 내용을 다시 확인해주세요.";
                    else
                        return true;
                }
                catch
                {
                    msg = "생일을 잘못 입력하셨습니다.\n입력하신 내용을 다시 확인해주세요.";
                }
                
            }

            MessageBox.Show($"{msg}");

            return false;
        }

//         private void IdNullText_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
//         {
//             IdNullText.Visibility = Visibility.Collapsed;
//         }
    }
}
