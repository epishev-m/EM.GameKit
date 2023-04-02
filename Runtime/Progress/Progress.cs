namespace EM.GameKit
{

using System.Collections.Generic;
using System.Linq;
using Foundation;

public abstract class Progress : IProgress
{
	private readonly List<ProgressPhase> _phases = new();

	private float _weightSum;

	#region IProgress

	public float Value => Calculate();

	#endregion

	#region Progress

	protected void AddProgress(ProgressPhase phase)
	{
		Requires.NotNullParam(phase, nameof(phase));

		_phases.Add(phase);
		_weightSum += phase.Weight;
	}

	private float Calculate()
	{
		if (_weightSum == 0)
		{
			return 1f;
		}

		var result = _phases.Sum(p => p.Value * p.Weight / _weightSum);

		return result;
	}

	#endregion
}

}