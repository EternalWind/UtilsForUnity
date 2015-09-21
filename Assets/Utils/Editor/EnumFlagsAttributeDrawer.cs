using UnityEngine;
using UnityEditor;
using System;

[CustomPropertyDrawer(typeof(EnumFlagsAttribute))]
public class EnumFlagsDrawer : PropertyDrawer
{
    //private Enum currentValue;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EnumFlagsAttribute flagSettings = attribute as EnumFlagsAttribute;
        string propName = flagSettings.enumName;
        if (string.IsNullOrEmpty(propName))
            propName = property.name;

        EditorGUI.BeginProperty(position, label, property);

        Enum currentValue = Convert.ChangeType(fieldInfo.GetValue(property.serializedObject.targetObject), fieldInfo.FieldType) as Enum;
        currentValue = EditorGUI.EnumMaskField(position, propName, currentValue);
        property.intValue = (int)Convert.ChangeType(currentValue, fieldInfo.FieldType);

        EditorGUI.EndProperty();
    }
}
