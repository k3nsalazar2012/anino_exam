using UnityEngine;
using UnityEditor;
using Anino.Implementation;

[CustomPropertyDrawer(typeof(PayoutLineData))]
public class CustomPayoutLineData : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.PrefixLabel(position, label);
        Rect newPosition = position;
        newPosition.y += 20f;

        SerializedProperty rows = property.FindPropertyRelative("_rows");

        for(int i=0; i< 3; i++)
        {
            SerializedProperty row = rows.GetArrayElementAtIndex(i).FindPropertyRelative("row");
            newPosition.height = 20;

            if(row.arraySize != 5)
                row.arraySize = 5;

            newPosition.width = 40;

            for(int j=0; j<5; j++)
            {
                EditorGUI.PropertyField(newPosition, row.GetArrayElementAtIndex(j), GUIContent.none);
                newPosition.x += newPosition.width;
            }

            newPosition.x = position.x;
            newPosition.y += 20;
        }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return 20 * 4;
    }
}
