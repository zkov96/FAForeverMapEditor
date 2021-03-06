﻿using UnityEngine;
using System.Collections;
using UndoHistory;
using EditMap;

public class HistoryMapInfo : HistoryObject {

	public		string			Name;
	public		string			Desc;
	public		float			Version;
	public		int				Script;

	public override void Register(){
		Name = MapLuaParser.Current.ScenarioLuaFile.Data.name;
		Desc = MapLuaParser.Current.ScenarioLuaFile.Data.description;
		Version = MapLuaParser.Current.ScenarioLuaFile.Data.map_version;
		Script = MapLuaParser.Current.ScriptId;
	}


	public override void DoUndo(){
		if (!RedoGenerated)
			HistoryMapInfo.GenerateRedo (Undo.Current.Prefabs.MapInfo).Register();
		RedoGenerated = true;
		DoRedo ();
	}

	public override void DoRedo(){
		if(Undo.Current.EditMenu.State != Editing.EditStates.MapStat) Undo.Current.EditMenu.ButtonFunction("Map");
		MapLuaParser.Current.ScenarioLuaFile.Data.name = Name;
		MapLuaParser.Current.ScenarioLuaFile.Data.description = Desc;
		MapLuaParser.Current.ScenarioLuaFile.Data.map_version = Version;
		MapLuaParser.Current.ScriptId = Script;
		Undo.Current.MapInfoMenu.UpdateScriptToggles(Script);
		Undo.Current.MapInfoMenu.UpdateFields();
	}
}
