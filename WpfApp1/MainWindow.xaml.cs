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
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>\

    

    public partial class MainWindow : Window
    {
        private RadioButton gender;
        
        public MainWindow()
        {
            InitializeComponent();
            //Birth.SelectedDate = DateTime.Today;
        }

        public void BtnPress(object sender, RoutedEventArgs e)
        {
            //string text = ID.Text;
            //MessageBox.Show($"{text}");
            //var gender = (sender as RadioButton);
            /*var birth = Birth.SelectedDate.Value.ToString("yyyy.MM.dd");
            var year = birth.Split('.')[0];
            var month = birth.Split('.')[1];
            var day = birth.Split('.')[2];
            */
            
            if(IsVaild() == true)
            {
                var user = new User(ID.Text, PW1.Password, PW2.Password, Name.Text, gender.Name.ToString(), Year.Text, Month.Text, Day.Text);
                //var user = new User(ID.Text, PW1.Password, PW2.Password, Name.Text, gender.Name.ToString(), year, month, day);

                MessageBox.Show($"{user}");
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
            else if (PW1.Password.Length == 0)
            {
                msg = "비밀번호를 입력해주세요.";
            }
            else if (PW2.Password.Length == 0)
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
            else if (PW1.Password != PW2.Password)
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
    }
}
