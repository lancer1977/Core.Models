
using PolyhydraGames.Core.Interfaces;

namespace PolyhydraGames.Core.Models.Settings
{
    public abstract class Setting
    {
        protected readonly ISettings _settings;
        protected readonly string _key;

        protected Setting(ISettings settings, string key)
        {
            _key = key;
            _settings = settings;
        }
    }
}