using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSelection : MonoBehaviour
{
	private MoveObject theObject;
	private Camera camera;

	void Start()
	{
		camera = Camera.main;
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			SelectObject();

		}
		if (Input.GetMouseButtonUp(0))
		{
			SelectObject();
			if (theObject != null)
			{
				theObject.enabled = false;

				theObject = null;
			}
		}
	}

	void SelectObject()
	{
		RaycastHit hit;
		Ray ray = camera.ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast(ray, out hit))
		{
			GameObject obj = hit.transform.gameObject;
			var objectMover = obj.GetComponent<MoveObject>();
			if (objectMover != null)
			{
				theObject = objectMover;
				objectMover.enabled = true;
			}
		}
	}

	void OnDrawGizmos()
	{
		Gizmos.DrawRay(this.transform.position, this.transform.forward * 100);
	}
}
