using System.Collections.Generic;

namespace SMRouteRando {

    public class SMBrinstarGreen {

        public static IList<Room> Rooms { get; } = new[] {
            #region Green Brinstar Main Shaft Complex
            new Room {
                Name = "SM - Brinstar Green Main Shaft Complex",
                // Don't need to mention the in-room door pair as these will always connect to each
                // other in a spatially correct layout.
                Layout = Room.LayoutFrom(@"
                        6
                        ↓
                        X
                        X
                      5→X←7
                      4→X
                      3→X←8
                        XXXX
                        X X
                        X X
                      2→XXX
                        1→X"
                    , "SM - Brinstar Green Main Shaft Complex - Bottom Left Etecoons Door"
                    , "SM - Brinstar Green Main Shaft Complex - Bottom Left Door"
                    , "SM - Brinstar Green Main Shaft Complex - Middle Bottom Left Door"
                    , "SM - Brinstar Green Main Shaft Complex - Middle Top Left Door"
                    , "SM - Brinstar Green Main Shaft Complex - Top Left Door"
                    , "SM - Brinstar Green Main Shaft Complex - Elevator"
                    , "SM - Brinstar Green Main Shaft Complex - Top Right Door"
                    , "SM - Brinstar Green Main Shaft Complex - Middle Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Brinstar Green Main Shaft Complex - Bottom Left Etecoons Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 8,
                                OpenEnd = 0,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Brinstar Green Main Shaft Complex - Bottom Left Door",
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
                        Name = "SM - Brinstar Green Main Shaft Complex - Top Left Etecoons Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 1,
                            },
                        },
                        CanLeaveCharged = new[] {
                            new RunwayCharge {
                                Length = 17,
                                OpenEnd = 1,
                                FramesRemaining = 110,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Brinstar Green Main Shaft Complex - Middle Bottom Left Door",
                        Type = TransitionType.Red,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 12,
                                OpenEnd = 0,
                                Strats = new[] {
                                    // Runway is not usable if the PB blocks are broken.
                                    new Strat {
                                        Requires = null,
                                        //{"resetRoom":{
                                        //  "nodes": [1, 2, 3, 4, 5, 6, 7, 8, 9, 10],
                                        //  "obstaclesToAvoid": [ "A" ]
                                        //}}
                                    },
                                },
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Brinstar Green Main Shaft Complex - Mid-Low Left Red Lock",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenRedDoors"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Brinstar Green Main Shaft Complex - Middle Top Left Door",
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
                                Name = "SM - Brinstar Green Main Shaft Complex - Mid-High Left Red Lock",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenRedDoors"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Brinstar Green Main Shaft Complex - Top Left Door",
                        Type = TransitionType.Red,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 1,
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Brinstar Green Main Shaft Complex - Top Left Red Lock",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenRedDoors"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Brinstar Green Main Shaft Complex - Elevator",
                        Type = TransitionType.Elevator,
                    },
                    new Transition {
                        Name = "SM - Brinstar Green Main Shaft Complex - Top Right Door",
                        Type = TransitionType.Red,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 4,
                                OpenEnd = 1,
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Brinstar Green Main Shaft Complex - Top Right Red Lock",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenRedDoors"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Brinstar Green Main Shaft Complex - Middle Right Door",
                        Type = TransitionType.Red,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 12,
                                OpenEnd = 0,
                                Strats = new[] {
                                    // Runway is not usable if the PB blocks are broken.
                                    new Strat {
                                        Requires = null,
                                        //{"resetRoom":{
                                        //  "nodes": [1, 2, 3, 4, 5, 6, 7, 8, 9, 10],
                                        //  "obstaclesToAvoid": [ "A" ]
                                        //}}
                                    },
                                },
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Brinstar Green Main Shaft Complex - Middle Right Red Lock",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenRedDoors"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Brinstar Green Main Shaft Complex - Bottom Right Door",
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
                                Name = "SM - Brinstar Green Main Shaft Complex - Etecoon Exit Grey Lock",
                                Type = LockType.Permanent,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null, /*["never"]*/ },
                                },
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - Brinstar Green Main Shaft Complex - Item",
                        Type = PlacementType.Chozo,
                    },
                    new Junction {
                        Name = "SM - Brinstar Green Main Shaft Complex - Top Junction",
                    },
                    new Junction {
                        Name = "SM - Brinstar Green Main Shaft Complex - Bottom Junction",
                    },
                    new Junction {
                        Name = "SM - Brinstar Green Main Shaft Complex - Etecoon Item Tunnel Junction",
                    },
                    new Junction {
                        Name = "SM - Brinstar Green Main Shaft Complex - Etecoon Escape Tunnel Junction",
                    },
                },
                Obstacles = new[] {
                    new Obstacle {
                        Name = "Power Bomb Blocks",
                        Type = ObstacleType.Inanimate,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Brinstar Green Main Shaft Complex - Elevator",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Green Main Shaft Complex - Top Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Brinstar Green Main Shaft Complex - Top Left Door",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Green Main Shaft Complex - Top Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Brinstar Green Main Shaft Complex - Top Right Door",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Green Main Shaft Complex - Top Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Brinstar Green Main Shaft Complex - Middle Top Left Door",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Green Main Shaft Complex - Top Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Brinstar Green Main Shaft Complex - Middle Bottom Left Door",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Green Main Shaft Complex - Top Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Brinstar Green Main Shaft Complex - Middle Right Door",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Green Main Shaft Complex - Top Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Brinstar Green Main Shaft Complex - Bottom Right Door",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Green Main Shaft Complex - Bottom Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Brinstar Green Main Shaft Complex - Bottom Left Door",
                        To = new[] {
                            // This link is only for the X-Ray climb, which skips the junction altogether.
                            new LinkTarget("SM - Brinstar Green Main Shaft Complex - Top Junction", new[] {
                                new Strat {
                                    Name = "Green Brinstar Main Shaft Left-Side X-Ray Climb",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canRightFacingDoorXRayClimb",
                                    //  { "resetRoom": {
                                    //    "nodes": [8],
                                    //    "mustStayPut": true
                                    //  }}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Brinstar Green Main Shaft Complex - Bottom Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Brinstar Green Main Shaft Complex - Top Left Etecoons Door",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Green Main Shaft Complex - Etecoon Escape Tunnel Junction"),
                            new LinkTarget("SM - Brinstar Green Main Shaft Complex - Etecoon Item Tunnel Junction", new[] {
                                new Strat { Requires = null /*["Morph"]*/ },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Brinstar Green Main Shaft Complex - Bottom Left Etecoons Door",
                        To = new[] {
                            // One-way link for shinespark.
                            new LinkTarget("SM - Brinstar Green Main Shaft Complex - Top Left Etecoons Door", new[] {
                                new Strat {
                                    Name = "Shinespark",
                                    Requires = null,
                                    //{"canComeInCharged": {
                                    //  "fromNode": 10,
                                    //  "framesRemaining": 30,
                                    //  "shinesparkFrames": 75
                                    //}}
                                },
                            }),
                            new LinkTarget("SM - Brinstar Green Main Shaft Complex - Etecoon Escape Tunnel Junction", new[] {
                                new Strat { Requires = null /*["canWalljump"]*/ },
                                new Strat { Requires = null /*["canIBJ"]*/ },
                                new Strat { Requires = null /*["SpaceJump"]*/ },
                                // This is specifically a shinespark that doesn't reach the top.
                                // Needs HJB to bonk at the right place without walljumping.
                                new Strat {
                                    Name = "Shinespark",
                                    Requires = null,
                                    //[ "HiJump",
                                    //  {"canComeInCharged": {
                                    //    "fromNode": 10,
                                    //    "framesRemaining": 60,
                                    //    "shinesparkFrames": 20
                                    //  }}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Brinstar Green Main Shaft Complex - Item",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Green Main Shaft Complex - Etecoon Item Tunnel Junction", new[] {
                                new Strat { Requires = null, /*["Morph"]*/ },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Brinstar Green Main Shaft Complex - Top Junction",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Green Main Shaft Complex - Elevator"),
                            new LinkTarget("SM - Brinstar Green Main Shaft Complex - Top Left Door"),
                            new LinkTarget("SM - Brinstar Green Main Shaft Complex - Top Right Door"),
                            new LinkTarget("SM - Brinstar Green Main Shaft Complex - Middle Top Left Door"),
                            new LinkTarget("SM - Brinstar Green Main Shaft Complex - Middle Bottom Left Door"),
                            new LinkTarget("SM - Brinstar Green Main Shaft Complex - Middle Right Door"),
                            new LinkTarget("SM - Brinstar Green Main Shaft Complex - Bottom Junction", new[] {
                                new Strat {
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Power Bomb Blocks",
                                            Requires = null, // ["h_canUsePowerBombs"]
                                        },
                                    },
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Brinstar Green Main Shaft Complex - Bottom Junction",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Green Main Shaft Complex - Bottom Right Door"),
                            new LinkTarget("SM - Brinstar Green Main Shaft Complex - Bottom Left Door"),
                            new LinkTarget("SM - Brinstar Green Main Shaft Complex - Top Junction", new[] {
                                new Strat {
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Power Bomb Blocks",
                                            Requires = null, // ["h_canUsePowerBombs"]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Green Brinstar Main Shaft Ice Clip",
                                    Notable = true,
                                    Requires = null, // ["canWallCrawlerClip"]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Brinstar Green Main Shaft Complex - Etecoon Escape Tunnel Junction",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Green Main Shaft Complex - Top Left Etecoons Door", new[] {
                                // Not quite the full climb, but close enough.
                                new Strat {
                                    Name = "Full Etecoon Walljump Climb",
                                    Notable = true,
                                    Requires = null, // ["canWalljump"]
                                },
                                // This is the full climb, since you have to drop down to 10 and start there.
                                new Strat {
                                    Name = "Full Etecoon IBJ",
                                    Notable = true,
                                    Requires = null, // ["canIBJ"]
                                },
                                new Strat {
                                    Requires = null, // ["SpaceJump"]
                                },
                            }),
                            new LinkTarget("SM - Brinstar Green Main Shaft Complex - Bottom Left Etecoons Door"),
                            new LinkTarget("SM - Brinstar Green Main Shaft Complex - Bottom Junction", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "Morph",
                                    //  {"or": [
                                    //    "Bombs",
                                    //    {"and": [
                                    //      "PowerBomb",
                                    //      {"ammo": {
                                    //        "type": "PowerBomb",
                                    //        "count": 2
                                    //      }}
                                    //    ]}
                                    //  ]}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Brinstar Green Main Shaft Complex - Etecoon Item Tunnel Junction",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Green Main Shaft Complex - Top Left Etecoons Door", new[] {
                                // The Mockball is setup at 11.
                                new Strat {
                                    Name = "Mockball",
                                    Notable = true,
                                    Requires = null, // ["canMockball"]
                                },
                            }),
                            new LinkTarget("SM - Brinstar Green Main Shaft Complex - Item", new[] {
                                new Strat { Requires = null /*["Morph"]*/ },
                            }),
                            // One-way link, for falling off the tunnel. It doesn't actually fall
                            // all the way to the bottom but this is probably close enough.
                            new LinkTarget("SM - Brinstar Green Main Shaft Complex - Etecoon Escape Tunnel Junction", new[] {
                                new Strat { Requires = null /*["Morph"]*/ },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Brinstar Green Main Shaft Complex - Top Zeelas",
                        EnemyName = "Zeela",
                        Quantity = 4,
                        HomeNodes = new[] { "SM - Brinstar Green Main Shaft Complex - Top Junction" },
                    },
                    new Enemy {
                        GroupName = "SM - Brinstar Green Main Shaft Complex - Ripper 2s",
                        EnemyName = "Ripper 2 (red)",
                        Quantity = 2,
                        HomeNodes = new[] { "SM - Brinstar Green Main Shaft Complex - Top Junction" },
                    },
                    new Enemy {
                        GroupName = "SM - Brinstar Green Main Shaft Complex - Bottom Zeela",
                        EnemyName = "Zeela",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Brinstar Green Main Shaft Complex - Bottom Junction" },
                    },
                },
            },
            #endregion
            // Todo: Acceptable name?
            #region Brinstar Green Speed Gates
            new Room {
                Name = "SM - Brinstar Green Speed Gates",
                Layout = Room.LayoutFrom(@"
                        XXX
                      1→XXX←2"
                    , "SM - Brinstar Green Speed Gates - Left Door"
                    , "SM - Brinstar Green Speed Gates - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Brinstar Green Speed Gates - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 0,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Brinstar Green Speed Gates - Right Door",
                        Type = TransitionType.Red,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 1,
                                OpenEnd = 1,
                                UsableComingIn = false,
                            },
                        },
                        CanLeaveCharged = new[] {
                            new RunwayCharge {
                                Length = 33,
                                OpenEnd = 2,
                                FramesRemaining = 60,
                                InitiateRemotely = new() {
                                    InitiateAt = "SM - Brinstar Green Speed Gates - Left Door",
                                    MustOpenDoorFirst = false,
                                    PathToDoor = new[] {
                                        new PathStep("SM - Brinstar Green Speed Gates - Right Door", new[] { "Speed Through" }),
                                    },
                                },
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //{"resetRoom": {
                                        //  "nodes": [1],
                                        //  "mustStayPut": true
                                        //}}
                                    },
                                },
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Brinstar Green Speed Gates - Red Lock",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenRedDoors"]*/ },
                                },
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - Brinstar Green Speed Gates - Top Item",
                        Type = PlacementType.Visible,
                    },
                    new Placement {
                        Name = "SM - Brinstar Green Speed Gates - Bottom Item",
                        Type = PlacementType.Visible,
                    },
                    new Junction {
                        Name = "SM - Brinstar Green Speed Gates - Sidehopper Pit Junction",
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Brinstar Green Speed Gates - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Green Speed Gates - Right Door", new[] {
                                new Strat {
                                    Name = "Speed Through",
                                    Requires = null,
                                    //[ {"resetRoom":{
                                    //    "nodes": [1],
                                    //    "mustStayPut": true
                                    //  }},
                                    //  "SpeedBooster"
                                    //]
                                },
                                new Strat {
                                    Name = "Speed Gates Mockball",
                                    Notable = true,
                                    Requires = null,
                                    //[ {"resetRoom":{
                                    //    "nodes": [1],
                                    //    "mustStayPut": true
                                    //  }},
                                    //  "canMockball"
                                    //]
                                    Failures = new[] {
                                        // Falls down into node 3 with no possiblity of quick crumble escape.
                                        new Strat.Failure {
                                            Name = "Crumble Fall",
                                            LeadsToNode = "SM - Brinstar Green Speed Gates - Bottom Item",
                                            ClearsPreviousNode = true,
                                        },
                                    },
                                },
                            }),
                            // This has no requirements, but getting back out does!
                            new LinkTarget("SM - Brinstar Green Speed Gates - Bottom Item"),
                            new LinkTarget("SM - Brinstar Green Speed Gates - Sidehopper Pit Junction", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ {"resetRoom":{
                                    //    "nodes": [1],
                                    //    "mustStayPut": true
                                    //  }},
                                    //  "SpeedBooster"
                                    //]
                                },
                                // Not considered a notable strat because executing this has no real value.
                                new Strat {
                                    Name = "Mockball",
                                    Requires = null,
                                    //[ {"resetRoom":{
                                    //    "nodes": [1],
                                    //    "mustStayPut": true
                                    //  }},
                                    //  "canMockball"
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Brinstar Green Speed Gates - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Green Speed Gates - Top Item"),
                        },
                    },
                    new Link {
                        From = "SM - Brinstar Green Speed Gates - Bottom Item",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Green Speed Gates - Left Door", new[] {
                                new Strat { Requires = null /*["h_canPassBombPassages"]*/ },
                                // This one involves doing a second quick crumble escape on the way
                                // out as a means to avoid doing a crumble jump.
                                new Strat {
                                    Name = "Early Supers Quick Crumble Escape (Dual Quick Crumble)",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canQuickCrumbleEscape",
                                    //  {"previousNode": 1}
                                    //]
                                    Failures = new[] {
                                        // Failure leaves you at Bottom Item with solid crumble blocks above your head.
                                        new Strat.Failure {
                                            Name = "Crumble Failure",
                                            ClearsPreviousNode = true,
                                        },
                                    },
                                },
                                // Space Jump is here as an alternative to performing a crumble jump on the way out.
                                new Strat {
                                    Name = "Early Supers Quick Crumble Escape (Space)",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canQuickCrumbleEscape",
                                    //  "SpaceJump",
                                    //  {"previousNode": 1}
                                    //]
                                    Failures = new[] {
                                        // Failure leaves you at Bottom Item with solid crumble blocks above your head.
                                        new Strat.Failure {
                                            Name = "Crumble Failure",
                                            ClearsPreviousNode = true,
                                        },
                                    },
                                },
                                // Spring Ball is here as an alternative to performing a crumble jump on the way out.
                                new Strat {
                                    Name = "Early Supers Quick Crumble Escape (SpringBall)",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canQuickCrumbleEscape",
                                    //  "h_canUseSpringBall",
                                    //  {"previousNode": 1}
                                    //]
                                    Failures = new[] {
                                        // Failure leaves you at Bottom Item with solid crumble blocks above your head.
                                        new Strat.Failure {
                                            Name = "Crumble Failure",
                                            ClearsPreviousNode = true,
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Early Supers Quick Crumble Escape (Crumble Jump)",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canQuickCrumbleEscape",
                                    //  "canCrumbleJump",
                                    //  {"previousNode": 1}
                                    //]
                                    Failures = new[] {
                                        // Failure leaves you at Bottom Item with solid crumble blocks above your head.
                                        new Strat.Failure {
                                            Name = "Crumble Failure",
                                            ClearsPreviousNode = true,
                                        },
                                    },
                                },
                            }),
                            new LinkTarget("SM - Brinstar Green Speed Gates - Sidehopper Pit Junction", new[] {
                                new Strat { Requires = null /*["h_canPassBombPassages"]*/ },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Brinstar Green Speed Gates - Top Item",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Green Speed Gates - Left Door"),
                            new LinkTarget("SM - Brinstar Green Speed Gates - Right Door"),
                        },
                    },
                    new Link {
                        From = "SM - Brinstar Green Speed Gates - Sidehopper Pit Junction",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Green Speed Gates - Bottom Item", new[] {
                                new Strat { Requires = null /*["h_canPassBombPassages"]*/ },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Brinstar Green Speed Gates - Zeb",
                        EnemyName = "Zeb",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Brinstar Green Speed Gates - Left Door" },
                        FarmCycles = new[] {
                            new FarmCycle {
                                Name = "Crouch over spawn point",
                                CycleFrames = 120,
                            },
                        },
                    },
                    new Enemy {
                        GroupName = "SM - Brinstar Green Speed Gates - Wavers",
                        EnemyName = "Waver",
                        Quantity = 4,
                        HomeNodes = new[] { "SM - Brinstar Green Speed Gates - Top Item" },
                    },
                    new Enemy {
                        GroupName = "SM - Brinstar Green Speed Gates - Top Small sidehoppers",
                        EnemyName = "Sm. Sidehopper",
                        Quantity = 3,
                        HomeNodes = new[] { "SM - Brinstar Green Speed Gates - Top Item" },
                    },
                    new Enemy {
                        GroupName = "SM - Brinstar Green Speed Gates - Bottom Small sidehoppers",
                        EnemyName = "Sm. Sidehopper",
                        Quantity = 2,
                        HomeNodes = new[] { "SM - Brinstar Green Speed Gates - Sidehopper Pit Junction" },
                    },
                },
            },
            #endregion
            // Todo: Acceptable name?
            #region Brinstar Green Chozo Room
            new Room {
                Name = "SM - Brinstar Green Chozo Room",
                Layout = Room.LayoutFrom(@"
                      1→XX"
                    , "SM - Brinstar Green Chozo Room - Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Brinstar Green Chozo Room - Door",
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
                        Name = "SM - Brinstar Green Chozo Room - Chozo Item",
                        Type = PlacementType.Chozo,
                    },
                    new Placement {
                        Name = "SM - Brinstar Green Chozo Room - Behind Wall Item",
                        Type = PlacementType.Visible,
                    },
                    new Placement {
                        Name = "SM - Brinstar Green Chozo Room - Inside Wall Item",
                        Type = PlacementType.Hidden,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Brinstar Green Chozo Room - Door",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Green Chozo Room - Chozo Item"),
                        },
                    },
                    new Link {
                        From = "SM - Brinstar Green Chozo Room - Chozo Item",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Green Chozo Room - Door"),
                            new LinkTarget("SM - Brinstar Green Chozo Room - Behind Wall Item", new[] {
                                new Strat { Requires = null /*["Morph"]*/ },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Brinstar Green Chozo Room - Behind Wall Item",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Green Chozo Room - Chozo Item", new[] {
                                new Strat { Requires = null /*["Morph"]*/ },
                            }),
                            new LinkTarget("SM - Brinstar Green Chozo Room - Inside Wall Item", new[] {
                                new Strat { Requires = null /*["h_canPassBombPassages"]*/ },
                                new Strat {
                                    Name = "Brinstar Reserve Hole-in-One",
                                    Notable = true,
                                    Requires = null,
                                    //[ "Morph",
                                    //  "canTunnelCrawl",
                                    //  "ScrewAttack"
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Brinstar Green Chozo Room - Inside Wall Item",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Green Chozo Room - Behind Wall Item", new[] {
                                new Strat { Requires = null /*["Morph"]*/ },
                            }),
                        },
                    },
                },
            },
            #endregion
            // Todo: What the bleep do we call this one?
            #region Brinstar Pre-Map Room
            new Room {
                Name = "SM - Brinstar Pre-Map Room",
                Layout = Room.LayoutFrom(@"
                      1→XXX←2"
                    , "SM - Brinstar Pre-Map - Left Door"
                    , "SM - Brinstar Pre-Map - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Brinstar Pre-Map - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 2,
                                OpenEnd = 0,
                                UsableComingIn = false,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Brinstar Pre-Map - Right Door",
                        Type = TransitionType.Gray,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 14,
                                OpenEnd = 0,
                            },
                        },
                        CanLeaveCharged = new[] {
                            new RunwayCharge {
                                Length = 17,
                                OpenEnd = 1,
                                FramesRemaining = 80,
                            },
                        },
                        Locks = new[] {
                            // Both sides of the room must be accessed to reach all enemies and
                            // unlock the door. Beyond that, the enemies can be killed with Power
                            // Beam.
                            new Lock {
                                Name = "SM - Brinstar Pre-Map - Grey Lock",
                                Type = LockType.KillEnemies,
                                UnlockStrats = new[] {
                                    new Strat {
                                        Requires = null, // ["Morph"]
                                        Obstacles = new[] {
                                            new Strat.Obstacle {
                                                Name = "Bomb Blocks",
                                                Requires = null, // ["h_canPassBombPassages"]
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
                        Name = "Bomb Blocks",
                        Type = ObstacleType.Inanimate,
                    }
                },
                Links = new[] {
                    new Link {
                        From = "SM - Brinstar Pre-Map - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Pre-Map - Right Door", new[] {
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
                        From = "SM - Brinstar Pre-Map - Right Door",
                        To = new[] {
                            // A speedball strat can be doable here, depending on adjacent runway,
                            // but between the grey door and the number of runway tiles in this
                            // room that can't be used for that, it might be better to omit it.
                            new LinkTarget("SM - Brinstar Pre-Map - Left Door", new[] {
                                new Strat {
                                    Requires = null, //["Morph"]
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
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Brinstar Pre-Map - Left Zeela",
                        EnemyName = "Zeela",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Brinstar Pre-Map - Left Door" },
                    },
                    new Enemy {
                        GroupName = "SM - Brinstar Pre-Map - Right Zeelas",
                        EnemyName = "Zeela",
                        Quantity = 2,
                        HomeNodes = new[] { "SM - Brinstar Pre-Map - Right Door" },
                    },
                    new Enemy {
                        GroupName = "SM - Brinstar Pre-Map - Small Sidehopper",
                        EnemyName = "Sm. Sidehopper",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Brinstar Pre-Map - Right Door" },
                    },
                },
            },
            #endregion
            #region Brinstar Map Room
            new Room {
                Name = "SM - Brinstar Map Room",
                Layout = Room.LayoutFrom(@"
                      X←1"
                    , "SM - Brinstar Map Room - Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Brinstar Map Room - Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Utility {
                        Name = "SM - Brinstar Map Room - Map Station",
                        Type = UtilityType.Map,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Brinstar Map Room - Door",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Map Room - Map Station"),
                        },
                    },
                    new Link {
                        From = "SM - Brinstar Map Room - Map Station",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Map Room - Door"),
                        },
                    },
                },
            },
            #endregion
            #region Brinstar Green Fireflea Room
            new Room {
                Name = "SM - Brinstar Green Fireflea Room",
                Layout = Room.LayoutFrom(@"
                        XXX←2
                      1→XX"
                    , "SM - Brinstar Green Firefleas Room - Left Door"
                    , "SM - Brinstar Green Firefleas Room - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Brinstar Green Firefleas Room - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 6,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Brinstar Green Firefleas Room - Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 16,
                                OpenEnd = 1,
                            },
                        },
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Brinstar Green Firefleas Room - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Green Firefleas Room - Right Door"),
                        },
                    },
                    new Link {
                        From = "SM - Brinstar Green Firefleas Room - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Green Firefleas Room - Left Door"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Brinstar Green Firefleas Room - Firefleas",
                        EnemyName = "Fireflea",
                        Quantity = 5,
                        HomeNodes = new[] { "SM - Brinstar Green Firefleas Room - Left Door" },
                    },
                },
            },
            #endregion
            #region Beetom Room
            new Room {
                Name = "SM - Beetom Room",
                Layout = Room.LayoutFrom(@"
                      1→X←2"
                    , "SM - Beetoms - Left Door"
                    , "SM - Beetoms - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Beetoms - Left Door",
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
                        Name = "SM - Beetoms - Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 2,
                                OpenEnd = 1,
                                UsableComingIn = false,
                            },
                        },
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Beetoms - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Beetoms - Right Door"),
                        },
                    },
                    new Link {
                        From = "SM - Beetoms - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Beetoms - Left Door"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Beetom Room - Beetoms",
                        EnemyName = "Beetom",
                        Quantity = 4,
                        HomeNodes = new[] {
                            "SM - Beetoms - Left Door",
                            "SM - Beetoms - Right Door",
                        },
                    },
                },
            },
            #endregion
            // Todo: Acceptable name?
            #region Floor Trap Room
            new Room {
                Name = "SM - Floor Trap Room",
                Layout = Room.LayoutFrom(@"
                      2→XX←3
                      1→XXXXX←4"
                    , "SM - Floor Trap Room - Bottom Left Door"
                    , "SM - Floor Trap Room - Top Left Door"
                    , "SM - Floor Trap Room - Top Right Door"
                    , "SM - Floor Trap Room - Bottom Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Floor Trap Room - Bottom Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 5,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Floor Trap Room - Top Left Door",
                        Type = TransitionType.Green,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 5,
                                OpenEnd = 1,
                            },
                        },
                        CanLeaveCharged = new[] {
                            new RunwayCharge {
                                Length = 20,
                                OpenEnd = 2,
                                FramesRemaining = 60,
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Floor Trap Room - Green Lock",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenGreenDoors"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Floor Trap Room - Top Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 20,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Floor Trap Room - Bottom Right Door",
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
                        Name = "SM - Floor Trap Room - Item",
                        Type = PlacementType.Visible,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Floor Trap Room - Top Left Door",
                        To = new[] {
                            new LinkTarget("SM - Floor Trap Room - Item"),
                        },
                    },
                    new Link {
                        From = "SM - Floor Trap Room - Top Right Door",
                        To = new[] {
                            new LinkTarget("SM - Floor Trap Room - Bottom Left Door"),
                            new LinkTarget("SM - Floor Trap Room - Item"),
                        },
                    },
                    new Link {
                        From = "SM - Floor Trap Room - Bottom Left Door",
                        To = new[] {
                            new LinkTarget("SM - Floor Trap Room - Top Right Door", new[] {
                                new Strat {
                                    Name = "Etecoon E-Tank Beetom Clip",
                                    Notable = true,
                                    Requires = null, // ["canBeetomClip"]
                                },
                                // In truth this goes to Top Left Door, but there's no need to make
                                // a link for this since movement between Top Left Door and
                                // Top Right Door is free (via Item).
                                new Strat {
                                    Name = "Etecoon E-Tank X-Ray Climb",
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
                            new LinkTarget("SM - Floor Trap Room - Bottom Right Door", new[] {
                                new Strat { Requires = null, /*["Morph"]*/ },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Floor Trap Room - Bottom Right Door",
                        To = new[] {
                            new LinkTarget("SM - Floor Trap Room - Bottom Left Door", new[] {
                                new Strat { Requires = null /*["Morph"]*/ },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Floor Trap Room - Item",
                        To = new[] {
                            new LinkTarget("SM - Floor Trap Room - Top Left Door"),
                            new LinkTarget("SM - Floor Trap Room - Top Right Door"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Floor Trap Room - Beetoms",
                        EnemyName = "Beetom",
                        Quantity = 5,
                        HomeNodes = new[] { "SM - Floor Trap Room - Bottom Right Door" },
                        FarmCycles = new[] {
                            new FarmCycle {
                                Name = "Crouch two tiles above spawn point",
                                CycleFrames = 130,
                            },
                        },
                    },
                    new Enemy {
                        GroupName = "SM - Floor Trap Room - Left Zebbo",
                        EnemyName = "Zebbo",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Floor Trap Room - Bottom Right Door" },
                        FarmCycles = new[] {
                            new FarmCycle {
                                Name = "Crouch two tiles above spawn point",
                                CycleFrames = 130,
                            },
                        },
                    },
                    new Enemy {
                        GroupName = "SM - Floor Trap Room - Middle Zebbo",
                        EnemyName = "Zebbo",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Floor Trap Room - Bottom Right Door" },
                        FarmCycles = new[] {
                            new FarmCycle {
                                Name = "Crouch over spawn point",
                                CycleFrames = 120,
                            },
                        },
                    },
                    new Enemy {
                        GroupName = "SM - Floor Trap Room - Right Zebbo",
                        EnemyName = "Zebbo",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Floor Trap Room - Bottom Right Door" },
                        FarmCycles = new[] {
                            new FarmCycle {
                                Name = "Crouch two tiles above spawn point",
                                CycleFrames = 130,
                            },
                        },
                    },
                },
            },
            #endregion
            // Todo: Acceptable name?
            #region Brinstar Green Prize Room
            new Room {
                Name = "SM - Brinstar Green Prize Room",
                Layout = Room.LayoutFrom(@"
                      X←1"
                    , "SM - Brinstar Green Prize Room - Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Brinstar Green Prize Room - Door",
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
                        Name = "SM - Brinstar Green Prize Room - Item",
                        Type = PlacementType.Visible,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Brinstar Green Prize Room - Door",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Green Prize Room - Item"),
                        },
                    },
                    new Link {
                        From = "SM - Brinstar Green Prize Room - Item",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Green Prize Room - Door"),
                        },
                    },
                },
            },
            #endregion
            #region Green Hill Zone
            new Room {
                Name = "SM - Green Hill Zone",
                Layout = Room.LayoutFrom(@"
                      1→XX←2
                        XXXX
                          XXXX
                            XXX←3"
                    , "SM - Green Hill Zone - Left Door"
                    , "SM - Green Hill Zone - Top Right Door"
                    , "SM - Green Hill Zone - Bottom Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Green Hill Zone - Left Door",
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
                        Name = "SM - Green Hill Zone - Top Right Door",
                        Type = TransitionType.Yellow,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 10,
                                OpenEnd = 1,
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Green Hill - Yellow Lock",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenYellowDoors"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Green Hill Zone - Bottom Right Door",
                        Type = TransitionType.Blue,
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
                                FramesRemaining = 120,
                            },
                            new RunwayCharge{
                                Length = 30,
                                OpenEnd = 0,
                                FramesRemaining = 120,
                                Strats = new[] {
                                    new Strat {
                                        Name = "Open Blue Gate",
                                        Requires = null, // ["h_canOpenWrongFacingBlueGateFromRight"]
                                    },
                                    new Strat {
                                        Name = "Arrive From Left",
                                        Requires = null,
                                        //{"resetRoom": {
                                        //  "nodes": [1, 2],
                                        //  "mustStayPut": false
                                        //}}
                                    },
                                },
                            },
                        },
                    },
                    // Associated with Brinstar Pink in SMZ3.
                    new Placement {
                        Name = "SM - Green Hill Zone - Item",
                        Type = PlacementType.Visible,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Green Hill Zone - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Green Hill Zone - Top Right Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //{"or":[
                                    //  "h_canFly",
                                    //  "SpeedBooster",
                                    //  "HiJump",
                                    //  "canSpringBallJumpMidAir"
                                    //]}
                                },
                                new Strat {
                                    Name = "Green Hill Zone Walljump",
                                    Notable = true,
                                    Requires = null, // ["canWalljump"]
                                },
                                new Strat {
                                    Name = "Use Frozen Enemy",
                                    Requires = null, // ["canUseFrozenEnemies"]
                                },
                            }),
                            new LinkTarget("SM - Green Hill Zone - Bottom Right Door"),
                            new LinkTarget("SM - Green Hill Zone - Item", new[] {
                                new Strat { Requires = null /*["Morph"]*/ },
                                // Not notable because it's a one-way strat. It takes Morph or a
                                // Morphless Tunnel Crawl to get back out.
                                new Strat {
                                    Name = "Turnaround Aim Cancel",
                                    Requires = null, // ["canTurnaroundAimCancel"]
                                },
                                // It's a long Tunnel Crawl, so there's a heavy softlock risk.
                                new Strat {
                                    Name = "Green Hill Zone Tunnel Crawl (In)",
                                    Notable = true,
                                    Requires = null, // ["canMorphlessTunnelCrawl"]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Green Hill Zone - Top Right Door",
                        To = new[] {
                            new LinkTarget("SM - Green Hill Zone - Left Door"),
                        },
                    },
                    new Link {
                        From = "SM - Green Hill Zone - Bottom Right Door",
                        To = new[] {
                            new LinkTarget("SM - Green Hill Zone - Left Door", new[] {
                                new Strat { Requires = null /*["h_canOpenWrongFacingBlueGateFromRight"]*/ },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Green Hill Zone - Item",
                        To = new[] {
                            new LinkTarget("SM - Green Hill Zone - Left Door", new[] {
                                new Strat { Requires = null /*["Morph"]*/ },
                                // It's a long Tunnel Crawl, so there's a heavy softlock risk.
                                new Strat {
                                    Name = "Green Hill Zone Tunnel Crawl (In)",
                                    Notable = true,
                                    Requires = null, // ["canMorphlessTunnelCrawl"]
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Green Hill Zone - Top Geega",
                        EnemyName = "Geega",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Green Hill Zone - Left Door" },
                        FarmCycles = new[] {
                            new FarmCycle {
                                Name = "Single Geega Farm",
                                CycleFrames = 160,
                            },
                        },
                    },
                    new Enemy {
                        GroupName = "SM - Green Hill Zone - Middle Top Geega",
                        EnemyName = "Geega",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Green Hill Zone - Left Door" },
                        FarmCycles = new[] {
                            new FarmCycle {
                                Name = "Single Geega Farm",
                                CycleFrames = 160,
                            },
                        },
                    },
                    new Enemy {
                        GroupName = "SM - Green Hill Zone - Middle Geega",
                        EnemyName = "Geega",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Green Hill Zone - Left Door" },
                        FarmCycles = new[] {
                            new FarmCycle {
                                Name = "Single Geega Farm",
                                CycleFrames = 160,
                            },
                        },
                    },
                    new Enemy {
                        GroupName = "SM - Green Hill Zone - Middle Bottom Geega",
                        EnemyName = "Geega",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Green Hill Zone - Left Door" },
                        FarmCycles = new[] {
                            new FarmCycle {
                                Name = "Single Geega Farm",
                                CycleFrames = 160,
                            },
                        },
                    },
                    new Enemy {
                        GroupName = "SM - Green Hill Zone - Bottom Geega",
                        EnemyName = "Geega",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Green Hill Zone - Left Door" },
                        FarmCycles = new[] {
                            new FarmCycle {
                                Name = "Single Geega Farm",
                                CycleFrames = 160,
                            },
                        },
                    },
                    new Enemy {
                        GroupName = "SM - Green Hill Zone - Left Small Sidehoppers",
                        EnemyName = "Sm. Sidehopper",
                        Quantity = 2,
                        HomeNodes = new[] { "SM - Green Hill Zone - Left Door" },
                    },
                    new Enemy {
                        GroupName = "SM - Green Hill Zone - Right Small Sidehoppers",
                        EnemyName = "Sm. Sidehopper",
                        Quantity = 3,
                        HomeNodes = new[] { "SM - Green Hill Zone - Bottom Right Door" },
                    }
                },
            },
            #endregion
            // Todo: Which of these names?
            #region Noob Bridge / A Bridge Too Far
            new Room {
                Name = "SM - Noob Bridge",
                Layout = Room.LayoutFrom(@"
                      1→XXXXXX←2"
                    , "SM - Noob Bridge - Left Door"
                    , "SM - Noob Bridge - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Noob Bridge - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 0,
                                OpenEnd = 1,
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
                        Name = "SM - Noob Bridge - Right Door",
                        Type = TransitionType.Green,
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
                            new RunwayCharge{
                                Length = 20,
                                OpenEnd = 0,
                                FramesRemaining = 100,
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Noob Bridge - Green Lock",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenGreenDoors"]*/ },
                                },
                            },
                        },
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Noob Bridge - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Noob Bridge - Right Door"),
                        },
                    },
                    new Link {
                        From = "SM - Noob Bridge - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Noob Bridge - Left Door"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Noob Bridge - Left Cacatacs",
                        EnemyName = "Cacatac",
                        Quantity = 3,
                        HomeNodes = new[] { "SM - Noob Bridge - Left Door" },
                    },
                    new Enemy {
                        GroupName = "SM - Noob Bridge - Right Cacatac",
                        EnemyName = "Cacatac",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Noob Bridge - Right Door" },
                    },
                    new Enemy {
                        GroupName = "SM - Noob Bridge - Zeelas",
                        EnemyName = "Zeela",
                        Quantity = 4,
                        HomeNodes = new[] {
                            "SM - Noob Bridge - Left Door",
                            "SM - Noob Bridge - Right Door",
                        },
                    },
                },
            },
            #endregion
            #region Spore Spawn Kihunter Room
            new Room {
                Name = "SM - Spore Spawn Kihunter Room",
                Layout = Room.LayoutFrom(@"
                           2
                           ↓
                      1→XXXX"
                    , "SM - Spore Spawn Kihunters Room - Left Door"
                    , "SM - Spore Spawn Kihunters Room - Top Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Spore Spawn Kihunters Room - Left Door",
                        Type = TransitionType.Gray,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 1,
                            },
                        },
                        CanLeaveCharged = new[] {
                            new RunwayCharge {
                                Length = 32,
                                OpenEnd = 0,
                                FramesRemaining = 30,
                            },
                        },
                        Locks = new[] {
                            // The enemies can be killed with Power Beam.
                            new Lock {
                                Name = "SM - Spore Spawn Kihunters Room - Left Grey Lock",
                                Type = LockType.KillEnemies,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Spore Spawn Kihunters Room - Top Right Door",
                        Type = TransitionType.Gray,
                        CanLeaveCharged = new[] {
                            new RunwayCharge {
                                Length = 32,
                                OpenEnd = 0,
                                FramesRemaining = 40,
                            },
                        },
                        Locks = new[] {
                            // The enemies can be killed with Power Beam.
                            new Lock {
                                Name = "SM - Spore Spawn Kihunters Room - Right Grey Lock",
                                Type = LockType.KillEnemies,
                            },
                        },
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Spore Spawn Kihunters Room - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Spore Spawn Kihunters Room - Top Right Door"),
                        },
                    },
                    new Link {
                        From = "SM - Spore Spawn Kihunters Room - Top Right Door",
                        To = new[] {
                            new LinkTarget("SM - Spore Spawn Kihunters Room - Left Door"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Spore Spawn Kihunters Room - Kihunters",
                        EnemyName = "Kihunter (green)",
                        Quantity = 3,
                        HomeNodes = new[] {
                            "SM - Spore Spawn Kihunters Room - Left Door",
                            "SM - Spore Spawn Kihunters Room - Top Right Door",
                        },
                    }
                },
            },
            #endregion
            #region Spore Spawn Room
            new Room {
                Name = "SM - Spore Spawn Room",
                Layout = Room.LayoutFrom(@"
                      X←1
                      X
                      X
                      ↑
                      2"
                    , "SM - Spore Spawn Room - Top Right Door"
                    , "SM - Spore Spawn Room - Bottom Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Spore Spawn Room - Top Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 7,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Spore Spawn Room - Bottom Door",
                        Type = TransitionType.Green,
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Spore Spawn Room - Green Lock",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenGreenDoors"]*/ },
                                },
                            },
                        },
                    },
                    new Event {
                        Name = "SM - Spore Spawn Room - Spore Spawn",
                        Type = EventType.Boss,
                        Locks = new[] {
                            new Lock {
                                Name = "Spore Spawn Fight",
                                Type = LockType.BossFight,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["Charge"]*/ },
                                    // No ammo count because Missiles are farmable here.
                                    new Strat { Requires = null /*["Missile"]*/ },
                                    // Spore Spawn's pollen does not drop supers, which is why we
                                    // have ammo requirements. Too many misses could lead to a
                                    // softlock.
                                    new Strat {
                                        Name = "Supers",
                                        Requires = null,
                                        //{"enemyKill":{
                                        //  "enemies": [
                                        //    [ "Spore Spawn" ]
                                        //  ],
                                        //  "explicitWeapons": [ "Super" ]
                                        //}}
                                    },
                                },
                            },
                        },
                        Yields = new[] { "f_DefeatedSporeSpawn" },
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Spore Spawn Room - Top Right Door",
                        To = new[] {
                            new LinkTarget("SM - Spore Spawn Room - Spore Spawn", new[] {
                                new Strat { Requires = null /*["f_DefeatedSporeSpawn"]*/ },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Spore Spawn Room - Bottom Door",
                        To = new[] {
                            new LinkTarget("SM - Spore Spawn Room - Spore Spawn"),
                        },
                    },
                    new Link {
                        From = "SM - Spore Spawn Room - Spore Spawn",
                        To = new[] {
                            new LinkTarget("SM - Spore Spawn Room - Top Right Door", new[] {
                                new Strat { Requires = null /*["f_DefeatedSporeSpawn"]*/ },
                            }),
                            new LinkTarget("SM - Spore Spawn Room - Bottom Door"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Spore Spawn Room - Spore Spawn",
                        EnemyName = "Spore Spawn",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Spore Spawn Room - Spore Spawn" },
                        StopSpawn = null, // ["f_DefeatedSporeSpawn"]
                    },
                },
            },
            #endregion
            #region Brinstar Green Top Save Room
            new Room {
                Name = "SM - Brinstar Green Top Save Room",
                Layout = Room.LayoutFrom(@"
                      X←1"
                    , "SM - Brinstar Green Top Save Room - Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Brinstar Green Top Save Room - Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Utility {
                        Name = "SM - Brinstar Green Top Save Room - Save Station",
                        Type = UtilityType.Save,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Brinstar Green Top Save Room - Door",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Green Top Save Room - Save Station"),
                        },
                    },
                    new Link {
                        From = "SM - Brinstar Green Top Save Room - Save Station",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Green Top Save Room - Door"),
                        },
                    },
                },
            },
            #endregion
            #region Brinstar Green Bottom Save Room
            new Room {
                Name = "SM - Brinstar Green Bottom Save Room",
                Layout = Room.LayoutFrom(@"
                      X←1"
                    , "SM - Brinstar Green Bottom Save Room - Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Brinstar Green Bottom Save Room - Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Utility {
                        Name = "SM - Brinstar Green Bottom Save Room - Save Station",
                        Type = UtilityType.Save,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Brinstar Green Bottom Save Room - Door",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Green Bottom Save Room - Save Station"),
                        },
                    },
                    new Link {
                        From = "SM - Brinstar Green Bottom Save Room - Save Station",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Green Bottom Save Room - Door"),
                        },
                    },
                },
            },
            #endregion
            #region Brinstar Green Missile Refill
            new Room {
                Name = "SM - Brinstar Green Missile Refill",
                Layout = Room.LayoutFrom(@"
                      X←1"
                    , "SM - Brinstar Green Missile Refill - Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Brinstar Green Missile Refill - Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Utility {
                        Name = "SM - Brinstar Green Missile Refill - Missile Refill",
                        Type = UtilityType.Missile,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Brinstar Green Missile Refill - Door",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Green Missile Refill - Missile Refill"),
                        },
                    },
                    new Link {
                        From = "SM - Brinstar Green Missile Refill - Missile Refill",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Green Missile Refill - Door"),
                        },
                    },
                },
            },
            #endregion
        };

    }

}
