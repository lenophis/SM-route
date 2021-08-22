using System.Collections.Generic;

namespace SMRouteRando {

    public class SMCrateriaCentral {

        public static IList<Room> Rooms { get; } = new[] {
            #region Landing Site
            new Room {
                Name = "SM - Landing Site",
                Layout = Room.LayoutFrom(@"
                          XXXXXXX
                          XXXXXXX←3
                      2→XXXXXXXXX
                          XXXXXXX
                      1→XXXXXXXXX←4"
                    , "SM - Landing Site - Bottom Left Door"
                    , "SM - Landing Site - Top Left Door"
                    , "SM - Landing Site - Top Right Door"
                    , "SM - Landing Site - Bottom Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Landing Site - Bottom Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash { Length = 33, OpenEnd = 1 },
                        },
                    },
                    new Transition {
                        Name = "SM - Landing Site - Top Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 2,
                                UsableComingIn = false,
                                OpenEnd = 1,
                            },
                        },
                        CanLeaveCharged = new[] {
                            // ShinesparkFrames are at 0 because the shinespark frames are
                            // accounted for in the path to door. Length is set at 33 so that it
                            // insta-succeeds, because the proper runway use is accounted for in
                            // the path to door.
                            new RunwayCharge {
                                InitiateRemotely = new() {
                                    InitiateAt = "", // 3
                                    MustOpenDoorFirst = true,
                                    PathToDoor = new[] {
                                        new PathStep("SM - Landing Site - Top Left Door", new[] { "Shinespark" }),
                                    },
                                },
                                Length = 33,
                                FramesRemaining = 0,
                                ShinesparkFrames = 0,
                                OpenEnd = 1,
                            },
                            // This has MustOpenDoorFirst as false because the wraparound shot is a
                            // substitute for that. ShinesparkFrames are at 0 because the
                            // shinespark frames are accounted for in the path to door. Length is
                            // set at 33 so that it insta-succeeds, because the proper runway use
                            // is accounted for in the path to door.
                            new RunwayCharge {
                                InitiateRemotely = new() {
                                    InitiateAt = "", // 3
                                    MustOpenDoorFirst = false,
                                    PathToDoor = new[] {
                                        new PathStep("SM - Landing Site - Top Left Door", new[] { "Shinespark" }),
                                    },
                                },
                                Length = 33,
                                FramesRemaining = 0,
                                ShinesparkFrames = 0,
                                OpenEnd = 1,
                                Strats = new[] {
                                    new Strat {
                                        Name = "Gauntlet Wraparound Shot",
                                        Notable = true,
                                        Requires = null, // ["canWrapAroundShot"]
                                    },
                                },
                            },
                            // It's actually possible to use this without going to Top Left Door to
                            // open the door first, with a wraparound shot at Top Right Door.
                            // However, it makes more sense to represent that by initiating at Top
                            // Right Door. ShinesparkFrames are at 0 because the shinespark frames
                            // are accounted for in the path to door. Length is set at 33 so that
                            // it insta-succeeds, because the proper runway use is accounted for in
                            // the path to door.
                            new RunwayCharge {
                                InitiateRemotely = new() {
                                    InitiateAt = "", // 4
                                    MustOpenDoorFirst = true,
                                    PathToDoor = new[] {
                                        new PathStep("SM - Landing Site - Top Left Door", new[] { "Shinespark" }),
                                    },
                                },
                                Length = 33,
                                FramesRemaining = 0,
                                ShinesparkFrames = 0,
                                OpenEnd = 2,
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Landing Site - Top Left Escape Lock",
                                Type = LockType.EscapeFunnel,
                                Active = null, // ["f_ZebesSetAblaze"]
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["never"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Landing Site - Top Right Door",
                        Type = TransitionType.Yellow,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 30,
                                SteepDownTiles = 9,
                                OpenEnd = 1,
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Landing Site - Top Right Yellow Lock",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenYellowDoors"]*/ },
                                },
                            },
                            new Lock {
                                Name = "SM - Landing Site - Top Right Escape Lock",
                                Type = LockType.EscapeFunnel,
                                Active = null, // ["f_ZebesSetAblaze"]
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["never"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Landing Site - Bottom Right Door",
                        Type = TransitionType.Green,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 25,
                                SteepUpTiles = 3,
                                OpenEnd = 0,
                            },
                            // SpeedBooster is here without a shine charge on the knowledge that
                            // you can reach the ship for free and break the blocks from there.
                            new RunwayDash {
                                Length = 33,
                                OpenEnd = 1,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //{"or": [
                                        //  "SpeedBooster",
                                        //  "h_canDestroyBombWalls"
                                        //]}
                                    },
                                },
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Landing Site - Bottom Right Green Lock",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenGreenDoors"]*/ },
                                },
                            },
                            new Lock {
                                Name = "SM - Landing Site - Bottom Right Escape Lock",
                                Type = LockType.EscapeFunnel,
                                Active = null, // ["f_ZebesSetAblaze"]
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["never"]*/ },
                                },
                            },
                        },
                    },
                    new Utility {
                        // Todo: If there's a proper memory address to the ship/elevator it was in hiding
                        Name = "SM - Landing Site - Ship",
                        Type = UtilityType.Ship,
                        // Todo: needed? `Utility = [ "save", "missile", "super", "powerbomb", "energy", "reserve" ]`
                    },
                    // Todo: Should this not be an event?
                    new Transition {
                        Name = "SM - Landing Site - Escape Zebes",
                        Type = TransitionType.Elevator,
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Victory Lock",
                                Type = LockType.GameFlag,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["f_ZebesSetAblaze"]*/ },
                                },
                            },
                        },
                        Yields = new[] { "f_BeatSuperMetroid" },
                    },
                    new Junction {
                        Name = "SM - Landing Site - Left Ledge",
                    },
                },
                Obstacles = new[] {
                    new Obstacle {
                        Name = "SM - Landing Site - Left Ledge Bomb Blocks",
                        Type = ObstacleType.Inanimate,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Landing Site - Bottom Left Door",
                        To = new[] {
                            new LinkTarget("SM - Landing Site - Ship"),
                        },
                    },
                    new Link {
                        From = "SM - Landing Site - Top Left Door",
                        To = new[] {
                            // This link is only for sparking. All other strats should go
                            // Top Left Door -> Left Ledge -> Ship -> Bottom Right Door.
                            new LinkTarget("SM - Landing Site - Bottom Right Door", new[] {
                                new Strat {
                                    Name = "Shinespark",
                                    Requires = null,
                                    //{"canComeInCharged": {
                                    //  "fromNode": 1,
                                    //  "framesRemaining": 0,
                                    //  "shinesparkFrames": 160
                                    //}}
                                    Obstacles = new[] {
                                        new Strat.Obstacle { Name = "SM - Landing Site - Left Ledge Bomb Blocks" },
                                    },
                                },
                            }),
                            new LinkTarget("SM - Landing Site - Left Ledge", new[] {
                                new Strat {
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "SM - Landing Site - Left Ledge Bomb Blocks",
                                            Requires = null, // ["h_canDestroyBombWalls"]
                                        },
                                    },
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Landing Site - Top Right Door",
                        To = new[] {
                            // This link is only for sparking. All other strats should go
                            // Top Right Door -> Bottom Right Door -> Ship -> Top Left Door.
                            new LinkTarget("SM - Landing Site - Top Left Door", new[] {
                                new Strat {
                                    Name = "Shinespark",
                                    Requires = null,
                                    //{"canComeInCharged": {
                                    //  "fromNode": 3,
                                    //  "framesRemaining": 180,
                                    //  "shinesparkFrames": 125
                                    //}}
                                    Obstacles = new[] {
                                        new Strat.Obstacle { Name = "SM - Landing Site - Left Ledge Bomb Blocks" },
                                    },
                                },
                            }),
                            new LinkTarget("SM - Landing Site - Bottom Right Door"),
                        },
                    },
                    new Link {
                        From = "SM - Landing Site - Bottom Right Door",
                        To = new[] {
                            // This link is only for sparking. All other strats should go
                            // Bottom Right Door -> Ship -> Top Left Door.
                            new LinkTarget("SM - Landing Site - Top Left Door", new[] {
                                new Strat {
                                    Name = "Shinespark",
                                    Requires = null,
                                    //{"canShineCharge": {
                                    //  "usedTiles": 19,
                                    //  "steepUpTiles": 2,
                                    //  "steepDownTiles": 1,
                                    //  "shinesparkFrames": 125,
                                    //  "openEnd": 2
                                    //}}
                                    Obstacles = new[] {
                                        new Strat.Obstacle { Name = "SM - Landing Site - Left Ledge Bomb Blocks" },
                                    },
                                },
                            }),
                            new LinkTarget("SM - Landing Site - Top Right Door", new[] {
                                new Strat { Requires = null /*["h_canFly"]*/ },
                                new Strat {
                                    Name = "Shinespark",
                                    Requires = null,
                                    //{"canShineCharge": {
                                    //  "usedTiles": 19,
                                    //  "steepUpTiles": 2,
                                    //  "steepDownTiles": 1,
                                    //  "shinesparkFrames": 45,
                                    //  "openEnd": 2
                                    //}}
                                },
                            }),
                            new LinkTarget("SM - Landing Site - Ship"),
                        },
                    },
                    new Link {
                        From = "SM - Landing Site - Ship",
                        To = new[] {
                            new LinkTarget("SM - Landing Site - Bottom Left Door"),
                            // This link is only for sparking. All other strats should go
                            // Ship -> Bottom Right Door -> Top Right Door.
                            new LinkTarget("SM - Landing Site - Top Right Door", new[] {
                                new Strat {
                                    Name = "Shinespark",
                                    Requires = null,
                                    //{"canShineCharge": {
                                    //  "usedTiles": 33,
                                    //  "shinesparkFrames": 75,
                                    //  "openEnd": 2
                                    //}}
                                },
                            }),
                            new LinkTarget("SM - Landing Site - Bottom Right Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //{"or": [
                                    //  "canWalljump",
                                    //  "h_canFly",
                                    //  "SpeedBooster",
                                    //  "h_canDestroyBombWalls",
                                    //  "HiJump",
                                    //  "canSpringBallJump"
                                    //]}
                                },
                            }),
                            new LinkTarget("SM - Landing Site - Escape Zebes"),
                            new LinkTarget("SM - Landing Site - Left Ledge", new[] {
                                new Strat {
                                    Requires = null,
                                    //{"or":[
                                    //  "h_canFly",
                                    //  "SpeedBooster",
                                    //  {"and": [
                                    //    "HiJump",
                                    //    "canSpringBallJumpMidAir"
                                    //  ]}
                                    //]}
                                },
                                new Strat {
                                    Name = "Gauntlet Walljumps",
                                    Notable = true,
                                    Requires = null, // ["canDelayedWalljump"]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Landing Site - Escape Zebes",
                        To = new[] {
                            new LinkTarget("SM - Landing Site - Ship"),
                        },
                    },
                    new Link {
                        From = "SM - Landing Site - Left Ledge",
                        To = new[] {
                            new LinkTarget("SM - Landing Site - Top Left Door", new[] {
                                new Strat {
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "SM - Landing Site - Left Ledge Bomb Blocks",
                                            Requires = null, // ["h_canDestroyBombWalls"]
                                        },
                                    },
                                },
                            }),
                            new LinkTarget("SM - Landing Site - Ship"),
                        },
                    },
                },
            },
            #endregion
            #region Crateria Tube
            new Room {
                Name = "Crateria Tube",
                Layout = Room.LayoutFrom(@"
                      1→X←2"
                    , "SM - Crateria Tube - Left Doorway"
                    , "SM - Crateria Tube - Right Doorway"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Crateria Tube - Left Doorway",
                        Type = TransitionType.Doorway,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 12,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Crateria Tube - Right Doorway",
                        Type = TransitionType.Doorway,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 12,
                                OpenEnd = 1,
                            },
                        },
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Crateria Tube - Left Doorway",
                        To = new[] {
                            new LinkTarget("SM - Crateria Tube - Right Doorway"),
                        },
                    },
                    new Link {
                        From = "SM - Crateria Tube - Right Doorway",
                        To = new[] {
                            new LinkTarget("SM - Crateria Tube - Left Doorway"),
                        },
                    },
                },
            },
            #endregion
            #region Parlor
            new Room {
                Name = "SM - Parlor",
                Layout = Room.LayoutFrom(@"
                      3→XXXXX←4
                         X X
                       2→X X←5
                       1→X←6
                         X
                         ↑
                         7"
                    , "SM - Parlor - Bottom Left Door"
                    , "SM - Parlor - Middle Left Door"
                    , "SM - Parlor - Top Left Door"
                    , "SM - Parlor - Top Right Door"
                    , "SM - Parlor - Alcatraz Door"
                    , "SM - Parlor - Bottom Right Door"
                    , "SM - Parlor - Bottom Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Parlor - Bottom Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 4,
                                SteepUpTiles = 1,
                                EndingUpTiles = 1,
                                OpenEnd = 1,
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Parlor - Bottom Left Escape Lock",
                                Type = LockType.EscapeFunnel,
                                Active = null, // ["f_ZebesSetAblaze"]
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["never"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Parlor - Middle Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 2,
                                UsableComingIn = false,
                                OpenEnd = 0,
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Parlor - Middle Left Escape Lock",
                                Type = LockType.EscapeFunnel,
                                Active = null, // ["f_ZebesSetAblaze"]
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["never"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Parlor - Top Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 13,
                                SteepUpTiles = 2,
                                SteepDownTiles = 2,
                                OpenEnd = 0,
                            },
                            // This longer runway requires the ability to destroy the respawning
                            // bomb blocks. They can't be tracked as an obstacle because they
                            // respawn. This means going from Central Junction to Bottom Left Door
                            // and using the runway will logically require 2 PBs if no other
                            // methods are available, even though it's really doable with 1.
                            new RunwayDash {
                                Length = 21,
                                SteepUpTiles = 4,
                                SteepDownTiles = 2,
                                UsableComingIn = false,
                                OpenEnd = 1,
                                Strats = new[] {
                                    new Strat { Requires = null /*["h_canDestroyBombWalls"]*/ },
                                },
                            },
                        },
                        CanLeaveCharged = new[] {
                            new RunwayCharge {
                                Length = 25,
                                SteepUpTiles = 3,
                                SteepDownTiles = 3,
                                FramesRemaining = 0,
                                ShinesparkFrames = 40,
                                OpenEnd = 1,
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Parlor - Top Left Escape Lock",
                                Type = LockType.EscapeFunnel,
                                Active = null, // ["f_ZebesSetAblaze"]
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["never"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Parlor - Top Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 7,
                                SteepUpTiles = 1,
                                OpenEnd = 1,
                            },
                            // With no enemies
                            new RunwayDash {
                                Length = 11,
                                SteepUpTiles = 2,
                                UsableComingIn = false,
                                OpenEnd = 0,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Parlor - Alcatraz Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 10,
                                SteepDownTiles = 2,
                                OpenEnd = 0,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Parlor - Bottom Right Door",
                        Type = TransitionType.Red,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                SteepUpTiles = 1,
                                EndingUpTiles = 1,
                                OpenEnd = 1,
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Parlor - Bottom Right Red Lock",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenRedDoors"]*/ },
                                },
                            },
                            new Lock {
                                Name = "SM - Parlor - Bottom Right Escape Lock",
                                Type = LockType.EscapeFunnel,
                                Active = null, // ["f_ZebesSetAblaze"]
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["never"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Parlor - Bottom Door",
                        Type = TransitionType.Blue,
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Parlor - Bottom Escape Lock",
                                Type = LockType.EscapeFunnel,
                                Active = null, // ["f_ZebesSetAblaze"]
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["never"]*/ },
                                },
                            },
                        },
                    },
                    new Junction {
                        Name = "SM - Parlor - Central Junction",
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Parlor - Top Left Door",
                        To = new[] {
                            new LinkTarget("SM - Parlor - Central Junction", new[] {
                                new Strat { Requires = null /*["h_canDestroyBombWalls"]*/ },
                                new Strat {
                                    Name = "Shinespark",
                                    Requires = null,
                                    //{"canComeInCharged": {
                                    //  "fromNode": 1,
                                    //  "framesRemaining": 0,
                                    //  "shinesparkFrames": 75
                                    //}}
                                },
                                new Strat {
                                    Name = "SpeedBooster",
                                    Requires = null,
                                    //{ "canComeInCharged": {
                                    //  "fromNode": 1,
                                    //  "framesRemaining": 180,
                                    //  "shinesparkFrames": 0
                                    //}}
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Parlor - Middle Left Door",
                        To = new[] {
                            new LinkTarget("SM - Parlor - Central Junction", new[] {
                                new Strat { Requires = null /*["Morph"]*/ },
                                new Strat {
                                    Name = "Parlor X-Ray Climb",
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
                        From = "SM - Parlor - Bottom Left Door",
                        To = new[] {
                            new LinkTarget("SM - Parlor - Central Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Parlor - Top Right Door",
                        To = new[] {
                            new LinkTarget("SM - Parlor - Central Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Parlor - Alcatraz Door",
                        To = new[] {
                            new LinkTarget("SM - Parlor - Central Junction", new[] {
                                new Strat { Requires = null /*["h_canPassBombPassages"]*/ },
                                new Strat {
                                    Name = "Alcatraz Escape",
                                    Notable = true,
                                    Requires = null,
                                    //[ "Morph",
                                    //  "canPreciseWalljump"
                                    //]
                                },
                                new Strat {
                                    Name = "Space Jump Alcatraz Escape",
                                    Notable = true,
                                    Requires = null,
                                    //[ "Morph",
                                    //  "SpaceJump"
                                    //]
                                },
                                // Supers are for shaking down a Geemer into the hole and freeze it
                                // mid-air to act as a platform.
                                new Strat {
                                    Name = "Frozen Geemer Alcatraz Escape",
                                    Notable = true,
                                    Requires = null,
                                    //[ "Morph",
                                    //  "Super",
                                    //  {"ammo": {
                                    //    "type": "Super",
                                    //    "count": 2
                                    //  }},
                                    //  "canUseFrozenEnemies"
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Parlor - Bottom Right Door",
                        To = new[] {
                            new LinkTarget("SM - Parlor - Central Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Parlor - Bottom Door",
                        To = new[] {
                            new LinkTarget("SM - Parlor - Central Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Parlor - Central Junction",
                        To = new[] {
                            new LinkTarget("SM - Parlor - Top Left Door", new[] {
                                new Strat { Requires = null /*["h_canDestroyBombWalls"]*/ },
                                new Strat {
                                    Name = "Parlor Quick Charge",
                                    Notable = true,
                                    Requires = null,
                                    //{"canShineCharge": {
                                    //  "usedTiles": 25,
                                    //  "steepUpTiles": 3,
                                    //  "steepDownTiles": 3,
                                    //  "shinesparkFrames": 0,
                                    //  "openEnd": 1
                                    //}}
                                },
                                new Strat {
                                    Name = "Parlor Shinespark",
                                    Notable = true,
                                    Requires = null,
                                    //{"canComeInCharged": {
                                    //  "fromNode": 4,
                                    //  "inRoomPath": [4, 8],
                                    //  "framesRemaining": 180,
                                    //  "shinesparkFrames": 75
                                    //}}
                                },
                            }),
                            new LinkTarget("SM - Parlor - Middle Left Door", new[] {
                                new Strat { Requires = null /*["Morph"]*/ },
                            }),
                            new LinkTarget("SM - Parlor - Bottom Left Door"),
                            new LinkTarget("SM - Parlor - Top Right Door"),
                            new LinkTarget("SM - Parlor - Alcatraz Door", new[] {
                                new Strat { Requires = null /*["Morph"]*/ },
                            }),
                            new LinkTarget("SM - Parlor - Bottom Right Door"),
                            new LinkTarget("SM - Parlor - Bottom Door"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Parlor - Alcatraz Ripper",
                        EnemyName = "Ripper",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Parlor - Alcatraz Door" },
                        Spawn = null, // ["f_ZebesAwake"]
                        StopSpawn = null, // ["f_ZebesSetAblaze"]
                    },
                    new Enemy {
                        GroupName = "SM - Parlor - Ripper",
                        EnemyName = "Ripper",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Parlor - Central Junction" },
                        Spawn = null, // ["f_ZebesAwake"]
                        StopSpawn = null, // ["f_ZebesSetAblaze"]
                    },
                    new Enemy {
                        GroupName = "SM - Parlor - Skrees",
                        EnemyName = "Skree",
                        Quantity = 3,
                        HomeNodes = new[] { "SM - Parlor - Central Junction" },
                        Spawn = null, // ["f_ZebesAwake"]
                        StopSpawn = null, // ["f_ZebesSetAblaze"]
                    },
                    new Enemy {
                        GroupName = "SM - Parlor - Geemers",
                        EnemyName = "Geemer (blue)",
                        Quantity = 11,
                        HomeNodes = new[] { "SM - Parlor - Central Junction" },
                        Spawn = null, // ["f_ZebesAwake"]
                        StopSpawn = null, // ["f_ZebesSetAblaze"]
                    },
                },
            },
            #endregion
            #region Climb
            new Room {
                Name = "SM - Climb",
                Layout = Room.LayoutFrom(@"
                         2
                         ↓
                         XX←3
                         X
                         X
                         X
                         X
                         X
                         X
                         XX←4
                      1→XX←5"
                    , "SM - Climb - Bottom Left Door"
                    , "SM - Climb - Top Door"
                    , "SM - Climb - Top Right Door"
                    , "SM - Climb - Middle Right Door"
                    , "SM - Climb - Bottom Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Climb - Bottom Left Door",
                        Type = TransitionType.Gray,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 14,
                                OpenEnd = 0,
                            },
                            // This longer runway requires the bottom bomb wall to be destroyed.
                            // The requirements are on the obstacle itself.
                            new RunwayDash {
                                Length = 28,
                                OpenEnd = 0,
                                UsableComingIn = false,
                                Strats = new[] {
                                    new Strat {
                                        Obstacles = new[] {
                                            new Strat.Obstacle { Name = "Bottom Bomb Blocks" },
                                        },
                                    },
                                },
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Climb - Tourian Grey Lock",
                                Type = LockType.Permanent,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["never"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Climb - Top Door",
                        Type = TransitionType.Blue,
                    },
                    new Transition {
                        Name = "SM - Climb - Top Right Door",
                        Type = TransitionType.Gray,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 2,
                                OpenEnd = 0,
                                UsableComingIn = false,
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Climb - Top Right Grey Lock",
                                Type = LockType.Permanent,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["never"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Climb - Middle Right Door",
                        Type = TransitionType.Yellow,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 0,
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Climb - Middle Right Yellow Lock",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenYellowDoors"]*/ },
                                },
                            },
                            new Lock {
                                Name = "SM - Climb - Middle Right Escape Lock",
                                Type = LockType.EscapeFunnel,
                                Active = null, // ["f_ZebesSetAblaze"]
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["never"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Climb - Bottom Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 12,
                                OpenEnd = 0,
                            },
                            // This longer runway requires the bottom bomb wall to be destroyed.
                            // The requirements are on the obstacle itself.
                            new RunwayDash {
                                Length = 28,
                                OpenEnd = 0,
                                UsableComingIn = false,
                                Strats = new[] {
                                    new Strat {
                                        Obstacles = new[] {
                                            new Strat.Obstacle { Name = "Bottom Bomb Blocks" },
                                        },
                                    },
                                },
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Climb - Bottom Right Escape Lock",
                                Type = LockType.EscapeFunnel,
                                Active = null, // ["f_ZebesSetAblaze"]
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["never"]*/ },
                                },
                            },
                        },
                    },
                    new Junction {
                        Name = "SM - Climb - Main Junction",
                    },
                },
                Obstacles = new[] {
                    new Obstacle {
                        Name = "Bottom Bomb Blocks",
                        Type = ObstacleType.Inanimate,
                        Requires = null,
                        //{"or": [
                        //  "h_canUseMorphBombs",
                        //  "ScrewAttack",
                        //  "f_ZebesSetAblaze",
                        //  {"canComeInCharged": {
                        //    "fromNode": 2,
                        //    "framesRemaining": 0,
                        //    "shinesparkFrames": 43
                        //  }},
                        //  {"canComeInCharged": {
                        //    "fromNode": 5,
                        //    "framesRemaining": 0,
                        //    "shinesparkFrames": 43
                        //  }},
                        //  "h_canUsePowerBombs"
                        //]}
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Climb - Top Door",
                        To = new[] {
                            new LinkTarget("SM - Climb - Main Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Climb - Bottom Left Door",
                        To = new[] {
                            new LinkTarget("SM - Climb - Main Junction", new[] {
                                new Strat {
                                    Obstacles = new[] {
                                        new Strat.Obstacle { Name = "Bottom Bomb Blocks" },
                                    },
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Climb - Top Right Door",
                        To = new[] {
                            new LinkTarget("SM - Climb - Main Junction", new[] {
                                new Strat { Requires = null /*["h_canPassBombPassages"]*/ },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Climb - Middle Right Door",
                        To = new[] {
                            new LinkTarget("SM - Climb - Main Junction", new[] {
                                new Strat { Requires = null /*["h_canPassBombPassages"]*/ },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Climb - Bottom Right Door",
                        To = new[] {
                            new LinkTarget("SM - Climb - Main Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Climb - Main Junction",
                        To = new[] {
                            new LinkTarget("SM - Climb - Top Door"),
                            new LinkTarget("SM - Climb - Bottom Left Door", new[] {
                                new Strat {
                                    Obstacles = new[] {
                                        new Strat.Obstacle { Name = "Bottom Bomb Blocks" },
                                    },
                                },
                            }),
                            new LinkTarget("SM - Climb - Top Right Door", new[] {
                                new Strat { Requires = null /*["h_canPassBombPassages"]*/ },
                                // The Behemoth Spark opens the bomb blocks, making the path
                                // passable without bombs.
                                new Strat {
                                    Name = "Behemoth Spark Top",
                                    Notable = true,
                                    Requires = null,
                                    //[ "Morph",
                                    //  {"canShineCharge": {
                                    //    "usedTiles": 28,
                                    //    "shinesparkFrames": 147,
                                    //    "openEnd": 0
                                    //  }}
                                    //],
                                    Obstacles = new[] {
                                        new Strat.Obstacle { Name = "Bottom Bomb Blocks" },
                                    },
                                },
                            }),
                            new LinkTarget("SM - Climb - Middle Right Door", new[] {
                                new Strat { Requires = null /*["h_canPassBombPassages"]*/ },
                                // The Behemoth Spark opens the bomb blocks, making the path
                                // passable without bombs.
                                new Strat {
                                    Name = "Behemoth Spark Bottom",
                                    Notable = true,
                                    Requires = null,
                                    //[ "Morph",
                                    //  {"canShineCharge": {
                                    //    "usedTiles": 28,
                                    //    "shinesparkFrames": 147,
                                    //    "openEnd": 0
                                    //  }}
                                    //],
                                    Obstacles = new[] {
                                        new Strat.Obstacle { Name = "Bottom Bomb Blocks" },
                                    },
                                },
                                // The bomb blocks can be broken by spinjumping with Screw attack
                                // and holding right, if moonfall makes Samus clip through the
                                // platform.
                                new Strat {
                                    Name = "Climb Moonfall Block Break",
                                    Notable = true,
                                    Requires = null,
                                    //[ "Morph",
                                    //  "ScrewAttack",
                                    //  "canMoonfall"
                                    //],
                                },
                            }),
                            new LinkTarget("SM - Climb - Bottom Right Door"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Climb - Pirates",
                        EnemyName = "Grey Space Pirate (wall)",
                        Quantity = 11,
                        HomeNodes = new[] { "SM - Climb - Bottom Right Door" },
                        Spawn = null, // ["f_ZebesAwake"]
                        StopSpawn = null, // ["f_ZebesSetAblaze"]
                    },
                    new Enemy {
                        GroupName = "SM - Climb - Escape Pirates",
                        EnemyName = "Custom Climb Pirate",
                        Quantity = 2,
                        HomeNodes = new[] { "SM - Climb - Bottom Left Door" },
                        Spawn = null, // ["f_ZebesSetAblaze"]
                    },
                },
            },
            #endregion
            #region Pit Room
            new Room {
                Name = "SM - Pit Room",
                Layout = Room.LayoutFrom(@"
                      1→XXX←2
                        X"
                    , "SM - Pit Room - Left Door"
                    , "SM - Pit Room - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Pit Room - Left Door",
                        Type = TransitionType.Gray,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 7,
                                OpenEnd = 1,
                            },
                        },
                        Locks = new[] {
                            // Unlike the right door, this is locked from game start. Not just when
                            // Zebes awakens.
                            new Lock {
                                Name = "SM - Pit Room - Left Grey Lock",
                                Type = LockType.KillEnemies,
                                // Once the enemies actually spawn, they can be killed with just
                                // Power Beam.
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["f_ZebesAwake"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Pit Room - Right Door",
                        Type = TransitionType.Gray,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 2,
                                UsableComingIn = false,
                                OpenEnd = 1,
                            },
                        },
                        Locks = new[] {
                            // The enemies can be killed with just Power Beam.
                            new Lock {
                                Name = "SM - Pit Room - Right Grey Lock",
                                Type = LockType.KillEnemies,
                                Active = null, // ["f_ZebesAwake"]
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - Pit Room - Retro Mother Brain Item",
                        Type = PlacementType.Visible,
                        Locks = new[] {
                            // Item doesn't spawn until Zebes is awake.
                            new Lock {
                                Name = "SM - Retro Mother Brain Item Spawn Lock",
                                Type = LockType.GameFlag,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["f_ZebesAwake"]*/ },
                                },
                            },
                        },
                    },
                    new Event {
                        Name = "SM - Pit Room - Zebes Awakens",
                        Type = EventType.Flag,
                        Locks = new[] {
                            // Entering this room from either door with any missiles collected
                            // spawns the enemies in this and nearby rooms.
                            new Lock {
                                Name = "SM - Pit Room - Zebes Awakens Event Lock",
                                Type = LockType.TriggeredEvent,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["Missile"]*/ },
                                },
                            },
                        },
                        Yields = new[] { "f_ZebesAwake" },
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Pit Room - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Pit Room - Zebes Awakens"),
                        },
                    },
                    new Link {
                        From = "SM - Pit Room - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Pit Room - Zebes Awakens"),
                        },
                    },
                    new Link {
                        From = "SM - Pit Room - Retro Mother Brain Item",
                        To = new[] {
                            new LinkTarget("SM - Pit Room - Zebes Awakens"),
                        },
                    },
                    new Link {
                        From = "SM - Pit Room - Zebes Awakens",
                        To = new[] {
                            new LinkTarget("SM - Pit Room - Left Door"),
                            new LinkTarget("SM - Pit Room - Right Door"),
                            // FIXME Missing bluesuit strat, probably needs a new tech?
                            new LinkTarget("SM - Pit Room - Retro Mother Brain Item", new[] {
                                new Strat { Requires = null /*["h_canDestroyBombWalls"]*/ },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Pit Room - Left Standing Pirate",
                        EnemyName = "Grey Space Pirate (standing)",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Pit Room - Left Door" },
                        Spawn = null, // ["f_ZebesAwake"]
                    },
                    new Enemy {
                        GroupName = "SM - Pit Room - Right Standing Pirates",
                        EnemyName = "Grey Space Pirate (standing)",
                        Quantity = 3,
                        HomeNodes = new[] { "SM - Pit Room - Right Door" },
                        Spawn = null, // ["f_ZebesAwake"]
                    },
                    new Enemy {
                        GroupName = "SM - Pit Room - Wall Pirate",
                        EnemyName = "Grey Space Pirate (wall)",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Pit Room - Right Door" },
                        Spawn = null, // ["f_ZebesAwake"]
                    },
                },
            },
            #endregion
            #region Flyway
            new Room {
                Name = "SM - Flyway",
                Layout = Room.LayoutFrom(@"
                      1→XXX←2"
                    , "SM - Flyway - Left Door"
                    , "SM - Flyway - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Flyway - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 2,
                                OpenEnd = 1,
                                UsableComingIn = false,
                            },
                        },
                        CanLeaveCharged = new [] {
                            new RunwayCharge {
                                Length = 33,
                                OpenEnd = 2,
                                FramesRemaining = 90,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Flyway - Right Door",
                        Type = TransitionType.Red,
                        Runways = new [] {
                            new RunwayDash {
                                Length = 2,
                                UsableComingIn = false,
                                OpenEnd = 1,
                            },
                        },
                        CanLeaveCharged = new[] {
                            new RunwayCharge {
                                Length = 33,
                                FramesRemaining = 90,
                                OpenEnd = 2,
                            },
                        },
                        Locks = new[] {
                            // The end game sequence overrides the color lock.
                            new Lock {
                                Name = "SM - Flyway - Red Lock",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //{"or": [
                                        //  "h_canOpenRedDoors",
                                        //  "f_ZebesSetAblaze"
                                        //]}
                                    },
                                },
                            },
                        },
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Flyway - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Flyway - Right Door"),
                        },
                    },
                    new Link {
                        From = "SM - Flyway - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Flyway - Left Door"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Flyway - Mellows",
                        EnemyName = "Mellow",
                        Quantity = 12,
                        HomeNodes = new[] {
                            "SM - Flyway - Left Door",
                            "SM - Flyway - Right Door",
                        },
                        StopSpawn = null, // ["f_ZebesSetAblaze"]
                    },
                },
            },
            #endregion
            #region Jagged Flyway
            new Room {
                Name = "SM - Jagged Flyway",
                Layout = Room.LayoutFrom(@"
                      1→XXX←2"
                    , "SM - Jagged Flyway - Left Door"
                    , "SM - Jagged Flyway - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Jagged Flyway - Left Door",
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
                        Name = "SM - Jagged Flyway - Right Door",
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
                        From = "SM - Jagged Flyway - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Jagged Flyway - Right Door"),
                        },
                    },
                    new Link {
                        From = "SM - Jagged Flyway - Right Door",
                        To = new[]  {
                            new LinkTarget("SM - Jagged Flyway - Left Door"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Jagged Flyway - Mellows",
                        EnemyName = "Mellow",
                        Quantity = 3,
                        HomeNodes = new[] {
                            "SM - Jagged Flyway - Left Door",
                            "SM - Jagged Flyway - Right Door",
                        },
                    },
                    new Enemy {
                        GroupName = "SM - Jagged Flyway - Reo",
                        EnemyName = "Reo",
                        Quantity = 1,
                        HomeNodes = new[] {
                            "SM - Jagged Flyway - Left Door",
                            "SM - Jagged Flyway - Right Door",
                        },
                    },
                },
            },
            #endregion
            #region Crateria Map Room
            new Room {
                Name = "SM - Crateria Map Room",
                Layout = Room.LayoutFrom(@"
                      1→X"
                    , "SM - Crateria Map Room - Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Crateria Map Room - Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Utility {
                        Name = "SM - Crateria Map Room - Map Station",
                        Type = UtilityType.Map,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Crateria Map Room - Door",
                        To = new[] {
                            new LinkTarget("SM - Crateria Map Room - Map Station"),
                        },
                    },
                    new Link {
                        From = "SM - Crateria Map Room - Map Station",
                        To = new[] {
                            new LinkTarget("SM - Crateria Map Room - Door"),
                        },
                    },
                },
            },
            #endregion
            #region Crateria Save Room
            new Room {
                Name = "SM - Crateria Save Room",
                Layout = Room.LayoutFrom(@"
                      X←1"
                    , "SM - Crateria Save Room - Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Crateria Save Room - Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Utility {
                        Name = "SM - Crateria Save Room - Save Station",
                        Type = UtilityType.Save,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Crateria Save Room - Door",
                        To = new[] {
                            new LinkTarget("SM - Crateria Save Room - Save Station"),
                        },
                    },
                    new Link {
                        From = "SM - Crateria Save Room - Save Station",
                        To = new[] {
                            new LinkTarget("SM - Crateria Save Room - Door"),
                        },
                    },
                },
            },
            #endregion
            #region Crateria Chozo Room
            new Room {
                Name = "SM - Crateria Chozo Room",
                Layout = Room.LayoutFrom(@"
                      X←1"
                    , "SM - Crateria Chozo Room - Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Crateria Chozo Room - Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 9,
                                OpenEnd = 0,
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - Crateria Chozo Room - Item",
                        Type = PlacementType.Chozo,
                        Locks = new[] {
                            // Item doesn't spawn until Zebes is awake. Interestingly, the Chozo
                            // also has a scope that observes Samus, like in Blue Brinstar.
                            new Lock {
                                Name = "SM - Crateria Chozo Room - Item Spawn Lock",
                                Type = LockType.GameFlag,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["f_ZebesAwake"]*/ },
                                },
                            },
                        },
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Crateria Chozo Room - Door",
                        To = new[] {
                            new LinkTarget("SM - Crateria Chozo Room - Item"),
                        },
                    },
                    new Link {
                        From = "SM - Crateria Chozo Room - Item",
                        To = new[] {
                            new LinkTarget("SM - Crateria Chozo Room - Door"),
                        },
                    },
                },
            },
            #endregion
            #region Bombway
            new Room {
                Name = "SM - Bombway",
                Layout = Room.LayoutFrom(@"
                      1→XX←2"
                    , "SM - Bombway - Left Door"
                    , "SM - Bombway - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Bombway - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 0,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Bombway - Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 0,
                            },
                        },
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Bombway - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Bombway - Right Door", new[] {
                                // Todo: This assumes mid air morph. Adjust this and add PassBombPassages strat?
                                new Strat { Requires = null /*["Morph"]*/ },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Bombway - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Bombway - Left Door", new[] {
                                new Strat { Requires = null /*["h_canPassBombPassages"]*/ },
                            }),
                        },
                    },
                },
            },
            #endregion
            #region Bomb Torizo Room
            // Could it be a different actual room during the escape sequence?
            new Room {
                Name = "SM - Bomb Torizo Room",
                Layout = Room.LayoutFrom(@"
                      1→X"
                    , "SM - Bomb Torizo Room - Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Bomb Torizo Room - Door",
                        Type = TransitionType.Gray,
                        Locks = new[] {
                            // If no Bombs in inventory, door stays open.
                            new Lock {
                                Name = "SM - Bomb Torizo Room - Grey Lock",
                                Type = LockType.GameFlag,
                                Active = null, // ["Bombs"]
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["f_DefeatedBombTorizo"]*/ },
                                },
                            },
                            new Lock {
                                Name = "SM - Bomb Torizo Room - Animal Escape Grey Lock",
                                Type = LockType.GameFlag,
                                Active = null, // ["f_ZebesSetAblaze"]
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["f_AnimalsSaved"]*/ },
                                },
                            },
                        },
                        Runways = new[] {
                            new RunwayDash {
                                Length = 0,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - Bomb Torizo Room - Item",
                        Type = PlacementType.Chozo
                    },
                    new Event {
                        Name = "SM - Bomb Torizo Room - Bomb Torizo",
                        Type = EventType.Boss,
                        Locks = new[] {
                            // Killing Bomb Torizo requires only Power Beam, but Bombs are needed
                            // for it to activate.
                            new Lock {
                                Name = "SM - Bomb Torizo Room - Bomb Torizo Fight",
                                Type = LockType.BossFight,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["Bombs"]*/ },
                                },
                            },
                        },
                        Yields = new[] { "f_DefeatedBombTorizo" },
                    },
                    new Event {
                        Name = "SM - Bomb Torizo Room - Animals",
                        Type = EventType.Flag,
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Bomb Torizo Room - Animal Wall Lock",
                                Type = LockType.Cutscene,
                                // Technically this also requires opening the wall.
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["f_ZebesSetAblaze"]*/ },
                                },
                            },
                        },
                        Yields = new[] { "f_AnimalsSaved" },
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Bomb Torizo Room - Door",
                        To = new[] {
                            new LinkTarget("SM - Bomb Torizo Room - Bomb Torizo"),
                            new LinkTarget("SM - Bomb Torizo Room - Animals"),
                        },
                    },
                    new Link {
                        From = "SM - Bomb Torizo Room - Item",
                        To = new[] {
                            new LinkTarget("SM - Bomb Torizo Room - Bomb Torizo"),
                        },
                    },
                    new Link {
                        From = "SM - Bomb Torizo Room - Bomb Torizo",
                        To = new[] {
                            new LinkTarget("SM - Bomb Torizo Room - Door"),
                            new LinkTarget("SM - Bomb Torizo Room - Item"),
                        },
                    },
                    new Link {
                        From = "SM - Bomb Torizo Room - Animals",
                        To = new[] {
                            new LinkTarget("SM - Bomb Torizo Room - Door"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Bomb Torizo Room - Bomb Torizo",
                        EnemyName = "Bomb Torizo",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Bomb Torizo Room - Bomb Torizo" },
                        Spawn = null, // ["Bombs"]
                        StopSpawn = null,
                        //{"or": [
                        //  "f_DefeatedBombTorizo",
                        //  "f_ZebesSetAblaze"
                        //]}
                    },
                },
            },
            #endregion
            // Todo: Item generic room name?
            #region Crateria Power Bomb Room
            new Room {
                Name = "SM - Crateria Power Bomb Room",
                Layout = Room.LayoutFrom(@"
                      1→XX"
                    , "SM - Crateria Power Bomb Room - Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Crateria Power Bomb Room - Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - Crateria Power Bomb Room - Item",
                        Type = PlacementType.Visible,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Crateria Power Bomb Room - Door",
                        To = new[] {
                            new LinkTarget("SM - Crateria Power Bomb Room - Item"),
                        },
                    },
                    new Link {
                        From = "SM - Crateria Power Bomb Room - Item",
                        To = new[] {
                            new LinkTarget("SM - Crateria Power Bomb Room - Door"),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Crateria Power Bomb Room - Alcoons",
                        EnemyName =  "Alcoon",
                        Quantity = 3,
                        HomeNodes = new[] { "SM - Crateria Power Bomb Room - Item" },
                    },
                },
            },
            #endregion
            #region Crateria Shinespark Room
            new Room {
                Name = "SM - Crateria Shinespark Room",
                Layout = Room.LayoutFrom(@"
                      2→XXXX
                           X
                           X
                           X
                           X
                           X
                           X
                      1→XXXX"
                    , "SM - Crateria Shinespark Room - Bottom Left Door"
                    , "SM - Crateria Shinespark Room - Top Left Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Crateria Shinespark Room - Bottom Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 33,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Crateria Shinespark Room - Top Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 5,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - Crateria Shinespark Room - Item",
                        Type = PlacementType.Visible,
                    },
                    new Junction {
                        Name = "SM - Crateria Shinespark Room - Top Junction",
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Crateria Shinespark Room - Top Left Door",
                        To = new[] {
                            new LinkTarget("SM - Crateria Shinespark Room - Top Junction", new[] {
                                new Strat {
                                    Requires = null,
                                    //{"or":[
                                    //  "Grapple",
                                    //  "SpaceJump"
                                    //]}
                                },
                                new Strat {
                                    Name = "Tank the Damage",
                                    Requires = null, // [{"spikeHits": 1}]
                                },
                                new Strat {
                                    Name = "Shinespark",
                                    Requires = null,
                                    //{"canComeInCharged": {
                                    //  "fromNode": 1,
                                    //  "framesRemaining": 0,
                                    //  "shinesparkFrames": 65
                                    //}}
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Crateria Shinespark Room - Bottom Left Door",
                        To = new[] {
                            // No strat for getting through the Boyons with a dboost, since it's
                            // redundant with the bluesuit jump.
                            new LinkTarget("SM - Crateria Shinespark Room - Item", new[] {
                                new Strat {
                                    Name = "Vanilla Strat",
                                    Requires = null,
                                    //[ {"canShineCharge": {
                                    //    "usedTiles": 33,
                                    //    "shinesparkFrames": 130,
                                    //    "openEnd": 2
                                    //  }},
                                    //  "canUseFrozenEnemies"
                                    //]
                                },
                                //  This is doable without a short charge, but it's essentially
                                //  harder than the bluesuit jump. With a quick charge, it can
                                //  serve as a less scary strat.
                                new Strat {
                                    Name = "Crateria Supers Dead Boyons Quick Charge",
                                    Notable = true,
                                    Requires = null,
                                    //[ {"canShineCharge": {
                                    //    "usedTiles": 25,
                                    //    "shinesparkFrames": 130,
                                    //    "openEnd": 2
                                    //  }},
                                    //  {"enemyKill": {
                                    //    "enemies": [
                                    //      [ "Boyon", "Boyon", "Boyon", "Boyon" ]
                                    //    ]
                                    //  }}
                                    //]
                                },
                                // Involves charging a spark running left, then getting blue suit
                                // running right to jump through the Boyons.
                                new Strat {
                                    Name = "Crateria Supers BlueSuit Jump",
                                    Notable = true,
                                    Requires = null,
                                    //{"canShineCharge": {
                                    //  "usedTiles": 33,
                                    //  "shinesparkFrames": 130,
                                    //  "openEnd": 2
                                    //}}
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Crateria Shinespark Room - Item",
                        To = new[] {
                            new LinkTarget("SM - Crateria Shinespark Room - Top Junction", new[] {
                                new Strat { Requires = null /*["Morph"]*/ },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Crateria Shinespark Room - Top Junction",
                        To = new[] {
                            new LinkTarget("SM - Crateria Shinespark Room - Top Left Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //{"or":[
                                    //  "Grapple",
                                    //  "SpaceJump"
                                    //]}
                                },
                                new Strat {
                                    Name = "Tank the Damage",
                                    Requires = null, // [{"spikeHits": 1}]
                                },
                            }),
                            new LinkTarget("SM - Crateria Shinespark Room - Item", new[] {
                                new Strat { Requires = null /*["Morph"]*/ },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "Crateria Supers Boyons",
                        EnemyName = "Boyon",
                        Quantity = 4,
                        HomeNodes = new[] { "SM - Crateria Shinespark Room - Bottom Left Door" },
                    },
                },
            },
            #endregion
            #region Crateria Central Elevator Room
            new Room {
                Name = "SM - Crateria Central Elevator Room",
                Layout = Room.LayoutFrom(@"
                      1→X
                        ↑
                        2"
                    , "Crateria Central Elevator Room - Door"
                    , "Crateria Central Elevator Room - Elevator"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "Crateria Central Elevator Room - Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 13,
                                OpenEnd = 0,
                            },
                        },
                    },
                    new Transition {
                        Name = "Crateria Central Elevator Room - Elevator",
                        Type = TransitionType.Elevator,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "Crateria Central Elevator Room - Door",
                        To = new[] {
                            new LinkTarget("Crateria Central Elevator Room - Elevator"),
                        },
                    },
                    new Link {
                        From = "Crateria Central Elevator Room - Elevator",
                        To = new[] {
                            new LinkTarget("Crateria Central Elevator Room - Door"),
                        },
                    },
                },
            },
            #endregion
        };

    }

}
