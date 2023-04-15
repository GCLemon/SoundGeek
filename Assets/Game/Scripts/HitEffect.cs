using UnityEngine;
using Effekseer;

[RequireComponent(typeof(EffekseerEmitter))]
public class HitEffect : MonoBehaviour
{
    private float _ElapsedTime = 0.0f;

    public EffekseerEffectAsset EffectAsset;

    void Start()
    {
        EffekseerEmitter emitter = GetComponent<EffekseerEmitter>();
        emitter.effectAsset = EffectAsset;
        emitter.Play();
    }

    void Update()
    {
        _ElapsedTime += Time.deltaTime;
        if(_ElapsedTime >= 0.75f) { gameObject.SetActive(false); }
    }
}
