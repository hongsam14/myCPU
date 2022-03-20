using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public static class EditorList
{
    public static void Show(SerializedProperty list, ButtonFunc buttonFunc, EditorListOption option = EditorListOption.Default)
    {
        bool
            showListLabel = (option & EditorListOption.ListLabel) != 0,
            showListSize = (option & EditorListOption.ListSize) != 0;

        EditorGUILayout.BeginVertical("Box");

        if (showListLabel)
        {
            EditorGUILayout.PropertyField(list, false);
            EditorGUI.indentLevel++;
        }
        if (!showListLabel || list.isExpanded)
        {
            if (showListSize)
                EditorGUILayout.PropertyField(list.FindPropertyRelative("Array.size"));
            ShowElement(list, buttonFunc, option);
        }
        if (showListLabel)
            EditorGUI.indentLevel--;

        EditorGUILayout.EndVertical();
    }

    private static void ShowElement(SerializedProperty list, ButtonFunc buttonFunc = null, EditorListOption option = EditorListOption.Default)
    {
        bool showElement = (option & EditorListOption.ElementLabel) != 0;

        for (int i = 0; i < list.arraySize; i++)
        {
            if (buttonFunc != null)
                EditorGUILayout.BeginHorizontal();
            if (showElement)
                EditorGUILayout.PropertyField(list.GetArrayElementAtIndex(i), true);
            else
                EditorGUILayout.PropertyField(list.GetArrayElementAtIndex(i), GUIContent.none);
            if (buttonFunc != null)
            {
                buttonFunc(list, i);
                EditorGUILayout.EndHorizontal();
            }
        }
    }

    public delegate void ButtonFunc(SerializedProperty list, int index);
}

[Flags]
public enum EditorListOption
{
    None = 0,
    ListSize = 1,
    ListLabel = 2,
    ElementLabel = 4,
    Default = ListSize | ListLabel | ElementLabel
}