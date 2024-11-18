using System.Collections;
using Game.Core.Utils;
using UnityEngine;
using TMPro;

namespace Game.UI
{
	[RequireComponent(typeof(TextMeshProUGUI))]
    public class TypeWriter : MonoBehaviour
    {
	    private TextMeshProUGUI text;
		private string writer;

		[SerializeField] float timeBetweenChars = 0.1f;
		
		private void Start()
		{
			text = GetComponent<TextMeshProUGUI>();
			writer = text.text;
			text.SetInvisible();
		}
	
		public IEnumerator TypeWriterCoroutine()
		{
			yield return new WaitForEndOfFrame();
			
			text.SetVisible();
			
			var fontSize = text.fontSize;
			text.enableAutoSizing = false;
			text.fontSize = fontSize;
			
			text.text = "";
			foreach (var c in writer) {
				if (text.text.Length > 0) {
					text.text = text.text.Substring(0, text.text.Length);
				}
				
				text.text += c;
				
				yield return new WaitForSeconds(timeBetweenChars);
			}
		}
    }
}