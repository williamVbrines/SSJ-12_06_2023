using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ssj12062023
{
    [CreateAssetMenu(fileName = "New Configuration Layout", menuName = "SSJ12062023/Configuration Layout")]
    public class ConfigurationLayoutData : Data
    {
        public string Name;
        public int SlotsAvailable;
        public GameObject platform;


        protected static List<ConfigurationLayoutData> data = new();

        public static void Load(string folder = "")
        {
            data.Clear();
            data.AddRange(Resources.LoadAll<ConfigurationLayoutData>(folder));
        }

        public static ConfigurationLayoutData GetById(string uid)
        {
            foreach (ConfigurationLayoutData c in data)
            {
                if (c.UID == uid)
                {
                    return c;
                }
            }
            return null;
        }

        public static ConfigurationLayoutData GetByName(string name)
        {
            foreach (ConfigurationLayoutData c in data)
            {
                if (c.Name == name)
                {
                    return c;
                }
            }
            return null;
        }
    }
}