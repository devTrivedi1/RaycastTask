using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObject : MonoBehaviour
{
	[SerializeField] private GameObject objectToPlace;
	[SerializeField] private LayerMask mask;
	private Camera camera;
	private const string groundLayerName = "Ground";

	// Start is called before the first frame update
	void Start()
	{
		camera = Camera.main;
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			PlacingObjects();
		}
	}

	void PlacingObjects()
	{
		Ray ray = camera.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
		{
			if (hit.transform.tag == groundLayerName)
			{
				CreateObjects();
			}
		}
	}

	void CreateObjects()
	{
		Instantiate(objectToPlace);
		objectToPlace.AddComponent<MoveObject>();
	}
}
