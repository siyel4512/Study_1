using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GeneratePyramid))]
public class Generator : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GeneratePyramid gen = (GeneratePyramid)target;

        if (GUILayout.Button("피라미드 생성"))
        {
            gen.generator();
        }
    }
}
