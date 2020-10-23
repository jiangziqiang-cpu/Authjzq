using System.Collections.Generic;

namespace Poseidon.Infrastructure.Alarms
{
    public class Alarm : IAlarm
    {
        private readonly IList<AlertEntry> _entries;
        public Alarm()
        {
            _entries = new List<AlertEntry>();
        }
        public void Add(AlertType type, string message)
        {
            _entries.Add(new AlertEntry { Type = type, Message = message });
        }
        public IList<AlertEntry> List()
        {
            return _entries;
        }

    }
}
