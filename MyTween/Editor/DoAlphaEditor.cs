//*********************************************************************
//
//					   ScriptName 	: DoAlpha
//                                 
//                                 
//*********************************************************************

using UnityEngine;
using System.Collections;
using UnityEditor;
namespace Game.DoTween.Expand
{
    [CustomEditor(typeof(JTweenAlpha))]
    public class DoAlphaEditor : Editor
    {
        JTweenAlpha obj;
        void OnEnable()
        {
            obj = (JTweenAlpha)target;
        }
        public override void OnInspectorGUI()
        {
            EditorGUILayout.LabelField("Start Alpha :");
            obj.StartAlpha = EditorGUILayout.Slider(obj.StartAlpha, 0, 1);
            EditorGUILayout.LabelField("End   Alpha :");
            obj.EndAlpha = EditorGUILayout.Slider(obj.EndAlpha, 0, 1);
            obj.style = (JDOTweenBase.Style)EditorGUILayout.EnumPopup("Style :", obj.style);
            obj.durtion = EditorGUILayout.FloatField("Duration :", obj.durtion);
            obj.delay = EditorGUILayout.FloatField("Delay :", obj.delay);
            obj.IsStartRun = EditorGUILayout.Toggle("Is Start Run :", obj.IsStartRun);
        }


    }
}
