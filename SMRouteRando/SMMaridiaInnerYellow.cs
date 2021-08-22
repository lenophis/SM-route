using System.Collections.Generic;
using SMRouteRando.Util;

namespace SMRouteRando {

    public class SMMaridiaInnerYellow {

        public static IList<Room> Rooms { get; } = new[] {
            #region Beach
            new Room {
                Name = "SM - Beach",
                Layout = Room.LayoutFrom(@"
                        XXXX
                      1→XXXX
                        XXX
                        ↑
                        2"
                    , "SM - Beach - Left Door"
                    , "SM - Beach - Bottom Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Beach - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 5,
                                OpenEnd = 1,
                            },
                        },
                        CanLeaveCharged = new[] {
                            new RunwayCharge {
                                Length = 33,
                                FramesRemaining = 0,
                                OpenEnd = 2,
                                Strats = new[] {
                                    // Charge near node 2 then climb up and spark out of the left door.
                                    new Strat {
                                        Name = "Pseudo Plasma Spark Out Left",
                                        Notable = true,
                                        Requires = null, // ["Gravity"]
                                    },
                                },
                            },
                            new RunwayCharge {
                                Length = 33,
                                FramesRemaining = 30,
                                OpenEnd = 2,
                                Strats = new[] {
                                    // Charge near node 2 then climb out and carry the spark
                                    // through the left door.
                                    new Strat {
                                        Name = "Pseudo Plasma Charge Out Left",
                                        Notable = true,
                                        Requires = null,
                                        //[ "Gravity",
                                        //  "HiJump"
                                        //]
                                    },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Beach - Bottom Door",
                        Type = TransitionType.Blue,
                        CanLeaveCharged = new[] {
                            new RunwayCharge {
                                Length = 33,
                                FramesRemaining = 160,
                                OpenEnd = 2,
                                Strats = new[] {
                                    new Strat { Requires = null /*["Gravity"]*/ },
                                },
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - Beach - Item",
                        Type = PlacementType.Visible,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Beach - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Beach - Bottom Door"),
                        },
                    },
                    new Link {
                        From = "SM - Beach - Bottom Door",
                        To = new[] {
                            new LinkTarget("SM - Beach - Left Door", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                new Strat {
                                    Name = "Suitless Jump Assist",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "HiJump",
                                    //  "canSpringBallJumpMidAir"
                                    //]
                                },
                                new Strat {
                                    Name = "Suitless Frozen Skultera",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "canUseFrozenEnemies"
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Beach - Item"),
                        },
                    },
                    new Link {
                        From = "SM - Beach - Item",
                        To = new[] {
                            new LinkTarget("SM - Beach - Bottom Door"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Beach - Choots",
                        EnemyName = "Choot",
                        Quantity = 6,
                        HomeNodes = new[] { "SM - Beach - Left Door" },
                    },
                    new Enemy {
                        GroupName = "SM - Beach - Skulteras",
                        EnemyName = "Skultera",
                        Quantity = 2,
                        HomeNodes = new[] { "SM - Beach - Bottom Door" },
                    },
                    new Enemy {
                        GroupName = "SM - Beach - Owtch",
                        EnemyName = "Owtch",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Beach - Bottom Door" },
                    },
                },
            },
            #endregion
            // Todo: Better name?
            #region Northwest Maridia Bug Room
            new Room {
                Name = "SM - Northwest Maridia Bug Room",
                Layout = Room.LayoutFrom(@"
                      1→X
                        XXXX←2"
                    , "SM - Northwest Maridia Bug Room - Left Door"
                    , "SM - Northwest Maridia Bug Room - Right Door"
                ),
                Nodes = new[] {
                    new Transition {
                        Name = "SM - Northwest Maridia Bug Room - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 5,
                                OpenEnd = 1,
                            },
                        },
                        CanLeaveCharged = new[] {
                            new RunwayCharge {
                                Length = 22,
                                OpenEnd = 2,
                                FramesRemaining = 0,
                                ShinesparkFrames = 15,
                                Strats = new[] {
                                    new Strat {
                                        // Charge below then climb up and carry the spark out of
                                        // the left door.
                                        Name = "Bug Room Charge Out Left",
                                        Notable = true,
                                    },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Northwest Maridia Bug Room - Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 4,
                                OpenEnd = 1,
                            },
                        },
                        CanLeaveCharged = new[] {
                            // MustOpenDoorFirst is false because the door can be shot before
                            // initiating the spark.
                            new RunwayCharge {
                                Length = 22,
                                OpenEnd = 2,
                                FramesRemaining = 0,
                                ShinesparkFrames = 30,
                                InitiateRemotely = new() {
                                    InitiateAt = "SM - Northwest Maridia Bug Room - Left Door",
                                    MustOpenDoorFirst = false,
                                    PathToDoor = new[] {
                                        new PathStep("SM - Northwest Maridia Bug Room - Right Door", new[] { "Base" }),
                                    },
                                },
                                Strats = new[] {
                                    // Charge below Left Door then carry the spark through the
                                    // morph tunnel and out the right door. This is a lot trickier
                                    // without Gravity because the tide must be timed correctly.
                                    new Strat {
                                        Name = "Bug Room Charge Out Right (Gravityless)",
                                        Notable = true,
                                    },
                                    // Charge below Left Door then carry the spark through the
                                    // morph tunnel and out the right door. This is easier with
                                    // Gravity because the tide won't interfere.
                                    new Strat {
                                        Name = "Bug Room Charge Out Right (Gravity)",
                                        Notable = true,
                                        Requires = null, // ["Gravity"]
                                    },
                                },
                            },
                        },
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Northwest Maridia Bug Room - Left Door",
                        To = new[] {
                            // It's not clear whether the risk of falling into the water pits
                            // should count as water navigation. We went with yes for now, mostly
                            // because dealing with the Menus at the same time is not trivial.
                            new LinkTarget("SM - Northwest Maridia Bug Room - Right Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "Morph",
                                    //  "h_canNavigateUnderwater"
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Northwest Maridia Bug Room - Right Door",
                        To = new[] {
                            // It's not clear whether the risk of falling into the water pits
                            // should count as water navigation. We went with yes for now, mostly
                            // because dealing with the Menus at the same time is not trivial.
                            new LinkTarget("SM - Northwest Maridia Bug Room - Left Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "Morph",
                                    //  "h_canNavigateUnderwater",
                                    //  {"or":[
                                    //    "h_canPassBombPassages",
                                    //    "h_canUseSpringBall"
                                    //  ]}
                                    //]
                                },
                                // Freeze one of the bugs (called Menus) in a position where you can
                                // use it to get into the morph passage. That allows passage without
                                // having to gain height while being morphed.
                                new Strat {
                                    Name = "Maridia Bug Room Frozen Menu Bridge",
                                    Notable = true,
                                    Requires = null,
                                    //[ "Morph",
                                    //  "h_canNavigateUnderwater",
                                    //  "canTrickyUseFrozenEnemies"
                                    //]
                                },
                                // This probably needs to be behind a tech as well? With Gravity, it's
                                // possible to move forward and mid-air morph into the morph passage.
                                // The momentum can push Samus into the tunnel, no need to press
                                // forward while in mid-air.
                                new Strat {
                                    Name = "Maridia Bug Room MidAir Morph",
                                    Notable = true,
                                    Requires = null,
                                    //[ "Morph",
                                    //  "Gravity"
                                    //]
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "Maridia Bug Room Left Owtches",
                        EnemyName = "Owtch",
                        Quantity = 4,
                        HomeNodes = new[] { "SM - Northwest Maridia Bug Room - Left Door" },
                    },
                    new Enemy {
                        GroupName = "Maridia Bug Room Left Menus",
                        EnemyName = "Menu",
                        Quantity = 3,
                        HomeNodes = new[] { "SM - Northwest Maridia Bug Room - Left Door" },
                    },
                    new Enemy {
                        GroupName = "Maridia Bug Room Right Owtches",
                        EnemyName = "Owtch",
                        Quantity = 3,
                        HomeNodes = new[] { "SM - Northwest Maridia Bug Room - Right Door" },
                    },
                    new Enemy {
                        GroupName = "Maridia Bug Room Right Menus",
                        EnemyName = "Menu",
                        Quantity = 2,
                        HomeNodes = new[] { "SM - Northwest Maridia Bug Room - Right Door" },
                    },
                },
            },
            #endregion
            #region Watering Hole
            new Room {
                Name = "SM - Watering Hole",
                Layout = Room.LayoutFrom(@"
                      XX←1
                      X
                      X"
                    , "SM - Watering Hole - Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Watering Hole - Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 4,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - Watering Hole - Left Item",
                        Type = PlacementType.Visible,
                    },
                    new Placement {
                        Name = "SM - Watering Hole - Right Item",
                        Type = PlacementType.Visible,
                    },
                    new Junction {
                        Name = "SM - Watering Hole - Bottom Junction",
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Watering Hole - Door",
                        To = new[] {
                            new LinkTarget("SM - Watering Hole - Bottom Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Watering Hole - Left Item",
                        To = new[] {
                            new LinkTarget("SM - Watering Hole - Bottom Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Watering Hole - Right Item",
                        To = new[] {
                            new LinkTarget("SM - Watering Hole - Bottom Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Watering Hole - Bottom Junction",
                        To = new[] {
                            new LinkTarget("SM - Watering Hole - Door", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                new Strat {
                                    Name = "Suitless Jump Assist",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  {"or":[
                                    //    "HiJump",
                                    //    "canSpringBallJumpMidAir"
                                    //  ]}
                                    //]
                                },
                                // A stationary spinjump can put Samus into a situation where she
                                // can slowly infinite walljump to freedom.
                                new Strat {
                                    Name = "Naked Watering Hole Escape",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "canStationarySpinJump"
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Watering Hole - Left Item"),
                            new LinkTarget("SM - Watering Hole - Right Item"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Watering Hole - Zebs",
                        EnemyName = "Zeb",
                        Quantity = 2,
                        HomeNodes = new[] { "SM - Watering Hole - Door" },
                        FarmCycles = new[] {
                            // Running back and forth with proper timing can be a bit faster than
                            // camping just one of them.
                            new FarmCycle {
                                Name = "Half-screen back and forth",
                                CycleFrames = 200,
                            },
                        },
                    },
                    new Enemy {
                        GroupName = "SM - Watering Hole - Choot",
                        EnemyName = "Choot",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Watering Hole - Door" },
                    },
                },
            },
            #endregion
            // Todo: Better name?
            #region Plasma Spark Room
            new Room {
                Name = "SM - Plasma Spark Room",
                Layout = Room.LayoutFrom(@"
                       XX
                       XX←1
                      XXXX
                      ↑XXX←2
                      4XXX
                       XXX←3"
                    , "SM - Plasma Spark Room - Top Right Door"
                    , "SM - Plasma Spark Room - Middle Right Door"
                    , "SM - Plasma Spark Room - Bottom Right Door"
                    , "SM - Plasma Spark Room - Left Vertical Bottom Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Plasma Spark Room - Top Right Door",
                        Type = TransitionType.Gray,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 6,
                                OpenEnd = 1,
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Plasma Spark Room - Grey Lock",
                                Type = LockType.GameFlag,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["f_DefeatedDraygon"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Plasma Spark Room - Middle Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 4,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Plasma Spark Room - Bottom Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 33,
                                OpenEnd = 1,
                                Strats = new[] {
                                    new Strat { Requires = null /*["Gravity"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Plasma Spark Room - Left Vertical Bottom Door",
                        Type = TransitionType.Green,
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Plasma Spark Room - Green Lock",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenGreenDoors"]*/ },
                                },
                            },
                        },
                    },
                    // This exists mostly in case it ends up being helpful for handling walljumps later.
                    new Junction {
                        Name = "SM - Plasma Spark Room - Top Junction",
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Plasma Spark Room - Left Vertical Bottom Door",
                        To = new[] {
                            new LinkTarget("SM - Plasma Spark Room - Bottom Right Door"),
                            new LinkTarget("SM - Plasma Spark Room - Top Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Plasma Spark Room - Bottom Right Door",
                        To = new[] {
                            new LinkTarget("SM - Plasma Spark Room - Left Vertical Bottom Door", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                new Strat {
                                    Name = "Suitless Jump Assist",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "HiJump",
                                    //  "canSpringBallJumpMidAir"
                                    //]
                                },
                                new Strat {
                                    Name = "Suitless Frozen Skultera",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "HiJump",
                                    //  "canUseFrozenEnemies"
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Plasma Spark Room - Middle Right Door", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                new Strat {
                                    Name = "Suitless Jump Assist",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  {"or": [
                                    //    "HiJump",
                                    //    "canSpringBallJumpMidAir"
                                    //  ]}
                                    //]
                                },
                                // Doesn't actually require stepping on two successive Skulteras.
                                // Doable by standing on the left edge of the top ledge and crouch
                                // jump + downgrabbing on the top fish.
                                new Strat {
                                    Name = "Plasma Spark Fish Climb",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "canUseFrozenEnemies"
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Plasma Spark Room - Middle Right Door",
                        To = new[] {
                            new LinkTarget("SM - Plasma Spark Room - Bottom Right Door"),
                            new LinkTarget("SM - Plasma Spark Room - Top Right Door"),
                        },
                    },
                    new Link {
                        From = "SM - Plasma Spark Room - Top Right Door",
                        To = new[] {
                            new LinkTarget("SM - Plasma Spark Room - Middle Right Door"),
                            new LinkTarget("SM - Plasma Spark Room - Top Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Plasma Spark Room - Top Junction",
                        To = new[] {
                            new LinkTarget("SM - Plasma Spark Room - Left Vertical Bottom Door"),
                            new LinkTarget("SM - Plasma Spark Room - Top Right Door"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "Plasma Spark Room Left Choot",
                        EnemyName = "Choot",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Plasma Spark Room - Left Vertical Bottom Door" },
                    },
                    new Enemy {
                        GroupName = "Plasma Spark Room Bottom Choots",
                        EnemyName = "Choot",
                        Quantity = 2,
                        HomeNodes = new[] { "SM - Plasma Spark Room - Middle Right Door" },
                    },
                    new Enemy {
                        GroupName = "Plasma Spark Room Top Choots",
                        EnemyName = "Choot",
                        Quantity = 2,
                        HomeNodes = new[] { "SM - Plasma Spark Room - Top Junction" },
                    },
                    new Enemy {
                        GroupName = "Plasma Spark Room Owtches",
                        EnemyName = "Owtch",
                        Quantity = 4,
                        HomeNodes = new[] { "SM - Plasma Spark Room - Bottom Right Door" },
                    },
                    new Enemy {
                        GroupName = "Plasma Spark Room Top Skulteras",
                        EnemyName = "Skultera",
                        Quantity = 2,
                        HomeNodes = new[] { "SM - Plasma Spark Room - Bottom Right Door" },
                    },
                },
            },
            #endregion
            #region Bug Sand Hole
            new Room {
                Name = "SM - Bug Sand Hole",
                Layout = Room.LayoutFrom(@"
                      1→X←2
                        ↑
                        3"
                    , "SM - Bug Sand Hole - Left Door"
                    , "SM - Bug Sand Hole - Right Door"
                    , "SM - Bug Sand Hole - Sand Exit"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Bug Sand Hole - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 0,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Bug Sand Hole - Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 0,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Bug Sand Hole - Sand Exit",
                        Type = TransitionType.Sandpit,
                        Direction = TransitionDirection.Exit,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Bug Sand Hole - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Bug Sand Hole - Sand Exit"),
                            new LinkTarget("SM - Bug Sand Hole - Right Door", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                new Strat {
                                    Name = "Bug Sand Room Suitless HiJump (L to R)",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "HiJump"
                                    //]
                                },
                                new Strat {
                                    Name = "Bug Sand Room Suitless Frozen Bridge (L to R)",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "canUseFrozenEnemies"
                                    //]
                                },
                                new Strat {
                                    Name = "Bug Sand Room Suitless Kill Yapping Maws (L to R)",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  {"enemyKill":{
                                    //    "enemies": [
                                    //      ["Yapping Maw", "Yapping Maw"]
                                    //    ]
                                    //  }}
                                    //]
                                },
                                new Strat {
                                    Name = "Naked Bug Sand Room (L to R)",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "canQuickLowTideWalljumpWaterEscape"
                                    //]
                                },
                                // Requires shooting the door in midiar, otherwise water is involved.
                                new Strat {
                                    Name = "Bug Sand Room Space Jump (L to R)",
                                    Notable = true,
                                    Requires = null, // ["SpaceJump"]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Bug Sand Hole - Sand Exit",
                        To = Empty<LinkTarget>.List,
                    },
                    new Link {
                        From = "SM - Bug Sand Hole - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Bug Sand Hole - Left Door", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                new Strat {
                                    Name = "Bug Sand Room Suitless HiJump (R to L)",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "HiJump"
                                    //]
                                },
                                new Strat {
                                    Name = "Bug Sand Room Suitless Frozen Bridge (R to L)",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "canUseFrozenEnemies"
                                    //]
                                },
                                new Strat {
                                    Name = "Bug Sand Room Suitless Kill Yapping Maws (R to L)",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  {"enemyKill":{
                                    //    "enemies": [
                                    //      ["Yapping Maw", "Yapping Maw"]
                                    //    ]
                                    //  }}
                                    //]
                                },
                                new Strat {
                                    Name = "Naked Bug Sand Room (R to L)",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "canQuickLowTideWalljumpWaterEscape"
                                    //]
                                },
                                // Requires shooting the door in midiar, otherwise water is involved.
                                new Strat {
                                    Name = "Bug Sand Room Space Jump (R to L)",
                                    Notable = true,
                                    Requires = null, // ["SpaceJump"]
                                },
                            }),
                            new LinkTarget("SM - Bug Sand Hole - Sand Exit"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Bug Sand Hole - Zoa",
                        EnemyName = "Zoa",
                        Quantity = 1,
                        HomeNodes = new[] {
                            "SM - Bug Sand Hole - Left Door",
                            "SM - Bug Sand Hole - Right Door",
                        },
                        FarmCycles = new[] {
                            // Leaving this logically unfarmable until further notice because it sucks.
                            new FarmCycle {
                                Name = "Forget it",
                                CycleFrames = 120,
                                Requires = null, // ["never"]
                            },
                        },
                    },
                    new Enemy {
                        GroupName = "SM - Bug Sand Hole - Yapping Maws",
                        EnemyName = "Yapping Maw",
                        Quantity = 2,
                        HomeNodes = new[] {
                            "SM - Bug Sand Hole - Left Door",
                            "SM - Bug Sand Hole - Right Door",
                        },
                    },
                },
            },
            #endregion
            // Todo: Acceptable name?
            #region Short Quicksand Room
            new Room {
                Name = "SM - Short Quicksand Room",
                Layout = Room.LayoutFrom(@"
                      1
                      ↓
                      X
                      ↑
                      2"
                    , "SM - Short Quicksand Room - Top Sand Entrance"
                    , "SM - Short Quicksand Room - Bottom Sand Exit"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Short Quicksand Room - Top Sand Entrance",
                        Type = TransitionType.Sandpit,
                        Direction = TransitionDirection.Enter,
                    },
                    new Transition {
                        Name = "SM - Short Quicksand Room - Bottom Sand Exit",
                        Type = TransitionType.Sandpit,
                        Direction = TransitionDirection.Exit,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Short Quicksand Room - Top Sand Entrance",
                        To = new[] {
                            new LinkTarget("SM - Short Quicksand Room - Bottom Sand Exit"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Short Quicksand Room - Bulls",
                        EnemyName = "Bull",
                        Quantity = 3,
                        HomeNodes = new[] {
                            "SM - Short Quicksand Room - Top Sand Entrance",
                            "SM - Short Quicksand Room - Bottom Sand Exit",
                        },
                    },
                },
            },
            #endregion
            #region Butterfly Room
            new Room {
                Name = "SM - Butterfly Room",
                Layout = Room.LayoutFrom(@"
                        2
                        ↓
                      1→X←3"
                    , "SM - Butterfly Room - Left Door"
                    , "SM - Butterfly Room - Top Sand Entrance"
                    , "SM - Butterfly Room - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Butterfly Room - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 0,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Butterfly Room - Top Sand Entrance",
                        Type = TransitionType.Sandpit,
                        Direction = TransitionDirection.Enter,
                    },
                    new Transition {
                        Name = "SM - Butterfly Room - Right Door",
                        Type = TransitionType.Gray,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 0,
                                OpenEnd = 1,
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Butterfly Room - Grey Lock",
                                Type = LockType.GameFlag,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["f_DefeatedDraygon"]*/ },
                                },
                                BypassStrats = new[] {
                                    // The 2 hits enemy damage on the bypass is pretty much a
                                    // worst-case scenario where the next-to-last Zoa you kill
                                    // doesn't give you energy.
                                    new Strat {
                                        Name = "Botwoon Skip",
                                        Notable = true,
                                        Requires = null,
                                        //[ "h_canNavigateUnderwater",
                                        //  "canWallIceClip",
                                        //  {"enemyDamage": {
                                        //    "enemy": "Zoa",
                                        //    "type": "contact",
                                        //    "hits": 2
                                        //  }}
                                        //]
                                    },
                                },
                            },
                        },
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Butterfly Room - Left Door",
                        To = new[] {
                            // This link refers specifically to crossing on frozen enemies. Failing
                            // here will lead to a softlock.
                            new LinkTarget("SM - Butterfly Room - Right Door", new[] {
                                new Strat {
                                    Name = "Frozen Zoa",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "canUseFrozenEnemies"
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Butterfly Room - Top Sand Entrance", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                // HiJump logically required to move here suitless, as you need it
                                // to get back out if you're not arriving at the node from the sand
                                // chute.
                                new Strat {
                                    Name = "Suitless",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "HiJump"
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Butterfly Room - Right Door",
                        To = new[] {
                            // This link refers specifically to crossing on frozen enemies. Failing
                            // here will lead to a softlock.
                            new LinkTarget("SM - Butterfly Room - Left Door", new[] {
                                new Strat {
                                    Name = "Frozen Zoa",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "canUseFrozenEnemies"
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Butterfly Room - Top Sand Entrance", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                // HiJump logically required to move here suitless, as you need it
                                // to get back out if you're not arriving at the node from the sand
                                // chute.
                                new Strat {
                                    Name = "Suitless",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "HiJump"
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Butterfly Room - Top Sand Entrance",
                        To = new[] {
                            // Failing here without gravity or hiJump will lead to a softlock.
                            new LinkTarget("SM - Butterfly Room - Left Door", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                new Strat { Requires = null /*["canSuitlessMaridia"]*/ },
                            }),
                            // Failing here without gravity or hiJump will lead to a softlock.
                            new LinkTarget("SM - Butterfly Room - Right Door", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                new Strat { Requires = null /*["canSuitlessMaridia"]*/ },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Butterfly Room - Zoas",
                        EnemyName = "Zoa",
                        Quantity = 3,
                        HomeNodes = new[] { "SM - Butterfly Room - Top Sand Entrance" },
                        FarmCycles = new[] {
                            // Realistically could require a suit or hjb or something, but that's
                            // already needed to get in or out of the node.
                            new FarmCycle {
                                Name = "Farm 2 Zoas out of 3",
                                CycleFrames = 225,
                            },
                            // Technically doable without reaching node 3, but oh well.
                            new FarmCycle {
                                Name = "Grapple",
                                CycleFrames = 175,
                                Requires = null, // ["Grapple"]
                            },
                        },
                    },
                },
            },
            #endregion
            #region Thread The Needle Room
            new Room {
                Name = "SM - Thread The Needle Room",
                Layout = Room.LayoutFrom(@"
                      1→XXXXXXX←2"
                    , "SM - Thread The Needle Room - Left Door"
                    , "SM - Thread The Needle Room - RightDoor"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Thread The Needle Room - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 4,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Thread The Needle Room - Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 4,
                                OpenEnd = 1,
                            },
                        },
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Thread The Needle Room - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Thread The Needle Room - Right Door"),
                        },
                    },
                    new Link {
                        From = "SM - Thread The Needle Room - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Thread The Needle Room - Left Door"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Thread The Needle Room - Left Choots",
                        EnemyName = "Choot",
                        Quantity = 5,
                        HomeNodes = new[] { "SM - Thread The Needle Room - Left Door" },
                    },
                    new Enemy {
                        GroupName = "SM - Thread The Needle Room - Left Puyos",
                        EnemyName = "Puyo",
                        Quantity = 5,
                        HomeNodes = new[] { "SM - Thread The Needle Room - Left Door" },
                    },
                    new Enemy {
                        GroupName = "SM - Thread The Needle Room - Right Choots",
                        EnemyName = "Choot",
                        Quantity = 3,
                        HomeNodes = new[] { "SM - Thread The Needle Room - Right Door" },
                    },
                    new Enemy {
                        GroupName = "SM - Thread The Needle Room - Right Puyos",
                        EnemyName = "Puyo",
                        Quantity = 2,
                        HomeNodes = new[] { "SM - Thread The Needle Room - Right Door" },
                    },
                },
            },
            #endregion
            #region Maridia Elevator Room
            new Room {
                Name = "SM - Maridia Elevator Room",
                Layout = Room.LayoutFrom(@"
                        2
                        ↓
                        X
                        X
                        X←3
                      1→X"
                    , "SM - Maridia Elevator Room - Left Door"
                    , "SM - Maridia Elevator Room - Elevator"
                    , "SM - Maridia Elevator Room - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Maridia Elevator Room - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 1,
                                OpenEnd = 1,
                                UsableComingIn = false,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Maridia Elevator Room - Elevator",
                        Type = TransitionType.Elevator,
                    },
                    new Transition {
                        Name = "SM - Maridia Elevator Room - Right Door",
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
                                Name = "SM - Maridia Elevator Room - Red Lock",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenRedDoors"]*/ },
                                },
                            },
                        },
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Maridia Elevator Room - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Maridia Elevator Room - Right Door"),
                            // Only the the direct shinespark. Other strats should go Left Door ->
                            // Right Door -> Elevator.
                            new LinkTarget("SM - Maridia Elevator Room - Elevator", new[] {
                                // One walljump on the left before a diagonal spark.
                                new Strat {
                                    Name = "Shinespark",
                                    Requires = null,
                                    //{"canComeInCharged": {
                                    //  "fromNode": 1,
                                    //  "framesRemaining": 60,
                                    //  "shinesparkFrames": 45
                                    //}}
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Maridia Elevator Room - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Maridia Elevator Room - Left Door"),
                            new LinkTarget("SM - Maridia Elevator Room - Elevator", new[] {
                                new Strat {
                                    Name = "Frozen Rippers",
                                    Requires = null, // ["canUseFrozenEnemies"]
                                },
                                new Strat {
                                    Name = "Kill Rippers",
                                    Requires = null,
                                    //{"enemyKill":{
                                    //  "enemies": [
                                    //    ["Ripper", "Ripper", "Ripper"]
                                    //  ]
                                    //}}
                                },
                                // The walljumps are considered to require precision only if the
                                // Rippers are not killed.
                                new Strat {
                                    Name = "Maridia Elevator Room Wall Climb",
                                    Notable = true,
                                    Requires = null, // ["canPreciseWalljump"]
                                },
                                new Strat {
                                    Name = "Shinespark",
                                    Requires = null,
                                    //{"canComeInCharged": {
                                    //  "fromNode": 2,
                                    //  "framesRemaining": 40,
                                    //  "shinesparkFrames": 35
                                    //}}
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Maridia Elevator Room - Elevator",
                        To = new[] {
                            new LinkTarget("SM - Maridia Elevator Room - Right Door"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "Maridia Elevator Room Owtch",
                        EnemyName = "Owtch",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Maridia Elevator Room - Left Door" },
                    },
                    new Enemy {
                        GroupName = "Maridia Elevator Room Bottom Rippers",
                        EnemyName = "Ripper",
                        Quantity = 2,
                        HomeNodes = new[] { "SM - Maridia Elevator Room - Right Door" },
                    },
                    new Enemy {
                        GroupName = "Maridia Elevator Room Middle Rippers",
                        EnemyName = "Ripper",
                        Quantity = 2,
                        BetweenNodes = new[] {
                            "SM - Maridia Elevator Room - Right Door",
                            "SM - Maridia Elevator Room - Elevator",
                        },
                    },
                    new Enemy {
                        GroupName = "Maridia Elevator Room Top Rippers",
                        EnemyName = "Ripper",
                        Quantity = 2,
                        HomeNodes = new[] { "SM - Maridia Elevator Room - Elevator" },
                    },
                },
            },
            #endregion
            #region Maridia Yellow Save Room
            new Room {
                Name = "SM - Maridia Yellow Save Room",
                Layout = Room.LayoutFrom(@"
                      1→X"
                    , "SM - Maridia Yellow Save Room - Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Maridia Yellow Save Room - Door",
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
                        Name = "SM - Maridia Yellow Save Room - Save Station",
                        Type = UtilityType.Save,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Maridia Yellow Save Room - Door",
                        To = new[] {
                            new LinkTarget("SM - Maridia Yellow Save Room - Save Station"),
                        },
                    },
                    new Link {
                        From = "SM - Maridia Yellow Save Room - Save Station",
                        To = new [] {
                            new LinkTarget("SM - Maridia Yellow Save Room - Door"),
                        },
                    },
                },
            },
            #endregion
            #region Kassiuz Room
            new Room {
                Name = "SM - Kassiuz Room",
                Layout = Room.LayoutFrom(@"
                        X←2
                        X
                        X
                      1→X"
                    , "SM - Kassiuz Room - Left Door"
                    , "SM - Kassiuz Room - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Kassiuz Room - Left Door",
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
                        Name = "SM - Kassiuz Room - Right Door",
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
                        From = "SM - Kassiuz Room - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Kassiuz Room - Right Door"),
                        },
                    },
                    new Link {
                        From = "SM - Kassiuz Room - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Kassiuz Room - Left Door"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Kassiuz Room -Choots",
                        EnemyName = "Choot",
                        Quantity = 3,
                        HomeNodes = new[] {
                            "SM - Kassiuz Room - Left Door",
                            "SM - Kassiuz Room - Right Door",
                        },
                    },
                    new Enemy {
                        GroupName = "SM - Kassiuz Room - Puyos",
                        EnemyName = "Puyo",
                        Quantity = 4,
                        HomeNodes = new[] {
                            "SM - Kassiuz Room - Left Door",
                            "SM - Kassiuz Room - Right Door",
                        },
                    },
                },
            },
            #endregion
            // Todo: Acceptable name?
            #region Maridia Tunnel C
            new Room {
                Name = "SM - Maridia Tunnel C",
                Layout = Room.LayoutFrom(@"
                      1→X←2"
                    , "SM - Maridia Tunnel C - Left Door"
                    , "SM - Maridia Tunnel C - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Maridia Tunnel C - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 0,
                            },
                            new RunwayDash {
                                Length = 12,
                                OpenEnd = 0,
                                UsableComingIn = false,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Maridia Tunnel C - Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 7,
                                OpenEnd = 0,
                            },
                            new RunwayDash {
                                Length = 12,
                                OpenEnd = 0,
                                UsableComingIn = false,
                            },
                        },
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Maridia Tunnel C - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Maridia Tunnel C - Right Door"),
                        },
                    },
                    new Link {
                        From = "SM - Maridia Tunnel C - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Maridia Tunnel C - Left Door"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Maridia Tunnel C - Puyos",
                        EnemyName = "Puyo",
                        Quantity = 6,
                        HomeNodes = new[] { "SM - Maridia Tunnel C - Left Door" },
                    }
                },
            },
            #endregion
            // Todo: Acceptable name?
            #region Pirate Chozo Room
            new Room {
                Name = "SM - Pirate Chozo Room",
                Layout = Room.LayoutFrom(@"
                      1→XX
                        XX
                        XX"
                    , "SM - Pirate Chozo Room - Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Pirate Chozo Room - Door",
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
                                Name = "SM - Pirate Chozo Room - Grey Lock",
                                Type = LockType.KillEnemies,
                                UnlockStrats = new[] {
                                    // To avoid redundant requirements, obstacle must be destroyed
                                    // by going to Item and back.
                                    new Strat {
                                        Obstacles = new[] {
                                            new Strat.Obstacle {
                                                Name = "Pink Pirates",
                                                Requires = null, // ["never"]
                                            },
                                        },
                                    },
                                },
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - Pirate Chozo Room - Item",
                        Type = PlacementType.Chozo,
                    },
                    // Intended to logically separate killing the standing enemies (who have actual
                    // requirements) from climbing out of the room.
                    new Junction {
                        Name = "SM - Pirate Chozo Room - Pirates Dead Junction",
                    },
                },
                Obstacles = new[] {
                    // Enemies that must be cleared to unlock the room. Take note that the wall
                    // pirates do not have special immunities.
                    new Obstacle {
                        Name = "Pink Pirates",
                        Type = ObstacleType.Enemies,
                    }
                },
                Links = new[] {
                    new Link {
                        From = "SM - Pirate Chozo Room - Door",
                        To = new[] {
                            new LinkTarget("SM - Pirate Chozo Room - Item"),
                        },
                    },
                    new Link {
                        From = "SM - Pirate Chozo Room - Item",
                        To = new[] {
                            // Passing through Pirates Dead Junction would not be strictly required
                            // to reach Door, but it's needed to unlock the room and there's no
                            // logical reason to come back a second time.
                            new LinkTarget("SM - Pirate Chozo Room - Pirates Dead Junction", new[] {
                                new Strat {
                                    Name = "Simple Weapons",
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Pink Pirates",
                                            Requires = null,
                                            //{"or":[
                                            //  "Plasma",
                                            //  "ScrewAttack"
                                            //]}
                                        },
                                    },
                                },
                                // The 4 standing pirates take 2 Pseudo Screws to kill, so Samus must take 4 hits.
                                new Strat {
                                    Name = "Plasma Room Pseudo Screw",
                                    Notable = true,
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Pink Pirates",
                                            Requires = null,
                                            //[ "Charge",
                                            //  {"enemyDamage": {
                                            //    "enemy": "Pink Space Pirate (standing)",
                                            //    "type": "contact",
                                            //    "hits": 4
                                            //  }}
                                            //]
                                        },
                                    },
                                },
                                // Killing the pirates with shinesparks requires 4 sparks that total about 100 frames.
                                new Strat {
                                    Name = "Plasma Room Spark Clear",
                                    Notable = true,
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Pink Pirates",
                                            Requires = null,
                                            //{"canShineCharge": {
                                            //  "usedTiles": 19,
                                            //  "shinesparkFrames": 100,
                                            //  "openEnd": 1
                                            //}}
                                        },
                                    },
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Pirate Chozo Room - Pirates Dead Junction",
                        To = new[] {
                            new LinkTarget("SM - Pirate Chozo Room - Door", new[] {
                                new Strat { Requires = null /*["h_canFly"]*/},
                                new Strat {
                                    Name = "Speedjump",
                                    Requires = null,
                                    //[ "SpeedBooster",
                                    //  "HiJump"
                                    //]
                                },
                                new Strat {
                                    Name = "Shinespark",
                                    Requires = null,
                                    //{"canShineCharge": {
                                    //  "usedTiles": 21,
                                    //  "shinesparkFrames": 30,
                                    //  "openEnd": 0
                                    //}}
                                },
                                // It's possible to climb up with just ice by freezing the lower
                                // wall space pirate (who can be frozen and killed without Plasma).
                                new Strat {
                                    Name = "Frozen Wall Pirate Plasma Escape",
                                    Notable = true,
                                    Requires = null, // ["canUseFrozenEnemies"]
                                },
                                // This is the same size of ledge as WRITG, so it should be equally possible.
                                new Strat {
                                    Name = "Plasma Hj Walljump",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canPreciseWalljump",
                                    //  "HiJump"
                                    //]
                                },
                                // This is the same size of ledge as WRITG, so it should be equally possible.
                                new Strat {
                                    Name = "Plasma Hjless Walljump",
                                    Notable = true,
                                    Requires = null, // ["canInsaneWalljump"]
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Pirate Chozo Room - Top Standing Pirate",
                        EnemyName = "Pink Space Pirate (standing)",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Pirate Chozo Room - Door" },
                    },
                    new Enemy {
                        GroupName = "SM - Pirate Chozo Room - Bottom Standing Pirates",
                        EnemyName = "Pink Space Pirate (standing)",
                        Quantity = 3,
                        HomeNodes = new[] { "SM - Pirate Chozo Room - Item" },
                    },
                    new Enemy {
                        GroupName = "SM - Pirate Chozo Room - Wall Pirates",
                        EnemyName = "Pink Space Pirate (wall)",
                        Quantity = 2,
                        HomeNodes = new[] { "SM - Pirate Chozo Room - Item" },
                    },
                },
            },
            #endregion
        };

    }

}
