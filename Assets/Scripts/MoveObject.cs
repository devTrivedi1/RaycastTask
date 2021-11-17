using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
	private Camera camera;
	public LayerMask mask;

	// Start is called before the first frame update
	void Start()
	{
		camera = Camera.main;
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButton(0))
		{
			Move();
		}
	}

	void Move()
	{
		Ray ray = camera.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
		{
			this.transform.position = hit.point;
		}
	}
}
