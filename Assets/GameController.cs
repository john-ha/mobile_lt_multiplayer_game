using System.Collections;
using System.Collections.Generic;
using Fusion;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public NetworkRunner _networkRunner;
    
    public void StartGame()
    {
        var startGameArgs = new StartGameArgs()
        {
            GameMode = GameMode.Shared,
            SessionName = "OnlyRoom",
            Scene = SceneManager.GetActiveScene().buildIndex
        };
        _networkRunner.StartGame(startGameArgs);
        Debug.Log("StartGame");
    }

     public void Reset()
    {
        Destroy(GameObject.Find("Network Runner"));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
