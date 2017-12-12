﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using OzoneDecals;

namespace EditMap
{
	public partial class DecalsInfo : MonoBehaviour
	{

		public static DecalsInfo Current;

		public Transform DecalPivot;
		public GameObject DecalPrefab;

		public Material AlbedoMaterial;
		public Material NormalMaterial;

		public class PropTypeGroup
		{
			public string Blueprint = "";
			public string LoadBlueprint = "";
			public string HelpText = "";

			public Texture2D Albedo;
			public Texture2D Normal;
		}


		void Awake()
		{
			Current = this;
		}

		#region Loading Assets
		public static void UnloadDecals()
		{
			Decal.AllDecalsShared = new HashSet<Decal.DecalSharedSettings>();

		}

		public static bool LoadingDecals;
		public int LoadedCount = 0;
		public IEnumerator LoadDecals()
		{
			Current = this;
			LoadingDecals = true;
			UnloadDecals();
			MargeDecals();

			List<Decal> Props = ScmapEditor.Current.map.Decals;
			const int YieldStep = 500;
			int LoadCounter = YieldStep;
			int Count = Props.Count;
			LoadedCount = 0;

			Debug.Log("Decals count: " + Count);



			for (int i = 0; i < Count; i++)
			{

				GameObject NewDecalObject = Instantiate(DecalPrefab, DecalPivot);
				OzoneDecal Dec = NewDecalObject.GetComponent<OzoneDecal>();
				Decal Component = ScmapEditor.Current.map.Decals[i];
				Dec.Shared = Component.Shared;
				Dec.tr = NewDecalObject.transform;

				Dec.tr.localRotation = Quaternion.Euler(Component.Rotation * Mathf.Rad2Deg);
				Dec.tr.localScale = new Vector3(Component.Scale.x * 0.1f, Component.Scale.x * 0.1f, Component.Scale.z * 0.1f);

				Dec.CutOffLOD = Component.CutOffLOD;
				Dec.NearCutOffLOD = Component.NearCutOffLOD;

				Dec.MovePivotPoint(ScmapEditor.ScmapPosToWorld(Component.Position));

				Dec.Material = Dec.Shared.SharedMaterial;


				if (ScmapEditor.Current.map.Decals[i].Type != TerrainDecalType.TYPE_ALBEDO
				&& ScmapEditor.Current.map.Decals[i].Type != TerrainDecalType.TYPE_NORMALS && ScmapEditor.Current.map.Decals[i].Type != TerrainDecalType.TYPE_NORMALS_ALPHA
				&& ScmapEditor.Current.map.Decals[i].Type != TerrainDecalType.TYPE_GLOW && ScmapEditor.Current.map.Decals[i].Type != TerrainDecalType.TYPE_GLOW_MASK)
				{
					Debug.LogWarning("Found different decal type! " + ScmapEditor.Current.map.Decals[i].Type, NewDecalObject);


				}

				LoadedCount++;
				LoadCounter--;
				if (LoadCounter <= 0)
				{
					LoadCounter = YieldStep;
					yield return null;
				}
			}
			DecalsControler.Sort();

			yield return null;
			LoadingDecals = false;
		}

		public static float FrustumHeightAtDistance(float distance)
		{
			return 2.0f * distance * Mathf.Tan(40 * 0.5f * Mathf.Deg2Rad);
		}

		public static void SnapDecal(OzoneDecal Dec)
		{

		}

		#endregion


		public static Texture2D AssignTextureFromPath(ref Material mat, string property, string path)
		{
			Texture2D Tex = GetGamedataFile.LoadTexture2DFromGamedata("env.scd", path);
			mat.SetTexture(property, Tex);
			return Tex;
		}

	}
}
