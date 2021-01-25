/*using Sirenix.OdinInspector.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameDataGlobus : OdinMenuEditorWindow
{
    [MenuItem("Tools/GameDataGlobus")]
    private static void OpenWindow()
    {
        GetWindow<GameDataGlobus>().Show();
    }

	protected override OdinMenuTree BuildMenuTree()
	{
        var tree = new OdinMenuTree();

        tree.AddAllAssetsAtPath("NPCInfo", "Assets/NPCSInfo", typeof(NPCInfo), true);
        tree.AddAllAssetsAtPath("CreatingInfo", "Assets/NPCSInfo", typeof(CreatingInfo), true);

        tree.EnumerateTree().AddIcons<NPCInfo>(x => x.NPCImage);
        tree.EnumerateTree().AddIcons<CreatingInfo>(x=>x.CreationImage);
        return tree;
	}
}*/
