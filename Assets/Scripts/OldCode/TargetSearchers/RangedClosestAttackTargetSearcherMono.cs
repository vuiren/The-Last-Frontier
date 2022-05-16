using UnityEngine;

namespace Assets.Scripts.TargetSearchers
{
    public class RangedClosestAttackTargetSearcherMono : TargetSearcherMono
	{
        protected override bool ShouldInclude(GameObject gameObject)
        {
			return gameObject.transform.parent != transform.parent;
		}
	}
}