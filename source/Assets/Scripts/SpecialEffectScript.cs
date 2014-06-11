using UnityEngine;
using System.Collections;

public class SpecialEffectScript : MonoBehaviour {

	public static SpecialEffectScript Instance;

	public ParticleSystem smokeEffect;
	public ParticleSystem fireEffect;

	void Awake()
	{
		if (Instance != null)
		{
			Debug.LogError("Existem múltiplas instâncias do script SpecialEffectScript.");
		}

		Instance = this;
	}

	public void Explosion(Vector3 position)
	{
		// Criando o efeito de fumaça.
		InstantiateParticleSystem (smokeEffect, position);

		// Criando o efeito de fogo.
		InstantiateParticleSystem (fireEffect, position);
	}

	private ParticleSystem InstantiateParticleSystem(ParticleSystem prefab, Vector3 position)
	{
		ParticleSystem newParticleSystem = Instantiate (
			prefab,
			position,
			Quaternion.identity) as ParticleSystem;

		Destroy (newParticleSystem.gameObject, newParticleSystem.startLifetime);

		return particleSystem;
	}
}
