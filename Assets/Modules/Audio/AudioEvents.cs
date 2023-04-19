using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Audio Events", menuName = "ScriptableObjects/Audio Events", order = 1)]
public class AudioEvents : ScriptableObject
{
    public event Action PlayPlayerShoot;
    public void OnPlayPlayerShoot() => PlayPlayerShoot?.Invoke();
    public event Action EnemyDeath;
    public void OnEnemyDeath() => EnemyDeath?.Invoke();
}
