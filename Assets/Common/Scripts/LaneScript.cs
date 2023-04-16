using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CapsuleCollider))]
public class LaneScript : MonoBehaviour
{
    //レーンの位置
    [SerializeField]
    private Vector3 LanePosition = Vector3.zero;
    //大きさ
    [SerializeField]
    private Vector3 LaneScale = Vector3.zero;


    //レーンのオブジェクト、コライダー
    private GameObject Cylinder;
    private CapsuleCollider col;

    //当たり判定のオブジェクト
    private GameObject judge;
    //プレイヤーのオブジェクト
    private GameObject Player;
    



    // Start is called before the first frame update
    void Start()
    {

        Player = GameObject.Find("Player");
        Cylinder = GameObject.Find("Cylinder");
        //コンポーネント取得
        col = GetComponent<CapsuleCollider>();
        //当たり判定を表すゲームオブジェクト”judge”を取得
        judge = transform.GetChild(0).gameObject;
        judge.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Playerという名前のタグがついたゲームオブジェクトが重なった場合
        if(other.CompareTag("Player"))
        {
            Debug.Log("Trigger!");
            //当たり判定を表示
            judge.SetActive(true);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        //Playerという名前のタグがついたゲームオブジェクトが離れた場合
        if(other.CompareTag("Player"))
        {
            Debug.Log("leave");
            //当たり判定を非表示
            judge.SetActive(false);
        }
    }



}
