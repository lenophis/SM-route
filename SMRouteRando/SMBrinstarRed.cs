using System.Collections.Generic;

namespace SMRouteRando {

    public class SMBrinstarRed {

        public static IList<Room> Rooms { get; } = new[] {
            #region Red Tower
            new Room {
                Name = "SM - Red Tower",
                Layout = Room.LayoutFrom(@"
                        X←4
                        X
                        X
                        X
                      3→X
                        X
                      2→X
                        X
                        X
                      1→X←5"
                    , "SM - Red Tower - Bottom Left Door"
                    , "SM - Red Tower - Middle Left Door"
                    , "SM - Red Tower - Top Left Door"
                    , "SM - Red Tower - Top Right Door"
                    , "SM - Red Tower - Bottom Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Red Tower - Bottom Left Door",
                        Type = TransitionType.Green,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 12,
                                OpenEnd = 0,
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenGreenDoors"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Red Tower - Middle Left Door",
                        Type = TransitionType.Yellow,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 2,
                                OpenEnd = 0,
                                UsableComingIn = false,
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Red Tower - Yellow Lock",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenYellowDoors"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Red Tower - Top Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 10,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Red Tower - Top Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 12,
                                OpenEnd = 0,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Red Tower - Bottom Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 12,
                                OpenEnd = 0,
                            },
                        },
                    },
                    // This is meant to contain all Rippers in the top climb except the bottom one.
                    new Junction {
                        Name = "SM - Red Tower - Top Climb Junction",
                    },
                    // This is under the orange door, below the shot blocks, but above the bottom climb.
                    new Junction {
                        Name = "SM - Red Tower - Bottom Climb Top Junction",
                    },
                    // This is meant to contain all Rippers in the bottom climb except the bottom one.
                    new Junction {
                        Name = "SM - Red Tower - Bottom Climb Middle Junction",
                    },
                    new Junction {
                        Name = "SM - Red Tower - Bottom Climb Bottom Junction",
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Red Tower - Top Left Door",
                        To = new[] {
                            new LinkTarget("SM - Red Tower - Middle Left Door", new[] {
                                new Strat { Requires = null /*["h_canUsePowerBombs"]*/ },
                            }),
                            // Direct link for shinespark. Other strats should go Top Left Door ->
                            // Top Climb Junction -> Top Right Door.
                            new LinkTarget("SM - Red Tower - Top Right Door", new[] {
                                // 1- Come in charged from node 1.
                                // 2- Select Missiles, position Samus roughly in the horizontal center
                                //    of the room.
                                // 3- Crouch and aim up.
                                // 4- In very quick succession, shoot a missile upwards then spark up.
                                // If done right, Samus will pass the Missile, break the bomb blocks,
                                // then be passed by the Missile which will break the shot blocks at
                                // the top
                                new Strat {
                                    Name = "Red Tower Spark",
                                    Notable = true,
                                    Requires = null,
                                    //[ {"canComeInCharged": {
                                    //    "fromNode": 1,
                                    //    "framesRemaining": 100,
                                    //    "shinesparkFrames": 77
                                    //  }},
                                    //  "Missile",
                                    //  {"ammo": {
                                    //    "type": "Missile",
                                    //    "count": 1
                                    //  }}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Red Tower - Bottom Climb Top Junction"),
                            new LinkTarget("SM - Red Tower - Top Climb Junction"),
                        },
                    },
                    new Link {
                        From  = "SM - Red Tower - Middle Left Door",
                        To = new[] {
                            new LinkTarget("SM - Red Tower - Top Left Door", new[] {
                                new Strat { Requires = null /*["h_canUsePowerBombs"]*/ },
                                new Strat {
                                    Name = "Red Tower X-Ray Climb",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canRightFacingDoorXRayClimb",
                                    //  {"resetRoom":{
                                    //    "nodes": [2],
                                    //    "mustStayPut": true
                                    //  }}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Red Tower - Bottom Left Door",
                        To = new[] {
                            new LinkTarget("SM - Red Tower - Bottom Climb Bottom Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Red Tower - Bottom Right Door",
                        To = new[] {
                            new LinkTarget("SM - Red Tower - Bottom Climb Bottom Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Red Tower - Top Right Door",
                        To = new[] {
                            new LinkTarget("SM - Red Tower - Top Climb Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Red Tower - Bottom Climb Top Junction",
                        To = new[] {
                            new LinkTarget("SM - Red Tower - Top Left Door"),
                            new LinkTarget("SM - Red Tower - Bottom Climb Middle Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Red Tower - Bottom Climb Middle Junction",
                        To = new[] {
                            new LinkTarget("SM - Red Tower - Bottom Climb Top Junction", new[] {
                                new Strat {
                                    Requires = null,
                                    //{"or":[
                                    //  "HiJump",
                                    //  "SpaceJump"
                                    //]}
                                },
                                new Strat {
                                    Name = "Use Frozen Enemies",
                                    Requires = null, // ["canUseFrozenEnemies"]
                                },
                                // Doing an IBJ without killing the Rippers may be doable, but it would
                                // have to be a harder variation of IBJ.
                                new Strat {
                                    Name = "IBJ",
                                    Requires = null,
                                    //[ "canIBJ",
                                    //  {"enemyKill":{
                                    //    "enemies": [
                                    //      [ "Ripper","Ripper","Ripper","Ripper" ]
                                    //    ]
                                    //  }}
                                    //]
                                },
                                new Strat {
                                    Name = "Red Tower Midair Spring Ball",
                                    Notable = true,
                                    Requires = null, // ["canSpringBallJumpMidAir"]
                                },
                            }),
                            new LinkTarget("SM - Red Tower - Bottom Climb Bottom Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Red Tower - Bottom Climb Bottom Junction",
                        To = new[] {
                            new LinkTarget("SM - Red Tower - Bottom Left Door"),
                            new LinkTarget("SM - Red Tower - Bottom Right Door"),
                            // This link is only for sparking. Other strats go Bottom
                            // Climb Bottom Junction -> Bottom Climb Middle Junction ->
                            // Bottom Climb Top Junction.
                            new LinkTarget("SM - Red Tower - Bottom Climb Top Junction", new[] {
                                new Strat {
                                    Name = "Shinespark",
                                    Requires = null,
                                    //{"or":[
                                    //  {"canComeInCharged": {
                                    //    "fromNode": 4,
                                    //    "inRoomPath": [4, 8],
                                    //    "framesRemaining": 30,
                                    //    "shinesparkFrames": 45
                                    //  }},
                                    //  {"canComeInCharged": {
                                    //    "fromNode": 3,
                                    //    "inRoomPath": [3, 8],
                                    //    "framesRemaining": 40,
                                    //    "shinesparkFrames": 45
                                    //  }}
                                    //]}
                                },
                            }),
                            new LinkTarget("SM - Red Tower - Bottom Climb Middle Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Red Tower - Top Climb Junction",
                        To = new[] {
                            new LinkTarget("SM - Red Tower - Top Left Door"),
                            new LinkTarget("SM - Red Tower - Top Right Door", new[] {
                                new Strat {
                                    Name = "Use Frozen Enemies",
                                    Requires = null, // ["canUseFrozenEnemies"]
                                },
                                new Strat {
                                    Name = "Red Tower Walljump Climb",
                                    Notable = true,
                                    Requires = null, // ["canPreciseWalljump"]
                                },
                                // This strat exists on the belief that only the final wall jump is
                                // tricky. The top Ripper has to be killed otherwise there's no room to
                                // leverage Space Jump as an actual advantage.
                                new Strat {
                                    Requires = null,
                                    //[ "SpaceJump",
                                    //  {"enemyKill":{
                                    //    "enemies": [
                                    //      [ "Ripper" ]
                                    //    ]
                                    //  }}
                                    //]
                                },
                                new Strat {
                                    Name = "Red Tower IBJ",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canBombAboveIBJ",
                                    //  {"enemyKill":{
                                    //    "enemies": [
                                    //      [ "Ripper", "Ripper", "Ripper", "Ripper" ]
                                    //    ]
                                    //  }}
                                    //]
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Red Tower - Geegas",
                        EnemyName = "Geega",
                        Quantity = 2,
                        HomeNodes = new[] { "SM - Red Tower - Top Left Door" },
                        FarmCycles = new[] {
                            // Standing on the platform next to the right spawner, must jump to
                            // get Geegas to spawn from the left one.
                            new FarmCycle {
                                Name = "Alternating Geega Pipes",
                                CycleFrames = 180,
                            },
                        },
                    },
                    new Enemy {
                        GroupName = "SM - Red Tower - Beetom",
                        EnemyName = "Beetom",
                        Quantity = 1,
                        BetweenNodes = new[] {
                            "SM - Red Tower - Top Left Door",
                            "SM - Red Tower - Middle Left Door",
                        },
                    },
                    new Enemy {
                        GroupName = "SM - Red Tower - Middle Rippers",
                        EnemyName = "Ripper",
                        Quantity = 3,
                        HomeNodes = new[] { "SM - Red Tower - Bottom Climb Middle Junction" },
                    },
                    new Enemy {
                        GroupName = "SM - Red Tower - Bottom Ripper",
                        EnemyName = "Ripper",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Red Tower - Bottom Climb Bottom Junction" },
                    },
                    new Enemy {
                        GroupName = "SM - Red Tower - Top rippers",
                        EnemyName = "Ripper",
                        Quantity = 4,
                        HomeNodes = new[] { "SM - Red Tower - Top Climb Junction" },
                    },
                },
            },
            #endregion
            #region Brinstar Red Fireflea Room
            new Room {
                Name = "SM - Brinstar Red Fireflea Room",
                Layout = Room.LayoutFrom(@"
                      1→XXXXXXXX←2
                        XX  XX"
                    , "SM - Brinstar Red Fireflea Room - Left Door"
                    , "SM - Brinstar Red Fireflea Room - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Brinstar Red Fireflea Room - Left Door",
                        Type = TransitionType.Red,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 5,
                                OpenEnd = 1,
                            },
                        },
                        CanLeaveCharged = new[] {
                            // Requires opening the door, then going to the middle of the room to
                            // use the really small runway. ShinesparkFrames are at 0 because the
                            // shinespark frames are accounted for in the path to door.
                            new RunwayCharge {
                                Length = 13,
                                OpenEnd = 0,
                                FramesRemaining = 0,
                                ShinesparkFrames = 0,
                                InitiateRemotely = new() {
                                    InitiateAt = "SM - Brinstar Red Fireflea Room - Right Door",
                                    MustOpenDoorFirst = true,
                                    PathToDoor = new[] {
                                        new PathStep("SM - Brinstar Red Fireflea Room - Left Door", new[] { "In-Room Shinespark" }),
                                    },
                                },
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Brinstar Red Firefleas Room - Red Lock",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenRedDoors"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Brinstar Red Fireflea Room - Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 4,
                                OpenEnd = 1,
                            },
                        },
                        CanLeaveCharged = new[] {
                            new RunwayCharge {
                                Length = 13,
                                OpenEnd = 0,
                                FramesRemaining = 0,
                                ShinesparkFrames = 50,
                            },
                        },
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Brinstar Red Fireflea Room - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Red Fireflea Room - Right Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //{"or":[
                                    //  "Grapple",
                                    //  "SpaceJump"
                                    //]}
                                },
                                new Strat {
                                    Name = "Shinespark",
                                    Requires = null,
                                    //{"canComeInCharged": {
                                    //  "fromNode": 1,
                                    //  "framesRemaining": 0,
                                    //  "shinesparkFrames": 150
                                    //}}
                                },
                                // If you wait long enough, a Waver will arrive. With one dboost off it
                                // on its way back, you can follow it across and use it for i-frames,
                                // getting through with 5 hits.
                                new Strat {
                                    Name = "X-Ray Exit Damage Boost",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canDamageBoost",
                                    //  {"enemyDamage": {
                                    //    "enemy": "Waver",
                                    //    "type": "contact",
                                    //    "hits": 5
                                    //  }}
                                    //]
                                },
                                // This strat is simply running and jumping across the spikes.
                                new Strat {
                                    Name = "X-Ray Exit Spike Floor",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canIframeSpikeJump",
                                    //  { "spikeHits": 4}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Brinstar Red Fireflea Room - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Red Fireflea Room - Left Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //{"or":[
                                    //  "SpaceJump",
                                    //  "Grapple"
                                    //]}
                                },
                                new Strat {
                                    Name = "Shinespark",
                                    Requires = null,
                                    //{"canComeInCharged": {
                                    //  "fromNode": 2,
                                    //  "framesRemaining": 0,
                                    //  "shinesparkFrames": 150
                                    //}}
                                },
                                new Strat {
                                    Name = "In-Room Shinespark",
                                    Requires = null,
                                    //{"canShineCharge": {
                                    //  "usedTiles": 13,
                                    //  "openEnd": 0,
                                    //  "shinesparkFrames": 106
                                    //}}
                                },
                                new Strat {
                                    Name = "Use Frozen Waver",
                                    Requires = null,
                                    //[ "canIframeSpikeJump",
                                    //  "canUseFrozenEnemies",
                                    //  { "spikeHits": 3}
                                    //]
                                },
                                new Strat {
                                    Name = "X-Ray Access IBJ",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canIframeSpikeJump",
                                    //  { "spikeHits": 6},
                                    //  "canIBJ"
                                    //]
                                },
                                new Strat {
                                    Name = "X-Ray Access Springwall",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canIframeSpikeJump",
                                    //  { "spikeHits": 6},
                                    //  "canSpringwall"
                                    //]
                                },
                                new Strat {
                                    Name = "X-Ray Access Speed HiJump",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canIframeSpikeJump",
                                    //  "HiJump",
                                    //  { "spikeHits": 4},
                                    //  "SpeedBooster"
                                    //]
                                },
                                new Strat {
                                    Name = "X-Ray Access MidAir Spring Ball",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canIframeSpikeJump",
                                    //  "HiJump",
                                    //  { "spikeHits": 4},
                                    //  "canSpringBallJumpMidAir"
                                    //]
                                },
                                // A precise strat that involves crossing both gaps by dboosting off
                                // Wavers. The wavers are also used for iframes to avoid taking damage
                                // from any spikes.
                                new Strat {
                                    Name = "X-Ray Access Damage Boost",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canContinuousDboost",
                                    //  {"enemyDamage": {
                                    //    "enemy": "Waver",
                                    //    "type": "contact",
                                    //    "hits": 6
                                    //  }}
                                    //]
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Red Brinstar Fireflea Room Wavers",
                        EnemyName = "Waver",
                        Quantity = 3,
                        HomeNodes = new[] {
                            "SM - Brinstar Red Fireflea Room - Left Door",
                            "SM - Brinstar Red Fireflea Room - Right Door",
                        },
                    },
                    new Enemy {
                        GroupName = "SM - Brinstar Red Fireflea Room - Left Yapping Maws",
                        EnemyName = "Yapping Maw",
                        Quantity = 2,
                        BetweenNodes = new[] {
                            "SM - Brinstar Red Fireflea Room - Left Door",
                            "SM - Brinstar Red Fireflea Room - Right Door",
                        },
                        DropRequires = null, // ["never"]
                    },
                    new Enemy {
                        GroupName = "SM - Brinstar Red Fireflea Room - Right Yapping Maw",
                        EnemyName = "Yapping Maw",
                        Quantity = 1,
                        BetweenNodes = new[] {
                            "SM - Brinstar Red Fireflea Room - Left Door",
                            "SM - Brinstar Red Fireflea Room - Right Door",
                        },
                    },
                    new Enemy {
                        GroupName = "SM - Brinstar Red Fireflea Room - Firefleas",
                        EnemyName = "Fireflea",
                        Quantity = 5,
                        HomeNodes = new[] { "SM - Brinstar Red Fireflea Room - Right Door" },
                    },
                },
            },
            #endregion
            // Todo: Acceptable name?
            #region Headspace Chozo Room
            new Room {
                Name = "SM - Headspace Chozo Room",
                Layout = Room.LayoutFrom(@"
                      XX←1"
                    , "SM - Headspace Chozo Room - Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Headspace Chozo Room - Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 7,
                                OpenEnd = 0,
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - Headspace Chozo Room - Item",
                        Type = PlacementType.Chozo,
                    },
                    // This junction is used to separate the breaking of the bomb block from
                    // escaping the room.
                    new Junction {
                        Name = "SM - Headspace Chozo Room - Escape Junction",
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Headspace Chozo Room - Door",
                        To = new[] {
                            new LinkTarget("SM - Headspace Chozo Room - Item", new[] {
                                // There are additional requirements to get back out. It's a
                                // softlock if they aren't met.
                                new Strat { Requires = null /*["Morph"]*/ },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Headspace Chozo Room - Item",
                        To = new[] {
                            // Item -> Escape Junction and Escape Junction -> Door are fully
                            // separated, because it takes two PBs to break the block and then get
                            // into the tunnel.
                            new LinkTarget("SM - Headspace Chozo Room - Escape Junction", new[] {
                                new Strat { Requires = null /*["h_canDestroyBombWalls"]*/ },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Headspace Chozo Room - Escape Junction",
                        To = new[] {
                            new LinkTarget("SM - Headspace Chozo Room - Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //{"or":[
                                    //  "h_canPassBombPassages",
                                    //  "h_canUseSpringBall"
                                    //]}
                                },
                                // Maybe a little bit harder than in West Sand Hole, since you also
                                // need to change direction.
                                new Strat {
                                    Name = "X-Ray Escape Wall Morph",
                                    Notable = true,
                                    Requires = null, // ["can2HighWallMidAirMorph"]
                                },
                                // A running mid-air mockball can squeeze into the hole with good enough timing.
                                new Strat {
                                    Name = "X-Ray Escape Running Morph",
                                    Notable = true,
                                    Requires = null, // ["canMidAirMockball"]
                                },
                            }),
                        },
                    },
                },
            },
            #endregion
            #region Bat Room
            new Room {
                Name = "SM - Bat Room",
                Layout = Room.LayoutFrom(@"
                      1→XX←2"
                    , "SM - Bat Room - Left Door"
                    , "SM - Bat Room - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Bat Room - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 0,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Bat Room - Right Door",
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
                        From = "SM - Bat Room - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Bat Room - Right Door"),
                        },
                    },
                    new Link {
                        From = "SM - Bat Room - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Bat Room - Left Door"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Bat Room - Skrees",
                        EnemyName = "Skree",
                        Quantity = 2,
                        HomeNodes = new[] { "SM - Bat Room - Right Door" },
                    }
                },
            },
            #endregion
            // Todo: Need a not item name for this one.
            #region Below Spazer
            new Room {
                Name = "SM - Below Spazer",
                Layout = Room.LayoutFrom(@"
                        XX←2
                      1→XX←3"
                    , "SM - Below Spazer - Left Door"
                    , "SM - Below Spazer - Top Right Door"
                    , "SM - Below Spazer - Bottom Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Below Spazer - Left Door",
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
                        Name = "SM - Below Spazer - Top Right Door",
                        Type = TransitionType.Green,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 4,
                                OpenEnd = 1,
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Below Spazer - Green Lock",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenGreenDoors"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Below Spazer - Bottom Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 1,
                            },
                        },
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Below Spazer - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Below Spazer - Bottom Right Door"),
                            new LinkTarget("SM - Below Spazer - Top Right Door", new[] {
                                new Strat { Requires = null /*["h_canPassBombPassages"]*/ },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Below Spazer - Bottom Right Door",
                        To = new[] {
                            new LinkTarget("SM - Below Spazer - Left Door"),
                        },
                    },
                    new Link {
                        From = "SM - Below Spazer - Top Right Door",
                        To = new[] {
                            new LinkTarget("SM - Below Spazer - Left Door", new[] {
                                new Strat { Requires = null /*["h_canPassBombPassages"]*/ },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Below Spazer - Cacatac",
                        EnemyName = "Cacatac",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Below Spazer - Bottom Right Door" },
                    },
                    // Can pickup the drops without taking damage.
                    new Enemy {
                        GroupName = "Below Spazer Yapping Maws",
                        EnemyName = "Yapping Maw",
                        Quantity = 2,
                        HomeNodes = new[] { "SM - Below Spazer - Bottom Right Door" },
                    },
                },
            },
            #endregion
            // Todo: Acceptable name?
            #region Brinstar Red Chozo Room
            new Room {
                Name = "SM - Brinstar Red Chozo Room",
                Layout = Room .LayoutFrom(@"
                      1→X"
                    , "SM - Brinstar Red Chozo Room - Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Brinstar Red Chozo Room - Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - Brinstar Red Chozo Room - Item",
                        Type = PlacementType.Chozo,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Brinstar Red Chozo Room - Door",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Red Chozo Room - Item"),
                        },
                    },
                    new Link {
                        From = "SM - Brinstar Red Chozo Room - Item",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Red Chozo Room - Door"),
                        },
                    },
                },

            },
            #endregion
            #region Hellway
            new Room {
                Name = "SM - Hellway",
                Layout = Room.LayoutFrom(@"
                      1→XXX←2"
                    , "SM - Hellway - Left Door"
                    , "SM - Hellway - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Hellway - Left Door",
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
                        Name = "SM - Hellway - Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 8,
                                OpenEnd = 1,
                            },
                        },
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Hellway - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Hellway - Right Door"),
                        },
                    },
                    new Link {
                        From = "SM - Hellway - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Hellway - Left Door"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "Hellway Left Zebbo",
                        EnemyName = "Zebbo",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Hellway - Left Door" },
                        FarmCycles = new[] {
                            new FarmCycle {
                                Name = "Crouch two tiles above spawn point",
                                CycleFrames = 130,
                            },
                        },
                    },
                    new Enemy {
                        GroupName = "Hellway Middle Zebbo",
                        EnemyName = "Zebbo",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Hellway - Left Door" },
                        FarmCycles = new[] {
                            new FarmCycle {
                                Name = "Crouch two tiles above spawn point",
                                CycleFrames = 130,
                            },
                        },
                    },
                    new Enemy {
                        GroupName = "Hellway Right Zebbos",
                        EnemyName = "Zebbo",
                        Quantity = 2,
                        HomeNodes = new[] { "SM - Hellway - Left Door" },
                        FarmCycles = new[] {
                            // Involves tiny hops to get the drops as well.
                            new FarmCycle {
                                Name = "Turnaround two tiles above spawn",
                                CycleFrames = 240,
                            },
                            new FarmCycle {
                                Name = "Grapple turnaround two tiles above spawn",
                                CycleFrames = 175,
                                Requires = null, // ["Grapple"]
                            },
                        },
                    },
                    new Enemy {
                        GroupName = "Hellway Zeelas",
                        EnemyName = "Zeela",
                        Quantity = 4,
                        HomeNodes = new[] { "SM - Hellway - Left Door" },
                    },
                },
            },
            #endregion
            #region Caterpillar Room
            new Room {
                Name = "SM - Caterpillar Room",
                Layout = Room.LayoutFrom(@"
                        4
                        ↓
                        X
                      3→XXX←5
                        X←6
                      2→X
                        X
                      1→X"
                    , "SM - Caterpillar Room - Bottom Left Door"
                    , "SM - Caterpillar Room - Middle Left Door"
                    , "SM - Caterpillar Room - Top Left Door"
                    , "SM - Caterpillar Room - Elevator"
                    , "SM - Caterpillar Room - Top Right Door"
                    , "SM - Caterpillar Room - Bottom Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Caterpillar Room - Bottom Left Door",
                        Type = TransitionType.Green,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 0,
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Caterpillar Room - Bottom Left Green Lock",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenGreenDoors"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Caterpillar Room - Middle Left Door",
                        Type = TransitionType.Yellow,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 8,
                                OpenEnd = 0,
                                Strats = new[] {
                                    // Runway not usable if the shot blocks are broken. Those
                                    // blocks are not an obstacle right now, but there's no need to
                                    // destroy them except when travelling between Middle Left Door
                                    // and Bottom Left Door.
                                    new Strat {
                                        Requires = null,
                                        //{"resetRoom":{
                                        //  "nodes": [1, 2, 4, 5, 6],
                                        //  "nodesToAvoid": [3]
                                        //}}
                                    },
                                },
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "Caterpillar Room Yellow Lock (to Hellway)",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenYellowDoors"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Caterpillar Room - Top Left Door",
                        Type = TransitionType.Green,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 4,
                                OpenEnd = 1,
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Caterpillar Room - Top Left Green Lock",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenGreenDoors"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Caterpillar Room - Elevator",
                        Type = TransitionType.Elevator,
                    },
                    new Transition {
                        Name = "SM - Caterpillar Room - Top Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 7,
                                OpenEnd = 0,
                            },
                            new RunwayDash {
                                Length = 17,
                                OpenEnd = 0,
                                UsableComingIn = false,
                                Strats = new[] {
                                    // This longer runway is only available if the green gate is open.
                                    new Strat {
                                        Obstacles = new[] {
                                            new Strat.Obstacle {
                                                Name = "Green Gate",
                                                Requires = null,
                                                //[ "Super",
                                                //  {"ammo": {
                                                //    "type": "Super",
                                                //    "count": 1
                                                //  }}
                                                //]
                                            },
                                        },
                                    },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Caterpillar Room - Bottom Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 2,
                                OpenEnd = 1,
                                UsableComingIn = false,
                            },
                        },
                    },
                    new Junction {
                        Name = "SM - Caterpillar Room - Main Junction",
                    },
                },
                Obstacles = new[] {
                    new Obstacle {
                        Name = "Green Gate",
                        Type = ObstacleType.Inanimate,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Caterpillar Room - Top Left Door",
                        To = new[] {
                            new LinkTarget("SM - Caterpillar Room - Main Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Caterpillar Room - Middle Left Door",
                        To = new[] {
                            new LinkTarget("SM - Caterpillar Room - Main Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Caterpillar Room - Bottom Left Door",
                        To = new[] {
                            new LinkTarget("SM - Caterpillar Room - Main Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Caterpillar Room - Bottom Right Door",
                        To = new[] {
                            new LinkTarget("SM - Caterpillar Room - Main Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Caterpillar Room - Top Right Door",
                        To = new[] {
                            new LinkTarget("SM - Caterpillar Room - Main Junction", new[] {
                                new Strat {
                                    Requires = null, // ["Morph"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Green Gate",
                                            Requires = null,
                                            //[ "Super",
                                            //  {"ammo": {
                                            //    "type": "Super",
                                            //    "count": 1
                                            //  }}
                                            //]
                                        },
                                    },
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Caterpillar Room - Elevator",
                        To = new[] {
                            new LinkTarget("SM - Caterpillar Room - Main Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Caterpillar Room - Main Junction",
                        To = new[] {
                            new LinkTarget("SM - Caterpillar Room - Top Left Door"),
                            new LinkTarget("SM - Caterpillar Room - Middle Left Door"),
                            new LinkTarget("SM - Caterpillar Room - Bottom Left Door"),
                            new LinkTarget("SM - Caterpillar Room - Bottom Right Door"),
                            new LinkTarget("SM - Caterpillar Room - Top Right Door", new[] {
                                // Only doable if entering the room from Top Right Door. Only
                                // worthwhile to go kill the Zeros for PBs (and/or Cacatacs for
                                // Supers) then go back out.
                                new Strat {
                                    Name = "Backtrack",
                                    Requires = null, // ["Morph"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Green Gate",
                                            Requires = null, // ["never"]
                                        },
                                    },
                                },
                            }),
                            new LinkTarget("SM - Caterpillar Room - Elevator"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Caterpillar Room - Cacatacs",
                        EnemyName = "Cacatac",
                        Quantity = 2,
                        HomeNodes = new[] { "SM - Caterpillar Room - Main Junction" },
                    },
                    new Enemy {
                        GroupName = "SM - Caterpillar Room - Zeros",
                        EnemyName = "Zero",
                        Quantity = 3,
                        HomeNodes = new[] { "SM - Caterpillar Room - Bottom Left Door" },
                    },
                },
            },
            #endregion
            #region Alpha Room
            new Room {
                Name = "SM - Alpha Room",
                Layout = Room.LayoutFrom(@"
                      XXX←1"
                    , "SM - Alpha Room - Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Alpha Room - Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - Alpha Room - Chozo Item",
                        Type = PlacementType.Chozo,
                    },
                    new Placement {
                        Name = "SM - Alpha Room - Behind Wall Item",
                        Type = PlacementType.Visible,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Alpha Room - Door",
                        To = new[] {
                            new LinkTarget("SM - Alpha Room - Chozo Item"),
                        },
                    },
                    new Link {
                        From = "SM - Alpha Room - Chozo Item",
                        To = new[] {
                            new LinkTarget("SM - Alpha Room - Door"),
                            new LinkTarget("SM - Alpha Room - Behind Wall Item", new[] {
                                new Strat { Requires = null /*["h_canUsePowerBombs"]*/ },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Alpha Room - Behind Wall Item",
                        To = new[] {
                            new LinkTarget("SM - Alpha Room - Chozo Item"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Alpha Room - Boyons",
                        EnemyName = "Boyon",
                        Quantity = 4,
                        HomeNodes = new[] { "SM - Alpha Room - Chozo Item" },
                    },
                },
            },
            #endregion
            #region Beta Room
            new Room {
                Name = "SM - Beta Room",
                Layout = Room.LayoutFrom(@"
                      XX←1
                      X"
                    , "SM - Beta Room - Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Beta Room - Door",
                        Type = TransitionType.Gray,
                        Runways = new[] {
                            // This runway requires the PB blocks to be intact, but the sidehoppers
                            // to be dead. This is relevant because it can limit the player's
                            // options for killing the Sidehoppers.
                            new RunwayDash {
                                Length = 28,
                                OpenEnd = 0,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //{"resetRoom": {
                                        //  "nodes": [1],
                                        //  "obstaclesToAvoid": ["B"]
                                        //}}
                                        Obstacles = new[] {
                                            // To avoid redundant requirements, killing the
                                            // Sidehoppers requires going to Top Left Junction and
                                            // back.
                                            new Strat.Obstacle {
                                                Name = "Sidehoppers",
                                                Requires = null, // ["never"]
                                            },
                                        },
                                    },
                                },
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Beta Room - Grey Lock",
                                Type = LockType.KillEnemies,
                                UnlockStrats = new[] {
                                    new Strat {
                                        Obstacles = new[] {
                                            // To avoid redundant requirements, obstacle must be
                                            // destroyed by going to Top Left Junction and back.
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
                    new Placement {
                        Name = "SM - Beta Room - Item",
                        Type = PlacementType.Visible,
                    },
                    new Junction {
                        Name = "SM - Beta Room - Top Left Junction",
                    },
                },
                Obstacles = new[] {
                    new Obstacle {
                        Name = "Sidehoppers",
                        Type = ObstacleType.Enemies,
                    },
                    new Obstacle {
                        Name = "Power Bomb Blocks",
                        Type = ObstacleType.Enemies,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Beta Room - Door",
                        To = new[] {
                            new LinkTarget("SM - Beta Room - Top Left Junction", new[] {
                                new Strat {
                                    Name = "Power Beam Sidehopper Kill",
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Sidehoppers",
                                            Requires = null,
                                            //{"enemyDamage": {
                                            //  "enemy": "Sidehopper",
                                            //  "type": "contact",
                                            //  "hits": 4
                                            //}}
                                        },
                                    },
                                },
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
                                            //    "Wave"
                                            //  ]}
                                            //]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Sidehopper Missile Kill",
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
                                            //      [ "Sidehopper", "Sidehopper", "Sidehopper"]
                                            //    ],
                                            //    "explicitWeapons": [
                                            //      "Missile"
                                            //    ]
                                            //  }}
                                            //]
                                        },
                                    },
                                },
                                // The Sidehoppers can't hit a morphed Samus, so they can be picked
                                // off damage-free.
                                new Strat {
                                    Name = "Morph Power Beam Sidehopper Kill",
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Sidehoppers",
                                            Requires = null, // ["Morph"]
                                        },
                                    },
                                },
                                // This is essentially redundant with the Morph Power Beam kill.
                                // It wouldn't be redundant if Power Beam were to be taken away,
                                // though.
                                new Strat {
                                    Name = "PB Sidehopper Kill",
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Sidehoppers",
                                            Requires = null,
                                            //[ {"enemyKill":{
                                            //    "enemies": [
                                            //      [ "Sidehopper", "Sidehopper", "Sidehopper"]
                                            //    ],
                                            //    "explicitWeapons": [
                                            //      "PowerBomb"
                                            //    ]
                                            //  }}
                                            //]
                                            AdditionalObstacles = new[] { "Power Bomb Blocks" },
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Safe Weapon Sidehopper Kill",
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Sidehoppers",
                                            Requires = null,
                                            //[ {"enemyKill":{
                                            //    "enemies": [
                                            //      [ "Sidehopper", "Sidehopper", "Sidehopper"]
                                            //    ],
                                            //    "explicitWeapons": [
                                            //      "Super",
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
                        From = "SM - Beta Room - Item",
                        To = new[] {
                            new LinkTarget("SM - Beta Room - Top Left Junction", new[] {
                                // It's a bit pointless to put the obstacle requirement in since
                                // you can't get there without breaking the obstacle, but might as
                                // well since we have the obstacle.
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
                        From = "SM - Beta Room - Top Left Junction",
                        To = new[] {
                            new LinkTarget("SM - Beta Room - Door", new[] {
                                // To avoid redundant requirements, obstacle must be destroyed on
                                // the way in.
                                new Strat {
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Sidehoppers",
                                            Requires = null, // ["never"]
                                        },
                                    },
                                },
                            }),
                            new LinkTarget("SM - Beta Room - Item", new[] {
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
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Beta Room - Sidehoppers",
                        EnemyName = "Sidehopper",
                        Quantity = 3,
                        HomeNodes = new[] {
                            "SM - Beta Room - Door",
                            "SM - Beta Room - Top Left Junction",
                        },
                    },
                    // Wait for the Maws to reach up before killing them and the drops are reachable.
                    new Enemy {
                        GroupName = "SM - Beta Room - Yapping Maws",
                        EnemyName = "Yapping Maw",
                        Quantity = 2,
                        HomeNodes = new[] { "SM - Beta Room - Door" },
                    },
                },
            },
            #endregion
            #region Brinstar Red Refill Room
            new Room {
                Name = "SM - Brinstar Red Refill Room",
                Layout = Room.LayoutFrom(@"
                      X←1"
                    , "SM - Brinstar Red Refill Room - Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Brinstar Red Refill Room - Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Utility {
                        Name = "SM - Brinstar Red Refill Room - Energy Refill",
                        Type = UtilityType.Energy,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Brinstar Red Refill Room - Door",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Red Refill Room - Energy Refill"),
                        },
                    },
                    new Link {
                        From = "SM - Brinstar Red Refill Room - Energy Refill",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Red Refill Room - Door"),
                        },
                    },
                },
            },
            #endregion
            #region Brinstar Red Save Room
            new Room {
                Name = "SM - Brinstar Red Save Room",
                Layout = Room.LayoutFrom(@"
                      1→X"
                    , "SM - Brinstar Red Save Room - Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Brinstar Red Save Room - Door",
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
                        Name = "SM - Brinstar Red Save Room - Save Station",
                        Type = UtilityType.Save,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Brinstar Red Save Room - Door",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Red Save Room - Save Station"),
                        },
                    },
                    new Link {
                        From = "SM - Brinstar Red Save Room - Save Station",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Red Save Room - Door"),
                        },
                    },
                },
            },
            #endregion
        };

    }

}
