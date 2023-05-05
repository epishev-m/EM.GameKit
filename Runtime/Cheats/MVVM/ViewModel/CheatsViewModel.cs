namespace EM.GameKit
{

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using Foundation;

public sealed class CheatsViewModel : ICheatsViewModel
{
	private readonly RxProperty<List<string>> _visibleGroups = new();

	private readonly RxProperty<List<string>> _enableGroups = new();

	private readonly RxProperty<List<string>> _visibleCheats = new();

	private readonly CheatsModel _cheatModel;

	private readonly CheatsRouter _cheatsRouter;

	private string _filterCheats;

	#region ICheatsViewModel

	public IRxProperty<IEnumerable<string>> VisibleGroups => _visibleGroups;

	public IRxProperty<IEnumerable<string>> EnableGroups => _enableGroups;

	public IRxProperty<IEnumerable<string>> VisibleCheats => _visibleCheats;

	public IEnumerable<string> Groups => _cheatModel.GetGroups();

	public IEnumerable<string> Names => _cheatModel.GetNames();

	public void UpdateAll()
	{
		var groups = _cheatModel.GetGroups().ToArray();
		_visibleGroups.Value = new List<string>(groups);
		_enableGroups.Value = new List<string>(groups);
		_visibleCheats.Value = new List<string>(_cheatModel.GetNames());
	}

	public void EnableAllGroups()
	{
		_enableGroups.Value = new List<string>(_cheatModel.GetGroups());
		_visibleCheats.Value = new List<string>(_cheatModel.GetNames());
	}

	public void DisableAllGroups()
	{
		_enableGroups.Value = new List<string>();
		_visibleCheats.Value = new List<string>();
	}

	public void SetFilterVisibleGroups(string filter)
	{
		var filterLower = filter.ToLower();
		var groups = _cheatModel.GetGroups().Where(group => group.ToLower().Contains(filterLower));
		_visibleGroups.Value = new List<string>(groups);
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
			_enableGroups.Value = new List<string>(EnableGroups.Value)
			{
				name
			};
		}
		else if (!value && _enableGroups.Value.Remove(name))
		{
			_enableGroups.Value = new List<string>(EnableGroups.Value);
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

	private void ApplyFilterVisibleCheats()
	{
		var names = _cheatModel.GetNamesByGroups(_enableGroups.Value);

		if (!string.IsNullOrWhiteSpace(_filterCheats))
		{
			var filterLower = _filterCheats.ToLower();
			names = names.Where(n => n.ToLower().Contains(filterLower));
		}

		_visibleCheats.Value = new List<string>(names);
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