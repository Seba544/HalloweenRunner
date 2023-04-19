using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSystem : MonoBehaviour
{
    [SerializeField] AudioEvents _audioEvents;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _playerShootAudioClip;
    [SerializeField] AudioClip _enemyDeathAudioClip;
    // Start is called before the first frame update
    void Start()
    {
        _audioEvents.PlayPlayerShoot += PlayPlayerShootSound;
        _audioEvents.EnemyDeath += PlayEnemyDeathSound;
    }

    private void PlayPlayerShootSound() => _audioSource.PlayOneShot(_playerShootAudioClip);
    
    private void PlayEnemyDeathSound() => _audioSource.PlayOneShot(_enemyDeathAudioClip);

    void OnDestroy()
    {
        _audioEvents.PlayPlayerShoot -= PlayPlayerShootSound;
        _audioEvents.EnemyDeath -= PlayEnemyDeathSound;
    }
}
