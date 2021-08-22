using System.Collections.Generic;

namespace SMRouteRando {

    public class SMNorfairUpperEast {

        public static IList<Room> Rooms { get; } = new[] {
            #region Cathedral Entrance
            new Room {
                Name = "SM - Cathedral Entrance",
                Layout = Room.LayoutFrom(@"
                      1→XXX←2
                        XXX"
                    , "SM - Cathedral Entrance - Left Door"
                    , "SM - Cathedral Entrance - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Cathedral Entrance - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 4,
                                OpenEnd = 0,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"heatFrames": 85}
                                        //]
                                    },
                                },
                            },
                        },
                        CanLeaveCharged = new[] {
                            // The extra amount of reqs for making this a suitless possibility is
                            // just too much.
                            new RunwayCharge {
                                Length = 33,
                                FramesRemaining = 0,
                                ShinesparkFrames = 10,
                                OpenEnd = 2,
                                Strats = new[] {
                                    new Strat {
                                        Name = "Cathedral Entrance Spark Out Left",
                                        Notable = true,
                                        Requires = null,
                                        //[ "HiJump",
                                        //  "h_heatProof"
                                        //]
                                    },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Cathedral Entrance - Right Door",
                        Type = TransitionType.Red,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 4,
                                OpenEnd = 1,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"heatFrames": 85}
                                        //]
                                    },
                                },
                            },
                        },
                        CanLeaveCharged = new[] {
                            // The extra amount of reqs for making this a suitless possibility is
                            // just too much.
                            new RunwayCharge {
                                Length = 33,
                                FramesRemaining = 0,
                                ShinesparkFrames = 10,
                                OpenEnd = 2,
                                Strats = new[] {
                                    new Strat {
                                        Name = "Cathedral Entrance Spark Out Right",
                                        Notable = true,
                                        Requires = null,
                                        //[ "HiJump",
                                        //  "h_heatProof"
                                        //]
                                    },
                                },
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "Cathedral Entrance Red Lock (to Cathedral)",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenRedDoors"]*/ },
                                },
                            },
                        },
                    },
                    new Junction {
                        Name = "SM - Cathedral Entrance - Bottom Left Junction",
                    },
                    // This node is only considered reached if the enemy is clear of platforms, to
                    // setup a SpeedBooster strat.
                    new Junction {
                        Name = "SM - Cathedral Entrance - Cleared Platform Junction",
                    },
                    new Junction {
                        Name = "SM - Cathedral Entrance - Bottom Right Junction",
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Cathedral Entrance - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Cathedral Entrance - Bottom Left Junction", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 150}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Cathedral Entrance - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Cathedral Entrance - Bottom Right Junction", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 150}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Cathedral Entrance - Bottom Left Junction",
                        To = new[] {
                            new LinkTarget("SM - Cathedral Entrance - Left Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 300}
                                    //]
                                },
                            }),
                            // This link goes straight from Bottom Left Junction to Right Door
                            // because waiting for the Sova is the same time, regardless of how
                            // quickly you can travel through the other nodes.
                            // FIXME there is a morph dboost strat that works here. What tech
                            // should that use, and what heat frame count?
                            new LinkTarget("SM - Cathedral Entrance - Right Door", new[] {
                                new Strat {
                                    Name = "Frozen Sova",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "canUseFrozenEnemies",
                                    //  {"heatFrames": 950}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Cathedral Entrance - Cleared Platform Junction", new[] {
                                new Strat {
                                    Name = "Plasma Kill",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "Plasma",
                                    //  {"heatFrames": 100}
                                    //]
                                },
                                new Strat {
                                    Name = "Screw Kill",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "ScrewAttack",
                                    //  {"heatFrames": 100}
                                    //]
                                },
                                new Strat {
                                    Name = "Ammo Kill",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"enemyKill":{
                                    //    "enemies": [
                                    //      [
                                    //        "Sm. Dessgeega",
                                    //        "Sm. Dessgeega"
                                    //      ]
                                    //    ],
                                    //    "explicitWeapons": [ "Missile", "Super" ]
                                    //  }},
                                    //  { "heatFrames": 100}
                                    //]
                                },
                                new Strat {
                                    Name = "Intermediate Beam Kill",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"or":[
                                    //    "Wave",
                                    //    "Spazer"
                                    //  ]},
                                    //  { "heatFrames": 200}
                                    //]
                                },
                                new Strat {
                                    Name = "Power Beam Kill",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 350}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Cathedral Entrance - Bottom Right Junction", new[] {
                                new Strat {
                                    Name = "Mockball Through",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "canMockball",
                                    //  {"heatFrames": 100}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Cathedral Entrance - Cleared Platform Junction",
                        To = new[] {
                            new LinkTarget("SM - Cathedral Entrance - Right Door", new[] {
                                new Strat {
                                    Name = "Shinespark",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"canShineCharge": {
                                    //    "usedTiles": 33,
                                    //    "shinesparkFrames": 17,
                                    //    "openEnd": 2
                                    //  }},
                                    //  {"heatFrames": 400}
                                    //]
                                },
                                new Strat {
                                    Name = "Speedjump",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "canTrickyDashJump",
                                    //  {"heatFrames": 150}
                                    //]
                                },
                            }),
                            // Cleared Platform Junction is considered equivalent to
                            // Bottom Right Junction (though Bottom Right Junction isn't equivalent
                            // to Cleared Platform Junction).
                            new LinkTarget("SM - Cathedral Entrance - Bottom Right Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Cathedral Entrance - Bottom Right Junction",
                        To = new[] {
                            new LinkTarget("SM - Cathedral Entrance - Right Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"or":[
                                    //    "HiJump",
                                    //    "SpaceJump"
                                    //  ]},
                                    //  {"heatFrames": 150}
                                    //]
                                },
                                new Strat {
                                    Name = "MidAir SpringBall",
                                    Requires = null,
                                    //[ "canSpringBallJumpMidAir",
                                    //  {"heatFrames": 200}
                                    //]
                                },
                                // Does this heat frame count required a midair IBJ? If so, should
                                // we have two separate strats?
                                new Strat {
                                    Name = "IBJ",
                                    Requires = null,
                                    //[ "canIBJ",
                                    //  { "heatFrames": 500}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Cathedral Entrance - Bottom Left Junction", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 350}
                                    //]
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Cathedral Entrance - Sovas",
                        EnemyName = "Sova",
                        Quantity = 4,
                        HomeNodes = new[] { "SM - Cathedral Entrance - Bottom Left Junction" },
                        DropRequires = null, // ["h_heatProof"]
                    },
                    new Enemy {
                        GroupName = "SM - Cathedral Entrance - Small Dessgeegas",
                        EnemyName = "Sm. Dessgeega",
                        Quantity = 2,
                        BetweenNodes = new[] {
                            "SM - Cathedral Entrance - Bottom Left Junction",
                            "SM - Cathedral Entrance - Cleared Platform Junction",
                        },
                        DropRequires = null, // ["h_heatProof"]
                    },
                },
            },
            #endregion
            #region Cathedral
            new Room {
                Name = "SM - Cathedral",
                Layout = Room.LayoutFrom(@"
                      1→XXX
                        XXX←2"
                    , "SM - Cathedral - Left Door"
                    , "SM - Cathedral - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Cathedral - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 1,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"heatFrames": 75}
                                        //]
                                    },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Cathedral - Right Door",
                        Type = TransitionType.Green,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 5,
                                GentleDownTiles = 2,
                                StartingDownTiles = 2,
                                OpenEnd = 0,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"heatFrames": 90}
                                        //]
                                    },
                                },
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Cathedral - Green Lock",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenGreenDoors"]*/ },
                                },
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - Cathedral - Item",
                        Type = PlacementType.Hidden,
                    },
                    new Junction {
                        Name = "SM - Cathedral - Central Junction",
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Cathedral - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Cathedral - Central Junction", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 300}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Cathedral - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Cathedral - Central Junction", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 250}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Cathedral - Item",
                        To = new[] {
                            new LinkTarget("SM - Cathedral - Central Junction", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 200},
                                    //  {"lavaFrames": 60}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Cathedral - Central Junction",
                        To = new[] {
                            new LinkTarget("SM - Cathedral - Left Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 350}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Cathedral - Right Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 250}
                                    //]
                                },
                            }),
                            // FIXME Apparently there's a way to get this without Morph?
                            new LinkTarget("SM - Cathedral - Item", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "Morph",
                                    //  { "heatFrames": 350},
                                    //  { "lavaFrames": 60},
                                    //  {"enemyDamage": {
                                    //    "enemy": "Geruta",
                                    //    "type": "contact",
                                    //    "hits": 1
                                    //  }}
                                    //]
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "Cathedral Left Sovas",
                        EnemyName = "Sova",
                        Quantity = 3,
                        HomeNodes = new[] { "SM - Cathedral - Left Door" },
                        DropRequires = null, // ["h_heatProof"]
                    },
                    new Enemy {
                        GroupName = "Cathedral Left Geruta",
                        EnemyName = "Geruta",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Cathedral - Left Door" },
                        DropRequires = null, // ["h_heatProof"]
                    },
                    new Enemy {
                        GroupName = "Cathedral Right Sova",
                        EnemyName = "Sova",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Cathedral - Right Door" },
                        DropRequires = null, // ["h_heatProof"]
                    },
                    new Enemy {
                        GroupName = "Cathedral Right Gerutas",
                        EnemyName = "Geruta",
                        Quantity = 2,
                        HomeNodes = new[] { "SM - Cathedral - Central Junction" },
                        DropRequires = null, // ["h_heatProof"]
                    },
                },
            },
            #endregion
            #region Rising Tide
            new Room {
                Name = "SM - Rising Tide",
                Layout = Room.LayoutFrom(@"
                      1→XXXXX←2"
                    , "SM - Rising Tide - Left Door"
                    , "SM - Rising Tide - Right Door"
                ),
                Nodes = new[] {
                    new Transition {
                        Name = "SM - Rising Tide - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 1,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"heatFrames": 75}
                                        //]
                                    },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Rising Tide - Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 1,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  { "heatFrames": 75}
                                        //]
                                    },
                                },
                            },
                        },
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Rising Tide - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Rising Tide - Right Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 550}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Rising Tide - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Rising Tide - Left Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 650}
                                    //]
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Rising Tide - Sovas",
                        EnemyName = "Sova",
                        Quantity = 5,
                        BetweenNodes = new[] {
                            "SM - Rising Tide - Left Door",
                            "SM - Rising Tide - Right Door",
                        },
                        DropRequires = null, // ["h_heatProof"]
                    },
                    new Enemy {
                        GroupName = "SM - Rising Tide - Dragons",
                        EnemyName = "Dragon",
                        Quantity = 4,
                        BetweenNodes = new[] {
                            "SM - Rising Tide - Left Door",
                            "SM - Rising Tide - Right Door",
                        },
                        DropRequires = null,
                        //[ "h_heatProof",
                        //  {"or": [
                        //    "Gravity",
                        //    "Grapple"
                        //  ]}
                        //]
                    },
                    new Enemy {
                        GroupName = "SM - Rising Tide - Squeepts",
                        EnemyName = "Squeept",
                        Quantity = 2,
                        BetweenNodes = new[] {
                            "SM - Rising Tide - Left Door",
                            "SM - Rising Tide - Right Door",
                        },
                        DropRequires = null, // ["h_heatProof"]
                    },
                },
            },
            #endregion
            #region Frog Speedway
            new Room {
                Name = "SM - Frog Speedway",
                Layout = Room.LayoutFrom(@"
                      1→XXXXXXXX←2"
                    , "SM - Frog Speedway - Left Door"
                    , "SM - Frog Speedway - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Frog Speedway - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 33,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Frog Speedway - Right Door",
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
                        From = "SM - Frog Speedway - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Frog Speedway - Right Door", new[] {
                                new Strat { Requires = null /*["SpeedBooster"]*/ },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Frog Speedway - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Frog Speedway - Left Door", new[] {
                                new Strat { Requires = null /*["SpeedBooster"]*/ },
                                // This room has a bunch of offscreen shot blocks, and shooting enough
                                // of them with wave + spazer or plasma allows you to run through the
                                // speed blocks when going right to left.
                                new Strat {
                                    Name = "Frog Speedway Clip",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canShotBlockOverload",
                                    //  {"or":[
                                    //    "Spazer",
                                    //    "Plasma"
                                    //  ]}
                                    //]
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Frog Speedway - Left Beetoms",
                        EnemyName = "Beetom",
                        Quantity = 3,
                        HomeNodes = new[] { "SM - Frog Speedway - Left Door" },
                    },
                    new Enemy {
                        GroupName = "SM - Frog Speedway - Right Beetoms",
                        EnemyName = "Beetom",
                        Quantity = 3,
                        BetweenNodes = new[] {
                            "SM - Frog Speedway - Left Door",
                            "SM - Frog Speedway - Right Door",
                        },
                    },
                },
            },
            #endregion
            // Todo: Acceptable name?
            #region Crossroads Farming Room
            new Room {
                Name = "SM - Crossroads Farming Room",
                Layout = Room.LayoutFrom(@"
                      2→XX←3
                      1→XX"
                    , "SM - Crossroads Farming Room - Bottom Left Door"
                    , "SM - Crossroads Farming Room - Top Left Door"
                    , "SM - Crossroads Farming Room - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Crossroads Farming Room - Bottom Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 4,
                                OpenEnd = 0,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"heatFrames": 85}
                                        //]
                                    },
                                },
                            },
                            // With Gate Open.
                            new RunwayDash {
                                Length = 10,
                                OpenEnd = 1,
                                UsableComingIn = false,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"heatFrames": 130}
                                        //]
                                    },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Crossroads Farming Room - Top Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 11,
                                OpenEnd = 1,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"heatFrames": 135}
                                        //]
                                    },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Crossroads Farming Room - Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 11,
                                OpenEnd = 1,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"heatFrames": 135}
                                        //]
                                    },
                                },
                            },
                        },
                    },
                    new Junction {
                        Name = "SM - Crossroads Farming Room - Central Top Junction",
                    },
                    new Junction {
                        Name = "SM - Crossroads Farming Room - Central Bottom Junction",
                    },
                },
                Obstacles = new[] {
                    new Obstacle {
                        Name = "Blue Gate",
                        Type = ObstacleType.Inanimate,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Crossroads Farming Room - Top Left Door",
                        To = new[] {
                            new LinkTarget("SM - Crossroads Farming Room - Central Top Junction", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 75}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Crossroads Farming Room - Bottom Left Door",
                        To = new[] {
                            new LinkTarget("SM - Crossroads Farming Room - Central Bottom Junction", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 120}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Blue Gate",
                                            Requires = null,
                                            //{"heatFrames": 30}
                                        },
                                    }
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Crossroads Farming Room - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Crossroads Farming Room - Central Top Junction", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 75}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Crossroads Farming Room - Central Top Junction",
                        To = new[] {
                            new LinkTarget("SM - Crossroads Farming Room - Top Left Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 75}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Crossroads Farming Room - Right Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 75}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Crossroads Farming Room - Central Bottom Junction", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 100}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Crossroads Farming Room - Central Bottom Junction",
                        To = new[] {
                            new LinkTarget("SM - Crossroads Farming Room - Bottom Left Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 120}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Blue Gate",
                                            Requires = null,
                                            //[ {"heatFrames": 30},
                                            //  "Wave"
                                            //]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Gate Glitch",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 120}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Blue Gate",
                                            Requires = null, // ["canHeatedGateGlitch"]
                                        },
                                    },
                                },
                            }),
                            new LinkTarget("SM - Crossroads Farming Room - Central Top Junction", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 125}
                                    //]
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Crossroads Farming Room - Fune",
                        EnemyName = "Fune",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Crossroads Farming Room - Central Bottom Junction" },
                        DropRequires = null, // ["h_heatProof"]
                    },
                    // Can't be farmed quite as quickly as other spots without requirements.
                    new Enemy {
                        GroupName = "SM - Crossroads Farming Room - Gamets",
                        EnemyName = "Gamet",
                        Quantity = 5,
                        HomeNodes = new[] { "SM - Crossroads Farming Room - Central Bottom Junction" },
                        FarmCycles = new[] {
                            // Just crouching over them is slower because they have to rise a bit after spawning.
                            new FarmCycle {
                                Name = "Gamet down shots",
                                CycleFrames = 120,
                                Requires = null,
                                //[ "h_canNavigateHeatRooms",
                                //  {"heatFrames": 120}
                                //]
                            },
                        },
                    },
                },
            },
            #endregion
            #region Purple Shaft
            new Room {
                Name = "SM - Purple Shaft",
                Layout = Room.LayoutFrom(@"
                      1
                      ↓
                      X
                      X←2
                      X←3"
                    , "SM - Purple Shaft - Top Door"
                    , "SM - Purple Shaft - Top Right Door"
                    , "SM - Purple Shaft - Bottom Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Purple Shaft - Top Door",
                        Type = TransitionType.Blue,
                    },
                    new Transition {
                        Name = "SM - Purple Shaft - Top Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 1,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"heatFrames": 75}
                                        //]
                                    },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Purple Shaft - Bottom Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 12,
                                OpenEnd = 0,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"heatFrames": 140}
                                        //]
                                    },
                                },
                            },
                        },
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Purple Shaft - Top Door",
                        To = new[] {
                            new LinkTarget("SM - Purple Shaft - Top Right Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 150}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Purple Shaft - Top Right Door",
                        To = new[] {
                            new LinkTarget("SM - Purple Shaft - Top Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 250}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Purple Shaft - Bottom Right Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 150}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Purple Shaft - Bottom Right Door",
                        To = new[] {
                            new LinkTarget("SM - Purple Shaft - Top Right Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 200}
                                    //]
                                },
                            }),
                        },
                    },
                },
            },
            #endregion
            #region Purple Farming Room
            new Room {
                Name = "SM - Purple Farming Room",
                Layout = Room.LayoutFrom(@"
                      1→X"
                    , "SM - Purple Farming Room - Door"
                    , "SM - Purple Farming Room - Farm Spot"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Purple Farming Room - Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 5,
                                GentleUpTiles = 1,
                                OpenEnd = 0,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"heatFrames": 90}
                                        //]
                                    },
                                },
                            },
                            // With no Enemies.
                            // Involves leaving some drops hanging after killing the Gamets so they
                            // don't respawn.
                            new RunwayDash {
                                Length = 12,
                                GentleUpTiles = 1,
                                GentleDownTiles = 3,
                                StartingDownTiles = 2,
                                OpenEnd = 0,
                                UsableComingIn = false,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"heatFrames": 250}
                                        //]
                                    },
                                },
                            },
                        },
                    },
                    new Junction {
                        Name = "SM - Purple Farming Room - Farm Spot",
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Purple Farming Room - Door",
                        To = new[] {
                            new LinkTarget("SM - Purple Farming Room - Farm Spot", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 50}
                                    //]
                                },
                            }),
                        }
                    },
                    new Link {
                        From = "SM - Purple Farming Room - Farm Spot",
                        To = new[] {
                            new LinkTarget("SM - Purple Farming Room - Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 50}
                                    //]
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Purple Farming Room - Gamets",
                        EnemyName = "Gamet",
                        Quantity = 5,
                        HomeNodes = new[] { "SM - Purple Farming Room - Farm Spot" },
                        FarmCycles = new[] {
                            new FarmCycle {
                                Name = "Crouch over Gamets",
                                CycleFrames = 120,
                                Requires = null,
                                //[ "h_canNavigateHeatRooms",
                                //  {"heatFrames": 120}
                                //]
                            },
                        },
                    },
                },
            },
            #endregion
            #region Bubble Mountain
            new Room {
                Name = "SM - Bubble Mountain",
                Layout = Room.LayoutFrom(@"
                      4→XX←5
                      3→XX←6
                      2→XX
                      1→XX
                        ↑
                        7"
                    , "SM - Bubble Mountain - Bottom Left Door"
                    , "SM - Bubble Mountain - Middle Bottom Left Door"
                    , "SM - Bubble Mountain - Middle Top Left Door"
                    , "SM - Bubble Mountain - Top Left Door"
                    , "SM - Bubble Mountain - Top Right Door"
                    , "SM - Bubble Mountain - Bottom Right Door"
                    , "SM - Bubble Mountain - Bottom Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Bubble Mountain - Bottom Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 4,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Bubble Mountain - Middle Bottom Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 2,
                                OpenEnd = 1,
                            },
                            // With PB Blocks Intact.
                            new RunwayDash {
                                Length = 5,
                                OpenEnd = 0,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //{"resetRoom":{
                                        //  "nodes": [1, 2, 3, 4, 5, 6, 7],
                                        //  "obstaclesToAvoid": ["A"]
                                        //}}
                                    },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Bubble Mountain - Middle Top Left Door",
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
                        Name = "SM - Bubble Mountain - Top Left Door",
                        Type = TransitionType.Green,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 1,
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "Bubble Mountain Top Left Green Lock (to Bubble Missiles)",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenGreenDoors"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Bubble Mountain - Top Right Door",
                        Type = TransitionType.Green,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 2,
                                OpenEnd = 1,
                                UsableComingIn = false,
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "Bubble Mountain Top Right Green Lock (to Bat Cave)",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenGreenDoors"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Bubble Mountain - Bottom Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 4,
                                OpenEnd = 0,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Bubble Mountain - Bottom Door",
                        Type = TransitionType.Blue,
                    },
                    new Placement {
                        Name = "SM - Bubble Mountain - Item",
                        Type = PlacementType.Visible,
                    },
                    new Junction {
                        Name = "SM - Bubble Mountain - Central Junction",
                    },
                },
                Obstacles = new[] {
                    // The Power Bomb blocks above the bottom doors.
                    new Obstacle {
                        Name = "Power Bomb Blocks",
                        Type = ObstacleType.Inanimate,
                    },
                    // The bomb blocks in the Morph maze above the bottom doors.
                    new Obstacle {
                        Name = "Morph Maze",
                        Type = ObstacleType.Inanimate,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Bubble Mountain - Top Left Door",
                        To = new[] {
                            // This link only includes ways of crossing to Top Right Door that
                            // can't be done from Central junction.
                            new LinkTarget("SM - Bubble Mountain - Top Right Door", new[] {
                                // Doable without a walljump by opening the door. We could consider
                                // adding a logical element that could represent unlocking a door?
                                new Strat {
                                    Requires = null,
                                    //{"or":[
                                    //  "canWalljump",
                                    //  "Grapple"
                                    //]}
                                },
                                new Strat { Requires = null /*["canDamageBoost"]*/ },
                                new Strat {
                                    Name = "Shinespark",
                                    Requires = null,
                                    //{"canComeInCharged":{
                                    //  "fromNode": 1,
                                    //  "framesRemaining": 0,
                                    //  "shinesparkFrames": 45
                                    //}}
                                },
                            }),
                            new LinkTarget("SM - Bubble Mountain - Central Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Bubble Mountain - Middle Top Left Door",
                        To = new[] {
                            new LinkTarget("SM - Bubble Mountain - Top Left Door", new[] {
                                // This link is only for the X-Ray climb, which skips the junction altogether.
                                new Strat {
                                    Name = "Bubble Mountain X-Ray Climb (Top-Mid to Top)",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canRightFacingDoorXRayClimb",
                                    //  {"resetRoom": {
                                    //    "nodes": [2],
                                    //    "mustStayPut": true
                                    //  }}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Bubble Mountain - Central Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Bubble Mountain - Middle Bottom Left Door",
                        To = new[] {
                            // This link is only for the X-Ray climb, which skips the junction altogether.
                            new LinkTarget("SM - Bubble Mountain - Top Left Door", new[] {
                                new Strat {
                                    Name = "Bubble Mountain X-Ray Climb (Bot-Mid to Top)",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canRightFacingDoorXRayClimb",
                                    //  {"resetRoom": {
                                    //    "nodes": [3],
                                    //    "mustStayPut": true
                                    //  }}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Bubble Mountain - Central Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Bubble Mountain - Bottom Left Door",
                        To = new[] {
                            new LinkTarget("SM - Bubble Mountain - Bottom Door"),
                            // This link is only for the X-Ray climb, which skips the junction altogether.
                            new LinkTarget("SM - Bubble Mountain - Central Junction", new[] {
                                new Strat {
                                    Name = "Bubble Mountain X-Ray Climb (Bottom)",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canRightFacingDoorXRayClimb",
                                    //  {"resetRoom": {
                                    //    "nodes": [4],
                                    //    "mustStayPut": true
                                    //  }}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Bubble Mountain - Bottom Door",
                        To = new[] {
                            new LinkTarget("SM - Bubble Mountain - Bottom Left Door"),
                            new LinkTarget("SM - Bubble Mountain - Central Junction", new[] {
                                new Strat {
                                    Name = "Break Power Bomb Blocks",
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Power Bomb Blocks",
                                            Requires = null, // ["h_canUsePowerBombs"],
                                            AdditionalObstacles = new[] { "Morph Maze" },
                                        },
                                    },
                                },
                                // Morph Maze could also be broken with Power Bombs, but that's
                                // made redundant by the PB Blocks strat.
                                new Strat {
                                    Name = "Morph Maze",
                                    Requires = null, // ["Morph"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Morph Maze",
                                            Requires = null, // ["h_canUseMorphBombs"]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Bubble Mountain Ice Clip",
                                    Notable = true,
                                    Requires = null, // ["canWallCrawlerClip"]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Bubble Mountain - Bottom Right Door",
                        To = new[] {
                            new LinkTarget("SM - Bubble Mountain - Top Right Door"),
                        },
                    },
                    new Link {
                        From = "SM - Bubble Mountain - Top Right Door",
                        To = new[] {
                            // This link only includes ways of crossing to Top Left Door that can't
                            // be done from Central Junction.
                            new LinkTarget("SM - Bubble Mountain - Top Left Door", new[] {
                                new Strat { Requires = null /*["Grapple"]*/ },
                                new Strat {
                                    Name = "Shinespark",
                                    Requires = null,
                                    //{"or":[
                                    //  {"canComeInCharged":{
                                    //    "fromNode": 7,
                                    //    "framesRemaining": 0,
                                    //    "shinesparkFrames": 45
                                    //  }},
                                    //  {"canComeInCharged":{
                                    //    "fromNode": 6,
                                    //    "inRoomPath": [6, 7],
                                    //    "framesRemaining": 150,
                                    //    "shinesparkFrames": 30
                                    //  }}
                                    //]}
                                },
                                // Dboost off a Waber to cross the gap.
                                new Strat {
                                    Name = "Bubble Mountain Dboost",
                                    Notable = true,
                                    Requires = null, // ["canDamageBoost"]
                                },
                            }),
                            new LinkTarget("SM - Bubble Mountain - Bottom Right Door"),
                            new LinkTarget("SM - Bubble Mountain - Central Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Bubble Mountain - Item",
                        To = new[] {
                            new LinkTarget("SM - Bubble Mountain - Central Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Bubble Mountain - Central Junction",
                        To = new[] {
                            new LinkTarget("SM - Bubble Mountain - Top Left Door", new[] {
                                new Strat { Requires = null /*["h_canFly"]*/ },
                                new Strat {
                                    Name = "Dual Jump Assist",
                                    Requires = null,
                                    //[ "HiJump",
                                    //  "canSpringBallJumpMidAir"
                                    //]
                                },
                                new Strat {
                                    Name = "Bubble Mountain Springwall",
                                    Notable = true,
                                    Requires = null, // ["canSpringwall"]
                                },
                                // This is the same size of ledge as WRITG, so it should be equally possible.
                                new Strat {
                                    Name = "Bubble Mountain HiJump Walljump (Left)",
                                    Notable = true,
                                    Requires = null,
                                    //[ "HiJump",
                                    //  "canPreciseWalljump"
                                    //]
                                },
                                // This is the same size of ledge as WRITG, so it should be equally possible.
                                new Strat {
                                    Name = "Bubble Mountain Hjless Walljump (Left)",
                                    Notable = true,
                                    Requires = null, // ["canInsaneWalljump"]
                                },
                                new Strat {
                                    Name = "Shinespark",
                                    Requires = null,
                                    //{"or": [
                                    //  {"canComeInCharged":{
                                    //    "fromNode": 2,
                                    //    "inRoomPath": [2, 9],
                                    //    "framesRemaining": 30,
                                    //    "shinesparkFrames": 25
                                    //  }},
                                    //  {"canComeInCharged":{
                                    //    "fromNode": 3,
                                    //    "inRoomPath": [3, 9],
                                    //    "framesRemaining": 30,
                                    //    "shinesparkFrames": 35
                                    //  }}
                                    //]}
                                },
                                new Strat {
                                    Name = "Frozen Waver",
                                    Requires = null, // ["canUseFrozenEnemies"]
                                },
                            }),
                            new LinkTarget("SM - Bubble Mountain - Middle Top Left Door"),
                            new LinkTarget("SM - Bubble Mountain - Middle Bottom Left Door"),
                            new LinkTarget("SM - Bubble Mountain - Bottom Door", new[] {
                                new Strat {
                                    Name = "Break Power Bomb Blocks",
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Power Bomb Blocks",
                                            Requires = null, // ["h_canUsePowerBombs"]
                                            AdditionalObstacles = new[] { "Morph Maze" },
                                        },
                                    },
                                },
                                // Morph Maze could also be broken with Power Bombs, but that's
                                // made redundant by the PB Blocks strat.
                                new Strat {
                                    Name = "Morph Maze",
                                    Requires = null, // ["Morph"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Morph Maze",
                                            Requires = null, // ["h_canUseMorphBombs"]
                                        },
                                    },
                                },
                            }),
                            new LinkTarget("SM - Bubble Mountain - Top Right Door", new[] {
                                new Strat { Requires = null /*["h_canFly"]*/ },
                                new Strat {
                                    Name = "Frozen Waver",
                                    Requires = null, // ["canUseFrozenEnemies"]
                                },
                                // A tricky, delayed walljump makes it possible to climb to top
                                // right in-room, with nothing.
                                new Strat {
                                    Name = "Bubble Mountain Delayed Walljump (Right)",
                                    Notable = true,
                                    Requires = null, // ["canDelayedWalljump"],
                                },
                                new Strat {
                                    Name = "Regular Walljump",
                                    Requires = null,
                                    //[ "HiJump",
                                    //  "canWalljump"
                                    //]
                                },
                                new Strat {
                                    Name = "Shinespark",
                                    Requires = null,
                                    //{"or":[
                                    //  {"canComeInCharged":{
                                    //    "fromNode": 2,
                                    //    "inRoomPath": [2, 9],
                                    //    "framesRemaining": 30,
                                    //    "shinesparkFrames": 25
                                    //  }},
                                    //  {"canComeInCharged":{
                                    //    "fromNode": 3,
                                    //    "inRoomPath": [3, 9],
                                    //    "framesRemaining": 90,
                                    //    "shinesparkFrames": 40
                                    //  }}
                                    //]}
                                },
                                // It's possible to do this without a precise walljump, with enough
                                // speed from the adjacent room. The jump itself out of the door is
                                // a pretty precise one, however.
                                new Strat {
                                    Name = "Bubble Mountain Save Room Jump",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canWalljump",
                                    //  "canTrickyJump",
                                    //  {"adjacentRunway": {
                                    //    "fromNode": 2,
                                    //    "inRoomPath": [2, 9],
                                    //    "usedTiles": 2
                                    //  }}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Bubble Mountain - Item"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "Bubble Mountain Bottom Sova",
                        EnemyName = "Sova",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Bubble Mountain - Bottom Door" },
                    },
                    new Enemy {
                        GroupName = "Bubble Mountain Morph Maze Sovas",
                        EnemyName = "Sova",
                        Quantity = 2,
                        BetweenNodes = new[] {
                            "SM - Bubble Mountain - Bottom Door",
                            "SM - Bubble Mountain - Central Junction",
                        },
                    },
                    new Enemy {
                        GroupName = "Bubble Mountain Wavers",
                        EnemyName = "Waver",
                        Quantity = 3,
                        HomeNodes = new[] { "SM - Bubble Mountain - Central Junction" },
                    },
                    new Enemy {
                        GroupName = "King Cacatac",
                        EnemyName = "Cacatac",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Bubble Mountain - Top Right Door" },
                    },
                    new Enemy {
                        GroupName = "Bubble Mountain Ripper 2",
                        EnemyName = "Ripper 2 (red)",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Bubble Mountain - Item" },
                    },
                },
            },
            #endregion
            // Todo: Acceptable name?
            #region Bubble Secrets Room
            new Room {
                Name = "SM - Bubble Secrets Room",
                Layout = Room.LayoutFrom(@"
                      1→XX←2"
                    , "SM - Bubble Secrets Room - Left Door"
                    , "SM - Bubble Secrets Room - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Bubble Secrets Room - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 0,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"heatFrames": 75}
                                        //]
                                    },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Bubble Secrets Room - Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 2,
                                OpenEnd = 1,
                                UsableComingIn = false,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  { "heatFrames": 70}
                                        //]
                                    },
                                },
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - Bubble Secrets Room - Item",
                        Type = PlacementType.Visible,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Bubble Secrets Room - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Bubble Secrets Room - Item", new[] {
                                new Strat {
                                    Name = "Quick Geruta Kill",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "Morph",
                                    //  {"heatFrames": 250},
                                    //  {"enemyKill":{
                                    //    "enemies": [
                                    //      ["Geruta"]
                                    //    ],
                                    //    "explicitWeapons": [ "Super", "Missile", "PowerBomb", "Plasma" ]
                                    //  }}
                                    //]
                                },
                                new Strat {
                                    Name = "Slow Geruta Kill",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "Morph",
                                    //  { "heatFrames": 400}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Bubble Secrets Room - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Bubble Secrets Room - Item", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 150}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Bubble Secrets Room - Item",
                        To = new[] {
                            new LinkTarget("SM - Bubble Secrets Room - Left Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "Morph",
                                    //  "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 200}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Bubble Secrets Room - Right Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 150}
                                    //]
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "Green Bubbles Missile Room Geruta",
                        EnemyName = "Geruta",
                        Quantity = 1,
                        HomeNodes = new[] {
                            "SM - Bubble Secrets Room - Right Door",
                            "SM - Bubble Secrets Room - Item",
                        },
                        DropRequires = null, // ["h_heatProof"]
                    },
                },
            },
            #endregion
            // Todo: Acceptable name?
            #region Stepping Stone Room
            new Room {
                Name = "SM - Stepping Stone Room",
                Layout = Room.LayoutFrom(@"
                      XX←1"
                    , "SM - Stepping Stone Room - Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Stepping Stone Room - Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 1,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"heatFrames": 75}
                                        //]
                                    },
                                },
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - Stepping Stone Room - Left Item",
                        Type = PlacementType.Chozo,
                    },
                    new Placement {
                        Name = "SM - Stepping Stone Room - Right Item",
                        Type = PlacementType.Hidden,
                    },
                    new Junction {
                        Name = "SM - Stepping Stone Room - Above Last Stone Junction",
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Stepping Stone Room - Door",
                        To = new[] {
                            new LinkTarget("SM - Stepping Stone Room - Above Last Stone Junction", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 300}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Stepping Stone Room - Left Item",
                        To = new[] {
                            new LinkTarget("SM - Stepping Stone Room - Above Last Stone Junction", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 100}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Stepping Stone Room - Right Item",
                        To = new[] {
                            new LinkTarget("SM - Stepping Stone Room - Above Last Stone Junction", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 50},
                                    //  {"lavaFrames": 50}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Stepping Stone Room - Above Last Stone Junction",
                        To = new[] {
                            new LinkTarget("SM - Stepping Stone Room - Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 300}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Stepping Stone Room - Left Item", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 100}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Stepping Stone Room - Right Item"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "Norfair Reserve Dragons",
                        EnemyName = "Dragon",
                        Quantity = 3,
                        HomeNodes = new[] { "SM - Stepping Stone Room - Above Last Stone Junction" },
                        DropRequires = null,
                        //[ "h_heatProof",
                        //  {"or": [
                        //    "Gravity",
                        //    "Grapple"
                        //  ]}
                        //]
                    },
                    new Enemy {
                        GroupName = "Norfair Reserve Sovas",
                        EnemyName = "Sova",
                        Quantity = 3,
                        HomeNodes = new[] { "SM - Stepping Stone Room - Above Last Stone Junction" },
                        DropRequires = null, // ["h_heatProof"]
                    },
                },
            },
            #endregion
            #region Bat Cave
            new Room {
                Name = "SM - Bat Cave",
                Layout = Room.LayoutFrom(@"
                        X←2
                      1→X"
                    , "SM - Bat Cave - Left Door"
                    , "SM - Bat Cave - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Bat Cave - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 2,
                                OpenEnd = 1,
                                UsableComingIn = false,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"heatFrames": 70}
                                        //]
                                    },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Bat Cave - Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            // The blocks respawn, so no need to split this in two runways. While
                            // waiting for respawn would take additional heat frames, the spawner
                            // makes that more or less inconsequential.
                            new RunwayDash {
                                Length = 6,
                                OpenEnd = 1,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  { "heatFrames": 100}
                                        //]
                                    },
                                },
                            },
                        },
                    },
                    new Junction {
                        Name = "SM - Bat Cave - Farm Spot Junction",
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Bat Cave - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Bat Cave - Right Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 350}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Bat Cave - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Bat Cave - Left Door", new [] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 250}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Bat Cave - Farm Spot Junction", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 50}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Bat Cave - Farm Spot Junction",
                        To = new[] {
                            new LinkTarget("SM - Bat Cave - Right Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 50}
                                    //]
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Bat Cave - Skrees",
                        EnemyName = "Skree",
                        Quantity = 3,
                        HomeNodes = new[] { "SM - Bat Cave - Left Door" },
                        DropRequires = null, // ["h_heatProof"]
                    },
                    new Enemy {
                        GroupName = "SM - Bat Cave - Gamets",
                        EnemyName = "Gamet",
                        Quantity = 5,
                        HomeNodes = new[] { "SM - Bat Cave - Farm Spot Junction" },
                        FarmCycles = new[] {
                            new FarmCycle {
                                Name = "Crouch over Gamets",
                                CycleFrames = 120,
                                Requires = null,
                                //[ "h_canNavigateHeatRooms",
                                //  {"heatFrames": 120}
                                //]
                            },
                        },
                    },
                },
            },
            #endregion
            // Todo: Acceptable name?
            #region Bubble Speedway
            new Room {
                Name = "SM - Bubble Speedway",
                Layout = Room.LayoutFrom(@"
                      1→XXXXXX
                           XXXXXXXXX←2"
                    , "SM - Bubble Speedway - Left Door"
                    , "SM - Bubble Speedway - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Bubble Speedway - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 6,
                                OpenEnd = 1,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"heatFrames": 100}
                                        //]
                                    },
                                },
                            },
                            // When Running Through.
                            new RunwayDash {
                                Length = 33,
                                OpenEnd = 1,
                                Strats = new[] {
                                    // Although technically meaningless, mustStayPut false is used here
                                    // to make this resetRoom structurally valid. This is a rare
                                    // situation where visiting a node or destroying an obstacle isn't
                                    // stricly what makes the strat impossible. In this case, you can
                                    // destroy the crumble blocks and still do the strat as long as you
                                    // break them moving towards the door and don't lose momentum.
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"resetRoom":{
                                        //    "nodes": [2],
                                        //    "mustStayPut": false
                                        //  }},
                                        //  { "heatFrames": 300}
                                        //]
                                    },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Bubble Speedway - Right Door",
                        Type = TransitionType.Red,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 7,
                                OpenEnd = 1,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"heatFrames": 110}
                                        //]
                                    },
                                },
                            },
                            // When Running Through.
                            new RunwayDash {
                                Length = 33,
                                OpenEnd = 1,
                                Strats = new[] {
                                    // Unlike with Left Door, here we can count visiting Item as
                                    // 'breaking momentum after using the crumble blocks'.
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"resetRoom":{
                                        //    "nodes": [1],
                                        //    "nodesToAvoid": [3]
                                        //  }},
                                        //  { "heatFrames": 300}
                                        //]
                                    },
                                },
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "Speed Booster Hall Red Lock (to Speed Booster)",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenRedDoors"]*/ },
                                },
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - Bubble Speedway - Item",
                        Type = PlacementType.Hidden,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Bubble Speedway - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Bubble Speedway - Right Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"resetRoom":{
                                    //    "nodes": [1],
                                    //    "nodesToAvoid": [2]
                                    //  }},
                                    //  {"heatFrames": 650}
                                    //]
                                },
                                new Strat {
                                    Name = "Speed Run",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"resetRoom":{
                                    //    "nodes": [1],
                                    //    "nodesToAvoid": [2]
                                    //  }},
                                    //  {"and":[
                                    //    "SpeedBooster",
                                    //    { "heatFrames": 400}
                                    //  ]}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Bubble Speedway - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Bubble Speedway - Left Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"resetRoom":{
                                    //    "nodes": [2],
                                    //    "nodesToAvoid": [1]
                                    //  }},
                                    //  {"heatFrames": 650}
                                    //]
                                },
                                new Strat {
                                    Name = "Speed Run",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"resetRoom":{
                                    //    "nodes": [2],
                                    //    "nodesToAvoid": [1]
                                    //  }},
                                    //  "SpeedBooster",
                                    //  { "heatFrames": 400}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Bubble Speedway - Item", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 25}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Bubble Speedway - Item",
                        To = new[] {
                            new LinkTarget("SM - Bubble Speedway - Right Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 25}
                                    //]
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Bubble Speedway - Metarees",
                        EnemyName = "Metaree",
                        Quantity = 2,
                        HomeNodes = new[] { "SM - Bubble Speedway - Left Door" },
                        DropRequires = null, // ["h_heatProof"]
                    },
                    // Accessible without Gravity going left to right but not right to left with
                    // speedbooster. Letting it slide.
                    new Enemy {
                        GroupName = "SM - Bubble Speedway - Gerutas",
                        EnemyName = "Geruta",
                        Quantity = 3,
                        BetweenNodes = new[] {
                            "SM - Bubble Speedway - Left Door",
                            "SM - Bubble Speedway - Right Door",
                        },
                        DropRequires = null,
                        //[ "Gravity",
                        //  "h_heatProof"
                        //]
                    },
                },
            },
            #endregion
            // Todo: Acceptable name?
            #region Bubble Chozo Prize Room
            new Room {
                Name = "SM - Bubble Chozo Room",
                Layout = Room.LayoutFrom(@"
                      1→X"
                    , "SM - Bubble Chozo Room - Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Bubble Chozo Room - Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 2,
                                OpenEnd = 1,
                                UsableComingIn = false,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"heatFrames": 70}
                                        //]
                                    },
                                },
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - Bubble Chozo Room - Item",
                        Type = PlacementType.Chozo,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Bubble Chozo Room - Door",
                        To = new[] {
                            new LinkTarget("SM - Bubble Chozo Room - Item", new[] {
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
                        From = "SM - Bubble Chozo Room - Item",
                        To = new[] {
                            new LinkTarget("SM - Bubble Chozo Room - Door", new[] {
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
            #region Single Chamber
            new Room {
                Name = "SM - Single Chamber",
                Layout = Room.LayoutFrom(@"
                      1→XXXXXX←2
                        X←3
                        X←4
                        X←5"
                    , "SM - Single Chamber - Left Door"
                    , "SM - Single Chamber - Top Right Door"
                    , "SM - Single Chamber - Middle Top Right Door"
                    , "SM - Single Chamber - Middle Bottom Right Door"
                    , "SM - Single Chamber - Bottom Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Single Chamber - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 7,
                                OpenEnd = 1,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"heatFrames": 110}
                                        //]
                                    },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Single Chamber - Top Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 1,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"heatFrames": 75}
                                        //]
                                    },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Single Chamber - Middle Top Right Door",
                        Type = TransitionType.Red,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 1,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"heatFrames": 75}
                                        //]
                                    },
                                },
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "Single Chamber Red Lock (to Double Chamber Top)",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenRedDoors"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Single Chamber - Middle Bottom Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 1,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"heatFrames": 75}
                                        //]
                                    },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Single Chamber - Bottom Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 12,
                                GentleDownTiles = 4,
                                OpenEnd = 0,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"heatFrames": 140}
                                        //]
                                    },
                                },
                            },
                        },
                    },
                    // Represents the platform where Samus will land after falling from the morph
                    // tunnel when arriving from Lower Norfair.
                    new Junction {
                        Name = "SM - Single Chamber - Top Left Junction",
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Single Chamber - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Single Chamber - Top Left Junction", new[] {
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
                        From = "SM - Single Chamber - Bottom Right Door",
                        To = new[] {
                            new LinkTarget("SM - Single Chamber - Middle Bottom Right Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 280}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Single Chamber - Middle Bottom Right Door",
                        To = new[] {
                            new LinkTarget("SM - Single Chamber - Bottom Right Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 200}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Single Chamber - Middle Top Right Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 310}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Single Chamber - Middle Top Right Door",
                        To = new[] {
                            new LinkTarget("SM - Single Chamber - Middle Bottom Right Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 220}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Single Chamber - Top Left Junction", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 200}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Single Chamber - Top Right Door",
                        To = new[] {
                            new LinkTarget("SM - Single Chamber - Top Left Junction", new[] {
                                new Strat {
                                    Name = "Screw",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "Morph",
                                    //  "ScrewAttack",
                                    //  {"heatFrames": 780}
                                    //]
                                },
                                new Strat {
                                    Name = "Power Bomb",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "h_canUsePowerBombs",
                                    //  {"heatFrames": 850}
                                    //]
                                },
                                new Strat {
                                    Name = "Morph Bomb",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "h_canUseMorphBombs",
                                    //  { "heatFrames": 1130}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Single Chamber - Top Left Junction",
                        To = new[] {
                            new LinkTarget("SM - Single Chamber - Left Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 100}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Single Chamber - Middle Top Right Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 150}
                                    //]
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "Single Chamber Top Alcoons",
                        EnemyName = "Alcoon",
                        Quantity = 2,
                        HomeNodes = new[] { "SM - Single Chamber - Top Left Junction" },
                        DropRequires = null, // ["h_heatProof"]
                    },
                    new Enemy {
                        GroupName = "Single Chamber Top Multiviola",
                        EnemyName = "Multiviola",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Single Chamber - Top Left Junction" },
                        DropRequires = null, // ["h_heatProof"]
                    },
                    new Enemy {
                        GroupName = "Single Chamber Middle Alcoon",
                        EnemyName = "Alcoon",
                        Quantity = 1,
                        BetweenNodes = new[] {
                            "SM - Single Chamber - Middle Bottom Right Door",
                            "SM - Single Chamber - Middle Top Right Door",
                        },
                        DropRequires = null, // ["h_heatProof"]
                    },
                    new Enemy {
                        GroupName = "Single Chamber Middle Multiviola",
                        EnemyName = "Multiviola",
                        Quantity = 1,
                        BetweenNodes = new[] {
                            "SM - Single Chamber - Middle Bottom Right Door",
                            "SM - Single Chamber - Middle Top Right Door",
                        },
                        DropRequires = null, // ["h_heatProof"]
                    },
                    new Enemy {
                        GroupName = "Single Chamber Bottom Alcoon",
                        EnemyName = "Alcoon",
                        Quantity = 1,
                        BetweenNodes = new[] {
                            "SM - Single Chamber - Bottom Right Door",
                            "SM - Single Chamber - Middle Bottom Right Door",
                        },
                        DropRequires = null, // ["h_heatProof"]
                    },
                    new Enemy {
                        GroupName = "Single Chamber Bottom Multiviola",
                        EnemyName = "Multiviola",
                        Quantity = 1,
                        BetweenNodes = new[] {
                            "SM - Single Chamber - Bottom Right Door",
                            "SM - Single Chamber - Middle Bottom Right Door",
                        },
                        DropRequires = null, // ["h_heatProof"]
                    },
                },
            },
            #endregion
            #region Double Chamber
            new Room {
                Name = "SM - Double Chamber",
                Layout = Room.LayoutFrom(@"
                      2→XXXX←3
                      1→XXXX"
                    , "SM - Double Chamber - Bottom Left Door"
                    , "SM - Double Chamber - Top Left Door"
                    , "SM - Double Chamber - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Double Chamber - Bottom Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 0,
                                OpenEnd = 1,
                            },
                        },
                        CanLeaveCharged = new[] {
                            new RunwayCharge {
                                Length = 28,
                                OpenEnd = 0,
                                FramesRemaining = 140,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"heatFrames": 300}
                                        //]
                                    },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Double Chamber - Top Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 1,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"heatFrames": 75}
                                        //]
                                    },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Double Chamber - Right Door",
                        Type = TransitionType.Red,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 5,
                                OpenEnd = 1,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"heatFrames": 90}
                                        //]
                                    },
                                },
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "Double Chamber Red Lock (to Wave)",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenRedDoors"]*/ },
                                },
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - Double Chamber - Item",
                        Type = PlacementType.Visible,
                    },
                    new Junction {
                        Name = "SM - Double Chamber - Below Spikes Junction",
                    },
                },
                Obstacles = new[] {
                    new Obstacle {
                        Name = "Blue Gate",
                        Type = ObstacleType.Inanimate,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Double Chamber - Top Left Door",
                        To = new[] {
                            new LinkTarget("SM - Double Chamber - Bottom Left Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 150}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Double Chamber - Item", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 250}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle { Name = "Blue Gate", },
                                    },
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Double Chamber - Bottom Left Door",
                        To = new[] {
                            new LinkTarget("SM - Double Chamber - Top Left Door", new[] {
                                new Strat {
                                    Name = "Walljump",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "canWalljump",
                                    //  {"heatFrames": 250}
                                    //]
                                },
                                new Strat {
                                    Name = "Space Jump",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "SpaceJump",
                                    //  {"heatFrames": 300}
                                    //]
                                },
                                new Strat {
                                    Name = "IBJ",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "canIBJ",
                                    //  { "heatFrames": 1450}
                                    //]
                                },
                                new Strat {
                                    Name = "Charge Shinespark",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"canShineCharge": {
                                    //    "usedTiles": 28,
                                    //    "gentleUpTiles": 3,
                                    //    "gentleDownTiles": 3,
                                    //    "shinesparkFrames": 27,
                                    //    "openEnd": 0
                                    //  }},
                                    //  { "heatFrames": 450}
                                    //]
                                },
                                new Strat {
                                    Name = "Come in Charged",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"canComeInCharged":{
                                    //    "fromNode": 2,
                                    //    "framesRemaining": 40,
                                    //    "shinesparkFrames": 27
                                    //  }},
                                    //  { "heatFrames": 200}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Double Chamber - Below Spikes Junction", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "Morph",
                                    //  { "heatFrames": 200}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Double Chamber - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Double Chamber - Item", new[] {
                                new Strat {
                                    Name = "Grapple",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "Grapple",
                                    //  {"heatFrames": 200}
                                    //]
                                },
                                new Strat {
                                    Name = "Space Jump",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "SpaceJump",
                                    //  {"heatFrames": 200}
                                    //]
                                },
                                new Strat {
                                    Name = "Double Chamber Spike IBJ",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "canIframeSpikeJump",
                                    //  { "spikeHits": 1},
                                    //  "canIBJ",
                                    //  { "heatFrames": 1200}
                                    //]
                                },
                                new Strat {
                                    Name = "Double Chamber Spike SpringBall",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "canIframeSpikeJump",
                                    //  { "spikeHits": 1},
                                    //  "canSpringBallJumpMidAir",
                                    //  { "heatFrames": 300}
                                    //]
                                },
                                new Strat {
                                    Name = "Double Chamber Spike HiJump",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "canIframeSpikeJump",
                                    //  { "spikeHits": 1},
                                    //  "canWalljump",
                                    //  "HiJump",
                                    //  { "heatFrames": 300}
                                    //]
                                },
                                new Strat {
                                    Name = "Double Chamber Spike Speedjump",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "canIframeSpikeJump",
                                    //  { "spikeHits": 1},
                                    //  "SpeedBooster",
                                    //  "HiJump",
                                    //  { "heatFrames": 200}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Double Chamber - Below Spikes Junction", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 250}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Double Chamber - Item",
                        To = new[] {
                            new LinkTarget("SM - Double Chamber - Top Left Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 250}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Blue Gate",
                                            Requires = null,
                                            //[ "Wave",
                                            //  {"heatFrames": 100}
                                            //]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Gate Glitch",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 250}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Blue Gate",
                                            Requires = null, // ["canHeatedGateGlitch"]
                                        },
                                    },
                                },
                            }),
                            new LinkTarget("SM - Double Chamber - Right Door", new[] {
                                new Strat {
                                    Name = "Walljump",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "canWalljump",
                                    //  { "heatFrames": 300}
                                    //]
                                },
                                new Strat {
                                    Name = "Grapple",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "Grapple",
                                    //  { "heatFrames": 200}
                                    //]
                                },
                                new Strat {
                                    Name = "Space Jump",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "SpaceJump",
                                    //  { "heatFrames": 200}
                                    //]
                                },
                                new Strat {
                                    Name = "IBJ",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "canIframeSpikeJump",
                                    //  { "spikeHits": 1},
                                    //  "canIBJ",
                                    //  { "heatFrames": 1200}
                                    //]
                                },
                                new Strat {
                                    Name = "MidAir SpringBall",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "canIframeSpikeJump",
                                    //  { "spikeHits": 1},
                                    //  "canSpringBallJumpMidAir",
                                    //  { "heatFrames": 300}
                                    //]
                                },
                                new Strat {
                                    Name = "Speedjump",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "canIframeSpikeJump",
                                    //  { "spikeHits": 1},
                                    //  "HiJump",
                                    //  "SpeedBooster",
                                    //  { "heatFrames": 250}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Double Chamber - Below Spikes Junction", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 160}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Double Chamber - Below Spikes Junction",
                        To = new[] {
                            new LinkTarget("SM - Double Chamber - Bottom Left Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "Morph",
                                    //  {"heatFrames": 200}
                                    //]
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "Double Chamber Funes",
                        EnemyName = "Fune",
                        Quantity = 2,
                        BetweenNodes = new[] {
                            "SM - Double Chamber - Top Left Door",
                            "SM - Double Chamber - Bottom Left Door",
                        },
                        DropRequires = null, // ["h_heatProof"]
                    },
                    new Enemy {
                        GroupName = "Double Chamber Ripper 2",
                        EnemyName = "Ripper 2 (green)",
                        Quantity = 1,
                        BetweenNodes = new[] {
                            "SM - Double Chamber - Right Door",
                            "SM - Double Chamber - Below Spikes Junction",
                        },
                        DropRequires = null, // ["h_heatProof"]
                    },
                    new Enemy {
                        GroupName = "Double Chamber Kago",
                        EnemyName = "Kago",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Double Chamber - Below Spikes Junction" },
                        DropRequires = null, // ["h_heatProof"]
                    },
                },
            },
            #endregion
            // Todo: Acceptable name?
            #region Norfair Chozo Room
            new Room {
                Name = "SM - Norfair Chozo Room",
                Layout = Room.LayoutFrom(@"
                      1→X"
                    , "SM - Norfair Chozo Room - Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Norfair Chozo Room - Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - Norfair Chozo Room - Item",
                        Type = PlacementType.Chozo,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Norfair Chozo Room - Door",
                        To = new[] {
                            new LinkTarget("SM - Norfair Chozo Room - Item"),
                        },
                    },
                    new Link {
                        From = "SM - Norfair Chozo Room - Item",
                        To = new[] {
                            new LinkTarget("SM - Norfair Chozo Room - Door"),
                        },
                    },
                },
            },
            #endregion
            #region Spiky Acid Snakes Tunnel
            new Room {
                Name = "SM - Spiky Acid Snakes Tunnel",
                Layout = Room.LayoutFrom(@"
                      1→XXXX←2"
                    , "SM - Spiky Acid Snakes Tunnel - Left Door"
                    , "SM - Spiky Acid Snakes Tunnel - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Spiky Acid Snakes Tunnel - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 1,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"heatFrames": 75}
                                        //]
                                    },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Spiky Acid Snakes Tunnel - Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 1,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  { "heatFrames": 75}
                                        //]
                                    },
                                },
                            },
                        },
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Spiky Acid Snakes Tunnel - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Spiky Acid Snakes Tunnel - Right Door", new[] {
                                new Strat {
                                    Name = "Grapple",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "Grapple",
                                    //  {"heatFrames": 450}
                                    //]
                                },
                                new Strat {
                                    Name = "Space Jump",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "SpaceJump",
                                    //  {"heatFrames": 450}
                                    //]
                                },
                                new Strat {
                                    Name = "Tank the Damage",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 820},
                                    //  { "lavaFrames": 150},
                                    //  { "spikeHits": 7}
                                    //]
                                },
                                new Strat {
                                    Name = "Shinespark",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"canComeInCharged": {
                                    //    "fromNode": 1,
                                    //    "framesRemaining": 0,
                                    //    "shinesparkFrames": 76
                                    //  }},
                                    //  { "heatFrames": 200}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Spiky Acid Snakes Tunnel - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Spiky Acid Snakes Tunnel - Left Door", new[] {
                                new Strat {
                                    Name = "Grapple",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "Grapple",
                                    //  {"heatFrames": 450}
                                    //]
                                },
                                new Strat {
                                    Name = "Space Jump",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "SpaceJump",
                                    //  {"heatFrames": 450}
                                    //]
                                },
                                new Strat {
                                    Name = "Tank the Damage",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 820},
                                    //  { "lavaFrames": 150},
                                    //  { "spikeHits": 7}
                                    //]
                                },
                                new Strat {
                                    Name = "Shinespark",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"canComeInCharged": {
                                    //    "fromNode": 2,
                                    //    "framesRemaining": 0,
                                    //    "shinesparkFrames": 76
                                    //  }},
                                    //  { "heatFrames": 200}
                                    //]
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    // Possible but requires multiple spike hits in most configurations so rarely
                    // worth it.
                    new Enemy {
                        GroupName = "SM - Spiky Acid Snakes Tunnel - Yapping Maws",
                        EnemyName = "Yapping Maw",
                        Quantity = 3,
                        BetweenNodes = new[] {
                            "SM - Spiky Acid Snakes Tunnel - Left Door",
                            "SM - Spiky Acid Snakes Tunnel - Right Door",
                        },
                        DropRequires = null, // [ "never" ]
                    },
                },
            },
            #endregion
            #region Kronic Boost Room
            new Room {
                Name = "SM - Kronic Boost Room",
                Layout = Room.LayoutFrom(@"
                       3→X←4
                      2→XX
                       1→X"
                    , "SM - Kronic Boost Room - Bottom Left Door"
                    , "SM - Kronic Boost Room - Middle Left Door"
                    , "SM - Kronic Boost Room - Top Left Door"
                    , "SM - Kronic Boost Room - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Kronic Boost Room - Bottom Left Door",
                        Type = TransitionType.Yellow,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 13,
                                OpenEnd = 0,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"heatFrames": 200}
                                        //]
                                    },
                                },
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "Kronic Boost Room Yellow Lock (to Lava Dive)",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenYellowDoors"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Kronic Boost Room - Middle Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 5,
                                GentleDownTiles = 2,
                                OpenEnd = 0,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"heatFrames": 75}
                                        //]
                                    },
                                },
                            },
                            // With Gate Open.
                            new RunwayDash {
                                Length = 10,
                                GentleDownTiles = 4,
                                OpenEnd = 0,
                                UsableComingIn = false,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"heatFrames": 170}
                                        //]
                                    },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Kronic Boost Room - Top Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 1,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"heatFrames": 70}
                                        //]
                                    },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Kronic Boost Room - Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 1,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"heatFrames": 70}
                                        //]
                                    },
                                },
                            },
                        },
                    },
                    new Junction {
                        Name = "SM - Kronic Boost Room - Top Junction",
                    },
                    new Junction {
                        Name = "SM - Kronic Boost Room - Middle Junction",
                    },
                },
                Obstacles = new[] {
                    new Obstacle {
                        Name = "Blue Gate",
                        Type = ObstacleType.Inanimate,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Kronic Boost Room - Top Left Door",
                        To = new[] {
                            new LinkTarget("SM - Kronic Boost Room - Top Junction", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 75}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Kronic Boost Room - Middle Left Door",
                        To = new[] {
                            new LinkTarget("SM - Kronic Boost Room - Middle Junction", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "Morph",
                                    //  { "heatFrames": 200}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Blue Gate",
                                            Requires = null, // [{"heatFrames": 50}]
                                        },
                                    },
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Kronic Boost Room - Bottom Left Door",
                        To = new[] {
                            new LinkTarget("SM - Kronic Boost Room - Middle Junction", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 220}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Kronic Boost Room - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Kronic Boost Room - Top Junction", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 25}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Kronic Boost Room - Top Junction",
                        To = new[] {
                            new LinkTarget("SM - Kronic Boost Room - Top Left Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 75}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Kronic Boost Room - Right Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 25}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Kronic Boost Room - Middle Junction", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 160}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Kronic Boost Room - Middle Junction",
                        To = new[] {
                            new LinkTarget("SM - Kronic Boost Room - Middle Left Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "Morph",
                                    //  {"heatFrames": 150}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Blue Gate",
                                            Requires = null,
                                            //[ "Wave",
                                            //  {"heatFrames": 30}
                                            //]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Gate Glitch",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "Morph",
                                    //  { "heatFrames": 150}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Blue Gate",
                                            Requires = null, // ["canHeatedGateGlitch"]
                                        },
                                    },
                                },
                            }),
                            new LinkTarget("SM - Kronic Boost Room - Bottom Left Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 140}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Kronic Boost Room - Top Junction", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 150}
                                    //]
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Kronic Boost Room - Bottom Violas",
                        EnemyName = "Viola",
                        Quantity = 3,
                        HomeNodes = new[] { "SM - Kronic Boost Room - Bottom Left Door" },
                        DropRequires = null, // ["h_heatProof"]
                    },
                    new Enemy {
                        GroupName = "SM - Kronic Boost Room - Top Viola",
                        EnemyName = "Viola",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Kronic Boost Room - Top Junction" },
                        DropRequires = null, // ["h_heatProof"]
                    },
                },
            },
            #endregion
            #region Magdollite Tunnel
            new Room {
                Name = "SM - Magdollite Tunnel",
                Layout = Room.LayoutFrom(@"
                      1→XXX←2"
                    , "SM - Magdollite Tunnel - Left Door"
                    , "SM - Magdollite Tunnel - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Magdollite Tunnel - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 1,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"heatFrames": 75}
                                        //]
                                    },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Magdollite Tunnel - Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 1,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  { "heatFrames": 75}
                                        //]
                                    },
                                },
                            },
                        },
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Magdollite Tunnel - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Magdollite Tunnel - Right Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 500}
                                    //]
                                },
                                new Strat {
                                    Name = "Space Jump",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "SpaceJump",
                                    //  {"enemyKill":{
                                    //    "enemies": [
                                    //      [
                                    //        "Multiviola"
                                    //      ]
                                    //    ],
                                    //    "explicitWeapons": [ "Super", "Missile" ]
                                    //  }},
                                    //  { "heatFrames": 300}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Magdollite Tunnel - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Magdollite Tunnel - Left Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 550}
                                    //]
                                },
                                new Strat {
                                    Name = "Space Jump",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "SpaceJump",
                                    //  {"heatFrames": 350}
                                    //]
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "Magdollite Tunnel Multiviolas",
                        EnemyName = "Multiviola",
                        Quantity = 2,
                        HomeNodes = new[] {
                            "SM - Magdollite Tunnel - Left Door",
                            "SM - Magdollite Tunnel - Right Door",
                        },
                        DropRequires = null, // ["h_heatProof"]
                    },
                    new Enemy {
                        GroupName = "Magdollite Tunnel Magdollites",
                        EnemyName = "Magdollite",
                        Quantity = 3,
                        HomeNodes = new[] {
                            "SM - Magdollite Tunnel - Left Door",
                            "SM - Magdollite Tunnel - Right Door",
                        },
                        DropRequires = null,
                        //[ "h_heatProof",
                        //  {"or": [
                        //    "Gravity",
                        //    "Grapple"
                        //  ]}
                        //]
                    },
                },
            },
            #endregion
            #region Lava Dive Room
            new Room {
                Name = "SM - Lava Dive Room",
                Layout = Room.LayoutFrom(@"
                      1→XXXX←2
                         XXX
                         XX"
                    , "SM - Lava Dive Room - Left Door"
                    , "SM - Lava Dive Room - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Lava Dive Room - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 0,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Lava Dive Room - Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 4,
                                OpenEnd = 1,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"heatFrames": 85}
                                        //]
                                    },
                                },
                            },
                        },
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Lava Dive Room - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Lava Dive Room - Right Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "SpaceJump",
                                    //  "Gravity",
                                    //  {"heatFrames": 450}
                                    //]
                                },
                                new Strat {
                                    Name = "Reverse Lava Dive",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "canSuitlessLavaDive",
                                    //  {"heatFrames": 600},
                                    //  {"lavaFrames": 500}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Lava Dive Room - Right Door",
                        To = new[] {
                            // FIXME Do we want a strat (and heat frame count) for morphless hjless
                            // lava dive? Probably?
                            new LinkTarget("SM - Lava Dive Room - Left Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "Gravity",
                                    //  "SpaceJump",
                                    //  {"heatFrames": 600}
                                    //]
                                },
                                new Strat {
                                    Name = "Lava Spark",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "Gravity",
                                    //  "canDamageBoost",
                                    //  {"canComeInCharged":{
                                    //    "fromNode": 2,
                                    //    "framesRemaining": 180,
                                    //    "shinesparkFrames": 33
                                    //  }},
                                    //  { "heatFrames": 500},
                                    //  {"enemyDamage": {
                                    //    "enemy": "Namihe",
                                    //    "type": "fireball",
                                    //    "hits": 1
                                    //  }}
                                    //]
                                },
                                new Strat {
                                    Name = "Lava Dive Gravity Jump",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "Gravity",
                                    //  "canLavaGravityJump",
                                    //  "HiJump",
                                    //  { "heatFrames": 600},
                                    //  { "lavaPhysicsFrames": 100}
                                    //]
                                },
                                new Strat {
                                    Name = "Hjless Lava Dive Gravity Jump",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "Gravity",
                                    //  "canLavaGravityJump",
                                    //  "canSuitlessLavaDive",
                                    //  "canSuitlessLavaWalljump",
                                    //  { "heatFrames": 750},
                                    //  { "lavaPhysicsFrames": 250}
                                    //]
                                },
                                new Strat {
                                    Name = "Lava Dive (Morph)",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "canSuitlessLavaDive",
                                    //  "Morph",
                                    //  {"adjacentRunway": {
                                    //    "fromNode": 2,
                                    //    "usedTiles": 4
                                    //  }},
                                    //  "HiJump",
                                    //  { "heatFrames": 900},
                                    //  { "lavaFrames": 650}
                                    //]
                                },
                                new Strat {
                                    Name = "Lava Dive (Morphless)",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "canSuitlessLavaDive",
                                    //  "HiJump",
                                    //  { "heatFrames": 1350},
                                    //  { "lavaFrames": 1100}
                                    //]
                                },
                                new Strat {
                                    Name = "Hjless Lava Dive",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "canSuitlessLavaDive",
                                    //  "Morph",
                                    //  {"adjacentRunway": {
                                    //    "fromNode": 2,
                                    //    "usedTiles": 4
                                    //  }},
                                    //  "canIframeSpikeWalljump",
                                    //  { "heatFrames": 950},
                                    //  { "lavaFrames": 700},
                                    //  {"enemyDamage": {
                                    //    "enemy": "Namihe",
                                    //    "type": "fireball",
                                    //    "hits": 1
                                    //  }}
                                    //]
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "Lava Dive Namihes",
                        EnemyName = "Namihe",
                        Quantity = 6,
                        BetweenNodes = new[] {
                            "SM - Lava Dive Room - Left Door",
                            "SM - Lava Dive Room - Right Door",
                        },
                        DropRequires = null,
                        //[ "h_heatProof",
                        //  "Gravity"
                        //]
                    },
                },
            },
            #endregion
            #region Volcano Room
            new Room {
                Name = "SM - Volcano Room",
                Layout = Room.LayoutFrom(@"
                        2→X
                          X
                      1→XXX"
                    , "SM - Volcano Room - Bottom Left Door"
                    , "SM - Volcano Room - Top Left Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Volcano Room - Bottom Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            // Can't charge in lava, so doesn't work coming in from the top left door.
                            new RunwayDash {
                                Length = 5,
                                OpenEnd = 1,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  { "heatFrames": 90},
                                        //  {"resetRoom":{
                                        //    "nodes": [2],
                                        //    "mustStayPut": true
                                        //  }}
                                        //]
                                    }
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Volcano Room - Top Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 7,
                                OpenEnd = 1,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"heatFrames": 110}
                                        //]
                                    },
                                },
                            },
                        },
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Volcano Room - Top Left Door",
                        To = new[] {
                            // Is a heatroom when entering from bottom but not when entering from top.
                            new LinkTarget("SM - Volcano Room - Bottom Left Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "Gravity",
                                    //  "Morph"
                                    //]
                                },
                                new Strat {
                                    Name = "Suitless Volcano Dive",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canSuitlessLavaDive",
                                    //  "Morph",
                                    //  {"lavaFrames": 450}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Volcano Room - Bottom Left Door",
                        To = new[] {
                            new LinkTarget("SM - Volcano Room - Top Left Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "Morph",
                                    //  { "heatFrames": 650}
                                    //]
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Volcano Room - Top Funes",
                        EnemyName = "Fune",
                        Quantity = 5,
                        HomeNodes = new[] { "SM - Volcano Room - Top Left Door" },
                        DropRequires = null, // ["h_heatProof"]
                    },
                    new Enemy {
                        GroupName = "SM - Volcano Room - Bottom Fune",
                        EnemyName = "Fune",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Volcano Room - Bottom Left Door" },
                        DropRequires = null,
                        //[ "h_heatProof",
                        //  "Gravity"
                        //]
                    },
                },
            },
            #endregion
            #region Spiky Platforms Tunnel
            new Room {
                Name = "SM - Spiky Platforms Tunnel",
                Layout = Room.LayoutFrom(@"
                      1→XXXX←2"
                    , "SM - Spiky Platforms Tunnel - Left Door"
                    , "SM - Spiky Platforms Tunnel - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Spiky Platforms Tunnel - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 1,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"heatFrames": 75}
                                        //]
                                    },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Spiky Platforms Tunnel - Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 1,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  { "heatFrames": 75}
                                        //]
                                    },
                                },
                            },
                        },
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Spiky Platforms Tunnel - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Spiky Platforms Tunnel - Right Door", new[] {
                                new Strat {
                                    Name = "Gravity",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "Gravity",
                                    //  {"heatFrames": 900}
                                    //]
                                },
                                new Strat {
                                    Name = "Tripper Morphing",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "Morph",
                                    //  {"heatFrames": 1050}
                                    //]
                                },
                                new Strat {
                                    Name = "Lava Bath",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "canSuitlessLavaDive",
                                    //  { "heatFrames": 900},
                                    //  { "lavaFrames": 200}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Spiky Platforms Tunnel - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Spiky Platforms Tunnel - Left Door", new[] {
                                new Strat {
                                    Name = "Gravity",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "Gravity",
                                    //  {"heatFrames": 900}
                                    //]
                                },
                                new Strat {
                                    Name = "Tripper Morphing",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "Morph",
                                    //  {"heatFrames": 1050}
                                    //]
                                },
                                new Strat {
                                    Name = "Lava Bath",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "canSuitlessLavaDive",
                                    //  { "heatFrames": 900},
                                    //  { "lavaFrames": 200}
                                    //]
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Spiky Platforms Tunnel - Left Tripper",
                        EnemyName = "Tripper",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Spiky Platforms Tunnel - Left Door" },
                        DropRequires = null,
                        //[ "h_heatProof",
                        //  "Gravity"
                        //]
                    },
                    new Enemy {
                        GroupName = "SM - Spiky Platforms Tunnel - Right Tripper",
                        EnemyName = "Tripper",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Spiky Platforms Tunnel - Right Door" },
                        DropRequires = null,
                        //[ "h_heatProof",
                        //  "Gravity"
                        //]
                    },
                },
            },
            #endregion
            #region Red Pirate Shaft
            new Room {
                Name = "SM - Red Pirate Shaft",
                Layout = Room.LayoutFrom(@"
                      X←1
                      X
                      X
                      ↑
                      2"
                    , "SM - Red Pirate Shaft - Right Door"
                    , "SM - Red Pirate Shaft - Bottom Door"
                ),
                Nodes = new[] {
                    new Transition {
                        Name = "SM - Red Pirate Shaft - Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 4,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Red Pirate Shaft - Bottom Door",
                        Type = TransitionType.Blue,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Red Pirate Shaft - Bottom Door",
                        To = new[] {
                            new LinkTarget("SM - Red Pirate Shaft - Right Door"),
                        },
                    },
                    new Link {
                        From = "SM - Red Pirate Shaft - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Red Pirate Shaft - Bottom Door"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "Red Pirate Shaft Geemers",
                        EnemyName = "Geemer (grey)",
                        Quantity = 4,
                        HomeNodes = new[] { "SM - Red Pirate Shaft - Bottom Door" },
                    },
                    new Enemy {
                        GroupName = "Red Pirate Shaft Pirates",
                        EnemyName = "Red Space Pirate (standing)",
                        Quantity = 3,
                        HomeNodes = new[] { "SM - Red Pirate Shaft - Bottom Door" },
                    },
                },
            },
            #endregion
            #region Acid Snakes Tunnel
            new Room {
                Name = "SM - Acid Snakes Tunnel",
                Layout = Room.LayoutFrom(@"
                           2
                           ↓
                      1→XXXX←3"
                    , "SM - Acid Snakes Tunnel - Left Door"
                    , "SM - Acid Snakes Tunnel - Top Door"
                    , "SM - Acid Snakes Tunnel - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Acid Snakes Tunnel - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 13,
                                OpenEnd = 1,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"heatFrames": 150}
                                        //]
                                    },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Acid Snakes Tunnel - Top Door",
                        Type = TransitionType.Blue,
                    },
                    new Transition {
                        Name = "SM - Acid Snakes Tunnel - Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 13,
                                OpenEnd = 1,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  { "heatFrames": 150}
                                        //]
                                    },
                                },
                            },
                        },
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Acid Snakes Tunnel - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Acid Snakes Tunnel - Top Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 300}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Acid Snakes Tunnel - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Acid Snakes Tunnel - Top Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 100}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Acid Snakes Tunnel - Top Door",
                        To = new[] {
                            new LinkTarget("SM - Acid Snakes Tunnel - Left Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 300}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Acid Snakes Tunnel - Right Door", new[] {
                            new Strat {
                                Requires = null,
                                //[ "h_canNavigateHeatRooms",
                                //  {"heatFrames": 50}
                                //]
                            },
                        }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "Acid Snakes Tunnel Gamets",
                        EnemyName = "Gamet",
                        Quantity = 5,
                        HomeNodes = new[] { "SM - Acid Snakes Tunnel - Left Door" },
                        FarmCycles = new[] {
                            new FarmCycle {
                                Name = "Crouch 3 tiles over Gamets",
                                CycleFrames = 165,
                                Requires = null,
                                //[ "h_canNavigateHeatRooms",
                                //  {"heatFrames": 165}
                                //]
                            },
                            // Works fine with lava immunity.
                            new FarmCycle {
                                Name = "Lava Gamets down shots",
                                CycleFrames = 120,
                                Requires = null,
                                //[ "h_canNavigateHeatRooms",
                                //  {"heatFrames": 120},
                                //  { "lavaFrames": 120}
                                //]
                            },
                        },
                    },
                    // Drops can be reached from land.
                    new Enemy {
                        GroupName = "Acid Snakes Tunnel Dragons",
                        EnemyName = "Dragon",
                        Quantity = 2,
                        HomeNodes = new[] {
                            "SM - Acid Snakes Tunnel - Left Door",
                            "SM - Acid Snakes Tunnel - Right Door",
                        },
                        DropRequires = null, // ["h_heatProof"]
                    }
                },
            },
            #endregion
            #region Norfair Upper Save Room A
            new Room {
                Name = "SM - Norfair Upper Save Room A",
                Layout = Room.LayoutFrom(@"
                      1→X←2"
                    , "SM - Norfair Upper Save Room A - Left Door"
                    , "SM - Norfair Upper Save Room A - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Norfair Upper Save Room A - Left Door",
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
                        Name = "SM - Norfair Upper Save Room A - Right Door",
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
                        Name = "SM - Norfair Upper Save Room A - Save Station",
                        Type = UtilityType.Save,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Norfair Upper Save Room A - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Norfair Upper Save Room A - Save Station"),
                        },
                    },
                    new Link {
                        From = "SM - Norfair Upper Save Room A - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Norfair Upper Save Room A - Save Station"),
                        },
                    },
                    new Link {
                        From = "SM - Norfair Upper Save Room A - Save Station",
                        To = new[] {
                            new LinkTarget("SM - Norfair Upper Save Room A - Left Door"),
                            new LinkTarget("SM - Norfair Upper Save Room A - Right Door"),
                        },
                    },
                },
            },
            #endregion
            #region Norfair Upper Save Room C
            new Room {
                Name = "SM - Norfair Upper Save Room D",
                Layout = Room.LayoutFrom(@"
                      X←1"
                    , "SM - Norfair Upper Save Room D - Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Norfair Upper Save Room D - Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Utility {
                        Name = "SM - Norfair Upper Save Room D - Save Station",
                        Type = UtilityType.Save,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Norfair Upper Save Room D - Door",
                        To = new[] {
                            new LinkTarget("SM - Norfair Upper Save Room D - Save Station"),
                        },
                    },
                    new Link {
                        From = "SM - Norfair Upper Save Room D - Save Station",
                        To = new[] {
                            new LinkTarget("SM - Norfair Upper Save Room D - Door"),
                        },
                    },
                },
            },
            #endregion
            #region Norfair Upper Energy Refill Room
            new Room {
                Name = "SM - Norfair Upper Energy Refill Room",
                Layout = Room.LayoutFrom(@"
                      1→X←2"
                    , "SM - Norfair Upper Energy Refill Room - Left Door"
                    , "SM - Norfair Upper Energy Refill Room - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Norfair Upper Energy Refill Room - Left Door",
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
                        Name = "SM - Norfair Upper Energy Refill Room - Right Door",
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
                        Name = "SM - Norfair Upper Energy Refill Room - Energy Refill",
                        Type = UtilityType.Energy,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Norfair Upper Energy Refill Room - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Norfair Upper Energy Refill Room - Energy Refill"),
                        },
                    },
                    new Link {
                        From = "SM - Norfair Upper Energy Refill Room - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Norfair Upper Energy Refill Room - Energy Refill"),
                        },
                    },
                    new Link {
                        From = "SM - Norfair Upper Energy Refill Room - Energy Refill",
                        To = new[] {
                            new LinkTarget("SM - Norfair Upper Energy Refill Room - Left Door"),
                            new LinkTarget("SM - Norfair Upper Energy Refill Room - Right Door"),
                        },
                    },
                },
            },
            #endregion
            #region Norfair Upper Elevator Room
            new Room {
                Name = "SM - Norfair Upper Elevator Room",
                Layout = Room.LayoutFrom(@"
                      1→X←2
                        ↑
                        3"
                    , "SM - Norfair Upper Elevator Room - Left Door"
                    , "SM - Norfair Upper Elevator Room - Right Door"
                    , "SM - Norfair Upper Elevator Room - Elevator"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Norfair Upper Elevator Room - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 12,
                                OpenEnd = 0,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"heatFrames": 125}
                                        //]
                                    },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Norfair Upper Elevator Room - Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 12,
                                OpenEnd = 0,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  { "heatFrames": 125}
                                        //]
                                    },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Norfair Upper Elevator Room - Elevator",
                        Type = TransitionType.Elevator,
                    },
                    new Junction {
                        Name = "SM - Norfair Upper Elevator Room - Main Junction",
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Norfair Upper Elevator Room - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Norfair Upper Elevator Room - Main Junction", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 50}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Norfair Upper Elevator Room - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Norfair Upper Elevator Room - Main Junction", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 50}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Norfair Upper Elevator Room - Main Junction",
                        To = new[] {
                            new LinkTarget("SM - Norfair Upper Elevator Room - Left Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 50}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Norfair Upper Elevator Room - Right Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 50}
                                    //]
                                },
                            }),
                            // This link exists because of how Samus takes heatdamage while riding
                            // the elevator.
                            new LinkTarget("SM - Norfair Upper Elevator Room - Elevator", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 235}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Norfair Upper Elevator Room - Elevator",
                        To = new[] {
                            // This link exists because of how Samus takes heatdamage while riding
                            // the elevator.
                            new LinkTarget("SM - Norfair Upper Elevator Room - Main Junction", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 215}
                                    //]
                                },
                            }),
                        },
                    },
                },
            },
            #endregion
            #region Norfair Upper Save Room D
            new Room {
                Name = "SM - Norfair Upper Save Room E",
                Layout = Room.LayoutFrom(@"
                      X1"
                    , "SM - Norfair Upper Save Room E - Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Norfair Upper Save Room E - Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Utility {
                        Name = "SM - Norfair Upper Save Room E - Save Station",
                        Type = UtilityType.Save,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Norfair Upper Save Room E - Door",
                        To = new[] {
                            new LinkTarget("SM - Norfair Upper Save Room E - Save Station"),
                        },
                    },
                    new Link {
                        From = "SM - Norfair Upper Save Room E - Save Station",
                        To = new[] {
                            new LinkTarget("SM - Norfair Upper Save Room E - Door"),
                        },
                    },
                },
            },
            #endregion
        };

    }

}
