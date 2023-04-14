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

    // 表示するスペクトルバー
    [SerializeField]
    private SpectrumBar _BarPrefab;
    private SpectrumBar[] _SpectrumBars;

    // 初期化時処理
    void Start()
    {
        // スペクトルバーを配置する
        _SpectrumBars = new SpectrumBar[_SpectrumNum];
        for(int i = 0; i < _SpectrumNum; ++i)
        {
            SpectrumBar bar = Instantiate(_BarPrefab);
            bar.transform.parent = transform;
            bar.transform.position = new Vector3(2.0f * i - _SpectrumNum + 1.0f, 0, 60);
            _SpectrumBars[i] = bar;
        }
    }

    // 更新時処理
    void Update()
    {
        // 周波数解析を行い、バーの高さを設定
        float[] spectrum = _BGMPlayer.GetSpectrum(_SpectrumNum, 0);
        for (int i = 0; i < _SpectrumNum; ++i)
        {
            _SpectrumBars[i].BarHeight = spectrum[i] * 500.0f + 1;
        }
    }
}
