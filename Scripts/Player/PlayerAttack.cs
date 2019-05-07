using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAttack : StateMachineBehaviour {

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	//override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
	GameObject player;
	Animator ani;
	void OnStateEnter()
	{ ////ISSUE HERE'''''''''''''''''''''''''''''''''''''''''''
		player = GameObject.Find("Player");
		ani =player.GetComponent<Animator>();
		if(ani.GetCurrentAnimatorStateInfo(0).IsName("Player_Jab"))
		{
			player.GetComponent<playerMove>().Attack(5);
		}
		else if(ani.GetCurrentAnimatorStateInfo(0).IsName("Player_2Punch"))
		{
			player.GetComponent<playerMove>().Attack(5);
		}
		else if(ani.GetCurrentAnimatorStateInfo(0).IsName("Player_PunchCombo"))
		{
			player.GetComponent<playerMove>().Attack(5);
		}
		else if(ani.GetCurrentAnimatorStateInfo(0).IsName("Player_KickCombo"))
		{
			player.GetComponent<playerMove>().Attack(5);
		}
		else if(ani.GetCurrentAnimatorStateInfo(0).IsName("Player_2Kick"))
		{
			player.GetComponent<playerMove>().Attack(5);
		}
		else if(ani.GetCurrentAnimatorStateInfo(0).IsName("Player_2Kick 0"))
		{
			player.GetComponent<playerMove>().Attack(5);
		}
		else if(ani.GetCurrentAnimatorStateInfo(0).IsName("Player_2Punch 1"))
		{
			player.GetComponent<playerMove>().Attack(5);
		}
		else if(ani.GetCurrentAnimatorStateInfo(0).IsName("Player_Kick"))
		{
			player.GetComponent<playerMove>().Attack(5);
		}


	}
	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	//override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	//override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
