using PolyhydraGames.Core.Interfaces;

namespace PolyhydraGames.Core.Models.Settings
{
    public class IntSetting : Setting, ISettingValue<int>
    {
      
        private int _value;
        public int Value
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

        public IntSetting(ISettings settings, string key, int defaultValue = 0): base(settings,key){
            Value = settings.GetValueOrDefault(key, defaultValue);}
    }
}