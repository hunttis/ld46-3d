using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{

	[ActionCategory("LD46")]
	public class IsGroundColliderColliding : FsmStateAction
	{

		[Tooltip("Event to send if the ground collider is colliding")]
		public FsmEvent sendEvent;

		// Code that runs on entering the state.
		public override void OnEnter()
		{
			
		}


	}

}
