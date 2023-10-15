using iBlack.Enums;
using System;
using System.Linq;
using System.Windows;

namespace iBlack.Classes
{
    public class Account
    {
        public int Id { get; private set; }

        public string Name { get; set; }

        public string Family { get; set; }

        private Post post;
       
        private string[] ArrayStringPosts =  new string[3] { "Руководитель", "Инженер", "Техник" };

    public string NamePost { get => ArrayStringPosts[(int)post]; set {
               if  (ArrayStringPosts.Contains(value) )
                {
                    int index = Array.IndexOf(ArrayStringPosts, value);
                    if (Enum.IsDefined(typeof(Post), index))
                    {
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


        public Account(int Id,string Name,string Family, Post Post,DateTime date)
        {
            this.Id = Id;
            this.Family = Family;
            this.Name = Name;
            post = Post;
            //NamePost = ArrayStringPosts[(int)Post];
            ReceiptDateTime = date;
        }
    }


}
