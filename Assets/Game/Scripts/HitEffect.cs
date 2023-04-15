using UnityEngine;
using Effekseer;

// ヒットエフェクトを再生する
[RequireComponent(typeof(EffekseerEmitter))]
public class HitEffect : MonoBehaviour
{
    // 再生時間
    private float _ElapsedTime = 0.0f;

    // 再生するエフェクト
    public EffekseerEffectAsset EffectAsset;

    // 初期化時処理
    void Start()
    {
        EffekseerEmitter emitter = GetComponent<EffekseerEmitter>();
        emitter.effectAsset = EffectAsset;
        emitter.Play();
    }

    // 更新時処理
    void Update()
    {
        _ElapsedTime += Time.deltaTime;
        if(_ElapsedTime >= 0.75f) { gameObject.SetActive(false); }
    }
}
