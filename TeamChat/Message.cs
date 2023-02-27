using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamChat
{
    internal class Message
    {
        private int id;
        private String text;


        public Message(int id, string text)
        {
            this.id = id;
            this.text = text;
        }
        public Message(string text)
        {
            this.id = -1;
            this.text = text;
        }
        public int Id { get => id; set => id = value; }
        public string Text { get => text; set => text = value; }


    }
}
