using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamChat
{
    internal class MessageSaveDAO : AbstractDAO<MessageSave>
    {
        /*
           id_sender int references Users(id),
           id_getter int references Users(id),
           id_zprava int references Zprava(id),
           sender_seeable bit not null,
           getter_seeable bit not null
           id int primary key identity(1,1),
         */


        private static String table = "MessageSave";
        private String C_CREATE = String.Format("INSERT INTO {0} (id_sender,id_getter,id_zprava,sender_seeable,getter_seeable) VALUES (@id_sender,@id_getter,@id_zprava,@sender_seeable,@getter_seeable)", table);
        private String C_UPDATE = String.Format("UPDATE {0} SET id_sender = @id_sender,id_getter = @id_getter,id_zprava = @id_zprava,sender_seeable = @sender_seeable,getter_seeable = @getter_seeable WHERE id = @id", table);
        private String C_READ_ALL = String.Format("SELECT * FROM {0}", table);
        private String C_READ_BY_ID = String.Format("SELECT * FROM {0} WHERE id = @id", table);
        private String C_DELETE = String.Format("DELETE FROM {0} WHERE id = @id", table);

        public void Update(MessageSave obj)
        {
            Update(C_UPDATE, obj,obj.Id);
        }

        public int Create(MessageSave obj)
        {
           return Create(C_CREATE, obj);
        }

        public List<MessageSave> ReadAll()
        {
            return GetAll(C_READ_ALL);
        }

        public MessageSave? ReadById(int id)
        {
            return GetByID(C_READ_BY_ID, id);
        }

        protected override MessageSave Map(SqlDataReader reader)
        {
            return new MessageSave(
                Convert.ToInt32(reader[0].ToString()),
                new UserDAO().ReadById(Convert.ToInt32(reader[1].ToString())),
                new UserDAO().ReadById(Convert.ToInt32(reader[2].ToString())),
                new MessageDAO().ReadById(Convert.ToInt32(reader[3].ToString())),
                reader.GetBoolean(4),
                reader.GetBoolean(5)
                );
        }

        protected override List<SqlParameter> Map(MessageSave obj)
        {
            return new List<SqlParameter>
            {
                new SqlParameter("@id_sender",obj.Sender.Id),
                new SqlParameter("@id_getter",obj.Getter.Id),
                new SqlParameter("@id_zprava",obj.Message.Id),
                new SqlParameter("@sender_seeable",obj.Sender_seeable),
                new SqlParameter("@getter_seeable",obj.Getter_seeable),
            };
        }
    }
}
