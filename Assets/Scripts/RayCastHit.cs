using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastHit : MonoBehaviour
{
	private Camera camera;
	public LayerMask mask;

	void Start()
	{
		camera = Camera.main;
	}
	
	void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{
			MoveObject();
		}
	}

	void MoveObject()
	{
		Ray ray = camera.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if(Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
		{
			Debug.Log("Hit the world");
		}
	}
}
