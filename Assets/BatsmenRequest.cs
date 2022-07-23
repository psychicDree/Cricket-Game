using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class BatsmenRequest : MonoBehaviour
{
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.gameObject.GetComponent<Rigidbody>())
		{
			Debug.Log("OnCollisionEnter Ball"  + collision.collider.gameObject.name);
			GameObject ball = FindObjectOfType<BowlerRequest>().transform.GetChild(0).gameObject;
			ball.transform.parent = null;
			Destroy(FindObjectOfType<BowlerRequest>().gameObject);
			transform.Find("Main Camera").gameObject.SetActive(true);
			GameFacade.Instance.OnNextBall();
		}
	}
}
