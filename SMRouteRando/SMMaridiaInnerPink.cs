using System.Collections.Generic;
using SMRouteRando.Util;

namespace SMRouteRando {

    public class SMMaridiaInnerPink {

        public static IList<Room> Rooms { get; } = new[] {
            #region Crab Shaft
            new Room {
                Name = "SM - Crab Shaft",
                Layout = Room.LayoutFrom(@"
                        2
                        ↓
                        X
                        X
                      1→X
                        XX←3"
                    , "SM - Crab Shaft - Left Door"
                    , "SM - Crab Shaft - Top Door"
                    , "SM - Crab Shaft - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Crab Shaft - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 13,
                                OpenEnd = 0,
                                Strats = new[] {
                                    new Strat { Requires = null, /*["Gravity"]*/ },
                                },
                            },
                        },
                    },
                    // No spawnAt and no junction below, because the door can be entered with just
                    // a crouch jump.
                    new Transition {
                        Name = "SM - Crab Shaft - Top Door",
                        Type = TransitionType.Blue,
                    },
                    new Transition {
                        Name = "SM - Crab Shaft - Right Door",
                        Type = TransitionType.Green,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 1,
                                Strats = new[] {
                                    new Strat { Requires = null /*["Gravity"]*/ },
                                },
                            },
                        },
                        CanLeaveCharged = new[] {
                            new RunwayCharge {
                                Length = 23,
                                FramesRemaining = 90,
                                OpenEnd = 0,
                                Strats = new[] {
                                    new Strat { Requires = null /*["Gravity"]*/ },
                                },
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Crab Shaft - Green Lock",
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
                        From = "SM - Crab Shaft - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Crab Shaft - Right Door"),
                            new LinkTarget("SM - Crab Shaft - Top Door", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                // It's a really long one.
                                new Strat {
                                    Name = "Crab Shaft Walljump Climb",
                                    Notable = true,
                                    Requires = null, // ["canSunkenDualWallClimb"]
                                },
                                new Strat {
                                    Name = "Shinespark",
                                    Notable = false,
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  {"canComeInCharged": {
                                    //    "fromNode": 1,
                                    //    "framesRemaining": 60,
                                    //    "shinesparkFrames": 40
                                    //  }}
                                    //]
                                },
                                new Strat {
                                    Name = "Crab Shaft Crab Climb",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "canCrabClimb"
                                    //]
                                },
                                // Differs from crab climb in that the crabs only serve as one-time
                                // stepping stone between platforms.
                                new Strat {
                                    Name = "Frozen HiJump",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "HiJump",
                                    //  "canUseFrozenEnemies"
                                    //]
                                },
                                // Differs from crab climb in that the crabs only serve as one-time
                                // stepping stone between platforms.
                                new Strat {
                                    Name = "Frozen SpringBall",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "canSpringBallJumpMidAir",
                                    //  "canUseFrozenEnemies"
                                    //]
                                },
                                new Strat {
                                    Name = "Dual Jump Assist",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "canSpringBallJumpMidAir",
                                    //  "HiJump"
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Crab Shaft - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Crab Shaft - Left Door", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                new Strat {
                                    Name = "Jump Assist",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  {"or": [
                                    //    "canSpringBallJumpMidAir",
                                    //    "HiJump"
                                    //  ]}
                                    //]
                                },
                                // Involves a Super to freeze a crab in midair.
                                new Strat {
                                    Name = "Crab Shaft Bottom Frozen Falling Crab",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "Super",
                                    //  {"ammo": {
                                    //    "type": "Super",
                                    //    "count": 1
                                    //  }},
                                    //  "canUseFrozenEnemies"
                                    //]
                                },
                                // Freeze a crab below the opening, and another one at the ceiling
                                // on the lip of the entrance. Crouch jump + downgrab makes it
                                // possible to get up. Another frozen crab can help complete the
                                // way up.
                                new Strat {
                                    Name = "Crab Shaft Bottom Frozen Crab Steps",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "canUseFrozenEnemies"
                                    //]
                                },
                                // Similar to naked watering hole escape. Freeze a crab under the
                                // gap above, do a stationary spinjump facing right, then walljump
                                // until you're up. Another frozen crab can help complete the way
                                // up.
                                new Strat {
                                    Name = "Crab Shaft Bottom Repetitive Walljumps",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "canUseFrozenEnemies",
                                    //  "canStationarySpinJump"
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Crab Shaft - Top Door",
                        To = new[] {
                            new LinkTarget("SM - Crab Shaft - Left Door"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Crab Shaft - Bottom Scisers",
                        EnemyName = "Sciser",
                        Quantity = 3,
                        HomeNodes = new[] { "SM - Crab Shaft - Right Door" },
                    },
                    new Enemy {
                        GroupName = "SM - Crab Shaft - Top Sciser",
                        EnemyName = "Sciser",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Crab Shaft - Top Door" },
                    },
                },
            },
            #endregion
            #region Maridia Pink Save Room A
            new Room {
                Name = "SM - Maridia Pink Save Room A",
                Layout = Room.LayoutFrom(@"
                      X←1"
                    , "SM - Maridia Pink Save Room A - Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Maridia Pink Save Room A - Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 1,
                                Strats = new[] {
                                    new Strat { Requires = null /*[ "Gravity" ]*/ },
                                },
                            },
                        },
                    },
                    new Utility {
                        Name = "SM - Maridia Pink Save Room A - Save Station",
                        Type = UtilityType.Save,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Maridia Pink Save Room A - Door",
                        To = new[] {
                            new LinkTarget("SM - Maridia Pink Save Room A - Save Station"),
                        },
                    },
                    new Link {
                        From = "SM - Maridia Pink Save Room A - Save Station",
                        To = new[] {
                            new LinkTarget("SM - Maridia Pink Save Room A - Door"),
                        },
                    },
                },
            },
            #endregion
            #region Aqueduct
            new Room {
                Name = "SM - Aqueduct",
                Layout = Room.LayoutFrom(@"
                        3
                        ↓
                        XXXXXX
                      2→XXXXXX←4
                      1→XXXXXX
                         ↑ ↑
                         6 5"
                    , "SM - Aqueduct - Bottom Left Door"
                    , "SM - Aqueduct - Top Left Door"
                    , "SM - Aqueduct - Top Door"
                    , "SM - Aqueduct - Right Door"
                    , "SM - Aqueduct - Right Sand Pit"
                    , "SM - Aqueduct - Left Sand Pit"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Aqueduct - Bottom Left Door",
                        Type = TransitionType.Red,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 33,
                                OpenEnd = 1,
                                Strats = new[] {
                                    new Strat { Requires = null /*["Gravity"]*/ },
                                },
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Aqueduct - Save Red Lock",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenRedDoors"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Aqueduct - Top Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 5,
                                OpenEnd = 1,
                                Strats = new[] {
                                    new Strat { Requires = null /*["Gravity"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Aqueduct - Top Door",
                        Type = TransitionType.Blue,
                        SpawnAt = "SM - Aqueduct - Top Door Junction",
                    },
                    new Transition {
                        Name = "SM - Aqueduct - Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 0,
                                OpenEnd = 1,
                            },
                        },
                        CanLeaveCharged = new[] {
                            new RunwayCharge {
                                Length = 20,
                                FramesRemaining = 60,
                                OpenEnd = 2,
                                Strats = new[] {
                                    new Strat { Requires = null /*["Gravity"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Aqueduct - Right Sand Pit",
                        Type = TransitionType.Sandpit,
                        Direction = TransitionDirection.Exit,
                    },
                    new Transition {
                        Name = "SM - Aqueduct - Left Sand Pit",
                        Type = TransitionType.Sandpit,
                        Direction = TransitionDirection.Exit,
                    },
                    new Placement {
                        Name = "SM - Aqueduct - Left Item",
                        Type = PlacementType.Visible,
                    },
                    new Placement {
                        Name = "SM - Aqueduct - Right Item",
                        Type = PlacementType.Visible,
                    },
                    new Junction {
                        Name = "SM - Aqueduct - Top Door Junction",
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
                        From = "SM - Aqueduct - Top Left Door",
                        To = new[] {
                            new LinkTarget("SM - Aqueduct - Bottom Left Door", new[] {
                                new Strat {
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Power Bomb Blocks",
                                            Requires = null, // ["h_canUsePowerBombs"]
                                        },
                                    },
                                },
                            }),
                            new LinkTarget("SM - Aqueduct - Top Door Junction", new[] {
                                new Strat {
                                    Name = "Aqueduct Left-Side X-Ray Climb (Upper)",
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
                        From = "SM - Aqueduct - Bottom Left Door",
                        To = new[] {
                            new LinkTarget("SM - Aqueduct - Top Left Door", new[] {
                                new Strat {
                                    Requires = null, // ["Gravity"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Power Bomb Blocks",
                                            Requires = null, // ["h_canUsePowerBombs"]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Snail Clip",
                                    Requires = null,
                                    //[ "Gravity",
                                    //  "canSnailClip"
                                    //]
                                },
                                new Strat {
                                    Name = "Aqueduct Left-Side X-Ray Climb (Lower)",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateUnderwater",
                                    //  "canRightFacingDoorXRayClimb",
                                    //  {"resetRoom":{
                                    //    "nodes": [2],
                                    //    "mustStayPut": true
                                    //  }}
                                    //]
                                },
                                new Strat {
                                    Name = "Suitless Jump Assist",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "HiJump",
                                    //  "canSpringBallJumpMidAir"
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Power Bomb Blocks",
                                            Requires = null, // ["h_canUsePowerBombs"]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Suitless Snail Climb",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "canSnailClimb"
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Power Bomb Blocks",
                                            Requires = null, // ["h_canUsePowerBombs"]
                                        },
                                    },
                                },
                            }),
                            // There's nothing difficult about getting here suitless, but it does
                            // run a heavy risk of leading the player into suitless Maridia
                            // situations.
                            new LinkTarget("SM - Aqueduct - Right Sand Pit", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                new Strat {
                                    Name = "Suitless",
                                    Requires = null, // ["canSuitlessMaridia"]
                                },
                            }),
                            new LinkTarget("SM - Aqueduct - Right Door", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                new Strat {
                                    Name = "Grapple Jump",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "canGrappleJump"
                                    //]
                                },
                                new Strat {
                                    Name = "Snail Climb",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "canSnailClimb"
                                    //]
                                },
                            }),
                            // This direct link is just for the shinespark.
                            new LinkTarget("SM - Aqueduct - Left Item", new[] {
                                new Strat {
                                    Name = "Shinespark",
                                    Requires = null,
                                    //[ "Gravity",
                                    //  {"canShineCharge": {
                                    //    "usedTiles": 33,
                                    //    "shinesparkFrames": 40,
                                    //    "openEnd": 2
                                    //  }}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Aqueduct - Top Door Junction", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                new Strat {
                                    Name = "Grapple Jump",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "canGrappleJump"
                                    //]
                                },
                                new Strat {
                                    Name = "Snail Climb",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "canSnailClimb"
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Aqueduct - Left Sand Pit",
                        To = new[] {
                            // There's nothing difficult about getting here suitless, but it does
                            // run a heavy risk of leading the player into suitless Maridia
                            // situations.
                            new LinkTarget("SM - Aqueduct - Right Sand Pit", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                new Strat {
                                    Name = "Suitless",
                                    Requires = null, // ["canSuitlessMaridia"]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Aqueduct - Right Sand Pit",
                        To = new[] {
                            new LinkTarget("SM - Aqueduct - Bottom Left Door", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                new Strat {
                                    Name = "Suitless",
                                    Requires = null, // ["canSuitlessMaridia"]
                                },
                            }),
                            // There's nothing difficult about getting here suitless, but it does
                            // run a heavy risk of leading the player into suitless Maridia
                            // situations.
                            new LinkTarget("SM - Aqueduct - Left Sand Pit", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                new Strat {
                                    Name = "Suitless",
                                    Requires = null, // ["canSuitlessMaridia"]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Aqueduct - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Aqueduct - Bottom Left Door"),
                            new LinkTarget("SM - Aqueduct - Left Item", new[] {
                                new Strat {
                                    Name = "Snail Clip",
                                    Requires = null,
                                    //[ "Gravity",
                                    //  "canSnailClip"
                                    //]
                                },
                                new Strat {
                                    Name = "Shinespark",
                                    Requires = null,
                                    //[ "Gravity",
                                    //  {"canShineCharge": {
                                    //    "usedTiles": 20,
                                    //    "shinesparkFrames": 25,
                                    //    "openEnd": 2
                                    //  }}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Aqueduct - Top Door",
                        To = new[] {
                            new LinkTarget("SM - Aqueduct - Top Door Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Aqueduct - Left Item",
                        To = new[] {
                            new LinkTarget("SM - Aqueduct - Right Item"),
                        },
                    },
                    new Link {
                        From = "SM - Aqueduct - Right Item",
                        To = new[] {
                            new LinkTarget("SM - Aqueduct - Right Door"),
                        },
                    },
                    new Link {
                        From = "SM - Aqueduct - Top Door Junction",
                        To = new[] {
                            new LinkTarget("SM - Aqueduct - Top Left Door", new[] {
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
                                    //  "h_canBombThings"
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Aqueduct - Bottom Left Door"),
                            new LinkTarget("SM - Aqueduct - Top Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //{"or":[
                                    //  "Gravity",
                                    //  "HiJump",
                                    //  "canSpringBallJumpMidAir"
                                    //]}
                                },
                                // Involves waiting around for a snail to come along, in order to
                                // reach the door by jumping while standing on it.
                                new Strat {
                                    Name = "Aqueduct Top Door Snailstep",
                                    Notable = true,
                                    Requires = null, // ["canUseEnemies"],
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    // They move around the external walls even when offscreen, and can be brought
                    // to any of their home nodes.
                    new Enemy {
                        GroupName = "SM - Aqueduct - Free-Roaming Yards",
                        EnemyName = "Yard",
                        Quantity = 3,
                        HomeNodes = new[] {
                            "SM - Aqueduct - Bottom Left Door",
                            "SM - Aqueduct - Right Door",
                            "SM - Aqueduct - Top Door Junction",
                        },
                    },
                    // It circles around on one of the grapple panels.
                    new Enemy {
                        GroupName = "SM - Aqueduct - Middle Yard",
                        EnemyName = "Yard",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Aqueduct - Bottom Left Door" },
                    },
                    new Enemy {
                        GroupName = "SM - Aqueduct - Bottom Yard",
                        EnemyName = "Yard",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Aqueduct - Right Sand Pit" },
                    },
                },
            },
            #endregion
            // Todo: Acceptable name? Refers to finding the correct path in Super Mario Bros.
            #region Last Castle Hallway
            new Room {
                Name = "SM - Last Castle Hallway",
                Layout = Room.LayoutFrom(@"
                      XXXX←1
                      ↑
                      2"
                    , "SM - Last Castle Hallway - Right Door"
                    , "SM - Last Castle Hallway - Bottom Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Last Castle Hallway - Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 4,
                                OpenEnd = 1,
                                Strats = new[] {
                                    new Strat { Requires = null /*["Gravity"]*/ },
                                },
                            },
                        },
                        CanLeaveCharged = new[] {
                            new RunwayCharge {
                                Length = 33,
                                FramesRemaining = 90,
                                OpenEnd = 2,
                                Strats = new[] {
                                    new Strat { Requires = null /*["Gravity"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Last Castle Hallway - Bottom Door",
                        Type = TransitionType.Blue,
                        CanLeaveCharged = new[] {
                            new RunwayCharge {
                                Length = 33,
                                FramesRemaining = 80,
                                OpenEnd = 2,
                                Strats = new[] {
                                    new Strat { Requires = null /*["Gravity"]*/ },
                                },
                            },
                        },
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Last Castle Hallway - Bottom Door",
                        To = new[] {
                            new LinkTarget("SM - Last Castle Hallway - Right Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "Gravity",
                                    //  "SpeedBooster"
                                    //]
                                },
                                new Strat {
                                    Name = "Botwoon Puyo Clip (Left to Right)",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateUnderwater",
                                    //  "canPuyoClip"
                                    //]
                                },
                                new Strat {
                                    Name = "Botwoon Mochtroid Clip (Left to Right)",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateUnderwater",
                                    //  "canMochtroidClip"
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Last Castle Hallway - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Last Castle Hallway - Bottom Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "Gravity",
                                    //  "SpeedBooster"
                                    //]
                                },
                                new Strat {
                                    Name = "Botwoon Puyo Clip (Right to Left)",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateUnderwater",
                                    //  "canPuyoClip"
                                    //]
                                },
                                new Strat {
                                    Name = "Botwoon Mochtroid Clip (Right to Left)",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateUnderwater",
                                    //  "canMochtroidClip"
                                    //]
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Last Castle Hallway - Left Mochtroids",
                        EnemyName = "Mochtroid",
                        Quantity = 2,
                        HomeNodes = new[] { "SM - Last Castle Hallway - Bottom Door" },
                    },
                    new Enemy {
                        GroupName = "SM - Last Castle Hallway - Middle Mochtroid",
                        EnemyName = "Mochtroid",
                        Quantity = 1,
                        BetweenNodes = new[] {
                            "SM - Last Castle Hallway - Bottom Door",
                            "SM - Last Castle Hallway - Right Door",
                        },
                        // It's stuck in a prison and you need morph to enter.
                        DropRequires = null,
                        //{"or": [
                        //  "Morph",
                        //  "Grapple"
                        //]}
                    },
                    new Enemy {
                        GroupName = "SM - Last Castle Hallway - Right Mochtroid",
                        EnemyName = "Mochtroid",
                        Quantity = 1,
                        BetweenNodes = new[] {
                            "SM - Last Castle Hallway - Bottom Door",
                            "SM - Last Castle Hallway - Right Door",
                        },
                    },
                    new Enemy {
                        GroupName = "SM - Last Castle Hallway - Puyos",
                        EnemyName = "Puyo",
                        Quantity = 2,
                        BetweenNodes = new[] {
                            "SM - Last Castle Hallway - Bottom Door",
                            "SM - Last Castle Hallway - Right Door",
                        },
                    },
                },
            },
            #endregion
            #region Botwoon's Room
            new Room {
                Name = "SM - Botwoon's Room",
                Layout = Room.LayoutFrom(@"
                      1→XX←2"
                    , "SM - Botwoon's Room - Left Door"
                    , "SM - Botwoon's Room - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Botwoon's Room - Left Door",
                        Type = TransitionType.Gray,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 0,
                                OpenEnd = 1,
                            },
                        },
                        CanLeaveCharged = new[] {
                            new RunwayCharge {
                                Length = 16,
                                FramesRemaining = 100,
                                OpenEnd = 0,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "Gravity",
                                        //  "f_DefeatedBotwoon"
                                        //]
                                    },
                                },
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Botwoon's Room - Grey Lock",
                                Type = LockType.GameFlag,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["f_DefeatedBotwoon"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Botwoon's Room - Right Door",
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
                        CanLeaveCharged = new[] {
                            new RunwayCharge {
                                Length = 16,
                                FramesRemaining = 40,
                                OpenEnd = 0,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "Gravity",
                                        //  "f_DefeatedBotwoon"
                                        //]
                                    },
                                },
                            },
                        },
                    },
                    new Event {
                        Name = "SM - Botwoon's Room - Botwoon",
                        Type = EventType.Boss,
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Botwoon's Room - Botwoon Fight",
                                Type = LockType.BossFight,
                                UnlockStrats = new[] {
                                    new Strat {
                                        Name = "Gravity",
                                        Requires = null,
                                        //[ "Gravity",
                                        //  {"enemyKill":{
                                        //    "enemies": [
                                        //      [ "Botwoon" ]
                                        //    ]
                                        //  }}
                                        //]
                                    },
                                    new Strat {
                                        Name = "Suitless Botwoon Kill",
                                        Notable = true,
                                        Requires = null,
                                        //[ "canSuitlessMaridia",
                                        //  {"enemyKill":{
                                        //    "enemies": [
                                        //      [ "Botwoon" ]
                                        //    ]
                                        //  }}
                                        //]
                                    },
                                },
                            },
                        },
                        Yields = new[] { "f_DefeatedBotwoon" },
                    },
                    // This represents fighting Botwoon from behind the wall.
                    new Event {
                        Name = "SM - Botwoon's Room - Back-Side Botwoon",
                        Type = EventType.Boss,
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Botwoon's Room - Back-Side Botwoon Fight",
                                Type = LockType.BossFight,
                                UnlockStrats = new[] {
                                    // With Gravity, dodging the acid is pretty trivial. Even
                                    // without knowing about the distance trick expected in the
                                    // suitless version.
                                    new Strat {
                                        Name = "Gravity Wave",
                                        Requires = null,
                                        //[ "Gravity",
                                        //  "Charge",
                                        //  "Wave"
                                        //]
                                    },
                                    // Even when suitless, it's possible to stand far enough that
                                    // the acid attack doesn't spawn. Botwoon still gets hit. So
                                    // there's a safe way to take no damage.
                                    new Strat {
                                        Name = "Suitless Botwoon Backdoor Kill (Wave)",
                                        Notable = true,
                                        Requires = null,
                                        //[ "canSuitlessMaridia",
                                        //  "Charge",
                                        //  "Wave"
                                        //]
                                    },
                                },
                            },
                        },
                        Yields = new[] { "f_DefeatedBotwoon" },
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Botwoon's Room - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Botwoon's Room - Botwoon"),
                        },
                    },
                    new Link {
                        From = "SM - Botwoon's Room - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Botwoon's Room - Back-Side Botwoon"),
                        },
                    },
                    new Link {
                        From = "SM - Botwoon's Room - Botwoon",
                        To = new[] {
                            new LinkTarget("SM - Botwoon's Room - Left Door"),
                            new LinkTarget("SM - Botwoon's Room - Back-Side Botwoon", new[] {
                                new Strat { Requires = null /*["f_DefeatedBotwoon"]*/ },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Botwoon's Room - Back-Side Botwoon",
                        To = new[] {
                            new LinkTarget("SM - Botwoon's Room - Right Door"),
                            new LinkTarget("SM - Botwoon's Room - Botwoon", new[] {
                                new Strat { Requires = null /*["f_DefeatedBotwoon"]*/ },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Botwoon's Room - Botwoon",
                        EnemyName = "Botwoon",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Botwoon's Room - Botwoon" },
                        StopSpawn = null, // ["f_DefeatedBotwoon"]
                    },
                },
            },
            #endregion
            // Todo: Acceptable name?
            #region Sandsurf Room
            new Room {
                Name = "SM - Sandsurf Room",
                Layout = Room.LayoutFrom(@"
                      1→XXXXXXX←2
                          ↑↑
                          43"
                    , "SM - Sandsurf Room - Left Door"
                    , "SM - Sandsurf Room - Right Door"
                    , "SM - Sandsurf Room - Right Sand Pit"
                    , "SM - Sandsurf Room - Left Sand Pit"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Sandsurf Room - Left Door",
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
                        CanLeaveCharged = new[] {
                            new RunwayCharge {
                                Length = 33,
                                FramesRemaining = 120,
                                OpenEnd = 2,
                                Strats = new[] {
                                    new Strat { Requires = null /*["Gravity"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Sandsurf Room - Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 22,
                                GentleUpTiles = 4,
                                OpenEnd = 1,
                                Strats = new[] {
                                    new Strat { Requires = null /*["Gravity"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Sandsurf Room - Right Sand Pit",
                        Type = TransitionType.Sandpit,
                        Direction = TransitionDirection.Exit,
                    },
                    new Transition {
                        Name = "SM - Sandsurf Room - Left Sand Pit",
                        Type = TransitionType.Sandpit,
                        Direction = TransitionDirection.Exit,
                    },
                    new Placement {
                        Name = "SM - Sandsurf Room - Item",
                        Type = PlacementType.Visible,
                    },
                    new Junction {
                        Name = "SM - Sandsurf Room - Right of Morph Maze Junction",
                    },
                },
                Obstacles = new[] {
                    new Obstacle {
                        Name = "Speed Blocks",
                        Type = ObstacleType.Inanimate,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Sandsurf Room - Left Door",
                        To = new[] {
                            // There's nothing difficult about getting here suitless, but it does
                            // run a heavy risk of leading the player into suitless Maridia
                            // situations.
                            new LinkTarget("SM - Sandsurf Room - Left Sand Pit", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                new Strat {
                                    Name = "Suitless",
                                    Requires = null, // ["canSuitlessMaridia"]
                                },
                            }),
                            // There's nothing difficult about getting here suitless, but it does
                            // run a heavy risk of leading the player into suitless Maridia
                            // situations.
                            new LinkTarget("SM - Sandsurf Room - Right Sand Pit", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                new Strat {
                                    Name = "Suitless",
                                    Requires = null, // ["canSuitlessMaridia"]
                                },
                            }),
                            // Direct link passing below. Passage above should go Left Door ->
                            // Item -> Right Door.
                            new LinkTarget("SM - Sandsurf Room - Right Door", new[] {
                                new Strat {
                                    Requires = null, // ["Gravity"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Speed Blocks",
                                            Requires = null, // ["SpeedBooster"]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Suitless Spark",
                                    Requires = null, // ["canSuitlessMaridia"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Speed Blocks",
                                            Requires = null,
                                            //{"canComeInCharged": {
                                            //  "fromNode": 1,
                                            //  "framesRemaining": 80,
                                            //  "shinesparkFrames": 159
                                            //}}
                                        },
                                    },
                                },
                            }),
                            new LinkTarget("SM - Sandsurf Room - Item", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "Gravity",
                                    //  "Morph"
                                    //]
                                },
                                new Strat {
                                    Name = "Suitless Jump Assist",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "Morph",
                                    //  {"or": [
                                    //    "canSpringBallJumpMidAir",
                                    //    "HiJump"
                                    //  ]}
                                    //]
                                },
                                new Strat {
                                    Name = "Suitless Frozen Puyo",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "Morph",
                                    //  "canUseFrozenEnemies"
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Sandsurf Room - Left Sand Pit",
                        To = Empty<LinkTarget>.List,
                    },
                    new Link {
                        From = "SM - Sandsurf Room - Right Sand Pit",
                        To = Empty<LinkTarget>.List,
                    },
                    new Link {
                        From = "SM - Sandsurf Room - Right Door",
                        To = new[] {
                            // Direct link passing below. Passage above should go Right Door ->
                            // Item -> Left Door.
                            new LinkTarget("SM - Sandsurf Room - Left Door", new[] {
                                // The canComeInCharged with 180 frames remaining is intended to
                                // logically include an in-room short charge.
                                new Strat {
                                    Requires = null, // ["Gravity"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Speed Blocks",
                                            Requires = null,
                                            //{"or": [
                                            //  {"canComeInCharged": {
                                            //    "fromNode": 4,
                                            //    "framesRemaining": 180,
                                            //    "shinesparkFrames": 0
                                            //  }},
                                            //  {"canComeInCharged": {
                                            //    "fromNode": 4,
                                            //    "framesRemaining": 80,
                                            //    "shinesparkFrames": 115
                                            //  }}
                                            //]}
                                        },
                                    },
                                },
                                // Coming in with zero momentum, all it takes is one non-hjb full
                                // height bounce forward, then activate.
                                new Strat {
                                    Name = "Suitless Spark",
                                    Requires = null, // ["canSuitlessMaridia"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Speed Blocks",
                                            Requires = null,
                                            //{"canComeInCharged": {
                                            //  "fromNode": 4,
                                            //  "framesRemaining": 160,
                                            //  "shinesparkFrames": 147
                                            //}}
                                        },
                                    },
                                },
                            }),
                            new LinkTarget("SM - Sandsurf Room - Right of Morph Maze Junction", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                new Strat {
                                    Name = "Suitless Jump Assist",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  {"or": [
                                    //    "canSpringBallJumpMidAir",
                                    //    "HiJump"
                                    //  ]}
                                    //]
                                },
                                new Strat {
                                    Name = "Suitless Frozen Zoa",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "canUseFrozenEnemies"
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Sandsurf Room - Item",
                        To = new[] {
                            new LinkTarget("SM - Sandsurf Room - Left Door", new[] {
                                new Strat { Requires = null /*["Morph"]*/ },
                            }),
                            new LinkTarget("SM - Sandsurf Room - Right of Morph Maze Junction", new[] {
                                // With Gravity, this means taking it off to mid-air morph. That
                                // doesn't count as true suitless Maridia. There are otherways to
                                // do this than a mid-air morph, but they have more requirements
                                // than this strat which isn't even notable.
                                new Strat {
                                    Name = "Midair Morph",
                                    Requires = null,
                                    //[ "h_canNavigateUnderwater",
                                    //  "Morph"
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Sandsurf Room - Right of Morph Maze Junction",
                        To = new[] {
                            new LinkTarget("SM - Sandsurf Room - Right Door"),
                            new LinkTarget("SM - Sandsurf Room - Item", new[] {
                                // With Gravity, this means taking it off to mid-air morph. That
                                // doesn't count as true suitless Maridia. There are otherways to
                                // do this than a mid-air morph, but they have more requirements
                                // than this strat which isn't even notable.
                                new Strat {
                                    Name = "Midair Morph",
                                    Requires = null,
                                    //[ "h_canNavigateUnderwater",
                                    //  "Morph"
                                    //]
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "Botwoon E-Tank Left Puyos",
                        EnemyName = "Puyo",
                        Quantity = 4,
                        HomeNodes = new[] { "SM - Sandsurf Room - Left Door" },
                    },
                    new Enemy {
                        GroupName = "Botwoon E-Tank Right Puyo",
                        EnemyName = "Puyo",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Sandsurf Room - Right Sand Pit" },
                    },
                    new Enemy {
                        GroupName = "Botwoon E-Tank Zoas",
                        EnemyName = "Zoa",
                        Quantity = 5,
                        HomeNodes = new[] { "SM - Sandsurf Room - Right Door" },
                        FarmCycles = new[] {
                            // Needs Gravity to get into the sand.
                            new FarmCycle {
                                Name = "Zoa Power Beam spam",
                                CycleFrames = 150,
                                Requires = null, // ["Gravity"]
                            },
                            new FarmCycle {
                                Name = "Zoa Power Beam suitless back and forth",
                                CycleFrames = 300,
                                Requires = null, // ["canSuitlessMaridia"]
                            },
                            new FarmCycle {
                                Name = "Zoa diagonal Grapple",
                                CycleFrames = 150,
                                Requires = null, // ["Grapple"]
                            },
                        },
                    },
                },
            },
            #endregion
            // Todo: Acceptable name?
            #region Maridia Pink Climb Room
            new Room {
                Name = "SM - Maridia Pink Climb Room",
                Layout = Room.LayoutFrom(@"
                        X←3
                      2→X
                      1→XXXXX←4"
                    , "SM - Maridia Pink Climb Room - Bottom Left Door"
                    , "SM - Maridia Pink Climb Room - Top Left Door"
                    , "SM - Maridia Pink Climb Room - Top Right Door"
                    , "SM - Maridia Pink Climb Room - Bottom Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Maridia Pink Climb Room - Bottom Left Door",
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
                        Name = "SM - Maridia Pink Climb Room - Top Left Door",
                        Type = TransitionType.Gray,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 1,
                                OpenEnd = 1,
                                UsableComingIn = false,
                                Strats = new[] {
                                    new Strat { Requires = null /*["Gravity"]*/ },
                                },
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Maridia Pink Climb Room - Grey Lock",
                                Type = LockType.GameFlag,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["f_DefeatedDraygon"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Maridia Pink Climb Room - Top Right Door",
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
                        Name = "SM - Maridia Pink Climb Room - Bottom Right Door",
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
                                FramesRemaining = 120,
                                OpenEnd = 2,
                                Strats = new[] {
                                    new Strat { Requires = null /*["Gravity"]*/ },
                                },
                            },
                        },
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Maridia Pink Climb Room - Top Left Door",
                        To = new[] {
                            new LinkTarget("SM - Maridia Pink Climb Room - Bottom Left Door"),
                            new LinkTarget("SM - Maridia Pink Climb Room - Top Right Door", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                new Strat {
                                    Name = "Shinespark",
                                    Requires = null,
                                    //{"canComeInCharged": {
                                    //  "fromNode": 1,
                                    //  "framesRemaining": 20,
                                    //  "shinesparkFrames": 25
                                    //}}
                                },
                                new Strat {
                                    Name = "Mochtroid Climb",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "canMochtroidClimb"
                                    //]
                                },
                                new Strat {
                                    Name = "Suitless Grapple",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "Grapple"
                                    //]
                                },
                                new Strat {
                                    Name = "Break Free",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "HiJump",
                                    //  "SpaceJump"
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Maridia Pink Climb Room - Bottom Left Door",
                        To = new[] {
                            new LinkTarget("SM - Maridia Pink Climb Room - Top Left Door", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                new Strat {
                                    Name = "Shinespark",
                                    Requires = null,
                                    //{"canComeInCharged": {
                                    //  "fromNode": 2,
                                    //  "framesRemaining": 30,
                                    //  "shinesparkFrames": 20
                                    //}}
                                },
                                new Strat {
                                    Name =  "Halfie Climb X-Ray Climb",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "canRightFacingDoorXRayClimb",
                                    //  {"resetRoom":{
                                    //    "nodes": [2],
                                    //    "mustStayPut": true
                                    //  }}
                                    //]
                                },
                                new Strat {
                                    Name = "Mochtroid Climb",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "canMochtroidClimb"
                                    //]
                                },
                                new Strat {
                                    Name = "Suitless Grapple",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "Grapple"
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Maridia Pink Climb Room - Bottom Right Door", new[] {
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
                                    //  {"or": [
                                    //    "canSpringBallJumpMidAir",
                                    //    "HiJump"
                                    //  ]}
                                    //]
                                },
                            }),
                            // This link is only for the shinespark. Other strats should go
                            // Bottom Left Door -> Top Left Door -> Top Right Door.
                            new LinkTarget("SM - Maridia Pink Climb Room - Top Right Door", new[] {
                                new Strat {
                                    Name = "Shinespark",
                                    Requires = null,
                                    //{"canComeInCharged": {
                                    //  "fromNode": 2,
                                    //  "framesRemaining": 30,
                                    //  "shinesparkFrames": 45
                                    //}}
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Maridia Pink Climb Room - Bottom Right Door",
                        To = new[] {
                            new LinkTarget("SM - Maridia Pink Climb Room - Bottom Left Door", new[] {
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
                                    //  {"or": [
                                    //    "canSpringBallJumpMidAir",
                                    //    "HiJump"
                                    //  ]}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Maridia Pink Climb Room - Top Right Door",
                        To = new[] {
                            new LinkTarget("SM - Maridia Pink Climb Room - Top Left Door"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "Halfie Climb Mochtroids",
                        EnemyName = "Mochtroid",
                        Quantity = 3,
                        HomeNodes = new[] {
                            "SM - Maridia Pink Climb Room - Top Left Door",
                            "SM - Maridia Pink Climb Room - Bottom Left Door",
                        },
                    },
                    new Enemy {
                        GroupName = "Halfie Climb Oums",
                        EnemyName = "Oum",
                        Quantity = 3,
                        HomeNodes = new[] { "SM - Maridia Pink Climb Room - Bottom Right Door" },
                    },
                },
            },
            #endregion
            #region Maridia Pink Missile Refil Room
            new Room {
                Name = "SM - Maridia Pink Missile Refil Room",
                Layout = Room.LayoutFrom(@"
                      1→X"
                    , "SM - Maridia Missile Refill Room - Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Maridia Missile Refill Room - Door",
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
                    new Utility {
                        Name = "SM - Maridia Missile Refill Room - Missile Refill",
                        Type = UtilityType.Missile,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Maridia Missile Refill Room - Door",
                        To = new[] {
                            new LinkTarget("SM - Maridia Missile Refill Room - Missile Refill"),
                        },
                    },
                    new Link {
                        From = "SM - Maridia Missile Refill Room - Missile Refill",
                        To = new[] {
                            new LinkTarget("SM - Maridia Missile Refill Room - Door"),
                        },
                    },
                },
            },
            #endregion
            #region Colosseum
            new Room {
                Name = "SM - Colosseum",
                Layout = Room.LayoutFrom(@"
                      1→XXXXXXX←2
                        XXXXXXX←3"
                    , "SM - Colosseum - Left Door"
                    , "SM - Colosseum - Top Right Door"
                    , "SM - Colosseum - Bottom Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Colosseum - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 2,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Colosseum - Top Right Door",
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
                                Name = "SM - Colosseum - Red Lock",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenRedDoors"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Colosseum - Bottom Right Door",
                        Type = TransitionType.Green,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 1,
                                Strats = new[] {
                                    new Strat { Requires = null /*["Gravity"]*/ },
                                },
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Colosseum - Green Lock",
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
                        From = "SM - Colosseum - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Colosseum - Top Right Door", new[] {
                                // While that one walljump near the end is a bit precise, it does
                                // not require a delayed walljump and so it is not considered a
                                // trickyWalljump.
                                new Strat { Requires = null /*["Gravity"]*/ },
                                // No water involved here, so no need for Gravity or
                                // canSuitlessMaridia.
                                new Strat { Requires = null /*["SpaceJump"]*/ },
                                new Strat {
                                    Name = "Shinespark",
                                    Requires = null,
                                    //{"canComeInCharged": {
                                    //  "fromNode": 1,
                                    //  "framesRemaining": 60,
                                    //  "shinesparkFrames": 125
                                    //}}
                                },
                                new Strat {
                                    Name = "Suitless Colosseum Grapple (Left to Right)",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "Grapple"
                                    //]
                                },
                                new Strat {
                                    Name = "Colosseum Mochtroid Climb (Left to Right)",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "canSandMochtroidClimb"
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Colosseum - Bottom Right Door",
                        To = new[] {
                            new LinkTarget("SM - Colosseum - Top Right Door", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                new Strat {
                                    Name = "Mochtroid Climb",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "canMochtroidClimb"
                                    //]
                                },
                                new Strat {
                                    Name = "Suitless Grapple",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "Grapple"
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Colosseum - Top Right Door",
                        To = new[] {
                            new LinkTarget("SM - Colosseum - Left Door", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                // No water involved here, so no need for Gravity or
                                // canSuitlessMaridia.
                                new Strat { Requires = null /*["SpaceJump"]*/ },
                                new Strat {
                                    Name = "Shinespark",
                                    Requires = null,
                                    //{"canComeInCharged": {
                                    //  "fromNode": 3,
                                    //  "framesRemaining": 60,
                                    //  "shinesparkFrames": 125
                                    //}}
                                },
                                new Strat {
                                    Name = "Suitless Colosseum Grapple (Right to Left)",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "Grapple"
                                    //]
                                },
                                new Strat {
                                    Name = "Colosseum Mochtroid Climb (Right to Left)",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "canSandMochtroidClimb"
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Colosseum - Bottom Right Door", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                new Strat {
                                    Name = "Suitless",
                                    Requires = null, /*["canSuitlessMaridia"]*/
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Colosseum - Mochtroids",
                        EnemyName = "Mochtroid",
                        Quantity = 8,
                        BetweenNodes = new[] {
                            "SM - Colosseum - Left Door",
                            "SM - Colosseum - Top Right Door",
                        },
                    },
                },
            },
            #endregion
            #region Maridia Pink Save Room B
            new Room {
                Name = "SM - Maridia Pink Save Room B",
                Layout = Room.LayoutFrom(@"
                      1→X←2"
                    , "SM - Maridia Pink Save Room B - Left Door"
                    , "SM - Maridia Pink Save Room B - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Maridia Pink Save Room B - Left Door",
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
                        Name = "SM - Maridia Pink Save Room B - Right Door",
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
                        Name = "SM - Maridia Pink Save Room B - Save Station",
                        Type = UtilityType.Save,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Maridia Pink Save Room B - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Maridia Pink Save Room B - Save Station"),
                        },
                    },
                    new Link {
                        From = "SM - Maridia Pink Save Room B - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Maridia Pink Save Room B - Save Station"),
                        },
                    },
                    new Link {
                        From = "SM - Maridia Pink Save Room B - Save Station",
                        To = new[] {
                            new LinkTarget("SM - Maridia Pink Save Room B - Left Door"),
                            new LinkTarget("SM - Maridia Pink Save Room B - Right Door"),
                        },
                    },
                },
            },
            #endregion
            #region Maridia Energy Refill Room
            new Room {
                Name = "SM - Maridia Energy Refill Room",
                Layout = Room.LayoutFrom(@"
                      1→X"
                    , "SM - Maridia Energy Refill Room - Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Maridia Energy Refill Room - Door",
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
                        Name = "SM - Maridia Energy Refill Room - Energy Refill",
                        Type = UtilityType.Energy,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Maridia Energy Refill Room - Door",
                        To = new[] {
                            new LinkTarget("SM - Maridia Energy Refill Room - Energy Refill"),
                        },
                    },
                    new Link {
                        From = "SM - Maridia Energy Refill Room - Energy Refill",
                        To = new[] {
                            new LinkTarget("SM - Maridia Energy Refill Room - Door"),
                        },
                    },
                },
            },
            #endregion
            #region The Precious Room
            new Room {
                Name = "SM - The Precious Room",
                Layout = Room.LayoutFrom(@"
                      2→XX
                        X
                      1→X"
                    , "SM - The Precious Room - Bottom Left Door"
                    , "SM - The Precious Room - Top Left Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - The Precious Room - Bottom Left Door",
                        Type = TransitionType.Gedora,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 12,
                                OpenEnd = 0,
                                Strats = new[] {
                                    new Strat { Requires = null /*["Gravity"]*/ },
                                },
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - The Precious Room - Eye Lock",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenEyeDoors"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - The Precious Room - Top Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 2,
                                OpenEnd = 1,
                                Strats = new[] {
                                    new Strat { Requires = null /*["Gravity"]*/ },
                                },
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - The Precious Room - Item",
                        Type = PlacementType.Hidden,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - The Precious Room - Top Left Door",
                        To = new[] {
                            new LinkTarget("SM - The Precious Room - Bottom Left Door"),
                            // Since this involves water and failure involves more water, it won't be
                            // expected without gravity suit unless suitless is expected.
                            new LinkTarget("SM - The Precious Room - Item", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                new Strat {
                                    Name = "Suitless",
                                    Requires = null /*["canSuitlessMaridia"]*/
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - The Precious Room - Bottom Left Door",
                        To = new[] {
                            new LinkTarget("SM - The Precious Room - Top Left Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "Gravity",
                                    //  {"or": [
                                    //    "canGravityJump",
                                    //    "h_canFly",
                                    //    "canSpringBallJumpMidAir",
                                    //    "HiJump"
                                    //  ]}
                                    //]
                                },
                                new Strat {
                                    Name = "Precious Room Delayed Walljump",
                                    Notable = true,
                                    Requires = null,
                                    //[ "Gravity",
                                    //  "canDelayedWalljump"
                                    //]
                                },
                                new Strat {
                                    Name = "Suited Shinespark",
                                    Requires = null,
                                    //[ "Gravity",
                                    //  {"canComeInCharged": {
                                    //    "fromNode": 2,
                                    //    "framesRemaining": 40,
                                    //    "shinesparkFrames": 40
                                    //  }}
                                    //]
                                },
                                // It takes a bit more time to set up the spark when suitless.
                                new Strat {
                                    Name = "Suitless Shinespark",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  {"canComeInCharged": {
                                    //    "fromNode": 2,
                                    //    "framesRemaining": 60,
                                    //    "shinesparkFrames": 40
                                    //  }}
                                    //]
                                },
                                new Strat {
                                    Name = "Precious Room X-Ray Climb",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateUnderwater",
                                    //  "canRightFacingDoorXRayClimb",
                                    //  {"resetRoom":{
                                    //    "nodes": [2],
                                    //    "mustStayPut": true
                                    //  }}
                                    //]
                                },
                                new Strat {
                                    Name = "Suitless Jump Assist",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "HiJump",
                                    //  "canSpringBallJumpMidAir"
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - The Precious Room - Item",
                        To = new[] {
                            // Since this involves water and failure involves more water, it
                            // shouldn't be expected without gravity suit unless suitless is
                            // expected.
                            new LinkTarget("SM - The Precious Room - Top Left Door", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                new Strat {
                                    Name = "Suitless",
                                    Requires = null, // ["canSuitlessMaridia"]
                                },
                            }),
                        },
                    },
                },
            },
            #endregion
            #region Draygon's Room
            new Room {
                Name = "SM - Draygon's Room",
                Layout = Room.LayoutFrom(@"
                        XX←2
                      1→XX"
                    , "SM - Draygon's Room - Left Door"
                    , "SM - Draygon's Room - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Draygon's Room - Left Door",
                        Type = TransitionType.Gray,
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
                        CanLeaveCharged = new[] {
                            new RunwayCharge {
                                Length = 22,
                                FramesRemaining = 80,
                                OpenEnd = 0,
                                Strats = new[] {
                                    new Strat { Requires = null /*["Gravity"]*/ },
                                },
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Draygon's Room - Left Grey Lock",
                                Type = LockType.GameFlag,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["f_DefeatedDraygon"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Draygon's Room - Right Door",
                        Type = TransitionType.Gray,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 5,
                                OpenEnd = 1,
                                Strats = new[] {
                                    new Strat { Requires = null /*["Gravity"]*/ },
                                },
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Draygon's Room - Right Grey Lock",
                                Type = LockType.GameFlag,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["f_DefeatedDraygon"]*/ },
                                },
                            },
                        },
                    },
                    new Event {
                        Name = "SM - Draygon's Room - Draygon",
                        Type = EventType.Boss,
                        Locks = new[] {
                            new Lock {
                                Name = "Draygon Fight",
                                Type = LockType.BossFight,
                                UnlockStrats = new[] {
                                    // Kill Draygon by grappling to the top left turret. Number of
                                    // Draygon hits seems to vary, taking a worst case guess at 5.
                                    new Strat {
                                        Name = "Draygon Grapple Kill (Suited)",
                                        Notable = true,
                                        Requires = null,
                                        //[ "Gravity",
                                        //  "Grapple",
                                        //  {"draygonElectricityFrames": 240},
                                        //  {"enemyDamage": {
                                        //    "enemy": "Draygon",
                                        //    "type": "contact",
                                        //    "hits": 5
                                        //  }}
                                        //]
                                    },
                                    // Kill Draygon by grappling to the top left turret. Number of
                                    // Draygon hits seems to vary, taking a worst case guess at 5.
                                    new Strat {
                                        Name = "Draygon Grapple Kill (Suitless)",
                                        Notable = true,
                                        Requires = null,
                                        //[ "canSuitlessMaridia",
                                        //  "Grapple",
                                        //  {"draygonElectricityFrames": 240},
                                        //  {"enemyDamage": {
                                        //    "enemy": "Draygon",
                                        //    "type": "contact",
                                        //    "hits": 5
                                        //  }}
                                        //]
                                    },
                                    // Kill Draygon by grappling to a bottom turret as you get
                                    // grabbed. Avoids taking all the hits from Draygon.
                                    new Strat {
                                        Name = "Draygon Grapple Quick Kill (Suited)",
                                        Notable = true,
                                        Requires = null,
                                        //[ "Gravity",
                                        //  "Grapple",
                                        //  "h_canBreakOneDraygonTurret",
                                        //  { "draygonElectricityFrames": 240}
                                        //]
                                    },
                                    // Kill Draygon by grappling to a bottom turret as you get
                                    // grabbed. Avoids taking all the hits from Draygon.
                                    new Strat {
                                        Name = "Draygon Grapple Quick Kill (Suitless)",
                                        Notable = true,
                                        Requires = null,
                                        //[ "canSuitlessMaridia",
                                        //  "Grapple",
                                        //  "h_canBreakOneDraygonTurret",
                                        //  { "draygonElectricityFrames": 240}
                                        //]
                                    },
                                    // 150 frames is an approximate sum of all required shinesparks.
                                    new Strat {
                                        Name = "Draygon Shinespark Kill",
                                        Notable = true,
                                        Requires = null,
                                        //[ "Gravity",
                                        //  {"canShineCharge": {
                                        //    "usedTiles": 22,
                                        //    "shinesparkFrames": 150,
                                        //    "openEnd": 0
                                        //  }}
                                        //]
                                    },
                                    new Strat {
                                        Name = "Gravity Draygon",
                                        Notable = false,
                                        Requires = null,
                                        //[ "Gravity",
                                        //  {"enemyKill": {
                                        //    "enemies": [
                                        //      ["Draygon"]
                                        //    ],
                                        //    "farmableAmmo": ["Missile", "Super"]
                                        //  }}
                                        //]
                                    },
                                    new Strat {
                                        Name = "Suitless Draygon",
                                        Notable = true,
                                        Requires = null,
                                        //[ "canSuitlessMaridia",
                                        //  "Morph",
                                        //  "h_canBreakThreeDraygonTurrets",
                                        //  {"enemyKill": {
                                        //    "enemies": [
                                        //      ["Draygon"]
                                        //    ],
                                        //    "farmableAmmo": ["Missile", "Super"]
                                        //  }}
                                        //]
                                    },
                                },
                            },
                        },
                        Yields = new[] { "f_DefeatedDraygon" },
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Draygon's Room - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Draygon's Room - Draygon"),
                        },
                    },
                    new Link {
                        From = "SM - Draygon's Room - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Draygon's Room - Draygon"),
                        },
                    },
                    new Link {
                        From = "SM - Draygon's Room - Draygon",
                        To = new[] {
                            new LinkTarget("SM - Draygon's Room - Left Door"),
                            new LinkTarget("SM - Draygon's Room - Right Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "Gravity",
                                    //  {"or":[
                                    //    "canGravityJump",
                                    //    "h_canFly",
                                    //    {"and": [
                                    //      "HiJump",
                                    //      "canSpringBallJumpMidAir"
                                    //    ]}
                                    //  ]}
                                    //]
                                },
                                new Strat {
                                    Name = "Speedjump",
                                    Requires = null,
                                    //[ "Gravity",
                                    //  "HiJump",
                                    //  "SpeedBooster"
                                    //]
                                },
                                // There is a very precise speed where the hjless speedjump is
                                // doable.
                                new Strat {
                                    Name = "Draygon HiJumpless Speedjump",
                                    Notable = true,
                                    Requires = null,
                                    //[ "Gravity",
                                    //  "canTrickyDashJump"
                                    //]
                                },
                                new Strat {
                                    Name = "Suited Shinespark",
                                    Requires = null,
                                    //[ "Gravity",
                                    //  {"canComeInCharged": {
                                    //    "fromNode": 1,
                                    //    "inRoomPath": [1, 3],
                                    //    "framesRemaining": 50,
                                    //    "shinesparkFrames": 25
                                    //  }}
                                    //]
                                },
                                new Strat {
                                    Name = "Draygon Springwall",
                                    Notable = true,
                                    Requires = null,
                                    //[ "Gravity",
                                    //  "canSpringwall"
                                    //]
                                },
                                new Strat {
                                    Name = "Short Charge",
                                    Requires = null,
                                    //[ "Gravity",
                                    //  {"canShineCharge": {
                                    //    "usedTiles": 22,
                                    //    "shinesparkFrames": 30,
                                    //    "openEnd": 1
                                    //  }}
                                    //]
                                },
                                // Takes more time to setupd than suited. but you can spark from a
                                // bit farther out because of the water physics.
                                new Strat {
                                    Name = "Suitless shinespark",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  {"canComeInCharged": {
                                    //    "fromNode": 1,
                                    //    "inRoomPath": [1, 3],
                                    //    "framesRemaining": 90,
                                    //    "shinesparkFrames": 25
                                    //  }}
                                    //]
                                },
                                new Strat {
                                    Name = "Draygon Grapple Jump",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "canDraygonGrappleJump",
                                    //  "h_canBreakOneDraygonTurret"
                                    //]
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "Draygon",
                        EnemyName = "Draygon",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Draygon's Room - Draygon" },
                        StopSpawn = null, // ["f_DefeatedDraygon"]
                    },
                },
            },
            #endregion
            // Todo: Acceptable name?
            #region Maridia Chozo Room
            new Room {
                Name = "SM - Maridia Chozo Room",
                Layout = Room.LayoutFrom(@"
                      X←1"
                    , "SM - Maridia Chozo Room - Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Maridia Chozo Room - Door",
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
                    new Placement {
                        Name = "SM - Maridia Chozo Room - Item",
                        Type = PlacementType.Chozo,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Maridia Chozo Room - Door",
                        To = new[] {
                            new LinkTarget("SM - Maridia Chozo Room - Item"),
                        },
                    },
                    new Link {
                        From = "SM - Maridia Chozo Room - Item",
                        To = new[] {
                            new LinkTarget("SM - Maridia Chozo Room - Door"),
                        },
                    },
                },
            },
            #endregion
            // Todo: Better name?
            #region West Cactus Alley Room
            new Room {
                Name = "SM - West Cactus Alley Room",
                Layout = Room.LayoutFrom(@"
                        X←2
                      1→X"
                    , "SM - West Cactus Alley Room - Left Door"
                    , "SM - West Cactus Alley Room - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - West Cactus Alley Room - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 2,
                                OpenEnd = 1,
                                UsableComingIn = false,
                                Strats = new[] {
                                    new Strat { Requires = null /*["Gravity"]*/ }
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - West Cactus Alley Room - Right Door",
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
                        From = "SM - West Cactus Alley Room - Left Door",
                        To = new[] {
                            new LinkTarget("SM - West Cactus Alley Room - Right Door", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                new Strat {
                                    Name = "Suitless Dual Jump Assist",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "HiJump",
                                    //  "canSpringBallJumpMidAir"
                                    //]
                                },
                                new Strat {
                                    Name = "Suitless HiJump Frozen Cacatac",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "canUseFrozenEnemies",
                                    //  "HiJump"
                                    //]
                                },
                                new Strat {
                                    Name = "Suitless SpringBall Frozen Cacatac",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "canUseFrozenEnemies",
                                    //  "canSpringBallJumpMidAir"
                                    //]
                                },
                                new Strat {
                                    Name = "West Cactus Alley X-Ray Climb",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
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
                        From = "SM - West Cactus Alley Room - Right Door",
                        To = new[] {
                            new LinkTarget("SM - West Cactus Alley Room - Left Door"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - West Cactus Alley Room - Top Cacatacs",
                        EnemyName = "Cacatac",
                        Quantity = 2,
                        HomeNodes = new[] { "SM - West Cactus Alley Room - Right Door" },
                    },
                    new Enemy {
                        GroupName = "SM - West Cactus Alley Room - Bottom Cacatac",
                        EnemyName = "Cacatac",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - West Cactus Alley Room - Left Door" },
                    },
                    new Enemy {
                        GroupName = "SM - West Cactus Alley Room - Middle Cacatac",
                        EnemyName = "Cacatac",
                        Quantity = 1,
                        BetweenNodes = new[] {
                            "SM - West Cactus Alley Room - Left Door",
                            "SM - West Cactus Alley Room - Right Door",
                        },
                    }
                },
            },
            #endregion
            // Todo: Better name?
            #region East Cactus Alley Room
            new Room {
                Name = "SM - East Cactus Alley Room",
                Layout = Room.LayoutFrom(@"
                      1→XXXXX
                        XXXXX←2"
                    , "SM - East Cactus Alley Room - Left Door"
                    , "SM - East Cactus Alley Room - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - East Cactus Alley Room - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 4,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - East Cactus Alley Room - Right Door",
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
                    new Junction {
                        Name = "SM - East Cactus Alley Room - Bottom Left Junction",
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - East Cactus Alley Room - Left Door",
                        To = new[] {
                            // Doesn't require anything, but getting out does.
                            new LinkTarget("SM - East Cactus Alley Room - Bottom Left Junction"),
                        },
                    },
                    new Link {
                        From = "SM - East Cactus Alley Room - Right Door",
                        To = new[] {
                            new LinkTarget("SM - East Cactus Alley Room - Bottom Left Junction", new[] {
                                // There is a way to avoid taking damage through the room, even
                                // without mid-air unmorphing.
                                new Strat {
                                    Requires = null,
                                    //[ "Gravity",
                                    //  "Morph"
                                    //]
                                },
                                // There is a way to avoid taking damage through the room, even
                                // without mid-air unmorphing.
                                new Strat {
                                    Name = "Suitless",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  {"or":[
                                    //    "HiJump",
                                    //    "canSpringBallJumpMidAir"
                                    //  ]},
                                    //  {"canComeInCharged": {
                                    //    "fromNode": 2,
                                    //    "framesRemaining": 20,
                                    //    "shinesparkFrames": 20
                                    //  }}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - East Cactus Alley Room - Bottom Left Junction",
                        To = new[] {
                            new LinkTarget("SM - East Cactus Alley Room - Left Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "Gravity",
                                    //  "SpaceJump"
                                    //]
                                },
                                // HiJump also makes it possible to escape the water suitless.
                                new Strat {
                                    Name = "HiJump Walljump",
                                    Requires = null,
                                    //[ "h_canNavigateUnderwater",
                                    //  "HiJump"
                                    //]
                                },
                                new Strat {
                                    Name = "East Cactus Hjless Walljump",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canPreciseWalljump",
                                    //  "Gravity"
                                    //]
                                },
                                // Requires only Gravity because suitless requires HiJump anyway.
                                new Strat {
                                    Name = "East Cactus Springwall",
                                    Notable = true,
                                    Requires = null,
                                    //[ "Gravity",
                                    //  "canSpringwall"
                                    //]
                                },
                            }),
                            new LinkTarget("SM - East Cactus Alley Room - Right Door", new[] {
                                // This requires taking off Gravity to do a mid-air morph. There is
                                // a way to get across without taking any damage from spikes or
                                // Cacatacs, although it's a bit tricky.
                                new Strat {
                                    Requires = null,
                                    //[ "Gravity",
                                    //  "Morph"
                                    //]
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - East Cactus Alley Room - Left Cacatac",
                        EnemyName = "Cacatac",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - East Cactus Alley Room - Bottom Left Junction" },
                    },
                    new Enemy {
                        GroupName = "SM - East Cactus Alley Room - Right Cacatacs",
                        EnemyName = "Cacatac",
                        Quantity = 3,
                        BetweenNodes = new[] {
                            "SM - East Cactus Alley Room - Right Door",
                            "SM - East Cactus Alley Room - Bottom Left Junction",
                        },
                    },
                },
            },
            #endregion
            // Todo: Acceptable name?
            #region Twin Quicksand Room
            new Room {
                Name = "SM - Twin Quicksand Room",
                Layout = Room.LayoutFrom(@"
                      12
                      ↓↓
                      XX
                      ↑↑
                      43"
                    , "SM - Twin Quicksand Room - Top Left Sand Entrance"
                    , "SM - Twin Quicksand Room - Top Right Sand Entrance"
                    , "SM - Twin Quicksand Room - Bottom Right Sand Exit"
                    , "SM - Twin Quicksand Room - Bottom Left Sand Exit"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Twin Quicksand Room - Top Left Sand Entrance",
                        Type = TransitionType.Sandpit,
                        Direction = TransitionDirection.Enter,
                    },
                    new Transition {
                        Name = "SM - Twin Quicksand Room - Top Right Sand Entrance",
                        Type = TransitionType.Sandpit,
                        Direction = TransitionDirection.Enter,
                    },
                    new Transition {
                        Name = "SM - Twin Quicksand Room - Bottom Right Sand Exit",
                        Type = TransitionType.Sandpit,
                        Direction = TransitionDirection.Exit,
                    },
                    new Transition {
                        Name = "SM - Twin Quicksand Room - Bottom Left Sand Exit",
                        Type = TransitionType.Sandpit,
                        Direction = TransitionDirection.Exit,
                    },
                    new Junction {
                        Name = "SM - Twin Quicksand Room - Central Junction",
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Twin Quicksand Room - Top Left Sand Entrance",
                        To = new[] {
                            new LinkTarget("SM - Twin Quicksand Room - Bottom Left Sand Exit"),
                            new LinkTarget("SM - Twin Quicksand Room - Central Junction", new[] {
                                new Strat { Requires = null /*["Morph"]*/ },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Twin Quicksand Room - Top Right Sand Entrance",
                        To = new[] {
                            new LinkTarget("SM - Twin Quicksand Room - Bottom Right Sand Exit"),
                            new LinkTarget("SM - Twin Quicksand Room - Central Junction", new[] {
                                new Strat { Requires = null /*["Morph"]*/ },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Twin Quicksand Room - Central Junction",
                        To = new[] {
                            new LinkTarget("SM - Twin Quicksand Room - Bottom Left Sand Exit", new[] {
                                new Strat { Requires = null /*["Morph"]*/ },
                            }),
                            new LinkTarget("SM - Twin Quicksand Room - Bottom Right Sand Exit", new[] {
                                new Strat { Requires = null /*["Morph"]*/ },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Twin Quicksand Room - Bulls",
                        EnemyName = "Bull",
                        Quantity = 9,
                        HomeNodes = new[] {
                            "SM - Twin Quicksand Room - Bottom Left Sand Exit",
                            "SM - Twin Quicksand Room - Bottom Right Sand Exit",
                        },
                    },
                },
            },
            #endregion
            // Todo: Acceptable name?
            #region Back Alley Sand Hall
            new Room {
                Name = "SM - Back Alley Sand Hall",
                Layout = Room.LayoutFrom(@"
                          23
                          ↓↓
                      1→XXXX"
                    , "SM - Back Alley Sand Hall - Door"
                    , "SM - Back Alley Sand Hall - Left Sand Entrance"
                    , "SM - Back Alley Sand Hall - Right Sand Entrance"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Back Alley Sand Hall - Door",
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
                        CanLeaveCharged = new[] {
                            new RunwayCharge {
                                Length = 23,
                                FramesRemaining = 120,
                                OpenEnd = 1,
                                Strats = new[] {
                                    new Strat { Requires = null /*["Gravity"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Back Alley Sand Hall - Left Sand Entrance",
                        Type = TransitionType.Sandpit,
                        Direction = TransitionDirection.Enter,
                    },
                    new Transition {
                        Name = "SM - Back Alley Sand Hall - Right Sand Entrance",
                        Type = TransitionType.Sandpit,
                        Direction = TransitionDirection.Enter,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Back Alley Sand Hall - Door",
                        To = new[] {
                            new LinkTarget("SM - Back Alley Sand Hall - Left Sand Entrance", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                new Strat {
                                    Name = "Suitless",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "HiJump"
                                    //]
                                },
                            }),
                            // This link refers specifically to crossing on frozen enemies. Failing
                            // here will lead to a softlock.
                            new LinkTarget("SM - Back Alley Sand Hall - Right Sand Entrance", new[] {
                                new Strat {
                                    Name = "Suitless Frozen Zoa",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "canUseFrozenEnemies"
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Back Alley Sand Hall - Left Sand Entrance",
                        To = new[] {
                            new LinkTarget("SM - Back Alley Sand Hall - Door", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                new Strat {
                                    Name = "Suitless",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "HiJump"
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Back Alley Sand Hall - Right Sand Entrance", new[] {
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
                        From = "SM - Back Alley Sand Hall - Right Sand Entrance",
                        To = new[] {
                            // This link refers specifically to crossing on frozen enemies. Failing
                            // here will lead to a softlock.
                            new LinkTarget("SM - Back Alley Sand Hall - Door", new[] {
                                new Strat {
                                    Name = "Suitless Frozen Zoa",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "canUseFrozenEnemies"
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Back Alley Sand Hall - Left Sand Entrance", new[] {
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
                        GroupName = "Below Botwoon E-Tank Left Zoas",
                        EnemyName = "Zoa",
                        Quantity = 3,
                        HomeNodes = new[] { "SM - Back Alley Sand Hall - Door" },
                        FarmCycles = new[] {
                            // Doable without getting in the sand here.
                            new FarmCycle {
                                Name = "Zoa Power Beam spam",
                                CycleFrames = 150,
                            },
                        },
                    },
                    new Enemy {
                        GroupName = "Below Botwoon E-Tank Middle Zoa",
                        EnemyName = "Zoa",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Back Alley Sand Hall - Left Sand Entrance" },
                        FarmCycles = new[] {
                            // Doable without getting in the sand here, as long as you can reach
                            // the node.
                            new FarmCycle {
                                Name = "Zoa Power Beam spam",
                                CycleFrames = 150,
                            },
                        },
                    },
                    new Enemy {
                        GroupName = "Below Botwoon E-Tank Right Zoa",
                        EnemyName = "Zoa",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Back Alley Sand Hall - Right Sand Entrance" },
                        FarmCycles = new[] {
                            // Doable without getting in the sand here, as long as you can reach
                            // the node.
                            new FarmCycle {
                                Name = "Zoa Power Beam spam",
                                CycleFrames = 150,
                            },
                        },
                    },
                    new Enemy {
                        GroupName = "Below Botwoon E-Tank Owtch",
                        EnemyName = "Owtch",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Back Alley Sand Hall - Door" },
                    },
                },
            },
            #endregion
            #region Quicksand Room A
            new Room {
                Name = "SM - Quicksand Room A",
                Layout = Room.LayoutFrom(@"
                      1
                      ↓
                      X
                      X
                      ↑
                      2"
                    , "SM - Quicksand Room A - Top Sand Entrance"
                    , "SM - Quicksand Room A - Bottom Sand Exit"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Quicksand Room A - Top Sand Entrance",
                        Type = TransitionType.Sandpit,
                        Direction = TransitionDirection.Enter,
                    },
                    new Transition {
                        Name = "SM - Quicksand Room A - Bottom Sand Exit",
                        Type = TransitionType.Sandpit,
                        Direction = TransitionDirection.Exit,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Quicksand Room A - Top Sand Entrance",
                        To = new[] {
                            new LinkTarget("SM - Quicksand Room A - Bottom Sand Exit"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Quicksand Room A - Bulls",
                        EnemyName = "Bull",
                        Quantity = 7,
                        HomeNodes = new[] {
                            "SM - Quicksand Room A - Top Sand Entrance",
                            "SM - Quicksand Room A - Bottom Sand Exit",
                        },
                    },
                },
            },
            #endregion
            #region Quicksand Room B
            new Room {
                Name = "SM - Quicksand Room B",
                    Layout = Room.LayoutFrom(@"
                      1
                      ↓
                      X
                      X
                      ↑
                      2"
                    , "SM - Quicksand Room B - Top Sand Entrance"
                    , "SM - Quicksand Room B - Bottom Sand Exit"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Quicksand Room B - Top Sand Entrance",
                        Type = TransitionType.Sandpit,
                        Direction = TransitionDirection.Enter,
                    },
                    new Transition {
                        Name = "SM - Quicksand Room B - Bottom Sand Exit",
                        Type = TransitionType.Sandpit,
                        Direction = TransitionDirection.Exit,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Quicksand Room B - Top Sand Entrance",
                        To = new[] {
                            new LinkTarget("SM - Quicksand Room B - Bottom Sand Exit"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "East Aqueduct Quicksand Bulls",
                        EnemyName = "Bull",
                        Quantity = 6,
                        HomeNodes = new[] {
                            "SM - Quicksand Room B - Top Sand Entrance",
                            "SM - Quicksand Room B - Bottom Sand Exit",
                        },
                    }
                },
            },
            #endregion
            // Todo: Better name?
            #region East Sand Hole
            new Room {
                Name  = "SM - East Sand Hole",
                Layout = Room.LayoutFrom(@"
                      1
                      ↓
                      XX
                      XX
                       ↑
                       2"
                    , "SM - East Sand Hole - Top Sand Entrance"
                    , "SM - East Sand Hole - Bottom Sand Exit"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - East Sand Hole - Top Sand Entrance",
                        Type = TransitionType.Sandpit,
                        Direction = TransitionDirection.Enter,
                    },
                    new Transition {
                        Name = "SM - East Sand Hole - Bottom Sand Exit",
                        Type = TransitionType.Sandpit,
                        Direction = TransitionDirection.Exit,
                    },
                    new Placement {
                        Name = "SM - East Sand Hole - Left Item",
                        Type = PlacementType.Visible,
                    },
                    new Placement {
                        Name = "SM - East Sand Hole - Right Item",
                        Type = PlacementType.Visible,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - East Sand Hole - Top Sand Entrance",
                        To = new[] {
                            new LinkTarget("SM - East Sand Hole - Bottom Sand Exit"),
                            new LinkTarget("SM - East Sand Hole - Left Item", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                // It's possible to get out of the sand suitless and without hjb after
                                // falling from the chute, by hugging the left side and moving quickly.
                                // However, getting across the sand chute right-to-left or left-to-right
                                // without sinking isn't possible in those conditions.
                                new Strat {
                                    Name = "Suitless",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  {"or": [
                                    //    "canSpringBallJumpMidAir",
                                    //    "HiJump"
                                    //  ]}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - East Sand Hole - Right Item", new[] {
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
                    new Link {
                        From = "SM - East Sand Hole - Bottom Sand Exit",
                        To = Empty<LinkTarget>.List,
                    },
                    new Link {
                        From = "SM - East Sand Hole - Left Item",
                        To = new[] {
                            new LinkTarget("SM - East Sand Hole - Top Sand Entrance"),
                        },
                    },
                    new Link {
                        From = "SM - East Sand Hole - Right Item",
                        To = new[] {
                            new LinkTarget("SM - East Sand Hole - Top Sand Entrance"),
                        },
                    },
                },
            },
            #endregion
            // Todo: Better name?
            #region West Sand Hole
            new Room {
                Name = "SM - West Sand Hole",
                Layout = Room.LayoutFrom(@"
                       1
                       ↓
                      XX
                      XX
                      ↑
                      2"
                    , "SM - West Sand Hole - Top Sand Entrance"
                    , "SM - West Sand Hole - Bottom Sand Exit"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - West Sand Hole - Top Sand Entrance",
                        Type = TransitionType.Sandpit,
                        Direction = TransitionDirection.Enter,
                    },
                    new Transition {
                        Name = "SM - West Sand Hole - Bottom Sand Exit",
                        Type = TransitionType.Sandpit,
                        Direction = TransitionDirection.Exit,
                    },
                    new Placement {
                        Name = "SM - West Sand Hole - Left Item",
                        Type = PlacementType.Visible,
                    },
                    new Placement {
                        Name = "SM - West Sand Hole - Right Item",
                        // Todo: incorrect?
                        Type = PlacementType.Visible,
                    },
                    // You actually have to go back to Before Maze Branch Junction to move between
                    // the left and right portions of this junction, but access both ways has the
                    // same requirements.
                    new Junction {
                        Name = "SM - West Sand Hole - After Maze Branch Junction",
                    },
                    new Junction {
                        Name = "SM - West Sand Hole - Before Maze Branch Junction",
                    },
                    new Junction {
                        Name = "SM - West Sand Hole - Next To Crumbles Junction",
                    }
                },
                Links = new[] {
                    new Link {
                        From = "SM - West Sand Hole - Top Sand Entrance",
                        To = new[] {
                            new LinkTarget("SM - West Sand Hole - Bottom Sand Exit"),
                            new LinkTarget("SM - West Sand Hole - Next To Crumbles Junction", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                new Strat {
                                    Name = "West Sand Hole Break Free",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "HiJump",
                                    //  "canBreakFree"
                                    //]
                                },
                                new Strat {
                                    Name = "West Sand Hole Space Wall Climb",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "HiJump",
                                    //  "canSunkenDualWallClimb",
                                    //  "SpaceJump"
                                    //]
                                },
                                new Strat {
                                    Name = "Suitless Dual Jump Assist",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "HiJump",
                                    //  "canSpringBallJumpMidAir"
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - West Sand Hole - Bottom Sand Exit",
                        To = Empty<LinkTarget>.List,
                    },
                    new Link {
                        From = "SM - West Sand Hole - Left Item",
                        To = new[] {
                            new LinkTarget("SM - West Sand Hole - After Maze Branch Junction", new[] {
                                new Strat {
                                    Requires = null,
                                    //{"or": [
                                    //  "h_canPassBombPassages",
                                    //  "h_canUseSpringBall"
                                    //]}
                                },
                                new Strat {
                                    Name = "MidAir Morph",
                                    Requires = null, // ["can2HighWallMidAirMorph"]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - West Sand Hole - Right Item",
                        To = new[] {
                            new LinkTarget("SM - West Sand Hole - After Maze Branch Junction", new[] {
                                new Strat { Requires = null /*["Morph"]*/ },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - West Sand Hole - Before Maze Branch Junction",
                        To = new[] {
                            new LinkTarget("SM - West Sand Hole - After Maze Branch Junction", new[] {
                                new Strat { Requires = null /*["h_canUseSpringBall"]*/ },
                                new Strat { Requires = null /*["canIBJ"]*/ },
                                new Strat {
                                    Name = "West Sand Hole MidAir Morph",
                                    Notable = true,
                                    Requires = null, // ["can3HighMidAirMorph"]
                                },
                            }),
                            new LinkTarget("SM - West Sand Hole - Next To Crumbles Junction", new[] {
                                new Strat { Requires = null /*["Morph"]*/ },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - West Sand Hole - After Maze Branch Junction",
                        To = new[] {
                            new LinkTarget("SM - West Sand Hole - Left Item", new[] {
                                new Strat {
                                    Requires = null,
                                    //{"or": [
                                    //  "h_canPassBombPassages",
                                    //  "h_canUseSpringBall"
                                    //]}
                                },
                                new Strat {
                                    Name = "MidAir Morph",
                                    Requires = null, // ["can2HighWallMidAirMorph"]
                                },
                            }),
                            new LinkTarget("SM - West Sand Hole - Right Item", new[] {
                                new Strat {
                                    Requires = null,
                                    //{"or": [
                                    //  "h_canPassBombPassages",
                                    //  "h_canUseSpringBall"
                                    //]}
                                },
                                new Strat {
                                    Name = "Turnaround Aim Cancel",
                                    Requires = null, // ["canTurnaroundAimCancel"]
                                },
                            }),
                            new LinkTarget("SM - West Sand Hole - Before Maze Branch Junction", new[] {
                                new Strat { Requires = null /*["Morph"]*/ },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - West Sand Hole - Next To Crumbles Junction",
                        To = new[] {
                            new LinkTarget("SM - West Sand Hole - Top Sand Entrance", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                new Strat {
                                    Name = "Suitless Way Back",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "HiJump"
                                    //]
                                },
                                new Strat {
                                    Name = "Suitless Crumble Blocks",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "Morph"
                                    //]
                                },
                            }),
                            new LinkTarget("SM - West Sand Hole - Before Maze Branch Junction", new[] {
                                // Mid-air morph off the left wall.
                                new Strat {
                                    Name = "Left Sand Pit Initial MidAir Morph",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canWalljump",
                                    //  "Morph",
                                    //  {"or": [
                                    //    "Gravity",
                                    //    {"and": [
                                    //      "canSuitlessMaridia",
                                    //      "HiJump"
                                    //    ]}
                                    //  ]}
                                    //]
                                },
                                // Breaking free of the water here requires SpaceJump if HiJump
                                // isn't available.
                                new Strat {
                                    Name = "Left Sand Pit Initial MidAir Morph (Bootless Suitless)",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canWalljump",
                                    //  "Morph",
                                    //  "canSuitlessMaridia",
                                    //  "SpaceJump"
                                    //]
                                },
                                // This is just an easier alternative to the notable strats.
                                new Strat {
                                    Name = "Spring Ball",
                                    Requires = null,
                                    //[ "h_canUseSpringBall",
                                    //  "HiJump"
                                    //]
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "West Sand Hole Boulders",
                        EnemyName = "Boulder",
                        Quantity = 2,
                        HomeNodes = new[] { "SM - West Sand Hole - Next To Crumbles Junction" },
                    }
                },
            },
            #endregion
            // Todo: Toilet Bowl is in Inner Pink. Needed? If so, is this area the best of it?
        };

    }

}
