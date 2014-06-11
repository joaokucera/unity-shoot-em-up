using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour {

	// A velocidade da nave.
	public Vector2 speed = new Vector2 (5, 5);

	// Guarda o movimento da nave.
	private Vector2 movement;

	public Vector2 direction = new Vector2 (-1, 0);

	// Update is called once per frame
	void Update () {
	
		// Movimentacao pela direcao.
		movement = new Vector2 (
			 direction.x * speed.x,
			 direction.y * speed.y);
	}

	void FixedUpdate() {
		// Movimento do objeto.
		rigidbody2D.velocity = movement;
	}
}
