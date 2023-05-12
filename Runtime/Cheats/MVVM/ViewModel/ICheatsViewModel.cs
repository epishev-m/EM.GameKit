namespace EM.GameKit
{

using System.Collections.Generic;
using Foundation;

public interface ICheatsViewModel
{
	IObservableField<IEnumerable<string>> VisibleGroups { get; }

	IObservableField<IEnumerable<string>> EnableGroups { get; }

	IObservableField<IEnumerable<string>> VisibleCheats { get; }

	IEnumerable<string> Groups { get; }

	IEnumerable<string> Names { get; }

	void UpdateAll();

	void EnableAllGroups();

	void DisableAllGroups();

	void SetFilterVisibleGroups(string filter);

	void SetEnableGroupByName(string name,
		bool value);

	void SetFilterVisibleCheats(string filter);

	IEnumerable<IFieldViewModel> GetFieldViewModelsByName(string name);

	void Close();
}

}