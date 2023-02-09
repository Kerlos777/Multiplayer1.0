using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;
using UnityEngine.UI;

public class ButonHandler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Button serverBtn;
    [SerializeField] private Button hostBtn;
    [SerializeField] private Button clientBtn;
    public InputField ipToConnect;
    private string input;
    private void Awake()
    {
        serverBtn.onClick.AddListener(() =>
        {
            Controller.Singleton.networkManager.StartServer();
        });
        hostBtn.onClick.AddListener(() =>
        {
            Controller.Singleton.networkManager.StartHost();
        });
        clientBtn.onClick.AddListener(() =>
        {

            //Controller.Singleton.SetIp(input);
            Controller.Singleton.networkManager.GetComponent<UnityTransport>().SetConnectionData(
                input,
                (ushort) 7777
                );
            Controller.Singleton.networkManager.GetComponent<UnityTransport>().SetDebugSimulatorParameters(

                );
            Controller.Singleton.networkManager.StartClient();
        });
    }
    public void ReadStringInput(string s)
    {
        input = s;
        Debug.Log("lol :" + input);
    }
}
