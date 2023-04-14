using System.Linq;
using UnityEngine;

// スペクトルバー
[RequireComponent(typeof(MeshRenderer))]
public class SpectrumBar : MonoBehaviour
{
    // 子オブジェクトのメッシュ情報
    private Mesh _EdgeMesh;
    private Mesh _FaceMesh;

    // 子オブジェクトの頂点情報
    private Vector3[] _EdgeVertices;
    private Vector3[] _FaceVertices;

    // スペクトルバーの子オブジェクト
    public GameObject Edge;
    public GameObject Face;

    // バーの高さ
    public float BarHeight;

    // 初期化時処理
    void Start()
    {
        // メッシュを取得
        _EdgeMesh = Edge.GetComponent<MeshFilter>().sharedMesh;
        _FaceMesh = Face.GetComponent<MeshFilter>().sharedMesh;

        // 頂点情報を取得
        _EdgeVertices = _EdgeMesh.vertices;
        _FaceVertices = _FaceMesh.vertices;
    }

    // 更新時処理
    void Update()
    {
        // 頂点情報を更新
        Vector3 filter(Vector3 value) => value.y >= 0.5 ? value + new Vector3(0, BarHeight - 1, 0) : value;
        _EdgeMesh.vertices = _EdgeVertices.Select(filter).ToArray();
        _FaceMesh.vertices = _FaceVertices.Select(filter).ToArray();
    }
}
