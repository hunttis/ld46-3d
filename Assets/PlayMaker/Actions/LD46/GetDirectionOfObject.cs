using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{

	[ActionCategory("LD46")]
	public class GetDirectionOfObject : FsmStateAction
	{

		[RequiredField]
		[Tooltip("The GameObject to position.")]
		public FsmOwnerDefault gameObject;
		
		[RequiredField]
		[Tooltip("The target point to get the direction towards")]
		public FsmGameObject targetObject;

		[UIHint(UIHint.Variable)] 
		[Tooltip("Store the Direction")]
		public FsmVector3 storeDirection;		
		
		// Code that runs on entering the state.
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			var normalized = (go.transform.position - targetObject.Value.gameObject.transform.position).normalized;
			storeDirection.Value = normalized;
			Finish();
		}


	}

}
