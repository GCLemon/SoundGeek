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
			// 0.2秒後に消える
			Destroy(gameObject, 0f);
		}
	}
}