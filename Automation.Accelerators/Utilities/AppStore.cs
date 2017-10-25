using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Automation.Accelerators.Utilities
{
    public sealed class AppStore
    {
        private static AppStore instance = null;
        private static readonly object padlock = new object();
        private Dictionary<string, object> _Store;

        private AppStore()
        {
            _Store = new Dictionary<string, object>();
        }

        public static AppStore Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new AppStore();
                    }
                    return instance;
                }
            }
        }

        public Dictionary<string, object> Store { get { return _Store; } }

        public void ClearStore(string keysSeperatedByComma)
        {
            string[] keys = keysSeperatedByComma.Split(new char[] { ',' });

            foreach (var key in keys)
            {
                if (_Store.ContainsKey(key))
                {
                    _Store.Remove(key);
                }
            }
        }
    }
}
