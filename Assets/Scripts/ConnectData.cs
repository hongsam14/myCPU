using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

namespace ConnectData
{
    public class WindowInfo
    {
        private readonly int id;
        public bool open { get; set; }
        public GameObject selectedObj { get; set; }

        public WindowInfo(int i)
        {
            this.id = i;
            this.open = false;
            this.selectedObj = null;
        }

        public override string ToString()
        {
            return $"window:{id}, open:{open}, selectedObj:{selectedObj}";
        }
    }

    public class WindowCache
    {
        private Dictionary<int, WindowInfo> data;

        public WindowCache()
        {
            data = new Dictionary<int, WindowInfo>();
        }

        ~WindowCache()
        {
            data = null;
        }

        public WindowInfo AddWindowCache(int id)
        {
            if (!data.ContainsKey(id))
            {
                data.Add(id, new WindowInfo(id));
            }
            return data[id];
        }

        public void DelWindowCache(int id)
        {
            if (data.ContainsKey(id))
            {
                data.Remove(id);
            }
        }

        public WindowInfo this[int id]
        {
            get { return data[id]; }
            set { data[id] = value; }
        }
    }
}