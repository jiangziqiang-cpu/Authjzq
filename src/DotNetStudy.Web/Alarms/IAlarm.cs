using System.Collections.Generic;

namespace Poseidon.Infrastructure.Alarms
{
    public interface IAlarm
    {
        void Add(AlertType alertType, string message);
        IList<AlertEntry> List();
    }
}
