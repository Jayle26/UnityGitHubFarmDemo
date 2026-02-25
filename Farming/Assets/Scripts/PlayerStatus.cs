using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName ="GameData/New PlayerStatus")]
public class PlayerStatus : ScriptableObject
{
    //角色状态
    public int coin;
    public int hp;
    public int mp;
    //状态栏信息
    public int attack;
    public int defend;
    public int speed;
}
