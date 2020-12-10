namespace Final.Simulator
{
    public class NetworkInterfaceFactory : INetworkInterfaceFactory
    {
        public INetworkInterface Create(ushort port) => new NetworkInterface(port);
    }
}