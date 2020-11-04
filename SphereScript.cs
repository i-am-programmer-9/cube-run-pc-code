using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereScript : MonoBehaviour
{
	public Vector3 changePos;
	public float time;
	void Update()
	{
		Invoke("ChangingPosition", time);
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Barrier")
		{
			transform.position += new Vector3(0f, 5f, 0f);
		}
		if(other.tag == "LavaBarrier")
		{
			GameObject.Destroy(this, 1f);
		}
	}
	void ChangingPosition()
	{
		transform.position +=changePos;
	}
}
