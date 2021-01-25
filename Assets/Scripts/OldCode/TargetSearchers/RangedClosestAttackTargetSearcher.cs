using UnityEngine;

namespace Assets.Scripts.TargetSearchers
{
    public class RangedClosestAttackTargetSearcher : TargetSearcher
	{
        protected override bool ShouldInclude(GameObject gameObject)
        {
			return gameObject.transform.parent != transform.parent;
		}
	}
}