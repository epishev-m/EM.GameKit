namespace EM.GameKit
{

using System.Linq;
using System.Collections.Generic;
using DG.DemiEditor;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(LayoutElement), typeof(VerticalLayoutGroup))]
public sealed class VerticalElementMinSize : MonoBehaviour
{
	[SerializeField]
	private LayoutElement _layoutElement;

	[SerializeField]
	private VerticalLayoutGroup _verticalLayoutGroup;

	#region VerticalElementMinSize

	public void CalculateAndSetMinHeight()
	{
		var layoutElements = GetLayoutElements().ToList();
		CalculateAndSetMinHeightForChildren(layoutElements);
		var heightAllElements = layoutElements.Sum(layoutElement => layoutElement.minHeight);

		_layoutElement.minHeight = heightAllElements +
								   (layoutElements.Count - 1) * _verticalLayoutGroup.spacing +
								   _verticalLayoutGroup.padding.top +
								   _verticalLayoutGroup.padding.bottom;

		var rectTransform = _layoutElement.GetComponent<RectTransform>();
		rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, _layoutElement.minHeight);
	}

	private void CalculateAndSetMinHeightForChildren(IEnumerable<LayoutElement> layoutElements)
	{
		foreach (var layoutElement in layoutElements)
		{
			var verticalElementMinSize = layoutElement.GetComponent<VerticalElementMinSize>();

			if (verticalElementMinSize == null)
			{
				continue;
			}
			
			verticalElementMinSize.CalculateAndSetMinHeight();
		}
	}

	private IEnumerable<LayoutElement> GetLayoutElements()
	{
		var layoutElements = new List<LayoutElement>(8);
		var verticalLayoutGroupTransform = _verticalLayoutGroup.transform;

		for (var i = 0; i < verticalLayoutGroupTransform.childCount; ++i)
		{
			var child = verticalLayoutGroupTransform.GetChild(i);

			if (!child.gameObject.activeSelf)
			{
				continue;
			}
			
			var layoutElement = child.GetComponent<LayoutElement>();

			if (layoutElement == null || layoutElement.ignoreLayout)
			{
				continue;
			}

			layoutElements.Add(layoutElement);
		}

		return layoutElements;
	}

	#endregion
}

}