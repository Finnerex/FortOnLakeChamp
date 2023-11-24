using UnityEngine;

namespace Utility
{


#if UNITY_EDITOR
  using UnityEditor;
#endif

  /// <summary>
  /// Serializable Nullable (SN) Does the same as C# System.Nullable, except it's an ordinary
  /// serializable struct, allowing unity to serialize it and show it in the inspector.
  /// </summary>
  [System.Serializable]
  public struct NullableSerializable<T> where T : struct
  {
    public T Value
    {
      get
      {
        if (!HasValue)
          throw new System.InvalidOperationException("Serializable nullable object must have a value.");
        return v;
      }
    }

    public bool HasValue => hasValue;

    [SerializeField] private T v;

    [SerializeField] private bool hasValue;

    public NullableSerializable(bool hasValue, T v)
    {
      this.v = v;
      this.hasValue = hasValue;
    }

    private NullableSerializable(T v)
    {
      this.v = v;
      this.hasValue = true;
    }

    public static implicit operator NullableSerializable<T>(T value)
    {
      return new NullableSerializable<T>(value);
    }

    public static implicit operator NullableSerializable<T>(System.Nullable<T> value)
    {
      return value.HasValue ? new NullableSerializable<T>(value.Value) : new NullableSerializable<T>();
    }

    public static implicit operator System.Nullable<T>(NullableSerializable<T> value)
    {
      return value.HasValue ? (T?)value.Value : null;
    }
  }

#if UNITY_EDITOR
  [CustomPropertyDrawer(typeof(NullableSerializable<>))]
  internal class SNDrawer : PropertyDrawer
  {

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
      bool hasValue = property.FindPropertyRelative("hasValue").boolValue;

      return hasValue
        ? EditorGUI.GetPropertyHeight(property.FindPropertyRelative("v"), GUIContent.none, true)
        : EditorGUIUtility.singleLineHeight;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
      EditorGUI.BeginProperty(position, label, property);

      // Draw label
      position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

      // Don't make child fields be indented
      var indent = EditorGUI.indentLevel;
      EditorGUI.indentLevel = 0;

      // Calculate rects
      var setRect = new Rect(position.x, position.y, 15, 15 /*position.height*/);
      var consumed = setRect.width + 5;
      var valueRect = new Rect(position.x + consumed, position.y, position.width - consumed,
        EditorGUIUtility.singleLineHeight);

      // Draw fields - pass GUIContent.none to each so they are drawn without labels
      var hasValueProp = property.FindPropertyRelative("hasValue");
      EditorGUI.PropertyField(setRect, hasValueProp, GUIContent.none);
      bool guiEnabled = GUI.enabled;
      GUI.enabled = guiEnabled && hasValueProp.boolValue;

      // Calculate the height for the value field dynamically
      SerializedProperty valueProp = property.FindPropertyRelative("v");
      float valueHeight = EditorGUI.GetPropertyHeight(valueProp, GUIContent.none, true);
      valueRect.height = valueHeight;
      EditorGUI.PropertyField(valueRect, valueProp, GUIContent.none, true);
      GUI.enabled = guiEnabled;

      // Set indent back to what it was
      EditorGUI.indentLevel = indent;

      EditorGUI.EndProperty();
    }
  }
#endif
}