using UnityEngine;

namespace Assets.Scripts.TargetSearchers
{
    public class MelleeClosestTargetSearcher : TargetSearcher
	{
        protected override bool ShouldInclude(GameObject gameObject)
        {
            return true;
        }
    }
}