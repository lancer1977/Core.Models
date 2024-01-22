using PolyhydraGames.Core.Interfaces;

namespace PolyhydraGames.Core.Models.Settings
{
    public class JsonSetting<T> : Setting, ISettingValue<T>
    {
        private T _value;
        public T Value
        {
            get => _value;
            set
            {
                if (_value?.Equals(value) ?? false)
                    return;
                _value = value;
                _settings.AddOrUpdateValue(_key, _value.ToJson());

            }
        }
 
        public JsonSetting(ISettings settings, string key, T defaultValue = default(T)) : base(settings, key)
        {
            _value = settings.GetValueOrDefault(_key, defaultValue?.ToString()).FromJson<T>();
        }
    }
}