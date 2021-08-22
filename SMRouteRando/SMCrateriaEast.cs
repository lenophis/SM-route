using System.Collections.Generic;

namespace SMRouteRando {

    public class SMCrateriaEast {

        public static IList<Room> Rooms { get; } = new[] {
            #region The Moat
            new Room {
                Name = "SM - The Moat",
                Layout = Room.LayoutFrom(@"
                      1→XX←2
                        XX"
                    , "SM - The Moat - Left Door"
                    , "SM - The Moat - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - The Moat - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new [] {
                            new RunwayDash {
                                Length = 2,
                                SteepUpTiles = 1,
                                OpenEnd = 1,
                                UsableComingIn = false,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - The Moat - Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 4,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - The Moat - Item",
                        Type = PlacementType.Visible,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - The Moat - Left Door",
                        To = new[] {
                            new LinkTarget("SM - The Moat - Item"),
                        },
                    },
                    new Link {
                        From = "SM - The Moat - Right Door",
                        To = new[] {
                            new LinkTarget("SM - The Moat - Item", new[] {
                                new Strat { Requires = null /*["Grapple"]*/ },
                                new Strat { Requires = null /*["SpaceJump"]*/ },
                                // In reality, bombs lead to 1 and not 3, but 1->3 and 3->1 are
                                // free so it doesn't matter.
                                new Strat {
                                    Name = "Pass Below",
                                    Requires = null, // ["h_canPassBombPassages"]
                                },
                                new Strat { Requires = null /*["Gravity"]*/ },
                                // Execution of this strat is non-trivial, and failing will lead to
                                // falling into the pit. Depending on item loadout, that could be a
                                // softlock.
                                new Strat {
                                    Name = "Moat Reverse Jump",
                                    Notable = true,
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - The Moat - Item",
                        To = new[] {
                            new LinkTarget("SM - The Moat - Left Door"),
                            // Because Moving from Left Door to Item is free, all strats are
                            // represented here even if they start at Left Door.
                            new LinkTarget("SM - The Moat - Right Door", new[] {
                                new Strat { Requires = null /*["Grapple"]*/ },
                                new Strat { Requires = null /*["SpaceJump"]*/ },
                                new Strat {
                                    Name = "Gravity with Jump Assist",
                                    Requires = null,
                                    //[ "Gravity",
                                    //  {"or": [
                                    //    "HiJump",
                                    //    "canSpringBallJumpMidAir"
                                    //  ]}
                                    //]
                                },
                                new Strat {
                                    Name = "IBJ",
                                    Requires = null,
                                    //[ "Gravity",
                                    //  "canIBJ"
                                    //]
                                },
                                new Strat { Requires = null /*["canGravityJump"]*/ },
                                new Strat {
                                    Name = "Shinespark",
                                    Requires = null,
                                    //{"canComeInCharged": {
                                    //  "fromNode": 1,
                                    //  "inRoomPath": [1, 3],
                                    //  "framesRemaining": 0,
                                    //  "shinesparkFrames": 50
                                    //}}
                                },
                                new Strat {
                                    Name = "Moat SpringBall Jump",
                                    Notable = true,
                                    Requires = null, // ["canSpringBallJump"]
                                },
                                new Strat {
                                    Name = "Moat Continuous Walljump",
                                    Notable = true,
                                    Requires = null, // ["canCWJ"]
                                },
                                new Strat {
                                    Name = "Moat Horizontal Bomb Jump",
                                    Notable = true,
                                    Requires = null, // ["canDoubleHBJ"]
                                },
                            }),
                        },
                    },
                },
            },
            #endregion
            #region Crateria Kihunter Room
            new Room {
                Name = "SM - Crateria Kihunter Room",
                Layout = Room.LayoutFrom(@"
                      1→XXX←2
                         X
                         X
                         ↑
                         3"
                    , "SM - Crateria Kihunter Room - Left Door"
                    , "SM - Crateria Kihunter Room - Right Door"
                    , "SM - Crateria Kihunter Room - Bottom Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Crateria Kihunter Room - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 33,
                                OpenEnd = 0,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Crateria Kihunter Room - Right Door",
                        Type = TransitionType.Yellow,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 1,
                            },
                        },
                        CanLeaveCharged = new[] {
                            new RunwayCharge {
                                Length = 33,
                                FramesRemaining = 60,
                                OpenEnd = 0,
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Crateria Kihunter Room - Right Yellow Lock",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenYellowDoors"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Crateria Kihunter Room - Bottom Door",
                        Type = TransitionType.Yellow,
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Crateria Kihunter Room - Bottom Yellow Lock",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenYellowDoors"]*/ },
                                },
                            },
                        },
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Crateria Kihunter Room - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Crateria Kihunter Room - Right Door"),
                        },
                    },
                    new Link {
                        From = "SM - Crateria Kihunter Room - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Crateria Kihunter Room - Left Door"),
                            new LinkTarget("SM - Crateria Kihunter Room - Bottom Door"),
                        },
                    },
                    new Link {
                        From = "SM - Crateria Kihunter Room - Bottom Door",
                        To = new[] {
                            new LinkTarget("SM - Crateria Kihunter Room - Right Door"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Crateria Kihunter Room - Kihunters",
                        EnemyName = "Kihunter (green)",
                        Quantity = 2,
                        HomeNodes = new[] {
                            "SM - Crateria Kihunter Room - Left Door",
                            "SM - Crateria Kihunter Room - Right Door",
                        },
                    },
                    new Enemy {
                        GroupName = "SM - Crateria Kihunter Room - Scisers",
                        EnemyName = "Sciser",
                        Quantity = 2,
                        HomeNodes = new[] { "SM - Crateria Kihunter Room - Bottom Door" },
                    },
                },
            },
            #endregion
            #region Crateria East Elevator Room A
            new Room {
                Name = "SM - Crateria East Elevator Room A",
                Layout = Room.LayoutFrom(@"
                      1
                      ↓
                      X
                      ↑
                      2"
                    , "SM - Crateria East Elevator Room A - Top Door"
                    , "SM - Crateria East Elevator Room A - Elevator"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Crateria East Elevator Room A - Top Door",
                        Type = TransitionType.Yellow,
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Crateria East Elevator Room A - Yellow Lock",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenYellowDoors"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Crateria East Elevator Room A - Elevator",
                        Type = TransitionType.Elevator,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Crateria East Elevator Room A - Top Door",
                        To = new[] {
                            new LinkTarget("SM - Crateria East Elevator Room A - Elevator"),
                        },
                    },
                    new Link {
                        From = "SM - Crateria East Elevator Room A - Elevator",
                        To = new[] {
                            new LinkTarget("SM - Crateria East Elevator Room A - Top Door"),
                        },
                    },
                },
            },
            #endregion
            #region West Ocean
            // The section between Bowling Alley Path and Bowling Alley is excluded from West Ocean
            // and considered as its own room instead (Homing Geemer Room).
            new Room {
                Name = "SM - West Ocean",
                Layout = Room.LayoutFrom(@"
                        XXXXXXXX←2
                        XXXXXXXX←3
                        XXX←4
                        XXXXXX←5
                      1→XXXXXXXX←6
                        XXXXXXXX"
                    , "SM - West Ocean - Left Door"
                    , "SM - West Ocean - Top Right Door"
                    , "SM - West Ocean - Middle Top Right Door"
                    , "SM - West Ocean - Center Right Door"
                    , "SM - West Ocean - Middle Bottom Right Door"
                    , "SM - West Ocean - Bottom Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - West Ocean - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 23,
                                SteepUpTiles = 6,
                                SteepDownTiles = 1,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - West Ocean - Top Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 6,
                                SteepUpTiles = 1,
                                OpenEnd = 1,
                            },
                        },
                        CanLeaveCharged = new[] {
                            new RunwayCharge {
                                Length = 32,
                                FramesRemaining = 25,
                                OpenEnd = 1,
                                Strats = new[] {
                                    // Charge near Middle Top Right Door and use HiJump to get up quickly.
                                    new Strat {
                                        Name = "SM - West Ocean - Top Right Charge Out",
                                        Notable = true,
                                        Requires = null, // ["HiJump"]
                                    },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - West Ocean - Middle Top Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 32,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - West Ocean - Center Right Door",
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
                        Name = "SM - West Ocean - Middle Bottom Right Door",
                        Type = TransitionType.Gray,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 0,
                                OpenEnd = 1,
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - West Ocean - Ship Exit Grey Lock",
                                Type = LockType.Permanent,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["never"]*/ },
                                },
                                BypassStrats = new[] {
                                    new Strat {
                                        // 1- Grapple on a ripper to get position inside the wall under the door.
                                        // 2- Do a Crystal Flash to force a standup.
                                        // 3- X-Ray climb up to the door trigger.
                                        Name = "Bowling Skip",
                                        Notable = true,
                                        Requires = null,
                                        //[ "canCrystalFlashForceStandup",
                                        //  "canXRayClimb",
                                        //  "canGrappleClip"
                                        //]
                                    },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - West Ocean - Bottom Right Door",
                        Type = TransitionType.Green,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 8,
                                SteepUpTiles = 2,
                                OpenEnd = 1,
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - West Ocean - Green Lock",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenGreenDoors"]*/ },
                                },
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - West Ocean - Top Item",
                        Type = PlacementType.Hidden,
                    },
                    new Placement {
                        Name = "SM - West Ocean - Middle Item",
                        Type = PlacementType.Visible,
                    },
                    new Placement {
                        Name = "SM - West Ocean - Bottom Item",
                        Type = PlacementType.Visible,
                    },
                    new Junction {
                        Name = "SM - West Ocean - Top Junction",
                    },
                    new Junction {
                        Name = "SM - West Ocean - Crawl Maze Junction",
                    },
                    new Junction {
                        Name = "SM - West Ocean - Bottom Junction",
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - West Ocean - Left Door",
                        To = new[] {
                            new LinkTarget("SM - West Ocean - Bottom Junction"),
                        },
                    },
                    new Link {
                        From = "SM - West Ocean - Top Right Door",
                        To = new[] {
                            new LinkTarget("SM - West Ocean - Top Junction"),
                        },
                    },
                    new Link {
                        From = "SM - West Ocean - Middle Top Right Door",
                        To = new[] {
                            new LinkTarget("SM - West Ocean - Top Junction"),
                        },
                    },
                    new Link {
                        From = "SM - West Ocean - Middle Bottom Right Door",
                        To = new[] {
                            new LinkTarget("SM - West Ocean - Bottom Right Door"),
                        },
                    },
                    new Link {
                        From = "SM - West Ocean - Bottom Right Door",
                        To = new[] {
                            new LinkTarget("SM - West Ocean - Middle Bottom Right Door"),
                            new LinkTarget("SM - West Ocean - Bottom Junction"),
                        },
                    },
                    new Link {
                        From = "SM - West Ocean - Center Right Door",
                        To = new[] {
                            new LinkTarget("SM - West Ocean - Top Junction", new[] {
                                // The shot blocks can be destroyed without using bombs.
                                new Strat {
                                    Requires = null,
                                    //{"or": [
                                    //  "h_canPassBombPassages",
                                    //  "h_canUseSpringBall"
                                    //]}
                                },
                                // Get a Zeb to move left into the morph passage, and reach the end
                                // of the tunnel before it. Must be quick enough to shoot the shot
                                // block first, but certainly doable with a mockball. One might
                                // break the shot block beforehand with Wave, but getting into the
                                // tunnel quick enough without mockball still doesn't seem
                                // realistic. This strat is a one-shot try and failure is a
                                // softlock.
                                new Strat {
                                    Name = "West Ocean Bug Boost",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canDamageBoost",
                                    //  "canMockball"
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - West Ocean - Top Item",
                        To = new[] {
                            new LinkTarget("SM - West Ocean - Top Junction"),
                        },
                    },
                    new Link {
                        From = "SM - West Ocean - Middle Item",
                        To = new[] {
                            new LinkTarget("SM - West Ocean - Crawl Maze Junction", new[] {
                                new Strat { Requires = null /*["Morph"]*/ },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - West Ocean - Bottom Item",
                        To = new[] {
                            new LinkTarget("SM - West Ocean - Bottom Junction", new[] {
                                // The shot blocks can be hit from afar without bombs, and there is
                                // enough time to get past them without Gravity before they respawn.
                                new Strat { Requires = null /*["Morph"]*/ },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - West Ocean - Top Junction",
                        To = new[] {
                            new LinkTarget("SM - West Ocean - Top Right Door"),
                            new LinkTarget("SM - West Ocean - Middle Top Right Door"),
                            new LinkTarget("SM - West Ocean - Center Right Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //{"or": [
                                    //  "h_canPassBombPassages",
                                    //  "h_canUseSpringBall"
                                    //]}
                                },
                            }),
                            // It's horribly time-consuming, but this can be attained without any
                            // items or techs.
                            new LinkTarget("SM - West Ocean - Top Item"),
                            new LinkTarget("SM - West Ocean - Crawl Maze Junction", new[] {
                                // Super is for a Super Block. It's not an obstacle because it respawns.
                                new Strat {
                                    Requires = null,
                                    //[ "Super",
                                    //  {"ammo": {
                                    //    "type": "Super",
                                    //    "count": 1
                                    //  }}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - West Ocean - Bottom Junction",
                        To = new[] {
                            new LinkTarget("SM - West Ocean - Left Door"),
                            new LinkTarget("SM - West Ocean - Bottom Right Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //{"or":[
                                    //  "SpaceJump",
                                    //  "Grapple",
                                    //  "Gravity"
                                    //]}
                                },
                                new Strat {
                                    Name = "Shinespark",
                                    Requires = null,
                                    //{"or":[
                                    //  {"canComeInCharged": {
                                    //    "fromNode": 1,
                                    //    "framesRemaining": 0,
                                    //    "shinesparkFrames": 146
                                    //  }},
                                    //  {"canComeInCharged": {
                                    //    "fromNode": 1,
                                    //    "framesRemaining": 180,
                                    //    "shinesparkFrames": 105
                                    //  }}
                                    //]}
                                },
                                new Strat {
                                    Name = "West Ocean Precise Jumps",
                                    Notable = true,
                                },
                            }),
                            new LinkTarget("SM - West Ocean - Bottom Item", new[] {
                                new Strat { Requires = null /*["Morph"]*/ },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - West Ocean - Crawl Maze Junction",
                        To = new[] {
                            new LinkTarget("SM - West Ocean - Middle Item", new[] {
                                new Strat { Requires = null /*["Morph"]*/ },
                            }),
                            new LinkTarget("SM - West Ocean - Top Junction", new[] {
                                // Super is for a Super Block. It's not an obstacle because it
                                // respawns.
                                new Strat {
                                    Requires = null,
                                    //[ "Super",
                                    //  {"ammo": {
                                    //    "type": "Super",
                                    //    "count": 1
                                    //  }}
                                    //]
                                },
                                // It's possible to go Top Junction -> Crawl Maze Junction ->
                                // Middle Item -> Crawl Maze Junction -> Top Junction before the
                                // Super block respawns, if going quick enough. Note that this
                                // representation of the strat would need to be reworked if there
                                // were another way to access Crawl Maze Junction or Middle Item.
                                new Strat {
                                    Name = "Beat West Ocean Super Block Respawn",
                                    Notable = true,
                                },
                            }),
                            new LinkTarget("SM - West Ocean - Bottom Junction", new[] {
                                new Strat { Requires = null /*["Morph"]*/ },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - West Ocean - Zeb",
                        EnemyName = "Zeb",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - West Ocean - Center Right Door" },
                        FarmCycles = new[] {
                            new FarmCycle {
                                Name = "Crouch over spawn point",
                                CycleFrames = 120,
                            },
                        },
                    },
                    new Enemy {
                        GroupName = "SM - West Ocean - Trippers",
                        EnemyName = "Tripper",
                        Quantity = 3,
                        HomeNodes = new[] { "SM - West Ocean - Top Junction" },
                    },
                    new Enemy {
                        GroupName = "SM - West Ocean - Ripper 2",
                        EnemyName = "Ripper 2 (green)",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - West Ocean - Bottom Junction" },
                    },
                    new Enemy {
                        GroupName = "SM - West Ocean - Skulteras",
                        EnemyName = "Skultera",
                        Quantity = 2,
                        HomeNodes = new[] { "SM - West Ocean - Bottom Junction" },
                    },
                },
            },
            #endregion
            #region Bowling Alley Path
            new Room {
                Name = "SM - Bowling Alley Path",
                Layout = Room.LayoutFrom(@"
                      1→XX←2"
                    , "SM - Bowling Alley Path - Left Door"
                    , "SM - Bowling Alley Path - RightDoor"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Bowling Alley Path - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 2,
                                OpenEnd = 0,
                            },
                            // This longer runway requires starting in the water.
                            new RunwayDash {
                                Length = 4,
                                SteepUpTiles = 2,
                                OpenEnd = 1,
                                Strats = new[] {
                                    new Strat { Requires = null /*["Gravity"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Bowling Alley Path - Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 6,
                                OpenEnd = 0,
                            },
                            // This longer runway requires starting in the water.
                            new RunwayDash {
                                Length = 8,
                                SteepUpTiles = 2,
                                OpenEnd = 1,
                                Strats = new[] {
                                    new Strat { Requires = null /*["Gravity"]*/ },
                                },
                            },
                        },
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Bowling Alley Path - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Bowling Alley Path - Right Door"),
                        },
                    },
                    new Link {
                        From = "SM - Bowling Alley Path - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Bowling Alley Path - Left Door"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Bowling Alley Path - Wavers",
                        EnemyName = "Waver",
                        Quantity = 3,
                        HomeNodes = new[] {
                            "SM - Bowling Alley Path - Left Door",
                            "SM - Bowling Alley Path - Right Door",
                        },
                    },
                    new Enemy {
                        GroupName = "SM - Bowling Alley Path - Choots",
                        EnemyName = "Choot",
                        Quantity = 3,
                        HomeNodes = new[] { "SM - Bowling Alley Path - Left Door" },
                    }
},
            },
            #endregion
            #region East Ocean
            new Room {
                Name = "SM - East Ocean",
                Layout = Room.LayoutFrom(@"
                      1→XXXXXXX←2
                        XXXXXXX"
                    , "SM - East Ocean - Left Door"
                    , "SM - East Ocean - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - East Ocean - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 7,
                                SteepUpTiles = 1,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - East Ocean - Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 4,
                                SteepUpTiles = 1,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Junction {
                        Name = "SM - East Ocean - Main Junction",
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - East Ocean - Left Door",
                        To = new[] {
                            // The way out has requirements, in both directions. Following this can
                            // be a softlock.
                            new LinkTarget("SM - East Ocean - Main Junction"),
                        },
                    },
                    new Link {
                        From = "SM - East Ocean - Right Door",
                        To = new[] {
                            // The way out has requirements, in both directions. Following this can
                            // be a softlock.
                            new LinkTarget("SM - East Ocean - Main Junction"),
                        },
                    },
                    new Link {
                        From = "SM - East Ocean - Main Junction",
                        To = new[] {
                            new LinkTarget("SM - East Ocean - Left Door", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                new Strat {
                                    Name = "Suitless",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  {"or": [
                                    //    "HiJump",
                                    //    "canSpringBallJumpMidAir",
                                    //    "canUseFrozenEnemies",
                                    //    "SpaceJump"
                                    //  ]}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - East Ocean - Right Door", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                new Strat {
                                    Name = "Suitless",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "HiJump",
                                    //  {"or":[
                                    //    "canSpringBallJumpMidAir",
                                    //    "SpaceJump"
                                    //  ]}
                                    //]
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - East Ocean - Bottom Choots",
                        EnemyName = "Choot",
                        Quantity = 4,
                        HomeNodes = new[] { "SM - East Ocean - Main Junction" },
                    },
                    new Enemy {
                        GroupName = "SM - East Ocean - Top Choot",
                        EnemyName = "Choot",
                        Quantity = 1,
                        HomeNodes = new[] {
                            "SM - East Ocean - Left Door",
                            "SM - East Ocean - Main Junction",
                        }
                    },
                    new Enemy {
                        GroupName = "SM - East Ocean - Skulteras",
                        EnemyName = "Skultera",
                        Quantity = 5,
                        HomeNodes = new[] { "SM - East Ocean - Main Junction" },
                    },
                },
            },
            #endregion
            #region Forgotten Highway Kago Room
            new Room {
                Name = "SM - Forgotten Highway Kago Room",
                Layout = Room.LayoutFrom(@"
                      1→X
                        X
                        X
                        X
                        ↑
                        2"
                    , "SM - Forgotten Highway Kago Room - Left Door"
                    , "SM - Forgotten Highway Kago Room - Bottom Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Forgotten Highway Kago Room - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 10,
                                SteepUpTiles = 1,
                                SteepDownTiles = 2,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Forgotten Highway Kago Room - Bottom Door",
                        Type = TransitionType.Blue,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Forgotten Highway Kago Room - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Forgotten Highway Kago Room - Bottom Door"),
                        },
                    },
                    new Link {
                        From = "SM - Forgotten Highway Kago Room - Bottom Door",
                        To = new[] {
                            new LinkTarget("SM - Forgotten Highway Kago Room - Left Door"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Forgotten Highway Room - Kagos",
                        EnemyName = "Kago",
                        Quantity = 2,
                        HomeNodes = new[] { "SM - Forgotten Highway Kago Room - Bottom Door" },
                    },
                },
            },
            #endregion
            #region Crab Maze
            new Room {
                Name = "SM - Crab Maze",
                Layout = Room.LayoutFrom(@"
                           2
                           ↓
                        XXXX
                      1→XXXX"
                    , "SM - Crab Maze - Left Door"
                    , "SM - Crab Maze - Top Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Crab Maze - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 7,
                                SteepUpTiles = 1,
                                OpenEnd = 0,
                            },
                            // This longer runway requires starting in the water.
                            new RunwayDash {
                                Length = 28,
                                SteepUpTiles = 5,
                                SteepDownTiles = 1,
                                OpenEnd = 0,
                                UsableComingIn = false,
                                Strats = new[] {
                                    new Strat { Requires = null /*["Gravity"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Crab Maze - Top Door",
                        Type = TransitionType.Blue,
                    },
                    // Exists mainly to separate Left Door from the shot block.
                    new Junction {
                        Name = "SM - Crab Maze - Middle Junction",
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Crab Maze - Top Door",
                        To = new[] {
                            new LinkTarget("SM - Crab Maze - Middle Junction", new[] {
                                new Strat { Requires = null /*["Morph"]*/ },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Crab Maze - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Crab Maze - Middle Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Crab Maze - Middle Junction",
                        To = new[] {
                            new LinkTarget("SM - Crab Maze - Top Door", new[] {
                                new Strat { Requires = null /*["Morph"]*/ },
                            }),
                            new LinkTarget("SM - Crab Maze - Left Door"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Crab Maze - Top Right Sciser",
                        EnemyName = "Sciser",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Crab Maze - Top Door" },
                    },
                    new Enemy {
                        GroupName = "SM - Crab Maze - Bottom Left Scisers",
                        EnemyName = "Sciser",
                        Quantity = 3,
                        HomeNodes = new[] { "SM - Crab Maze - Left Door" },
                    },
                    new Enemy {
                        GroupName = "SM - Crab Maze - Top Left Scisers",
                        EnemyName = "Sciser",
                        Quantity = 4,
                        HomeNodes = new[] { "SM - Crab Maze - Middle Junction" },
                    },
                },
            },
            #endregion
            #region Crateria East Elevator Room B
            new Room {
                Name = "SM - Crateria East Elevator Room B",
                Layout = Room.LayoutFrom(@"
                      1
                      ↓
                      X
                      ↑
                      2"
                    , "SM - Crateria East Elevator Room B - Top Door"
                    , "SM - Crateria East Elevator Room B - Elevator"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Crateria East Elevator Room B - Top Door",
                        Type = TransitionType.Blue,
                    },
                    new Transition {
                        Name = "SM - Crateria East Elevator Room B - Elevator",
                        Type = TransitionType.Elevator,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Crateria East Elevator Room B - Top Door",
                        To = new[] {
                            new LinkTarget("SM - Crateria East Elevator Room B - Elevator"),
                        },
                    },
                    new Link {
                        From = "SM - Crateria East Elevator Room B - Elevator",
                        To = new[] {
                            new LinkTarget("SM - Crateria East Elevator Room B - Top Door"),
                        },
                    },
                },
            },
            #endregion
            #region Forgotten Highway Elbow
            new Room {
                Name = "SM - Forgotten Highway Elbow",
                Layout = Room.LayoutFrom(@"
                      X←1
                      ↑
                      2"
                    , "SM - Forgotten Highway Elbow - Right Door"
                    , "SM - Forgotten Highway Elbow - Bottom Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Forgotten Highway Elbow - Right Door",
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
                        Name = "SM - Forgotten Highway Elbow - Bottom Door",
                        Type = TransitionType.Yellow,
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Forgotten Highway Elbow - Yellow Lock",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenYellowDoors"]*/ },
                                },
                            },
                        },
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Forgotten Highway Elbow - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Forgotten Highway Elbow - Bottom Door"),
                        },
                    },
                    new Link {
                        From = "SM - Forgotten Highway Elbow - Bottom Door",
                        To = new[] {
                            new LinkTarget("SM - Forgotten Highway Elbow - Right Door"),
                        },
                    },
                },
            },
            #endregion
            #region Homing Geemer Room
            new Room {
                Name = "SM - Homing Geemer Room",
                Layout = Room.LayoutFrom(@"
                      1→X←2"
                    , "SM - Homing Geemer Room - Left Door"
                    , "SM - Homing Geemer Room - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Homing Geemer Room - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 12,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Homing Geemer Room - Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 12,
                                OpenEnd = 1,
                            },
                        },
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Homing Geemer Room - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Homing Geemer Room - Right Door"),
                        },
                    },
                    new Link {
                        From = "SM - Homing Geemer Room - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Homing Geemer Room - Left Door"),
                        },
                    },
                },
            },
            #endregion
        };

    }

}
