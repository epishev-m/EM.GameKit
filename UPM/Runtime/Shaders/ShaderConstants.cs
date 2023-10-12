namespace EM.GameKit
{

using UnityEngine;

public static class ShaderConstants
{
	public static class Names
	{
		public static readonly string CoverColor = "EM/UI/CoverColor";
	}

	public static class Properties
	{
		public static readonly int GrayAmount = Shader.PropertyToID("_GrayAmount");

		public static readonly int CoverColor = Shader.PropertyToID("_CoverColor");

		public static readonly int CoverAmount = Shader.PropertyToID("_CoverAmount");
	}
}

}