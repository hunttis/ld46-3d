using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{

	[ActionCategory("LD46")]
	public class CheckMultipleIntsAtOrBelowZero : FsmStateAction
	{
		
		[RequiredField]
		[MatchElementType("array")]
		[UIHint(UIHint.Variable)]
		[Tooltip("The variables to check.")]
		public FsmInt[] variables;

		[Tooltip("Repeat every frame while the state is active.")]
		public bool everyFrame;

		[RequiredField]
		[Tooltip("Where to store if each of them was zero or below")]
		[UIHint(UIHint.Variable)]
		public FsmBool storeValue;
		
		public override void Reset()
		{
			storeValue = null;
			everyFrame = false;
		}
		
		public override void OnEnter()
		{
			DoCheckVariablesAtZeroOrBelow();

			if (!everyFrame)
			{
				Finish();
			}
		}

		public override void OnUpdate()
		{
			DoCheckVariablesAtZeroOrBelow();
		}

		private void DoCheckVariablesAtZeroOrBelow()
		{
			bool returnValue = true;
			foreach (var fsmVar in variables)
			{
				Debug.Log("Checking: " + fsmVar.Name + " has value " + fsmVar.Value);

				if (fsmVar.Value > 0)
				{
					returnValue = false;
				}
			}

			storeValue.Value = returnValue;
		}
	}

}
