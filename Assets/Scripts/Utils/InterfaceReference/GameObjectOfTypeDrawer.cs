using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Object = System.Object;

namespace Utils.InterfaceReference
{
    [CustomPropertyDrawer(typeof(GameObjectOfTypeAttribute))]
    public class GameObjectOfTypeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            bool isFieldGameObject = IsFieldGameObject();

            if (isFieldGameObject == false)
                return;

            GameObjectOfTypeAttribute typeAttribute = attribute as GameObjectOfTypeAttribute;
            Type requiredType = typeAttribute.Type;

            CheckDragAndDrop(position, requiredType);

            DrawObjectField(property, position, label, typeAttribute.AllowSceneObjects);
        }

        private void CheckDragAndDrop(Rect position, Type requiredType)
        {
            if (position.Contains(Event.current.mousePosition) == false)
                return;

            int dragObjectsCount = DragAndDrop.objectReferences.Length;

            for (int i = 0; i < dragObjectsCount; i++)
            {
                if (IsValidObject(DragAndDrop.objectReferences[i], requiredType) == false)
                {
                    DragAndDrop.visualMode = DragAndDropVisualMode.Rejected;
                    break;
                }
            }
        }

        private bool IsValidObject(Object obj, Type requiredType)
        {
            bool valid = false;

            GameObject go = obj as GameObject;

            if (go != null && go.GetComponent(requiredType) != null)
                valid = true;

            return valid;
        }

        private bool IsFieldGameObject()
        {
            return fieldInfo.FieldType == typeof(GameObject) ||
                typeof(IEnumerable<GameObject>).IsAssignableFrom(fieldInfo.FieldType);
        }

        private void DrawObjectField(SerializedProperty property, Rect position, GUIContent label, bool allowSceneObjects)
        {
            property.objectReferenceValue = EditorGUI.ObjectField(position,
                label,
                property.objectReferenceValue,
                typeof(GameObject),
                allowSceneObjects);
        }
    }
}
