using System.Collections.Generic;
using UnityEngine;
using Effekseer;

// ヒットエフェクトを設置する
public class HitEffectPlacer : MonoBehaviour
{
    // エフェクトリスト
    [SerializeField]
    private List<EffekseerEffectAsset> _EffectAssets;

    // エフェクトオブジェクトのプレハブ
    [SerializeField]
    private HitEffect _EffectPrefab;

    // エフェクトを設置する
    public void Place(int index, Vector3 position)
    {
        HitEffect effect = Instantiate(_EffectPrefab);
        effect.EffectAsset = _EffectAssets[index];
        effect.transform.position = position;
    }
}
