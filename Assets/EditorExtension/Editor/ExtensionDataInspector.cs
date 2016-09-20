/*
* 1. Must be located in a "Editor" Folder in your Assets folder
* 2. Must have a script that is in the "typeof(SCRIPT HERE)" line that exists
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//change the name to your class name here
[CustomEditor(typeof(ExtensionDataClass))]
//uncomment if needed
//[CanEditMultipleObjects]
public class NewInspector : Editor
{

    public override void OnInspectorGUI()
    {

      GUILayout.Label("I'm an awesome label", EditorStyles.helpBox);
    }
}