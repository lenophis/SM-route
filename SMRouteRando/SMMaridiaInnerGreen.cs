using System.Collections.Generic;
using SMRouteRando.Util;

namespace SMRouteRando {

    public class SMMaridiaInnerGreen {

        public static IList<Room> Rooms { get; } = new[] {
            #region Oasis
            new Room {
                Name = "SM - Oasis",
                Layout = Room.LayoutFrom(@"
                        2
                        ↓
                        X
                      1→X←3"
                    , "SM - Oasis - Left Door"
                    , "SM - Oasis - Top Door"
                    , "SM - Oasis - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Oasis - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 12,
                                OpenEnd = 0,
                                Strats = new[] {
                                    new Strat { Requires = null /*["Gravity"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Oasis - Top Door",
                        Type = TransitionType.Green,
                        SpawnAt = "SM - Oasis - Top Door Junction",
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Oasis - Green Lock",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenGreenDoors"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Oasis - Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 12,
                                OpenEnd = 0,
                                Strats = new[] {
                                    new Strat { Requires = null /*["Gravity"]*/ },
                                },
                            },
                        },
                    },
                    new Junction {
                        Name = "SM - Oasis - Top Door Junction",
                    },
                    new Junction {
                        Name = "SM - Oasis - Above Bomb Blocks Junction",
                    },
                    new Junction {
                        Name = "SM - Oasis - Bottom Junction",
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Oasis - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Oasis - Bottom Junction"),
                            // This link is only for the X-Ray climb, which skips the junction altogether.
                            new LinkTarget("SM - Oasis - Above Bomb Blocks Junction", new[] {
                                new Strat {
                                    Name = "Oasis Left-Side X-Ray Climb",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateUnderwater",
                                    //  "canRightFacingDoorXRayClimb",
                                    //  {"resetRoom":{
                                    //    "nodes": [1],
                                    //    "mustStayPut": true
                                    //  }}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Oasis - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Oasis - Bottom Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Oasis - Top Door",
                        To = new[] {
                            new LinkTarget("SM - Oasis - Top Door Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Oasis - Top Door Junction",
                        To = new[] {
                            new LinkTarget("SM - Oasis - Top Door", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                // This isn't requiring canSuitlessMaridia because it reduces the
                                // likelihood of entering from the top being a logical softlock.
                                new Strat {
                                    Name = "Suitless",
                                    Requires = null,
                                    //{"or": [
                                    //  "HiJump",
                                    //  "canSpringBallJumpMidAir"
                                    //]}
                                },
                            }),
                            new LinkTarget("SM - Oasis - Above Bomb Blocks Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Oasis - Bottom Junction",
                        To = new[] {
                            new LinkTarget("SM - Oasis - Left Door"),
                            new LinkTarget("SM - Oasis - Right Door"),
                            // One-way link for shinesparks. Other strats should go
                            // Bottom Junction -> Above Bomb Blocks Junction ->
                            // Top Door Junction.
                            new LinkTarget("SM - Oasis - Top Door Junction", new[] {
                                // The spark takes Samus directly to the top platform.
                                new Strat {
                                    Name = "Come in Charged",
                                    Requires = null,
                                    //[ "h_canNavigateUnderwater",
                                    //  {"or": [
                                    //    {"canComeInCharged": {
                                    //      "fromNode": 1,
                                    //      "inRoomPath": [1, 5],
                                    //      "framesRemaining": 30,
                                    //      "shinesparkFrames": 23
                                    //    }},
                                    //    {"canComeInCharged": {
                                    //      "fromNode": 2,
                                    //      "inRoomPath": [2, 5],
                                    //      "framesRemaining": 30,
                                    //      "shinesparkFrames": 23
                                    //    }}
                                    //  ]}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Oasis - Above Bomb Blocks Junction", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "Gravity",
                                    //  "h_canDestroyBombWalls"
                                    //]
                                },
                                new Strat {
                                    Name = "Suitless",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "h_canPassBombPassages"
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Oasis - Above Bomb Blocks Junction",
                        To = new[] {
                            new LinkTarget("SM - Oasis - Top Door Junction", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                new Strat {
                                    Name = "Suitless",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  {"or": [
                                    //    "HiJump",
                                    //    "canSpringBallJumpMidAir"
                                    //  ]}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Oasis - Bottom Junction", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "Gravity",
                                    //  "h_canDestroyBombWalls"
                                    //]
                                },
                                // Doesn't require canSuitlessMaridia because it's so straightforward.
                                // It's only a separate thing because of how Screw Attack doesn't work.
                                new Strat {
                                    Name = "Suitless",
                                    Requires = null, // ["h_canPassBombPassages"],
                                },
                            }),
                        },
                    },
                },
            },
            #endregion
            #region Sand Hall A
            new Room {
                Name = "SM - Sand Hall A",
                Layout = Room.LayoutFrom(@"
                          2
                          ↓
                      1→XXXX←3"
                    , "SM - Sand Hall A - Left Door"
                    , "SM - Sand Hall A - Sand Entrance"
                    , "SM - Sand Hall A - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Sand Hall A - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 1,
                                Strats = new[] {
                                    new Strat { Requires = null /*["Gravity"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Sand Hall A - Sand Entrance",
                        Type = TransitionType.Sandpit,
                    },
                    new Transition {
                        Name = "SM - Sand Hall A - Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
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
                        From = "SM - Sand Hall A - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Sand Hall A - Sand Entrance", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
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
                        From = "SM - Sand Hall A - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Sand Hall A - Sand Entrance", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
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
                        From = "SM - Sand Hall A - Sand Entrance",
                        To = new[] {
                            new LinkTarget("SM - Sand Hall A - Left Door", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                new Strat {
                                    Name = "Suitless",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "HiJump"
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Sand Hall A - Right Door", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
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
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Sand Hall A - Right Evirs",
                        EnemyName = "Evir",
                        Quantity = 2,
                        BetweenNodes = new[] {
                            "SM - Sand Hall A - Right Door",
                            "SM - Sand Hall A - Sand Entrance",
                        },
                    },
                    new Enemy {
                        GroupName = "SM - Sand Hall A - Left Evir",
                        EnemyName = "Evir",
                        Quantity = 1,
                        BetweenNodes = new[] {
                            "SM - Sand Hall A - Left Door",
                            "SM - Sand Hall A - Sand Entrance",
                        },
                    },
                },
            },
            #endregion
            // Todo: Acceptable Name?
            #region Maridia Tunnel B
            new Room {
                Name = "SM - Maridia Tunnel B",
                Layout = Room.LayoutFrom(@"
                      1→X←2"
                    , "SM - Maridia Tunnel B - Left Door"
                    , "SM - Maridia Tunnel B - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Maridia Tunnel B - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 12,
                                OpenEnd = 0,
                                Strats = new[] {
                                    new Strat { Requires = null /*["Gravity"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Maridia Tunnel B - Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 12,
                                OpenEnd = 0,
                                Strats = new[] {
                                    new Strat { Requires = null /*["Gravity"]*/ },
                                },
                            },
                        },
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Maridia Tunnel B - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Maridia Tunnel B - Right Door"),
                        },
                    },
                    new Link {
                        From = "SM - Maridia Tunnel B - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Maridia Tunnel B - Left Door"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Maridia Tunnel B - Sciser",
                        EnemyName = "Sciser",
                        Quantity = 1,
                        HomeNodes = new[] {
                            "SM - Maridia Tunnel B - Left Door",
                            "SM - Maridia Tunnel B - Right Door",
                        },
                    },
                },
            },
            #endregion
            #region Sand Hall B
            new Room {
                Name = "SM - Sand Hall B",
                Layout = Room.LayoutFrom(@"
                         2
                         ↓
                      1→XXX←3"
                    , "SM - Sand Hall B - Left Door"
                    , "SM - Sand Hall B - Sand Entrance"
                    , "SM - Sand Hall B - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Sand Hall B - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 1,
                                Strats = new[] {
                                    new Strat { Requires = null /*["Gravity"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Sand Hall B - Sand Entrance",
                        Type = TransitionType.Sandpit,
                    },
                    new Transition {
                        Name = "SM - Sand Hall B - Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
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
                        From = "SM - Sand Hall B - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Sand Hall B - Sand Entrance", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
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
                        From = "SM - Sand Hall B - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Sand Hall B - Sand Entrance", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
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
                        From = "SM - Sand Hall B - Sand Entrance",
                        To = new[] {
                            new LinkTarget("SM - Sand Hall B - Left Door", new[] {
                                new Strat { Requires = null, /*["Gravity"]*/ },
                                new Strat {
                                    Name = "Suitless",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "HiJump"
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Sand Hall B - Right Door", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                new Strat {
                                    Name = "Suitless",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "HiJump",
                                    //  "canUseFrozenEnemies"
                                    //]
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "East Sand Hall Left Evirs",
                        EnemyName = "Evir",
                        Quantity = 2,
                        BetweenNodes = new[] {
                            "SM - Sand Hall B - Left Door",
                            "SM - Sand Hall B - Sand Entrance",
                        },
                    },
                    new Enemy {
                        GroupName = "East Sand Hall Right Evir",
                        EnemyName = "Evir",
                        Quantity = 1,
                        BetweenNodes = new[] {
                            "SM - Sand Hall B - Right Door",
                            "SM - Sand Hall B - Sand Entrance",
                        },
                    },
                },
            },
            #endregion
            // Todo: Why A and B? Let's try to patch these two together later
            #region Pants Room A
            new Room {
                Name = "SM - Pants Room A",
                // Don't need to mention the in-room door pair as these will always connect to each
                // other in a spatially correct layout.
                Layout = Room.LayoutFrom(@"
                        XX
                        XX
                        XX←2
                      1→XX"
                    , "SM - Pants Room A - Left Door"
                    , "SM - Pants Room A - Left Leg Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Pants Room A - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 2,
                                OpenEnd = 1,
                                UsableComingIn = false,
                                Strats = new[] {
                                    new Strat { Requires = null /*["Gravity"]*/ },
                                },
                            },
                        },
                    },
                    // The center door that is accessible from the grapple block side.
                    new Transition {
                        Name = "SM - Pants Room A - Left Leg Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 2,
                                OpenEnd = 1,
                                UsableComingIn = false,
                                Strats = new[] {
                                    new Strat { Requires = null /*["Gravity"]*/ },
                                },
                            },
                        },
                    },
                    // This has no address because this transition doesn't exist in the actual game.
                    // It's just a way for us to avoid duplicating East Pants Room by pretending
                    // Pants Room ends at that point.
                    new Transition {
                        Name = "SM - Pants Room A - in-Room Transition",
                        // NodeType: exit, NodeSubType: inRoomTransition
                        Type = TransitionType.Passage,
                    },
                    new Junction {
                        Name = "SM - Pants Room A - Above Grapple Block Junction",
                    },
                    new Junction {
                        Name = "SM - Pants Room A - Bottom Left Junction",
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Pants Room A - Left Door",
                        To = new[] {
                            // This link is only for the X-Ray climb, which skips the junction altogether.
                            new LinkTarget("SM - Pants Room A - in-Room Transition", new[] {
                                new Strat {
                                    Name = "Pants Room Left-Side X-Ray Climb",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateUnderwater",
                                    //  "canRightFacingDoorXRayClimb",
                                    //  {"resetRoom":{
                                    //    "nodes": [1],
                                    //    "mustStayPut": true
                                    //  }}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Pants Room A - Bottom Left Junction", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                new Strat {
                                    Name = "Suitless",
                                    Requires = null, // ["canSuitlessMaridia"]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Pants Room A - in-Room Transition",
                        To = Empty<LinkTarget>.List,
                    },
                    new Link {
                        From = "SM - Pants Room A - Left Leg Right Door",
                        To = new[] {
                            new LinkTarget("SM - Pants Room A - Bottom Left Junction", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                new Strat {
                                    Name = "Suitless",
                                    Requires = null, // ["canSuitlessMaridia"]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Pants Room A - Bottom Left Junction",
                        To = new[] {
                            new LinkTarget("SM - Pants Room A - Left Door", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                new Strat {
                                    Name = "Suitless",
                                    Requires = null, // ["canSuitlessMaridia"]
                                },
                            }),
                            // Todo: No node had the id 7, so what do they mean here?
                            // This link is for strats that go directly to the top of the room. Other strats should go 5 -> 7 -> 2.
                            new LinkTarget("SM - Pants Room A - in-Room Transition", new[] {
                                new Strat {
                                    Name = "Pants Room Shinespark",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateUnderwater",
                                    //  "Grapple",
                                    //  {"or": [
                                    //    {"canComeInCharged": {
                                    //      "fromNode": 1,
                                    //      "inRoomPath": [1, 4],
                                    //      "framesRemaining": 150,
                                    //      "shinesparkFrames": 65
                                    //    }},
                                    //    {"canComeInCharged": {
                                    //      "fromNode": 3,
                                    //      "inRoomPath": [3, 4],
                                    //      "framesRemaining": 150,
                                    //      "shinesparkFrames": 65
                                    //    }}
                                    //  ]},
                                    //  {"enemyDamage": {
                                    //    "enemy": "Menu",
                                    //    "type": "contact",
                                    //    "hits": 1
                                    //  }}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Pants Room A - Left Leg Right Door", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                new Strat {
                                    Name = "Suitless",
                                    Requires = null, // ["canSuitlessMaridia"]
                                },
                            }),
                            new LinkTarget("SM - Pants Room A - Above Grapple Block Junction", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "Gravity",
                                    //  "Grapple",
                                    //  "SpaceJump"
                                    //]
                                },
                                new Strat {
                                    Name = "Pants Room Sand HiJump",
                                    Notable = true,
                                    Requires = null,
                                    //[ "Gravity",
                                    //  "Grapple",
                                    //  "HiJump"
                                    //]
                                },
                                // It's pretty annoying with the sand, but it's doable.
                                new Strat {
                                    Name = "Pants Room Sand MidAir SpringBall",
                                    Notable = true,
                                    Requires = null,
                                    //[ "Gravity",
                                    //  "Grapple",
                                    //  "canSpringBallJumpMidAir"
                                    //]
                                },
                                new Strat {
                                    Name = "Pants Room IBJ",
                                    Notable = true,
                                    Requires = null,
                                    //[ "Gravity",
                                    //  "Grapple",
                                    //  "canSandIBJ"
                                    //]
                                },
                                // Starting the IBJ with SpringBall is a lot less obnoxious.
                                new Strat {
                                    Name = "SpringBall IBJ",
                                    Notable = false,
                                    Requires = null,
                                    //[ "Gravity",
                                    //  "Grapple",
                                    //  "SpringBall",
                                    //  "canIBJ"
                                    //]
                                },
                                // Gets above the grapple block with doing a well-positioned and
                                // well-timed Gravity jump off the sand.
                                new Strat {
                                    Name = "Pants Room Gravity Jump",
                                    Notable = true,
                                    Requires = null,
                                    //[ "Gravity",
                                    //  "Grapple",
                                    //  "canGravityJump"
                                    //]
                                },
                                // Gets above the grapple block with doing a gravity jump off a
                                // wall jump on the side.
                                new Strat {
                                    Name = "Pants Room Gravity Walljump",
                                    Notable = true,
                                    Requires = null,
                                    //[ "Gravity",
                                    //  "Grapple",
                                    //  "canGravityWalljump"
                                    //]
                                },
                                // Requires a mid-air SpringBall jump off the sand.
                                new Strat {
                                    Name = "Suitless Pants Room SpringBall Climb",
                                    Notable = true,
                                    Requires = null,
                                    //[ "Grapple",
                                    //  "canSuitlessMaridia",
                                    //  "HiJump",
                                    //  "canSpringBallJumpMidAir"
                                    //]
                                },
                                // Uses a flatley turnaround jump to get Samus inside the gap
                                // during a spinjump.
                                new Strat {
                                    Name = "Suitless Pants Room Flatley Turnaround Climb",
                                    Notable = true,
                                    Requires = null,
                                    //[ "Grapple",
                                    //  "canSuitlessMaridia",
                                    //  "HiJump",
                                    //  "canFlatleyTurnaroundJump"
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Pants Room A - Above Grapple Block Junction",
                        To = new[] {
                            new LinkTarget("SM - Pants Room A - in-Room Transition", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                // SpaceJump is needed to break free of the water.
                                new Strat {
                                    Name = "Suitless",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "SpaceJump",
                                    //  "HiJump"
                                    //]
                                },
                            }),
                            // This link assumes the grapple block has been broken from below.
                            new LinkTarget("SM - Pants Room A - Bottom Left Junction", new[] {
                            new Strat { Requires = null /*["Gravity"]*/ },
                            // Doable without hjb, but there is a softlock risk.
                            new Strat {
                                Name = "Suitless",
                                Requires = null, // ["canSuitlessMaridia"]
                            },
                        }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Pants Room A - Menus",
                        EnemyName = "Menu",
                        Quantity = 6,
                        BetweenNodes = new[] {
                            "SM - Pants Room A - in-Room Transition",
                            "SM - Pants Room A - Above Grapple Block Junction",
                        },
                    },
                    new Enemy {
                        GroupName = "SM - Pants Room A - Top Right Puyo",
                        EnemyName = "Puyo",
                        Quantity = 1,
                        BetweenNodes = new[] {
                            "SM - Pants Room A - in-Room Transition",
                            "SM - Pants Room A - Above Grapple Block Junction",
                        },
                    },
                    new Enemy {
                        GroupName = "SM - Pants Room A - Bottom Right Puyo",
                        EnemyName = "Puyo",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Pants Room A - in-Room Transition" },
                    },
                },
            },
            #endregion
            #region Pants Room B
            new Room {
                Name = "SM - Pants Room B",
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Pants Room B - Right Leg Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 2,
                                OpenEnd = 1,
                                UsableComingIn = false,
                                Strats = new[] {
                                    new Strat { Requires = null /*["Gravity"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Pants Room B - Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 6,
                                OpenEnd = 0,
                                Strats = new[] {
                                    new Strat { Requires = null /*["Gravity"]*/ },
                                },
                            },
                            new RunwayDash {
                                Length = 7,
                                OpenEnd = 1,
                                UsableComingIn = false,
                                Strats = new[] {
                                    new Strat { Requires = null /*["Gravity"]*/ },
                                },
                            },
                        },
                    },
                    // This has no address because this transition doesn't exist in the actual game.
                    // It's just a way for us to avoid duplicating East Pants Room by pretending
                    // Pants Room ends at that point.
                    new Transition {
                        Name = "SM - Pants Room B - in-Room Transition",
                        // NodeType: entrance, NodeSubType: inRoomTransition
                        Type = TransitionType.Passage,
                    },
                    new Junction {
                        Name = "SM - Pants Room B - Below Right Door Junction",
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Pants Room B - in-Room Transition",
                        To = new[] {
                            new LinkTarget("SM - Pants Room B - Right Door"),
                        },
                    },
                    new Link {
                        From = "SM - Pants Room B - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Pants Room B - Below Right Door Junction", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                new Strat {
                                    Name = "Suitless",
                                    Requires = null, // ["canSuitlessMaridia"]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Pants Room B - Right Leg Left Door",
                        To = new[] {
                            new LinkTarget("SM - Pants Room B - Below Right Door Junction", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                // HiJump works with a crouch jump + downgrab.
                                new Strat {
                                    Name = "Suitless Base",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  {"or": [
                                    //    "canSpringBallJumpMidAir",
                                    //    "HiJump"
                                    //  ]}
                                    //]
                                },
                                // Involves breaking the top left Puyo free and then freezing it while
                                // it falls. It's very very tricky to get 4 shots off in time to freeze
                                // it. The beam requirements are to do it in less shots than that.
                                new Strat {
                                    Name = "Suitless Frozen Puyo",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "canUseFrozenEnemies",
                                    //  {"or": [
                                    //    "Wave",
                                    //    "Spazer",
                                    //    "Plasma"
                                    //  ]}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Pants Room B - Below Right Door Junction",
                        To = new[] {
                            new LinkTarget("SM - Pants Room B - Right Door", new[] {
                                new Strat {
                                    Name = "East Pants Room Puyo Clip",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateUnderwater",
                                    //  "canPuyoClip"
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Pants Room B - Right Leg Left Door", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                new Strat {
                                    Name = "Suitless",
                                    Requires = null, // ["canSuitlessMaridia"]
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Pants Room B - Top Puyo",
                        EnemyName = "Puyo",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Pants Room B - Right Door" },
                    },
                    new Enemy {
                        GroupName = "SM - Pants Room B - Middle Puyos",
                        EnemyName = "Puyo",
                        Quantity = 2,
                        HomeNodes = new[] { "SM - Pants Room B - Below Right Door Junction" },
                    },
                    new Enemy {
                        GroupName = "SM - Pants Room B - Bottom Puyos",
                        EnemyName = "Puyo",
                        Quantity = 2,
                        HomeNodes = new[] { "SM - Pants Room B - Right Leg Left Door" },
                    },
                },
            },
            #endregion
            #region Shaktool Room
            new Room {
                Name = "SM - Shaktool Room",
                Layout = Room.LayoutFrom(@"
                      1→XXXX←2"
                    , "SM - Shaktool Room - Left Door"
                    , "SM - Shaktool Room - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Shaktool Room - Left Door",
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
                                FramesRemaining = 80,
                                Strats = new[] {
                                    new Strat { Requires = null /*["f_ShaktoolDoneDigging"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Shaktool Room - Right Door",
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
                                FramesRemaining = 80,
                                Strats = new[] {
                                    new Strat { Requires = null /*["f_ShaktoolDoneDigging"]*/ },
                                },
                            },
                        },
                    },
                    // No unlock requirements for this event, since just reaching it is enough but
                    // the requirements for reaching it depend on where you're coming from.
                    new Event {
                        Name = "SM - Shaktool Room - Shaktool Done Digging",
                        Type = EventType.Flag,
                        Yields = new[] { "f_ShaktoolDoneDigging" },
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Shaktool Room - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Shaktool Room - Shaktool Done Digging", new[] {
                                new Strat {
                                    Requires = null,
                                    //{"or":[
                                    //  "f_ShaktoolDoneDigging",
                                    //  "h_canUsePowerBombs"
                                    //]}
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Shaktool Room - Right Door",
                        To = new[] {
                            // Entering from the right door gives a weird alignment glitch, but
                            // it's possible to exit back through the door and that triggers the
                            // event flag, which opens up the room on the next re-entry
                            new LinkTarget("SM - Shaktool Room - Shaktool Done Digging"),
                        },
                    },
                    new Link {
                        From = "SM - Shaktool Room - Shaktool Done Digging",
                        To = new[] {
                            new LinkTarget("SM - Shaktool Room - Left Door", new[] {
                                new Strat { Requires = null /*["f_ShaktoolDoneDigging"]*/ },
                            }),
                            new LinkTarget("SM - Shaktool Room - Right Door"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Shaktool Room - Shaktool",
                        EnemyName = "Shaktool",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Shaktool Room - Left Door" },
                    },
                    new Enemy {
                        GroupName = "SM - Shaktool Room - Yards",
                        EnemyName = "Yard",
                        Quantity = 2,
                        HomeNodes = new[] { "SM - Shaktool Room - Right Door" },
                    },
                },
            },
            #endregion
            // Todo: Acceptable name?
            #region Chozo Cavern
            new Room {
                Name = "SM - Chozo Cavern",
                Layout = Room.LayoutFrom(@"
                      1→X
                        XX"
                    , "SM - Chozo Cavern - Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Chozo Cavern - Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 6,
                                OpenEnd = 0,
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - Chozo Cavern - Item",
                        Type = PlacementType.Chozo,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Chozo Cavern - Door",
                        To = new[] {
                            new LinkTarget("SM - Chozo Cavern - Item", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "Morph",
                                    //  "Gravity",
                                    //  {"or": [
                                    //    "Bombs",
                                    //    {"and":[
                                    //      "PowerBomb",
                                    //      {"ammo": {
                                    //        "type": "PowerBomb",
                                    //        "count": 2
                                    //      }}
                                    //    ]},
                                    //    "SpringBall"
                                    //  ]}
                                    //]
                                },
                                new Strat {
                                    Name = "Suitless",
                                    Requires = null,
                                    //[ "h_canUseSpringBall",
                                    //  "canSuitlessMaridia"
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Chozo Cavern - Item",
                        To = new[] {
                            new LinkTarget("SM - Chozo Cavern - Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "Morph",
                                    //  "Gravity"
                                    //]
                                },
                                new Strat {
                                    Name = "Suitless",
                                    Requires = null,
                                    //[ "Morph",
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
        };

    }

}
