﻿//using System.Linq;
//using System.Reflection;
//using UnityEditor;
//using UnityEngine;

//[CustomEditor(typeof(PlayerMovement))]
//public class KeyMappingEditor: Editor
//{
//    public override void OnInspectorGUI()
//    {
//        PlayerMovement manager = (PlayerMovement)target;

//        MonoBehaviour[] scripts = manager.GetComponents<MonoBehaviour>();
//        string[] scriptNames = scripts.Select(s => s.GetType().Name).ToArray();

//        int newIndex = EditorGUILayout.Popup("Script", scripts.ToList().IndexOf(manager.selectedScript), scriptNames);
//        if (newIndex >= 0)
//            manager.selectedScript = scripts[newIndex];

//        if (manager.selectedScript != null)
//        {
//            MethodInfo[] methods = manager.selectedScript.GetType().GetMethods().Where(m => m.DeclaringType == manager.selectedScript.GetType()).ToArray();
//            string[] methodNames = methods.Select(m => m.Name).ToArray();

//            int methodIndex = EditorGUILayout.Popup("Method", methodNames.ToList().IndexOf(manager.selectedMethod), methodNames);
//            if (methodIndex >= 0)
//                manager.selectedMethod = methodNames[methodIndex];
//        }
//    }
//}
////?????