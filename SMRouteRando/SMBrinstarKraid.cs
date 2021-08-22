using System.Collections.Generic;

namespace SMRouteRando {

    public class SMBrinstarKraid {

        public static IList<Room> Rooms { get; } = new[] {
            #region Warehouse Entrance
            new Room {
                Name = "SM - Warehouse Entrance",
                Layout = Room.LayoutFrom(@"
                      1→XXX←2
                        ↑X
                        3"
                    , "SM - Warehouse Entrance - Left Door"
                    , "SM - Warehouse Entrance - Right Door"
                    , "SM - Warehouse Entrance - Elevator"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Warehouse Entrance - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 13,
                                OpenEnd = 0,
                            },
                            // Must break 3 Super Blocks for this longer runway to be usable.
                            new RunwayDash {
                                Length = 17,
                                OpenEnd = 1,
                                UsableComingIn = false,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "Super",
                                        //  {"ammo": {
                                        //    "type": "Super",
                                        //    "count": 3
                                        //  }}
                                        //]
                                    },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Warehouse Entrance - Right Door",
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
                                Length = 17,
                                FramesRemaining = 120,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Warehouse Entrance - Elevator",
                        Type = TransitionType.Elevator,
                    },
                    new Junction {
                        Name = "SM - Warehouse Entrance - Pit Junction",
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Warehouse Entrance - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Warehouse Entrance - Elevator"),
                        },
                    },
                    new Link {
                        From = "SM - Warehouse Entrance - Elevator",
                        To = new[] {
                            new LinkTarget("SM - Warehouse Entrance - Left Door"),
                            new LinkTarget("SM - Warehouse Entrance - Pit Junction", new[] {
                                // Needs 1 Super with Morph. Needs 3 Supers with nothing at all.
                                new Strat {
                                    Requires = null,
                                    //[ "Super",
                                    //  {"ammo": {
                                    //    "type": "Super",
                                    //    "count": 1
                                    //  }},
                                    //  {"or": [
                                    //    "Morph",
                                    //    {"ammo": {
                                    //      "type": "Super",
                                    //      "count": 2
                                    //    }}
                                    //  ]}
                                    //]
                                },
                                // This strat makes it possible to squeeze through Morphless with just 2 supers.
                                new Strat {
                                    Name = "Kraid Entrance Wiggle",
                                    Notable = true,
                                    Requires = null,
                                    //[ "Super",
                                    //  {"ammo": {
                                    //    "type": "Super",
                                    //    "count": 2
                                    //  }},
                                    //  "canTurnaroundAimCancel"
                                    //]
                                },
                                // Use 2 supers, then squeeze through with a spin jump or down-aim jump.
                                new Strat {
                                    Name = "Kraid Entrance Squeeze",
                                    Notable = true,
                                    Requires = null,
                                    //[ "Super",
                                    //  {"ammo": {
                                    //    "type": "Super",
                                    //    "count": 2
                                    //  }},
                                    //  "canManipulateHitbox"
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Warehouse Entrance - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Warehouse Entrance - Pit Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Warehouse Entrance - Pit Junction",
                        To = new[] {
                            new LinkTarget("SM - Warehouse Entrance - Elevator", new[] {
                                // Needs 1 Super with Morph. Needs 3 Supers with nothing at all.
                                new Strat {
                                    Requires = null,
                                    //[ "Super",
                                    //  {"ammo": {
                                    //    "type": "Super",
                                    //    "count": 1
                                    //  }},
                                    //  {"or": [
                                    //    "Morph",
                                    //    {"ammo": {
                                    //      "type": "Super",
                                    //      "count": 2
                                    //    }}
                                    //  ]}
                                    //]
                                },
                                // Use 2 supers, then squeeze through with a spin jump or down-aim jump.
                                new Strat {
                                    Name = "Kraid Exit Squeeze",
                                    Notable = true,
                                    Requires = null,
                                    //[ "Super",
                                    //  {"ammo": {
                                    //    "type": "Super",
                                    //    "count": 2
                                    //  }},
                                    //  "canManipulateHitbox"
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Warehouse Entrance - Right Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //{"or":[
                                    //  "h_canFly",
                                    //  "HiJump"
                                    //]}
                                },
                                new Strat {
                                    Name = "Kraid Entrance Walljump",
                                    Notable = true,
                                    Requires = null, // ["canWalljump"]
                                },
                            }),
                        },
                    },
                },
            },
            #endregion
            #region Warehouse Zeela Room
            new Room {
                Name = "SM - Warehouse Zeela Room",
                Layout = Room.LayoutFrom(@"
                         3
                      2→X↓
                      1→XX"
                    , "SM - Warehouse Zeela Room - Bottom Left Door"
                    , "SM - Warehouse Zeela Room - Top Left Door"
                    , "SM - Warehouse Zeela Room - Right Vertical Top Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Warehouse Zeela Room - Bottom Left Door",
                        Type = TransitionType.Gray,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 4,
                                OpenEnd = 0,
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Warehouse Zeela Room - Grey Lock",
                                Type = LockType.GameFlag,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["f_DefeatedKraid"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Warehouse Zeela Room - Top Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 5,
                                OpenEnd = 0,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Warehouse Zeela Room - Right Vertical Top Door",
                        Type = TransitionType.Blue,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Warehouse Zeela Room - Top Left Door",
                        To = new[] {
                            new LinkTarget("SM - Warehouse Zeela Room - Bottom Left Door"),
                        },
                    },
                    new Link {
                        From = "SM - Warehouse Zeela Room - Bottom Left Door",
                        To = new[] {
                            new LinkTarget("SM - Warehouse Zeela Room - Top Left Door"),
                            new LinkTarget("SM - Warehouse Zeela Room - Right Vertical Top Door", new[] {
                                new Strat { Requires = null /*["h_canPassBombPassages"]*/ },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Warehouse Zeela Room - Right Vertical Top Door",
                        To = new[] {
                            new LinkTarget("SM - Warehouse Zeela Room - Bottom Left Door", new[] {
                                new Strat { Requires = null /*["h_canPassBombPassages"]*/ },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Warehouse Zeela Room - Top Zeelas",
                        EnemyName = "Zeela",
                        Quantity = 2,
                        HomeNodes = new[] { "SM - Warehouse Zeela Room - Top Left Door" },
                    },
                    new Enemy {
                        GroupName = "SM - Warehouse Zeela Room - Bottom Zeela",
                        EnemyName = "Zeela",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Warehouse Zeela Room - Bottom Left Door" },
                    }
                },
            },
            #endregion
            // Todo: Acceptable name?
            #region Warehouse Closet
            new Room {
                Name = "SM - Warehouse Closet",
                Layout = Room.LayoutFrom(@"
                      X←1"
                    , "SM - Warehouse Closet - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Warehouse Closet - Right Door",
                        Type = TransitionType.Gray,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 0,
                                OpenEnd = 1,
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Warehouse Closet - Grey Lock",
                                Type = LockType.KillEnemies,
                                UnlockStrats = new[] {
                                    // This is a softlock if no means to kill Beetoms are available.
                                    new Strat {
                                        Requires = null,
                                        //{"enemyKill":{
                                        //  "enemies": [
                                        //    [ "Beetom", "Beetom", "Beetom", "Beetom" ]
                                        //  ]
                                        //}}
                                    },
                                },
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - Warehouse Closet - Item",
                        Type = PlacementType.Hidden,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Warehouse Closet - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Warehouse Closet - Item"),
                        },
                    },
                    new Link {
                        From = "SM - Warehouse Closet - Item",
                        To = new[] {
                            new LinkTarget("SM - Warehouse Closet - Right Door"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Warehouse Closet - Beetoms",
                        EnemyName = "Beetom",
                        Quantity = 4,
                        HomeNodes = new[] { "SM - Warehouse Closet - Item" },
                    }
                },
            },
            #endregion
            #region Warehouse Kihunter Room
            new Room {
                Name = "SM - Warehouse Kihunter Room",
                Layout = Room.LayoutFrom(@"
                      XXXX←1
                      ↑X←2
                      3"
                    , "SM - Warehouse Kihunter Room - Top Right Door"
                    , "SM - Warehouse Kihunter Room - Bottom Right Door"
                    , "SM - Warehouse Kihunter Room - Left Vertical Bottom Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Warehouse Kihunter Room - Top Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 1,
                            },
                        },
                        CanLeaveCharged = new[] {
                            // MustOpenDoorFirst set to false because the requirements of the
                            // pathToDoor (going Left Vertical Bottom Door -> Top Right Door)
                            // already cover getting to the door and back. Besides, it's also
                            // possible to shoot the door before sparking out, if trickier.
                            new RunwayCharge {
                                Length = 31,
                                OpenEnd = 1,
                                FramesRemaining = 0,
                                ShinesparkFrames = 15,
                                InitiateRemotely = new() {
                                    InitiateAt = "SM - Warehouse Kihunter Room - Left Vertical Bottom Door",
                                    MustOpenDoorFirst = false,
                                    PathToDoor = new[] {
                                        new PathStep("SM - Warehouse Kihunter Room - Top Right Door", new[] { "Base" }),
                                    },
                                },
                                Strats = new[] {
                                    // Generate a charge on the left side and carry it through the
                                    // morph tunnel and out the Top Right Door.
                                    new Strat {
                                        Name = "Warehouse Kihunter Room Tunnel Charge",
                                        Notable = true,
                                        Requires = null,
                                        //{"resetRoom":{
                                        //  "nodes": [1, 3],
                                        //  "nodesToAvoid": [2]
                                        //}}
                                    },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Warehouse Kihunter Room - Bottom Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 8,
                                OpenEnd = 0,
                            },
                        },
                        CanLeaveCharged = new[] {
                            new RunwayCharge {
                                Length = 25,
                                OpenEnd = 0,
                                FramesRemaining = 0,
                                ShinesparkFrames = 20,
                                InitiateRemotely = new() {
                                    InitiateAt = "SM - Warehouse Kihunter Room - Left Vertical Bottom Door",
                                    MustOpenDoorFirst = false,
                                    PathToDoor = new[] {
                                        new PathStep("SM - Warehouse Kihunter Room - Bottom Right Door", new[] { "Base" }),
                                    },
                                },
                                Strats = new[] {
                                    // Charge a spark, then break the shot blocks, drop through,
                                    // and spark out the bottom right door.
                                    new Strat {
                                        Name = "Warehouse Kihunter Room Bottom Spark Out",
                                        Notable = true,
                                        Requires = null,
                                        //{"resetRoom":{
                                        //  "nodes": [1, 3],
                                        //  "nodesToAvoid": [2]
                                        //}}
                                    },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Warehouse Kihunter Room - Left Vertical Bottom Door",
                        Type = TransitionType.Blue,
                        CanLeaveCharged = new[] {
                            new RunwayCharge {
                                Length = 27,
                                OpenEnd = 2,
                                FramesRemaining = 120,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //{"resetRoom":{
                                        //  "nodes": [1, 3],
                                        //  "nodesToAvoid": [2]
                                        //}}
                                    },
                                },
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - Warehouse Kihunter Room - Item",
                        Type = PlacementType.Hidden,
                    },
                },
                Obstacles = new[] {
                    new Obstacle {
                        Name = "Power Bomb Blocks",
                        Type = ObstacleType.Inanimate,
                    },
                    new Obstacle {
                        Name = "Bomb Block",
                        Type = ObstacleType.Inanimate,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Warehouse Kihunter Room - Left Vertical Bottom Door",
                        To = new[] {
                            new LinkTarget("SM - Warehouse Kihunter Room - Bottom Right Door"),
                            new LinkTarget("SM - Warehouse Kihunter Room - Top Right Door", new[] {
                                new Strat {
                                    Requires = null, // ["Morph"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Bomb Block",
                                            Requires = null, // ["h_canPassBombPassages"]
                                        },
                                    },
                                },
                                // The biggest factor for the short charge here isn't so much the
                                // available room as the speed attained. 17 tiles is a guess, it
                                // might be doable with a bit more. But it's a really obnoxious
                                // strat anyway, and much harder than the sum of its techs, so
                                // tightening up the short charge requirement feels like the right
                                // move.
                                new Strat {
                                    Name = "Warehouse Kihunter Speedball",
                                    Notable = true,
                                    Requires = null, // ["Morph"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Bomb Block",
                                            Requires = null,
                                            //[ "canMockball",
                                            //  {"canShineCharge": {
                                            //    "usedTiles": 17,
                                            //    "shinesparkFrames": 0,
                                            //    "openEnd": 0
                                            //  }}
                                            //]
                                        },
                                    },
                                },
                            }),
                            new LinkTarget("SM - Warehouse Kihunter Room - Item", new[] {
                                new Strat {
                                    Requires = null, // ["Morph"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Power Bomb Blocks",
                                            Requires = null,
                                            //[ "PowerBomb",
                                            //  {"ammo": {
                                            //    "type": "PowerBomb",
                                            //    "count": 1
                                            //  }}
                                            //]
                                            AdditionalObstacles = new[] { "Bomb Block" },
                                        },
                                    },
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Warehouse Kihunter Room - Bottom Right Door",
                        To = new[] {
                            new LinkTarget("SM - Warehouse Kihunter Room - Left Vertical Bottom Door"),
                        },
                    },
                    new Link {
                        From = "SM - Warehouse Kihunter Room - Top Right Door",
                        To = new[] {
                            // FIXME Possible speedball here depending on adjacent room?
                            new LinkTarget("SM - Warehouse Kihunter Room - Left Vertical Bottom Door", new[] {
                                new Strat {
                                    Name = "Bomb the Block",
                                    Requires = null, // ["Morph"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Bomb Block",
                                            Requires = null, // ["Bombs"]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Power Bomb the Block",
                                    Requires = null, // ["Morph"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Bomb Block",
                                            Requires = null,
                                            //[ "PowerBomb",
                                            //  {"ammo": {
                                            //    "type": "PowerBomb",
                                            //    "count": 1
                                            //  }}
                                            //]
                                            AdditionalObstacles = new[] { "Power Bomb Blocks" },
                                        },
                                    },
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Warehouse Kihunter Room - Item",
                        To = new[] {
                            new LinkTarget("SM - Warehouse Kihunter Room - Left Vertical Bottom Door", new[] {
                                // Reaching Item means Bomb Block is open.
                                new Strat { Requires = null /*["Morph"]*/ },
                            }),
                            new LinkTarget("SM - Warehouse Kihunter Room - Top Right Door", new[] {
                                new Strat { Requires = null /*["Morph"]*/ },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Warehouse Kihunter Room - Kihunters",
                        EnemyName = "Kihunter (green)",
                        Quantity = 4,
                        HomeNodes = new[] { "SM - Warehouse Kihunter Room - Left Vertical Bottom Door" },
                    }
                },
            },
            #endregion
            #region Baby Kraid Room
            new Room {
                Name = "SM - Baby Kraid Room",
                Layout = Room.LayoutFrom(@"
                      1→XXXXXX←2"
                    , "SM - Baby Kraid Room - Left Door"
                    , "SM - Baby Kraid Room - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Baby Kraid Room - Left Door",
                        Type = TransitionType.Gray,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 2,
                                OpenEnd = 1,
                                UsableComingIn = false,
                            },
                        },
                        CanLeaveCharged = new[] {
                            // We won't worry about obstacles as requirements here, because
                            // achieving blue suit will destroy them anyhow.
                            new RunwayCharge {
                                Length = 33,
                                OpenEnd = 2,
                                FramesRemaining = 120,
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Baby Kraid Room - Left Grey Lock",
                                Type = LockType.KillEnemies,
                                UnlockStrats = new[] {
                                    // Enemies can be killed by going between Left Door and Right Door.
                                    new Strat {
                                        Obstacles = new[] {
                                            new Strat.Obstacle {
                                                Name = "Pirates & Mini Kraid",
                                                Requires = null, // ["never"]
                                            },
                                        },
                                    },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Baby Kraid Room - Right Door",
                        Type = TransitionType.Gray,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 1,
                            },
                        },
                        CanLeaveCharged = new[] {
                            // We won't worry about obstacles as requirements here, because
                            // achieving blue suit will destroy them anyhow.
                            new RunwayCharge {
                                Length = 33,
                                OpenEnd = 2,
                                FramesRemaining = 120,
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "Baby Kraid Right Grey Lock (to Eye Room)",
                                Type = LockType.KillEnemies,
                                UnlockStrats = new[] {
                                    // Enemies can be killed by going between Left Door and Right Door.
                                    new Strat {
                                        Obstacles = new[] {
                                            new Strat.Obstacle {
                                                Name = "Pirates & Mini Kraid",
                                                Requires = null, // ["never"]
                                            },
                                        },
                                    },
                                },
                            },
                        },
                    },
                },
                Obstacles = new[] {
                    new Obstacle {
                        Name = "Pirates & Mini Kraid",
                        Type = ObstacleType.Enemies,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Baby Kraid Room - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Baby Kraid Room - Right Door", new[] {
                                new Strat {
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Pirates & Mini Kraid",
                                            Requires = null,
                                            //{"or": [
                                            //  "SpeedBooster",
                                            //  {"enemyKill":{
                                            //    "enemies": [
                                            //      [ "Green Space Pirate (standing)",
                                            //        "Green Space Pirate (standing)",
                                            //        "Green Space Pirate (standing)"
                                            //      ],
                                            //      ["Mini-Kraid"]
                                            //    ]
                                            //  }}
                                            //]}
                                        },
                                    },
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Baby Kraid Room - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Baby Kraid Room - Left Door", new[] {
                                new Strat {
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Pirates & Mini Kraid",
                                            Requires = null,
                                            //{"or": [
                                            //  "SpeedBooster",
                                            //  {"enemyKill":{
                                            //    "enemies": [
                                            //      [ "Green Space Pirate (standing)",
                                            //        "Green Space Pirate (standing)",
                                            //        "Green Space Pirate (standing)"
                                            //      ],
                                            //      ["Mini-Kraid"]
                                            //    ]
                                            //  }}
                                            //]}
                                        },
                                    },
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Baby Kraid Room - Pirates",
                        EnemyName = "Green Space Pirate (standing)",
                        Quantity = 3,
                        HomeNodes = new[] { "SM - Baby Kraid Room - Left Door" },
                    },
                    new Enemy {
                        GroupName = "SM - Baby Kraid Room - Mini-Kraid",
                        EnemyName = "Mini-Kraid",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Baby Kraid Room - Right Door" },
                    },
                },
            },
            #endregion
            // Todo: Better name?
            #region Warehouse Eye Door Room
            new Room {
                Name = "SM - Warehouse Eye Door Room",
                Layout = Room.LayoutFrom(@"
                        X←2
                      1→XX←3"
                    , "SM - Warehouse Eye Door Room - Left Door"
                    , "SM - Warehouse Eye Door Room - Top Right Door"
                    , "SM - Warehouse Eye Door Room - Bottom Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Warehouse Eye Door Room - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 4,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Warehouse Eye Door Room - Top Right Door",
                        Type = TransitionType.Green,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 1,
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Warehouse Eye Door Room - Green Lock",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenGreenDoors"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Warehouse Eye Door Room - Bottom Right Door",
                        Type = TransitionType.Gedora,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 2,
                                OpenEnd = 1,
                                UsableComingIn = false,
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - SM - Warehouse Eye Door Room - Eye Lock",
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
                        From = "SM - Warehouse Eye Door Room - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Warehouse Eye Door Room - Top Right Door"),
                            new LinkTarget("SM - Warehouse Eye Door Room - Bottom Right Door"),
                        },
                    },
                    new Link{
                        From = "SM - Warehouse Eye Door Room - Top Right Door",
                        To = new[] {
                            new LinkTarget("SM - Warehouse Eye Door Room - Left Door"),
                        },
                    },
                    new Link {
                        From = "SM - Warehouse Eye Door Room - Bottom Right Door",
                        To = new[] {
                            new LinkTarget("SM - Warehouse Eye Door Room - Left Door"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Warhouse Eye Door Room - Zeb",
                        EnemyName = "Zeb",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Warehouse Eye Door Room - Left Door" },
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
            #region Kraid Room
            new Room {
                Name = "SM - Kraid Room",
                Layout = Room.LayoutFrom(@"
                        XX
                      1→XX←2"
                    , "SM - Kraid Room - Left Door"
                    , "SM - Kraid Room - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Kraid Room - Left Door",
                        Type = TransitionType.Gray,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 1,
                            },
                        },
                        CanLeaveCharged = new[] {
                            new RunwayCharge {
                                Length = 22,
                                OpenEnd = 0,
                                FramesRemaining = 90,
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Kraid Room - Left Grey Lock",
                                Type = LockType.GameFlag,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["f_DefeatedKraid"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Kraid Room - Right Door",
                        Type = TransitionType.Gray,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 1,
                            },
                        },
                        CanLeaveCharged = new[] {
                            new RunwayCharge {
                                Length = 22,
                                OpenEnd = 0,
                                FramesRemaining = 90,
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Kraid Room - Right Grey Lock",
                                Type = LockType.GameFlag,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["f_DefeatedKraid"]*/ },
                                },
                            },
                        },
                    },
                    new Event {
                        Name = "SM - Kraid Room - Kraid",
                        Type = EventType.Boss,
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Kraid Room - Kraid Fight",
                                Type = LockType.BossFight,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["Charge"]*/ },
                                    // No ammo requirements because Missiles are farmable.
                                    new Strat { Requires = null /*["Missile"]*/ },
                                    // No ammo requirements because Supers are farmable, even though
                                    // the drop rate is low.
                                    new Strat { Requires = null /*["Super"]*/ },
                                },
                            },
                        },
                        Yields = new[] { "f_DefeatedKraid" },
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Kraid Room - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Kraid Room - Kraid"),
                        },
                    },
                    new Link {
                        From = "SM - Kraid Room - Right Door",
                        To = new[] {
                            // You can actually do the Kraid fight normally if entering from the
                            // right door.
                            new LinkTarget("SM - Kraid Room - Kraid"),
                        },
                    },
                    new Link {
                        From = "SM - Kraid Room - Kraid",
                        To = new[] {
                            // Door is reachable mid-fight but locked.
                            new LinkTarget("SM - Kraid Room - Left Door"),
                            // Door is not reachable mid-fight.
                            new LinkTarget("SM - Kraid Room - Right Door", new[] {
                                new Strat { Requires = null /*["f_DefeatedKraid"]*/ },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Kraid Room - Kraid",
                        EnemyName = "Kraid",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Kraid Room - Kraid" },
                        StopSpawn = null, // ["f_DefeatedKraid"]
                    }
                },
            },
            #endregion
            // Todo: Acceptable name?
            #region Brinstar Kraid Prize Room
            new Room {
                Name = "SM - Brinstar Kraid Prize Room",
                Layout = Room.LayoutFrom(@"
                      1→X"
                    , "SM - Brinstar Kraid Prize Room - Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Brinstar Kraid Prize Room - Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 1,
                                OpenEnd = 1,
                                UsableComingIn = false,
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - Brinstar Kraid Prize Room - Item",
                        Type = PlacementType.Chozo,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Brinstar Kraid Prize Room - Door",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Kraid Prize Room - Item"),
                        },
                    },
                    new Link {
                        From = "SM - Brinstar Kraid Prize Room - Item",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Kraid Prize Room - Door"),
                        },
                    },
                },
            },
            #endregion
            #region Brinstar Kraid Save Room
            new Room {
                Name = "SM - Brinstar Kraid Save Room",
                Layout = Room.LayoutFrom(@"
                      1→X"
                    , "SM - Brinstar Kraid Save Room - Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Brinstar Kraid Save Room - Door",
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
                        Name = "SM - Brinstar Kraid Save Room - Save Station",
                        Type = UtilityType.Save,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Brinstar Kraid Save Room - Door",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Kraid Save Room - Save Station"),
                        },
                    },
                    new Link {
                        From = "SM - Brinstar Kraid Save Room - Save Station",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Kraid Save Room - Door"),
                        },
                    },
                },
            },
            #endregion
            #region Brinstar Kraid Recharge Room
            new Room {
                Name = "SM - Brinstar Kraid Recharge Room",
                Layout = Room.LayoutFrom(@"
                      1→X"
                    , "SM - Brinstar Kraid Recharge Room - Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Brinstar Kraid Recharge Room - Door",
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
                        Name = "SM - Brinstar Kraid Recharge Room - Energy Refill",
                        Type = UtilityType.Energy,
                    },
                    new Utility {
                        Name = "SM - Brinstar Kraid Recharge Room - Missile Refill",
                        Type = UtilityType.Missile,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Brinstar Kraid Recharge Room - Door",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Kraid Recharge Room - Energy Refill"),
                        },
                    },
                    new Link {
                        From = "SM - Brinstar Kraid Recharge Room - Energy Refill",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Kraid Recharge Room - Door"),
                            new LinkTarget("SM - Brinstar Kraid Recharge Room - Missile Refill"),
                        },
                    },
                    new Link {
                        From = "SM - Brinstar Kraid Recharge Room - Missile Refill",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Kraid Recharge Room - Energy Refill"),
                        },
                    },
                },
            },
            #endregion
        };

    }

}
