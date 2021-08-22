using System.Collections.Generic;
using SMRouteRando.Util;

namespace SMRouteRando {

    public class SMNorfairUpperWest {

        public static IList<Room> Rooms { get; } = new[] {
            #region Business Center
            new Room {
                Name = "SM - Business Center",
                Layout = Room.LayoutFrom(@"
                        4
                        ↓
                        X
                      3→X←5
                      2→X
                      1→X←6
                        X←7"
                    , "SM - Business Center - Bottom Left Door"
                    , "SM - Business Center - Middle Left Door"
                    , "SM - Business Center - Top Left Door"
                    , "SM - Business Center - Elevator"
                    , "SM - Business Center - Top Right Door"
                    , "SM - Business Center - Middle Right Door"
                    , "SM - Business Center - Bottom Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Business Center - Bottom Left Door",
                        Type = TransitionType.Red,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 12,
                                OpenEnd = 0,
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "Business Center Bottom Left Red Lock (to HiJump E-Tank)",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenRedDoors"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Business Center - Middle Left Door",
                        Type = TransitionType.Yellow,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 1,
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "Business Center Middle Left Yellow Lock (to Map)",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenYellowDoors"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Business Center - Top Left Door",
                        Type = TransitionType.Green,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 4,
                                GentleUpTiles = 2,
                                EndingUpTiles = 2,
                                OpenEnd = 1,
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Business Center - Top Left Green Lock",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenGreenDoors"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Business Center - Elevator",
                        Type = TransitionType.Elevator,
                    },
                    // Should this have an additional runway with the gate open? Probably, but
                    // missing here would be so annoying. Depending on what room is the next one,
                    // there would be softlock potential too. To be considered.
                    new Transition {
                        Name = "SM - Business Center - Top Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 4,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Business Center - Middle Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 12,
                                OpenEnd = 0,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Business Center - Bottom Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 8,
                                GentleDownTiles = 4,
                                OpenEnd = 0,
                            },
                        },
                    },
                    new Junction {
                        Name = "SM - Business Center - Top Junction",
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Business Center - Top Left Door",
                        To = new[] {
                            new LinkTarget("SM - Business Center - Top Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Business Center - Middle Left Door",
                        To = new[] {
                            new LinkTarget("SM - Business Center - Top Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Business Center - Bottom Left Door",
                        To = new[] {
                            new LinkTarget("SM - Business Center - Top Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Business Center - Bottom Right Door",
                        To = new[] {
                            new LinkTarget("SM - Business Center - Top Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Business Center - Middle Right Door",
                        To = new[] {
                            new LinkTarget("SM - Business Center - Top Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Business Center - Top Right Door",
                        To = new[] {
                            new LinkTarget("SM - Business Center - Top Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Business Center - Elevator",
                        To = new[] {
                            new LinkTarget("SM - Business Center - Top Junction"),
                        },
                    },
                    new Link{
                        From = "SM - Business Center - Top Junction",
                        To = new[] {
                            new LinkTarget("SM - Business Center - Top Left Door"),
                            new LinkTarget("SM - Business Center - Middle Left Door"),
                            new LinkTarget("SM - Business Center - Bottom Left Door"),
                            new LinkTarget("SM - Business Center - Bottom Right Door"),
                            new LinkTarget("SM - Business Center - Middle Right Door"),
                            new LinkTarget("SM - Business Center - Top Right Door"),
                            new LinkTarget("SM - Business Center - Elevator"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Business Center - Top Sovas",
                        EnemyName = "Sova",
                        Quantity = 5,
                        HomeNodes = new[] { "SM - Business Center - Top Junction" },
                    },
                    new Enemy {
                        GroupName = "SM - Business Center - Bottom Sova",
                        EnemyName = "Sova",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Business Center - Bottom Right Door" },
                    },
                },
            },
            #endregion
            #region Norfair Map Room
            new Room {
                Name = "SM - Norfair Map Room",
                Layout = Room.LayoutFrom(@"
                      X←1"
                    , "SM - Norfair Map Room - Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Norfair Map Room - Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Utility {
                        Name = "SM - Norfair Map Room - Map Station",
                        Type = UtilityType.Map,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Norfair Map Room - Door",
                        To = new[] {
                            new LinkTarget("SM - Norfair Map Room - Map Station"),
                        },
                    },
                    new Link {
                        From = "SM - Norfair Map Room - Map Station",
                        To = new[] {
                            new LinkTarget("SM - Norfair Map Room - Door"),
                        },
                    },
                },
            },
            #endregion
            // Todo: Better name?
            #region HiJump Energy Tank Room
            new Room {
                Name = "SM - HiJump Energy Tank Room",
                Layout = Room.LayoutFrom(@"
                        XX←2
                      1→X"
                    , "SM - HiJump Energy Tank Room - Left Door"
                    , "SM - HiJump Energy Tank Room - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - HiJump Energy Tank Room - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 0,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - HiJump Energy Tank Room - Right Door",
                        Type = TransitionType.Gray,
                        Runways = new[] {
                            // The bomb blocks have to be intact, but it's always possible to get
                            // to this node without breaking them.
                            new RunwayDash {
                                Length = 6,
                                OpenEnd = 0,
                            },
                        },
                        Locks = new[] {
                            // The enemy is reachable with no requirement and killable with Power Beam.
                            new Lock {
                                Name = "SM - HiJump Energy Tank Room - Grey Lock",
                                Type = LockType.KillEnemies,
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - HiJump Energy Tank Room - Left Item",
                        Type = PlacementType.Visible,
                    },
                    new Placement {
                        Name = "SM - HiJump Energy Tank Room - Right Item",
                        Type = PlacementType.Visible,
                    },
                    // Just below the Energy tank. Reachable to kill the Sova without Morph.
                    new Junction {
                        Name = "SM - HiJump Energy Tank Room - Crawl Space Junction",
                    },
                },
                Obstacles = new[] {
                    new Obstacle {
                        Name = "Crumble blocks",
                        Type = ObstacleType.Inanimate,
                    },
                    new Obstacle {
                        Name = "E-tank bomb blocks",
                        Type = ObstacleType.Inanimate,
                    },
                    new Obstacle {
                        Name = "Missile bomb blocks",
                        Type = ObstacleType.Inanimate,
                    }
                },
                Links = new[] {
                    new Link {
                        From = "SM - HiJump Energy Tank Room - Left Door",
                        To = new[] {
                            new LinkTarget("SM - HiJump Energy Tank Room - Left Item", new[] {
                                new Strat { Requires = null /*["Morph"]*/ },
                            }),
                            new LinkTarget("SM - HiJump Energy Tank Room - Crawl Space Junction", new[] {
                                new Strat { Requires = null /*["Morph"]*/ },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - HiJump Energy Tank Room - Right Door",
                        To = new[] {
                            new LinkTarget("SM - HiJump Energy Tank Room - Right Item"),
                        },
                    },
                    new Link {
                        From = "SM - HiJump Energy Tank Room - Right Item",
                        To = new[] {
                            new LinkTarget("SM - HiJump Energy Tank Room - Right Door"),
                            new LinkTarget("SM - HiJump Energy Tank Room - Left Item", new[] {
                                new Strat {
                                    Requires = null, // ["Morph"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Missile bomb blocks",
                                            Requires = null, // ["h_canPassBombPassages"]
                                        },
                                    },
                                },
                            }),
                            new LinkTarget("SM - HiJump Energy Tank Room - Crawl Space Junction", new[] {
                                new Strat {
                                    Obstacles = new[] {
                                        new Strat.Obstacle { Name = "Crumble blocks", },
                                    },
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - HiJump Energy Tank Room - Left Item",
                        To = new[] {
                            new LinkTarget("SM - HiJump Energy Tank Room - Left Door", new[] {
                                new Strat { Requires = null /*["Morph"]*/ },
                            }),
                            new LinkTarget("SM - HiJump Energy Tank Room - Right Item", new[] {
                                new Strat {
                                    Requires = null, // ["Morph"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Missile bomb blocks",
                                            Requires = null, // ["h_canPassBombPassages"]
                                        },
                                    },
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - HiJump Energy Tank Room - Crawl Space Junction",
                        To = new[] {
                            new LinkTarget("SM - HiJump Energy Tank Room - Left Door", new[] {
                                new Strat { Requires = null /*["Morph"]*/ },
                            }),
                            new LinkTarget("SM - HiJump Energy Tank Room - Right Item", new[] {
                                new Strat {
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "E-tank bomb blocks",
                                            Requires = null, // ["h_canPassBombPassages"]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Crumble Blocks Gone",
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Crumble blocks",
                                            Requires = null, // ["never"]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "HiJump Etank X-Ray Clip",
                                    Notable = true,
                                    Requires = null,
                                    //[ "Morph",
                                    //  "canXRayStandUp",
                                    //  "canCeilingClip"
                                    //]
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - HiJump Energy Tank Room - Sova",
                        EnemyName = "Sova",
                        Quantity = 1,
                        HomeNodes = new[] {
                            "SM - HiJump Energy Tank Room - Left Door",
                            "SM - HiJump Energy Tank Room - Left Item",
                            "SM - HiJump Energy Tank Room - Crawl Space Junction",
                        },
                    },
                },
            },
            #endregion
            // Todo: Better name?
            #region HiJump Boots Room
            new Room {
                Name = "SM - HiJump Boots Room",
                Layout = Room.LayoutFrom(@"
                      X←1"
                    , "SM - HiJump Boots Room - Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - HiJump Boots Room - Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 5,
                                OpenEnd = 0,
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - HiJump Boots Room - Item",
                        Type = PlacementType.Chozo,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - HiJump Boots Room - Door",
                        To = new[] {
                            new LinkTarget("SM - HiJump Boots Room - Item"),
                        },
                    },
                    new Link {
                        From = "SM - HiJump Boots Room - Item",
                        To = new[] {
                            new LinkTarget("SM - HiJump Boots Room - Door"),
                        },
                    },
                },
            },
            #endregion
            // Todo: Acceptable name?
            #region Norfair Speed Gates
            new Room {
                Name = "SM - Norfair Speed Gates",
                Layout = Room.LayoutFrom(@"
                         3→X
                           X
                         2→XXXX←4
                      1→XXXX"
                    , "SM - Norfair Speed Gates - Bottom Left Door"
                    , "SM - Norfair Speed Gates - Middle Left Door"
                    , "SM - Norfair Speed Gates - Top Left Door"
                    , "SM - Norfair Speed Gates - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Norfair Speed Gates - Bottom Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 6,
                                OpenEnd = 0,
                            },
                            // With no Enemies.
                            new RunwayDash {
                                Length = 33,
                                OpenEnd = 1,
                                UsableComingIn = false,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Norfair Speed Gates - Middle Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 14,
                                OpenEnd = 0,
                            },
                        },
                        CanLeaveCharged = new[] {
                            new RunwayCharge {
                                Length = 33,
                                OpenEnd = 2,
                                FramesRemaining = 100,
                                InitiateRemotely = new() {
                                    InitiateAt = "SM - Norfair Speed Gates - Right Door",
                                    MustOpenDoorFirst = false,
                                    PathToDoor = new[] {
                                        new PathStep("SM - Norfair Speed Gates - Middle Left Door", new[] { "Speed Through" }),
                                    },
                                },
                                Strats = new[] {
                                    // Run through the room from node 4, store the spark after the gate, and run out.
                                    new Strat {
                                        Requires = null,
                                        //{"resetRoom": {
                                        //  "nodes": [4],
                                        //  "mustStayPut": true
                                        //}}
                                    },
                                },
                            },
                        },
                    },
                    // Samus is considered to spawn at 5 because of the crumble blocks.
                    new Transition {
                        Name = "SM - Norfair Speed Gates - Top Left Door",
                        Type = TransitionType.Blue,
                        SpawnAt = "SM - Norfair Speed Gates - Above Crumbles Junction",
                        Runways = new[] {
                            new RunwayDash {
                                Length = 0,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Norfair Speed Gates - Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 13,
                                OpenEnd = 0,
                            },
                        },
                    },
                    new Junction {
                        Name = "SM - Norfair Speed Gates - Above Crumbles Junction",
                    },
                    new Junction {
                        Name = "SM - Norfair Speed Gates - Below Top Crumbles Junction",
                    },
                },
                Obstacles = new[] {
                    new Obstacle {
                        Name = "Ceiling bomb blocks",
                        Type = ObstacleType.Inanimate,
                    },
                    new Obstacle {
                        Name = "Morph path bomb blocks",
                        Type = ObstacleType.Inanimate,
                    },
                    new Obstacle {
                        Name = "PowerBomb blocks",
                        Type = ObstacleType.Inanimate,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Norfair Speed Gates - Top Left Door",
                        To = new[] {
                            new LinkTarget("SM - Norfair Speed Gates - Above Crumbles Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Norfair Speed Gates - Middle Left Door",
                        To = new[] {
                            new LinkTarget("SM - Norfair Speed Gates - Top Left Door", new[] {
                                new Strat {
                                    Name = "Ice Beam Gate Room X-Ray Climb",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canRightFacingDoorXRayClimb",
                                    //  {"resetRoom":{
                                    //    "nodes":[2],
                                    //    "mustStayPut": true
                                    //  }}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Norfair Speed Gates - Bottom Left Door", new[] {
                                new Strat {
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "PowerBomb blocks",
                                            Requires = null, // ["h_canUsePowerBombs"]
                                            AdditionalObstacles = new[] {
                                                "Ceiling bomb blocks",
                                                "Morph path bomb blocks",
                                            },
                                        },
                                    },
                                },
                            }),
                            new LinkTarget("SM - Norfair Speed Gates - Right Door", new[] {
                                // FIXME Mockballing from the next room can also be done with
                                // smaller runways (like in the vanilla strat). See issue #63.
                                new Strat {
                                    Name = "Mockball",
                                    Requires = null,
                                    //[ "canMockball",
                                    //  {"adjacentRunway": {
                                    //    "fromNode": 2,
                                    //    "usedTiles": 11
                                    //  }}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Norfair Speed Gates - Below Top Crumbles Junction", new[] {
                                new Strat {
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Ceiling bomb blocks",
                                            Requires = null, // ["ScrewAttack"]
                                        },
                                    },
                                },
                                new Strat {
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Ceiling bomb blocks",
                                            Requires = null, // ["h_canUseMorphBombs"]
                                        },
                                    },
                                },
                                new Strat {
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Ceiling bomb blocks",
                                            Requires = null, // ["h_canUsePowerBombs"]
                                            AdditionalObstacles = new[] {
                                                "Morph path bomb blocks",
                                                "PowerBomb blocks",
                                            },
                                        },
                                    },
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Norfair Speed Gates - Bottom Left Door",
                        To = new[] {
                            new LinkTarget("SM - Norfair Speed Gates - Middle Left Door", new[] {
                                // Avoiding damage from all enemies with just Power Beam is tricky, but doable.
                                new Strat {
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "PowerBomb blocks",
                                            Requires = null, // ["h_canUsePowerBombs"]
                                            AdditionalObstacles = new[] {
                                                "Ceiling bomb blocks",
                                                "Morph path bomb blocks",
                                            },
                                        },
                                    },
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Norfair Speed Gates - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Norfair Speed Gates - Middle Left Door", new[] {
                                new Strat {
                                    Name = "Speed Through",
                                    Requires = null, // ["SpeedBooster"]
                                },
                                new Strat {
                                    Name = "Ice Beam Mockball",
                                    Requires = null, // ["canMockball"]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Norfair Speed Gates - Below Top Crumbles Junction",
                        To = new[] {
                            new LinkTarget("SM - Norfair Speed Gates - Middle Left Door", new[] {
                                new Strat {
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Ceiling bomb blocks",
                                            Requires = null, // ["ScrewAttack"]
                                        },
                                    },
                                },
                                new Strat {
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Ceiling bomb blocks",
                                            Requires = null, // ["h_canUseMorphBombs"]
                                        },
                                    },
                                },
                                new Strat {
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Ceiling bomb blocks",
                                            Requires = null, // ["h_canUsePowerBombs"]
                                            AdditionalObstacles = new[] {
                                                "Morph path bomb blocks",
                                                "PowerBomb blocks",
                                            },
                                        },
                                    },
                                },
                            }),
                            new LinkTarget("SM - Norfair Speed Gates - Right Door", new[] {
                                new Strat {
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Morph path bomb blocks",
                                            Requires = null, // ["h_canUseMorphBombs"]
                                        },
                                    },
                                },
                                new Strat {
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Morph path bomb blocks",
                                            Requires = null, // ["h_canUsePowerBombs"]
                                            AdditionalObstacles = new [] {
                                                "Ceiling bomb blocks",
                                                "PowerBomb blocks",
                                            },
                                        },
                                    },
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Norfair Speed Gates - Above Crumbles Junction",
                        To = new[] {
                            new LinkTarget("SM - Norfair Speed Gates - Top Left Door", new[] {
                                new Strat {
                                    Name = "Ice Beam Gate Room Crumble Jump Retreat",
                                    Notable = true,
                                    Requires = null, // ["canCrumbleJump"]
                                },
                                // Use SpringBall to bounce on the crumble blocks, the unmorph and
                                // shoot the door open.
                                new Strat {
                                    Name = "Ice Beam Gate Room SpringBall Retreat",
                                    Notable = true,
                                    Requires = null, // ["h_canUseSpringBall"],
                                },
                            }),
                            new LinkTarget("SM - Norfair Speed Gates - Below Top Crumbles Junction"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "Ice Beam Gate Room Sova",
                        EnemyName = "Sova",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Norfair Speed Gates - Below Top Crumbles Junction" },
                    },
                    new Enemy {
                        GroupName = "Ice Beam Gate Room Small Dessgeegas",
                        EnemyName = "Sm. Dessgeega",
                        Quantity = 3,
                        HomeNodes = new[] { "SM - Norfair Speed Gates - Bottom Left Door" },
                    },
                    new Enemy {
                        GroupName = "Ice Beam Gate Room Mellas",
                        EnemyName = "Mella",
                        Quantity = 6,
                        HomeNodes = new[] { "SM - Norfair Speed Gates - Bottom Left Door" },
                    },
                },
            },
            #endregion
            // Todo: Acceptable name?
            #region Metal Bunker Lava Hallway
            new Room {
                Name = "SM - Metal Bunker Lava Hallway",
                Layout = Room.LayoutFrom(@"
                      1→XX←2"
                    , "SM - Metal Bunker Lava Hallway - Left Door"
                    , "SM - Metal Bunker Lava Hallway - Left Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Metal Bunker Lava Hallway - Left Door",
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
                        Name = "SM - Metal Bunker Lava Hallway - Right Door",
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
                },
                Links = new[] {
                    new Link {
                        From = "SM - Metal Bunker Lava Hallway - Left Door",
                        To = new [] {
                            new LinkTarget("SM - Metal Bunker Lava Hallway - Right Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 250}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Metal Bunker Lava Hallway - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Metal Bunker Lava Hallway - Left Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 250}
                                    //]
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    // Drops can be reached from land without issues.
                    new Enemy {
                        GroupName = "SM - Metal Bunker Lava Hallway - Trippers",
                        EnemyName = "Tripper",
                        Quantity = 3,
                        HomeNodes = new[] {
                            "SM - Metal Bunker Lava Hallway - Left Door",
                            "SM - Metal Bunker Lava Hallway - Right Door",
                        },
                        DropRequires = null, // ["h_heatProof"],
                    },
                },
            },
            #endregion
            // Todo: Acceptable name?
            #region Metal Bunker Snake Room
            new Room {
                Name = "SM - Metal Bunker Snake Room",
                Layout = Room.LayoutFrom(@"
                      X←1
                      XX←2
                      X←3"
                    , "SM - Metal Bunker Snake Room - Top Right Door"
                    , "SM - Metal Bunker Snake Room - Middle Right Door"
                    , "SM - Metal Bunker Snake Room - Bottom Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Metal Bunker Snake Room - Top Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 0,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Metal Bunker Snake Room - Middle Right Door",
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
                        Name = "SM - Metal Bunker Snake Room - Bottom Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 11,
                                OpenEnd = 0,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"heatFrames": 135}
                                        //]
                                    },
                                },
                            },
                            // With no Enemies.
                            new RunwayDash {
                                Length = 12,
                                OpenEnd = 0,
                                UsableComingIn = false,
                                Strats = new[] {
                                    new Strat {
                                        Name = "PowerBombs Fune Kill",
                                        Requires = null,
                                        //[ {"enemyKill":{
                                        //    "enemies": [
                                        //      [ "Fune" ]
                                        //    ],
                                        //    "explicitWeapons": [ "PowerBomb" ]
                                        //  }},
                                        //  { "heatFrames": 350}
                                        //]
                                    },
                                    new Strat {
                                        Name = "Supers Fune Kill",
                                        Requires = null,
                                        //[ {"enemyKill":{
                                        //    "enemies": [
                                        //      [ "Fune" ]
                                        //    ],
                                        //    "explicitWeapons": [ "Super" ]
                                        //  }},
                                        //  { "heatFrames": 150}
                                        //]
                                    },
                                },
                            },
                        },
                    },
                    new Junction {
                        Name = "SM - Metal Bunker Snake Room - Bottom Right Passage Junction",
                    },
                    new Junction {
                        Name = "SM - Metal Bunker Snake Room - Top Right Passage Junction",
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Metal Bunker Snake Room - Top Right Door",
                        To = new[] {
                            new LinkTarget("SM - Metal Bunker Snake Room - Bottom Right Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 750}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Metal Bunker Snake Room - Top Right Passage Junction", new[] {
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
                        From = "SM - Metal Bunker Snake Room - Middle Right Door",
                        To = new[] {
                            new LinkTarget("SM - Metal Bunker Snake Room - Bottom Right Passage Junction", new[] {
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
                    new Link {
                        From = "SM - Metal Bunker Snake Room - Bottom Right Door",
                        To = new[] {
                            new LinkTarget("SM - Metal Bunker Snake Room - Top Right Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 500}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Metal Bunker Snake Room - Bottom Right Passage Junction", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "Morph",
                                    //  {"heatFrames": 100}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Metal Bunker Snake Room - Bottom Right Passage Junction",
                        To = new[] {
                            new LinkTarget("SM - Metal Bunker Snake Room - Middle Right Door", new[] {
                                new Strat {
                                    Name = "Tank Damage",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "Morph",
                                    //  {"heatFrames": 300},
                                    //  {"enemyDamage": {
                                    //    "enemy": "Sova",
                                    //    "type": "contact",
                                    //    "hits": 1
                                    //  }}
                                    //]
                                },
                                new Strat {
                                    Name = "Power Bombs",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "h_canUsePowerBombs",
                                    //  {"heatFrames": 300}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Metal Bunker Snake Room - Bottom Right Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "Morph",
                                    //  { "heatFrames": 100}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Metal Bunker Snake Room - Top Right Passage Junction", new[] {
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
                        From = "SM - Metal Bunker Snake Room - Top Right Passage Junction",
                        To = new[] {
                            new LinkTarget("SM - Metal Bunker Snake Room - Top Right Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 150}
                                    //]
                                },
                            }),
                            // This is considered one-way even though technically you can get from
                            // Middle Right Door to Top Right Passage Junction without falling to
                            // Top Right Passage Junction with a tight jump using Spring Ball. This
                            // won't be expected for heat run times.
                            new LinkTarget("SM - Metal Bunker Snake Room - Middle Right Door", new[] {
                                new Strat {
                                    Name = "Tank Damage",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "Morph",
                                    //  {"heatFrames": 150},
                                    //  {"enemyDamage": {
                                    //    "enemy": "Sova",
                                    //    "type": "contact",
                                    //    "hits": 1
                                    //  }}
                                    //]
                                },
                                new Strat {
                                    Name = "Power Bombs",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "h_canUsePowerBombs",
                                    //  { "heatFrames": 200}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Metal Bunker Snake Room - Bottom Right Passage Junction", new[] {
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
                        GroupName = "Ice Beam Snake Room Funes",
                        EnemyName = "Fune",
                        Quantity = 4,
                        BetweenNodes = new[] {
                            "SM - Metal Bunker Snake Room - Top Right Door",
                            "SM - Metal Bunker Snake Room - Bottom Right Door",
                        },
                        DropRequires = null, // ["h_heatProof"]
                    },
                    new Enemy {
                        GroupName = "Ice Beam Snake Room Sovas",
                        EnemyName = "Sova",
                        Quantity = 3,
                        HomeNodes = new[] {
                            "SM - Metal Bunker Snake Room - Middle Right Door",
                            "SM - Metal Bunker Snake Room - Bottom Right Door",
                            "SM - Metal Bunker Snake Room - Bottom Right Passage Junction",
                        },
                        DropRequires = null, // ["h_heatProof"]
                    },
                },
            },
            #endregion
            // Todo: Acceptable name?
            #region Metal Bunker Chozo Room
            new Room {
                Name = "SM - Metal Bunker Chozo Room",
                Layout = Room.LayoutFrom(@"
                      1→X"
                    , "SM - Metal Bunker Chozo Room - Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Metal Bunker Chozo Room - Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 10,
                                OpenEnd = 0,
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - Metal Bunker Chozo Room - Item",
                        Type = PlacementType.Chozo,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Metal Bunker Chozo Room - Door",
                        To = new[] {
                            new LinkTarget("SM - Metal Bunker Chozo Room - Item"),
                        },
                    },
                    new Link {
                        From = "SM - Metal Bunker Chozo Room - Item",
                        To = new[] {
                            new LinkTarget("SM - Metal Bunker Chozo Room - Door"),
                        },
                    },
                },
            },
            #endregion
            // Todo: Acceptable name?
            #region Metal Bunker Escape Vent
            new Room {
                Name = "SM - Metal Bunker Escape Vent",
                Layout = Room.LayoutFrom(@"
                      1→XX←2"
                    , "SM - Metal Bunker Escape Vent - Left Door"
                    , "SM - Metal Bunker Escape Vent - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Metal Bunker Escape Vent - Left Door",
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
                        Name = "SM - Metal Bunker Escape Vent - Right Door",
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
                        From = "SM - Metal Bunker Escape Vent - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Metal Bunker Escape Vent - Right Door", new[] {
                                new Strat {
                                    Name = "Gravity",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "Morph",
                                    //  "Gravity",
                                    //  {"heatFrames": 350}
                                    //]
                                },
                                new Strat {
                                    Name = "Frozen Boyon",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "Morph",
                                    //  "canUseFrozenEnemies",
                                    //  {"heatFrames": 350}
                                    //]
                                },
                                // It's possible to get into the passage by a non-mockball mid-air
                                // morph. It just needs to be fairly late. The Boyyon will then
                                // push Samus into the passage.
                                new Strat {
                                    Name = "Boyon Hit",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "Morph",
                                    //  "canDamageBoost",
                                    //  {"enemyDamage": {
                                    //    "enemy": "Boyon",
                                    //    "type": "contact",
                                    //    "hits": 1
                                    //  }},
                                    //  { "heatFrames": 350}
                                    //]
                                },
                                // A well-executed mid-air mockball can get into the passage
                                // without taking a hit.
                                new Strat {
                                    Name = "Mid-Air Mockball",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "canMidAirMockball",
                                    //  { "heatFrames": 350}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Metal Bunker Escape Vent - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Metal Bunker Escape Vent - Left Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "Morph",
                                    //  {"heatFrames": 300},
                                    //  {"lavaFrames": 70},
                                    //  {"enemyDamage": {
                                    //    "enemy": "Boyon",
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
                        GroupName = "SM - Metal Bunker Escape Vent - Boyons",
                        EnemyName = "Boyon",
                        Quantity = 3,
                        HomeNodes = new[] { "SM - Metal Bunker Escape Vent - Left Door" },
                        DropRequires = null,
                        //[ "h_heatProof",
                        //  "Gravity"
                        //]
                    },
                    new Enemy {
                        GroupName = "SM - Metal Bunker Escape Vent - Ripper 2",
                        EnemyName = "Ripper 2 (red)",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Metal Bunker Escape Vent - Right Door" },
                        DropRequires = null, // ["h_heatProof"]
                    },
                },
            },
            #endregion
            #region Crumble Shaft
            new Room {
                Name = "SM - Crumble Shaft",
                Layout = Room.LayoutFrom(@"
                      X←1
                      X
                      X
                      X←2"
                    , "SM - Crumble Shaft - Top Right Door"
                    , "SM - Crumble Shaft - Bottom Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Crumble Shaft - Top Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 1,
                                OpenEnd = 1,
                                UsableComingIn = false,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"heatFrames": 50}
                                        //]
                                    },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Crumble Shaft - Bottom Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 0,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - Crumble Shaft - Item",
                        Type = PlacementType.Hidden,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Crumble Shaft - Top Right Door",
                        To = new[] {
                            new LinkTarget("SM - Crumble Shaft - Bottom Right Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 200}
                                    //]
                                },
                            }),
                            // If none of the strats can be done, falling down to Bottom Right Door
                            // and going back up to the item may still be doable.
                            new LinkTarget("SM - Crumble Shaft - Item", new[] {
                                // Shoot the shot block, then crumble jump on the middle platform.
                                new Strat {
                                    Name = "Crumble Shaft Top Item Crumble Jump",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "canCrumbleJump",
                                    //  {"heatFrames": 150}
                                    //]
                                },
                                new Strat {
                                    Name = "Space Jump",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "SpaceJump",
                                    //  {"heatFrames": 150}
                                    //]
                                    StratProperties = new[] { "spinjump" },
                                },
                                new Strat {
                                    Name = "Shinespark",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"canComeInCharged":{
                                    //    "fromNode": 1,
                                    //    "framesRemaining": 60,
                                    //    "shinesparkFrames": 20
                                    //  }},
                                    //  { "heatFrames": 175}
                                    //]
                                },
                                // Get the game focus to move down so the middle platform Sova
                                // starts moving. Then shoot the shot block and walljump off the
                                // left side of the middle platform to reach the item.
                                new Strat {
                                    Name = "Crumble Shaft Top Item Precise Walljump",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "canPreciseWalljump",
                                    //  { "heatFrames": 300}
                                    //]
                                    StratProperties = new[] { "spinjump" },
                                },
                                // Get the game focus to move down so the middle platform Sova
                                // starts moving. Then freeze it by aiming down, shoot the shot
                                // block, and use the Sova as a stable platform.
                                new Strat {
                                    Name = "Crumble Shaft Top Item Frozen Sova",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "canUseFrozenEnemies",
                                    //  { "heatFrames": 350}
                                    //]
                                    StratProperties = new[] { "spinjump" },
                                },
                                // Shoot the shot block, the Spring Ball on the middle platform.
                                new Strat {
                                    Name = "SpringBall",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "h_canUseSpringBall",
                                    //  { "heatFrames": 200}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Crumble Shaft - Bottom Right Door",
                        To = new[] {
                            new LinkTarget("SM - Crumble Shaft - Top Right Door", new[] {
                                // Walljump up the right, then setup a walljump on the top-right
                                // crumble platform directly from the right wall.
                                new Strat {
                                    Name = "Crumble Shaft HiJump Climb",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "HiJump",
                                    //  {"heatFrames": 500}
                                    //]
                                },
                                // Walljump up the right, then walljump off the top-middle crumble
                                // platform then off the top-right one.
                                new Strat {
                                    Name = "Crumble Shaft HiJumpless Climb",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "canPreciseWalljump",
                                    //  {"heatFrames": 500}
                                    //]
                                },
                                // Do 9 successive crumble jumps up the platforms.
                                new Strat {
                                    Name = "Crumble Shaft Crumble Climb",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "canCrumbleJump",
                                    //  { "heatFrames": 800}
                                    //]
                                },
                                // Walljump up the right then do one crumble jump on the top middle
                                // platform.
                                new Strat {
                                    Name = "Crumble Shaft Wall/Crumble Climb",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "canCrumbleJump",
                                    //  { "heatFrames": 600}
                                    //]
                                },
                                // Do 9 successive spring ball bounces up the platforms.
                                new Strat {
                                    Name = "SpringBall",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "h_canUseSpringBall",
                                    //  { "heatFrames": 800}
                                    //]
                                },
                                // Walljump up the right, then use SpaceJump at the top.
                                new Strat {
                                    Name = "Space Jump",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "SpaceJump",
                                    //  { "heatFrames": 500}
                                    //]
                                },
                                // Kill the two Sovas on right-side platforms, then IBJ right next
                                // to those platforms.
                                new Strat {
                                    Name = "Crumble Shaft IBJ",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "canIBJ",
                                    //  { "heatFrames": 4000}
                                    //]
                                },
                                // Walljump up the right then do a springwall to get around the top
                                // right crumble platform.
                                new Strat {
                                    Name = "Crumble Shaft Springwall",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "canSpringwall",
                                    //  { "heatFrames": 500}
                                    //]
                                },
                                // It has to be setup really close to the right platforms, else it
                                // requires a crumble jump too.
                                new Strat {
                                    Name = "Crumble Shaft Shinespark Climb",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"canComeInCharged":{
                                    //    "fromNode": 2,
                                    //    "framesRemaining": 60,
                                    //    "shinesparkFrames": 59
                                    //  }},
                                    //  { "heatFrames": 250}
                                    //]
                                },
                                // Climb up the left, freeze the top-left Sova, and use it as a
                                // platform to reach the door.
                                new Strat {
                                    Name = "Crumble Shaft Frozen Climb",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "canUseFrozenEnemies",
                                    //  { "heatFrames": 800}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Crumble Shaft - Item", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 550}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Crumble Shaft - Item",
                        To = new[] {
                            // If no strat is applicable, the only option is to fall down to
                            // Bottom Right Door and climb back up to Top Right Door.
                            new LinkTarget("SM - Crumble Shaft - Top Right Door", new[] {
                                new Strat {
                                    Name = "Crumble Shaft Top Door Crumble Jump",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "canCrumbleJump",
                                    //  {"heatFrames": 200}
                                    //]
                                },
                                // Expects to freeze and use two Sovas back-to-back, as leniency to
                                // account for position variations. Also has an extra buffer for
                                // possibly needing to wait beforehand for the left Sova to
                                // position itself right.
                                new Strat {
                                    Name = "Frozen Sova",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "canUseFrozenEnemies",
                                    //  {"heatFrames": 400}
                                    //]
                                },
                                new Strat {
                                    Name = "SpringBall",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "h_canUseSpringBall",
                                    //  { "heatFrames": 250}
                                    //]
                                },
                                // Must have grabbed the item with a spinjump still active.
                                new Strat {
                                    Name = "Space Jump",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "SpaceJump",
                                    //  { "previousStratProperty": "spinjump"},
                                    //  { "heatFrames": 175}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Crumble Shaft - Bottom Right Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 250}
                                    //]
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "Crumble Shaft Sovas",
                        EnemyName = "Sova",
                        Quantity = 6,
                        HomeNodes = new[] {
                            "SM - Crumble Shaft - Top Right Door",
                            "SM - Crumble Shaft - Bottom Right Door",
                        },
                        DropRequires = null, // ["h_heatProof"]
                    },
                },
            },
            #endregion
            // Todo: Acceptable name?
            #region Downhill Pirate Speedway
            new Room {
                Name = "SM - Downhill Pirate Speedway",
                Layout = Room.LayoutFrom(@"
                      1→XXXXX     2→X
                           XXXX     X←3
                             XXXXXXXX←4
                                    ↑
                                    5"
                    , "SM - Downhill Pirate Speedway - Far Top Left Door"
                    , "SM - Downhill Pirate Speedway - Near Top Left Door"
                    , "SM - Downhill Pirate Speedway - Top Right Door"
                    , "SM - Downhill Pirate Speedway - Bottom Right Door"
                    , "SM - Downhill Pirate Speedway - Bottom Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Downhill Pirate Speedway - Far Top Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 33,
                                OpenEnd = 1,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  { "heatFrames": 300}
                                        //]
                                    },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Downhill Pirate Speedway - Near Top Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 7,
                                GentleUpTiles = 4,
                                EndingUpTiles = 3,
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
                        Name = "SM - Downhill Pirate Speedway - Top Right Door",
                        Type = TransitionType.Blue,
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
                                }
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Downhill Pirate Speedway - Bottom Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 1,
                                OpenEnd = 1,
                                UsableComingIn = false,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"heatFrames": 50}
                                        //]
                                    },
                                },
                            },
                        },
                        CanLeaveCharged = new[] {
                            new RunwayCharge {
                                Length = 33,
                                OpenEnd = 2,
                                FramesRemaining = 60,
                                Strats = new[] {
                                    // Enabled by coming in through Far Top Left Door and breaking
                                    // the obstacle on the way, or coming in charged and opening
                                    // the path to Far Top Left Door.
                                    new Strat {
                                        Requires = null, // ["h_heatProof"]
                                        Obstacles = new[] {
                                            new Strat.Obstacle {
                                                Name = "Right-side Speed Blocks",
                                                Requires = null, // ["never"]
                                            },
                                        },
                                    },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Downhill Pirate Speedway - Bottom Door",
                        Type = TransitionType.Green,
                        CanLeaveCharged = new[] {
                            new RunwayCharge {
                                Length = 33,
                                OpenEnd = 2,
                                FramesRemaining = 100,
                                Strats = new[] {
                                    // Enabled by coming in through Far Top Left Door and breaking
                                    // the obstacle on the way, or coming in charged and opening
                                    // the path to Far Top Left Door.
                                    new Strat {
                                        Requires = null, // ["h_heatProof"]
                                        Obstacles = new[] {
                                            new Strat.Obstacle {
                                                Name = "Right-side Speed Blocks",
                                                Requires = null, // [ "never" ]
                                            },
                                        },
                                    },
                                },
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "Far Top Left Door - Green Lock",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null, /*["h_canOpenGreenDoors"]*/ },
                                },
                            },
                        },
                    },
                    new Junction {
                        Name = "SM - Downhill Pirate Speedway - Bottom Right Junction",
                    },
                },
                Obstacles = new[] {
                    // The speed blocks on the right side of the speedway. Breaking those is needed
                    // for some CanLeaveCharged strats.
                    new Obstacle {
                        Name = "Right-side Speed Blocks",
                        Type = ObstacleType.Inanimate,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Downhill Pirate Speedway - Near Top Left Door",
                        To = new[] {
                            new LinkTarget("SM - Downhill Pirate Speedway - Top Right Door", new[] {
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
                        From = "SM - Downhill Pirate Speedway - Far Top Left Door",
                        To = new[] {
                            // This could probably be done without Speed Booster, assuming the
                            // blocks are gone, but it would require figuring out a strat for
                            // something that can't happen.
                            new LinkTarget("SM - Downhill Pirate Speedway - Bottom Right Junction", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "SpeedBooster",
                                    //  { "heatFrames": 400}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle { Name = "Right-side Speed Blocks" },
                                    },
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Downhill Pirate Speedway - Bottom Door",
                        To = new[] {
                            new LinkTarget("SM - Downhill Pirate Speedway - Bottom Right Junction", new[] {
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
                        From = "SM - Downhill Pirate Speedway - Bottom Right Door",
                        To = new[] {
                            new LinkTarget("SM - Downhill Pirate Speedway - Bottom Right Junction", new[] {
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
                        From = "SM - Downhill Pirate Speedway - Top Right Door",
                        To = new[] {
                            new LinkTarget("SM - Downhill Pirate Speedway - Near Top Left Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 200}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Downhill Pirate Speedway - Bottom Right Junction", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 250}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Downhill Pirate Speedway - Bottom Right Junction",
                        To = new[] {
                            new LinkTarget("SM - Downhill Pirate Speedway - Far Top Left Door", new[] {
                                new Strat {
                                    Name = "Croc Speedway Bottom Reverse Spark",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "SpeedBooster",
                                    //  {"heatFrames": 700}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Right-side Speed Blocks",
                                            Requires = null,
                                            //{"canComeInCharged":{
                                            //  "fromNode": 3,
                                            //  "inRoomPath": [3, 6],
                                            //  "framesRemaining": 60,
                                            //  "shinesparkFrames": 100
                                            //}}
                                        },
                                    },
                                },
                                // This could probably be done without Speed Booster, assuming the
                                // blocks are gone, but it would require figuring out a strat for
                                // something that can't happen.
                                new Strat {
                                    Name = "Lateral Spark",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "SpeedBooster",
                                    //  { "heatFrames": 700}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Right-side Speed Blocks",
                                            Requires = null,
                                            //{"canComeInCharged":{
                                            //  "fromNode": 4,
                                            //  "inRoomPath": [4, 6],
                                            //  "framesRemaining": 0,
                                            //  "shinesparkFrames": 100
                                            //}}
                                        },
                                    },
                                },
                            }),
                            new LinkTarget("SM - Downhill Pirate Speedway - Bottom Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 50}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Downhill Pirate Speedway - Bottom Right Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 50}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Downhill Pirate Speedway - Top Right Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 300}
                                    //]
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Downhill Pirate Speedway - Pirates",
                        EnemyName = "Red Space Pirate (standing)",
                        Quantity = 3,
                        HomeNodes = new[] { "SM - Downhill Pirate Speedway - Far Top Left Door" },
                        DropRequires = null, // ["h_heatProof"]
                    },
                    new Enemy {
                        GroupName = "SM - Downhill Pirate Speedway - Multiviolas",
                        EnemyName = "Multiviola",
                        Quantity = 4,
                        HomeNodes = new[] { "SM - Downhill Pirate Speedway - Far Top Left Door" },
                        DropRequires = null, // ["h_heatProof"]
                    },
                    new Enemy {
                        GroupName = "SM - Downhill Pirate Speedway - Right Pirates",
                        EnemyName = "Red Space Pirate (standing)",
                        Quantity = 2,
                        BetweenNodes = new[] {
                            "SM - Downhill Pirate Speedway - Far Top Left Door",
                            "SM - Downhill Pirate Speedway - Bottom Right Junction",
                        },
                        DropRequires = null, // ["h_heatProof"]
                    },
                    new Enemy {
                        GroupName = "SM - Downhill Pirate Speedway - Cacatacs",
                        EnemyName = "Cacatac",
                        Quantity = 2,
                        BetweenNodes = new[] {
                            "SM - Downhill Pirate Speedway - Top Right Door",
                            "SM - Downhill Pirate Speedway - Bottom Right Junction",
                        },
                        DropRequires = null, // ["h_heatProof"]
                    }
                },
            },
            #endregion
            // Todo: Acceptable name?
            #region Emergency Exit Room
            new Room {
                Name = "SM - Emergency Exit Room",
                Layout = Room.LayoutFrom(@"
                      1→XXXX
                        XXXX←2"
                    , "SM - Emergency Exit Room - Left Door"
                    , "SM - Emergency Exit Room - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Emergency Exit Room - Left Door",
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
                    },
                    new Transition {
                        Name = "SM - Emergency Exit Room - Right Door",
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
                    // Associated with Norfair Upper Crocomire in SMZ3.
                    new Placement {
                        Name = "SM - Emergency Exit Room - Item",
                        Type = PlacementType.Visible,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Emergency Exit Room - Left Door",
                        To = Empty<LinkTarget>.List,
                    },
                    new Link {
                        From = "SM - Emergency Exit Room - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Emergency Exit Room - Item", new[] {
                                // Do a series of mid-air SpringBall jumps to bring the Geruta over,
                                // then freeze it and step on it.
                                new Strat {
                                    Name = "Croc Escape SpringBall Freeze",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "canUseFrozenEnemies",
                                    //  "canSpringBallJumpMidAir",
                                    //  {"heatFrames": 1600},
                                    //  {"enemyDamage": {
                                    //    "enemy": "Geruta",
                                    //    "type": "contact",
                                    //    "hits": 1
                                    //  }}
                                    //]
                                },
                                new Strat {
                                    Name = "Croc Escape HiJump Freeze",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "canUseFrozenEnemies",
                                    //  "HiJump",
                                    //  {"heatFrames": 1150}
                                    //]
                                },
                                new Strat {
                                    Name = "Grapple",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "Grapple",
                                    //  {"heatFrames": 600}
                                    //]
                                },
                                new Strat {
                                    Name = "Space Jump",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "SpaceJump",
                                    //  { "heatFrames": 600}
                                    //]
                                },
                                new Strat {
                                    Name = "MidAir SpringBall",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "HiJump",
                                    //  "canSpringBallJumpMidAir",
                                    //  { "heatFrames": 600}
                                    //]
                                },
                                // Uses a bomb boost at the end of a mid-air SpringBall jump. Also
                                // requires a downgrab to complete the maneuver.
                                new Strat {
                                    Name = "Croc Escape SpringBall Bomb Boost",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "canSpringBallJumpMidAir",
                                    //  "canUnmorphBombBoost",
                                    //  {"heatFrames": 800}
                                    //]
                                },
                                new Strat {
                                    Name = "Speedjump",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "HiJump",
                                    //  "SpeedBooster",
                                    //  {"heatFrames": 600}
                                    //]
                                },
                                new Strat {
                                    Name = "Croc Escape IBJ",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "canIBJ",
                                    //  {"heatFrames": 1650}
                                    //]
                                },
                                new Strat {
                                    Name = "Croc Escape Short Short Charge",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"canShineCharge": {
                                    //    "usedTiles": 15,
                                    //    "shinesparkFrames": 50,
                                    //    "openEnd": 2
                                    //  }},
                                    //  { "heatFrames": 600}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Emergency Exit Room - Item",
                        To = new[] {
                            new LinkTarget("SM - Emergency Exit Room - Left Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "h_canOpenGreenDoors",
                                    //  {"heatFrames": 150}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Emergency Exit Room - Right Door", new[] {
                                new Strat {
                                    Name = "Grapple",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "Grapple",
                                    //  {"heatFrames": 500}
                                    //]
                                },
                                new Strat {
                                    Name = "Space Jump",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "SpaceJump",
                                    //  { "heatFrames": 500}
                                    //]
                                },
                                new Strat {
                                    Name = "Speedjump",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "HiJump",
                                    //  "SpeedBooster",
                                    //  { "heatFrames": 500}
                                    //]
                                },
                                new Strat {
                                    Name = "HiJump",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "HiJump",
                                    //  { "heatFrames": 600}
                                    //]
                                },
                                new Strat {
                                    Name = "Morph",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "Morph",
                                    //  { "heatFrames": 400}
                                    //]
                                },
                                new Strat {
                                    Name = "Quick Lava Bath",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 350},
                                    //  { "lavaFrames": 70},
                                    //  {"or":[
                                    //    {"enemyDamage": {
                                    //      "enemy": "Dragon",
                                    //      "type": "contact",
                                    //      "hits": 1
                                    //    }},
                                    //    {"enemyKill":{
                                    //      "enemies": [
                                    //        ["Dragon"]
                                    //      ],
                                    //      "explicitWeapons": [ "Super", "Missile", "Plasma", "ScrewAttack" ]
                                    //    }}
                                    //  ]}
                                    //]
                                },
                                // This strat just waits out the Dragon.
                                new Strat {
                                    Name = "Safe Lava Bath",
                                    Requires = null,
                                    //[ "h_heatProof",
                                    //  "Gravity"
                                    //]
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "Crocomire Escape Geruta",
                        EnemyName = "Geruta",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Emergency Exit Room - Right Door" },
                        DropRequires = null, // ["h_heatProof"]
                    },
                    new Enemy {
                        GroupName = "Crocomire Escape Dragons",
                        EnemyName = "Dragon",
                        Quantity = 5,
                        HomeNodes = new[] { "SM - Emergency Exit Room - Right Door" },
                        DropRequires = null,
                        //[ "h_heatProof",
                        //  {"or": [
                        //    "Gravity",
                        //    "Grapple"
                        //  ]}
                        //]
                    }
                },
            },
            #endregion
            #region Norfair Upper Save Room B
            new Room {
                Name = "SM - Norfair Upper Save Room B",
                Layout = Room.LayoutFrom(@"
                      1→X"
                    , "SM - Norfair Upper Save Room B - Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Norfair Upper Save Room B - Door",
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
                        Name = "SM - Norfair Upper Save Room B - Save Station",
                        Type = UtilityType.Save,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Norfair Upper Save Room B - Door",
                        To = new[] {
                            new LinkTarget("SM - Norfair Upper Save Room B - Save Station"),
                        },
                    },
                    new Link {
                        From = "SM - Norfair Upper Save Room B - Save Station",
                        To = new[] {
                            new LinkTarget("SM - Norfair Upper Save Room B - Door"),
                        },
                    },
                },
            },
            #endregion
        };

    }

}
