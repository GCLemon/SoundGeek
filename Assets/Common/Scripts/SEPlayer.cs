using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SEPlayer : MonoBehaviour
{
    private AudioSource _AudioSource;

    [SerializeField]
    private List<AudioClip> _SoundEffects;

    void Start()
    {
        _AudioSource = GetComponent<AudioSource>();
    }

    public void Play(int index)
    {
        _AudioSource.PlayOneShot(_SoundEffects[index]);
    }
}
