using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using System;

namespace BaseModel
{
    public class Port
    {
        public int index { get; private set; }
        public bool Bit { get; set; } = false;
        public Dir type { get; private set; }

        public Port From
        {
            get => _from;
            private set
            {
                _from = value;
            }
        }
        public Port To
        {
            get => _to;
            private set
            {
                _to = value;
            }
        }

        private Port _from;
        private Port _to;

        public void ConnectTo(Port to)
        {
            this.To = to;
            to.From = this;
        }

        public void ConnectFrom(Port from)
        {
            this.From = from;
            from.To = this;
        }

        public void Disconnect()
        {
            if (type == Dir.exit)
                this.To = null;
            else
                this.From = null;
        }

        public void Update()
        {
            switch (type)
            {
                case Dir.enter:
                    if (_from != null)
                        this.Bit = _from.Bit;
                    break;
                case Dir.exit:
                    if (_to != null)
                        To.Bit = this.Bit;
                    break;
                case Dir.sel:
                    if (_from != null)
                        this.Bit = _from.Bit;
                    break;
            }
        }

        public Port Connected()
        {
            switch (type)
            {
                case Dir.enter:
                    return this._from;
                case Dir.exit:
                    return this._to;
                case Dir.sel:
                    return this._from;
                default:
                    return null;
            }
        }

        public override string ToString()
        {
            string name = "";
            //return base.ToString();
            switch (type)
            {
                case Dir.enter:
                    name = "in";
                    break;
                case Dir.exit:
                    name = "out";
                    break;
                case Dir.sel:
                    name = "sel";
                    break;
            }
            return (name + String.Format("[{0}]", this.index));
        }

        public Port(int index, Dir option)
        {
            this.index = index;
            type = option;
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
                case Dir.sel:
                    _to = this;
                    _from = null;
                    break;
            }
        }

        [Flags]
        public enum Dir
        {
            enter,
            exit,
            sel
        }
    }
}
