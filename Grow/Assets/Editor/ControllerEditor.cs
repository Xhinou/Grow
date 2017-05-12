using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Controller))]
public class ControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Controller myTarget = (Controller)target;
        
        EditorGUILayout.LabelField("Day", myTarget.day.ToString());

        myTarget.population = EditorGUILayout.IntField("Population", myTarget.population);
        if (myTarget.population >= 10)
        {
            myTarget.population = 0;
            myTarget.extraLife += 1;
        }
        else if (myTarget.population < 0)
        {
            myTarget.population = 0;
        }

        myTarget.extraLife = EditorGUILayout.IntField("Extra Life", myTarget.extraLife);
        if (myTarget.extraLife < 0)
        {
            myTarget.extraLife = 0;
        }
    }
}
