using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	private WeaponScript weapon;

	private bool canBeDesytroyed = false;

	void Start () {

		collider2D.enabled = false;

		weapon = GetComponent<WeaponScript> ();	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (weapon != null && weapon.shootCooldown <= 0) 
		{
			weapon.Attack();

			// Criando o som de tiro do inimigo.
			SoundEffectScript.Instance.MakeEnemyShotSound();
		}

		if (renderer.IsVisibleFrom(Camera.main))
		{
			collider2D.enabled = true;

			canBeDesytroyed = true;
		}
		else
		{
			if (canBeDesytroyed)
			{
				Destroy(gameObject);
			}
		}
	}
}
