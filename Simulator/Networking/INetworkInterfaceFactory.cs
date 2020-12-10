using System;
using System.Dynamic;

namespace Final.Simulator
{
    public interface INetworkInterfaceFactory
    {
        INetworkInterface Create(UInt16 port);
    }
}