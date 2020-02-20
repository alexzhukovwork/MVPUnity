using UnityEngine;

namespace Assets.Scripts.Additionals.Logger
{
    class Logger : ILogger
    {
        public void Log(string message)
        {
            Debug.Log(message);
        }
    }
}
