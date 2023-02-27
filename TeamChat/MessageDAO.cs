using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamChat
{
    internal class MessageDAO : AbstractDAO<Message>
    {
        /**
         * 	id int primary key identity(1,1),
         * 	text varchar(500) not null
         */

        private static String table = "Zprava";
        private String C_CREATE = String.Format("INSERT INTO {0} (text) VALUES (@text)", table);
        private String C_UPDATE = String.Format("UPDATE {0} SET u_nick = @u_nick, u_password = @u_password WHERE id = @id", table);
        private String C_READ_ALL = String.Format("SELECT * FROM {0}", table);
        private String C_READ_BY_ID = String.Format("SELECT * FROM {0} WHERE id = @id", table);
        private String C_DELETE = String.Format("DELETE FROM {0} WHERE id = @id", table);

        public int Create(Message elem)
        {
            return Create(C_CREATE, elem);
        }

        public List<Message> ReadAll()
        {
            return GetAll(C_READ_ALL);
        }

        public Message? ReadById(int id)
        {
            return GetByID(C_READ_BY_ID, id);
        }

        protected override Message Map(SqlDataReader reader)
        {
            return new Message(
                    Convert.ToInt32(reader[0].ToString()),
                    reader[1].ToString()
                );
        }

        protected override List<SqlParameter> Map(Message obj)
        {
            return new List<SqlParameter>
            {
                new SqlParameter("@text",obj.Text)
            };
        }
    }
}
