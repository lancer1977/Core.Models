using PolyhydraGames.Core.Interfaces;

namespace PolyhydraGames.Core.Models.Settings
{
    public class StringSetting : Setting, ISettingValue<string>
    {
        private string _value;
        public string Value
        {
            get => _value;
            set
            {
                if (_value?.Equals(value) ?? false)
                    return;
                _value = value;
                _settings.AddOrUpdateValue(_key, _value);

            }
        }

        public StringSetting(ISettings settings, string key, string defaultValue = default(string)) : base(settings, key)
        {
            Value = settings.GetValueOrDefault(key, defaultValue);
        }
    }
}