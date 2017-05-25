using System;
using System.Collections.Generic;
using RMGUI.GraphView;
using UnityEditor.Graphing.Drawing;
using UnityEngine;
using UnityEngine.MaterialGraph;

namespace UnityEditor.MaterialGraph.Drawing
{
    class Matrix4ControlPresenter : GraphControlPresenter
    {
        public override void OnGUIHandler()
        {
            base.OnGUIHandler();

            var tNode = node as UnityEngine.MaterialGraph.Matrix4Node;
            if (tNode == null)
                return;

            tNode[0] = EditorGUILayout.Vector4Field("", tNode[0]);
            tNode[1] = EditorGUILayout.Vector4Field("", tNode[1]);
            tNode[2] = EditorGUILayout.Vector4Field("", tNode[2]);
            tNode[3] = EditorGUILayout.Vector4Field("", tNode[3]);
        }

        public override float GetHeight()
        {
            return (EditorGUIUtility.singleLineHeight * 4 + EditorGUIUtility.standardVerticalSpacing) + EditorGUIUtility.standardVerticalSpacing;
        }
    }

    [Serializable]
    public class Matrix4NodePresenter : PropertyNodePresenter
    {
        protected override IEnumerable<GraphElementPresenter> GetControlData()
        {
            var instance = CreateInstance<Matrix4ControlPresenter>();
            instance.Initialize(node);
            return new List<GraphElementPresenter>(base.GetControlData()) { instance };
        }
    }
}
