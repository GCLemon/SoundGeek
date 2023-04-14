using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// スペクトルバー
[RequireComponent(typeof(MeshRenderer))]
public class SpectrumBar : MonoBehaviour
{
    // 子オブジェクトのメッシュ情報
    private List<Mesh> _MeshList;

    // 子オブジェクトの頂点情報
    private List<Vector3[]> _VerticesList;

    // スペクトルバーの子オブジェクト
    public List<GameObject> ObjectList = new();

    // バーの高さ
    public float BarHeight;

    // 初期化時処理
    void Start()
    {
        // メッシュ情報・頂点情報を取得
        _MeshList = ObjectList.Select(value => value.GetComponent<MeshFilter>().sharedMesh).ToList();

        // 頂点情報を取得
        _VerticesList = _MeshList.Select(value => value.vertices).ToList();
    }

    // 更新時処理
    void Update()
    {
        // 頂点情報を更新
        for(int i = 0; i < _MeshList.Count; ++i)
        {
            _MeshList[i].vertices = _VerticesList[i].Select(value =>
            {
                Vector3 stretch = new(0, BarHeight - 1, 0);
                if (value.y >= 0.5) { return value + stretch; } else { return value; }
            }).ToArray();
        }
    }
}
