using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class tapping : MonoBehaviour
{
   void OnCollisionEnter(Collision collision)
	{
		// 衝突した相手にPlayerタグが付いているとき
		if (collision.gameObject.tag == "Player")
		{
			//消える
			Destroy(gameObject, 0f);
		}
	}
}