namespace Assets.Scripts.Attack
{
    public class MelleAttackController : AttackController
	{
		DamageTarget damageTarget;

        protected override void AddComponents()
        {
            base.AddComponents();
			damageTarget = gameObject.AddComponent<DamageTarget>();
		}

        protected override void SubscribeToEvents()
        {
            base.SubscribeToEvents();
			onAttack += () =>
			{
				damageTarget.DoDamageTarget(NPCInfoHolder.AttackTarget, NPCInfoHolder.NPCInfo.DamageCount);
			};
		}
	}
}