using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class NPCInfoInspector : OdinMenuEditorWindow
{
    [MenuItem("My Game/My NPCInfoInspector")]
    private static void OpenWindow()
    {
        GetWindow<NPCInfoInspector>().Show();
    }

    protected override OdinMenuTree BuildMenuTree()
    {
        var tree = new OdinMenuTree();

        tree.AddAllAssetsAtPath("NPCInfoHolders", "Assets/NPCSInfo", typeof(NPCInfo), true);

        return tree;
    }
}
