using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{

	[ActionCategory("LD46")]
	public class IsFloatAboveZero : FsmStateAction
	{
		[RequiredField]
		[UIHint(UIHint.Variable)]
		public FsmFloat floatVariable;

		[RequiredField]
		[UIHint(UIHint.Variable)] 
		[Tooltip("Store the result in a boolean variable.")]
		public FsmBool storeResult;
		
		public bool everyFrame;
		
		public override void OnEnter()
		{
			DoCheckIfFloatIsAboveZero();
			if (!everyFrame)
			{
				Finish();
			}
		}
		
		public override void OnUpdate()
		{
			DoCheckIfFloatIsAboveZero();
		}

		private void DoCheckIfFloatIsAboveZero()
		{
			storeResult.Value = false;
			
			if (floatVariable.Value > 0)
			{
				storeResult.Value = true;
			}
		}




	}

}
