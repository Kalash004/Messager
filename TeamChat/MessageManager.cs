using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamChat
{
    internal class MessageManager
    {
        public void SentMessage(User usr)
        {
            Console.WriteLine("Please write the message");
            String message = Console.ReadLine();
        }
    }
}
