using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// show firemen infomations
public class InfoBoardCtrl : MonoBehaviour {
	
	void OnGUI(){
		GameObject[] targets = GameObject.FindGameObjectsWithTag ("Player");
		if (targets != null && targets.Length > 0) {
			int i = 0;
			foreach (GameObject target in targets) {
				FiremenController targetCtrl = target.GetComponent<FiremenController> ();
				FiremenInfo targetInfo = targetCtrl.playerInfo;
				if(targetInfo != null){
					GUI.Box(new Rect(5, i*100+10, 80, 90), "");
					GUI.TextField (new Rect(10, i*100+15, 70, 20), "消防员"+targetInfo.id.ToString());
					GUI.TextField (new Rect(10, i*100+35, 70, 20), "状态:"+targetInfo.stateName());
					GUI.TextField (new Rect(10, i*100+55, 70, 20), "位置:"+(int)targetInfo.pos.x+","+(int)targetInfo.pos.y);
					if (GUI.Button (new Rect (10, i * 100 + 75, 70, 20), "现场视频"))
						showVedio ();
				}
				i++;
			}
		}
	}

	//显示火灾现场
	void showVedio(){
		Debug.Log ("打开火灾现场视频");

		GameObject.Find ("VedioCanvas").GetComponent<MoviePlayer> ().showVedio ();
	}

}
