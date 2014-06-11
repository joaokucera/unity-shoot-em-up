using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class ScrollingScript : MonoBehaviour {

	public Vector2 speed = new Vector2(1, 1);

	public Vector2 direction = new Vector2(-1, 0);

	public bool isLooping = false;

	private List<Transform> backgroundPart;

	void Start()
	{
		if (isLooping)
		{
			backgroundPart = new List<Transform>();

			for (int i = 0; i < transform.childCount; i++) {

				Transform child = transform.GetChild(i);

				if (child.renderer != null)
				{
					backgroundPart.Add(child);
				}
			}

			backgroundPart = backgroundPart
				.OrderBy(t => t.position.x).ToList();
		}
	}

	void Update () {

		Vector2 movement = new Vector2 (speed.x * direction.x, speed.y * direction.y);
		movement *= Time.deltaTime;

		transform.Translate (movement);

		if (isLooping)
		{
			Transform firstChild = backgroundPart.FirstOrDefault();

			if (firstChild != null)
			{
				if (firstChild.position.x < Camera.main.transform.position.x)
				{
					if (!firstChild.renderer.IsVisibleFrom(Camera.main))
					{
						Transform lastChild = backgroundPart.LastOrDefault();

						Vector3 lastPosition = lastChild.position;
						Vector3 lastSize = (lastChild.renderer.bounds.max - 
						                    lastChild.renderer.bounds.min);


						firstChild.position = new Vector3(
							lastPosition.x + lastSize.x,
							firstChild.position.y,
							firstChild.position.z);

						backgroundPart.Remove(firstChild);
						backgroundPart.Add(firstChild);
					}
				}
			}
		}
	}
}
