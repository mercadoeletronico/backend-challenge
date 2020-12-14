using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ME.Api.Settings.Configuration
{

    internal static class GlobalSettings
    {
        public static MESettings Configuration { get; set; }
    }
    public enum MEProjects
    {
        Api = 0
    }
    public enum MEDataBase
    {
        MSSQL = 0,
        MySQL = 1,
        SqlLite = 2,
    }
    public class MESettings
    {
        public MESettings()
        {
            Configs = new List<MEItemSetting>();
        }

        public List<MEItemSetting> Configs { get; set; }
        private static string GetFileName()
        {

            return "MESettings.DEV.json";

        }

        private static MESettings LoadJson()
        {
            try
            {
                MESettings config = null;
                if (GlobalSettings.Configuration == null)
                {
                    string file = GetFileName();

                    var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                    var configPath = Path.Combine(path, file);

                    if (!File.Exists(configPath))
                        configPath = Path.Combine(path, "Configuration", file);


                    var reader =
                        new JsonTextReader(new StringReader(File.ReadAllText(configPath)));
                    var serializer = new JsonSerializer();
                    config = serializer.Deserialize<MESettings>(reader);
                    if (config == null)
                        throw new Exception("No configuration was found");
                    if (config.Configs == null || config.Configs.Count == 0)
                        throw new Exception("Nexo settings was not parametrized");
                    GlobalSettings.Configuration = config;
                }

                return GlobalSettings.Configuration;
            }
            catch (Exception ex)
            {
                throw new Exception("A problem occured when loading NexoSettings.json. Error: " + ex.Message);
            }
        }

        public static MEItemSetting GetSetting(MEProjects project)
        {
            var nexoSettings = LoadJson();
            return nexoSettings.Configs.FirstOrDefault(x => x.Projeto == project);
        }
        public static MEDataBase GetDataBase(MEProjects project)
        {
            return GetSetting(project)?.DataBase ?? MEDataBase.SqlLite;
        }

        public static string GetConnectionString(MEProjects project)
        {
            return GetSetting(project)?.ConnectionString ?? "";
        }

    }

    public class MEItemSetting
    {
        public MEProjects Projeto { get; set; } = MEProjects.Api;
        public string Host { get; set; } = "";
        public string ConnectionString { get; set; } = "";
        public MEDataBase DataBase { get; set; } = MEDataBase.SqlLite;
    }
}
