namespace EM.GameKit
{

using System;

public interface ICheatBinding
{
	ICheatBinding AddInfo(string info);

	ICheatBinding AddField<T>(T field)
		where T : class;

	ICheatBinding AddButton(string label,
		Action action);

	ICheatBinding AddButton(string label,
		Action action,
		string label2,
		Action action2);

	ICheatBinding AddButton(string label,
		Action action,
		string label2,
		Action action2,
		string label3,
		Action action3);
}

}