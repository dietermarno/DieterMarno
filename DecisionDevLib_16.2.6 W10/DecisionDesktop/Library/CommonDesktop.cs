using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Decision.Util;
using System.IO;

namespace Decision.Util
{
    public static class CommonDesktop
    {
        public static string GetMasterConnectionString()
        {
            //***************************************************
            //* Obtem string de conexão a partir da configuração
            //***************************************************
            string ConnectionString = "driver={MySQL ODBC 5.1 Driver}; persist security info=True; database = master_data; ";
            ConnectionString += "server = " + Crypto.DecryptString(DecisionDesktop.Properties.Settings.Default.Connection_Server) + ";";
            ConnectionString += "port = " + Crypto.DecryptString(DecisionDesktop.Properties.Settings.Default.Connection_Port) + ";";
            ConnectionString += "uid = " + Crypto.DecryptString(DecisionDesktop.Properties.Settings.Default.Connection_User) + ";";
            ConnectionString += "password = " + Crypto.DecryptString(DecisionDesktop.Properties.Settings.Default.Connection_Password) + ";";
            return ConnectionString;
        }
    }
}
