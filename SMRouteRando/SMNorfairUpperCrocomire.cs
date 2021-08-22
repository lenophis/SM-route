using System.Collections.Generic;

namespace SMRouteRando {

    public class SMNorfairUpperCrocomire {

        public static IList<Room> Rooms { get; } = new[] {
            #region Crocomire's Room
            new Room {
                Name = "SM - Crocomire's Room",
                Layout = Room.LayoutFrom(@"
                           2
                           ↓
                      1→XXXXXXXX"
                    , "SM - Crocomire's Room - Left Door"
                    , "SM - Crocomire's Room - Top Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Crocomire's Room - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 2,
                                OpenEnd = 1,
                                UsableComingIn = false,
                            },
                        },
                        CanLeaveCharged = new[] {
                            new RunwayCharge {
                                Length = 33,
                                OpenEnd = 2,
                                FramesRemaining = 50,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Crocomire's Room - Top Door",
                        Type = TransitionType.Gray,
                        SpawnAt = "SM - Crocomire's Room - Central Junction",
                        CanLeaveCharged = new[] {
                            new RunwayCharge {
                                Length = 33,
                                OpenEnd = 2,
                                FramesRemaining = 80,
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Crocomire's Room - Grey Lock",
                                Type = LockType.GameFlag,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["f_DefeatedCrocomire"]*/ },
                                },
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - Crocomire's Room - Item",
                        Type = PlacementType.Visible,
                    },
                    new Event {
                        Name = "SM - Crocomire's Room - Crocomire",
                        Type = EventType.Boss,
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Crocomire's Room - Crocomire Fight",
                                Type = LockType.BossFight,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["Charge"]*/ },
                                    // With a max of 5 missiles, Crocomire may not stop and shoot farmables
                                    // often enough to kill it. So, we're requiring 10 here.
                                    new Strat {
                                        Requires = null,
                                        //[ "Missile",
                                        //  {"ammo": {
                                        //    "type": "Missile",
                                        //    "count": 10
                                        //  }}
                                        //]
                                    },
                                    // While Crocomire's farmables may drop Supers, the rate is too low to
                                    // rely on. If you run out, Croc will most likely push you into the
                                    // spikes. It takes 8 Supers to kill croc if you don't let it move
                                    // forward.
                                    new Strat {
                                        Requires = null,
                                        //[ "Super",
                                        //  {"ammo": {
                                        //    "type": "Super",
                                        //    "count": 8
                                        //  }}
                                        //]
                                    },
                                },
                            },
                        },
                        Yields = new[] { "f_DefeatedCrocomire" },
                    },
                    new Junction {
                        Name = "SM - Crocomire's Room - Central Junction",
                    },
                    new Junction {
                        Name = "SM - Crocomire's Room - Behind Crocomire Junction",
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Crocomire's Room - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Crocomire's Room - Central Junction", new[] {
                                new Strat { Requires = null /*["f_DefeatedCrocomire"]*/ },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Crocomire's Room - Top Door",
                        To = new[] {
                            new LinkTarget("SM - Crocomire's Room - Central Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Crocomire's Room - Item",
                        To = new[] {
                            new LinkTarget("SM - Crocomire's Room - Behind Crocomire Junction", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "f_DefeatedCrocomire",
                                    //  {"or":[
                                    //    "SpaceJump",
                                    //    "Grapple"
                                    //  ]}
                                    //]
                                },
                                new Strat {
                                    Name = "Gravity Acid",
                                    Requires = null,
                                    //[ "f_DefeatedCrocomire",
                                    //  "Gravity",
                                    //  {"acidFrames": 50}
                                    //]
                                },
                                new Strat {
                                    Name = "Acid Bath",
                                    Requires = null,
                                    //[ "f_DefeatedCrocomire",
                                    //  { "acidFrames": 130}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Crocomire's Room - Crocomire",
                        To = new[] {
                            new LinkTarget("SM - Crocomire's Room - Central Junction"),
                            new LinkTarget("SM - Crocomire's Room - Behind Crocomire Junction", new[] {
                                new Strat { Requires = null /*["f_DefeatedCrocomire"]*/ },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Crocomire's Room - Central Junction",
                        To = new[] {
                            new LinkTarget("SM - Crocomire's Room - Left Door", new[] {
                                new Strat { Requires = null /*["f_DefeatedCrocomire"]*/ },
                            }),
                            new LinkTarget("SM - Crocomire's Room - Top Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //{"or": [
                                    //  "SpeedBooster",
                                    //  "HiJump",
                                    //  "h_canFly",
                                    //  "canWalljump",
                                    //  "canSpringBallJumpMidAir"
                                    //]}
                                },
                            }),
                            new LinkTarget("SM - Crocomire's Room - Crocomire"),
                        },
                    },
                    new Link {
                        From = "SM - Crocomire's Room - Behind Crocomire Junction",
                        To = new[] {
                            new LinkTarget("SM - Crocomire's Room - Item", new[] {
                                new Strat {
                                    Requires = null,
                                    //{"or": [
                                    //  "SpaceJump",
                                    //  "Grapple"
                                    //]}
                                },
                                new Strat {
                                    Name = "Gravity Acid",
                                    Requires = null,
                                    //[ "Gravity",
                                    //  {"acidFrames": 35}
                                    //]
                                },
                                new Strat {
                                    Name = "Acid Bath",
                                    Requires = null,
                                    // [{ "acidFrames": 60}]
                                },
                                new Strat {
                                    Name = "Shinespark",
                                    Requires = null,
                                    //{"canShineCharge": {
                                    //  "usedTiles": 33,
                                    //  "shinesparkFrames": 50,
                                    //  "openEnd": 2
                                    //}}
                                },
                                // With a precise enough jump, it's possible to avoid acid damage
                                // without a shinespark.
                                new Strat {
                                    Name = "Crocomire Speedjump",
                                    Notable = true,
                                    Requires = null,
                                    //[ "SpeedBooster",
                                    //  "canTrickyJump"
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Crocomire's Room - Crocomire"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Crocomire's Room - Crocomire",
                        EnemyName = "Crocomire",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Crocomire's Room - Crocomire" },
                        StopSpawn = null, // ["f_DefeatedCrocomire"]
                    },
                },
            },
            #endregion
            #region Norfair Crocomire Farming Room
            new Room {
                Name = "SM - Norfair Crocomire Farming Room",
                Layout = Room.LayoutFrom(@"
                      1→XX←2
                        XX←3
                        ↑
                        4"
                    , "SM - Norfair Crocomire Farming Room - Left Door"
                    , "SM - Norfair Crocomire Farming Room - Top Right Door"
                    , "SM - Norfair Crocomire Farming Room - Bottom Right Door"
                    , "SM - Norfair Crocomire Farming Room - Bottom Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Norfair Crocomire Farming Room - Left Door",
                        Type = TransitionType.Red,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 2,
                                OpenEnd = 1,
                                UsableComingIn = false,
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "Post Crocomire Farming Room Red Lock (to Power Bombs)",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenRedDoors"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Norfair Crocomire Farming Room - Top Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 2,
                                OpenEnd = 1,
                                UsableComingIn = false,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Norfair Crocomire Farming Room - Bottom Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 10,
                                GentleUpTiles = 4,
                                OpenEnd = 0,
                            },
                            // With no Enemies.
                            // Involves leaving some drops hanging after killing the Gamets so they
                            // don't respawn.
                            new RunwayDash {
                                Length = 18,
                                GentleUpTiles = 4,
                                GentleDownTiles = 2,
                                OpenEnd = 1,
                                UsableComingIn = false,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Norfair Crocomire Farming Room - Bottom Door",
                        Type = TransitionType.Blue,
                        CanLeaveCharged = new[] {
                            new RunwayCharge {
                                Length = 18,
                                OpenEnd = 2,
                                FramesRemaining = 120,
                            },
                        },
                    },
                    new Junction {
                        Name = "SM - Norfair Crocomire Farming Room - Main Junction",
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Norfair Crocomire Farming Room - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Norfair Crocomire Farming Room - Main Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Norfair Crocomire Farming Room - Bottom Door",
                        To = new[] {
                            new LinkTarget("SM - Norfair Crocomire Farming Room - Main Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Norfair Crocomire Farming Room - Bottom Right Door",
                        To = new[] {
                            new LinkTarget("SM - Norfair Crocomire Farming Room - Main Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Norfair Crocomire Farming Room - Top Right Door",
                        To = new[] {
                            new LinkTarget("SM - Norfair Crocomire Farming Room - Main Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Norfair Crocomire Farming Room - Main Junction",
                        To = new[] {
                            new LinkTarget("SM - Norfair Crocomire Farming Room - Left Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //{"or":[
                                    //  "h_canFly",
                                    //  "HiJump"
                                    //]}
                                },
                                // Requires canUseEnemies because this wouldn't work without the
                                // Ripper 2 being there.
                                new Strat {
                                    Name = "Ripper Grapple",
                                    Requires = null,
                                    //[ "canUseEnemies",
                                    //  "Grapple"
                                    //]
                                },
                                new Strat {
                                    Name = "Use Frozen Enemies",
                                    Requires = null, // ["canUseFrozenEnemies"]
                                },
                                // Doesn't require opening the bottom right door, even. Just using
                                // the available space and jumping late enough. It does require
                                // killing the Gamets and leaving the drops there so they don't
                                // kill your momentum.
                                new Strat {
                                    Name = "Post Crocomire Farming Room Speed Jump",
                                    Notable = true,
                                    Requires = null, // ["SpeedBooster"]
                                },
                                new Strat {
                                    Name = "Shinespark",
                                    Requires = null,
                                    //{"or":[
                                    //  {"canComeInCharged": {
                                    //    "fromNode": 2,
                                    //    "inRoomPath": [2, 5],
                                    //    "framesRemaining": 0,
                                    //    "shinesparkFrames": 25
                                    //  }},
                                    //  {"canComeInCharged": {
                                    //    "fromNode": 3,
                                    //    "inRoomPath": [3, 5],
                                    //    "framesRemaining": 50,
                                    //    "shinesparkFrames": 25
                                    //  }},
                                    //  {"canComeInCharged": {
                                    //    "fromNode": 4,
                                    //    "inRoomPath": [4, 5],
                                    //    "framesRemaining": 0,
                                    //    "shinesparkFrames": 45
                                    //  }}
                                    //]}
                                },
                                new Strat {
                                    Name = "Post Crocomire Farming Room Dboost",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canDamageBoost",
                                    //  "canTrickyJump"
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Norfair Crocomire Farming Room - Bottom Door"),
                            new LinkTarget("SM - Norfair Crocomire Farming Room - Bottom Right Door"),
                            new LinkTarget("SM - Norfair Crocomire Farming Room - Top Right Door"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Norfair Crocomire Farming Room - Ripper 2",
                        EnemyName = "Ripper 2 (green)",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Norfair Crocomire Farming Room - Main Junction" },
                    },
                    new Enemy {
                        GroupName = "SM - Norfair Crocomire Farming Room - Gamets",
                        EnemyName = "Gamet",
                        Quantity = 5,
                        HomeNodes = new[] { "SM - Norfair Crocomire Farming Room - Main Junction" },
                        FarmCycles = new[] {
                            new FarmCycle {
                                Name = "Crouch over Gamets",
                                CycleFrames = 120,
                            },
                        },
                    },
                },
            },
            #endregion
            #region Norfair Crocomire Prize Room
            new Room {
                Name = "SM - Norfair Crocomire Prize Room",
                Layout = Room.LayoutFrom(@"
                      X←1"
                    , "SM - Norfair Crocomire Prize Room - Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Norfair Crocomire Prize Room - Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 4,
                                OpenEnd = 0,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"heatFrames": 50}
                                        //]
                                    },
                                },
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - Norfair Crocomire Prize Room - Item",
                        Type = PlacementType.Visible,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Norfair Crocomire Prize Room - Door",
                        To = new[] {
                            new LinkTarget("SM - Norfair Crocomire Prize Room - Item", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 100}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Norfair Crocomire Prize Room - Item",
                        To = new[] {
                            new LinkTarget("SM - Norfair Crocomire Prize Room - Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 100}
                                    //]
                                },
                            }),
                        },
                    },
                },
            },
            #endregion
            #region Norfair Crocomire Shaft
            new Room {
                Name = "SM - Norfair Crocomire Shaft",
                Layout = Room.LayoutFrom(@"
                        2
                        ↓
                      1→X
                        X
                        X
                        X←3
                        X
                        ↑
                        4"
                    , "SM - Norfair Crocomire Shaft - Left Door"
                    , "SM - Norfair Crocomire Shaft - Top Door"
                    , "SM - Norfair Crocomire Shaft - Right Door"
                    , "SM - Norfair Crocomire Shaft - Bottom Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Norfair Crocomire Shaft - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 9,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Norfair Crocomire Shaft - Top Door",
                        Type = TransitionType.Blue,
                    },
                    new Transition {
                        Name = "SM - Norfair Crocomire Shaft - Right Door",
                        Type = TransitionType.Red,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 1,
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Norfair Crocomire Shaft - Red Lock",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenRedDoors"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Norfair Crocomire Shaft - Bottom Door",
                        Type = TransitionType.Blue,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Norfair Crocomire Shaft - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Norfair Crocomire Shaft - Top Door"),
                        },
                    },
                    new Link {
                        From = "SM - Norfair Crocomire Shaft - Bottom Door",
                        To = new[] {
                            new LinkTarget("SM - Norfair Crocomire Shaft - Right Door"),
                        },
                    },
                    new Link {
                        From = "SM - Norfair Crocomire Shaft - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Norfair Crocomire Shaft - Bottom Door"),
                            new LinkTarget("SM - Norfair Crocomire Shaft - Top Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //{"or": [
                                    //  "canWalljump",
                                    //  "h_canFly"
                                    //]}
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Norfair Crocomire Shaft - Top Door",
                        To = new[] {
                            new LinkTarget("SM - Norfair Crocomire Shaft - Left Door"),
                            new LinkTarget("SM - Norfair Crocomire Shaft - Right Door"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Norfair Crocomire Shaft - Bottom Violas",
                        EnemyName = "Viola",
                        Quantity = 2,
                        HomeNodes = new[] { "SM - Norfair Crocomire Shaft - Bottom Door" },
                    },
                    new Enemy {
                        GroupName = "SM - Norfair Crocomire Shaft - Top Violas",
                        EnemyName = "Viola",
                        Quantity = 2,
                        HomeNodes = new[] { "SM - Norfair Crocomire Shaft - Right Door" },
                    },
                },
            },
            #endregion
            #region Cosine Room
            new Room {
                Name = "SM - Cosine Room",
                Layout = Room.LayoutFrom(@"
                      1→XXXX"
                    , "SM - Cosine Room - Left Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Cosine Room - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 4,
                                GentleUpTiles = 2,
                                OpenEnd = 0,
                            },
                            // With Acid Timing.
                            new RunwayDash {
                                Length = 33,
                                OpenEnd = 1,
                                UsableComingIn = false,
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - Cosine Room - Item",
                        Type = PlacementType.Visible,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Cosine Room - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Cosine Room - Item", new[] {
                                new Strat { Requires = null /*["Morph"]*/ },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Cosine Room - Item",
                        To = new[] {
                            new LinkTarget("SM - Cosine Room - Left Door", new[] {
                                new Strat { Requires = null /*["Morph"]*/ },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Cosine Room - Metarees",
                        EnemyName = "Metaree",
                        Quantity = 2,
                        HomeNodes = new[] { "SM - Cosine Room - Left Door" },
                    },
                    // With the gamets spawning over acid, there probably isn't a more effective strat.
                    new Enemy {
                        GroupName = "SM - Cosine Room - Gamets",
                        EnemyName = "Gamet",
                        Quantity = 5,
                        HomeNodes = new[] { "SM - Cosine Room - Item" },
                        FarmCycles = new[] {
                            new FarmCycle {
                                Name = "Crouch 3 tiles over Gamets",
                                CycleFrames = 165,
                            },
                        },
                    },
                },
            },
            #endregion
            #region Indiana Jones Room
            new Room {
                Name = "SM - Indiana Jones Room",
                Layout = Room.LayoutFrom(@"
                        XXXXX 2
                      1→XXXXX ↓
                        XXXXXXXX"
                    , "SM - Indiana Jones Room - Left Door"
                    , "SM - Indiana Jones Room - Top Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Indiana Jones Room - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 9,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Indiana Jones Room - Top Door",
                        Type = TransitionType.Blue,
                        CanLeaveCharged = new[] {
                            new RunwayCharge {
                                Length = 32,
                                OpenEnd = 1,
                                FramesRemaining = 60,
                                Strats = new[] {
                                    // This is available if Speed blocks can be destroyed by
                                    // travelling to Usable Speed Ramp Junction.
                                    new Strat {
                                        Name = "Speed Blocks Broken",
                                        Obstacles = new[] {
                                            new Strat.Obstacle {
                                                Name = "Speed blocks",
                                                Requires = null, // ["never"]
                                            },
                                        },
                                    },
                                },
                            },
                            new RunwayCharge {
                                Length = 33,
                                OpenEnd = 2,
                                FramesRemaining = 120,
                                Strats = new[] {
                                    new Strat {
                                        Name = "Break Power Bomb Blocks",
                                        Obstacles = new[] {
                                            new Strat.Obstacle {
                                                Name = "Power bomb blocks",
                                                Requires = null, // ["h_canUsePowerBombs"]
                                            },
                                        },
                                    },
                                },
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - Indiana Jones Room - Item",
                        Type = PlacementType.Visible,
                    },
                    // This node strictly represents access to the speed ramp *with the speed
                    // blocks broken*. If they can't be broken, this node is not considered
                    // accessible but Small Platforms Junction might be.
                    new Junction {
                        Name = "SM - Indiana Jones Room - Usable Speed Ramp Junction",
                    },
                    // This node represents the small platforms above the acid. In some situations,
                    // it may be accessible without access to Usable Speed Ramp Junction, if the
                    // Speed blocks can't be broken.
                    new Junction {
                        Name = "SM - Indiana Jones Room - Small Platforms Junction",
                    },
                },
                Obstacles = new[] {
                    new Obstacle {
                        Name = "Power bomb blocks",
                        Type = ObstacleType.Inanimate,
                    },
                    new Obstacle {
                        Name = "Speed blocks",
                        Type = ObstacleType.Inanimate,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Indiana Jones Room - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Indiana Jones Room - Item", new[] {
                                new Strat { Requires = null /*["SpaceJump"]*/ },
                                // Doesn't need hjb. Takes two walljumps, and must do the
                                // shinespark at the apex.
                                new Strat {
                                    Name = "Left-Side Indy Spark",
                                    Notable = true,
                                    Requires = null,
                                    //{"canComeInCharged": {
                                    //  "fromNode": 1,
                                    //  "framesRemaining": 150,
                                    //  "shinesparkFrames": 40
                                    //}}
                                },
                                // Requires canUseEnemies because this wouldn't work without the
                                // Ripper 2's being there.
                                new Strat {
                                    Name = "Indiana Jones Grapple",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canUseEnemies",
                                    //  "Grapple"
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Indiana Jones Room - Usable Speed Ramp Junction", new[] {
                                // The blocks can be broken if you can generate a blue suit using
                                // the previous room's runway, and carry it to the blocks by
                                // slowing floating down with Space Jump.
                                new Strat {
                                    Name = "PCJR Bluespace",
                                    Notable = true,
                                    Requires = null,
                                    //[ {"canComeInCharged": {
                                    //    "fromNode": 1,
                                    //    "framesRemaining": 180,
                                    //    "shinesparkFrames": 0
                                    //  }},
                                    //  "canBlueSpaceJump"
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Indiana Jones Room - Small Platforms Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Indiana Jones Room - Top Door",
                        To = new[] {
                            new LinkTarget("SM - Indiana Jones Room - Usable Speed Ramp Junction", new[] {
                                new Strat {
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Power bomb blocks",
                                            Requires = null, // ["h_canUsePowerBombs"]
                                        },
                                        new Strat.Obstacle {
                                            Name = "Speed blocks",
                                            Requires = null, // ["SpeedBooster"]
                                        },
                                    },
                                },
                                // This exists to guarantee going back is free after the speed
                                // blocks have been broken. None of the other strats can work as a
                                // proper substitute. The base strat requires obstacle A. The
                                // shinespark strat may not be possible. The stutter-3 is notable
                                // and could be turned off.
                                new Strat {
                                    Name = "Base with Broken Obstacle",
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Speed blocks",
                                            Requires = null, // ["never"]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Shinespark",
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Speed blocks",
                                            Requires = null,
                                            //{"canComeInCharged": {
                                            //  "fromNode": 2,
                                            //  "framesRemaining": 100,
                                            //  "shinesparkFrames": 120
                                            //}}
                                        },
                                    },
                                },
                                // Commonly known as a stutter-3, this is also doable as a 4-tap.
                                new Strat {
                                    Name = "PCJR Stutter-3",
                                    Notable = true,
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Speed blocks",
                                            Requires = null,
                                            //{"canShineCharge": {
                                            //  "usedTiles": 17,
                                            //  "shinesparkFrames": 0,
                                            //  "openEnd": 0
                                            //}}
                                        },
                                    },
                                },
                            }),
                            new LinkTarget("SM - Indiana Jones Room - Small Platforms Junction", new[] {
                                new Strat { Requires = null /*["Morph"]*/ },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Indiana Jones Room - Item",
                        To = new[] {
                            // No Space Jump strat because that's taken care of by Item ->
                            // Small Platforms Junction -> Left Door.
                            new LinkTarget("SM - Indiana Jones Room - Left Door", new[] {
                                // Requires canUseEnemies because this wouldn't work without the
                                // Ripper 2's being there.
                                new Strat {
                                    Name = "Reverse Indiana Jones Grapple",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canUseEnemies",
                                    //  "Grapple"
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Indiana Jones Room - Small Platforms Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Indiana Jones Room - Usable Speed Ramp Junction",
                        To = new[] {
                            new LinkTarget("SM - Indiana Jones Room - Left Door", new[] {
                                // Fire off the shinespark at the apex of two consecutive walljumps.
                                // You can have a 'max' length runway available here if you break
                                // the PB blocks, but we won't duplicate strats for that right now.
                                new Strat {
                                    Name = "PCJR Walljump Shinespark to Grapple",
                                    Notable = true,
                                    Requires = null,
                                    //{"canShineCharge": {
                                    //  "usedTiles": 32,
                                    //  "shinesparkFrames": 90,
                                    //  "openEnd": 1
                                    //}}
                                },
                                // Charge a spark to the right, then come back, run and jump, and
                                // do a horizontal spark at the apex. You can have a 'max' length
                                // runway available here if you break the PB blocks, but we won't
                                // duplicate strats for that right now.
                                new Strat {
                                    Name = "PCJR Big Jump Shinespark",
                                    Notable = true,
                                    Requires = null,
                                    //{"canShineCharge": {
                                    //  "usedTiles": 32,
                                    //  "shinesparkFrames": 52,
                                    //  "openEnd": 1
                                    //}}
                                },
                                new Strat {
                                    Name = "Short run Speedjump",
                                    Requires = null,
                                    //[ "SpeedBooster",
                                    //  "HiJump"
                                    //]
                                },
                                new Strat {
                                    Name = "Long Run Speedjump",
                                    Requires = null, // ["SpeedBooster"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Power bomb blocks",
                                            Requires = null, // [ "h_canUsePowerBombs" ]
                                        },
                                    },
                                },
                            }),
                            // Since Usable Speed Ramp Junction is only accessed if Speed blocks
                            // are broken, access back to Top Door is free.
                            new LinkTarget("SM - Indiana Jones Room - Top Door"),
                            // All strats that don't require speed blocks to be broken are in
                            // Small Platforms Junction -> Item.
                            new LinkTarget("SM - Indiana Jones Room - Item", new[] {
                                // You can have a capped length runway available here if you break
                                // the PB blocks, but we won't duplicate strats for that right now.
                                new Strat {
                                    Name = "Shinespark",
                                    Requires = null,
                                    //{"canShineCharge": {
                                    //  "usedTiles": 32,
                                    //  "shinesparkFrames": 40,
                                    //  "openEnd": 1
                                    //}}
                                },
                                new Strat {
                                    Name = "Speedjump",
                                    Requires = null,
                                    //[ "SpeedBooster",
                                    //  "HiJump"
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Indiana Jones Room - Small Platforms Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Indiana Jones Room - Small Platforms Junction",
                        To = new[] {
                            new LinkTarget("SM - Indiana Jones Room - Left Door", new[] {
                                new Strat { Requires = null /*["SpaceJump"]*/ },
                                // Separate strat because it has to start in midair. Maybe also
                                // make a tech for that later?
                                new Strat {
                                    Name = "PCJR Door IBJ",
                                    Notable = true,
                                    Requires = null, // ["canIBJ"]
                                },
                                new Strat {
                                    Name = "Speedjump",
                                    Requires = null,
                                    //[ "SpeedBooster",
                                    //  "HiJump"
                                    //]
                                },
                                // Speed blocks is present here because you need access to Top Door
                                // to bring a Mella over. Then you need to manipulate it to go high
                                // enough to be used as a stepping stone once frozen.
                                new Strat {
                                    Name = "PCJR Frozen Mella Door",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canUseFrozenEnemies",
                                    //  "canManipulateMellas"
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Speed blocks",
                                            Requires = null, // ["never"]
                                            Bypass = null, // ["Morph"]
                                        },
                                    },
                                },
                            }),
                            // If the speed blocks are broken, free access can be attained via
                            // Usable Speed Ramp Junction
                            new LinkTarget("SM - Indiana Jones Room - Top Door", new[] {
                                new Strat { Requires = null /*["Morph"]*/ },
                            }),
                            new LinkTarget("SM - Indiana Jones Room - Item", new[] {
                                new Strat { Requires = null /*["h_canFly"]*/ },
                                new Strat {
                                    Name = "PCJR Speedjump SpringBall",
                                    Notable = true,
                                    Requires = null,
                                    //[ "HiJump",
                                    //  "SpeedBooster",
                                    //  "canSpringBallJumpMidAir"
                                    //]
                                },
                                new Strat {
                                    Name = "PCJR Springwall",
                                    Notable = true,
                                    Requires = null,
                                    //[ "HiJump",
                                    //  "canSpringwall",
                                    //  "canPreciseWalljump"
                                    //]
                                },
                                // Speed blocks is present here because you need access to Top Door
                                // to bring a Mella over. Then you need to manipulate it to go high
                                // enough to be used as a stepping stone once frozen.
                                new Strat {
                                    Name = "Indy Jones Short Mella",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canUseFrozenEnemies",
                                    //  "canManipulateMellas",
                                    //  "HiJump"
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Speed blocks",
                                            Requires = null, // ["never"],
                                            Bypass = null, // ["Morph"]
                                        },
                                    },
                                },
                                // Speed blocks is present here because you need access to Top Door
                                // to bring a Mella over. Then you need to manipulate it to go high
                                // enough to be used as a stepping stone once frozen.
                                new Strat {
                                    Name = "Indy Jones Long Mella",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canUseFrozenEnemies",
                                    //  "canManipulateMellas",
                                    //  "canBePatient"
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Speed blocks",
                                            Requires = null, // ["never"],
                                            Bypass = null, // ["Morph"]
                                        },
                                    },
                                },
                            }),
                            new LinkTarget("SM - Indiana Jones Room - Usable Speed Ramp Junction", new[] {
                                // Gravity makes it possible to charge a spark in the acid and get
                                // to Usable Speed Ramp Junction.
                                new Strat {
                                    Name = "PCJR Acid Shinespark",
                                    Notable = true,
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Speed blocks",
                                            Requires = null,
                                            //[ "Gravity",
                                            //  {"canShineCharge": {
                                            //    "usedTiles": 33,
                                            //    "shinesparkFrames":35,
                                            //    "openEnd": 2
                                            //  }},
                                            //  { "acidFrames": 140}
                                            //]
                                        },
                                    },
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Indiana Jones Room - Rippers 2s",
                        EnemyName = "Ripper 2 (green)",
                        Quantity = 4,
                        BetweenNodes = new[] {
                            "SM - Indiana Jones Room - Left Door",
                            "SM - Indiana Jones Room - Item",
                        },
                    },
                    new Enemy {
                        GroupName = "SM - Indiana Jones Room - Mellas",
                        EnemyName = "Mella",
                        Quantity = 5,
                        HomeNodes = new[] { "SM - Indiana Jones Room - Top Door" },
                    },
                },
            },
            #endregion
            // Todo: Acceptable name?
            #region Grappling Chozo Room
            new Room {
                Name = "SM - Grappling Chozo Room",
                Layout = Room.LayoutFrom(@"
                      X←1
                      X
                      X←2"
                    , "SM - Grappling Chozo Room - Top Right Door"
                    , "SM - Grappling Chozo Room - Bottom Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Grappling Chozo Room - Top Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 0,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Grappling Chozo Room - Bottom Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 9,
                                OpenEnd = 0,
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - Grappling Chozo Room - Item",
                        Type = PlacementType.Chozo,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Grappling Chozo Room - Top Right Door",
                        To = new[] {
                            new LinkTarget("SM - Grappling Chozo Room - Item"),
                        },
                    },
                    new Link {
                        From = "SM - Grappling Chozo Room - Bottom Right Door",
                        To = new[] {
                            new LinkTarget("SM - Grappling Chozo Room - Item"),
                        },
                    },
                    new Link {
                        From = "SM - Grappling Chozo Room - Item",
                        To = new[] {
                            new LinkTarget("SM - Grappling Chozo Room - Top Right Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //{"or": [
                                    //  {"and": [
                                    //    "HiJump",
                                    //    "Grapple"
                                    //  ]},
                                    //  "canWalljump",
                                    //  "h_canFly"
                                    //]}
                                },
                                new Strat {
                                    Name = "Shinespark",
                                    Requires = null,
                                    //{"canComeInCharged": {
                                    //  "fromNode": 2,
                                    //  "inRoomPath": [2, 3],
                                    //  "framesRemaining": 20,
                                    //  "shinesparkFrames": 40
                                    //}}
                                },
                            }),
                            new LinkTarget("SM - Grappling Chozo Room - Bottom Right Door"),
                        },
                    },
                },
            },
            #endregion
            // Todo: Acceptable name?
            #region Norfair Crocomire Small Moat
            new Room {
                Name = "SM - Norfair Crocomire Small Moat",
                Layout = Room.LayoutFrom(@"
                      1→XX←2"
                    , "SM - Norfair Crocomire Small Moat - Left Door"
                    , "SM - Norfair Crocomire Small Moat - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Norfair Crocomire Small Moat - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 9,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Norfair Crocomire Small Moat - Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 8,
                                OpenEnd = 1,
                            },
                        },
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Norfair Crocomire Small Moat - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Norfair Crocomire Small Moat - Right Door"),
                        },
                    },
                    new Link {
                        From = "SM - Norfair Crocomire Small Moat - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Norfair Crocomire Small Moat - Left Door"),
                        },
                    },
                },
            },
            #endregion
            // Todo: Acceptable name?
            #region Grappling Climb Room
            new Room {
                Name = "SM - Grappling Climb Room",
                Layout = Room.LayoutFrom(@"
                        X←2
                        X
                      1→X"
                    , "SM - Grappling Climb Room - Left Door"
                    , "SM - Grappling Climb Room - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Grappling Climb Room - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Grappling Climb Room - Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 0,
                                OpenEnd = 1,
                            },
                        },
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Grappling Climb Room - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Grappling Climb Room - Right Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //{"or":[
                                    //  "h_canFly",
                                    //  "HiJump",
                                    //  "canSpringBallJumpMidAir",
                                    //  "Grapple"
                                    //]}
                                },
                                new Strat {
                                    Name = "Shinespark",
                                    Requires = null,
                                    //{"canComeInCharged": {
                                    //  "fromNode": 1,
                                    //  "framesRemaining": 120,
                                    //  "shinesparkFrames": 30
                                    //}}
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Grappling Climb Room - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Grappling Climb Room - Left Door"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Grappling Climb Room - Funes",
                        EnemyName = "Fune",
                        Quantity = 3,
                        HomeNodes = new[] { "SM - Grappling Climb Room - Left Door" },
                    },
                },
            },
            #endregion
            // Todo: Acceptable name?
            #region Norfair Crocomire Double Moat
            new Room {
                Name = "SM - Norfair Crocomire Double Moat",
                Layout = Room.LayoutFrom(@"
                      1→XXX←2
                        XXX"
                    , "SM - Norfair Crocomire Double Moat - Left Door"
                    , "SM - Norfair Crocomire Double Moat - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Norfair Crocomire Double Moat - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Norfair Crocomire Double Moat - Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 0,
                            },
                            // With Gate Open.
                            new RunwayDash {
                                Length = 6,
                                OpenEnd = 1,
                                UsableComingIn = false,
                                Strats = new[] {
                                    new Strat {
                                        Obstacles = new[] {
                                            new Strat.Obstacle {
                                                Name = "Green Gate",
                                                Requires = null, // ["canGGG"]
                                            },
                                        },
                                    },
                                },
                            },
                        },
                    },
                    new Junction {
                        Name = "SM - Norfair Crocomire Double Moat - Left of Gate Junction",
                    },
                },
                Obstacles = new[] {
                    new Obstacle {
                        Name = "Green Gate",
                        Type = ObstacleType.Inanimate,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Norfair Crocomire Double Moat - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Norfair Crocomire Double Moat - Left of Gate Junction", new[] {
                                new Strat {
                                    Requires = null,
                                    //{"or":[
                                    //  {"and": [
                                    //    "canWalljump",
                                    //    "Gravity"
                                    //  ]},
                                    //  "Grapple",
                                    //  "SpaceJump"
                                    //]}
                                },
                                new Strat {
                                    Name = "Shinespark",
                                    Requires = null,
                                    //{"canComeInCharged": {
                                    //  "fromNode": 1,
                                    //  "framesRemaining": 0,
                                    //  "shinesparkFrames": 60
                                    //}}
                                },
                                new Strat {
                                    Name = "Grapple Tutorial Speedjump",
                                    Notable = true,
                                    Requires = null,
                                    //[ "SpeedBooster",
                                    //  "canTrickyJump"
                                    //]
                                },
                                // 1- Bring a Gamet above the water line.
                                // 2- Freeze the Gamet before it starts moving left.
                                // 3- Cross the first moat.
                                // 4- Wait for it to thaw and freeze it a second time to cross the
                                //    second moat.
                                new Strat {
                                    Name = "Grapple Tutorial Frozen Gamet",
                                    Notable = true,
                                    Requires = null, // ["canTrickyUseFrozenEnemies"],
                                },
                                // 1- Stand near the farm point, on the edge of where you make
                                //    Gamets spawn.
                                // 2- Wait for the proper water position.
                                // 3- Move to make the Gamets spawn. Moonwalk useful here.
                                // 4- Quickly climb up to the last ledge before the dor.
                                // 5- Move as far left as possible, wait for the Gamets to start
                                //    deploying vertically.
                                // 6- Run, jump, dboost off a Gamet. Make sure you make the top one
                                //    move right.
                                // 7- Dboost a second time off the Gamet to cross the second moat.
                                new Strat {
                                    Name = "Grapple Tutorial Double Dboost",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canContinuousDboost",
                                    //  {"enemyDamage": {
                                    //    "enemy": "Gamet",
                                    //    "type": "contact",
                                    //    "hits": 2
                                    //  }}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Norfair Crocomire Double Moat - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Norfair Crocomire Double Moat - Left of Gate Junction", new[] {
                                new Strat {
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Green Gate",
                                            Requires = null, // ["canGGG"]
                                        },
                                    },
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Norfair Crocomire Double Moat - Left of Gate Junction",
                        To = new[] {
                            new LinkTarget("SM - Norfair Crocomire Double Moat - Left Door"),
                            new LinkTarget("SM - Norfair Crocomire Double Moat - Right Door", new[] {
                                new Strat {
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Green Gate",
                                            Requires = null, // ["h_canOpenGreenDoors"]
                                        },
                                    },
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Norfair Crocomire Double Moat - Gamets",
                        EnemyName = "Gamet",
                        Quantity = 5,
                        HomeNodes = new[] { "SM - Norfair Crocomire Double Moat - Left Door" },
                        FarmCycles = new[] {
                            new FarmCycle {
                                Name = "Crouch over Gamets",
                                CycleFrames = 120,
                            },
                        },
                    },
                    new Enemy {
                        GroupName = "SM - Norfair Crocomire Double Moat - Puyos",
                        EnemyName = "Puyo",
                        Quantity = 5,
                        BetweenNodes = new[] {
                            "SM - Norfair Crocomire Double Moat - Left Door",
                            "SM - Norfair Crocomire Double Moat - Right Door",
                        },
                    },
                },
            },
            #endregion
            #region Norfair Upper Save Room C
            new Room {
                Name = "SM - Norfair Upper Save Room C",
                Layout = Room.LayoutFrom(@"
                      1→X"
                    , "SM - Norfair Upper Save Room C - Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Norfair Upper Save Room C - Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 2,
                                OpenEnd = 1,
                                UsableComingIn = false,
                            },
                        },
                    },
                    new Utility {
                        Name = "SM - Norfair Upper Save Room C - Save Station",
                        Type = UtilityType.Save,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Norfair Upper Save Room C - Door",
                        To = new[] {
                            new LinkTarget("SM - Norfair Upper Save Room C - Save Station"),
                        },
                    },
                    new Link {
                        From = "SM - Norfair Upper Save Room C - Save Station",
                        To = new[] {
                            new LinkTarget("SM - Norfair Upper Save Room C - Door"),
                        },
                    },
                },
            },
            #endregion
        };

    }

}
