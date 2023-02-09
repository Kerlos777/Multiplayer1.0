using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Netcode.Transports.UNET;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public NetworkManager networkManager;
    public static Controller Singleton;

    public ulong LocalId => networkManager.LocalClient.ClientId;
    //public UNetTransport Transport => (UNetTransport) networkManager.NetworkConfig.NetworkTransport;

    //public void SetIp(string ip) => Transport.ConnectAddress = ip;
    
    void Start()
    {
        networkManager = NetworkManager.Singleton;
        
    }
    private void Awake()
    {
        DontDestroyOnLoad(this);
        if(Singleton != null && Singleton != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Singleton = this;
        }
        DontDestroyOnLoad(this);
    }

}
