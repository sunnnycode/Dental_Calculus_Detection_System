using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FireSharp.Config;
using FireSharp;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Collections;
using Google.Cloud.Firestore;

namespace register_1
{
    public class Person
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string Pass { get; set; }


    }
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
       FirestoreDb db;


        public MainWindow()
        {
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + @"fir-join-edecd-firebase-adminsdk-4sa24-e9e7493658.json";
                Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

                db = FirestoreDb.Create("fir-join-edecd");
            
            };

        }

        //  private async void 회원가입(object sender, RoutedEventArgs e)
        //  {//
        //    try
        //     {
        //     await client.SetAsync("Sing-up/data", )
        //    }

        //  }
        //
        private async void TxtSingup_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            string id = txtId.Text;
            string pass = txtPass.Password;
         //  < TextBox Name = "txtPass" Margin = "73,49,-58,-29" Grid.Column = "1" />


            if (id =="" || pass =="")
            {
                MessageBox.Show("아이디 또는 비밀번호에 공백이 있습니다.");
                return;
            }
            JoinManagementAsync(name, id, pass);
        }
        private int pwChanges = 0;

        void PasswordChangedHandler(Object sender, RoutedEventArgs args)
        {
            // Increment a counter each time the event fires.
            ++pwChanges;
        }

        private async Task JoinManagementAsync(string name, string id, string pass)
        {
            bool idCheck = await FindId(id);
            if (idCheck) { } //id가 이미 있으므로 회원가입 X
            else if (!idCheck) //id가 없으므로 회원가입 O
            {
                Signup(name, id, pass);
                MessageBox.Show("회원가입이 완료되었습니다.");
            }
        }

         void Signup(string name, string id, string pass)
        {
            DocumentReference DOC = db.Collection("Signup").Document();
            Dictionary<string, object> data1 = new Dictionary<string, object>()
            {
                 {"Name", name },
                {"Id", id },
                {"Pass", pass },

            };
            DOC.SetAsync(data1);
        }


        

        async Task<bool> FindId(string id)
        {
            Query qref = db.Collection("Signup").WhereEqualTo("Id", id);
            QuerySnapshot snap = await qref.GetSnapshotAsync();

            foreach (DocumentSnapshot docsnap in snap)
            {
                if (docsnap.Exists)
                {
                    return true;
                }
            }
            return false;
        }

        private void TxtLogin_Click(object sender, RoutedEventArgs e)

        {
            string name = txtName.Text;
            string id = txtId.Text;
            string pass = txtPass.Password;


            if (name == "" || id == "" || pass == "") //공백이 입력될 경우
            {
                MessageBox.Show("이름 또는 아이디 또는 비밀번호에 공백이 있습니다.\n빈칸을 입력해주세요.");
                return;
            }

            LoginManagementAsync(name, id, pass);
        }

        private async Task LoginManagementAsync(string name, string id, string pass)
        {
            bool idCheck = await FindId(name, id, pass);
            if (idCheck) //id, pass 일치
            {
                MessageBox.Show("로그인 되었습니다.");
            }
            else if (!idCheck) //id, pass 일치하지 않음
            {
                MessageBox.Show("로그인에 실패하였습니다.");
            }
        }

        async Task<bool> FindId(string name, string id, string pass)
        {
            Query qref = db.Collection("Signup").WhereEqualTo("Name", name).WhereEqualTo("Id", id).WhereEqualTo("Pass", pass);
            QuerySnapshot snap = await qref.GetSnapshotAsync();

            foreach (DocumentSnapshot docsnap in snap)
            {
                if (docsnap.Exists)
                {
                    return true;
                }
            }
            return false;
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Window win1 = new Window();
            win1.Show();
        }

        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {

            if (txtPass.Password == "Password")
            {
                statusText.Text = "'Password' is not allowed as a password.";
            }
            else
            {
                statusText.Text = string.Empty;
            }
        }
    }
 
   
}


//  private async void BTN_Click(object sender, RoutedEventArgs e)
// {
//   try
// {
//   await client.SetAsync("Register/data", .Text);
// MessageBox.Show("회원가입 성공");
// }
// catch { }
//}

