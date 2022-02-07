using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

namespace ConnectData
{
    public class PortInfo
    //public struct PortInfo
    {
        private readonly int portID;
        private bool open;
        private GameObject selectedObj;

        public PortInfo(int i)
        {
            this.portID = i;
            this.open = false;
            this.selectedObj = null;
        }

        public bool Open() { this.open = true; return this.open; }

        public bool Close() => this.open = false;

        public bool Status() => this.open;

        public GameObject Connect(GameObject value) => this.selectedObj = value;

        public GameObject GetObject() => this.selectedObj;

        public GameObject DisConnect() => this.selectedObj = null;

        public override string ToString()
        {
            return $"port:{portID}, open:{open}, selectedObj:{selectedObj}";
        }
    }

    public class WindowCache
    {
        private Dictionary<GameObject, Dictionary<int, PortInfo>> data;

        public WindowCache()
        {
            data = new Dictionary<GameObject, Dictionary<int, PortInfo>>();
        }

        ~WindowCache()
        {
            data.Clear();
        }

        private Dictionary<int, PortInfo> GetGateData(GameObject target)
        {
            if (!data.ContainsKey(target))
            {
                data.Add(target, new Dictionary<int, PortInfo>());
            }
            return data[target];
        }

        private void DelGateData(GameObject target)
        {
            if (data.ContainsKey(target))
            {
                data.Remove(target);
            }
        }

        public PortInfo AddPortCacheToGate(GameObject target, int index)
        {
            Dictionary<int, PortInfo> gate = GetGateData(target);

            if (!gate.ContainsKey(index))
            {
                gate.Add(index, new PortInfo(index));
            }
            return gate[index];
        }

        public void DelPortCacheFromGate(GameObject target, int index)
        {
            if (data.ContainsKey(target))
            {
                if (data[target].ContainsKey(index))
                    data[target].Remove(index);
                if (data[target].Count == 0)
                {
                    data[target].Clear();
                    DelGateData(target);
                }
            }
        }

        public PortInfo this[GameObject target, int index]
        {
            get { return data[target][index]; }
            set { data[target][index] = value; }
        }
    }
}