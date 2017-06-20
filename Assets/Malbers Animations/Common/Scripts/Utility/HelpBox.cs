using UnityEngine;
using System;
#if UNITY_EDITOR
using UnityEditor;


namespace MalbersAnimations
{
    public class HelpBox : PropertyAttribute
    {
        public string message;

        public HelpBox(string m)
        { message = m; }
    }

    [CustomPropertyDrawer(typeof(HelpBox))]
    public class HelpBoxDrawer : DecoratorDrawer
    {
        public override void OnGUI(Rect position)
        {
            position.y += 8f;
            position = EditorGUI.IndentedRect(position);
            position.height -= 12f;
            EditorGUI.HelpBox(position, (attribute as HelpBox).message, MessageType.None); 
        }

        public override float GetHeight()
        {
            return base.GetHeight() + 25f;
        }
    }
}
#endif