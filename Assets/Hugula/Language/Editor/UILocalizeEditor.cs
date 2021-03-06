//----------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright © 2011-2014 Tasharen Entertainment
//----------------------------------------------
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


namespace Hugula.Editor {

    [CanEditMultipleObjects]
    [CustomEditor (typeof (Hugula.UGUILocalize), true)]
    public class UILocalizeEditor : UnityEditor.Editor {
        List<string> mKeys;
        Dictionary<string, string> dicts = new Dictionary<string, string> ();
        string value;
        void OnEnable () {
            // dicts
            Dictionary<string, string> dict = Localization.dictionary;

            //if (dict.Count > 0)
            //{
            //mKeys = new BetterList<string>();

            //foreach (KeyValuePair<string, string[]> pair in dict)
            //{
            //    if (pair.Key == "KEY") continue;
            //    mKeys.Add(pair.Key);
            //}
            //mKeys.Sort(delegate(string left, string right) { return left.CompareTo(right); });
            //}
        }

        public override void OnInspectorGUI () {
            serializedObject.Update ();

            GUILayout.Space (6f);
            UGUIEditorTools.SetLabelWidth (80f);

            GUILayout.BeginHorizontal ();
            // Key not found in the localization file -- draw it as a text field
            SerializedProperty sp = UGUIEditorTools.DrawProperty ("Key", serializedObject, "key");

            string myKey = sp.stringValue;
            //Debug.Log(myKey);
            bool isPresent = !string.IsNullOrEmpty (myKey) && Localization.localizationHasBeenSet;
            GUI.color = isPresent ? Color.green : Color.red;
            GUILayout.BeginVertical (GUILayout.Width (22f));
            GUILayout.Space (2f);

            GUILayout.Label (isPresent ? "\u2714" : "\u2718", "TL SelectionButtonNew", GUILayout.Height (20f));
            GUILayout.EndVertical ();
            GUI.color = Color.white;
            GUILayout.EndHorizontal ();

            if (isPresent) {
                if (UGUIEditorTools.DrawHeader ("Preview")) {
                    UGUIEditorTools.BeginContents ();

                    string[] keys;
                    string[] values;
                    string value;

                    if (Localization.dictionary.TryGetValue (myKey, out value)) {
                        keys = new string[] { myKey };
                        values = new string[] { value };
                        for (int i = 0; i < keys.Length; ++i) {
                            GUILayout.BeginHorizontal ();
                            GUILayout.Label (keys[i], GUILayout.Width (70f));

                            if (GUILayout.Button (values[i], "AS TextArea", GUILayout.MinWidth (80f), GUILayout.MaxWidth (Screen.width - 110f))) {
                                (target as UGUILocalize).value = values[i];
                                GUIUtility.hotControl = 0;
                                GUIUtility.keyboardControl = 0;
                            }
                            GUILayout.EndHorizontal ();
                        }
                    } else {
                        GUILayout.Label ("No preview available");
                    }

                    UGUIEditorTools.EndContents ();
                }
            } else if (mKeys != null && !string.IsNullOrEmpty (myKey)) {
                GUILayout.BeginHorizontal ();
                GUILayout.Space (80f);
                GUILayout.BeginVertical ();
                GUI.backgroundColor = new Color (1f, 1f, 1f, 0.35f);

                int matches = 0;

                for (int i = 0; i < mKeys.Count; ++i) {
                    if (mKeys[i].StartsWith (myKey, System.StringComparison.OrdinalIgnoreCase) || mKeys[i].Contains (myKey)) {

                        if (GUILayout.Button (mKeys[i] + " \u25B2", "CN CountBadge"))
                        {
                            sp.stringValue = mKeys[i];
                            GUIUtility.hotControl = 0;
                            GUIUtility.keyboardControl = 0;
                        }

                        if (++matches == 8) {
                            GUILayout.Label ("...and more");
                            break;
                        }
                    }
                }
                GUI.backgroundColor = Color.white;
                GUILayout.EndVertical ();
                GUILayout.Space (22f);
                GUILayout.EndHorizontal ();
            }

            serializedObject.ApplyModifiedProperties ();
        }
    }
}