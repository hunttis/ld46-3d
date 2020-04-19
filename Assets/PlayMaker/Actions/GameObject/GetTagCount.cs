// (c) Copyright HutongGames, LLC 2010-2013. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.GameObject)]
	[Tooltip("Gets the number of Game Objects in the scene with the specified Tag.")]
	public class GetTagCount : FsmStateAction
	{
		[UIHint(UIHint.Tag)]
		public FsmString tag;
		[RequiredField]
		[UIHint(UIHint.Variable)]
		public FsmInt storeResult;

		[Tooltip("Repeat every frame while the state is active.")]
		public bool everyFrame;
		
		public override void Reset()
		{
			tag = "Untagged";
			storeResult = null;
		}

		public override void OnEnter()
		{
			GameObject[] gos = GameObject.FindGameObjectsWithTag(tag.Value);
			
			if (storeResult != null)
				storeResult.Value = gos != null ? gos.Length : 0;

			if (!everyFrame)
			{
				Finish();
			}
		}

		public override void OnUpdate()
		{
			if (!everyFrame)
			{
				Finish();
			}
			
			GameObject[] gos = GameObject.FindGameObjectsWithTag(tag.Value);
			
			if (storeResult != null)
				storeResult.Value = gos != null ? gos.Length : 0;
			
		}
	}
}