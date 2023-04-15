using System.Linq;
using UnityEngine;

// 音声情報を可視化するオブジェクト
public class AudioVisualizer : MonoBehaviour
{
    // 音声を再生するオブジェクト
    [SerializeField]
    private BGMPlayer _BGMPlayer;

    // サンプル数
    [SerializeField]
    private int _SpectrumNum;

    // スペクトルバーのプレハブ
    [SerializeField]
    private SpectrumBar _BarPrefab;

    // 表示されているスペクトルバー
    [HideInInspector]
    private SpectrumBar[] _SpectrumBars;

    // 初期化時処理
    void Start()
    {
        // スペクトルバーを配置する
        _SpectrumBars = new SpectrumBar[_SpectrumNum * 2];
        for(int i = 0; i < _SpectrumBars.Length; ++i)
        {
            float angle = Mathf.PI * (i + 0.5f) / _SpectrumNum;
            float radius = 1 / (2 * Mathf.Sin(0.2f * Mathf.PI / _SpectrumNum));
            Vector3 eulerAngles = new Vector3(0, angle * Mathf.Rad2Deg, 0);
            Vector3 position = radius * new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle));

            SpectrumBar bar = Instantiate(_BarPrefab);
            bar.transform.parent = transform;
            bar.transform.localPosition = position;
            bar.transform.localEulerAngles = eulerAngles;
            _SpectrumBars[i] = bar;
        }
    }

    // 更新時処理
    void Update()
    {
        // 周波数解析を行い、バーの高さを設定
        float[] left = _BGMPlayer.GetSpectrum(_SpectrumNum, 0);
        float[] right = _BGMPlayer.GetSpectrum(_SpectrumNum, 1);
        float[] spectrum = left.Concat(right.Reverse()).ToArray();
        for (int i = 0; i < _SpectrumBars.Length; ++i)
        {
            _SpectrumBars[i].BarHeight = spectrum[i] * 500.0f + 1;
        }
    }
}
