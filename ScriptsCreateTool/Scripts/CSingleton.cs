using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTools
{
    public class CSingleton<T> where T : class, new()
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new T();
                }
                return _instance;
            }
            set { _instance = value; }
        }

        public T GetInstance()
        {
            if (_instance==null)
            {
                _instance=new T();
            }
            return _instance;
        }
    }
}
