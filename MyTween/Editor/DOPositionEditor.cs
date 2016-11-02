//*********************************************************************
//
//					   ScriptName 	: DOMoveFormTo
//                                 
//                                 
//*********************************************************************

using UnityEngine;
using System.Collections;
using UnityEditor;
namespace Game.DoTween.Expand
{
    [CustomEditor(typeof(JTweenPosition))]
    public class DOPositionEditor : Editor
    {
        JTweenPosition obj;
        void OnEnable()
        {

            obj = (JTweenPosition)target;
        }

        public override void OnInspectorGUI()
        {

            obj.Form = EditorGUILayout.Vector3Field("Start Position：", obj.Form);
            obj.To = EditorGUILayout.Vector3Field("End Position：", obj.To);
            obj.style = (JDOTweenBase.Style)EditorGUILayout.EnumPopup("Style：", obj.style);
            obj.duration = EditorGUILayout.FloatField("Duration :", obj.duration);
            obj.delay = EditorGUILayout.FloatField("Delay :", obj.delay);
            obj.IsStartRun = EditorGUILayout.Toggle("Is Start Play：", obj.IsStartRun);

        }
    }
}
