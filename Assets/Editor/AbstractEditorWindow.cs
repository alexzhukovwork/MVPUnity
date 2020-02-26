using System;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;


namespace WebClientSDK.Scripts.Editor {

public abstract class AbstractEditorWindow<T> : EditorWindow where T: AbstractEditorWindow<T> {
	
	protected virtual void CreateButtonForMethod(Action method, [CanBeNull] string btnName = null) {
		if (ReferenceEquals(btnName, null)) btnName = $"{method.Method.Name}";
		if (GUILayout.Button(btnName)) method();
	}

	protected abstract void OnGUI();
	
	
}

}
