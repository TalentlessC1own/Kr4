using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kr4.Services
{
    public interface IEventAgregator
    {
        void AddSubscriber(EventHandler value);
        void NotifyDBChanged();
    }
}
