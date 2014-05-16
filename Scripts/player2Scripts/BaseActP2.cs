using UnityEngine;
using System.Collections;

public class BaseActP2 : MonoBehaviour {
	
	protected GameObject target;
	protected GameObject player;
	public Vector3 MoveDir;
	private int rise = 0; 

	private ComboBarP2 ComboBar(){
		return (ComboBarP2)player.GetComponent ("ComboBarP2");
	}
	
	protected void AddToCombo(int act){
		if(Distance()< 0.74f)
			ComboBar().ComboPointsAdj(act);
		Debug.Log (act);
	}
	
	protected bool FullComboBar(){
		return ComboBar().Full();
	}

	protected void ClearCombo(){
		ComboBar().AdjustPoints(-2);
	}
	
	public float Distance(){
		return	Vector3.Distance (target.transform.position, player.transform.position);
	}
	
	protected void Attack(int damage){
		Debug.Log (Distance());
		
		if (Distance() < 0.74f) {
			HealthBarP1 eh = (HealthBarP1)target.GetComponent ("HealthBarP1");
			eh.AdjustHealth (damage);

		}
	}
	private void JumpDir(){
		if(Distance(target.transform.position.x,transform.position.x)<0.3f
		   && Distance(target.transform.position.y,transform.position.y)<0.3f||
		   target.transform.position.y<0.3f){
		
			if (Input.GetKey ("left"))
				MoveDir.x -= 0.2f;
			
			if (Input.GetKey ("right"))
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
			if(Distance(target.transform.position.x,transform.position.x)<0.8f&& transform.position.y <1.7f){
				if(Front()){
					MoveDir.x -= 0.9f;
				} else MoveDir.x += 0.9f;
				transform.position= MoveDir;
				
				
			}
			
		}
		
	}

	protected bool Front(){
		if(player.transform.position.x < target.transform.position.x)
			return false;
		return true;
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
	
	protected int GetTargetAnim(){
		ActionsP1 ea = (ActionsP1)target.GetComponent ("ActionsP1");
		return ea.GetPlayingAnim ();
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
	
	protected int PlEnHealthStat(){
		HealthBarP1 eh = (HealthBarP1)target.GetComponent ("HealthBarP1");
		if (eh.GetHealth () == 0) 
			return 1;
		HealthBarP2 ph = (HealthBarP2)player.GetComponent ("HealthBarP2");
		if (ph.GetHealth () == 0)
			return 2;
		
		return 0;
	}

}
