using NUnit.Framework;
using Photon.Pun;

public class ConnectionTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void When_Client_IsConnected_ToPhotonServer()
    {
        PhotonNetwork.ConnectUsingSettings();
        Assert.True(PhotonNetwork.IsConnected);
    }
}
