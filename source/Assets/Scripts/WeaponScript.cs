using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {

	public Transform shotPrefab;

	public float shootintRate = 0.25f;

	public float shootCooldown;
	
	void Start () {
		shootCooldown = 0;	
	}

	void Update () {
		if (shootCooldown > 0) 
		{
			shootCooldown -= Time.deltaTime;
		}
	}

	public void Attack()
	{
		//Debug.Log("Pensou em atirar: " + shootCooldown); 

		if (shootCooldown <= 0)
		{
			shootCooldown = shootintRate;

			var shotTransform = Instantiate(shotPrefab) as Transform;
			shotTransform.position = transform.position;

			Debug.Log("Atirou!"); 
		}
	}
}
