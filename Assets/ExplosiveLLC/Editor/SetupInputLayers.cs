﻿using UnityEditor;
using UnityEngine;

namespace RPGCharacterAnims
{
	class SetupInputLayers:AssetPostprocessor
	{
		static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
		{
			SetupMessageWindow window = ( SetupMessageWindow )EditorWindow.GetWindow(typeof(SetupMessageWindow), true, "Load Input and Tag Presets");
			window.maxSize = new Vector2(290f, 190f);
			window.minSize = window.maxSize;
		}
	}

	public class SetupMessageWindow:EditorWindow
	{
		void OnGUI()
		{
			EditorGUILayout.LabelField("Before attempting to use the RPG Character Animation Mecaim Animation Pack, you must first ensure that the layers and inputs are correctly defined.  There is an included Input.preset and Layer.preset which contains all the settings that you can load in.\n \nThe README and other documents are located in the Documentation folder.\n \nYou can remove this message by deleting the SetupInputLayers.cs script in the Editor folder.", EditorStyles.wordWrappedLabel);
		}
	}
}