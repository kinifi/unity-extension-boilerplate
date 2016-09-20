using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Assertions;

public class EditorWindowExtension : EditorWindow
{

	private ExtensionDataClass mLevel = null;
	private bool mIsInitalized = false;
	private string m_NotificationText = "Select A Language Asset";

	[MenuItem("Window/New Editor %l")]
	public static void ShowEditor()
	{

		//create the editor window
		EditorWindowExtension editor = EditorWindow.GetWindow<EditorWindowExtension>();
		//the editor window must have a min size
		editor.titleContent = new GUIContent("New Editor");
		editor.minSize = new Vector2 (600, 400);
		//call the init method after we create our window
		editor.Init();

	}


	private void Init()
	{
		//check if we are initialized or not
		if(mIsInitalized == true)
		{
			return;
		}

		//detect what type of object we have selected
		DetectSelectedFile();
	}

	//draws the UI
	private void OnGUI()
	{

		if(mIsInitalized == false)
		{
			GUILayout.Label("New Editor");
			this.ShowNotification(new GUIContent(m_NotificationText));
			return;
		}


	}


	//UNITY EVENTS START
	//All will reset the editor window

	public void PlaymodeChanged()
	{
		DetectSelectedFile();
		Repaint();
	}

	public void OnLostFocus ()
	{
		DetectSelectedFile();
		Repaint();
	}

	public void OnFocus()
	{
		DetectSelectedFile();
		Repaint();
	}

	public void OnProjectChange ()
	{
		DetectSelectedFile();
		Repaint();
	}

	public void OnSelectionChange ()
	{
		DetectSelectedFile();
		Repaint();
	}
	//UNITY EVENTS END


	//checks what object we have selected and gets the data if its the correct type
	private void DetectSelectedFile()
	{
		ExtensionDataClass selectedAsset = null;

		//check if we aren't selecting a game object
		if (Selection.activeObject == null)
		{
			//the selected object is null
			mLevel = null;
			mIsInitalized = false;
			selectedAsset = null;
		}

		//check if the object we have selected is a language file
		if (Selection.activeObject is ExtensionDataClass && EditorUtility.IsPersistent(Selection.activeObject))
		{
			//set the language file we have selected to be manipulated
			selectedAsset = Selection.activeObject as ExtensionDataClass;
			mLevel = selectedAsset;
			mIsInitalized = true;
	        this.RemoveNotification();
		}
		else
		{
			//the selected object is null
			mIsInitalized = false;
			selectedAsset = null;
			mLevel = null;
		}

	}


}