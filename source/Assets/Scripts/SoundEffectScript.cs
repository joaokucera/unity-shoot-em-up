using UnityEngine;
using System.Collections;

public class SoundEffectScript : MonoBehaviour {

	public static SoundEffectScript Instance;

	public AudioClip explosionSound;
	public AudioClip playerShotSound;
	public AudioClip enemyShotSound;

	void Awake()
	{
		if (Instance != null)
		{
			Debug.LogError("Existem múltiplas instâncias do script SoundEffectScript.");
		}

		Instance = this;
	}

	public void MakeExplosionSound()
	{
		MakeSound (explosionSound);
	}

	public void MakePlayerShotSound()
	{
		MakeSound (playerShotSound);
	}

	public void MakeEnemyShotSound()
	{
		MakeSound (enemyShotSound);
	}

	private void MakeSound(AudioClip originalClip)
	{
		AudioSource.PlayClipAtPoint (originalClip, transform.position);
	}
}
