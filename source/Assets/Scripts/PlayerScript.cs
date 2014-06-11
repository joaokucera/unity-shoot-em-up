using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	// A velocidade da nave.
	public Vector2 speed = new Vector2 (10, 10);

	// Guarda o movimento da nave.
	private Vector2 movement;

	// Update is called once per frame
	void Update () {
	
		// Coleta os eixos de movimentacao.
		float inputX = Input.GetAxis ("Horizontal");
		float inputY = Input.GetAxis ("Vertical");

		// Movimentacao pela direcao.
		movement = new Vector2 (
			inputX * speed.x,
			inputY * speed.y);

		// Verificando se o player está atirando.
		if (Input.GetButtonDown ("Fire1")) 
		{
			WeaponScript weapon = GetComponent<WeaponScript>();

			if (weapon != null && weapon.shootCooldown <= 0)
			{
				weapon.Attack();

				// Som de tiro do player.
				SoundEffectScript.Instance.MakePlayerShotSound();
			}
		}

		// Verificando o posicionamento do player dentro dos limites da câmera.
		var distanceZ = (transform.position - Camera.main.transform.position).z;

		var leftBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distanceZ)).x;

		var rightBorder = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distanceZ)).x;

		var topBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distanceZ)).y;

		var bottomBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, distanceZ)).y;

		transform.position = new Vector3 (
			Mathf.Clamp (transform.position.x, leftBorder, rightBorder),
			Mathf.Clamp (transform.position.y, topBorder, bottomBorder),
			transform.position.z
		);
	}

	void FixedUpdate() {
		// Movimento do objeto.
		rigidbody2D.velocity = movement;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Enemy") 
		{
			var damagePlayer = false;

			EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript>();

			if (enemy != null)
			{
				HealthScript enemyHealth = enemy.GetComponent<HealthScript>();

				if (enemyHealth != null)
				{
					enemyHealth.Damage(enemyHealth.hp);
				}

				damagePlayer = true;
			}

			if (damagePlayer)
			{
				HealthScript playerHealth = GetComponent<HealthScript>();

				if (playerHealth != null)
				{
					playerHealth.Damage(1);
				}
			}
		}
	}

	void OnDestroy()
	{
		transform.parent.gameObject.AddComponent<GameOverScript> ();
	}
}
