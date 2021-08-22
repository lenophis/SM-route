using System.Collections.Generic;

namespace SMRouteRando {

    public class SMCrateriaWest {

        public static IList<Room> Rooms { get; } = new[] {
            #region Terminator Room
            new Room {
                Name = "SM - Terminator Room",
                Layout = Room.LayoutFrom(@"
                           XXX←2
                         XXXX
                      1→XXX"
                    , "SM - Terminator Room - Left Door"
                    , "SM - Terminator Room - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Terminator Room - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 33,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Terminator Room - Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 33,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - Terminator Room - Item",
                        Type = PlacementType.Visible,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Terminator Room - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Terminator Room - Item"),
                        },
                    },
                    new Link {
                        From = "SM - Terminator Room - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Terminator Room - Item"),
                        },
                    },
                    new Link {
                        From = "SM - Terminator Room - Item",
                        To = new[] {
                            new LinkTarget("SM - Terminator Room - Left Door"),
                            new LinkTarget("SM - Terminator Room - Right Door"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Terminator Room - Geemers",
                        EnemyName = "Geemer (blue)",
                        Quantity = 6,
                        HomeNodes = new[] {
                            "SM - Terminator Room - Left Door",
                            "SM - Terminator Room - Right Door",
                            "SM - Terminator Room - Item"
                        },
                    },
                    new Enemy {
                        GroupName = "SM - Terminator Room - Wavers",
                        EnemyName = "Waver",
                        Quantity = 3,
                        HomeNodes = new[] {
                            "SM - Terminator Room - Left Door",
                            "SM - Terminator Room - Right Door",
                            "SM - Terminator Room - Item"
                        },
                    },
                },
            },
            #endregion
            #region Green Pirates Shaft
            new Room {
                Name = "SM - Green Pirates Shaft",
                Layout = Room.LayoutFrom(@"
                        X←2
                        X
                        X
                        X
                        X←3
                        X
                      1→X←4"
                    , "SM - Green Pirates Shaft - Bottom Left Door"
                    , "SM - Green Pirates Shaft - Top Right Door"
                    , "SM - Green Pirates Shaft - Middle Right Door"
                    , "SM - Green Pirates Shaft - Bottom Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Green Pirates Shaft - Bottom Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 12,
                                OpenEnd = 0,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Green Pirates Shaft - Top Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 4,
                                OpenEnd = 0,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Green Pirates Shaft - Middle Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 8,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Green Pirates Shaft - Bottom Right Door",
                        Type = TransitionType.Red,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 12,
                                OpenEnd = 0,
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Green Pirates Shaft - Red Lock",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenRedDoors"]*/ },
                                },
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - Green Pirates Shaft - Left Item",
                        Type = PlacementType.Visible,
                    },
                    new Placement {
                        Name = "SM - Green Pirates Shaft - Right Item",
                        Type = PlacementType.Visible,
                    },
                    new Junction {
                        Name = "SM - Green Pirates Shaft - Crumble Junction",
                    },
                    new Junction {
                        Name = "SM - Green Pirates Shaft - Narrow Shaft Junction",
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Green Pirates Shaft - Top Right Door",
                        To = new[] {
                            new LinkTarget("SM - Green Pirates Shaft - Crumble Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Green Pirates Shaft - Middle Right Door",
                        To = new[] {
                            new LinkTarget("SM - Green Pirates Shaft - Bottom Right Door", new[] {
                                new Strat {
                                    Name = "Tank the Damage",
                                    Requires = null,
                                    //{"enemyDamage": {
                                    //  "enemy": "Green Space Pirate (standing)",
                                    //  "type": "contact",
                                    //  "hits": 3
                                    //}}
                                },
                                new Strat {
                                    Name = "Kill the Pirates",
                                    Requires = null,
                                    //{"enemyKill":{
                                    //  "enemies": [
                                    //    [ "Green Space Pirate (standing)",
                                    //      "Green Space Pirate (standing)",
                                    //      "Green Space Pirate (standing)"
                                    //    ],
                                    //    [ "Green Space Pirate (standing)",
                                    //      "Green Space Pirate (standing)"
                                    //    ]
                                    //  ]
                                    //}}
                                },
                            }),
                            new LinkTarget("SM - Green Pirates Shaft - Narrow Shaft Junction", new[] {
                                new Strat { Requires = null /*["h_canUsePowerBombs"]*/ },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Green Pirates Shaft - Bottom Left Door",
                        To = new[] {
                            new LinkTarget("SM - Green Pirates Shaft - Bottom Right Door"),
                        },
                    },
                    new Link {
                        From = "SM - Green Pirates Shaft - Bottom Right Door",
                        To = new[] {
                            new LinkTarget("SM - Green Pirates Shaft - Middle Right Door", new[] {
                                new Strat {
                                    Name = "Tank the Damage",
                                    Requires = null,
                                    //{"enemyDamage": {
                                    //  "enemy": "Green Space Pirate (standing)",
                                    //  "type": "contact",
                                    //  "hits": 3
                                    //}}
                                },
                                new Strat {
                                    Name = "Kill the Pirates",
                                    Requires = null,
                                    //{"enemyKill":{
                                    //  "enemies": [
                                    //    [ "Green Space Pirate (standing)",
                                    //      "Green Space Pirate (standing)",
                                    //      "Green Space Pirate (standing)"
                                    //    ],
                                    //    [ "Green Space Pirate (standing)",
                                    //      "Green Space Pirate (standing)"
                                    //    ]
                                    //  ]
                                    //}}
                                },
                            }),
                            new LinkTarget("SM - Green Pirates Shaft - Bottom Left Door"),
                        },
                    },
                    new Link {
                        From = "SM - Green Pirates Shaft - Left Item",
                        To = new[] {
                            new LinkTarget("SM - Green Pirates Shaft - Crumble Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Green Pirates Shaft - Right Item",
                        To = new[] {
                            new LinkTarget("SM - Green Pirates Shaft - Crumble Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Green Pirates Shaft - Crumble Junction",
                        To = new[] {
                            new LinkTarget("SM - Green Pirates Shaft - Left Item"),
                            new LinkTarget("SM - Green Pirates Shaft - Right Item"),
                            new LinkTarget("SM - Green Pirates Shaft - Narrow Shaft Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Green Pirates Shaft - Narrow Shaft Junction",
                        To = new[] {
                            new LinkTarget("SM - Green Pirates Shaft - Middle Right Door", new[] {
                                new Strat { Requires = null /*["Morph"]*/ },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Green Pirates Shaft - Pirates",
                        EnemyName = "Green Space Pirate (standing)",
                        Quantity = 5,
                        // They're really between Middle Right Door and Bottom Right Door, but they
                        // are the actual obstacle between the two, so access to either + ability
                        // to kill them is enough to get their drops.
                        HomeNodes = new[] {
                            "SM - Green Pirates Shaft - Middle Right Door",
                            "SM - Green Pirates Shaft - Bottom Right Door",
                        },
                    },
                    // Todo: Missing the WhatchaMahCallIt that can drop PBs?
                },
            },
            #endregion
            #region Lower Mushrooms
            new Room {
                Name = "SM - Lower Mushrooms",
                Layout = Room.LayoutFrom(@"
                      1→XXXX←2"
                    , "SM - Lower Mushrooms - Left Door"
                    , "SM - Lower Mushrooms - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Lower Mushrooms - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 13,
                                GentleDownTiles = 2,
                                GentleUpTiles = 4,
                                OpenEnd = 0,
                            },
                            // With no Enemies.
                            // This longer runway has no requirements, but it's not usable coming
                            // in because of enemies in the way.
                            new RunwayDash {
                                Length = 33,
                                UsableComingIn = false,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Lower Mushrooms - Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 28,
                                GentleDownTiles = 2,
                                GentleUpTiles = 6,
                                OpenEnd = 0,
                            },
                            // With no Enemies.
                            // This longer runway has no requirements, but it's not usable coming
                            // in because of enemies in the way.
                            new RunwayDash {
                                Length = 33,
                                OpenEnd = 1,
                                UsableComingIn = false,
                            },
                        },
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Lower Mushrooms - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Lower Mushrooms - Right Door"),
                        },
                    },
                    new Link {
                        From = "SM - Lower Mushrooms - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Lower Mushrooms - Left Door"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Lower Mushrooms - Geemers",
                        EnemyName = "Geemer (grey)",
                        Quantity = 2,
                        HomeNodes = new[] { "SM - Lower Mushrooms - Left Door" },
                    },
                    new Enemy {
                        GroupName = "SM - Lower Mushrooms - Kagos",
                        EnemyName = "Kago",
                        Quantity = 2,
                        HomeNodes = new[] { "SM - Lower Mushrooms - Left Door" },
                    },
                },
            },
            #endregion
            #region Crateria West Elevator Room
            new Room {
                Name = "SM - Crateria West Elevator Room",
                Layout = Room.LayoutFrom(@"
                      X←1
                      ↑
                      2"
                    , "SM - Crateria West Elevator Room - Door"
                    , "SM - Crateria West Elevator Room - Elevator"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Crateria West Elevator Room - Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 13,
                                OpenEnd = 0,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Crateria West Elevator Room - Elevator",
                        Type = TransitionType.Elevator,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Crateria West Elevator Room - Door",
                        To = new[] {
                            new LinkTarget("SM - Crateria West Elevator Room - Elevator"),
                        },
                    },
                    new Link {
                        From = "SM - Crateria West Elevator Room - Elevator",
                        To = new[] {
                            new LinkTarget("SM - Crateria West Elevator Room - Door"),
                        },
                    },
                },
            },
            #endregion
            #region Tourian Entrance
            new Room {
                Name = "SM - Tourian Entrance",
                Layout = Room.LayoutFrom(@"
                      1→XXXXX←2"
                    , "SM - Tourian Entrance - Left Door"
                    , "SM - Tourian Entrance - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Tourian Entrance - Left Door",
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
                                FramesRemaining = 120,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Tourian Entrance - Right Door",
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
                                FramesRemaining = 120,
                            },
                        },
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Tourian Entrance - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Tourian Entrance - Right Door"),
                        },
                    },
                    new Link {
                        From = "SM - Tourian Entrance - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Tourian Entrance - Left Door"),
                        },
                    },
                },
            },
            #endregion
            #region Tourian Statues Room
            new Room {
                Name = "SM - Tourian Statues Room",
                Layout = Room.LayoutFrom(@"
                      1→X
                        X
                        ↑
                        2"
                    , "SM - Tourian Statues Room - Left Door"
                    , "SM - Tourian Statues Room - Elevator"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Tourian Statues Room - Left Door",
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
                                Name = "SM - Tourian Statues Room - Grey Lock",
                                Type = LockType.Cutscene,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Tourian Statues Room - Elevator",
                        Type = TransitionType.Elevator,
                    },
                    // Represents the statues actually sinking and opening up the path to Tourian.
                    new Event {
                        Name = "SM - Tourian Statues Room - Statues Event",
                        Type = EventType.Flag,
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Tourian Statues Room - Statues Above Lock",
                                Type = LockType.GameFlag,
                                UnlockStrats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "f_DefeatedKraid",
                                        //  "f_DefeatedPhantoon",
                                        //  "f_DefeatedDraygon",
                                        //  "f_DefeatedRidley"
                                        //]
                                    },
                                },
                            },
                        },
                        Yields = new[] { "f_TourianOpen" },
                    },
                    new Event {
                        Name = "SM - Tourian Statues Room - Underwater Statues Event",
                        Type = EventType.Flag,
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Tourian Statues Room - Statues Below Lock",
                                Type = LockType.GameFlag,
                                UnlockStrats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "f_DefeatedKraid",
                                        //  "f_DefeatedPhantoon",
                                        //  "f_DefeatedDraygon",
                                        //  "f_DefeatedRidley"
                                        //]
                                    },
                                },
                            },
                        },
                        Yields = new[] { "f_TourianOpen" },
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Tourian Statues Room - Left Door",
                        To = new[] {
                            // The path to the node is considered clear, but the node itself must
                            // be unlocked to actually cross below.
                            new LinkTarget("SM - Tourian Statues Room - Statues Event"),
                        },
                    },
                    new Link {
                        From = "SM - Tourian Statues Room - Elevator",
                        To = new[] {
                            // The path to the node is considered clear, and the event can trigger
                            // coming up from the elevator, but the node itself must be unlocked to
                            // actually cross above.
                            new LinkTarget("SM - Tourian Statues Room - Underwater Statues Event"),
                        },
                    },
                    new Link {
                        From = "SM - Tourian Statues Room - Statues Event",
                        To = new[] {
                            new LinkTarget("SM - Tourian Statues Room - Left Door"),
                            new LinkTarget("SM - Tourian Statues Room - Underwater Statues Event", new[] {
                                new Strat { Requires = null /*["f_TourianOpen"]*/ },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Tourian Statues Room - Underwater Statues Event",
                        To = new[] {
                            new LinkTarget("SM - Tourian Statues Room - Elevator"),
                            // If Tourian is locked, coming in from below results in glitched
                            // graphics. You can reach the elevator to go back down again or sit
                            // through the unlock to get up which in turn can result in persisting
                            // glitched graphics.
                            new LinkTarget("SM - Tourian Statues Room - Statues Event", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "f_TourianOpen",
                                    //  "Gravity"
                                    //]
                                },
                                new Strat {
                                    Name = "Suitless Base",
                                    Requires = null,
                                    //[ "f_TourianOpen",
                                    //  "canSuitlessMaridia",
                                    //  "HiJump",
                                    //  "canSpringBallJumpMidAir"
                                    //]
                                },
                            }),
                        },
                    },
                },
            },
            #endregion
            #region Gauntlet East Room
            new Room {
                Name = "SM - Gauntlet East Room",
                Layout = Room.LayoutFrom(@"
                      1→XXXXX←2"
                    , "SM - Gauntlet East Room - Left Door"
                    , "SM - Gauntlet East Room - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Gauntlet East Room - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 6,
                                SteepUpTiles = 1,
                                SteepDownTiles = 1,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Gauntlet East Room - Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 6,
                                SteepUpTiles = 1,
                                SteepDownTiles = 1,
                                OpenEnd = 1,
                            },
                        },
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Gauntlet East Room - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Gauntlet East Room - Right Door", new[] {
                                new Strat { Requires = null /*["ScrewAttack"]*/ },
                                new Strat {
                                    Name = "Morph Bomb Gauntlet East Room (Right)",
                                    Notable = true,
                                    Requires = null, // ["h_canUseMorphBombs"]
                                },
                                new Strat {
                                    Name = "Power Bomb Gauntlet East Room (Right)",
                                    Notable = true,
                                    Requires = null,
                                    //[ "Morph",
                                    //  "PowerBomb",
                                    //  {"ammo": {
                                    //    "type": "PowerBomb",
                                    //    "count": 3
                                    //  }}
                                    //]
                                },
                                new Strat {
                                    Name = "Shinespark",
                                    Requires = null,
                                    //{"canComeInCharged": {
                                    //  "fromNode": 1,
                                    //  "framesRemaining": 0,
                                    //  "shinesparkFrames": 100
                                    //}}
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Gauntlet East Room - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Gauntlet East Room - Left Door", new[] {
                                new Strat { Requires = null /*["ScrewAttack"]*/ },
                                new Strat {
                                    Name = "Morph Bomb Gauntlet East Room (Left)",
                                    Notable = true,
                                    Requires = null, // ["h_canUseMorphBombs"]
                                },
                                new Strat {
                                    Name = "Power Bomb Gauntlet East Room (Left)",
                                    Notable = true,
                                    Requires = null,
                                    //[ "Morph",
                                    //  "PowerBomb",
                                    //  {"ammo": {
                                    //    "type": "PowerBomb",
                                    //    "count": 3
                                    //  }}
                                    //]
                                },
                                new Strat {
                                    Name = "Shinespark",
                                    Requires = null,
                                    //{"canComeInCharged": {
                                    //  "fromNode": 2,
                                    //  "framesRemaining": 0,
                                    //  "shinesparkFrames": 100
                                    //}}
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Gauntlet East Room - Wavers",
                        EnemyName = "Waver",
                        Quantity = 3,
                        BetweenNodes = new[] {
                            "SM - Gauntlet East Room - Left Door",
                            "SM - Gauntlet East Room - Right Door",
                        },
                    },
                    new Enemy {
                        GroupName = "SM - Gauntlet East Room - Yapping Maws",
                        EnemyName = "Yapping Maw",
                        Quantity = 4,
                        BetweenNodes = new[] {
                            "SM - Gauntlet East Room - Left Door",
                            "SM - Gauntlet East Room - Right Door",
                        },
                    }
                },
            },
            #endregion
            #region Gauntlet West Room
            new Room {
                Name = "SM - Gauntlet West Room",
                Layout = Room.LayoutFrom(@"
                      1→XXXXXX←2"
                    , "SM - Gauntlet West Room - Left Door"
                    , "SM - Gauntlet West Room - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Gauntlet West Room - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 14,
                                SteepUpTiles = 1,
                                SteepDownTiles = 1,
                                OpenEnd = 0,
                            },
                            new RunwayDash {
                                Length = 18,
                                SteepUpTiles = 1,
                                SteepDownTiles= 1,
                                OpenEnd = 1,
                                UsableComingIn = false,
                                Strats = new[] {
                                    // This longer runway requires breaking the bomb blocks.
                                    new Strat {
                                        Obstacles = new[] {
                                            new Strat.Obstacle {
                                                Name = "Runway Thick Bomb Blocks",
                                                Requires = null,
                                                //{"or": [
                                                //  "ScrewAttack",
                                                //  "h_canUseMorphBombs",
                                                //  "h_canUsePowerBombs"
                                                //]}
                                            },
                                        },
                                    },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Gauntlet West Room - Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 10,
                                SteepUpTiles = 1,
                                OpenEnd = 0,
                            },
                        },
                    },
                    new Placement {
                      Name = "SM - Gauntlet West Room - Item",
                      Type = PlacementType.Chozo,
                    },
                    // A junction in the central part of the room, to the right of the
                    // Vertical Bomb Blocks obstacle.
                    new Junction {
                      Name = "SM - Gauntlet West Room - Center Junction",
                    },
                },
                Obstacles = new[] {
                    // The Bomb blocks to the far right respawn and are excluded from this obstacle.
                    // The shot blocks are excluded because they are shot blocks.
                    new Obstacle {
                        Name = "Vertical Bomb Blocks",
                        Type = ObstacleType.Inanimate,
                    },
                    // The leftmost thick wall that can be broken for passage or to extend the
                    // runway.
                    new Obstacle {
                        Name = "Runway Thick Bomb Blocks",
                        Type = ObstacleType.Inanimate,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Gauntlet West Room - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Gauntlet West Room - Center Junction", new[] {
                                new Strat {
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Vertical Bomb Blocks",
                                            Requires = null, // ["ScrewAttack"]
                                        },
                                        new Strat.Obstacle {
                                            Name = "Runway Thick Bomb Blocks",
                                            Requires = null, // ["ScrewAttack"]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Shinespark",
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Runway Thick Bomb Blocks",
                                            Requires = null,
                                            //{"canComeInCharged": {
                                            //  "fromNode": 1,
                                            //  "framesRemaining": 0,
                                            //  "shinesparkFrames": 90
                                            //}}
                                            AdditionalObstacles = new[] { "Vertical Bomb Blocks" },
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Morph Bomb Gauntlet West Room (Right)",
                                    Notable = true,
                                    Obstacles = new[] {
                                        // FIXME health?
                                        new Strat.Obstacle {
                                            Name = "Vertical Bomb Blocks",
                                            Requires = null, // ["h_canUseMorphBombs"]
                                        },
                                        new Strat.Obstacle {
                                            Name = "Runway Thick Bomb Blocks",
                                            Requires = null, // ["h_canUseMorphBombs"]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Power Bomb Gauntlet West Room (Right)",
                                    Notable = true,
                                    Obstacles = new[] {
                                        // FIXME health?
                                        new Strat.Obstacle {
                                            Name = "Vertical Bomb Blocks",
                                            Requires = null,
                                            //[ "Morph",
                                            //  "PowerBomb",
                                            //  {"ammo": {
                                            //    "type": "PowerBomb",
                                            //    "count": 2
                                            //  }}
                                            //]
                                        },
                                        new Strat.Obstacle {
                                            Name = "Runway Thick Bomb Blocks",
                                            Requires = null, // ["h_canUsePowerBombs"]
                                        },
                                    },
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Gauntlet West Room - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Gauntlet West Room - Item"),
                        },
                    },
                    new Link {
                        From = "SM - Gauntlet West Room - Item",
                        To = new[] {
                            new LinkTarget("SM - Gauntlet West Room - Right Door"),
                            new LinkTarget("SM - Gauntlet West Room - Center Junction", new[] {
                                new Strat {
                                    Requires = null,
                                    //{"or":[
                                    //  "h_canUseMorphBombs",
                                    //  "h_canUsePowerBombs"
                                    //]}
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Gauntlet West Room - Center Junction",
                        To = new[] {
                            new LinkTarget("SM - Gauntlet West Room - Left Door", new[] {
                                new Strat {
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Vertical Bomb Blocks",
                                            Requires = null, // ["ScrewAttack"]
                                        },
                                        new Strat.Obstacle {
                                            Name = "Runway Thick Bomb Blocks",
                                            Requires = null, // ["ScrewAttack"]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Morph Bomb Gauntlet West Room (Left)",
                                    Notable = true,
                                    Obstacles = new[] {
                                        // FIXME health?
                                        new Strat.Obstacle {
                                          Name = "Vertical Bomb Blocks",
                                          Requires = null, // ["h_canUseMorphBombs"]
                                        },
                                        new Strat.Obstacle {
                                          Name = "Runway Thick Bomb Blocks",
                                          Requires = null, // ["h_canUseMorphBombs"]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Power Bomb Gauntlet West Room (Left)",
                                    Notable = true,
                                    Obstacles = new[] {
                                        // FIXME health?
                                        new Strat.Obstacle {
                                            Name = "Vertical Bomb Blocks",
                                            Requires = null,
                                            //[ "Morph",
                                            //  "PowerBomb",
                                            //  {"ammo": {
                                            //    "type": "PowerBomb",
                                            //    "count": 2
                                            //  }}
                                            //],
                                        },
                                        new Strat.Obstacle {
                                            Name = "Runway Thick Bomb Blocks",
                                            Requires = null, // ["h_canUsePowerBombs"]
                                        },
                                    },
                                },
                            }),
                            new LinkTarget("SM - Gauntlet West Room - Item", new[] {
                                new Strat {
                                    Requires = null,
                                    //{"or":[
                                    //  "h_canUseMorphBombs",
                                    //  "h_canUsePowerBombs"
                                    //]}
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "Gauntlet West Room - Yapping Maw",
                        EnemyName = "Yapping Maw",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Gauntlet West Room - Left Door" },
                    },
                    new Enemy {
                        GroupName = "Gauntlet West Room - Zebbo",
                        EnemyName = "Zebbo",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Gauntlet West Room - Left Door" },
                        FarmCycles = new[] {
                            new FarmCycle {
                                Name = "Grapple three tiles away",
                                CycleFrames = 130,
                                Requires = null, // ["Grapple"]
                            },
                            new FarmCycle {
                                Name = "Shoot and jump three tiles away",
                                CycleFrames = 160,
                            },
                        },
                    },
                },
            },
            #endregion
        };

    }

}
