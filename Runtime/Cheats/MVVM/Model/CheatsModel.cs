namespace EM.GameKit
{

using System.Collections.Generic;
using System.Linq;

public sealed class CheatsModel
{
	private readonly ICheatBinder _binder;

	#region CheatsModel

	public CheatsModel(ICheatBinder binder)
	{
		_binder = binder;
	}

	public IEnumerable<string> GetNames()
	{
		return _binder.GetNames();
	}

	public IEnumerable<string> GetGroups()
	{
		var resultList = new List<string>();
		var names = GetNames();

		foreach (var name in names)
		{
			var groups = GetGroupsByName(name);

			foreach (var group in groups)
			{
				if (resultList.Any(g => g == group))
				{
					continue;
				}

				resultList.Add(group);
			}
		}

		return resultList;
	}

	public IEnumerable<string> GetGroupsByName(string name)
	{
		return _binder.GetGroupsByName(name);
	}

	public IEnumerable<string> GetNamesByGroups(IEnumerable<string> groups)
	{
		var resultList = new List<string>();
		var groupsArray = groups.ToArray();
		var names = _binder.GetNames();

		foreach (var name in names)
		{
			var groupByName = _binder.GetGroupsByName(name).ToArray();

			foreach (var group in groupByName)
			{
				if (groupsArray.FirstOrDefault(g => g == group) == null)
				{
					continue;
				}

				resultList.Add(name);
				break;
			}
		}

		return resultList;
	}

	public IEnumerable<ICheatFieldModel> GetFieldsByName(string name)
	{
		return _binder.GetItemsByName(name);
	}

	#endregion
}

}