using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesSound : MonoBehaviour
{

    //音ファイルを格納する変数
    private new AudioSource audio;
    [SerializeField] 
    private AudioClip sound;

    //ノーツとなるゲームオブジェクト
    [SerializeField]
    private Collider Obj;

    
    void Start()
    {
     audio = gameObject.AddComponent<AudioSource>();   
    }

    void Update()
    {
        OnTriggerEnter(Obj);
        
    }
    //Notesというゲームオブジェクトのcolliderのトリガーがオンになったら音が鳴りノーツが消える
    private void OnTriggerEnter(Collider Notes)
    {
        //Playerという名前のタグがついたゲームオブジェクトに重なった場合
        if(Notes.gameObject.tag == "Notes")
        {
            //音を鳴らす
            audio.PlayOneShot(sound);
            //オブジェクトを非表示
            Notes.gameObject.SetActive(false);

        }
    }
}
