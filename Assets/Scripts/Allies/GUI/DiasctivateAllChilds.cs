using UnityEngine;

public class DiasctivateAllChilds : MonoBehaviour
{
	[SerializeField]
	Transform parent;

	public void DoDisactivate()
	{
		for(int i=0;i<parent.childCount;i++)
		{
			parent.GetChild(i).gameObject.SetActive(false);
		}
	}
}
