using UnityEngine;

namespace HexLoop.Core.Log
{
    public static class Logger
    {
        public static void Assert(bool res, object message)
        {
            if (!res)
                return;

            UnityEngine.Debug.LogAssertion(message);
        }

        public static void Log(object message, Object context=default) => UnityEngine.Debug.Log(message, context);

        public static void LogWarning(object message, Object context) => Debug.LogWarning(message, context);

        public static void LogError(object message, Object context) => Debug.LogError(message, context);

    }
}
