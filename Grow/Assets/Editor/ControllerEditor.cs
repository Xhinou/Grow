using UnityEditor;

[CustomEditor(typeof(GameManager))]
public class ControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        GameManager myTarget = (GameManager)target;
        
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
