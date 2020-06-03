using System;
using System.Diagnostics;
using System.Threading;

namespace CommonUtilities.Methods
{
    public static class TryCatchMethods
    {
        private const int DefaultTimeoutSec = 15;
        private const int SecToMilliSec = 1000;
        private const string FailedAction = "Failed action: ";

        public static T TryCatchReturn<T>(Func<T> action, int timeOutSec = DefaultTimeoutSec, string customMessage = "", int tempTimeOutMilliseconds = 100)
        {
            var sw = new Stopwatch();
            sw.Start();
            while (sw.ElapsedMilliseconds < timeOutSec * SecToMilliSec)
            {
                try
                {
                    return action();
                }
                catch
                {
                    Thread.Sleep(tempTimeOutMilliseconds);
                }
            }

            throw new Exception($"{FailedAction}{action.GetActionName()}. {customMessage}");
        }

        public static void TryCatchVoid(Action action, int timeOutSec = DefaultTimeoutSec, string customMessage = "", int tempTimeOutMilliseconds = 100)
        {
            var sw = new Stopwatch();
            sw.Start();
            while (sw.ElapsedMilliseconds < timeOutSec * SecToMilliSec)
            {
                try
                {
                    action();
                    return;
                }
                catch
                {
                    Thread.Sleep(tempTimeOutMilliseconds);
                }

                throw new Exception($"{FailedAction}{action.GetActionName()}. {customMessage}");
            }
        }

        private static string GetActionName(this Delegate action) => action.Method.ToString().Split('<', '>')[1];
       

    }
}
