using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{

	[ActionCategory("LD46")]
	public class ShootTowardsObject : ComponentAction<Rigidbody>
	{
		[Tooltip("The thing being shot.")]
		public FsmOwnerDefault gameObject;

		[Tooltip("The thing being shot at.")]
		public FsmGameObject targetObject;

		[Tooltip("Velocity")]
		public FsmFloat velocity;

		// Code that runs on entering the state.
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			go.transform.LookAt(targetObject.Value.transform.position);
			rigidbody.velocity = Vector3.back * velocity.Value;
			Finish();
		}


	}

}
