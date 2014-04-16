using UnityEngine;
using System.Collections;

public class BaseActP1 : MonoBehaviour {

	protected GameObject target;
	protected GameObject player;
	public bool computerplayer;
	public Vector3 MoveDir;
	protected int rise=0;

	
	protected float Distance(){
		return	Vector3.Distance (target.transform.position, transform.position);
	}
	
	protected void Attack(int damage){
		
		if (Distance() < 0.74f) {
			HealthBarP2 eh = (HealthBarP2)target.GetComponent ("HealthBarP2");
			eh.AdjustHealth (damage);
			//ComboBarP1 cp = (ComboBarP1)player.GetComponent ("ComboBarP1");
			//cp.AdjustPoints (1);
		}
	}
	
	protected int GetTargetAnim(){
		if (computerplayer) {
			EnemyAction ea = (EnemyAction)target.GetComponent ("EnemyAction");
			return ea.GetPlayingAnim ();	
		} else {
			ActionsP2 ea = (ActionsP2)target.GetComponent ("ActionsP2");
			return ea.GetPlayingAnim ();
		}
	}
	
	public int GetPlayingAnim(){
		if (animation ["punchR"].enabled)
			return 1;
		if (animation ["punchL1"].enabled)
			return 2;
		if (animation ["defend"].enabled)
			return 3;
		return 0;
	}
	
	private void JumpDir(){
		if(Distance(target.transform.position.x,transform.position.x)>0.3f
		   && Distance(target.transform.position.y,transform.position.y)>0.2f||
		   target.transform.position.y<0.3f){
			if (Input.GetKey ("a"))
				MoveDir.x -= 0.2f;
			
			if (Input.GetKey ("d"))
				MoveDir.x += 0.2f;
		}
	}
	protected void Jump(){
		float jumpforce = 0.3f;
		if(rise<18){
			JumpDir();

			MoveDir.y +=jumpforce;
			transform.position= MoveDir;
			rise++;

		}else {
			JumpDir();

			MoveDir.y -=jumpforce;
			transform.position= MoveDir;

			Landing();
			if(Distance(target.transform.position.x,transform.position.x)<0.8f&& transform.position.y <1.6f){
				if(Front()){
					MoveDir.x -= 0.6f;
				} else MoveDir.x += 0.6f;
				transform.position= MoveDir;


			}

		}

	}

	protected float Distance(float a, float b){
		float dist = a-b;
		if(dist<0)dist*=-1;
		return dist;
	}

	private void Landing(){
		
		if(MoveDir.y == 0){
			rise =0;
			CancelInvoke();
		}
		
		if(MoveDir.y<0){
			MoveDir.y+=0.3f;
			transform.position= MoveDir;
			rise =0;
			CancelInvoke();
		}

	}
	/*protected void JumpBackR(){
		float jumpforce = 0.3f;
		Debug.Log(MoveDir.y);
		if(MoveDir.y<(0.3f*18)&& transform.position.y >1.7f){
			MoveDir.x -= 0.5f;
			MoveDir.y +=jumpforce;
			transform.position= MoveDir;
			rise++;
		} else {
			MoveDir.y -=jumpforce;
			transform.position= MoveDir;
			Landing ();
		}
	}*/


	protected bool Front(){
		if(player.transform.position.x < target.transform.position.x)
			return true;
		return false;
	}

	protected int PlEnHealthStat(){
		HealthBarP2 eh = (HealthBarP2)target.GetComponent ("HealthBarP2");
		if (eh.GetHealth () == 0) 
			return 1;
		HealthBarP1 ph = (HealthBarP1)player.GetComponent ("HealthBarP1");
		if (ph.GetHealth () == 0)
			return 2;
		
		return 0;
	}


}
