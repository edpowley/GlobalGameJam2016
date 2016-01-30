using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(SandWall))]
public class SandWallEditor : Editor
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		
		SandWall myScript = (SandWall)target;
		if(GUILayout.Button("Build (will remove all children)"))
		{
			myScript.BuildObject();
		}
	}
}
