using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kr4.Services
{
    public class EventAgregator : IEventAgregator , IDisposable
    {
        private event EventHandler? eventHandler;
        public void AddSubscriber(EventHandler value)
        {
            eventHandler += value;
        }

        public void NotifyDBChanged()
        {
           eventHandler?.Invoke(this, EventArgs.Empty);
        }

        public void Dispose()
        {
            eventHandler = null;
        }
    }
}
