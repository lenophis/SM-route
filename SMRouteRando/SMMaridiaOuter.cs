using System.Collections.Generic;

namespace SMRouteRando {

    public class SMMaridiaOuter {

        public static IList<Room> Rooms { get; } = new[] {
            // Todo: Acceptable name?
            #region Maridia Tunnel A
            new Room {
                Name = "SM - Maridia Tunnel A",
                Layout = Room.LayoutFrom(@"
                      1→X←2"
                    , "SM - Maridia Tunnel A - Left Door"
                    , "SM - Maridia Tunnel A - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Maridia Tunnel A - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 12,
                                OpenEnd = 0,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Maridia Tunnel A - Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 12,
                                OpenEnd = 0,
                            },
                        },
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Maridia Tunnel A - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Maridia Tunnel A - Right Door"),
                        },
                    },
                    new Link{
                        From = "SM - Maridia Tunnel A - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Maridia Tunnel A - Left Door"),
                        },
                    },
                },
            },
            #endregion
            #region Glass Tunnel
            new Room {
                Name = "SM - Glass Tunnel",
                Layout = Room.LayoutFrom(@"
                        2
                        ↓
                        X
                      1→X←3
                        X←4"
                    , "SM - Glass Tunnel - Left Door"
                    , "SM - Glass Tunnel - Top Door"
                    , "SM - Glass Tunnel - Top Right Door"
                    , "SM - Glass Tunnel - Bottom Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Glass Tunnel - Left Door",
                        Type = TransitionType.Doorway,
                        Runways = new[] {
                            // The runway is longer with the tube intact, but we'll leave this out
                            // because it's gone forever once the tube's broken.
                            new RunwayDash {
                                Length = 1,
                                OpenEnd = 1,
                                UsableComingIn = false,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Glass Tunnel - Top Door",
                        Type = TransitionType.Blue,
                        SpawnAt = "SM - Glass Tunnel - Below Top Door Junction",
                    },
                    new Transition {
                        Name = "SM - Glass Tunnel - Top Right Door",
                        Type = TransitionType.Doorway,
                        Runways = new[] {
                            // The runway is longer with the tube intact, but we'll leave this out
                            // because it's gone forever once the tube's broken.
                            new RunwayDash {
                                Length = 1,
                                OpenEnd = 1,
                                UsableComingIn = false,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Glass Tunnel - Bottom Right Door",
                        Type = TransitionType.Red,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 4,
                                OpenEnd = 1,
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Glass Tunnel - Red Lock",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenRedDoors"]*/ },
                                },
                            },
                        },
                    },
                    // Represents the inside of the tube; unlocking this node breaks the tube.
                    new Event {
                        Name = "SM - Glass Tunnel - Inside Tube",
                        Type = EventType.Flag,
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Glass Tunnel - Inside Tube Event Lock",
                                Type = LockType.TriggeredEvent,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canUsePowerBombs"]*/ },
                                },
                            },
                        },
                        Yields = new[] { "f_MaridiaTubeBroken" },
                    },
                    // Represents the area just above the tube; unlocking this node breaks the tube.
                    new Event {
                        Name = "SM - Glass Tunnel - Above Tube",
                        Type = EventType.Flag,
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Glass Tunnel - Above Tube Event Lock",
                                Type = LockType.TriggeredEvent,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canUsePowerBombs"]*/ },
                                },
                            },
                        },
                        Yields = new[] { "f_MaridiaTubeBroken" },
                    },
                    // Represents the area just below the tube; unlocking this node breaks the tube.
                    new Event {
                        Name = "SM - Glass Tunnel - Below Tube",
                        Type = EventType.Flag,
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Glass Tunnel - Below Tube Event Lock",
                                Type = LockType.TriggeredEvent,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canUsePowerBombs"]*/ },
                                },
                            },
                        },
                        Yields = new[] { "f_MaridiaTubeBroken" },
                    },
                    new Junction {
                        Name = "SM - Glass Tunnel - Below Top Door Junction",
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Glass Tunnel - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Glass Tunnel - Inside Tube"),
                        },
                    },
                    new Link {
                        From = "SM - Glass Tunnel - Bottom Right Door",
                        To = new[] {
                            new LinkTarget("SM - Glass Tunnel - Below Tube"),
                        },
                    },
                    new Link {
                        From = "SM - Glass Tunnel - Top Right Door",
                        To = new[] {
                            new LinkTarget("SM - Glass Tunnel - Inside Tube"),
                        },
                    },
                    new Link {
                        From = "SM - Glass Tunnel - Top Door",
                        To = new[] {
                            new LinkTarget("SM - Glass Tunnel - Below Top Door Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Glass Tunnel - Inside Tube",
                        To = new[] {
                            new LinkTarget("SM - Glass Tunnel - Left Door"),
                            new LinkTarget("SM - Glass Tunnel - Top Right Door"),
                            // This direct link involves using an adjacent room without water
                            // physics to initiate a jump that takes Samus through the top door.
                            // The runway is to get enough speed to clear the edge of the tube.
                            // This wouldn't work for a submerged runway rendered usable by Gravity,
                            // but Gravity renders this strat redundant anyway.
                            new LinkTarget("SM - Glass Tunnel - Top Door", new[] {
                                new Strat {
                                    Name = "Maridia Tube Transition Gravity Jump",
                                    Notable = true,
                                    Requires = null,
                                    //[ "f_MaridiaTubeBroken",
                                    //  "canSuitlessMaridia",
                                    //  {"or":[
                                    //    {"adjacentRunway": {
                                    //      "fromNode": 1,
                                    //      "inRoomPath": [1, 5],
                                    //      "usedTiles": 1
                                    //    }},
                                    //    {"adjacentRunway": {
                                    //      "fromNode": 3,
                                    //      "inRoomPath": [3, 5],
                                    //      "usedTiles": 1
                                    //    }}
                                    //  ]}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Glass Tunnel - Above Tube", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "f_MaridiaTubeBroken",
                                    //  "Gravity"
                                    //]
                                },
                                // Doesn't require canSuitlessMaridia because there is no risk, nor
                                // anything tricky whatsoever.
                                new Strat {
                                    Name = "Suitless Base",
                                    Requires = null,
                                    //[ "f_MaridiaTubeBroken",
                                    //  "HiJump"
                                    //]
                                },
                                new Strat {
                                    Name = "Suitless",
                                    Requires = null,
                                    //[ "f_MaridiaTubeBroken",
                                    //  "canSuitlessMaridia",
                                    //  "canSpringBallJumpMidAir"
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Glass Tunnel - Below Tube", new[] {
                                new Strat { Requires = null /*["f_MaridiaTubeBroken"]*/ },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Glass Tunnel - Above Tube",
                        To = new[] {
                            new LinkTarget("SM - Glass Tunnel - Inside Tube", new[] {
                                new Strat { Requires = null /*["f_MaridiaTubeBroken"]*/ },
                                // This could have been a notable strat, but not with such a specific
                                // tech already tied to it.
                                new Strat {
                                    Name = "Maridia Tube Clip",
                                    Requires = null, // ["canMaridiaTubeClip"]
                                },
                            }),
                            new LinkTarget("SM - Glass Tunnel - Below Top Door Junction", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                // Doesn't require canSuitlessMaridia because there is no risk, nor
                                // anything tricky whatsoever.
                                new Strat {
                                    Name = "Suitless Base",
                                    Requires = null,
                                    //[ "f_MaridiaTubeBroken",
                                    //  "HiJump"
                                    //]
                                },
                                new Strat {
                                    Name = "Suitless",
                                    Requires = null,
                                    //[ "f_MaridiaTubeBroken",
                                    //  "canSuitlessMaridia",
                                    //  "canSpringBallJumpMidAir"
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Glass Tunnel - Below Tube",
                        To = new[] {
                            new LinkTarget("SM - Glass Tunnel - Bottom Right Door"),
                            new LinkTarget("SM - Glass Tunnel - Inside Tube", new[] {
                                new Strat { Requires = null /*["f_MaridiaTubeBroken"]*/ },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Glass Tunnel - Below Top Door Junction",
                        To = new[] {
                            new LinkTarget("SM - Glass Tunnel - Top Door", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                // Doesn't require canSuitlessMaridia because there is no risk, nor
                                // anything tricky whatsoever.
                                new Strat {
                                    Name = "Suitless Base",
                                    Requires = null,
                                    //[ "f_MaridiaTubeBroken",
                                    //  "HiJump"
                                    //]
                                },
                                new Strat {
                                    Name = "Suitless",
                                    Requires = null,
                                    //[ "f_MaridiaTubeBroken",
                                    //  "canSuitlessMaridia",
                                    //  "canSpringBallJumpMidAir"
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Glass Tunnel - Above Tube"),
                        },
                    },
                },
            },
            #endregion
            #region Maridia Outer Save Room
            new Room {
                Name = "SM - Maridia Outer Save Room",
                Layout = Room.LayoutFrom(@"
                      1→X"
                    , "SM - Maridia Outer Save Room - Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Maridia Outer Save Room - Door",
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
                        Name = "SM - Maridia Outer Save Room - Save Station",
                        Type = UtilityType.Save,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Maridia Outer Save Room - Door",
                        To = new[] {
                            new LinkTarget("SM - Maridia Outer Save Room - Save Station"),
                        },
                    },
                    new Link {
                        From = "SM - Maridia Outer Save Room - Save Station",
                        To = new[] {
                            new LinkTarget("SM - Maridia Outer Save Room - Door"),
                        },
                    },
                },
            },
            #endregion
            #region Main Street
            new Room {
                Name = "SM - Main Street",
                Layout = Room.LayoutFrom(@"
                      XX←1
                      XX
                      XXX←2
                      XX
                      XX
                      XX
                      XXX←3
                      XX←4
                       ↑
                       5"
                    , "SM - Main Street - Top Right Door"
                    , "SM - Main Street - Morph Passage"
                    , "SM - Main Street - Middle Right Door"
                    , "SM - Main Street - Bottom Right Door"
                    , "SM - Main Street - Bottom Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Main Street - Top Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 14,
                                SteepUpTiles = 2,
                                OpenEnd = 1,
                                Strats = new[] {
                                    new Strat { Requires = null /*["Gravity"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Main Street - Morph Passage",
                        Type = TransitionType.Passage,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 0,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Main Street - Middle Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 24,
                                GentleDownTiles = 3,
                                GentleUpTiles = 3,
                                OpenEnd = 1,
                                Strats = new[] {
                                    new Strat { Requires = null /*["Gravity"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Main Street - Bottom Right Door",
                        Type = TransitionType.Red,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 4,
                                SteepUpTiles = 1,
                                OpenEnd = 1,
                                Strats = new[] {
                                    new Strat { Requires = null /*["Gravity"]*/ },
                                },
                            },
                        },
                        CanLeaveCharged = new[] {
                            new RunwayCharge {
                                Length = 17,
                                FramesRemaining = 80,
                                OpenEnd = 0,
                                Strats = new[] {
                                    new Strat { Requires = null /*["Gravity"]*/ },
                                },
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Main Street - Red Lock",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenRedDoors"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Main Street - Bottom Door",
                        Type = TransitionType.Blue,
                        CanLeaveCharged = new[] {
                            new RunwayCharge {
                                Length = 17,
                                OpenEnd = 0,
                                FramesRemaining = 90,
                                Strats = new[] {
                                    new Strat { Requires = null /*["Gravity"]*/ },
                                },
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - Main Street - Shinespark Item",
                        Type = PlacementType.Visible,
                    },
                    new Placement {
                        Name = "SM - Main Street - Tunnel Item",
                        Type = PlacementType.Visible,
                    },
                    new Junction {
                        Name = "SM - Main Street - Bottom Junction",
                    },
                    new Junction {
                        Name = "SM - Main Street - Middle Junction",
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Main Street - Bottom Door",
                        To = new[] {
                            new LinkTarget("SM - Main Street - Bottom Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Main Street - Bottom Right Door",
                        To = new[] {
                            new LinkTarget("SM - Main Street - Bottom Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Main Street - Middle Right Door",
                        To = new[] {
                            new LinkTarget("SM - Main Street - Shinespark Item", new[] {
                                new Strat {
                                    Name = "Shinespark",
                                    Requires = null,
                                    //[ "Gravity",
                                    //  {"canComeInCharged": {
                                    //    "fromNode": 3,
                                    //    "framesRemaining": 150,
                                    //    "shinesparkFrames": 50
                                    //  }}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Main Street - Bottom Junction"),
                            new LinkTarget("SM - Main Street - Middle Junction", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                new Strat {
                                    Name = "Suitless Jump Assists",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "HiJump",
                                    //  "canSpringBallJumpMidAir"
                                    //]
                                },
                                new Strat {
                                    Name = "Suitless Frozen Enemies",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "HiJump",
                                    //  "canUseFrozenEnemies"
                                    //]
                                },
                                new Strat {
                                    Name = "Main Street Mid Crab Climb",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "canCrabClimb"
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Main Street - Top Right Door",
                        To = new[] {
                            new LinkTarget("SM - Main Street - Middle Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Main Street - Morph Passage",
                        To = new[] {
                            new LinkTarget("SM - Main Street - Tunnel Item", new[] {
                            new Strat { Requires = null /*["Morph"]*/ },
                        }),
                        },
                    },
                    new Link {
                        From = "SM - Main Street - Shinespark Item",
                        To = new[] {
                            new LinkTarget("SM - Main Street - Middle Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Main Street - Tunnel Item",
                        To = new[] {
                            new LinkTarget("SM - Main Street - Morph Passage", new[] {
                                new Strat { Requires = null /*["Morph"]*/ },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Main Street - Bottom Junction",
                        To = new[] {
                            new LinkTarget("SM - Main Street - Bottom Door"),
                            new LinkTarget("SM - Main Street - Bottom Right Door"),
                            // The short charge actually has 2 steep up tiles, but one is against a
                            // wall so it was excluded.
                            new LinkTarget("SM - Main Street - Middle Right Door", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                new Strat {
                                    Name = "Suitless Jump Assists",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "HiJump",
                                    //  "canSpringBallJumpMidAir"
                                    //]
                                },
                                // It's possible to do consecutive walljumps off a frozen Skultera.
                                // That negates the need to user a super to freeze a Sciser in
                                // mid-air.
                                new Strat {
                                    Name = "Suitless Frozen Enemies",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "HiJump",
                                    //  "canUseFrozenEnemies"
                                    //]
                                },
                                // One super needed to freeze a Sciser in mid-air.
                                new Strat {
                                    Name = "Main Street Bottom Crab Climb",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "canCrabClimb",
                                    //  "Super",
                                    //  {"ammo": {
                                    //    "type": "Super",
                                    //    "count": 1
                                    //  }}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Main Street - Shinespark Item", new[] {
                                new Strat {
                                    Name = "Shinespark with Suit",
                                    Requires = null,
                                    //[ "Gravity",
                                    //  {"or": [
                                    //    {"canShineCharge": {
                                    //      "usedTiles": 17,
                                    //      "steepUpTiles": 1,
                                    //      "shinesparkFrames": 75,
                                    //      "openEnd": 0
                                    //    }},
                                    //    {"canComeInCharged": {
                                    //      "fromNode": 1,
                                    //      "inRoomPath": [1, 8],
                                    //      "framesRemaining": 80,
                                    //      "shinesparkFrames": 75
                                    //    }},
                                    //    {"canComeInCharged": {
                                    //      "fromNode": 2,
                                    //      "inRoomPath": [2, 8],
                                    //      "framesRemaining": 120,
                                    //      "shinesparkFrames": 75
                                    //    }}
                                    //  ]}
                                    //]
                                },
                                new Strat {
                                    Name = "Suitless Shinespark",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  {"or": [
                                    //    {"canComeInCharged": {
                                    //      "fromNode": 1,
                                    //      "inRoomPath": [1, 8],
                                    //      "framesRemaining": 120,
                                    //      "shinesparkFrames": 75
                                    //    }},
                                    //    {"canComeInCharged": {
                                    //      "fromNode": 2,
                                    //      "inRoomPath": [2, 8],
                                    //      "framesRemaining": 180,
                                    //      "shinesparkFrames": 75
                                    //    }}
                                    //  ]}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Main Street - Middle Junction",
                        To = new[] {
                            new LinkTarget("SM - Main Street - Middle Right Door"),
                            new LinkTarget("SM - Main Street - Top Right Door", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                new Strat {
                                    Name = "Suitless Jump Assists",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "HiJump",
                                    //  "canSpringBallJumpMidAir"
                                    //]
                                },
                                new Strat {
                                    Name = "Suitless Frozen Enemies",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "HiJump",
                                    //  "canUseFrozenEnemies"
                                    //]
                                },
                                // Two supers needed to freeze Scisers in mid-air.
                                new Strat {
                                    Name = "Main Street Top Crab Climb",
                                    Notable = true,
                                    Requires = null,
                                    //{"and": [
                                    //  "canSuitlessMaridia",
                                    //  "canCrabClimb",
                                    //  "Super",
                                    //  {"ammo": {
                                    //    "type": "Super",
                                    //    "count": 2
                                    //  }}
                                    //]}
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Main Street - Bottom Sciser",
                        EnemyName = "Sciser",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Main Street - Bottom Junction" },
                    },
                    new Enemy {
                        GroupName = "SM - Main Street - Bottom Skulteras",
                        EnemyName = "Skultera",
                        Quantity = 4,
                        BetweenNodes = new[] {
                            "SM - Main Street - Middle Right Door",
                            "SM - Main Street - Middle Junction",
                        },
                    },
                    new Enemy {
                        GroupName = "SM - Main Street - Bottom-Middle Sciser",
                        EnemyName = "Sciser",
                        Quantity = 2,
                        BetweenNodes = new[] {
                            "SM - Main Street - Middle Right Door",
                            "SM - Main Street - Middle Junction",
                        },
                    },
                    new Enemy {
                        GroupName = "SM - Main Street - Top Skultera",
                        EnemyName = "Skultera",
                        Quantity = 1,
                        BetweenNodes = new[] {
                            "SM - Main Street - Top Right Door",
                            "SM - Main Street - Middle Junction",
                        },
                    },
                    new Enemy {
                        GroupName = "SM - Main Street - Top Sciser",
                        EnemyName = "Sciser",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Main Street - Top Right Door" },
                    },
                    new Enemy {
                        GroupName = "SM - Main Street - Top-Middle Scisers",
                        EnemyName = "Sciser",
                        Quantity = 2,
                        BetweenNodes = new[] {
                            "SM - Main Street - Top Right Door",
                            "SM - Main Street - Middle Junction",
                        },
                    },
                    new Enemy {
                        GroupName = "SM - Main Street - Crab Supers Sciser",
                        EnemyName = "Sciser",
                        Quantity = 1,
                        HomeNodes = new[] {
                            "SM - Main Street - Morph Passage",
                            "SM - Main Street - Tunnel Item",
                        },
                    },
                },
            },
            #endregion
            #region Fish Tank
            new Room {
                Name = "SM - Fish Tank",
                Layout = Room.LayoutFrom(@"
                        2  3
                        ↓  ↓
                        XXXX
                        XXXX
                      1→XXXX←4"
                    , "SM - Fish Tank - Left Door"
                    , "SM - Fish Tank - Top Left Door"
                    , "SM - Fish Tank - Top Right Door"
                    , "SM - Fish Tank - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Fish Tank - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 0,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Fish Tank - Top Left Door",
                        Type = TransitionType.Blue,
                        SpawnAt = "SM - Fish Tank - Left Door",
                    },
                    new Transition {
                        Name = "SM - Fish Tank - Top Right Door",
                        Type = TransitionType.Blue,
                    },
                    new Transition {
                        Name = "SM - Fish Tank - Right Door",
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
                                Name = "SM - Fish Tank - Red Lock",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenRedDoors"]*/ },
                                },
                            },
                        },
                    },
                    new Junction {
                        Name = "SM - Fish Tank - Top Left Junction",
                    },
                    new Junction {
                        Name = "SM - Fish Tank - Middle Junction",
                    },
                    new Junction {
                        Name = "SM - Fish Tank - Top Right Junction",
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Fish Tank - Left Door",
                        To = new[] {
                            // This link mostly exists because it will become useful as an
                            // alternate to walljumping. IBJ can't be done from
                            // Top Left Junction to Top Left Door and must be directly from
                            // Left Door.
                            new LinkTarget("SM - Fish Tank - Top Left Door", new[] {
                                new Strat {
                                    Name = "IBJ",
                                    Requires = null,
                                    //[ "Gravity",
                                    //  "canIBJ"
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Fish Tank - Top Left Junction", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                new Strat {
                                    Name = "Suitless",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "canUseFrozenEnemies",
                                    //  "HiJump",
                                    //  "canSpringBallJumpMidAir"
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Fish Tank - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Fish Tank - Middle Junction", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                new Strat {
                                    Name = "Suitless",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "HiJump"
                                    //]
                                },
                                // The second jump is doable by combining a stationary mid-air mockball
                                // with a mid-air springball jump.
                                new Strat {
                                    Name = "Fish Tank SpringBall Escape",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "canStationaryMidAirMockball",
                                    //  "canSpringBallJumpMidAir"
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Fish Tank - Top Right Door",
                        To = new[] {
                            new LinkTarget("SM - Fish Tank - Top Right Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Fish Tank - Top Left Door",
                        To = new[] {
                            new LinkTarget("SM - Fish Tank - Left Door"),
                        },
                    },
                    new Link {
                        From = "SM - Fish Tank - Top Left Junction",
                        To = new[] {
                            new LinkTarget("SM - Fish Tank - Left Door"),
                            new LinkTarget("SM - Fish Tank - Top Left Door", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                new Strat {
                                    Name = "Suitless",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "canUseFrozenEnemies",
                                    //  {"or": [
                                    //    "HiJump",
                                    //    "canSpringBallJumpMidAir"
                                    //  ]}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Fish Tank - Middle Junction", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                new Strat {
                                    Name = "Suitless",
                                    Requires = null, // ["canSuitlessMaridia"]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Fish Tank - Middle Junction",
                        To = new[] {
                            new LinkTarget("SM - Fish Tank - Right Door"),
                            new LinkTarget("SM - Fish Tank - Top Left Junction", new[] {
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
                            new LinkTarget("SM - Fish Tank - Top Right Junction", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                new Strat {
                                    Name = "Suitless Jump Assists",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  {"or": [
                                    //    "HiJump",
                                    //    "canSpringBallJumpMidAir"
                                    //  ]}
                                    //]
                                },
                                new Strat {
                                    Name = "Suitless Frozen Pirate",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "Plasma",
                                    //  "canUseFrozenEnemies"
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Fish Tank - Top Right Junction",
                        To = new[] {
                            new LinkTarget("SM - Fish Tank - Top Right Door", new[] {
                                new Strat { Requires = null, /*["Gravity"]*/ },
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
                            new LinkTarget("SM - Fish Tank - Middle Junction", new[] {
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
                        GroupName = "SM - Fish Tank - Bottom Skultera",
                        EnemyName = "Skultera",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Fish Tank - Left Door" },
                    },
                    new Enemy {
                        GroupName = "SM - Fish Tank - Top Left Skultera",
                        EnemyName = "Skultera",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Fish Tank - Top Left Junction" },
                    },
                    new Enemy {
                        GroupName = "SM - Fish Tank - Central Skultera",
                        EnemyName = "Skultera",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Fish Tank - Middle Junction" },
                    },
                    new Enemy {
                        GroupName = "SM - Fish Tank - Top Right Skultera",
                        EnemyName = "Skultera",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Fish Tank - Top Right Junction" },
                    },
                    new Enemy {
                        GroupName = "SM - Fish Tank - Bottom Pirate",
                        EnemyName = "Pink Space Pirate (standing)",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Fish Tank - Right Door" },
                    },
                    new Enemy {
                        GroupName = "SM - Fish Tank - Central Pirate",
                        EnemyName = "Pink Space Pirate (standing)",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Fish Tank - Middle Junction" },
                    },
                    new Enemy {
                        GroupName = "SM - Fish Tank - Top Right Pirate",
                        EnemyName = "Pink Space Pirate (standing)",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Fish Tank - Top Right Junction" },
                    },
                },
            },
            #endregion
            #region Mt. Everest
            new Room {
                Name = "SM - Mt. Everest",
                Layout = Room.LayoutFrom(@"
                          3
                          ↓
                      2→XXXXXX←4
                        XXXXXX
                      1→XXXXX
                         XXXX
                         ↑  ↑
                         6  5"
                    , "SM - Mt. Everest - Morph Passage"
                    , "SM - Mt. Everest - Left Door"
                    , "SM - Mt. Everest - Top Door"
                    , "SM - Mt. Everest - Right Door"
                    , "SM - Mt. Everest - Bottom Right Door"
                    , "SM - Mt. Everest - Bottom Left Door"
                ),
                Nodes = new Node[] {
                    // It's not quite a door, but it is a morph passage transition to another room.
                    new Transition {
                        Name = "SM - Mt. Everest - Morph Passage",
                        Type = TransitionType.Passage,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 0,
                                OpenEnd = 0,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Mt. Everest - Left Door",
                        Type = TransitionType.Blue,
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
                    },
                    new Transition {
                        Name = "SM - Mt. Everest - Top Door",
                        Type = TransitionType.Blue,
                        SpawnAt = "SM - Mt. Everest - Top Door Junction",
                        CanLeaveCharged = new[] {
                            // In reality, you'd drop down to Bottom Left Door to charge and then
                            // spark out. Initiates at Top Door Junction rather than
                            // Bottom Left Door because dropping to Bottom Left Door is expected to
                            // be free, and because you need to be at Top Door Junction to open the
                            // door first. MustOpenDoorFirst is still set to false because the door
                            // can be opened from Top Door Junction, no need to actually go to
                            // Top Door. Shinespark frames are 0 because those are covered by the
                            // Shinespark strat from Top Door Junction to Top Door.
                            new RunwayCharge {
                                Length = 33,
                                FramesRemaining = 0,
                                ShinesparkFrames = 0,
                                OpenEnd = 2,
                                InitiateRemotely = new() {
                                    InitiateAt = "SM - Mt. Everest - Top Door Junction",
                                    MustOpenDoorFirst = false,
                                    PathToDoor = new[] {
                                        new PathStep("SM - Mt. Everest - Top Door", new[] { "Shinespark" }),
                                    },
                                },
                                Strats = new[] {
                                    new Strat { Requires = null /*["Gravity"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Mt. Everest - Right Door",
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
                        Name = "SM - Mt. Everest - Bottom Right Door",
                        Type = TransitionType.Blue,
                        CanLeaveCharged = new[] {
                            // Charge at Right Ledge Junction, and store the spark as you're
                            // walking off the ledge to drop down onto the door. It's possible to
                            // get 40 frames remaining by opening the door first and dropping with
                            // a moonfall, but is it worth putting here?
                            new RunwayCharge {
                                Length = 20,
                                FramesRemaining = 30,
                                OpenEnd = 1,
                                InitiateRemotely = new() {
                                    InitiateAt = "SM - Mt. Everest - Right Ledge Junction",
                                    MustOpenDoorFirst = false,
                                    PathToDoor = new[] {
                                        new PathStep("SM - Mt. Everest - Lower Hills Junction", new[] { "Base" }),
                                        new PathStep("SM - Mt. Everest - Bottom Right Door", new[] { "Base" }),
                                    },
                                },
                                Strats = new[] {
                                    new Strat {
                                        Name = "Mt. Everest Bottom Right Charged Drop",
                                        Notable = true,
                                        Requires = null, // ["Gravity"]
                                    },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Mt. Everest - Bottom Left Door",
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
                    new Junction {
                        Name = "SM - Mt. Everest - Top Door Junction",
                    },
                    new Junction {
                        Name = "SM - Mt. Everest - Left Ledge Junction",
                    },
                    new Junction {
                        Name = "SM - Mt. Everest - Higher Hills Junction",
                    },
                    new Junction {
                        Name = "SM - Mt. Everest - Lower Hills Junction",
                    },
                    new Junction {
                        Name = "SM - Mt. Everest - Right Ledge Junction",
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Mt. Everest - Left Door",
                        To = new[] {
                            // Shinespark direct link.
                            new LinkTarget("SM - Mt. Everest - Right Door", new[] {
                                new Strat {
                                    Name = "Shinespark",
                                    Requires = null,
                                    //[ "h_canNavigateUnderwater",
                                    //  {"canComeInCharged":{
                                    //    "fromNode": 1,
                                    //    "framesRemaining": 0,
                                    //    "shinesparkFrames": 150
                                    //  }}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Mt. Everest - Top Door Junction", new[] {
                                new Strat {
                                    Name = "Grapple",
                                    Requires = null,
                                    //[ "h_canNavigateUnderwater",
                                    //  "Grapple"
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Mt. Everest - Left Ledge Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Mt. Everest - Bottom Left Door",
                        To = new[] {
                            // One-way link for shinesparking.
                            new LinkTarget("SM - Mt. Everest - Left Door", new[] {
                                new Strat {
                                    Name = "Shinespark",
                                    Requires = null,
                                    //[ "h_canNavigateUnderwater",
                                    //  {"canComeInCharged":{
                                    //    "fromNode": 2,
                                    //    "framesRemaining": 0,
                                    //    "shinesparkFrames": 60
                                    //  }}
                                    //]
                                },
                            }),
                            // One-way link for shinesparking.
                            new LinkTarget("SM - Mt. Everest - Right Door", new[] {
                                new Strat {
                                    Name = "Shinespark",
                                    Requires = null,
                                    //[ "Gravity",
                                    //  {"canShineCharge": {
                                    //    "usedTiles": 33,
                                    //    "shinesparkFrames": 65,
                                    //    "openEnd": 2
                                    //  }}
                                    //]
                                },
                            }),
                            // One-way link for shinesparking.
                            new LinkTarget("SM - Mt. Everest - Top Door Junction", new[] {
                                new Strat {
                                    Name = "Shinespark",
                                    Requires = null,
                                    //[ "Gravity",
                                    //  {"canShineCharge": {
                                    //    "usedTiles": 33,
                                    //    "shinesparkFrames": 61,
                                    //    "openEnd": 2
                                    //  }}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Mt. Everest - Lower Hills Junction", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                new Strat {
                                    Name = "Suitless Jump Assists",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "HiJump",
                                    //  "canSpringBallJumpMidAir"
                                    //]
                                },
                                new Strat {
                                    Name = "Suitless Frozen Sciser",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "canUseFrozenEnemies"
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Mt. Everest - Bottom Right Door",
                        To = new[] {
                            new LinkTarget("SM - Mt. Everest - Lower Hills Junction", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                new Strat {
                                    Name = "Suitless Jump assists",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "HiJump",
                                    //  "canSpringBallJumpMidAir"
                                    //]
                                },
                            }),
                            // One-way link for diagonal suitless shinesparking.
                            new LinkTarget("SM - Mt. Everest - Top Door Junction", new[] {
                                // This is suitless only, because with Gravity, another path allows
                                // actual access to Top Door instead. That path goes
                                // Bottom Right Door -> Lower Hills Junction -> Bottom Left Door ->
                                // Top Door.
                                new Strat {
                                    Name = "Shinespark",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  {"canComeInCharged":{
                                    //    "fromNode": 3,
                                    //    "framesRemaining": 0,
                                    //    "shinesparkFrames": 70
                                    //  }}
                                    //]
                                },
                            }),
                            // One-way link for Shinesparking.
                            new LinkTarget("SM - Mt. Everest - Right Ledge Junction", new[] {
                                new Strat {
                                    Name = "Shinespark",
                                    Requires = null,
                                    //[ "h_canNavigateUnderwater",
                                    //  {"canComeInCharged":{
                                    //    "fromNode": 3,
                                    //    "framesRemaining": 0,
                                    //    "shinesparkFrames": 65
                                    //  }}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Mt. Everest - Right Door",
                        To = new[] {
                            // Suitless shinespark direct link.
                            new LinkTarget("SM - Mt. Everest - Left Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateUnderwater",
                                    //  {"canComeInCharged":{
                                    //    "fromNode": 4,
                                    //    "framesRemaining": 0,
                                    //    "shinesparkFrames": 150
                                    //  }}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Mt. Everest - Top Door Junction", new[] {
                                new Strat {
                                    Name = "Grapple",
                                    Requires = null,
                                    //[ "h_canNavigateUnderwater",
                                    //  "Grapple"
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Mt. Everest - Right Ledge Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Mt. Everest - Top Door",
                        To = new[] {
                            new LinkTarget("SM - Mt. Everest - Top Door Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Mt. Everest - Morph Passage",
                        To = new[] {
                            new LinkTarget("SM - Mt. Everest - Bottom Left Door", new[] {
                                new Strat { Requires = null /*["Morph"]*/ },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Mt. Everest - Lower Hills Junction",
                        To = new[] {
                            new LinkTarget("SM - Mt. Everest - Bottom Left Door"),
                            new LinkTarget("SM - Mt. Everest - Bottom Right Door"),
                            new LinkTarget("SM - Mt. Everest - Higher Hills Junction", new[] {
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
                                new Strat {
                                    Name = "Suitless Frozen Crab",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "canUseFrozenEnemies"
                                    //]
                                },
                                // Requires canUseEnemies because this wouldn't work without the
                                // Powamp being there.
                                new Strat {
                                    Name = "Grapple Powamp",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "canUseEnemies",
                                    //  "Grapple"
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Mt. Everest - Right Ledge Junction", new[] {
                                new Strat { Requires = null /*["canGravityJump"]*/ },
                                // There is a ridiculously precise, but possible, walljump to get
                                // up there.
                                new Strat {
                                    Name = "Mt. Everest Insane Walljump",
                                    Notable = true,
                                    Requires = null,
                                    //[ "Gravity",
                                    //  "HiJump",
                                    //  "canInsaneWalljump"
                                    //]
                                },
                                // The run and jump is done from the left peak of
                                // Lower Hills Junction, not the right one.
                                new Strat {
                                    Name = "Mt. Everest Dash Jump",
                                    Notable = true,
                                    Requires = null,
                                    //[ "Gravity",
                                    //  "HiJump",
                                    //  "canTrickyDashJump",
                                    //  "canWalljump"
                                    //]
                                },
                                new Strat {
                                    Name = "CanFly",
                                    Requires = null,
                                    //[ "Gravity",
                                    //  "h_canFly"
                                    //]
                                },
                                // Requires canUseEnemies because this wouldn't work without the
                                // Powamp being there.
                                new Strat {
                                    Name = "Grapple Powamp",
                                    Requires = null,
                                    //[ "h_canNavigateUnderwater",
                                    //  "canUseEnemies",
                                    //  "Grapple"
                                    //]
                                },
                                // Requires one Super to do mid-air freezing.
                                new Strat {
                                    Name = "Mt. Everest Bottom Crab Climb",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "canCrabClimb",
                                    //  "Super",
                                    //  {"ammo": {
                                    //    "type": "Super",
                                    //    "count": 1
                                    //  }}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Mt. Everest - Higher Hills Junction",
                        To = new[] {
                            new LinkTarget("SM - Mt. Everest - Morph Passage", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateUnderwater",
                                    //  "Morph"
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Mt. Everest - Lower Hills Junction"),
                            new LinkTarget("SM - Mt. Everest - Left Ledge Junction", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                // Requires canUseEnemies because this wouldn't work without the
                                // Powamp being there. No version with Gravity because Gravity
                                // alone already gets you there.
                                new Strat {
                                    Name = "Grapple Powamp",
                                    //Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "canUseEnemies",
                                    //  "Grapple"
                                    //]
                                },
                                new Strat {
                                    Name = "Suitless Jump Assists",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "HiJump",
                                    //  "canSpringBallJumpMidAir"
                                    //]
                                },
                                new Strat {
                                    Name = "Suitless Frozen Sciser",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "HiJump",
                                    //  "canUseFrozenEnemies"
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Mt. Everest - Top Door Junction",
                        To = new[] {
                            // Direct link for shinespark and grapple.
                            new LinkTarget("SM - Mt. Everest - Left Door", new[] {
                                new Strat {
                                    Name = "Shinespark",
                                    Requires = null,
                                    //[ "h_canNavigateUnderwater",
                                    //  {"canComeInCharged":{
                                    //    "fromNode": 5,
                                    //    "inRoomPath": [5, 9],
                                    //    "framesRemaining": 90,
                                    //    "shinesparkFrames": 65
                                    //  }}
                                    //]
                                },
                                new Strat {
                                    Name = "Grapple",
                                    Requires = null,
                                    //[ "h_canNavigateUnderwater",
                                    //  "Grapple"
                                    //]
                                },
                            }),
                            // Direct link for shinespark and grapple.
                            new LinkTarget("SM - Mt. Everest - Right Door", new[] {
                                new Strat {
                                    Name = "Shinespark",
                                    Requires = null,
                                    //[ "h_canNavigateUnderwater",
                                    //  {"canComeInCharged":{
                                    //    "fromNode": 5,
                                    //    "inRoomPath": [5, 9],
                                    //    "framesRemaining": 90,
                                    //    "shinesparkFrames": 90
                                    //  }}
                                    //]
                                },
                                new Strat {
                                    Name = "Grapple",
                                    Requires = null,
                                    //[ "h_canNavigateUnderwater",
                                    //  "Grapple"
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Mt. Everest - Top Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "Gravity",
                                    //  {"or":[
                                    //    "HiJump",
                                    //    "canSpringBallJumpMidAir",
                                    //    "h_canFly"
                                    //  ]}
                                    //]
                                },
                                new Strat {
                                    Name = "Grapple",
                                    Requires = null,
                                    //[ "h_canNavigateUnderwater",
                                    //  "Grapple"
                                    //]
                                },
                                new Strat {
                                    Name = "Suitless Jump Assists",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "HiJump",
                                    //  "canSpringBallJumpMidAir"
                                    //]
                                },
                                // Implicitly drops down to Bottom Left Door first. There is no
                                // link directly from Bottom Left Door to Top Door because the door
                                // must be opened first. So, you'd shinespark from Bottom Left Door
                                // to Top Door Junction, open the door, drop down, and shinespark
                                // again. In the model, that'll be represented by going
                                // Bottom Left Door -> Top Door Junction -> Top Door via two
                                // shinespark strats.
                                new Strat {
                                    Name = "Shinespark",
                                    Requires = null,
                                    //[ "Gravity",
                                    //  {"canShineCharge": {
                                    //    "usedTiles": 33,
                                    //    "shinesparkFrames": 61,
                                    //    "openEnd": 2
                                    //  }}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Mt. Everest - Left Ledge Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Mt. Everest - Right Ledge Junction",
                        To = new[] {
                            new LinkTarget("SM - Mt. Everest - Right Door", new[] {
                                new Strat { Requires = null /*["canGravityJump"]*/ },
                                new Strat {
                                    Name = "CanFly",
                                    Requires = null,
                                    //[ "Gravity",
                                    //  "h_canFly"
                                    //]
                                },
                                new Strat {
                                    Name = "Suited Grapple",
                                    Requires = null,
                                    //[ "Gravity",
                                    //  "Grapple"
                                    //]
                                },
                                new Strat {
                                    Name = "Mt. Everest Top Walljump",
                                    Notable = true,
                                    Requires = null,
                                    //[ "Gravity",
                                    //  "canPreciseWalljump"
                                    //]
                                },
                                // This strat uses the grapple blocks at the top left, not the Powamp.
                                // The blocks are technically reachable without a jump assist, but it's
                                // very finicky so it's excluded. Failure also doesn't usually allow a
                                // second try (assuming the Powamp is not there).
                                new Strat {
                                    Name = "Suitless Grapple",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "Grapple",
                                    //  {"or":[
                                    //    "HiJump",
                                    //    "canSpringBallJumpMidAir"
                                    //  ]}
                                    //]
                                },
                                // Requires canUseEnemies because this wouldn't work without the Powamp
                                // being there.
                                new Strat {
                                    Name = "Suitless Powamp Grapple",
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "canUseEnemies",
                                    //  "Grapple"
                                    //]
                                },
                                // Requires one Super for mid-air freezing.
                                new Strat {
                                    Name = "Mt. Everest Top Crab Climb",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canSuitlessMaridia",
                                    //  "canCrabClimb",
                                    //  "Super",
                                    //  {"ammo": {
                                    //    "type": "Super",
                                    //    "count": 1
                                    //  }}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Mt. Everest - Lower Hills Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Mt. Everest - Left Ledge Junction",
                        To = new[] {
                            // No Powamp grapple strat because that is covered by
                            // Left Ledge Junction -> Top Door Junction -> Left Door.
                            new LinkTarget("SM - Mt. Everest - Left Door", new[] {
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
                            }),
                            new LinkTarget("SM - Mt. Everest - Higher Hills Junction"),
                            new LinkTarget("SM - Mt. Everest - Top Door Junction", new[] {
                                // Technically an IBJ would have to be done from Higher Hills Junction,
                                // but it's here instead on the basis that Left Ledge Junction ->
                                // Higher Hills Junction has no reqs, in order to make pathing more
                                // linear.
                                new Strat {
                                    Name = "CanFly",
                                    Requires = null,
                                    //[ "Gravity",
                                    //  "h_canFly"
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
                                new Strat { Requires = null /*["canGravityJump"]*/ },
                                // Requires canUseEnemies because this wouldn't work without the Powamp
                                // being there.
                                new Strat {
                                    Name = "Powamp Grapple",
                                    Requires = null,
                                    //[ "h_canNavigateUnderwater",
                                    //  "canUseEnemies",
                                    //  "Grapple"
                                    //]
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Mt. Everest - Left Powamp",
                        EnemyName = "Powamp",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Mt. Everest - Higher Hills Junction" },
                        DropRequires = null,
                        //[ "Gravity",
                        //  {"or": [
                        //    "Grapple",
                        //    "HiJump",
                        //    "SpaceJump",
                        //    "canSpringBallJump",
                        //    "canGravityJump"
                        //  ]}
                        //]
                    },
                    new Enemy {
                        GroupName = "SM - Mt. Everest - Right Powamps",
                        EnemyName = "Powamp",
                        Quantity = 2,
                        HomeNodes = new[] { "SM - Mt. Everest - Lower Hills Junction" },
                        DropRequires = null,
                        //[ "Gravity",
                        //  {"or": [
                        //    "Grapple",
                        //    "HiJump",
                        //    "SpaceJump",
                        //    "canSpringBallJump",
                        //    "canGravityJump"
                        //  ]}
                        //]
                    },
                    new Enemy {
                        GroupName = "SM - Mt. Everest - Bottom Left Scisers",
                        EnemyName = "Sciser",
                        Quantity = 2,
                        HomeNodes = new[] { "SM - Mt. Everest - Bottom Left Door" },
                    },
                    new Enemy {
                        GroupName = "SM - Mt. Everest - Bottom Right Sciser",
                        EnemyName = "Sciser",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Mt. Everest - Bottom Right Door" },
                    },
                    new Enemy {
                        GroupName = "SM - Mt. Everest - Bottom Middle-Left Sciser",
                        EnemyName = "Sciser",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Mt. Everest - Morph Passage" },
                    },
                    // It crawls around the tallest of the three hills.
                    new Enemy {
                        GroupName = "SM - Mt. Everest - Bottom Middle Sciser",
                        EnemyName = "Sciser",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Mt. Everest - Higher Hills Junction" },
                    },
                },
            },
            #endregion
            #region Crab Tunnel
            new Room {
                Name = "SM - Crab Tunnel",
                Layout = Room.LayoutFrom(@"
                      1→XXXX←2"
                    , "SM - Crab Tunnel - Left Door"
                    , "SM - Crab Tunnel - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Crab Tunnel - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 12,
                                GentleUpTiles = 2,
                                SteepUpTiles = 2,
                                SteepDownTiles = 1,
                                OpenEnd = 0,
                                Strats = new[] {
                                    new Strat { Requires = null /*["Gravity"]*/ },
                                },
                            },
                            // With Gate Open.
                            new RunwayDash {
                                Length = 33,
                                UsableComingIn = false,
                                OpenEnd = 1,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null, // ["Gravity"]
                                        Obstacles = new[] {
                                            new Strat.Obstacle {
                                                Name = "Green Gate",
                                                Requires = null, // ["h_canOpenGreenDoors"]
                                            },
                                        },
                                    },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Crab Tunnel - Right Door",
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
                                FramesRemaining = 120,
                                OpenEnd = 2,
                                Strats = new[] {
                                    new Strat { Requires = null /*["Gravity"]*/ },
                                },
                            },
                        },
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
                        From = "SM - Crab Tunnel - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Crab Tunnel - Right Door", new[] {
                                new Strat {
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Green Gate",
                                            Requires = null, // ["h_canOpenGreenDoors"]
                                        },
                                    },
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Crab Tunnel - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Crab Tunnel - Left Door", new[] {
                                new Strat {
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Green Gate",
                                            Requires = null, // ["canGGG"]
                                        },
                                    },
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "Crab Tunnel Left Sciser",
                        EnemyName = "Sciser",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Crab Tunnel - Left Door" },
                    },
                    new Enemy {
                        GroupName = "Crab Tunnel Right Scisers",
                        EnemyName = "Sciser",
                        Quantity = 5,
                        HomeNodes = new[] { "SM - Crab Tunnel - Right Door" },
                    },
                },
            },
            #endregion
            #region Red Fish Room
            new Room {
                Name = "SM - Red Fish Room",
                Layout = Room.LayoutFrom(@"
                      1→XXX
                          X
                          ↑
                          2"
                    , "SM - Red Fish Room - Left Door"
                    , "SM - Red Fish Room - Bottom Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Red Fish Room - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 6,
                                OpenEnd = 1,
                                Strats = new[] {
                                    new Strat { Requires = null /*["Gravity"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Red Fish Room - Bottom Door",
                        Type = TransitionType.Blue,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Red Fish Room - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Red Fish Room - Bottom Door", new[] {
                                new Strat { Requires = null /*["Morph"]*/ },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Red Fish Room - Bottom Door",
                        To = new[] {
                            new LinkTarget("SM - Red Fish Room - Left Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "Morph",
                                    //  "Gravity"
                                    //]
                                },
                                new Strat {
                                    Name = "Suitless Jump Assists",
                                    Requires = null,
                                    //[ "Morph",
                                    //  "canSuitlessMaridia",
                                    //  "HiJump",
                                    //  "canSpringBallJumpMidAir"
                                    //]
                                },
                                new Strat {
                                    Name = "Suitless Frozen Skultera",
                                    Requires = null,
                                    //[ "Morph",
                                    //  "canSuitlessMaridia",
                                    //  "canUseFrozenEnemies"
                                    //]
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Red Fish Room - Zebbos",
                        EnemyName = "Zebbo",
                        Quantity = 3,
                        HomeNodes = new[] { "SM - Red Fish Room - Left Door" },
                        FarmCycles = new[] {
                            // Run back and forth from the door to the spawner, alternately spawning and killing 1 Zebbo then 2.
                            new FarmCycle {
                                Name = "3 Zebbos power beam desync",
                                CycleFrames = 260,
                            },
                            new FarmCycle {
                                Name = "Screw attack same spawn 3 enemies",
                                CycleFrames = 180,
                                Requires = null, // ["ScrewAttack"]
                            },
                            new FarmCycle {
                                Name = "Farm top of 3 Zebbos",
                                CycleFrames = 180,
                                Requires = null,
                                //{"or": [
                                //  "Wave",
                                //  "Spazer",
                                //  "Plasma",
                                //  "Grapple"
                                //]}
                            },
                        },
                    },
                    new Enemy {
                        GroupName = "SM - Red Fish Room - Red Fish",
                        EnemyName = "Skultera",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Red Fish Room - Bottom Door" },
                    },
                },
            },
            #endregion
            #region Mama Turtle Room
            new Room {
                Name = "SM - Mama Turtle Room",
                Layout = Room.LayoutFrom(@"
                         XX
                         XX
                         XX
                      1→XXX"
                    , "SM - Mama Turtle Room - Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Mama Turtle Room - Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 18,
                                GentleDownTiles = 2,
                                OpenEnd = 1,
                                Strats = new[] {
                                    new Strat { Requires = null /*["Gravity"]*/ },
                                },
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - Mama Turtle Room - Prize Item",
                        Type = PlacementType.Visible,
                    },
                    new Placement {
                        Name = "SM - Mama Turtle Room - In Wall Item",
                        Type = PlacementType.Hidden,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Mama Turtle Room - Door",
                        To = new[] {
                            new LinkTarget("SM - Mama Turtle Room - Prize Item", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateUnderwater",
                                    //  "Grapple"
                                    //]
                                },
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateUnderwater",
                                    //  "SpaceJump"
                                    //]
                                },
                                new Strat {
                                    Name = "Mama Turtle IBJ",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateUnderwater",
                                    //  "canIBJ"
                                    //]
                                },
                                new Strat {
                                    Name = "Charge Outside",
                                    Requires = null,
                                    //[ "Gravity",
                                    //  {"canComeInCharged":{
                                    //    "fromNode": 1,
                                    //    "framesRemaining": 110,
                                    //    "shinesparkFrames": 60
                                    //  }}
                                    //]
                                },
                                // All this essentially give is the ability to do a 22-tile charge
                                // instead of 18 or so in-room. Is it worth a complex strat? This
                                // involves getting all baby turtles to the edge of the pit so you
                                // can take a hit off mama then short charge.
                                new Strat {
                                    Name = "Turtle Herding Shinespark",
                                    Requires = null,
                                    //[ "Gravity",
                                    //  "canHerdBabyTurtles",
                                    //  {"enemyDamage": {
                                    //    "enemy": "Kame (Tatori)",
                                    //    "type": "contact",
                                    //    "hits": 1
                                    //  }},
                                    //  {"canShineCharge": {
                                    //    "usedTiles": 22,
                                    //    "shinesparkFrames": 65,
                                    //    "openEnd": 0
                                    //  }}
                                    //]
                                },
                                new Strat {
                                    Name = "Jump Assists",
                                    Requires = null,
                                    //[ "h_canNavigateUnderwater",
                                    //  "HiJump",
                                    //  "canSpringBallJumpMidAir"
                                    //]
                                },
                                new Strat {
                                    Name = "Mama Turtle Springwall",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateUnderwater",
                                    //  "canSpringwall"
                                    //]
                                },
                                // Not sure if this should have its own tech? Have to do a running
                                // stationary spinjump from a precise spot, to do a delayed
                                // walljump with slightly more speed off the wall one tile further
                                // out. This makes it possible to just barely walljump off the
                                // grapple block.
                                new Strat {
                                    Name = "Mama Turtle Insane Walljump",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateUnderwater",
                                    //  "HiJump",
                                    //  "canStationarySpinJump",
                                    //  "canInsaneWalljump"
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Mama Turtle Room - In Wall Item", new[] {
                                new Strat { Requires = null /*["Gravity"]*/ },
                                new Strat { Requires = null /*["canSuitlessMaridia"]*/ },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Mama Turtle Room - Prize Item",
                        To = new[] {
                            new LinkTarget("SM - Mama Turtle Room - Door"),
                        },
                    },
                    new Link {
                        From = "SM - Mama Turtle Room - In Wall Item",
                        To = new[] {
                            new LinkTarget("SM - Mama Turtle Room - Door"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Mama Turtle Room - Mama Turtle",
                        EnemyName = "Kame (Tatori)",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Mama Turtle Room - Door" },
                    },
                    new Enemy {
                        GroupName = "SM - Mama Turtle Room - Baby Turtles",
                        EnemyName = "Kame Baby",
                        Quantity = 4,
                        HomeNodes = new[] { "SM - Mama Turtle Room - Door" },
                    },
                },
            },
            #endregion
            #region Boyon Gate Hall
            new Room {
                Name = "SM - Boyon Gate Hall",
                Layout = Room.LayoutFrom(@"
                        XXXX←2
                      1→X←3"
                    , "SM - Boyon Gate Hall - Left Door"
                    , "SM - Boyon Gate Hall - Top Right Door"
                    , "SM - Boyon Gate Hall - Bottom Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Boyon Gate Hall - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 12,
                                OpenEnd = 0,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Boyon Gate Hall - Top Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 7,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Boyon Gate Hall - Bottom Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 12,
                                OpenEnd = 0,
                            },
                        },
                    },
                    new Junction {
                        Name = "SM - Boyon Gate Hall - Top Left Junction",
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Boyon Gate Hall - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Boyon Gate Hall - Bottom Right Door"),
                            new LinkTarget("SM - Boyon Gate Hall - Top Left Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Boyon Gate Hall - Bottom Right Door",
                        To = new[] {
                            new LinkTarget("SM - Boyon Gate Hall - Left Door"),
                        },
                    },
                    new Link {
                        From = "SM - Boyon Gate Hall - Top Right Door",
                        To = new[] {
                            new LinkTarget("SM - Boyon Gate Hall - Top Left Junction", new[] {
                                new Strat { Requires = null /*["h_canOpenGreenDoors"]*/ },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Boyon Gate Hall - Top Left Junction",
                        To = new[] {
                            new LinkTarget("SM - Boyon Gate Hall - Left Door"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Boyon Gate Hall - Left Boyon",
                        EnemyName = "Boyon",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Boyon Gate Hall - Top Left Junction" },
                    },
                    new Enemy {
                        GroupName = "SM - Boyon Gate Hall - Right Boyons",
                        EnemyName = "Boyon",
                        Quantity = 6,
                        HomeNodes = new[] { "SM - Boyon Gate Hall - Top Right Door" },
                    },
                    new Enemy {
                        GroupName = "SM - Boyon Gate Hall - Left Zebbo",
                        EnemyName = "Zebbo",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Boyon Gate Hall - Top Left Junction" },
                        FarmCycles = new[] {
                            new FarmCycle {
                                Name = "Jump two tiles above spawn point",
                                CycleFrames = 130,
                            },
                        },
                    },
                    new Enemy {
                        GroupName = "SM - Boyon Gate Hall - Middle Zebbo",
                        EnemyName = "Zebbo",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Boyon Gate Hall - Top Left Junction" },
                        FarmCycles = new[] {
                            new FarmCycle {
                                Name = "Jump two tiles above spawn point",
                                CycleFrames = 130,
                            },
                        },
                    },
                    new Enemy {
                        GroupName = "SM - Boyon Gate Hall - Right Zebbo",
                        EnemyName = "Zebbo",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Boyon Gate Hall - Top Left Junction" },
                        FarmCycles = new[] {
                            new FarmCycle {
                                Name = "Jump two tiles above spawn point",
                                CycleFrames = 130,
                            },
                        },
                    },
                },
            },
            #endregion
            #region Crab Hole
            new Room {
                Name = "SM - Crab Hole",
                Layout = Room.LayoutFrom(@"
                      2→X←3
                      1→X←4"
                    , "SM - Crab Hole - Bottom Left Door"
                    , "SM - Crab Hole - Top Left Door"
                    , "SM - Crab Hole - Top Right Door"
                    , "SM - Crab Hole - Bottom Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Crab Hole - Bottom Left Door",
                        Type = TransitionType.Blue,
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
                    },
                    new Transition {
                        Name = "SM - Crab Hole - Top Left Door",
                        Type = TransitionType.Doorway,
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
                        Name = "SM - Crab Hole - Top Right Door",
                        Type = TransitionType.Doorway,
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
                        Name = "SM - Crab Hole - Bottom Right Door",
                        Type = TransitionType.Red,
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
                                Name = "SM - Crab Hole - Red Lock",
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
                        From = "SM - Crab Hole - Top Left Door",
                        To = new[] {
                            new LinkTarget("SM - Crab Hole - Bottom Left Door", new[] {
                                new Strat { Requires = null /*["Morph"]*/ },
                            }),
                            new LinkTarget("SM - Crab Hole - Top Right Door"),
                        },
                    },
                    new Link {
                        From = "SM - Crab Hole - Bottom Left Door",
                        To = new[] {
                            new LinkTarget("SM - Crab Hole - Top Left Door", new[] {
                                new Strat {
                                    Name = "Gravity Jump",
                                    Requires = null,
                                    //[ "Morph",
                                    //  "canGravityJump"
                                    //]
                                },
                                new Strat {
                                    Name = "CanFly",
                                    Requires = null,
                                    //[ "Morph",
                                    //  "Gravity",
                                    //  "h_canFly"
                                    //]
                                },
                                new Strat {
                                    Name = "Suited HiJump",
                                    Requires = null,
                                    //[ "Morph",
                                    //  "Gravity",
                                    //  "HiJump"
                                    //]
                                },
                                // The easiest way is probably to freeze a crab on the end of the
                                // ceiling, top walljump off it. Then it's possible to stand on it
                                // for an easy mid-air morph.
                                new Strat {
                                    Name = "Suited Frozen Sciser",
                                    Requires = null,
                                    //[ "Morph",
                                    //  "Gravity",
                                    //  "canUseFrozenEnemies"
                                    //]
                                },
                                new Strat {
                                    Name = "Crab Hole Left-Side X-Ray Climb",
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
                                // Stand on a frozen crab, then freeze a second one on the edge of
                                // the hole. It's reachable with crouch jump + downgrab.
                                new Strat {
                                    Name = "Suitless HiJump Crab Hole Ascent",
                                    Notable = true,
                                    Requires = null,
                                    //[ "Morph",
                                    //  "canSuitlessMaridia",
                                    //  "canUseFrozenEnemies",
                                    //  "HiJump"
                                    //]
                                },
                                // Similar to the HiJump version. But instead of standing on a crab
                                // on the floor, requires a Super for mid-air freezing.
                                new Strat {
                                    Name = "Suitless Springball Crab Hole Ascent",
                                    Notable = true,
                                    Requires = null,
                                    //[ "Morph",
                                    //  "canSuitlessMaridia",
                                    //  "Super",
                                    //  {"ammo": {
                                    //    "type": "Super",
                                    //    "count": 1
                                    //  }},
                                    //  "canUseFrozenEnemies",
                                    //  "canSpringBallJumpMidAir"
                                    //]
                                },
                                // Needs a Super for mid-air freezing. Then get on that crab,
                                // possibly using a door ledge, and freeze a second crab on the
                                // edge of the wall to get on top of it.
                                new Strat {
                                    Name = "Crab Hole Crab Climb",
                                    Notable = true,
                                    Requires = null,
                                    //[ "Morph",
                                    //  "canSuitlessMaridia",
                                    //  "Super",
                                    //  {"ammo": {
                                    //    "type": "Super",
                                    //    "count": 1
                                    //  }},
                                    //  "canCrabClimb"
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Crab Hole - Bottom Right Door"),
                        },
                    },
                    new Link {
                        From = "SM - Crab Hole - Bottom Right Door",
                        To = new[] {
                            new LinkTarget("SM - Crab Hole - Bottom Left Door"),
                        },
                    },
                    new Link {
                        From = "SM - Crab Hole - Top Right Door",
                        To = new[] {
                            new LinkTarget("SM - Crab Hole - Top Left Door"),
                        },
                    },
                },
                Enemies = new[] {
                    // They move while offscreen and can easily be reached from anywher in the room.
                    new Enemy {
                        GroupName = "Crab Hole Scisers",
                        EnemyName = "Sciser",
                        Quantity = 4,
                        HomeNodes = new[] {
                            "SM - Crab Hole - Bottom Left Door",
                            "SM - Crab Hole - Top Left Door",
                            "SM - Crab Hole - Top Right Door",
                            "SM - Crab Hole - Bottom Right Door",
                        },
                    },
                },
            },
            #endregion
            #region Maridia Map Room
            new Room {
                Name = "SM - Maridia Map Room",
                Layout = Room.LayoutFrom(@"
                      1→X"
                    , "SM - Maridia Map Room - Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Maridia Map Room - Door",
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
                    new Utility {
                        Name = "SM - Maridia Map Room - Map Station",
                        Type = UtilityType.Map,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Maridia Map Room - Door",
                        To = new[] {
                            new LinkTarget("SM - Maridia Map Room - Map Station"),
                        },
                    },
                    new Link {
                        From = "SM - Maridia Map Room - Map Station",
                        To = new[] {
                            new LinkTarget("SM - Maridia Map Room - Door"),
                        },
                    },
                },
            },
            #endregion
        };

    }

}
