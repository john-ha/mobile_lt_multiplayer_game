using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Fusion;
using UnityEngine.SceneManagement;

public class HelloPlayer : NetworkBehaviour
{
    [SerializeField]
    private TMP_Text _playerName;
    [SerializeField]
    private GameObject PlayerRenderer;
    private GameObject _planeObject;
    
    public override void Spawned()
    {
        _planeObject = GameObject.Find("Plane");
        LoadPlayerSetting();
    }

    public void LoadPlayerSetting()
    {
        var networkObject = GetComponent<NetworkObject>();
        var playerData = networkObject.GetComponent<PlayerData>();
        _playerName.text = playerData.NickName;
        PlayerRenderer.GetComponent<Renderer>().material.color = playerData.CharactorColor;
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, _planeObject.transform.position);
        if(distance > 20f)
        {
            GameObject.Find("Game Controller").GetComponent<GameController>().Reset();
        }
    }
}
