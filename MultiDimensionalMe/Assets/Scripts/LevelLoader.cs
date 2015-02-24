using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour {


	public void LoadLevel(string name){
		Application.LoadLevel(name);
	}
}
