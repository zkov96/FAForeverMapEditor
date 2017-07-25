version = 3
ScenarioInfo = {
    name = "Seton's Clutch",
    description = "<LOC SCMP_009_Description>Dozens of battles have been fought over the years across Seton's Clutch. A patient searcher could find the remains of thousands of units resting beneath the earth and under the waves.",
    type = 'skirmish',
    starts = true,
    preview = '',
    size = {1024, 1024},
    map = '/maps/SCMP_009/SCMP_009.scmap',
    save = '/maps/SCMP_009/SCMP_009_save.lua',
    script = '/maps/SCMP_009/SCMP_009_script.lua',
    norushradius = 70.000000,
    norushoffsetX_ARMY_1 = 15.000000,
    norushoffsetY_ARMY_1 = 40.000000,
    norushoffsetX_ARMY_2 = -10.000000,
    norushoffsetY_ARMY_2 = -40.000000,
    norushoffsetX_ARMY_3 = 10.000000,
    norushoffsetY_ARMY_3 = 30.000000,
    norushoffsetX_ARMY_4 = -12.000000,
    norushoffsetY_ARMY_4 = -38.000000,
    norushoffsetX_ARMY_5 = -40.000000,
    norushoffsetY_ARMY_5 = -15.000000,
    norushoffsetX_ARMY_6 = 40.000000,
    norushoffsetY_ARMY_6 = 10.000000,
    norushoffsetX_ARMY_7 = -10.000000,
    norushoffsetY_ARMY_7 = -10.000000,
    norushoffsetX_ARMY_8 = 20.000000,
    norushoffsetY_ARMY_8 = 15.000000,
    Configurations = {
        ['standard'] = {
            teams = {
                { name = 'FFA', armies = {'ARMY_1','ARMY_2','ARMY_3','ARMY_4','ARMY_5','ARMY_6','ARMY_7','ARMY_8',} },
            },
            customprops = {
                ['ExtraArmies'] = STRING( 'ARMY_9 NEUTRAL_CIVILIAN' ),
            },
        },
    }}
