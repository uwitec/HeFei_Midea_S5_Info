using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;
namespace All.Class
{
    #region//PostGreSQL数据库
    public class PostGreSQL : All.Class.DataReadAndWrite
    {
        object lockObject = new object();
        NpgsqlConnection conn;
        public override System.Data.Common.DbConnection Conn
        {
            get { return conn; }
        }
        public override bool Login(string Address, string Data, string UserName, string Password)
        {
            //3D000:错误的数据库名称
            bool result = false;
            try
            {
                conn = new NpgsqlConnection(string.Format("Host={0};Database={1};User Id={2};Password={3};Port=5432;Connection LifeTime=0",
                        Address, Data, UserName, Password));
                conn.Open();
                result = (conn.State == ConnectionState.Open);
            }
            catch (Exception e)
            {
                All.Class.Error.Add(e);
            }
            return result;
        }
        public override DataTable Read(string sql)
        {
            lock (lockObject)
            {
                DataTable dt = new DataTable();
                try
                {
                    CheckConn();
                    using (NpgsqlDataAdapter od = new NpgsqlDataAdapter(new NpgsqlCommand(sql, conn)))
                    {
                        od.Fill(dt);
                    }
                }
                catch (Exception e)
                {
                    All.Class.Error.Add(e);
                    All.Class.Error.Add(sql);
                }
                return dt.Copy();
            }
        }
        public override int Write(string sql)
        {
            lock (lockObject)
            {
                int result = 0;
                try
                {
                    CheckConn();
                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {
                        result = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    All.Class.Error.Add(e);
                    All.Class.Error.Add(sql);
                }
                return result;
            }
        }
        public override int Update(string tableName, string[] columns, object[] value, string[] conditions)
        {
            throw new NotImplementedException();
        }
        public override DataTable Read(string[] columns, string tableName, string[] conditions, string[] orders, bool Desc)
        {
            throw new NotImplementedException();
        }
        public override int Insert(string tableName, string[] columns, object[] value)
        {
            throw new NotImplementedException();
        }
        public override int BlockCommand(DataTable dt)
        {
            int result = 0;
            lock (lockObject)
            {
                try
                {
                    CheckConn();
                    using (NpgsqlCommand cmd = new NpgsqlCommand(string.Format("select * from {0}", dt.TableName), conn))
                    {
                        using (NpgsqlDataAdapter ada = new NpgsqlDataAdapter(cmd))
                        {
                            using (NpgsqlCommandBuilder scb = new NpgsqlCommandBuilder(ada))
                            {
                                ada.InsertCommand = scb.GetInsertCommand();
                                ada.DeleteCommand = scb.GetDeleteCommand();
                                ada.UpdateCommand = scb.GetUpdateCommand();
                                result = ada.Update(dt);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    All.Class.Error.Add(e);//数据库中一定要有主键，不然当前方法会出错。即没有办法生成删除命令
                }
            }
            return result;
        }
    }
    #endregion
}
