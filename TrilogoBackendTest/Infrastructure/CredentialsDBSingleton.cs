using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class CredentialsDBSingleton
    {
        private static readonly string _server = "127.0.0.1";
        private static readonly string _database = "trilogo";
        private static readonly string _port = "7071";
        private static readonly string _user = "postgres";
        private static readonly string _password = "123456";

        public static string Credenciais
        {
            get => $"Server={_server};Database={_database};Port={_port};UserId={_user};Password={_password};Pooling=true;";
        }

    }
}
