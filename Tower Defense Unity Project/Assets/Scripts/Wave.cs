using UnityEngine;
using System;
using System.Text;

[System.Serializable]
public class Wave {

	public string enemyQueu;
	public float rate;

	public string DecodeEnemyQueu(){
		string count = "";
		StringBuilder builder = new StringBuilder();
		int cnt = 0;
		foreach (char c in enemyQueu)
		{
			if(Char.IsDigit(c))
			{
				count += c;
			}
			else
			{
				Int32.TryParse(count, out cnt);
				builder.Append(c, cnt);
				count = "";
			}
		}
		return builder.ToString();
	}

}