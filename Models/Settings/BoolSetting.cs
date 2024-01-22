

using PolyhydraGames.Core.Interfaces;

namespace PolyhydraGames.Core.Models.Settings
{
    public class BoolSetting : Setting, ISettingValue<bool>
    { 
        private bool _value;
        public bool Value
        {
            get => _value;
            set
            {
                if (_value.Equals(value))
                    return;
                _value = value;
                _settings.AddOrUpdateValue(_key, _value);
            }
        }

        public BoolSetting(ISettings settings, string key, bool defaultValue = false) : base(settings, key)
        { 
            Value = settings.GetValueOrDefault(key, defaultValue);
        }
    }
}