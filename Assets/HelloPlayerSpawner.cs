using UnityEngine;
using System.Collections;
using Fusion;
using TMPro;
using UnityEngine.UIElements;

public class HelloPlayerSpawner : SimulationBehaviour, IPlayerJoined
{
    public GameObject PlayerPrefab;

    public void PlayerJoined(PlayerRef player)
    {
        if (player == Runner.LocalPlayer)
        {
            var playerObject = Runner.Spawn(PlayerPrefab, new Vector3(0, 2, 0), Quaternion.identity, player);
            var playerData = playerObject.GetComponent<PlayerData>();
            var GUIPanel = GameObject.Find("GUIPanel");
            playerData.NickName = GUIPanel.transform.Find("Name_InputField").GetComponent<TMP_InputField>().text;
            playerData.CharactorColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            playerObject.GetComponent<HelloPlayer>().LoadPlayerSetting();
            GUIPanel.SetActive(false);
        }
    }
}

