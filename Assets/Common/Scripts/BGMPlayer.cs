using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// 音声を再生するオブジェクト
[RequireComponent(typeof(AudioSource))]
public class BGMPlayer : MonoBehaviour
{
    // 計算済み情報
    private readonly Dictionary<int, float> _CalculatedRatio = new();

    // 音源
    private AudioSource _AudioSource;

    // 初期化時処理
    void Start()
    {
        // コンポーネントを取得する
        _AudioSource = GetComponent<AudioSource>();
    }

    // スペクトル情報を取得する
    public float[] GetSpectrum(int length, int channel)
    {
        // スペクトル情報を取得
        float[] sample = new float[8192];
        _AudioSource.GetSpectrumData(sample, channel, FFTWindow.Hamming);

        // 計算済みでないならば加算範囲の公比を計算する
        if(!_CalculatedRatio.TryGetValue(length, out float ratio))
        {
            ratio = 2.0f;
            for(int i = 0; i < 1_000_000; ++i)
            {
                float numer = 8191 * length - 8192 * (length - 1) * ratio;
                float denom = length * (length * Mathf.Pow(ratio, length - 1) - 8192);
                ratio -= ratio / length + numer / denom;
            }
            _CalculatedRatio[length] = ratio;
        }

        // 配列を作成
        float[] spectrum = new float[length];

        // 対枢軸でスペクトル情報を加工
        float offset = 0.0f;
        for(int i = 0; i < length; ++i)
        {
            float width = Mathf.Pow(ratio, i);
            float topset = offset + width;
            spectrum[i] = Mathf.Log10(Enumerable.Range(0, 8192).Select(i =>
            {
                if(offset <= i && i <= topset) { return sample[i]; }
                else if(i <= offset && offset <= i + 1) { return sample[i] * (i + 1 - offset); }
                else if(i - 1 <= topset && topset <= i) { return sample[i] * (topset - i + 1); }
                else { return 0; }
            }).Sum() / width + 1);
            offset = topset;
        }
        return spectrum;
    }

    // 再生
    public void Play() { _AudioSource.Play(); }

    // 一時停止
    public void Pause() { _AudioSource.Pause(); }

    // 一時停止を解除
    public void UnPause() { _AudioSource.UnPause(); }

    // 停止
    public void Stop() { _AudioSource.Stop(); }
}
