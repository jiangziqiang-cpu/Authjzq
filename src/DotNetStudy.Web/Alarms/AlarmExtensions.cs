using System;

namespace Poseidon.Infrastructure.Alarms
{
    public static class AlarmExtensions
    {
        public static void Success(this IAlarm alarm, string message)
        {
            alarm.Add(AlertType.Success, message);
        }
        public static void Information(this IAlarm alarm, string message)
        {
            alarm.Add(AlertType.Information, message);
        }

        public static void Warning(this IAlarm alarm, string message)
        {
            alarm.Add(AlertType.Warning, message);
        }
        public static void Error(this IAlarm alarm, string message)
        {
            alarm.Add(AlertType.Error, message);
        }
        public static void Exception(this IAlarm alarm, Exception exception)
        {
            if (exception is ArgumentException || exception is InvalidOperationException)
            {
                alarm.Warning(exception.Message);
            }
            else
            {
                alarm.Error(exception.Message);
            }
        }
    }
}
