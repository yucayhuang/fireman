using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// draw firemen path
public class LineBoardController : MonoBehaviour {
	
	private static Dictionary<string, LineRenderer> lineRendererDic;

	private static Dictionary<string, List<Vector3>> pathDic;

	private Color[] colors = { Color.red, Color.green, Color.blue, Color.yellow, Color.white, Color.gray, Color.black };

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GameObject[] targets = GameObject.FindGameObjectsWithTag ("Player");
		if (targets != null && targets.Length > 0) {
			foreach (GameObject target in targets) {
				string tId = target.GetInstanceID().ToString();
				Vector3 toPos = target.transform.position;
				if(pathDic == null)
					pathDic = new Dictionary<string, List<Vector3>> ();
				if (!pathDic.ContainsKey (tId))
					pathDic [tId] = new List<Vector3> ();
				if(lineRendererDic == null)
					lineRendererDic = new Dictionary<string, LineRenderer> ();
				if (!lineRendererDic.ContainsKey (tId)){
					GameObject lineGO = new GameObject ();
					lineGO.transform.parent = transform;
					LineRenderer lr = lineGO.AddComponent<LineRenderer> ();
					Color c = getRandomColor();
					lr.material.shader = Shader.Find ("Custom/HightLightShader");
					lr.material.color = c;//new Material (Shader.Find("Standard"));
					//lr.SetColors (c, c);
					lr.SetWidth(0.1f, 0.1f);
					lineRendererDic [tId] = lr;
					//Debug.Log ("new Draw Line " + tId);
				}

				pathDic [tId].Add (toPos);
				lineRendererDic [tId].SetVertexCount (pathDic [tId].Count);
				lineRendererDic [tId].SetPositions (pathDic [tId].ToArray());
			}
		}
	}

	// get random color
	private Color getRandomColor(){
		return new Color (Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f));
	}
}
