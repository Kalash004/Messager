using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamChat
{
    internal class User
    {
        private int id;
        private String nick;
        private String password;

        public User(string nick, string password)
        {
            this.id = -1;
            this.nick = nick;
            this.password = password;
        }

        public User(int id,string nick, string password)
        {
            this.nick = nick;
            this.password = password;
            this.id = id;
        }

        public int Id { get => id; set => id = value; }
        public string Nick
        {
            get
            {
                return nick;
            }
            set
            {
                if (value.Length >= 5) //TODO: add nick protection - get nicks from data base and check if they exist
                {
                    nick = value;
                }
                else throw new Exception("Name isnt long enough (5+letters)");
            }
        }
        public string Password {
            get
            {
                return password;
            }
            set
            {
                if (value.Length >= 5) //TODO: Add password protection
                {
                    password = value;
                }
                else throw new Exception("Password isnt long enough (5+ letters)");
            }
        }
    }
}
