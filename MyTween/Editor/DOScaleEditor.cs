//*********************************************************************
//
//					   ScriptName 	: DOScale
//                                 
//                                 
//*********************************************************************

using UnityEngine;
using System.Collections;
using UnityEditor;
namespace Game.DoTween.Expand
{
    [CustomEditor(typeof(JTweenScale))]
    public class DOScaleEditor : Editor
    {
        JTweenScale obj;
        void OnEnable()
        {
            obj = (JTweenScale)target;
        }

        public override void OnInspectorGUI()
        {
            obj.formScale = EditorGUILayout.Vector3Field("Start Scale", obj.formScale);
            obj.toScale = EditorGUILayout.Vector3Field("End Scale", obj.toScale);
            obj.style = (JDOTweenBase.Style)EditorGUILayout.EnumPopup("Style :", obj.style);
            obj.duration = EditorGUILayout.FloatField("Duration :", obj.duration);
            obj.delay = EditorGUILayout.FloatField("Delay :", obj.delay);
            obj.IsStartRun = EditorGUILayout.Toggle("Is Start Run :", obj.IsStartRun);
        }
    }
}
