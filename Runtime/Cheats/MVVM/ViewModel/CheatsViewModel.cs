namespace EM.GameKit
{

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using Foundation;
using UI;

public sealed class CheatsViewModel : ICheatsViewModel
{
	private readonly ObservableField<List<string>> _visibleGroups = new();

	private readonly ObservableField<List<string>> _enableGroups = new();

	private readonly ObservableField<List<string>> _visibleCheats = new();

	private readonly CheatsModel _cheatModel;

	private readonly CheatsRouter _cheatsRouter;

	private string _filterCheats;

	#region ICheatsViewModel
	
	void IViewModel.Initialize()
	{
		UpdateAll();
	}

	public IObservableField<IEnumerable<string>> VisibleGroups => _visibleGroups;

	public IObservableField<IEnumerable<string>> EnableGroups => _enableGroups;

	public IObservableField<IEnumerable<string>> VisibleCheats => _visibleCheats;

	public IEnumerable<string> Groups => _cheatModel.GetGroups();

	public IEnumerable<string> Names => _cheatModel.GetNames();

	public void EnableAllGroups()
	{
		var enableGroups = new List<string>(_cheatModel.GetGroups());
		var visibleCheats = new List<string>(_cheatModel.GetNames());
		_enableGroups.SetValue(enableGroups); 
		_visibleCheats.SetValue(visibleCheats);
	}

	public void DisableAllGroups()
	{
		_enableGroups.SetValue(new List<string>());
		_visibleCheats.SetValue(new List<string>());
	}

	public void SetFilterVisibleGroups(string filter)
	{
		var filterLower = filter.ToLower();
		var groups = _cheatModel.GetGroups()
			.Where(group => group.ToLower().Contains(filterLower))
			.ToList();
		_visibleGroups.SetValue(groups);
	}

	public void SetEnableGroupByName(string name,
		bool value)
	{
		if (!_cheatModel.GetGroups().Contains(name))
		{
			return;
		}

		if (value && !EnableGroups.Value.Contains(name))
		{
			var enableGroups = new List<string>(EnableGroups.Value)
			{
				name
			};

			_enableGroups.SetValue(enableGroups);
		}
		else if (!value && _enableGroups.Value.Remove(name))
		{
			var enableGroups = new List<string>(EnableGroups.Value);
			_enableGroups.SetValue(enableGroups);
		}
		
		ApplyFilterVisibleCheats();
	}

	public void SetFilterVisibleCheats(string filter)
	{
		_filterCheats = filter;
		ApplyFilterVisibleCheats();
	}

	public IEnumerable<IFieldViewModel> GetFieldViewModelsByName(string name)
	{
		var fields = _cheatModel.GetFieldsByName(name);
		var resultList = new List<IFieldViewModel>();

		foreach (var field in fields)
		{
			var result = CreateFieldViewModel(field);

			if (result.Failure)
			{
				continue;
			}

			resultList.Add(result.Data);
		}

		return resultList;
	}

	public void Close()
	{
		_cheatsRouter.CloseAsync(new CancellationToken()).Forget();
	}

	#endregion

	#region CheatsViewModel

	public CheatsViewModel(CheatsModel cheatModel,
		CheatsRouter cheatsRouter)
	{
		_cheatModel = cheatModel;
		_cheatsRouter = cheatsRouter;
	}

	private void UpdateAll()
	{
		var groups = _cheatModel.GetGroups().ToArray();
		var visibleGroups = new List<string>(groups);
		var enableGroups = new List<string>(groups);
		var visibleCheats = new List<string>(_cheatModel.GetNames());
		_visibleGroups.SetValue(visibleGroups);
		_enableGroups.SetValue(enableGroups);
		_visibleCheats.SetValue(visibleCheats);
	}

	private void ApplyFilterVisibleCheats()
	{
		var names = _cheatModel.GetNamesByGroups(_enableGroups.Value);

		if (!string.IsNullOrWhiteSpace(_filterCheats))
		{
			var filterLower = _filterCheats.ToLower();
			names = names.Where(n => n.ToLower().Contains(filterLower));
		}

		var visibleCheats = new List<string>(names);
		_visibleCheats.SetValue(visibleCheats);
	}

	private static Result<IFieldViewModel> CreateFieldViewModel(ICheatFieldModel fieldModel)
	{
		Requires.NotNullParam(fieldModel, nameof(fieldModel));

		IFieldViewModel viewModel = fieldModel switch
		{
			InfoCheatFieldModel model => new InfoFieldViewModel(model),
			BoolCheatFieldModel model => new BoolFieldViewModel(model),
			IntCheatFieldModel model => new IntFieldViewModel(model),
			LongCheatFieldModel model => new LongFieldViewModel(model),
			FloatCheatFieldModel model => new FloatFieldViewModel(model),
			DoubleCheatFieldModel model => new DoubleFieldViewModel(model),
			TextCheatFieldModel model => new TextFieldViewModel(model),
			Vector2CheatFieldModel model => new Vector2FieldViewModel(model),
			Vector3CheatFieldModel model => new Vector3FieldViewModel(model),
			Vector4CheatFieldModel model => new Vector4FieldViewModel(model),
			RectCheatFieldModel model => new RectFieldViewModel(model),
			SliderCheatFieldModel model => new SliderFieldViewModel(model),
			IntSliderCheatFieldModel model => new IntSliderFieldViewModel(model),
			MinMaxSliderCheatFieldModel model => new MinMaxSliderFieldViewModel(model),
			IntMinMaxSliderCheatFieldModel model => new IntMinMaxSliderFieldViewModel(model),
			StringDropdownCheatFieldModel model => new StringDropdownFieldViewModel(model),
			ButtonCheatFieldModel model => new ButtonFieldViewModel(model),
			Button2CheatFieldModel model => new Button2FieldViewModel(model),
			Button3CheatFieldModel model => new Button3FieldViewModel(model),
			_ => null
		};

		if (viewModel == null)
		{
			return new ErrorResult<IFieldViewModel>($"Type {fieldModel.GetType()} not supported");
		}

		return new SuccessResult<IFieldViewModel>(viewModel);
	}

	#endregion
}

}