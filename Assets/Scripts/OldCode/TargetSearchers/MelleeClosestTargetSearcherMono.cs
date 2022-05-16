using UnityEngine;

namespace Assets.Scripts.TargetSearchers
{
    public class MelleeClosestTargetSearcherMono : TargetSearcherMono
	{
        protected override bool ShouldInclude(GameObject gameObject)
        {
            return true;
        }
    }
}