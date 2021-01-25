using UnityEngine;

namespace Assets.Scripts.TargetSearchers
{
    public class HealableTargetSearcher : TargetSearcher
	{ 
        protected override bool ShouldInclude(GameObject gameObject)
        {
			var healable = gameObject.transform.GetComponentInChildren<IHealthController>();
			if (healable == null) return false;
			return gameObject != transform.parent && healable.HealingRequired();
		}
    }
}