using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamChat
{
    internal class UserDAO : AbstractDAO<User>
    {
        /**
         * 	u_nick varchar(50) not null,
         * 	u_password varchar(30) not null
         */

        private static String table = "Users";
        private String C_CREATE = String.Format("INSERT INTO {0} (u_nick, u_password) VALUES (@u_nick, @u_password)", table);
        private String C_UPDATE = String.Format("UPDATE {0} SET u_nick = @u_nick, u_password = @u_password WHERE id = @id", table);
        private String C_READ_ALL = String.Format("SELECT * FROM {0}", table);
        private String C_READ_BY_ID = String.Format("SELECT * FROM {0} WHERE id = @id", table);
        private String C_DELETE = String.Format("DELETE FROM {0} WHERE id = @id", table);

        public int Create(User elem)
        {
            return Create(C_CREATE, elem);
        }

        public List<User> ReadAll()
        {
            return GetAll(C_READ_ALL);
        }

        public User? ReadById(int id)
        {
            return GetByID(C_READ_BY_ID,id);
        }


        protected override User Map(SqlDataReader reader)
        {
            return new User(
                    Convert.ToInt32(reader[0].ToString()),
                    reader[1].ToString(),
                    reader[2].ToString()
                ); 
        }

        protected override List<SqlParameter> Map(User obj)
        {
            return new List<SqlParameter>
            {
                new SqlParameter("@u_nick",obj.Nick),
                new SqlParameter("@u_password",obj.Password)
            };
        }
    }
}
