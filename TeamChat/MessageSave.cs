using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamChat
{
    internal class MessageSave
    {
        private int id;
        private User sender;
        private User getter;
        private Message message;
        private bool sender_seeable;
        private bool getter_seeable;


        public MessageSave(int id, User sender, User getter, Message message, bool sender_seeable, bool getter_seeable)
        {
            this.id = id;
            this.sender = sender;
            this.getter = getter;
            this.message = message;
            this.sender_seeable = sender_seeable;
            this.getter_seeable = getter_seeable;
        }

        public MessageSave(User sender, User getter, Message message, bool sender_seeable, bool getter_seeable)
        {
            this.id = -1;
            this.sender = sender;
            this.getter = getter;
            this.message = message;
            this.sender_seeable = sender_seeable;
            this.getter_seeable = getter_seeable;
        }
        public int Id { get => id; set => id = value; }
        internal User Sender { get => sender; set => sender = value; }
        internal User Getter { get => getter; set => getter = value; }
        internal Message Message { get => message; set => message = value; }
        public bool Sender_seeable { get => sender_seeable; set => sender_seeable = value; }
        public bool Getter_seeable { get => getter_seeable; set => getter_seeable = value; }
    }
}
