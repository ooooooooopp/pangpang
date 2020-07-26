using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(menuName = "Scriptable/SpriteLib")]
public class SpriteLibScriptable : SerializedScriptableObject
{
	[System.Serializable]
	public struct SpriteSet
	{
		public Sprite[] sprites;
	}
	public Dictionary<CharKind, Dictionary<PlayerState, SpriteSet>> sprites;

	public SpriteSet GetSpriteSet(CharKind kind, PlayerState state )
	{
		return sprites[kind][state];
	}
}