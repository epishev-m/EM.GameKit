namespace EM.GameKit
{

using System;

public sealed class Button3CheatFieldModel : ICheatFieldModel
{
	public readonly string Label1;

	public readonly Action Action1;

	public readonly string Label2;

	public readonly Action Action2;

	public readonly string Label3;

	public readonly Action Action3;

	#region CheatButton

	public Button3CheatFieldModel(string label1,
		Action action1,
		string label2,
		Action action2,
		string label3,
		Action action3)
	{
		Label1 = label1;
		Action1 = action1;
		Label2 = label2;
		Action2 = action2;
		Label3 = label3;
		Action3 = action3;
	}

	#endregion
}

}