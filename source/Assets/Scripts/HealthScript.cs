using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

	public int hp = 1;

	public void Damage(int damageCount)
	{
		hp -= damageCount;

		if (hp <= 0) 
		{
			// Criando o efeito de partícula.
			SpecialEffectScript.Instance.Explosion(transform.position);

			// Criando o som da explosão.
			SoundEffectScript.Instance.MakeExplosionSound();

			// Morte!
			Destroy(gameObject);
		}
	}
}