namespace EM.GameKit
{

using UnityEngine;

public class ProgressPhase
{
	public readonly float Weight;

	private float _value;

	#region ProgressPhase

	public ProgressPhase(float weight)
	{
		Weight = weight;
	}

	public float Value
	{
		get => _value;
		set => _value = Mathf.Clamp(value, 0f, 1f);
	}

	#endregion
}

}