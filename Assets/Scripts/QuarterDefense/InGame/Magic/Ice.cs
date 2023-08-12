using System.Collections;
using System.Collections.Generic;
using QuarterDefense.InGame.Player;
using UnityEngine;

public class Ice : MonoBehaviour
{
    private float _damage;
    private float _level;
    private float _increaseDamageValue; 
    
    private Character.CharacterRank _characterRank;

    
    
    public void LevelUp()
    {
        _level++;

        _damage += _increaseDamageValue;
    }
}
