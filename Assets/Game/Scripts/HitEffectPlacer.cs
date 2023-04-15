using System.Collections.Generic;
using UnityEngine;
using Effekseer;

public class HitEffectPlacer : MonoBehaviour
{
    [SerializeField]
    private List<EffekseerEffectAsset> _EffectAssets;

    [SerializeField]
    private HitEffect _EffectPrefab;

    public void Place(int index, Vector3 position)
    {
        HitEffect effect = Instantiate(_EffectPrefab);
        effect.EffectAsset = _EffectAssets[index];
        effect.transform.position = position;
    }
}
