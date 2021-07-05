using Vrnz2.BaseContracts.Settings.Base;
using Vrnz2.Infra.Repository.Settings;

namespace backend_challenge_crosscutting.Settings
{
    public class AppSettings
        : BaseAppSettings
    {
        public string DatabasePath { get; set; }

        public ConnectionStrings ConnectionStrings { get; set; }
    }
}
