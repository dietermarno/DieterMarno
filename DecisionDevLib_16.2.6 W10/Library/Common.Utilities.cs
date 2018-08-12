using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Configuration;

namespace Decision.Util
{
    public static class AppConfig
    {
        public static string ReadSetting(string key)
        {
            try
            {
                //************************************
                //* Devolve valor da chave solicitada
                //************************************
                var appSettings = ConfigurationManager.AppSettings;
                string result = appSettings[key] ?? string.Empty;
                return result;
            }
            catch (ConfigurationErrorsException)
            {
                //*************************************
                //* Configuração incorreta ou ilegível
                //*************************************
                return string.Empty;
            }
        }
        public static bool AddUpdateAppSettings(string key, string value)
        {
            try
            {
                //**************************************
                //* Deve atualizar ou criar nova chave?
                //**************************************
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    //********************
                    //* Nova configuração
                    //********************
                    settings.Add(key, value);
                }
                else
                {
                    //**************
                    //* Atualização
                    //**************
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
                return true;
            }
            catch (ConfigurationErrorsException)
            {
                //********************
                //* Falha na operação
                //********************
                return false;
            }
        }
        public static bool RemoveSetting(string key)
        {
            try
            {
                //**************************************
                //* Deve atualizar ou criar nova chave?
                //**************************************
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] != null)
                {
                    //*************
                    //* Remove key
                    //*************
                    settings.Remove(key);
                    configFile.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
                    return true;
                }
                else
                {
                    //*****************
                    //* Não localizada
                    //*****************
                    return false;
                }
            }
            catch (ConfigurationErrorsException)
            {
                //********************
                //* Falha na operação
                //********************
                return false;
            }
        }
    }
}