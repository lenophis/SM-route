using System.Collections.Generic;
using SMRouteRando.Util;

namespace SMRouteRando {

    public class SMWreckedShip {

        public static IList<Room> Rooms { get; } = new[] {
            #region Wrecked Ship Entrance
            new Room {
                Name = "SM - Wrecked Ship Entrance",
                Layout = Room.LayoutFrom(@"
                      1→XXXX←2"
                    , "SM - Wrecked Ship Entrance - Left Door"
                    , "SM - Wrecked Ship Entrance - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Wrecked Ship Entrance - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 33,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Wrecked Ship Entrance - Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 33,
                                OpenEnd = 1,
                            },
                        },
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Wrecked Ship Entrance - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Wrecked Ship Entrance - Right Door"),
                        },
                    },
                    new Link {
                        From = "SM - Wrecked Ship Entrance - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Wrecked Ship Entrance - Left Door"),
                        },
                    },
                },
            },
            #endregion
            #region Wrecked Ship Main Shaft
            new Room {
                Name = "SM - Wrecked Ship Main Shaft",
                // Todo: Correct layout?
                Layout = Room.LayoutFrom(@"
                          3
                          ↓
                          X
                          X
                          X
                        2→X←4
                          X←5
                      XXXXX
                        1→XX←6
                          X
                          ↑
                          7"
                    , "SM - Wrecked Ship Main Shaft - Bottom Left Door"
                    , "SM - Wrecked Ship Main Shaft - Top Left Door"
                    , "SM - Wrecked Ship Main Shaft - Top Door"
                    , "SM - Wrecked Ship Main Shaft - Top Right Door"
                    , "SM - Wrecked Ship Main Shaft - Middle Right Door"
                    , "SM - Wrecked Ship Main Shaft - Bottom Right Door"
                    , "SM - Wrecked Ship Main Shaft - Bottom Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Wrecked Ship Main Shaft - Bottom Left Door",
                        Type = TransitionType.Gray,
                        Runways = new[] {
                            // With Broken Blocks.
                            new RunwayDash {
                                Length = 1,
                                OpenEnd = 1,
                                UsableComingIn = false,
                            },
                            // It's technically possible to reset at Bottom Door and keep the top
                            // layer of the Shot Blocks obstacle intact by clipping through the
                            // blocks, but do we really need to represent that?
                            new RunwayDash {
                                Length = 13,
                                OpenEnd = 0,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //{"resetRoom": {
                                        //  "nodes": [1, 2, 3, 4, 5, 6],
                                        //  "obstaclesToAvoid": ["B"]
                                        //}}
                                    },
                                },
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Wrecked Ship Main Shaft - Bottom Left Grey Lock",
                                Type = LockType.GameFlag,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["f_DefeatedPhantoon"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Wrecked Ship Main Shaft - Top Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 5,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Wrecked Ship Main Shaft - Top Door",
                        Type = TransitionType.Blue,
                    },
                    new Transition {
                        Name = "SM - Wrecked Ship Main Shaft - Top Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 12,
                                SteepUpTiles = 7,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Wrecked Ship Main Shaft - Middle Right Door",
                        Type = TransitionType.Gray,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 11,
                                SteepUpTiles = 6,
                                OpenEnd = 1,
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Wrecked Ship Main Shaft - Middle Right Grey Lock",
                                Type = LockType.GameFlag,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["f_DefeatedPhantoon"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Wrecked Ship Main Shaft - Bottom Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 0,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Wrecked Ship Main Shaft - Bottom Door",
                        Type = TransitionType.Green,
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Wrecked Ship Main Shaft - Green Lock",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenGreenDoors"]*/ },
                                },
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - Wrecked Ship Main Shaft - Item",
                        Type = PlacementType.Visible,
                    },
                    new Junction {
                        Name = "SM - Wrecked Ship Main Shaft - Central Junction",
                    },
                },
                Obstacles = new[] {
                    // The bomb blocks that separate the bottom right door from the main shaft.
                    new Obstacle {
                        Name = "Bomb Blocks",
                        Type = ObstacleType.Inanimate,
                    },
                    // The shot blocks that separate the bottom door from the main shaft.
                    new Obstacle {
                        Name = "Shot Blocks",
                        Type = ObstacleType.Inanimate,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Wrecked Ship Main Shaft - Top Door",
                        To = new[] {
                            new LinkTarget("SM - Wrecked Ship Main Shaft - Central Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Wrecked Ship Main Shaft - Top Left Door",
                        To = new[] {
                            new LinkTarget("SM - Wrecked Ship Main Shaft - Central Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Wrecked Ship Main Shaft - Bottom Left Door",
                        To = new[] {
                            new LinkTarget("SM - Wrecked Ship Main Shaft - Central Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Wrecked Ship Main Shaft - Top Right Door",
                        To = new[] {
                            new LinkTarget("SM - Wrecked Ship Main Shaft - Central Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Wrecked Ship Main Shaft - Middle Right Door",
                        To = new[] {
                            new LinkTarget("SM - Wrecked Ship Main Shaft - Central Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Wrecked Ship Main Shaft - Bottom Right Door",
                        To = new[] {
                            // FIXME there is certainly a possible speedball here depending on
                            // adjacent room.
                            new LinkTarget("SM - Wrecked Ship Main Shaft - Central Junction", new[] {
                                new Strat {
                                    Requires = null, // ["Morph"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Bomb Blocks",
                                            Requires = null, // ["h_canPassBombPassages"]
                                        },
                                    },
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Wrecked Ship Main Shaft - Bottom Door",
                        To = new[] {
                            new LinkTarget("SM - Wrecked Ship Main Shaft - Central Junction", new[] {
                                new Strat {
                                    Name = "Morph Bombs",
                                    Requires = null, // ["Morph"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Shot Blocks",
                                            Requires = null, // ["h_canUseMorphBombs"]
                                        },
                                    },
                                },
                                // It's possible to mid-air morph into the morph tunnel.
                                new Strat {
                                    Name = "Shoot the Blocks",
                                    Requires = null, // ["Morph"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Shot Blocks",
                                            Requires = null,
                                            //{"or":[
                                            //  "Wave",
                                            //  "Spazer"
                                            //]}
                                        },
                                    },
                                },
                                // It's possible to mid-air morph into the morph tunnel. This is
                                // why no PBs are needed if the obstacle is already broken.
                                new Strat {
                                    Name = "Power Bombs",
                                    Requires = null, // ["Morph"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Shot Blocks",
                                            Requires = null, // ["h_canUsePowerBombs"]
                                            AdditionalObstacles = new[] { "Bomb Blocks" },
                                        },
                                    },
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Wrecked Ship Main Shaft - Item",
                        To = new[] {
                            new LinkTarget("SM - Wrecked Ship Main Shaft - Central Junction", new[] {
                                // No bombs needed on the premise that you can only get to 8 by
                                // breaking the bomb blocks.
                                new Strat { Requires = null /*["Morph"]*/ },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Wrecked Ship Main Shaft - Central Junction",
                        To = new[] {
                            new LinkTarget("SM - Wrecked Ship Main Shaft - Top Door"),
                            new LinkTarget("SM - Wrecked Ship Main Shaft - Top Left Door"),
                            new LinkTarget("SM - Wrecked Ship Main Shaft - Bottom Left Door"),
                            new LinkTarget("SM - Wrecked Ship Main Shaft - Top Right Door"),
                            new LinkTarget("SM - Wrecked Ship Main Shaft - Middle Right Door"),
                            new LinkTarget("SM - Wrecked Ship Main Shaft - Bottom Right Door", new[] {
                                new Strat {
                                    Name = "Morph Bombs",
                                    Requires = null, // ["Morph"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Bomb Blocks",
                                            Requires = null, // ["h_canUseMorphBombs"]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Power Bombs",
                                    Requires = null, // ["Morph"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Bomb Blocks",
                                            Requires = null, // ["h_canUsePowerBombs"]
                                            AdditionalObstacles = new[] { "Shot Blocks" },
                                        },
                                    },
                                },
                            }),
                            new LinkTarget("SM - Wrecked Ship Main Shaft - Bottom Door", new[] {
                                // From this direction, obstacle B is fully breakable with Power Beam.
                                new Strat {
                                    Requires = null, // ["Morph"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle { Name = "Shot Blocks" },
                                    },
                                },
                            }),
                            new LinkTarget("SM - Wrecked Ship Main Shaft - Item", new[] {
                                new Strat { Requires = null /*["h_canPassBombPassages"]*/ },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Wrecked Ship Main Shaft - Covern",
                        EnemyName = "Covern",
                        Quantity = 1,
                        HomeNodes = new[] {
                            "SM - Wrecked Ship Main Shaft - Top Door",
                            "SM - Wrecked Ship Main Shaft - Bottom Door",
                            "SM - Wrecked Ship Main Shaft - Central Junction",
                        },
                        StopSpawn = null, // ["f_DefeatedPhantoon"]
                    },
                    new Enemy {
                        GroupName = "SM - Wrecked Ship Main Shaft - Trapped Atomics",
                        EnemyName = "Trapped Atomic",
                        Quantity = 2,
                        HomeNodes = new[] { "SM - Wrecked Ship Main Shaft - Bottom Door" },
                        StopSpawn = null, // ["f_DefeatedPhantoon"]
                    },
                    new Enemy {
                        GroupName = "SM - Wrecked Ship Main Shaft - Atomics",
                        EnemyName = "Atomic",
                        Quantity = 4,
                        HomeNodes = new[] { "SM - Wrecked Ship Main Shaft - Central Junction" },
                        Spawn = null, // ["f_DefeatedPhantoon"]
                    },
                },
            },
            #endregion
            #region Wrecked Ship Basement
            new Room {
                Name = "SM - Wrecked Ship Basement",
                // Todo: Correct layout?
                Layout = Room.LayoutFrom(@"
                          2
                          ↓
                      1→XXXXX←3"
                    , "SM - Wrecked Ship Basement - Left Door"
                    , "SM - Wrecked Ship Basement - Top Door"
                    , "SM - Wrecked Ship Basement - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Wrecked Ship Basement - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 2,
                                UsableComingIn = false,
                                OpenEnd = 1,
                            },
                        },
                        CanLeaveCharged = new[] {
                            new RunwayCharge {
                                Length = 33,
                                FramesRemaining = 120,
                                OpenEnd = 2,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Wrecked Ship Basement - Top Door",
                        Type = TransitionType.Blue,
                        CanLeaveCharged = new[] {
                            new RunwayCharge {
                                Length = 33,
                                FramesRemaining = 60,
                                OpenEnd = 2,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Wrecked Ship Basement - Right Door",
                        Type = TransitionType.Gedora,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 1,
                                OpenEnd = 1,
                                UsableComingIn = false,
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Wrecked Ship Basement - Eye Lock",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenEyeDoors"]*/ },
                                },
                            },
                        },
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Wrecked Ship Basement - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Wrecked Ship Basement - Top Door"),
                        },
                    },
                    new Link {
                        From = "SM - Wrecked Ship Basement - Top Door",
                        To = new[] {
                            new LinkTarget("SM - Wrecked Ship Basement - Left Door"),
                            new LinkTarget("SM - Wrecked Ship Basement - Right Door", new[] {
                                new Strat { Requires = null, /*["h_canPassBombPassages"]*/ },
                                // The speedball is more complicated because of the robot standing
                                // in the way.
                                new Strat {
                                    Name = "Basement Speedball (Phantoon Alive)",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canMockball",
                                    //  {"canShineCharge": {
                                    //    "usedTiles": 25,
                                    //    "shinesparkFrames": 0,
                                    //    "openEnd": 0
                                    //  }}
                                    //]
                                },
                                // An easier version of the speedball, since you can push the
                                // robots all the way left. It's even possible to setup the short
                                // hop mockball by bonking the center platform.
                                new Strat {
                                    Name = "Basement Speedball (Phantoon Dead)",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canMockball",
                                    //  "f_DefeatedPhantoon",
                                    //  {"canShineCharge": {
                                    //    "usedTiles": 33,
                                    //    "shinesparkFrames": 0,
                                    //    "openEnd": 2
                                    //  }}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Wrecked Ship Basement - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Wrecked Ship Basement - Top Door", new[] {
                                new Strat { Requires = null /*["h_canPassBombPassages"]*/ },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Wrecked Ship Basement - Atomics",
                        EnemyName = "Atomic",
                        Quantity = 3,
                        HomeNodes = new[] {
                            "SM - Wrecked Ship Basement - Left Door",
                            "SM - Wrecked Ship Basement - Top Door",
                        },
                        Spawn = null, // ["f_DefeatedPhantoon"]
                    },
                    new Enemy {
                        GroupName = "SM - Wrecked Ship Basement - Workrobots",
                        EnemyName = "Workrobot",
                        Quantity = 2,
                        HomeNodes = new[] {
                            "SM - Wrecked Ship Basement - Left Door",
                            "SM - Wrecked Ship Basement - Top Door",
                        },
                        Spawn = null, // ["f_DefeatedPhantoon"]
                    },
                },
            },
            #endregion
            #region Wrecked Ship Map Room
            new Room {
                Name = "SM - Wrecked Ship Map Room",
                Layout = Room.LayoutFrom(@"
                      X←1"
                    , "SM - Wrecked Ship Map Room - Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Wrecked Ship Map Room - Door",
                        Type = TransitionType.Blue,
                        Runways = new [] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Utility {
                        Name = "SM - Wrecked Ship Map Room - Map Station",
                        Type = UtilityType.Map,
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Wrecked Ship Map Room - Station Lock",
                                Type = LockType.GameFlag,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["f_DefeatedPhantoon"]*/ },
                                },
                            },
                        },
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Wrecked Ship Map Room - Door",
                        To = new[] {
                            new LinkTarget("SM - Wrecked Ship Map Room - Map Station"),
                        },
                    },
                    new Link {
                        From = "SM - Wrecked Ship Map Room - Map Station",
                        To = new[] {
                            new LinkTarget("SM - Wrecked Ship Map Room - Door"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Wrecked Ship Map Room - Covern",
                        EnemyName = "Covern",
                        Quantity = 1,
                        HomeNodes = new[] {
                            "SM - Wrecked Ship Map Room - Door",
                            "SM - Wrecked Ship Map Room - Map Station",
                        },
                        StopSpawn = null, // ["f_DefeatedPhantoon"]
                    }
                },
            },
            #endregion
            #region Phantoon's Room
            new Room {
                Name = "SM - Phantoon's Room",
                Layout = Room.LayoutFrom(@"
                      1→X"
                    , "SM - Phantoon's Room - Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Phantoon's Room - Door",
                        Type = TransitionType.Gray,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 0,
                                OpenEnd = 1,
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Phantoon's Room - Grey Lock",
                                Type = LockType.GameFlag,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["f_DefeatedPhantoon"]*/ },
                                },
                            },
                        },
                    },
                    new Event {
                        Name = "SM - Phantoon's Room - Phantoon",
                        Type = EventType.Boss,
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Phantoon's Room - Phantoon Fight",
                                Type = LockType.BossFight,
                                UnlockStrats = new[] {
                                    // The strat for Charge-based weapons.
                                    new Strat {
                                        Name = "Regular Phantoon",
                                        Requires = null,
                                        //{"enemyKill": {
                                        //  "enemies": [
                                        //    ["Phantoon"]
                                        //  ],
                                        //  "excludedWeapons": ["Super"],
                                        //  "farmableAmmo": ["Missile"]
                                        //}}
                                    },
                                    new Strat {
                                        Name = "Nintendo Power Phantoon",
                                        Requires = null,
                                        //{"enemyKill": {
                                        //  "enemies": [
                                        //    ["Phantoon"]
                                        //  ],
                                        //  "explicitWeapons": ["Super"],
                                        //  "farmableAmmo": ["Super"]
                                        //}}
                                    },
                                },
                            },
                        },
                        Yields = new[] { "f_DefeatedPhantoon" },
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Phantoon's Room - Door",
                        To = new[] {
                            new LinkTarget("SM - Phantoon's Room - Phantoon"),
                        },
                    },
                    new Link {
                        From = "SM - Phantoon's Room - Phantoon",
                        To = new[] {
                            new LinkTarget("SM - Phantoon's Room - Door"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "Phantoon",
                        EnemyName = "Phantoon",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Phantoon's Room - Phantoon" },
                        StopSpawn = null, // ["f_DefeatedPhantoon"]
                    }
                },
            },
            #endregion
            // Todo: Acceptable name?
            #region Electric Closet
            new Room {
                Name = "SM - Electric Closet",
                Layout = Room.LayoutFrom(@"
                      X←1"
                    , "SM - Electric Closet - Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Electric Closet - Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 2,
                                OpenEnd = 1,
                                UsableComingIn = false,
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - Electric Closet - Item",
                        Type = PlacementType.Visible,
                        Locks = new[] {
                            // The item doesn't spawn until Phantoon is defeated.
                            new Lock {
                                Name = "SM - Electric Closet - Item Spawn Lock",
                                Type = LockType.GameFlag,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["f_DefeatedPhantoon"]*/ },
                                },
                            },
                        },
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Electric Closet - Door",
                        To = new[] {
                            new LinkTarget("SM - Electric Closet - Item"),
                        },
                    },
                    new Link {
                        From = "SM - Electric Closet - Item",
                        To = new[] {
                            new LinkTarget("SM - Electric Closet - Door"),
                        },
                    },
                },
            },
            #endregion
            #region Attic
            new Room {
                Name = "SM - Attic",
                Layout = Room.LayoutFrom(@"
                      1→XXXXXXX←2
                            ↑
                            3"
                    , "SM - Attic - Left Door"
                    , "SM - Attic - Right Door"
                    , "SM - Attic - Bottom Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Attic - Left Door",
                        Type = TransitionType.Gray,
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
                                FramesRemaining = 0,
                                ShinesparkFrames = 80,
                                OpenEnd = 2,
                            },
                        },
                        Locks = new[] {
                            // The enemies are killable using Power Beam, once they actually spawn.
                            new Lock {
                                Name = "SM - Attic - Left Grey Lock",
                                Type = LockType.KillEnemies,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["f_DefeatedPhantoon"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Attic - Right Door",
                        Type = TransitionType.Gray,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 16,
                                SteepUpTiles = 4,
                                OpenEnd = 0,
                            },
                        },
                        CanLeaveCharged = new[] {
                            new RunwayCharge {
                                Length = 33,
                                OpenEnd = 2,
                                FramesRemaining = 30,
                            },
                        },
                        Locks = new[] {
                            // The enemies are killable using Power Beam, once they actually spawn.
                            new Lock {
                                Name = "SM - Attic - Right Grey Lock",
                                Type = LockType.KillEnemies,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["f_DefeatedPhantoon"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Attic - Bottom Door",
                        Type = TransitionType.Blue,
                        CanLeaveCharged = new[] {
                            new RunwayCharge {
                                Length = 33,
                                OpenEnd = 2,
                                FramesRemaining = 60,
                            },
                        },
                        Locks = new[] {
                            // The enemies are killable using Power Beam, once they actually spawn.
                            // Todo: Why is defeat on `Active` here instead of `UnlockStrats`?
                            new Lock {
                                Name = "SM - Attic - Bottom Grey Lock",
                                Type = LockType.KillEnemies,
                                Active = null, // ["f_DefeatedPhantoon"]
                            },
                        },
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Attic - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Attic - Bottom Door"),
                        },
                    },
                    new Link {
                        From = "SM - Attic - Bottom Door",
                        To = new[] {
                            new LinkTarget("SM - Attic - Left Door"),
                            new LinkTarget("SM - Attic - Right Door"),
                        },
                    },
                    new Link {
                        From = "SM - Attic - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Attic - Bottom Door"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Attic - Covern",
                        EnemyName = "Covern",
                        Quantity = 1,
                        HomeNodes = new[] {
                            "SM - Attic - Left Door",
                            "SM - Attic - Right Door",
                            "SM - Attic - Bottom Door",
                        },
                        StopSpawn = null, // ["f_DefeatedPhantoon"]
                    },
                    new Enemy {
                        GroupName = "SM - Attic - Trapped Atomics",
                        EnemyName = "Trapped Atomic",
                        Quantity = 9,
                        HomeNodes = new[] {
                            "SM - Attic - Left Door",
                            "SM - Attic - Right Door",
                            "SM - Attic - Bottom Door",
                        },
                        StopSpawn = null, // ["f_DefeatedPhantoon"]
                    },
                    new Enemy {
                        GroupName = "SM - Attic - Atomics",
                        EnemyName = "Atomic",
                        Quantity = 4,
                        HomeNodes = new[] {
                            "SM - Attic - Left Door",
                            "SM - Attic - Right Door",
                            "SM - Attic - Bottom Door",
                        },
                        Spawn = null, // ["f_DefeatedPhantoon"]
                    },
                    new Enemy {
                        GroupName = "SM - Attic - Kihunters",
                        EnemyName = "Kihunter (yellow)",
                        Quantity = 4,
                        HomeNodes = new[] {
                            "SM - Attic - Left Door",
                            "SM - Attic - Right Door",
                            "SM - Attic - Bottom Door",
                        },
                        Spawn = null, // ["f_DefeatedPhantoon"]
                    },
                },
            },
            #endregion
            #region Bowling Alley
            new Room {
                Name = "SM - Bowling Alley",
                Layout = Room.LayoutFrom(@"
                        3→XXXX
                      2→XXXXXX
                      1→XXXXXX"
                    , "SM - Bowling Alley - Bottom Left Door"
                    , "SM - Bowling Alley - Middle Left Door"
                    , "SM - Bowling Alley - Top Left Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Bowling Alley - Bottom Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 0,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Bowling Alley - Middle Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 2,
                                OpenEnd = 1,
                                UsableComingIn = false,
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Bowling Alley - Top Left Grey Lock",
                                Type = LockType.Permanent,
                                Active = null, // ["f_DefeatedPhantoon"]
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["never"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Bowling Alley - Top Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 33,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - Bowling Alley - Chozo Item",
                        Type = PlacementType.Chozo,
                        Locks = new[] {
                            // The item doesn't spawn until Phantoon is defeated.
                            new Lock {
                                Name = "SM - Bowling Alley - Chozo Item Spawn Lock",
                                Type = LockType.GameFlag,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["f_DefeatedPhantoon"]*/ },
                                },
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - Bowling Alley - Top Item",
                        Type = PlacementType.Visible,
                        Locks = new[] {
                            // The item doesn't spawn until Phantoon is defeated.
                            new Lock {
                                Name = "SM - Bowling Alley - Top Item Spawn Lock",
                                Type = LockType.GameFlag,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["f_DefeatedPhantoon"]*/ },
                                },
                            },
                        },
                    },
                    new Junction {
                        Name = "SM - Bowling Alley - Bowling Statue",
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Bowling Alley - Top Left Door",
                        To = Empty<LinkTarget>.List,
                    },
                    new Link {
                        From = "SM - Bowling Alley - Middle Left Door",
                        To = new[] {
                            // It's one-way because there's no logical reason to go to the statue
                            // and back out to the door.
                            new LinkTarget("SM - Bowling Alley - Bowling Statue", new[] {
                                new Strat { Requires = null /*["Grapple"]*/ },
                                new Strat { Requires = null /*["SpaceJump"]*/ },
                                // This is doable even without any momentum from a previous room,
                                // but pretty tight.
                                new Strat {
                                    Name = "2-hit Bowling",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canIframeSpikeJump",
                                    //  {"spikeHits": 2}
                                    //]
                                },
                                // A bit easier than 2-hit bowling.
                                new Strat {
                                    Name = "2-hit Speed Bowling",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canIframeSpikeJump",
                                    //  "SpeedBooster",
                                    //  { "spikeHits": 2}
                                    //]
                                },
                                new Strat {
                                    Name = "3-hit Bowling",
                                    Requires = null,
                                    //[ "canIframeSpikeJump",
                                    //  { "spikeHits": 3}
                                    //]
                                },
                                // Should we have this one if you're not assumed to know the layout?
                                // You can't go out of the room to set it up once you see what room
                                // it is. But then again, it'd be a softlock either way if you have
                                // no way through.
                                new Strat {
                                    Name = "Shinespark",
                                    Requires = null,
                                    //{"canComeInCharged": {
                                    //  "fromNode": 2,
                                    //  "framesRemaining": 0,
                                    //  "shinesparkFrames": 90
                                    //}}
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Bowling Alley - Bottom Left Door",
                        To = new[] {
                            new LinkTarget("SM - Bowling Alley - Chozo Item", new[] {
                                // If using PBs, doable with just one by placing it far enough right.
                                new Strat {
                                    Name = "Bomb the blocks",
                                    Requires = null, // ["h_canPassBombPassages"]
                                },
                                // The shot blocks can be broken with Wave by scrolling the screen
                                // right then coming back out of the tunnel and walking right.
                                new Strat {
                                    Name = "Wave Screw",
                                    Requires = null,
                                    //[ "Wave",
                                    //  "ScrewAttack"
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Bowling Alley - Chozo Item",
                        To = new[] {
                            new LinkTarget("SM - Bowling Alley - Bottom Left Door", new[] {
                                // Those bomb blocks respawn. They must be broken on the way back too.
                                new Strat { Requires = null /*["h_canPassBombPassages"]*/ },
                            }),
                            new LinkTarget("SM - Bowling Alley - Top Item", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ {"canShineCharge": {
                                    //    "usedTiles": 33,
                                    //    "shinesparkFrames": 40,
                                    //    "openEnd": 2
                                    //  }},
                                    //  "h_canUsePowerBombs"
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Bowling Alley - Top Item",
                        To = new[] {
                            // No requirements, on the basis that the PB blocks must be destroyed
                            // to reach the Top Item in the first place.
                            new LinkTarget("SM - Bowling Alley - Chozo Item"),
                        },
                    },
                    new Link {
                        From = "SM - Bowling Alley - Bowling Statue",
                        To = new[] {
                            new LinkTarget("SM - Bowling Alley - Bottom Left Door", new[] {
                                new Strat {
                                    Name = "Bowling!",
                                    Requires = null,
                                    //[ "f_DefeatedPhantoon",
                                    //  "Morph"
                                    //]
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Bowling Alley - Workrobots",
                        EnemyName = "Workrobot",
                        Quantity = 2,
                        BetweenNodes = new[] {
                            "SM - Bowling Alley - Bottom Left Door",
                            "SM - Bowling Alley - Chozo Item",
                        },
                        Spawn = null, // ["f_DefeatedPhantoon"]
                    }
                },
            },
            #endregion
            // Todo: Acceptable name?
            #region Air Lock
            new Room {
                Name = "SM - Air Lock",
                Layout = Room.LayoutFrom(@"
                      1→X←2"
                    , "SM - Air Lock - Left Door"
                    , "SM - Air Lock - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Air Lock - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 12,
                                OpenEnd = 0,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Air Lock - Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 12,
                                OpenEnd = 0,
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - Air Lock - Item",
                        Type = PlacementType.Visible,
                        Locks = new[] {
                            // The item doesn't spawn until Phantoon is defeated.
                            new Lock {
                                Name = "SM - Air Lock - Item Spawn Lock",
                                Type = LockType.GameFlag,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["f_DefeatedPhantoon"]*/ },
                                },
                            },
                        },
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Air Lock - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Air Lock - Item"),
                        },
                    },
                    new Link {
                        From = "SM - Air Lock - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Air Lock - Item"),
                        },
                    },
                    new Link {
                        From = "SM - Air Lock - Item",
                        To = new[] {
                            new LinkTarget("SM - Air Lock - Left Door"),
                            // Todo: This one leads to itself in the original data. Typo, right?
                            new LinkTarget("SM - Air Lock - Right Door"),
                        },
                    },
                },
            },
            #endregion
            // Todo: As advocated by Crossproduct. Acceptable name?
            #region Reactor Room
            new Room {
                Name = "SM - Reactor Room",
                Layout = Room.LayoutFrom(@"
                      1→XXXX"
                    , "SM - Reactor Room - Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Reactor Room - Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            // The actual length is 4.5. Got halfwidth blocks.
                            new RunwayDash {
                                Length = 4,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - Reactor Room - Item",
                        Type = PlacementType.Visible,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Reactor Room - Door",
                        To = new[] {
                            new LinkTarget("SM - Reactor Room - Item", new[] {
                                // The path can't be passed unless the Workrobot is activated (so
                                // Phantoon dead).
                                new Strat {
                                    Requires = null,
                                    //[ "Morph",
                                    //  "h_canDestroyBombWalls",
                                    //  "f_DefeatedPhantoon"
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Reactor Room - Item",
                        To = new[] {
                            new LinkTarget("SM - Reactor Room - Door", new[] {
                                // The path can't be passed unless the Workrobot is activated (so
                                // Phantoon dead)". This doesn't require breaking the bomb blocks
                                // on the premise that you can't here without breaking them.
                                new Strat {
                                    Requires = null,
                                    //[ "Morph",
                                    //  "f_DefeatedPhantoon"
                                    //]
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Reactor Room - Covern",
                        EnemyName = "Covern",
                        Quantity = 1,
                        HomeNodes = new[] {
                            "SM - Reactor Room - Door",
                            "SM - Reactor Room - Item",
                        },
                        StopSpawn = null, // ["f_DefeatedPhantoon"]
                    },
                    new Enemy {
                        GroupName = "SM - Reactor Room - Bulls",
                        EnemyName = "Bull",
                        Quantity = 2,
                        HomeNodes = new[] { "SM - Reactor Room - Door" },
                        Spawn = null, // ["f_DefeatedPhantoon"]
                    },
                    new Enemy {
                        GroupName = "SM - Reactor Room - Workrobots",
                        EnemyName = "Workrobot",
                        Quantity = 2,
                        HomeNodes = new[] { "SM - Reactor Room - Door" },
                        Spawn = null, // ["f_DefeatedPhantoon"]
                    },
                    new Enemy {
                        GroupName = "SM - Reactor Room - Atomics",
                        EnemyName = "Trapped Atomic",
                        Quantity = 4,
                        HomeNodes = new[] { "SM - Reactor Room - Door" },
                        StopSpawn = null, // ["f_DefeatedPhantoon"]
                    }
                },
            },
            #endregion
            #region Sponge Bath
            new Room {
                Name = "SM - Sponge Bath",
                Layout = Room.LayoutFrom(@"
                      1→XX←2"
                    , "SM - Sponge Bath - Left Door"
                    , "SM - Sponge Bath - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Sponge Bath - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 0,
                            },
                            new RunwayDash {
                                Length = 20,
                                SteepUpTiles = 3,
                                OpenEnd = 0,
                                Strats = new[] {
                                    new Strat { Requires = null /*["Gravity"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Sponge Bath - Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 8,
                                SteepDownTiles = 2,
                                OpenEnd = 1,
                            },
                        },
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Sponge Bath - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Sponge Bath - Right Door", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                new Strat { Requires = null /*["SpaceJump"]*/ },
                                new Strat { Requires = null /*["HiJump"]*/ },
                                // Could be a notable strat, but it already has its own tech.
                                new Strat {
                                    Name = "Bomb Jump",
                                    Requires = null, // ["canBombJumpBreakFree"]
                                },
                                new Strat {
                                    Name = "Midair SpringBall",
                                    Requires = null, // ["canSpringBallJumpMidAir"]
                                },
                                new Strat {
                                    Name = "Shinespark",
                                    Requires = null,
                                    //{"canComeInCharged": {
                                    //  "fromNode": 1,
                                    //  "framesRemaining": 30,
                                    //  "shinesparkFrames": 50
                                    //}}
                                },
                                // A bit finicky for shorter runways, but exactly 3 tiles works.
                                new Strat {
                                    Name = "Exterior Speedjump",
                                    Requires = null,
                                    //[ {"adjacentRunway": {
                                    //    "fromNode": 1,
                                    //    "usedTiles": 3
                                    //  }},
                                    //  "SpeedBooster"
                                    //]
                                },
                                // It doesn't work from flush against the door. Start moving about
                                // half a tile away from it.
                                new Strat {
                                    Name = "Sponge Bath In-Room Speedjump",
                                    Notable = true,
                                    Requires = null, // ["SpeedBooster"]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Sponge Bath - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Sponge Bath - Left Door"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Sponge Bath - Bull",
                        EnemyName = "Bull",
                        Quantity = 1,
                        HomeNodes = new[] {
                            "SM - Sponge Bath - Left Door",
                            "SM - Sponge Bath - Right Door",
                        },
                        Spawn = null, // ["f_DefeatedPhantoon"]
                    }
                },
            },
            #endregion
            #region Spiky Death Room
            new Room {
                Name = "SM - Spiky Death Room",
                Layout = Room.LayoutFrom(@"
                      1→XX←2"
                    , "SM - Spiky Death Room - Left Door"
                    , "SM - Spiky Death Room - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Spiky Death Room - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 0,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Spiky Death Room - Right Door",
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
                        From = "SM - Spiky Death Room - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Spiky Death Room - Right Door", new[] {
                                new Strat {
                                    Name = "Naked Spiky Death Room (Left to Right)",
                                    Notable = true,
                                },
                                // The room is considerably more forgiving with Morph, so this is
                                // there as an alternate strat.
                                new Strat { Requires = null /*["Morph"]*/ },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Spiky Death Room - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Spiky Death Room - Left Door", new[] {
                                new Strat {
                                    Name = "Naked Spiky Death Room (Right to Left)",
                                    Notable = true,
                                },
                                // The room is considerably more forgiving with Morph, so this is
                                // there as an alternate strat.
                                new Strat { Requires = null /*["Morph"]*/ },
                            }),
                        },
                    },
                },
            },
            #endregion
            #region Electric Death Room
            new Room {
                Name = "SM - Electric Death Room",
                Layout = Room.LayoutFrom(@"
                      2→X
                        X←3
                      1→X"
                    , "SM - Electric Death Room - Top Left Door"
                    , "SM - Electric Death Room - Right Door"
                    , "SM - Electric Death Room - Bottom Left Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Electric Death Room - Top Left Door",
                        Type = TransitionType.Red,
                        Runways = new[] {
                            // Actual length is 3.5. Got halfwidth blocks.
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 0,
                            },
                        },
                        Locks = new[] {
                            // Somehow this door is blue, not red, before Phantoon dies.
                            new Lock {
                                Name = "SM - Electric Death Room - Red Lock",
                                Type = LockType.ColoredDoor,
                                Active = null, // ["f_DefeatedPhantoon"]
                                UnlockStrats = new[] {
                                    new Strat { Requires = null, /*["h_canOpenRedDoors"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Electric Death Room - Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 12,
                                SteepUpTiles = 3,
                                OpenEnd = 0,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Electric Death Room - Bottom Left Door",
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
                        From = "SM - Electric Death Room - Top Left Door",
                        To = new[] {
                            new LinkTarget("SM - Electric Death Room - Right Door"),
                        },
                    },
                    new Link {
                        From = "SM - Electric Death Room - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Electric Death Room - Top Left Door"),
                            new LinkTarget("SM - Electric Death Room - Bottom Left Door"),
                        },
                    },
                    new Link {
                        From = "SM - Electric Death Room - Bottom Left Door",
                        To = new[] {
                            new LinkTarget("SM - Electric Death Room - Right Door"),
                        },
                    },
                },
            },
            #endregion
            // Todo: Acceptable name?
            #region Spiky [Fish Tank / Bathtub / Laundry Tub]
            new Room {
                Name = "SM - Spiky Fish Tank",
                Layout = Room.LayoutFrom(@"
                      XXX←1
                      XXX"
                    , "SM - Spiky Fish Tank - Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Spiky Fish Tank - Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            // Run must be synched with the low tide.
                            new RunwayDash {
                                Length = 6,
                                SteepUpTiles = 2,
                                OpenEnd = 0,
                            },
                            new RunwayDash {
                                Length = 7,
                                SteepUpTiles = 2,
                                OpenEnd = 1,
                                Strats = new[] {
                                    new Strat { Requires = null /*["Gravity"]*/ },
                                },
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - Spiky Fish Tank - Item",
                        Type = PlacementType.Chozo,
                        Locks = new[] {
                            // The item doesn't spawn until Phantoon is defeated.
                            new Lock {
                                Name = "SM - Spiky Fish Tank - Item Spawn Lock",
                                Type = LockType.GameFlag,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["f_DefeatedPhantoon"]*/ },
                                },
                            },
                        },
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Spiky Fish Tank - Door",
                        To = new[] {
                            new LinkTarget("SM - Spiky Fish Tank - Item", new[] {
                                // This can be kind of tricky, so it's a notable strat and we have
                                // alternate strats.
                                new Strat {
                                    Name = "Wrecked Ship E-Tank Platforming",
                                    Notable = true,
                                },
                                // From a standstill at the door, jump just before the first stept.
                                // Mid-air mockball and bounce on the first platform. This should
                                // bounce on the third platform and get to the item.
                                new Strat {
                                    Name = "Wrecked Ship E-Tank Spring Ball Bounce",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canMidAirMockball",
                                    //  "h_canUseSpringBall"
                                    //]
                                },
                                new Strat { Requires = null /*["Grapple"]*/ },
                                new Strat {
                                    Name = "Walljumps",
                                    Requires = null, /*["Gravity"]*/
                                },
                                new Strat { Requires = null /*["SpaceJump"]*/ },
                                new Strat {
                                    Name = "Shinespark",
                                    Requires = null,
                                    //{"canComeInCharged": {
                                    //  "fromNode": 1,
                                    //  "framesRemaining": 0,
                                    //  "shinesparkFrames": 58
                                    //}}
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Spiky Fish Tank - Item",
                        To = new[] {
                            // No alternate strat since the only tricky jump is easy on the way back.
                            new LinkTarget("SM - Spiky Fish Tank - Door"),
                        },
                    },
                },
                Enemies = new[] {
                    // Drops can be reached for free using the platforms.
                    new Enemy {
                        GroupName = "SM - Spiky Fish Tank - Skulteras",
                        EnemyName = "Skultera",
                        Quantity = 2,
                        HomeNodes = new[] { "SM - Spiky Fish Tank - Door" },
                        Spawn = null, // ["f_DefeatedPhantoon"]
                    },
                },
            },
            #endregion
            // Todo: Found this name on the speed wiki. Acceptable?
            #region Assembly Line
            new Room {
                Name = "SM - Assembly Line",
                Layout = Room.LayoutFrom(@"
                      1→XXX"
                    , "SM - Assembly Line - Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Assembly Line - Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            // This runway is actually 9 tiles long but got 5 speedblocks, leaving
                            // a buffer.
                            new RunwayDash {
                                Length = 5,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - Assembly Line - Item",
                        Type = PlacementType.Visible,
                        Locks = new[] {
                            // The item doesn't spawn until Phantoon is defeated.
                            new Lock {
                                Name = "SM - Assembly Line - Item Spawn Lock",
                                Type = LockType.GameFlag,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["f_DefeatedPhantoon"]*/ },
                                },
                            },
                        },
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Assembly Line - Door",
                        To = new[] {
                            new LinkTarget("SM - Assembly Line - Item"),
                        },
                    },
                    new Link {
                        From = "SM - Assembly Line - Item",
                        To = new[] {
                            new LinkTarget("SM - Assembly Line - Door"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Assembly Line - Workrobot",
                        EnemyName = "Workrobot",
                        Quantity = 3,
                        HomeNodes = new[] {
                            "SM - Assembly Line - Door",
                            "SM - Assembly Line - Item",
                        },
                        Spawn = null, // ["f_DefeatedPhantoon"]
                    },
                },
            },
            #endregion
            #region Wrecked Ship Save Room
            new Room {
                Name = "SM - Wrecked Ship Save Room",
                Layout = Room.LayoutFrom(@"
                      1→X"
                    , "SM - Wrecked Ship Save Room - Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Wrecked Ship Save Room - Door",
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
                        Name = "SM - Wrecked Ship Save Room - Save Station",
                        Type = UtilityType.Save,
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Wrecked Ship Save Room - Station Lock",
                                Type = LockType.GameFlag,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["f_DefeatedPhantoon"]*/ },
                                },
                            },
                        },
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Wrecked Ship Save Room - Door",
                        To = new[] {
                            new LinkTarget("SM - Wrecked Ship Save Room - Save Station"),
                        },
                    },
                    new Link {
                        From = "SM - Wrecked Ship Save Room - Save Station",
                        To = new[] {
                            new LinkTarget("SM - Wrecked Ship Save Room - Door"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Wrecked Ship Save Room - Covern",
                        EnemyName = "Covern",
                        Quantity = 1,
                        HomeNodes = new[] {
                            "SM - Wrecked Ship Save Room - Door",
                            "SM - Wrecked Ship Save Room - Save Station",
                        },
                        StopSpawn = null, // ["f_DefeatedPhantoon"]
                    }
                },
            },
            #endregion
        };

    }

}
