namespace EM.GameKit
{

using System;

public sealed class Button2CheatFieldModel : ICheatFieldModel
{
	public readonly string Label1;

	public readonly Action Action1;

	public readonly string Label2;

	public readonly Action Action2;

	#region CheatButton

	public Button2CheatFieldModel(string label1,
		Action action1,
		string label2,
		Action action2)
	{
		Label1 = label1;
		Action1 = action1;
		Label2 = label2;
		Action2 = action2;
	}

	#endregion
}

}