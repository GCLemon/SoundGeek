using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{


   void OnCollisionEnter(Collision collision)
	{


		// 衝突した相手にRespawnタグが付いているとき
		if (collision.gameObject.tag == "Respawn"){

			//消える
			Destroy(gameObject, 0f);
		}

    }
}