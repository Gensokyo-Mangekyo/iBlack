using iBlack.Enums;
using System;
using System.Linq;
using System.Windows;

namespace iBlack.Classes
{
    public class Account
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Login { get; private set; }

        public string Password { get; private set; }

        public string Family { get; set; }

        private Post post;
       
        private string[] ArrayStringPosts =  new string[3] { "Руководитель", "Инженер", "Техник" };

    public string NamePost { get => ArrayStringPosts[(int)post]; set {
               if  (ArrayStringPosts.Contains(value) )
                {
                    int index = Array.IndexOf(ArrayStringPosts, value);
                    if (Enum.IsDefined(typeof(Post), index))
                    {
                        if (post == Post.Supervisor)
                        {
                            var Password = new Password("Supervisor", "qwerty");
                            bool? Result = Password.ShowDialog();
                            if (!Result.GetValueOrDefault())
                                return;
                        }
                        post = (Post)index;
                    }
                }
                else MessageBox.Show("Такой должности не существует","Ошибка ввода",MessageBoxButton.OK,MessageBoxImage.Error);
            } }

        private DateTime ReceiptDateTime;
        public string ReceiptDate { get => ReceiptDateTime.ToString("D"); set {

                DateTime date = new DateTime();
                if (DateTime.TryParse(value, out date))
                    ReceiptDateTime = date;
            } }


        public Account()
        {

        }

        public Account(int Id,string Name,string Family, Post Post,DateTime date)
        {
            this.Id = Id;
            this.Family = Family;
            this.Name = Name;
            post = Post;
            ReceiptDateTime = date;
            Login = "Andr";
            Password = "123";
        }

        public Account(int Id, string Name, string Family, string  NamePost, DateTime date)
        {
            this.Id = Id;
            this.Family = Family;
            this.Name = Name;
            this.NamePost = NamePost;
            ReceiptDateTime = date;
            Login = "Andr";
            Password = "123";
        }
    }


}
