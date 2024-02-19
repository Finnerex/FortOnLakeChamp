using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class VignetteEffect : MonoBehaviour {

	public bool on = false;

	[Range(0f, 100f)]
	public float amount = 1f;

	public Material material;
	private static readonly int Amount = Shader.PropertyToID("_Amount");
	
	private float _currentWakeupTime;
	[SerializeField] private float wakeupTime = 2f;

	void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
		if(on)
		{
			Graphics.Blit(src, dest, material);
		}
		else
		{
			Graphics.Blit(src, dest);
		}
	}


	void Update ()
	{

		if (amount <= 0)
			on = false;

		if (!on) return;
		
		material.SetFloat(Amount, amount);

		if (_currentWakeupTime < wakeupTime)
		{
			_currentWakeupTime += Time.deltaTime;
			amount = Mathf.Lerp(20, -amount, _currentWakeupTime / wakeupTime);
		}
	}
}
