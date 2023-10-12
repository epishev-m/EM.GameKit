using UnityEngine;

namespace EM.GameKit
{

public static class RichTag
{
	public static string RelScale(float percent,
		object text)
	{
		return $"<size={percent}%>{text}</size>";
	}

	public static string FontSize(float fontSize,
		object text)
	{
		return $"<size={fontSize}>{text}</size>";
	}

	public static string VOffset(float offset,
		object text)
	{
		// ReSharper disable once StringLiteralTypo
		return $"<voffset={offset}om>{text}</voffset>";
	}

	public static string Style(string value)
	{
		return $"<style={value}>";
	}

	public static string Bold(string value)
	{
		return $"<b>{value}</b>";
	}

	public static string Colored(string htmlStringRgb,
		object text)
	{
		return $"<color={htmlStringRgb}>{text}</color>";
	}

	public static string Colored(Color color,
		string text)
	{
		return $"<color=#{ColorUtility.ToHtmlStringRGB(color)}>{text}</color>";
	}

	public static string GrayArrow()
	{
		return Colored("#b5b5cb", "<sprite name=arrow>");
	}

	public static string Number(object num)
	{
		return Colored("#48cd6f", num);
	}

	public static string BigNumber(object num)
	{
		return RelScale(120, Colored("#48cd6f", num));
	}

	public static string Sprite(string value)
	{
		return $"<sprite name=\"{value}\">";
	}

	public static string SpriteIndent(string value,
		float percent)
	{
		return $"<sprite name=\"{value}\"><indent={percent}%>";
	}

	public static string BigSprite(string value,
		int percentSize,
		float offset)
	{
		return VOffset(offset, RelScale(percentSize, Sprite(value)));
	}

	public static string BigSpriteIndent(string value,
		int percentSize,
		float offset,
		float percent)
	{
		return VOffset(offset, RelScale(percentSize, SpriteIndent(value, percent)));
	}
}

}