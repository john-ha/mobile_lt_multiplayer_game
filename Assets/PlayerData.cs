using Fusion;
using UnityEngine;

public class PlayerData : NetworkBehaviour
{
    [Networked]
    public string NickName { get; set; }

    [Networked]
    public Color CharactorColor { get; set; }
}