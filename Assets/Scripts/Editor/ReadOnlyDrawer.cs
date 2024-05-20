using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// Esta clase contiene un cajón personalizado para el atributo de solo lectura

[CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
public class ReadOnlyDrawer : PropertyDrawer
{
    // Metodo de Unity para dibujar GUI en el Editor
    /// <param name="position">Position.</param>
    /// <param name="porperty">Property.</param>
    /// <param name="label">Label.</param>

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Guardando el valor habilitado de la GUI anterior
        var previousGUIState = GUI.enabled;
        // Desactivar edición de propiedad
        GUI.enabled = false;
        //  Propiedad de dibujo
        EditorGUI.PropertyField(position, property, label);
        // Estableciendo el antiguo valor de habilitación de la GUI
        GUI.enabled = previousGUIState;
    }
}
