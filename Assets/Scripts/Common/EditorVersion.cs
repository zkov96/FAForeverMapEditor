﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class EditorVersion : MonoBehaviour
{

	public const string EditorBuildVersion = "v0.515-Alpha";
	public static string LatestTag = "";
	public static string FoundUrl;

	void Start()
	{
		GetComponent<Text>().text = EditorBuildVersion;
		StartCoroutine(FindLatest());
	}

	public string url = "https://github.com/ozonexo3/FAForeverMapEditor/releases/latest";
	IEnumerator FindLatest()
	{
		using (WWW www = new WWW(url))
		{
			yield return www;
			/*
			if (www.responseHeaders.Count > 0)
			{
				
					foreach (KeyValuePair<string, string> entry in www.responseHeaders)
					{
						Debug.Log(entry.Key + " = " + entry.Value);
					}
				
			}
			*/
			string[] Tags = www.url.Replace("\\", "/").Split("/".ToCharArray());

			if (Tags.Length > 0)
			{
				LatestTag = Tags[Tags.Length - 1];
				FoundUrl = www.url;

				float Latest = BuildFloat(LatestTag);
				float Current = BuildFloat(EditorBuildVersion);
				if (Current < Latest || true)
					GenericPopup.ShowPopup(GenericPopup.PopupTypes.TwoButton, "New version",
						"New version of Map Editor is avaiable.\nCurrent: " + EditorBuildVersion.ToLower() + "\t\tNew: " + LatestTag + "\nDo you want to download it now?",
						"Download", DownloadLatest,
						"Cancel", CancelDownload
						);
				else
					Debug.Log("Latest version " + Latest);

			}
		}
	}

	static string CleanBuildVersion(string tag)
	{
		return tag.ToLower().Replace(" ", "").Replace("-alpha", "").Replace("-beta", "");
	}

	static float BuildFloat(string tag)
	{
		float Found = 0.5f;
		string ToParse = CleanBuildVersion(tag).Replace("v", "");

		if (float.TryParse(ToParse, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture.NumberFormat, out Found))
		{
			return Found;
		}
		else
		{
			Debug.LogError("Wrong tag! Cant parse build version to float! Tag: " + ToParse);
			return 0;
		}
	}

	public void DownloadLatest()
	{
		Application.OpenURL(FoundUrl);
	}

	public void CancelDownload()
	{

	}
}
