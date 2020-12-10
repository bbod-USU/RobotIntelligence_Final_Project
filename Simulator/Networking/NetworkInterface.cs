using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Final.Simulator
{
    public class NetworkInterface : INetworkInterface
    {
        public UdpClient UdpClient { get; }
        public Action<string> MessageRecieved;

        private UInt16 _remotePort { get; }
        private IPAddress _remoteIP { get; }
        private UInt16 _localPort { get; }
        private IPAddress _localIP { get; }

        public NetworkInterface(IPAddress localIp, UInt16 localPort, )
        {
            _remoteEp = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
            UdpClient = new UdpClient();
            Task.Run(() => RegisterForMessages());

        }

        private void RegisterForMessages()
        {
            while (true)
            {
                var remoteEP = new IPEndPoint(_remoteIP, _remotePort);
                MessageRecieved.Invoke(UdpClient.Receive(ref remoteEP).ToString());
                UdpClient.Send(new byte[] {1}, 1, remoteEP);
            }
        }

        private void TMP(object o)
        {
            throw new NotImplementedException();
        }

    }
}