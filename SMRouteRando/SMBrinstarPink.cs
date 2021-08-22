using System.Collections.Generic;
using SMRouteRando.Util;

namespace SMRouteRando {

    public class SMBrinstarPink {

        public static IList<Room> Rooms { get; } = new[] {
            #region Dachora Room
            new Room {
                Name = "SM - Dachora Room",
                Layout = Room.LayoutFrom(@"
                      2→XXXXXXX←3
                            X
                            X
                            X
                            X
                            X
                      1→XXXXX"
                    , "SM - Dachora Room - Bottom Left Door"
                    , "SM - Dachora Room - Top Left Door"
                    , "SM - Dachora Room - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Dachora Room - Bottom Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 33,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Dachora Room - Top Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 33,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Dachora Room - Right Door",
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
                        From = "SM - Dachora Room - Top Left Door",
                        To = new[] {
                            new LinkTarget("SM - Dachora Room - Right Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //{"or": [
                                    //  "SpeedBooster",
                                    //  "h_canDestroyBombWalls"
                                    //]}
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Dachora Room - Bottom Left Door",
                        To = new[] {
                            new LinkTarget("SM - Dachora Room - Right Door", new[] {
                                new Strat {
                                    Name = "Spark from Floor",
                                    Requires = null,
                                    //{"canShineCharge": {
                                    //  "usedTiles": 33,
                                    //  "shinesparkFrames": 115,
                                    //  "openEnd": 2
                                    //}}
                                },
                                // A spark cuts off with 29 energy remaining. It's possible to get
                                // out with one E-Tank without hjb, but it's very difficult. It's
                                // also not possible to get to the ceiling with that spark so we
                                // can't really model it. We'll limit this to the hjb version,
                                // where reaching the ceiling with no E_Tank is essentially doable
                                // (if tricky).
                                new Strat {
                                    Name = "No-Tank Dachora Escape",
                                    Notable = true,
                                    Requires = null,
                                    //[ {"canShineCharge": {
                                    //    "usedTiles": 33,
                                    //    "shinesparkFrames": 70,
                                    //    "openEnd": 2
                                    //  }},
                                    //  "HiJump",
                                    //  "canFastWalljumpClimb"
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Dachora Room - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Dachora Room - Top Left Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //{"or": [
                                    //  "SpeedBooster",
                                    //  "h_canDestroyBombWalls"
                                    //]}
                                },
                            }),
                            new LinkTarget("SM - Dachora Room - Bottom Left Door", new[] {
                                new Strat { Requires = null /*["SpeedBooster"]*/ },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "Dachora Room Zeelas",
                        EnemyName = "Zeela",
                        Quantity = 2,
                        HomeNodes = new[] { "SM - Dachora Room - Top Left Door" },
                    },
                    new Enemy {
                        GroupName = "Dachora Room Reo",
                        EnemyName = "Reo",
                        Quantity = 3,
                        HomeNodes = new[] { "SM - Dachora Room - Top Left Door" },
                    },
                    new Enemy {
                        GroupName = "Dachora Room Metarees",
                        EnemyName = "Metaree",
                        Quantity = 3,
                        HomeNodes = new[] { "SM - Dachora Room - Right Door" },
                    },
                },
            },
            #endregion
            #region Big Pink
            new Room {
                Name = "SM - Big Pink",
                Layout = Room.LayoutFrom(@"
                       5→XXX←6
                          XX
                        4→XX
                        3→XX
                        2→XX←7
                          XXX←8
                          XX←9
                        XXX
                        X
                      1→X"
                    , "SM - Big Pink - Bottom Left Door"
                    , "SM - Big Pink - Middle Bottom Left Door"
                    , "SM - Big Pink - Middle Left Door"
                    , "SM - Big Pink - Middle Top Left Door"
                    , "SM - Big Pink - Top Left Door"
                    , "SM - Big Pink - Top Right Door"
                    , "SM - Big Pink - Middle Top Right Door"
                    , "SM - Big Pink - Middle Bottom Right Door"
                    , "SM - Big Pink - Bottom Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Big Pink - Bottom Left Door",
                        Type = TransitionType.Red,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 5,
                                OpenEnd = 0,
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Big Pink - Bottom Left Red Lock",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenRedDoors"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Big Pink - Middle Bottom Left Door",
                        Type = TransitionType.Blue,
                        // Samus is considered to spawn at X-Ray Climb Setup Junction because of
                        // the crumble blocks. This can be negated by performing a stationary spin
                        // jump when entering, allowing her to "get back to 5".
                        SpawnAt = "SM - Big Pink - X-Ray Climb Setup Junction",
                        Runways = new[] {
                            new RunwayDash {
                                Length = 0,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Big Pink - Middle Left Door",
                        Type = TransitionType.Doorway,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 0,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Big Pink - Middle Top Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 24,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Big Pink - Top Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 6,
                                SteepDownTiles = 1,
                                OpenEnd = 0,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Big Pink - Top Right Door",
                        Type = TransitionType.Red,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 17,
                                OpenEnd = 0,
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Big Pink - Top Right Red Lock",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenRedDoors"] */ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Big Pink - Middle Top Right Door",
                        Type = TransitionType.Yellow,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 0,
                                OpenEnd = 1,
                            },
                        },
                        CanLeaveCharged = new[] {
                            new RunwayCharge {
                                Length = 19,
                                OpenEnd = 0,
                                FramesRemaining = 60,
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Big Pink - Right Yellow Lock",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenYellowDoors"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Big Pink - Middle Bottom Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 6,
                                OpenEnd = 0,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Big Pink - Bottom Right Door",
                        Type = TransitionType.Green,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 12,
                                OpenEnd = 0,
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Big Pink - Bottom Right Green Lock",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenGreenDoors"]*/ },
                                },
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - Big Pink - Top Item",
                        Type = PlacementType.Visible,
                    },
                    new Placement {
                        Name = "SM - Big Pink - Bottom Item",
                        Type = PlacementType.Visible,
                    },
                    new Placement {
                        Name = "SM - Big Pink - Chozo Item",
                        Type = PlacementType.Chozo,
                    },
                    new Junction {
                        Name = "SM - Big Pink - Central Junction",
                    },
                    // A junction used as a midpoint between Middle Bottom Left Door and
                    // Central Junction to express that a tech is required to access
                    // Middle Bottom Left Door.
                    new Junction {
                        Name = "SM - Big Pink - X-Ray Climb Setup Junction",
                    },
                },
                Obstacles = new[] {
                    // The Bomb block that blocks the save room.
                    new Obstacle {
                        Name = "Top Bomb Block",
                        Type = ObstacleType.Inanimate,
                    },
                    // The Power Bomb Blocks that block Mission Impossible access.
                    new Obstacle {
                        Name = "Mid Power Bomb Blocks",
                        Type = ObstacleType.Inanimate,
                    },
                    // The Crumble Blocks that serve as an escape for the top Mission Impossible door.
                    new Obstacle {
                        Name = "Crumble Blocks",
                        Type = ObstacleType.Inanimate,
                    },
                    // The Bomb blocks that separate Charge Beam from the main section.
                    new Obstacle {
                        Name = "Bottom Bomb Blocks",
                        Type = ObstacleType.Inanimate,
                    },
                    // The Power Bomb block that separates Charge Beam from waterway.
                    new Obstacle {
                        Name = "Bottom Power Bomb Block",
                        Type = ObstacleType.Inanimate,
                    },
                    // It's two bomb blocks and a Super block.
                    new Obstacle {
                        Name = "Spore Spawn Escape Barrier",
                        Type = ObstacleType.Inanimate,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Big Pink - Top Left Door",
                        To = new[] {
                            // FIXME There's a speedball strat here to clear the obstacle, depending on adjacent room.
                            new LinkTarget("SM - Big Pink - Central Junction", new[] {
                                new Strat {
                                    Requires = null, // ["Morph"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Top Bomb Block",
                                            Requires = null,
                                            //{"or":[
                                            //  "Bombs",
                                            //  {"and": [
                                            //    "PowerBomb",
                                            //    {"ammo": {
                                            //      "type": "PowerBomb",
                                            //      "count": 1
                                            //    }}
                                            //  ]}
                                            //]}
                                        },
                                    },
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Big Pink - Top Right Door",
                        To = new[] {
                            new LinkTarget("SM - Big Pink - Central Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Big Pink - Middle Top Left Door",
                        To = new[] {
                            new LinkTarget("SM - Big Pink - Central Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Big Pink - Middle Left Door",
                        To = new[] {
                            new LinkTarget("SM - Big Pink - Top Item", new[] {
                                new Strat {
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Mid Power Bomb Blocks",
                                            Requires = null, /*["h_canUsePowerBombs"]*/
                                        },
                                    },
                                },
                            }),
                            new LinkTarget("SM - Big Pink - Central Junction", new[] {
                                new Strat {
                                    Requires = null, // ["Morph"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle { Name = "Crumble Blocks" },
                                    },
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Big Pink - Middle Bottom Left Door",
                        To = new[] {
                            new LinkTarget("SM - Big Pink - Middle Left Door", new[] {
                                // Normally, an XRayClimb's resetRoom has mustStayPut true, but
                                // because Middle Bottom Left Door is configured to spawn at
                                // X-Ray Climb Setup Junction, Samus will be expected to visit
                                // X-Ray Climb Setup Junction before Middle Bottom Left Door when
                                // setting up. It's also possible to X-Ray Climb to
                                // Central Junction, but that's reachable for free just by falling
                                // down the crumble blocks anyway.
                                new Strat {
                                    Name = "Big Pink Left-Side X-Ray Climb",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canRightFacingDoorXRayClimb",
                                    //  { "resetRoom": {
                                    //    "nodes": [5],
                                    //    "nodesToAvoid": [13]
                                    //  }}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Big Pink - X-Ray Climb Setup Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Big Pink - Middle Top Right Door",
                        To = new[] {
                            new LinkTarget("SM - Big Pink - Central Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Big Pink - Middle Bottom Right Door",
                        To = new[] {
                            new LinkTarget("SM - Big Pink - Central Junction", new[] {
                                new Strat {
                                    Requires = null, // ["Morph"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Spore Spawn Escape Barrier",
                                            Requires = null,
                                            //[ "Super",
                                            //  {"ammo": {
                                            //    "type": "Super",
                                            //    "count": 1
                                            //  }},
                                            //  {"or":[
                                            //    "Bombs",
                                            //    {"and": [
                                            //      "PowerBomb",
                                            //      {"ammo": {
                                            //        "type": "PowerBomb",
                                            //        "count": 1
                                            //      }}
                                            //    ]}
                                            //  ]}
                                            //]
                                        },
                                    },
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Big Pink - Bottom Right Door",
                        To = new[] {
                            new LinkTarget("SM - Big Pink - Bottom Item", new[] {
                                new Strat { Requires = null /*["Morph"]*/ },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Big Pink - Bottom Left Door",
                        To = new[] {
                            new LinkTarget("SM - Big Pink - Chozo Item", new[] {
                                new Strat {
                                    Requires = null, // ["Morph"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Bottom Power Bomb Block",
                                            Requires = null, // ["h_canUsePowerBombs"]
                                        },
                                    },
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Big Pink - Top Item",
                        To = new[] {
                            new LinkTarget("SM - Big Pink - Middle Left Door", new[] {
                                new Strat {
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Mid Power Bomb Blocks",
                                            Requires = null, // ["h_canUsePowerBombs"]
                                        },
                                    },
                                },
                            }),
                            new LinkTarget("SM - Big Pink - Central Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Big Pink - Bottom Item",
                        To = new[] {
                            new LinkTarget("SM - Big Pink - Bottom Right Door", new[] {
                                new Strat { Requires = null /*["Morph"]*/ },
                            }),
                            new LinkTarget("SM - Big Pink - Chozo Item", new[] {
                                new Strat {
                                    Requires = null, // ["Morph"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Bottom Bomb Blocks",
                                            Requires = null, // ["h_canPassBombPassages"]
                                        },
                                    },
                                },
                            }),
                            new LinkTarget("SM - Big Pink - Central Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Big Pink - Chozo Item",
                        To = new[] {
                            new LinkTarget("SM - Big Pink - Bottom Left Door", new[] {
                                new Strat {
                                    Requires = null, // ["Morph"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Bottom Power Bomb Block",
                                            Requires = null, // ["h_canUsePowerBombs"]
                                        },
                                    },
                                },
                            }),
                            new LinkTarget("SM - Big Pink - Bottom Item", new[] {
                                new Strat {
                                    Requires = null, // ["Morph"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Bottom Bomb Blocks",
                                            Requires = null,
                                            //{"or":[
                                            //  "ScrewAttack",
                                            //  "Bombs",
                                            //  {"and": [
                                            //    "PowerBomb",
                                            //    {"ammo": {
                                            //    "type": "PowerBomb",
                                            //      "count": 1
                                            //    }}
                                            //  ]}
                                            //]}
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Charge Escape Clip",
                                    Notable = true,
                                    Requires = null, // ["canCeilingClip"]
                                }
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Big Pink - Central Junction",
                        To = new[] {
                            // FIXME Obstacle can be broken with a speedball coming in from
                            // Top Right Door, but can't be done with too short a charge as you
                            // won't clear the gap.
                            new LinkTarget("SM - Big Pink - Top Left Door", new[] {
                                new Strat {
                                    Requires = null, // ["Morph"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Top Bomb Block",
                                            Requires = null,
                                            //{"or":[
                                            //  "Bombs",
                                            //  {"and": [
                                            //    "PowerBomb",
                                            //    {"ammo": {
                                            //      "type": "PowerBomb",
                                            //      "count": 1
                                            //    }}
                                            //  ]}
                                            //]}
                                        },
                                    },
                                },
                            }),
                            new LinkTarget("SM - Big Pink - Top Right Door"),
                            new LinkTarget("SM - Big Pink - Middle Top Left Door"),
                            new LinkTarget("SM - Big Pink - Middle Left Door", new[] {
                                // Can only be done if the crumble blocks have been broken beforehand.
                                new Strat {
                                    Requires = null, // ["Morph"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Crumble Blocks",
                                            Requires = null, // ["never"]
                                        },
                                    },
                                },
                            }),
                            new LinkTarget("SM - Big Pink - Middle Top Right Door"),
                            new LinkTarget("SM - Big Pink - Middle Bottom Right Door", new[] {
                                // This base strat represents only backtracking after entering from
                                // Middle Top Right Door.
                                new Strat {
                                    Requires = null, // ["Morph"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Spore Spawn Escape Barrier",
                                            Requires = null, // ["never"]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Spore Spawn Skip",
                                    Notable = true,
                                    Requires = null, // ["Morph"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Spore Spawn Escape Barrier",
                                            Requires = null,
                                            //[ "canSuperReachAround",
                                            //  "h_canPassBombPassages"
                                            //]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "CF Spore Spawn Skip",
                                    Notable = true,
                                    Requires = null, // ["Morph"]
                                    Obstacles = new[] {
                                        // CF to force a standup, making it possible to shoot the
                                        // super block from the left while it's on-screen.
                                        new Strat.Obstacle {
                                            Name = "Spore Spawn Escape Barrier",
                                            Requires = null,
                                            //[ "h_canPassBombPassages",
                                            //  "canCrystalFlashForceStandup",
                                            //  "Super",
                                            //  {"ammo": {
                                            //    "type": "Super",
                                            //    "count": 1
                                            //  }}
                                            //]
                                        },
                                    },
                                },
                            }),
                            new LinkTarget("SM - Big Pink - Top Item"),
                            new LinkTarget("SM - Big Pink - Bottom Item"),
                        },
                    },
                    new Link {
                        From = "SM - Big Pink - X-Ray Climb Setup Junction",
                        To = new[] {
                            new LinkTarget("SM - Big Pink - Middle Bottom Left Door", new[] {
                                // The only expected way for Samus to access Middle Bottom Left Door
                                // is to enter room while doing a stationary spinjump, otherwise
                                // she is expected to spawn at X-Ray Climb Setup Junction and fall
                                // to Central Junction.
                                new Strat {
                                    Name = "Retroactive X-Ray Setup",
                                    Requires = null, // ["canStationarySpinJump"]
                                },
                            }),
                            new LinkTarget("SM - Big Pink - Central Junction"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName =  "SM - Big Pink - Top Zeb",
                        EnemyName =  "Zeb",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Big Pink - Central Junction" },
                        FarmCycles = new[] {
                            new FarmCycle {
                                Name = "Crouch over spawn point",
                                CycleFrames = 120,
                            },
                        },
                    },
                    new Enemy {
                        GroupName = "SM - Big Pink - Middle Zeb",
                        EnemyName = "Zeb",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Big Pink - Central Junction" },
                        FarmCycles = new[] {
                            new FarmCycle {
                                Name = "Crouch over spawn point",
                                CycleFrames = 120,
                            },
                        },
                    },
                    new Enemy {
                        GroupName = "SM - Big Pink - Bottom Zeb",
                        EnemyName = "Zeb",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Big Pink - Central Junction" },
                        FarmCycles = new[] {
                            new FarmCycle {
                                Name = "Crouch over spawn point",
                                CycleFrames = 120,
                            },
                        },
                    },
                    new Enemy {
                        GroupName = "SM - Big Pink - Small Sidehoppers",
                        EnemyName = "Sm. Sidehopper",
                        Quantity = 4,
                        HomeNodes = new[] { "SM - Big Pink - Central Junction" },
                    },
                    new Enemy {
                        GroupName = "SM - Big Pink - Reos",
                        EnemyName = "Reo",
                        Quantity = 3,
                        HomeNodes = new[] { "SM - Big Pink - Central Junction" },
                    },
                },
            },
            #endregion
            #region Mission Impossible
            new Room {
                Name = "SM - Mission Impossible",
                Layout = Room.LayoutFrom(@"
                      XX←1
                      XX←2"
                    , "SM - Mission Impossible - Top Right Door"
                    , "SM - Mission Impossible - Bottom Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Mission Impossible - Top Right Door",
                        Type = TransitionType.Gray,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 2,
                                OpenEnd = 1,
                                UsableComingIn = false,
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Mission Impossible - Grey Lock",
                                Type = LockType.KillEnemies,
                                UnlockStrats = new[] {
                                    // To avoid redundant requirements, obstacle must be destroyed by going to 4 and back.
                                    new Strat {
                                        Obstacles = new[] {
                                            new Strat.Obstacle {
                                                Name = "Sidehoppers",
                                                Requires = null, // ["never"]
                                            },
                                        },
                                    },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Mission Impossible - Bottom Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 0,
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - Mission Impossible - Item",
                        Type = PlacementType.Visible,
                    },
                    // The top left section of the room, where the Super block is.
                    new Junction {
                        Name = "SM - Mission Impossible - Top Left Junction",
                    }
                },
                Obstacles = new[] {
                    new Obstacle {
                        Name = "Sidehoppers",
                        Type = ObstacleType.Enemies,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Mission Impossible - Top Right Door",
                        To = new[] {
                            new LinkTarget("SM - Mission Impossible - Top Left Junction", new[] {
                                // 2 hits are expected to be taken. First hit can be either from a
                                // Sidehopper or from a spike. Second hit will be from a Sidehopper.
                                new Strat {
                                    Name = "Tank the Damage",
                                    Requires = null,
                                    //[ {"enemyDamage": {
                                    //    "enemy": "Sidehopper",
                                    //    "type": "contact",
                                    //    "hits": 1
                                    //  }},
                                    //  {"or":[
                                    //    {"enemyDamage": {
                                    //      "enemy": "Sidehopper",
                                    //      "type": "contact",
                                    //      "hits": 1
                                    //    }},
                                    //    {"spikeHits": 1}
                                    //  ]}
                                    //]
                                },
                                new Strat {
                                    Name = "Power Beam Sidehopper Kill",
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Sidehoppers",
                                            Requires = null,
                                            //{"enemyDamage": {
                                            //  "enemy": "Sidehopper",
                                            //  "type": "contact",
                                            //  "hits": 6
                                            //}}
                                        },
                                    },
                                },
                                // Morph reduces damage because the ceiling Sidehopper can't reach
                                // a morphed Samus.
                                new Strat {
                                    Name = "Morph Power Beam Sidehopper Kill",
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Sidehoppers",
                                            Requires = null,
                                            //[ {"enemyDamage": {
                                            //    "enemy": "Sidehopper",
                                            //    "type": "contact",
                                            //    "hits": 3
                                            //  }},
                                            //  "Morph"
                                            //]
                                        },
                                    },
                                },
                                // Charge here is for Pseudo Screw kills.
                                new Strat {
                                    Name = "Intermediate Weapon Sidehopper Kill",
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Sidehoppers",
                                            Requires = null,
                                            //[ {"enemyDamage": {
                                            //    "enemy": "Sidehopper",
                                            //    "type": "contact",
                                            //    "hits": 2
                                            //  }},
                                            //  {"or":[
                                            //    "Spazer",
                                            //    "Charge",
                                            //    "Wave"
                                            //  ]}
                                            //]
                                        },
                                    },
                                },
                                // Morph reduces damage because the ceiling Sidehopper can't reach
                                // a morphed Samus.
                                new Strat {
                                    Name = "Morph Intermediate Weapon Sidehopper Kill",
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Sidehoppers",
                                            Requires = null,
                                            //[ {"enemyDamage": {
                                            //    "enemy": "Sidehopper",
                                            //    "type": "contact",
                                            //    "hits": 1
                                            //  }},
                                            //  "Morph",
                                            //  {"or":[
                                            //    "Spazer",
                                            //    "Wave"
                                            //  ]}
                                            //]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Good Weapon Sidehopper Kill",
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Sidehoppers",
                                            Requires = null,
                                            //[ {"enemyDamage": {
                                            //    "enemy": "Sidehopper",
                                            //    "type": "contact",
                                            //    "hits": 1
                                            //  }},
                                            //  {"enemyKill":{
                                            //    "enemies": [
                                            //      ["Sidehopper"],
                                            //      ["Sidehopper"]
                                            //    ],
                                            //    "explicitWeapons": ["Missile"]
                                            //  }}
                                            //]
                                        },
                                    },
                                },
                                // All beam weapons that can take out a Sidehopper in 5 hits or
                                // less can reliably take out the Sidehoppers damage-free.
                                new Strat {
                                    Name = "Safe Weapon Sidehopper Kill",
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Sidehoppers",
                                            Requires = null,
                                            //[ {"enemyKill":{
                                            //    "enemies": [
                                            //      ["Sidehopper"],
                                            //      ["Sidehopper"]
                                            //    ],
                                            //    "explicitWeapons": [
                                            //      "Super",
                                            //      "PowerBomb",
                                            //      "ScrewAttack",
                                            //      "Plasma",
                                            //      "Wave+Spazer"
                                            //    ]
                                            //  }}
                                            //]
                                        },
                                    },
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Mission Impossible - Bottom Right Door",
                        To = Empty<LinkTarget>.List,
                    },
                    new Link {
                        From = "SM - Mission Impossible - Item",
                        To = new[] {
                            new LinkTarget("SM - Mission Impossible - Bottom Right Door", new[] {
                                new Strat { Requires = null /*["h_canPassBombPassages"]*/ },
                            }),
                            new LinkTarget("SM - Mission Impossible - Top Left Junction", new[] {
                                // This involves doing a quick-drop through the Crumble block,
                                // grabbing the item, and jumping back up before the crumble block
                                // reappears. Mission Impossible expects that the Sidehoppers are
                                // dead. To avoid redundant requirements, they must be killed
                                // coming in.
                                new Strat {
                                    Name = "Mission Impossible",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canQuickCrumbleEscape",
                                    //  "HiJump",
                                    //  {"previousNode": 4}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Sidehoppers",
                                            Requires = null, // ["never"]
                                        },
                                    },
                                    Failures = new[] {
                                        // Failure leaves you at Item with a solid crumble block above.
                                        new Strat.Failure {
                                            Name = "Crumble Failure",
                                            ClearsPreviousNode = true,
                                        },
                                    },
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Mission Impossible - Top Left Junction",
                        To = new[] {
                            new LinkTarget("SM - Mission Impossible - Top Right Door", new[] {
                                new Strat {
                                    Obstacles = new[] {
                                        // To avoid redundant requirements, obstacle must be destroyed coming in.
                                        new Strat.Obstacle {
                                            Name = "Sidehoppers",
                                            Requires = null, // ["never"]
                                        },
                                    },
                                },
                            }),
                            new LinkTarget("SM - Mission Impossible - Item", new[] {
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
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Mission Impossible - Sidehoppers",
                        EnemyName = "Sidehopper",
                        Quantity = 2,
                        HomeNodes = new[] {
                            "SM - Mission Impossible - Top Right Door",
                            "SM - Mission Impossible - Top Left Junction",
                        },
                    },
                },
            },
            #endregion
            // Todo: Acceptable name?
            #region Wave Gate Room
            new Room {
                Name = "SM - Wave Gate Room",
                Layout = Room.LayoutFrom(@"
                        XX
                      1→XX←2"
                    , "SM - Wave Gate Room - Left Door"
                    , "SM - Wave Gate Room - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Wave Gate Room - Left Door",
                        Type = TransitionType.Gray,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 0,
                                OpenEnd = 1,
                            },
                        },
                        Locks = new[] {
                            // To avoid redundant requirements, obstacle must be destroyed by going
                            // to Cleared Hoppers Junction (possibly via Right Door) and back.
                            new Lock {
                                Name = "SM - Wave Gate Room - Left Grey Lock",
                                Type = LockType.KillEnemies,
                                UnlockStrats = new[] {
                                    new Strat {
                                        Obstacles = new[] {
                                            new Strat.Obstacle {
                                                Name = "Hoppers",
                                                Requires = null, // ["never"]
                                            },
                                        },
                                    },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Wave Gate Room - Right Door",
                        Type = TransitionType.Gray,
                        Runways = new[] {
                            new RunwayDash{
                                Length = 5,
                                OpenEnd = 1,
                            },
                        },
                        Locks = new[] {
                            // To avoid redundant requirements, obstacle must be destroyed by going
                            // to Cleared Hoppers Junction and back.
                            new Lock {
                                Name = "SM - Wave Gate Room - Right Grey Lock",
                                Type = LockType.KillEnemies,
                                UnlockStrats = new[] {
                                    new Strat {
                                        Obstacles = new[] {
                                            new Strat.Obstacle {
                                                Name = "Hoppers",
                                                Requires = null, // ["never"]
                                            },
                                        },
                                    },
                                },
                            },
                        },
                    },
                    // This junction is essentially equivalent to being near the left door but with
                    // the enemies cleared.
                    new Junction {
                        Name = "SM - Wave Gate Room - Cleared Hoppers Junction",
                    },
                },
                Obstacles = new[] {
                    new Obstacle {
                        Name = "Hoppers",
                        Type = ObstacleType.Enemies,
                    },
                    new Obstacle {
                        Name = "Blue Gate",
                        Type = ObstacleType.Inanimate,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Wave Gate Room - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Wave Gate Room - Right Door", new[] {
                                // The reverse GGG pretty much requires you to clear the enemies,
                                // so it's done from the Cleared Hoppers Junction.
                                new Strat {
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Blue Gate",
                                            Requires = null, // ["Wave"]
                                        },
                                    },
                                },
                            }),
                            new LinkTarget("SM - Wave Gate Room - Cleared Hoppers Junction", new[] {
                                new Strat {
                                    Name = "Power Beam Kill",
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Hoppers",
                                            Requires = null,
                                            //[ {"enemyDamage": {
                                            //    "enemy": "Sm. Sidehopper",
                                            //    "type": "contact",
                                            //    "hits": 1
                                            //  }},
                                            //  {"enemyDamage": {
                                            //    "enemy": "Sidehopper",
                                            //    "type": "contact",
                                            //    "hits": 3
                                            //  }}
                                            //]
                                        },
                                    },
                                },
                                // This assumes you don't know you're entering this room, and take
                                // a Small Sidehopper hit quickly.
                                new Strat {
                                    Name = "Intermediate Weapon Kill",
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Hoppers",
                                            Requires = null,
                                            //[ {"enemyDamage": {
                                            //    "enemy": "Sm. Sidehopper",
                                            //    "type": "contact",
                                            //    "hits": 1
                                            //  }},
                                            //  {"enemyDamage": {
                                            //    "enemy": "Sidehopper",
                                            //    "type": "contact",
                                            //    "hits": 1
                                            //  }},
                                            //  {"or":[
                                            //    "Spazer",
                                            //    "Wave"
                                            //  ]}
                                            //]
                                        },
                                    },
                                },
                                // This assumes you don't know you're entering this room, and take
                                // a Small Sidehopper hit quickly.
                                new Strat {
                                    Name = "Fast Weapon Kill",
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Hoppers",
                                            Requires = null,
                                            //[ {"enemyDamage": {
                                            //    "enemy": "Sm. Sidehopper",
                                            //    "type": "contact",
                                            //    "hits": 1
                                            //  }},
                                            //  {"enemyKill":{
                                            //    "enemies": [
                                            //      [ "Sidehopper", "Sm. Sidehopper", "Sm. Sidehopper"]
                                            //    ],
                                            //    "explicitWeapons": [
                                            //      "Missile",
                                            //      "Super",
                                            //      "PowerBomb",
                                            //      "ScrewAttack",
                                            //      "Plasma"
                                            //    ]
                                            //  }}
                                            //]
                                        },
                                    },
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Wave Gate Room - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Wave Gate Room - Left Door", new[] {
                                new Strat {
                                    Obstacles = new[] {
                                        new Strat.Obstacle { Name = "Blue Gate" },
                                    },
                                },
                            }),
                            new LinkTarget("SM - Wave Gate Room - Cleared Hoppers Junction", new[] {
                                // The Small Sidehoppers may deliver more of the hits, but this is
                                // an assumed worst case scenario.
                                new Strat {
                                    Name = "Power Beam Kill",
                                    Obstacles = new[] {
                                        new Strat.Obstacle { Name = "Blue Gate" },
                                        new Strat.Obstacle {
                                            Name = "Hoppers",
                                            Requires = null,
                                            //[ {"enemyDamage": {
                                            //    "enemy": "Sm. Sidehopper",
                                            //    "type": "contact",
                                            //    "hits": 1
                                            //  }},
                                            //  {"enemyDamage": {
                                            //    "enemy": "Sidehopper",
                                            //    "type": "contact",
                                            //    "hits": 3
                                            //  }}
                                            //]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Intermediate Weapon Kill",
                                    Obstacles = new[] {
                                        new Strat.Obstacle { Name = "Blue Gate" },
                                        new Strat.Obstacle {
                                            Name = "Hoppers",
                                            Requires = null,
                                            //[ {"enemyDamage": {
                                            //    "enemy": "Sm. Sidehopper",
                                            //    "type": "contact",
                                            //    "hits": 1
                                            //  }},
                                            //  {"enemyDamage": {
                                            //    "enemy": "Sidehopper",
                                            //    "type": "contact",
                                            //    "hits": 1
                                            //  }},
                                            //  {"or":[
                                            //    "Spazer",
                                            //    "Wave"
                                            //  ]}
                                            //]
                                        },
                                    },
                                },
                                // Expects an intentional Small Sidehopper hit for iframes.
                                new Strat {
                                    Name = "Fast Weapon Kill",
                                    Obstacles = new[] {
                                        new Strat.Obstacle { Name = "Blue Gate" },
                                        new Strat.Obstacle {
                                            Name = "Hoppers",
                                            Requires = null,
                                            //[ {"enemyDamage": {
                                            //    "enemy": "Sm. Sidehopper",
                                            //    "type": "contact",
                                            //    "hits": 1
                                            //  }},
                                            //  {"enemyKill":{
                                            //    "enemies": [
                                            //      [ "Sidehopper", "Sm. Sidehopper", "Sm. Sidehopper"]
                                            //    ],
                                            //    "explicitWeapons": [
                                            //      "Missile",
                                            //      "Super",
                                            //      "Plasma"
                                            //    ]
                                            //  }}
                                            //]
                                        },
                                    },
                                },
                                // With access to the right side of the room, it's possible to kill
                                // the enemies safely with Wave or a PB.
                                new Strat {
                                    Name = "Safe Kill",
                                    Obstacles = new[] {
                                        new Strat.Obstacle { Name = "Blue Gate" },
                                        new Strat.Obstacle {
                                            Name = "Hoppers",
                                            Requires = null,
                                            //[ {"enemyKill":{
                                            //    "enemies": [
                                            //      [ "Sidehopper", "Sm. Sidehopper", "Sm. Sidehopper"]
                                            //    ],
                                            //    "explicitWeapons": [
                                            //      "PowerBomb",
                                            //      "ScrewAttack",
                                            //      "Wave"
                                            //    ]
                                            //  }}
                                            //]
                                        },
                                    },
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Wave Gate Room - Cleared Hoppers Junction",
                        To = new[] {
                            new LinkTarget("SM - Wave Gate Room - Left Door"),
                            new LinkTarget("SM - Wave Gate Room - Right Door", new[] {
                                new Strat {
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Blue Gate",
                                            Requires = null, // ["Wave"]
                                        },
                                    },
                                },
                                // This strat involves shooting a Super diagonally from the correct
                                // height while flush against the left wall. Its acceleration will
                                // cause it to clip into the blue gate off-screen. The reverse GGG
                                // pretty much requires killing the enemies first, so it's done here
                                // rather than at node Left Door.
                                new Strat {
                                    Name = "Pink Brin Reverse GGG",
                                    Notable = true,
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Blue Gate",
                                            Requires = null,
                                            //[ "canReverseGateGlitch",
                                            //  "canSuperReachAround"
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
                        GroupName = "SM - Wave Gate Room - Small Sidehoppers",
                        EnemyName = "Sm. Sidehopper",
                        Quantity = 2,
                        HomeNodes = new[] {
                            "SM - Wave Gate Room - Left Door",
                            "SM - Wave Gate Room - Cleared Hoppers Junction",
                        },
                    },
                    new Enemy {
                        GroupName = "SM - Wave Gate Room - Sidehopper",
                        EnemyName = "Sidehopper",
                        Quantity = 1,
                        HomeNodes = new[] {
                            "SM - Wave Gate Room - Left Door",
                            "SM - Wave Gate Room - Cleared Hoppers Junction",
                        },
                    },
                },
            },
            #endregion
            // Todo: Acceptable Name?
            #region Brinstar Pink Prize Room
            new Room {
                Name = "SM - Brinstar Pink Prize Room",
                Layout = Room.LayoutFrom(@"
                      1→X"
                    , "SM - Brinstar Pink Prize Room - Door"
                    , "SM - Brinstar Pink Prize Room - Item"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Brinstar Pink Prize Room - Door",
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
                        Name = "SM - Brinstar Pink Prize Room - Item",
                        Type = PlacementType.Visible,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Brinstar Pink Prize Room - Door",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Pink Prize Room - Item"),
                        },
                    },
                    new Link {
                        From = "SM - Brinstar Pink Prize Room - Item",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Pink Prize Room - Door"),
                        },
                    },
                },
            },
            #endregion
            // Todo: Tricky one. Does this name work?
            #region Brinstar Pink Escape Chute
            new Room {
                Name = "SM - Brinstar Pink Escape Chute",
                Layout = Room.LayoutFrom(@"
                      2→XX
                         X
                         X
                         X
                         X
                         X
                         X
                         X
                      1→XX"
                    , "SM - Brinstar Pink Escape Chute - Bottom Left Door"
                    , "SM - Brinstar Pink Escape Chute - Top Left Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Brinstar Pink Escape Chute - Bottom Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 16,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Brinstar Pink Escape Chute - Top Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 9,
                                SteepUpTiles = 2,
                                OpenEnd = 0,
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - Brinstar Pink Escape Chute - Item",
                        Type = PlacementType.Chozo,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Brinstar Pink Escape Chute - Top Left Door",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Pink Escape Chute - Item"),
                        },
                    },
                    new Link {
                        From = "SM - Brinstar Pink Escape Chute - Bottom Left Door",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Pink Escape Chute - Item"),
                        },
                    },
                    new Link {
                        From = "SM - Brinstar Pink Escape Chute - Item",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Pink Escape Chute - Bottom Left Door"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Brinstar Pink Escape Chute - Zeb",
                        EnemyName = "Zeb",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Brinstar Pink Escape Chute - Top Left Door" },
                        FarmCycles = new[] {
                            new FarmCycle {
                                Name = "Crouch over spawn point",
                                CycleFrames = 120,
                            },
                        },
                    },
                },
            },
            #endregion
            // Todo: Not happy with this name.
            #region Spore Spawn Farming Room
            new Room {
                Name = "SM - Spore Spawn Farming Room",
                Layout = Room.LayoutFrom(@"
                      1→XXX←2"
                    , "SM - Spore Spawn Farming Room - Left Door"
                    , "SM - Spore Spawn Farming Room - Right Door"
                ),
                Nodes = new[] {
                    new Transition {
                        Name = "SM - Spore Spawn Farming Room - Left Door",
                        Type = TransitionType.Green,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 11,
                                SteepUpTiles = 2,
                                OpenEnd = 0,
                            },
                        },
                        CanLeaveCharged = new[] {
                            new RunwayCharge {
                                Length = 21,
                                SteepUpTiles = 2,
                                OpenEnd = 0,
                                FramesRemaining = 0,
                                ShinesparkFrames = 20,
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Spore Spawn Farming Room - Green Lock",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenGreenDoors"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Spore Spawn Farming Room - Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 21,
                                SteepUpTiles = 2,
                                OpenEnd = 0,
                            },
                        },
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Spore Spawn Farming Room - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Spore Spawn Farming Room - Right Door"),
                        },
                    },
                    new Link {
                        From = "SM - Spore Spawn Farming Room - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Spore Spawn Farming Room - Left Door"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "Spore Spawn Farming Room Zeelas",
                        EnemyName = "Zeela",
                        Quantity = 2,
                        HomeNodes = new[] { "SM - Spore Spawn Farming Room - Left Door" },
                    },
                    new Enemy {
                        GroupName = "Spore Spawn Farming Room Left Zebs",
                        EnemyName = "Zeb",
                        Quantity = 2,
                        HomeNodes = new[] { "SM - Spore Spawn Farming Room - Left Door" },
                        FarmCycles = new[] {
                            // Getting the two spawners to desynch and jumping back and forth
                            // between the two.
                            new FarmCycle {
                                Name = "Alternating Farm",
                                CycleFrames = 120,
                            },
                        },
                    },
                    new Enemy {
                        GroupName = "Spore Spawn Farming Room Right Zeb",
                        EnemyName = "Zeb",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Spore Spawn Farming Room - Left Door" },
                        FarmCycles = new[] {
                            new FarmCycle {
                                Name = "Crouch over spawn point",
                                CycleFrames = 120,
                            },
                        },
                    },
                },
            },
            #endregion
            #region Waterway
            new Room {
                Name = "SM - Waterway",
                Layout = Room.LayoutFrom(@"
                      XXXXXXX←1"
                    , "SM - Waterway - Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Waterway - Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 1,
                                OpenEnd = 1,
                                UsableComingIn = false,
                            },
                        },
                        CanLeaveCharged = new[] {
                            // Charge in the dry section on the left side, and spark back out.
                            new RunwayCharge {
                                Length = 32,
                                OpenEnd = 1,
                                FramesRemaining = 0,
                                ShinesparkFrames = 75,
                            },
                            new RunwayCharge {
                                Length = 33,
                                OpenEnd = 2,
                                FramesRemaining = 120,
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - Waterway - Item",
                        Type = PlacementType.Visible,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Waterway - Door",
                        To = new[] {
                            new LinkTarget("SM - Waterway - Item", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "Gravity",
                                    //  "SpeedBooster"
                                    //]
                                },
                                // Doable without a short charge, since there are 32 tiles (plus one
                                // open end) to charge it.
                                new Strat {
                                    Name = "Waterway Suitless Spark",
                                    Notable = true,
                                    Requires = null,
                                    //{"canShineCharge": {
                                    //  "usedTiles": 32,
                                    //  "shinesparkFrames": 72,
                                    //  "openEnd": 1
                                    //}}
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Waterway - Item",
                        To = new[] {
                            // Speed blocks are ignored here because it's impossible to reach the
                            // Item without breaking them.
                            new LinkTarget("SM - Waterway - Door"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Waterway - Zeros",
                        EnemyName = "Zero",
                        Quantity = 2,
                        HomeNodes = new[] { "SM - Waterway - Door" },
                    },
                    new Enemy {
                        GroupName = "SM - Waterway - Puyos",
                        EnemyName = "Puyo",
                        Quantity = 3,
                        BetweenNodes = new[] {
                            "SM - Waterway - Door",
                            "SM - Waterway - Item",
                        },
                    },
                    new Enemy {
                        GroupName = "SM - Waterway - Skulteras",
                        EnemyName = "Skultera",
                        Quantity = 2,
                        BetweenNodes = new[] {
                            "SM - Waterway - Door",
                            "SM - Waterway - Item",
                        },
                    },
                },
            },
            #endregion
            #region Brinstar Pink Energy Refill Room
            new Room {
                Name = "SM - Brinstar Pink Energy Refill Room",
                Layout = Room.LayoutFrom(@"
                      X←1"
                    , "SM - Brinstar Pink Energy Refill Room - Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Brinstar Pink Energy Refill Room - Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Utility {
                        Name = "SM - Brinstar Pink Energy Refill Room - Energy Refill",
                        Type = UtilityType.Energy,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Brinstar Pink Energy Refill Room - Door",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Pink Energy Refill Room - Energy Refill"),
                        },
                    },
                    new Link {
                        From = "SM - Brinstar Pink Energy Refill Room - Energy Refill",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Pink Energy Refill Room - Door"),
                        },
                    },
                },
            },
            #endregion
            #region Brinstar Pink Save Room
            new Room {
                Name = "SM - Brinstar Pink Save Room",
                Layout = Room.LayoutFrom(@"
                      X←1"
                    , "SM - Brinstar Pink Save Room - Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Brinstar Pink Save Room - Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Utility {
                        Name = "SM - Brinstar Pink Save Room - Save Station",
                        Type = UtilityType.Save,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Brinstar Pink Save Room - Door",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Pink Save Room - Save Station"),
                        },
                    },
                    new Link {
                        From = "SM - Brinstar Pink Save Room - Save Station",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Pink Save Room - Door"),
                        },
                    },
                },
            },
            #endregion
        };

    }

}
