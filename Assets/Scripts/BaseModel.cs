using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using System;

namespace BaseModel
{
    public class Port
    {
        public bool[] Bit { get; set; }

        public Port From
        {
            get => _from;
            private set
            {
                _from = value;
                value.To = _from;
            }
        }
        public Port To
        {
            get => _to;
            private set
            {
                _to = value;
                value.From = _to;
            }
        }

        private Port _from;
        private Port _to;

        public void Send(Port to)
        {
            this.To = to;
            to.Bit = this.Bit;
        }

        public void Send(Port to, bool[] bit)
        {
            this.To = to;
            this.Bit = bit;
            to.Bit = this.Bit;
        }

        public void Recept(Port from)
        {
            this.From = from;
            this.Bit = from.Bit;
        }

        public void Recept(bool[] bit)
        {
            this.Bit = bit;
        }

        public Port(int bitSize, Dir option)
        {
            Bit = new bool[bitSize];
            for (int i = 0; i < bitSize; i++)
            {
                Bit[i] = false;
            }

            switch (option)
            {
                case Dir.enter:
                    _to = this;
                    _from = null;
                    break;
                case Dir.exit:
                    _from = this;
                    _to = null;
                    break;
            }
        }
        [Flags]
        public enum Dir
        {
            enter,
            exit
        }
    }

    public static class GateModel
    {
        public static bool[] AndGate(bool[] a, bool[] b)
        {
            if (a.Length != b.Length)
                return null;

            bool[] outBit = new bool[a.Length];

            for (int i = 0; i < a.Length; i++)
            {
                outBit[i] = a[i] & b[i];
            }
            return outBit;
        }

        public static bool[] OrGate(bool[] a, bool[] b)
        {
            if (a.Length != b.Length)
                return null;

            bool[] outBit = new bool[a.Length];

            for (int i = 0; i < a.Length; i++)
            {
                outBit[i] = a[i] | b[i];
            }
            return outBit;
        }

        public static bool[] XorGate(bool[] a, bool[] b)
        {
            if (a.Length != b.Length)
                return null;

            bool[] outBit = new bool[a.Length];

            for (int i = 0; i < a.Length; i++)
            {
                outBit[i] = a[i] ^ b[i];
            }
            return outBit;
        }

        public static bool[] NotGate(bool[] a)
        {
            bool[] outBit = new bool[a.Length];

            for (int i = 0; i < a.Length; i++)
            {
                outBit[i] = !a[i];
            }
            return outBit;
        }
    }
}
