using UnityEngine;
using Configuration;
using System;

namespace Loaders
{
    public  class ConfigLoader
    {
        readonly string _jsonData;

        public ConfigLoader(string data)
        {
            _jsonData = data;
        }

        public  Config LoadConfig()
        {
            if (_jsonData == null)
            {
                Debug.LogError("Can't load game config! Specify json data field in ConfigContainer!");
                return null;
            }
            try
            {
                return JsonUtility.FromJson<Config>(_jsonData);
            }
            catch (Exception e)
            {
                Debug.LogError("Cannot deserialize config: " + e.Message);
            }

            return null;
        }
    }
}
