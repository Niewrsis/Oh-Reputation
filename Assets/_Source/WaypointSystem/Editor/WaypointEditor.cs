using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace WaypointSystem
{
    [CustomEditor(typeof(Waypoint))]
    public class WaypointEditor : Editor
    {
        Waypoint Waypoint => target as Waypoint;
        private void OnSceneGUI()
        {
            Handles.color = Color.cyan;
            for(int i = 0; i < Waypoint.Points.Length; i++)
            {
                EditorGUI.BeginChangeCheck();

                Vector3 currentWaypoint = Waypoint.CurrentPosition + Waypoint.Points[i];
                var fmh_20_84_638671027153560933 = Quaternion.identity; Vector3 newWaypointPoint = Handles.FreeMoveHandle(currentWaypoint, .7f, new Vector3(.3f, .3f, .3f), Handles.SphereHandleCap);

                GUIStyle textStyle = new GUIStyle();
                textStyle.fontStyle = FontStyle.Bold;
                textStyle.fontSize = 16;
                textStyle.normal.textColor = Color.white;
                Vector3 textAlligment = Vector3.down * .35f + Vector3.right * .35f;
                Handles.Label(Waypoint.CurrentPosition + Waypoint.Points[i] + textAlligment, $"{i + 1}", textStyle);
                EditorGUI.EndChangeCheck();

                if(EditorGUI.EndChangeCheck())
                {
                    Undo.RecordObject(target, "Free Move Handle");
                    Waypoint.Points[i] = newWaypointPoint - Waypoint.CurrentPosition;
                }
            }
        }
    }
}