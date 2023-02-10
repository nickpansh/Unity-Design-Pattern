using System;
using System.Collections;
using System.Collections.Generic;
namespace WenQu.FacadePattern
{
    public sealed class WeatherManager
    {
        private static readonly Lazy<WeatherManager> _lazy = new Lazy<WeatherManager>(() => new WeatherManager());
        public static WeatherManager Instance
        {
            get
            {
                return _lazy.Value;
            }
        }
        private WeatherManager()
        {

        }

        public float GetTempeture()
        {
            Random random = new Random();
            return (float)random.Next(-10, 40);

        }
    }
}