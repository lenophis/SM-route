using System.Collections.Generic;
using SMRouteRando.Util;

namespace SMRouteRando {

    public class SMNorfairLowerEast {

        public static IList<Room> Rooms { get; } = new[] {
            #region Main Hall
            new Room {
                Name = "SM - Main Hall",
                Layout = Room.LayoutFrom(@"
                            2
                            ↓
                      1→XXXXXXXX←3"
                    , "SM - Main Hall - Left Door"
                    , "SM - Main Hall - Elevator"
                    , "SM - Main Hall - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Main Hall - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 2,
                                OpenEnd = 0,
                                UsableComingIn = false,
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
                        Name = "SM - Main Hall - Elevator",
                        Type = TransitionType.Elevator,
                    },
                    new Transition {
                        Name = "SM - Main Hall - Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 5,
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
                    },
                    new Junction {
                        Name = "SM - Main Hall - Middle Junction",
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Main Hall - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Main Hall - Middle Junction", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 800}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Main Hall - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Main Hall - Middle Junction", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 450}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Main Hall - Middle Junction",
                        To = new[] {
                            new LinkTarget("SM - Main Hall - Left Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 800}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Main Hall - Right Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 450}
                                    //]
                                },
                            }),
                            // This link exists because of how Samus takes heatdamage while riding
                            // the elevator.
                            new LinkTarget("SM - Main Hall - Elevator", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 285}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Main Hall - Elevator",
                        To = new[] {
                            // This link exists because of how Samus takes heatdamage while riding
                            // the elevator.
                            new LinkTarget("SM - Main Hall - Middle Junction", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 310}
                                    //]
                                },
                            }),
                        },
                    },
                },
            },
            #endregion
            // Todo: Better name? The name refers to the next room in vanilla, but we will randomize.
            #region Fast Pillars Setup Room
            new Room {
                Name = "SM - Fast Pillars Setup Room",
                Layout = Room.LayoutFrom(@"
                        X←3
                      2→X
                      1→X←4"
                    , "SM - Fast Pillars Setup Room - Bottom Left Door"
                    , "SM - Fast Pillars Setup Room - Top Left Door"
                    , "SM - Fast Pillars Setup Room - Top Right Door"
                    , "SM - Fast Pillars Setup Room - Bottom Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Fast Pillars Setup Room - Bottom Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 12,
                                GentleDownTiles = 2,
                                GentleUpTiles = 2,
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
                    new Transition {
                        Name = "SM - Fast Pillars Setup Room - Top Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 6,
                                OpenEnd = 0,
                                Strats = new[] {
                                    // This runway is not usable if the PB blocks are broken.
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"resetRoom":{
                                        //    "nodes": [1, 4],
                                        //    "obstaclesToAvoid": ["A"]
                                        //  }},
                                        //  {"heatFrames": 100}
                                        //]
                                    },
                                },
                            },
                            // With PB Blocks Intact.
                            // This runway is not usable if the PB blocks are broken, but it also
                            // requires the Pirate to be taken out. Some weapons have been excluded
                            // from suitless strats because they were judged to take too much time.
                            new RunwayDash {
                                Length = 12,
                                OpenEnd = 0,
                                UsableComingIn = false,
                                Strats = new[] {
                                    new Strat {
                                        Name = "Bombless Heatproof Pirate Kill",
                                        Requires = null,
                                        //[ {"resetRoom":{
                                        //    "nodes": [1, 4],
                                        //    "obstaclesToAvoid": ["A"]
                                        //  }},
                                        //  "h_heatProof",
                                        //  {"enemyKill":{
                                        //    "enemies": [
                                        //      [ "Yellow Space Pirate (standing)" ]
                                        //    ],
                                        //    "excludedWeapons": [ "Bombs", "PowerBomb" ]
                                        //  }}
                                        //]
                                    },
                                    // The Power Bombs must be placed carefully to hit the Pirate
                                    // without destroying the PB blocks. This strat requires
                                    // heatproof because it's pretty chaotic to execute.
                                    new Strat {
                                        Name = "Fast Pillars Power Bomb Periphery Pirate Kill",
                                        Notable = true,
                                        Requires = null,
                                        //[ {"resetRoom":{
                                        //    "nodes": [1, 4],
                                        //    "obstaclesToAvoid": ["A"]
                                        //  }},
                                        //  "h_heatProof",
                                        //  {"enemyKill":{
                                        //    "enemies": [
                                        //      [ "Yellow Space Pirate (standing)", "Yellow Space Pirate (wall)", "Yellow Space Pirate (wall)" ]
                                        //    ],
                                        //    "explicitWeapons": [ "PowerBombPeriphery" ]
                                        //  }}
                                        //]
                                    },
                                    new Strat {
                                        Name = "Suitless Pirate Kill",
                                        Requires = null,
                                        //[ {"resetRoom":{
                                        //    "nodes": [1, 4],
                                        //    "obstaclesToAvoid": ["A"]
                                        //  }},
                                        //  "canHeatRun",
                                        //  { "heatFrames": 420},
                                        //  {"enemyKill":{
                                        //    "enemies": [
                                        //      [
                                        //        "Yellow Space Pirate (standing)"
                                        //      ]
                                        //    ],
                                        //    "explicitWeapons": [ "Missile", "Super", "Charge+Plasma", "ScrewAttack" ]
                                        //  }}
                                        //]
                                    },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Fast Pillars Setup Room - Top Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 0,
                                OpenEnd = 1,
                                Strats = new[] {
                                    // Just using the open end of this 0-tile runway does take some
                                    // maneuvering time.
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"heatFrames": 100}
                                        //]
                                    },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Fast Pillars Setup Room - Bottom Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 12,
                                GentleDownTiles = 2,
                                GentleUpTiles = 2,
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
                    new Junction {
                        Name = "SM - Fast Pillars Setup Room - Bottom Junction",
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
                        From = "SM - Fast Pillars Setup Room - Top Left Door",
                        To = new[] {
                            new LinkTarget("SM - Fast Pillars Setup Room - Top Right Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 200}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Fast Pillars Setup Room - Bottom Junction", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 200}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Power Bomb Blocks",
                                            Requires = null,
                                            //[ {"heatFrames": 50},
                                            //  "h_canUsePowerBombs"
                                            //]
                                        },
                                    },
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Fast Pillars Setup Room - Bottom Left Door",
                        To = new[] {
                            new LinkTarget("SM - Fast Pillars Setup Room - Bottom Junction", new[] {
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
                        From = "SM - Fast Pillars Setup Room - Bottom Right Door",
                        To = new[] {
                            new LinkTarget("SM - Fast Pillars Setup Room - Bottom Junction", new[] {
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
                        From = "SM - Fast Pillars Setup Room - Top Right Door",
                        To = new[] {
                            new LinkTarget("SM - Fast Pillars Setup Room - Top Left Door", new[] {
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
                        From = "SM - Fast Pillars Setup Room - Bottom Junction",
                        To = new[] {
                            new LinkTarget("SM - Fast Pillars Setup Room - Top Left Door", new[] {
                                // Destroying the obstacle isn't seen to take extra time for two
                                // reasons.
                                // 1- It destroys the shot blocks as well which are assumed to be
                                //    manually destroyed each time since they respawn.
                                // 2- This assumes no jump assists, and some of the time loss of
                                //    waiting for the PB is offset by having to setup for a pretty
                                //    tight wall jump setup anyway.
                                // It might bo slightly faster to do a stationary spinjump rather
                                // than the setup, but we won't go into that much detail.
                                new Strat {
                                    Name = "Hjless",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 400}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Power Bomb Blocks",
                                            Requires = null, // ["h_canUsePowerBombs"]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Hjb",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "HiJump",
                                    //  { "heatFrames": 250}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Power Bomb Blocks",
                                            Requires = null,
                                            //[ "h_canUsePowerBombs",
                                            //  { "heatFrames": 50}
                                            //]
                                        },
                                    },
                                },
                            }),
                            new LinkTarget("SM - Fast Pillars Setup Room - Bottom Left Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 50}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Fast Pillars Setup Room - Bottom Right Door", new[] {
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
                        GroupName = "Fast Pillars Standing Pirates",
                        EnemyName = "Yellow Space Pirate (standing)",
                        Quantity = 1,
                        HomeNodes = new[] {
                            "SM - Fast Pillars Setup Room - Top Left Door",
                            "SM - Fast Pillars Setup Room - Top Right Door",
                        },
                        DropRequires = null, // ["h_heatProof"]
                    },
                    new Enemy {
                        GroupName = "Fast Pillars Wall Pirates",
                        EnemyName = "Yellow Space Pirate (wall)",
                        Quantity = 2,
                        HomeNodes = new[] {
                            "SM - Fast Pillars Setup Room - Top Left Door",
                            "SM - Fast Pillars Setup Room - Top Right Door",
                        },
                        DropRequires = null, // ["h_heatProof"]
                    },
                    new Enemy {
                        GroupName = "Fast Pillars Violas",
                        EnemyName = "Viola",
                        Quantity = 2,
                        HomeNodes = new[] { "SM - Fast Pillars Setup Room - Bottom Junction" },
                        DropRequires = null, // ["h_heatProof"]
                    },
                },
            },
            #endregion
            #region Pillar Room
            new Room {
                Name = "SM - Pillar Room",
                Layout = Room.LayoutFrom(@"
                      1→XXXX←2"
                    , "SM - Pillar Room - Left Door"
                    , "SM - Pillar Room - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Pillar Room - Left Door",
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
                                }
                            },
                        }
                    },
                    new Transition {
                        Name = "SM - Pillar Room - Right Door",
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
                },
                Links = new[] {
                    new Link {
                        From = "SM - Pillar Room - Left Door",
                        To = new[] {
                            // Potentially doable with morph bombs and enough energy, maybe, but
                            // let's not go there.
                            new LinkTarget("SM - Pillar Room - Right Door", new[] {
                                new Strat {
                                    Name = "Screw",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "ScrewAttack",
                                    //  {"heatFrames": 550}
                                    //]
                                },
                                new Strat {
                                    Name = "Space Screw",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "ScrewAttack",
                                    //  "SpaceJump",
                                    //  {"heatFrames": 400}
                                    //]
                                },
                                new Strat {
                                    Name = "Shinespark",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"canComeInCharged": {
                                    //    "fromNode": 1,
                                    //    "framesRemaining": 0,
                                    //    "shinesparkFrames": 75
                                    //  }},
                                    //  { "heatFrames": 200}
                                    //]
                                },
                                // This is considered faster than Space Screw becomes we can safely
                                // assume carried momentum from previous rooms. The heat frame
                                // count is conservative and assumes only the speed of a 4-tap.
                                new Strat {
                                    Name = "BlueSpace",
                                    Requires = null,
                                    //[ { "heatFrames": 300},
                                    //  "canBlueSpaceJump",
                                    //  {"canComeInCharged": {
                                    //    "fromNode": 1,
                                    //    "framesRemaining": 180,
                                    //    "shinesparkFrames": 0
                                    //  }}
                                    //]
                                },
                                new Strat {
                                    Name = "Power Bomb Pillar Room (Left to Right)",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "Morph",
                                    //  "PowerBomb",
                                    //  {"ammo": {
                                    //    "type": "PowerBomb",
                                    //    "count": 2
                                    //  }},
                                    //  { "heatFrames": 800},
                                    //  { "acidFrames": 50}
                                    //]
                                }
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Pillar Room - Right Door",
                        To = new[] {
                            // Potentially doable with morph bombs and enough energy, maybe, but
                            // let's not go there
                            new LinkTarget("SM - Pillar Room - Left Door", new[] {
                                // Requires some spin canceling to avoid damage from Puromis. It's
                                // pretty risky without Morph. Avoiding acid damage at the last
                                // jump is tricky but possible.
                                new Strat {
                                    Name = "Screw",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "ScrewAttack",
                                    //  {"heatFrames": 600}
                                    //]
                                },
                                new Strat {
                                    Name = "Space Screw",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "ScrewAttack",
                                    //  "SpaceJump",
                                    //  {"heatFrames": 400}
                                    //]
                                },
                                new Strat {
                                    Name = "Shinespark",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"canComeInCharged": {
                                    //    "fromNode": 2,
                                    //    "framesRemaining": 0,
                                    //    "shinesparkFrames": 75
                                    //  }},
                                    //  { "heatFrames": 200}
                                    //]
                                },
                                // Avoiding acid damage at the last jump is tricky but possible.
                                new Strat {
                                    Name = "Power Bomb Pillar Room (Right to Left)",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "Morph",
                                    //  "PowerBomb",
                                    //  {"ammo": {
                                    //    "type": "PowerBomb",
                                    //    "count": 2
                                    //  }},
                                    //  { "acidFrames": 100},
                                    //  { "heatFrames": 650}
                                    //]
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "Pillar Room Puromis",
                        EnemyName = "Puromi",
                        Quantity = 2,
                        BetweenNodes = new[] {
                            "SM - Pillar Room - Left Door",
                            "SM - Pillar Room - Right Door",
                        },
                        DropRequires = null, // ["h_heatProof"]
                    },
                },
            },
            #endregion
            #region The Worst Room In The Game
            new Room {
                Name = "SM - The Worst Room In The Game",
                Layout = Room.LayoutFrom(@"
                      2→X
                        X←3
                        X
                        X
                        X
                      1→X"
                    , "SM - The Worst Room In The Game - Bottom Left Door"
                    , "SM - The Worst Room In The Game - Top Left Door"
                    , "SM - The Worst Room In The Game - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - The Worst Room In The Game - Bottom Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 0,
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
                    new Transition {
                        Name = "SM - The Worst Room In The Game - Top Left Door",
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
                        Name = "SM - The Worst Room In The Game - Right Door",
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
                    new Junction {
                        Name = "SM - The Worst Room In The Game - Above Climb Middle Junction",
                    },
                    new Junction {
                        Name = "SM - The Worst Room In The Game - Before Top Pirate Junction",
                    },
                    // Represents being on the bottom platform with the pirates dead.
                    new Junction {
                        Name = "SM - The Worst Room In The Game - Cleared Bottom Junction",
                    },
                },
                Obstacles = new[] {
                    new Obstacle {
                        Name = "Bomb Blocks",
                        Type = ObstacleType.Inanimate,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - The Worst Room In The Game - Top Left Door",
                        To = new[] {
                            new LinkTarget("SM - The Worst Room In The Game - Right Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 200}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - The Worst Room In The Game - Before Top Pirate Junction", new[] {
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
                        From = "SM - The Worst Room In The Game - Bottom Left Door",
                        To = new[] {
                            // This link is for strats that don't require killing the pirates.
                            new LinkTarget("SM - The Worst Room In The Game - Above Climb Middle Junction", new[] {
                                new Strat {
                                    Name = "Shinespark",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"canComeInCharged": {
                                    //    "fromNode": 2,
                                    //    "framesRemaining": 120,
                                    //    "shinesparkFrames": 40
                                    //  }},
                                    //  {"heatFrames": 400}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle { Name = "Bomb Blocks" },
                                    },
                                },
                                new Strat {
                                    Name = "Writg Frozen Pirates",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canUseFrozenEnemies",
                                    //  "Charge",
                                    //  "h_heatProof"
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Bomb Blocks",
                                            Requires = null, //["h_canDestroyBombWalls"]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Writg X-Ray Climb",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "canRightFacingDoorXRayClimb",
                                    //  {"resetRoom":{
                                    //    "nodes": [2],
                                    //    "mustStayPut": true
                                    //  }},
                                    //  {"enemyDamage": {
                                    //    "enemy": "Namihe",
                                    //    "type": "fireball",
                                    //    "hits": 2
                                    //  }},
                                    //  {"enemyDamage": {
                                    //    "enemy": "Yellow Space Pirate (wall)",
                                    //    "type": "contact",
                                    //    "hits": 1
                                    //  }},
                                    //  { "heatFrames": 600}
                                    //]
                                },
                            }),
                            // It's a one-way link because the way back goes
                            // Above Climb Middle Junction -> Bottom Left Door.
                            new LinkTarget("SM - The Worst Room In The Game - Cleared Bottom Junction", new[] {
                                // Being heatproof allows slower kill methods. Morph bombs are
                                // still excluded because they take 30 bombs each and that's
                                // ridiculous.
                                new Strat {
                                    Name = "HeatProof Pirates Kill",
                                    Requires = null,
                                    //[ "h_heatProof",
                                    //  {"enemyKill":{
                                    //    "enemies": [
                                    //      [ "Yellow Space Pirate (wall)", "Yellow Space Pirate (wall)" ],
                                    //      [ "Yellow Space Pirate (wall)" ]
                                    //    ],
                                    //    "excludedWeapons": [ "Bombs" ]
                                    //  }}
                                    //]
                                },
                                new Strat {
                                    Name = "Screw Attack Pirates Kill",
                                    Requires = null,
                                    //[ "canHeatRun",
                                    //  "ScrewAttack",
                                    //  {"heatFrames": 250}
                                    //]
                                },
                                new Strat {
                                    Name = "Charge Plasma Pirates Kill",
                                    Requires = null,
                                    //[ "canHeatRun",
                                    //  "Charge",
                                    //  "Plasma",
                                    //  { "heatFrames": 600}
                                    //]
                                },
                                new Strat {
                                    Name = "Supers Pirates Kill",
                                    Requires = null,
                                    //[ "canHeatRun",
                                    //  {"enemyKill":{
                                    //    "enemies": [
                                    //      [
                                    //        "Yellow Space Pirate (wall)", "Yellow Space Pirate (wall)", "Yellow Space Pirate (wall)"
                                    //      ]
                                    //    ],
                                    //    "explicitWeapons": [ "Super" ]
                                    //  }},
                                    //  { "heatFrames": 450}
                                    //]
                                },
                                new Strat {
                                    Name = "Full Spazer Pirates Kill",
                                    Requires = null,
                                    //[ "canHeatRun",
                                    //  "Charge",
                                    //  "Ice",
                                    //  "Spazer",
                                    //  "Wave",
                                    //  { "heatFrames": 1150}
                                    //]
                                },
                                // It's not really possible to hit all enemies with double-PB hits
                                // while not taking damage. Using Power Bomb Periphery is based on
                                // a strat that allows killing them and taking out the blocks with
                                // 4 PBs. This calculation ends up taking 5, leaving a spare PB.
                                new Strat {
                                    Name = "Power Bomb Pirates Kill + Bomb Blocks",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"enemyKill":{
                                    //    "enemies": [
                                    //      [
                                    //        "Yellow Space Pirate (wall)", "Yellow Space Pirate (wall)", "Yellow Space Pirate (wall)"
                                    //      ]
                                    //    ],
                                    //    "explicitWeapons": ["PowerBombPeriphery"]
                                    //  }},
                                    //  { "heatFrames": 700}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle { Name = "Bomb Blocks" },
                                    },
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - The Worst Room In The Game - Right Door",
                        To = new[] {
                            new LinkTarget("SM - The Worst Room In The Game - Top Left Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 350}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - The Worst Room In The Game - Before Top Pirate Junction", new[] {
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
                        From = "SM - The Worst Room In The Game - Above Climb Middle Junction",
                        To = new[] {
                            new LinkTarget("SM - The Worst Room In The Game - Bottom Left Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 180}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Bomb Blocks",
                                            Requires = null,
                                            //{"or": [
                                            //  "ScrewAttack",
                                            //  {"and": [
                                            //    "h_canUsePowerBombs",
                                            //    {"heatFrames": 70}
                                            //  ]},
                                            //  {"and": [
                                            //    "h_canUseMorphBombs",
                                            //    { "heatFrames": 200}
                                            //  ]}
                                            //]}
                                        },
                                    },
                                },
                            }),
                            new LinkTarget("SM - The Worst Room In The Game - Before Top Pirate Junction", new[] {
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
                        From = "SM - The Worst Room In The Game - Before Top Pirate Junction",
                        To = new[] {
                            new LinkTarget("SM - The Worst Room In The Game - Top Left Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 400}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - The Worst Room In The Game - Right Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 200}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - The Worst Room In The Game - Above Climb Middle Junction", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 120}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - The Worst Room In The Game - Cleared Bottom Junction",
                        To = new[] {
                            // It's a one-way link because the way back goes
                            // Above Climb Middle Junction -> Bottom Left Door.
                            new LinkTarget("SM - The Worst Room In The Game - Above Climb Middle Junction", new[] {
                                // Space Jump without Screw will be another strat involving PBs.
                                new Strat {
                                    Name = "Space Screw",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "ScrewAttack",
                                    //  "SpaceJump",
                                    //  {"heatFrames": 300}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle { Name = "Bomb Blocks" },
                                    },
                                },
                                new Strat {
                                    Name = "Writg IBJ",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canIBJ",
                                    //  "h_heatProof"
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle { Name = "Bomb Blocks" },
                                    },
                                },
                                new Strat {
                                    Name = "Space",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "SpaceJump",
                                    //  { "heatFrames": 300}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Bomb Blocks",
                                            Requires = null,
                                            //[ "h_canUsePowerBombs",
                                            //  { "heatFrames": 250}
                                            //]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Writg Springwall",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "canSpringwall",
                                    //  { "heatFrames": 300}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Bomb Blocks",
                                            Requires = null,
                                            //[ "h_canUsePowerBombs",
                                            //  { "heatFrames": 250}
                                            //]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Writg Hj Walljump",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "HiJump",
                                    //  "canPreciseWalljump",
                                    //  { "heatFrames": 300}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Bomb Blocks",
                                            Requires = null,
                                            //[ "h_canUsePowerBombs",
                                            //  { "heatFrames": 250}
                                            //]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Writg Hjless Walljump",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canInsaneWalljump",
                                    //  "h_heatProof"
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Bomb Blocks",
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
                        GroupName = "SM - The Worst Room In The Game - Wall Pirates",
                        EnemyName = "Yellow Space Pirate (wall)",
                        Quantity = 3,
                        HomeNodes = new[] { "SM - The Worst Room In The Game - Bottom Left Door" },
                        DropRequires = null, // ["h_heatProof"]
                    },
                    new Enemy {
                        GroupName = "SM - The Worst Room In The Game - Bottom Namihe",
                        EnemyName = "Namihe",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - The Worst Room In The Game - Bottom Left Door" },
                        DropRequires = null, // ["h_heatProof"]
                    },
                    new Enemy {
                        GroupName = "SM - The Worst Room In The Game - Top Namihes",
                        EnemyName = "Namihe",
                        Quantity = 4,
                        HomeNodes = new[] {
                            "SM - The Worst Room In The Game - Above Climb Middle Junction",
                            "SM - The Worst Room In The Game - Before Top Pirate Junction",
                        },
                        DropRequires = null, // ["h_heatProof"]
                    },
                    new Enemy {
                        GroupName = "SM - The Worst Room In The Game - Standing Pirates",
                        EnemyName = "Yellow Space Pirate (standing)",
                        Quantity = 3,
                        HomeNodes = new[] {
                            "SM - The Worst Room In The Game - Above Climb Middle Junction",
                            "SM - The Worst Room In The Game - Before Top Pirate Junction",
                        },
                        DropRequires = null, // ["h_heatProof"]
                    },
                },
            },
            #endregion
            #region Amphitheatre
            new Room {
                Name = "SM - Amphitheatre",
                Layout = Room.LayoutFrom(@"
                         XXX←2
                      1→XXXX
                        XXXX
                        XXXX
                        XXXX"
                    , "SM - Amphitheatre - Left Door"
                    , "SM - Amphitheatre - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Amphitheatre - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 0,
                                OpenEnd = 1,
                                Strats = new[] {
                                    // Just using the open end of this 0-tile runway does take some maneuvering time.
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"heatFrames": 100}
                                        //]
                                    },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Amphitheatre - Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 15,
                                GentleUpTiles = 5,
                                OpenEnd = 0,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"heatFrames": 175}
                                        //]
                                    },
                                },
                            },
                            // With no Enemies.
                            // This longer runway requires taking out the Space Pirate.
                            new RunwayDash {
                                Length = 19,
                                GentleUpTiles = 6,
                                OpenEnd = 1,
                                UsableComingIn = false,
                                Strats = new[] {
                                    new Strat {
                                        Name = "Heatproof Pirate Kill",
                                        Requires = null,
                                        //[ "h_heatProof",
                                        //  {"enemyKill":{
                                        //    "enemies": [
                                        //      [
                                        //        "Yellow Space Pirate (standing)"
                                        //      ]
                                        //    ],
                                        //    "excludedWeapons": [ "Bombs" ]
                                        //  }}
                                        //]
                                    },
                                    new Strat {
                                        Name = "Quick Suitless Pirate Kill",
                                        Requires = null,
                                        //[ "canHeatRun",
                                        //  { "heatFrames": 220},
                                        //  {"enemyKill":{
                                        //    "enemies": [
                                        //      [ "Yellow Space Pirate (standing)" ]
                                        //    ],
                                        //    "explicitWeapons": [ "Super", "ScrewAttack" ]
                                        //  }}
                                        //]
                                    },
                                    new Strat {
                                        Name = "Medium Suitless Pirate Kill",
                                        Requires = null,
                                        //[ "canHeatRun",
                                        //  { "heatFrames": 450},
                                        //  {"enemyKill":{
                                        //    "enemies": [
                                        //      [ "Yellow Space Pirate (standing)" ]
                                        //    ],
                                        //    "explicitWeapons": [ "Missile", "Charge+Plasma" ]
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
                        From = "SM - Amphitheatre - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Amphitheatre - Right Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 1300}
                                    //]
                                },
                                // Todo: Name is "SpaceJump", but no SpaceJump in the Condition
                                new Strat {
                                    Name = "SpaceJump",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 1100}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Amphitheatre - Right Door",
                        To = new[] {
                            // Without HiJump or any suit it can be done with Crystal Flash but
                            // will keep that out for now.
                            new LinkTarget("SM - Amphitheatre - Left Door", new[] {
                                new Strat {
                                    Name = "Gravity Reverse Amphitheatre",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "Gravity",
                                    //  { "heatFrames": 800},
                                    //  { "acidFrames": 650}
                                    //]
                                },
                                new Strat {
                                    Name = "Gravityless Reverse Amphitheatre",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "HiJump",
                                    //  "canSuitlessLavaDive",
                                    //  { "heatFrames": 950},
                                    //  { "acidFrames": 800}
                                    //]
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "Amphitheatre Top Pirate",
                        EnemyName = "Yellow Space Pirate (standing)",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Amphitheatre - Right Door" },
                        DropRequires = null, // ["h_heatProof"]
                    },
                    // Technically you can get the drops but you likely won't.
                    new Enemy {
                        GroupName = "Amphitheatre Acid Pirates",
                        EnemyName = "Yellow Space Pirate (standing)",
                        Quantity = 8,
                        BetweenNodes = new[] {
                            "SM - Amphitheatre - Left Door",
                            "SM - Amphitheatre - Right Door",
                        },
                        DropRequires = null, // ["never"]
                    },
                },
            },
            #endregion
            #region Red Kihunter Shaft
            new Room {
                Name = "SM - Red Kihunter Shaft",
                Layout = Room.LayoutFrom(@"
                      1→X←2
                        X
                        X
                        X←3
                        XXX
                          ↑
                          4"
                    , "SM - Red Kihunter Shaft - Left Door"
                    , "SM - Red Kihunter Shaft - Top Right Door"
                    , "SM - Red Kihunter Shaft - Bottom Right Door"
                    , "SM - Red Kihunter Shaft - Bottom Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Red Kihunter Shaft - Left Door",
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
                            // With Broken Blocks.
                            new RunwayDash {
                                Length = 12,
                                OpenEnd = 0,
                                UsableComingIn = false,
                                Strats = new[] {
                                    // This longer runway's not usable if the shot blocks are destroyed.
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"resetRoom":{
                                        //    "nodes": [1, 4],
                                        //    "nodesToAvoid": [3]
                                        //  }},
                                        //  { "heatFrames": 175}
                                        //]
                                    },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Red Kihunter Shaft - Top Right Door",
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
                            // With Broken Blocks.
                            new RunwayDash {
                                Length = 12,
                                OpenEnd = 0,
                                UsableComingIn = false,
                                Strats = new[] {
                                    // This longer runway's not usable if the shot blocks are destroyed.
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"resetRoom":{
                                        //    "nodes": [1, 4],
                                        //    "nodesToAvoid": [3]
                                        //  }},
                                        //  { "heatFrames": 175}
                                        //]
                                    },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Red Kihunter Shaft - Bottom Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 10,
                                GentleDownTiles = 2,
                                GentleUpTiles = 2,
                                OpenEnd = 1,
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
                    new Transition {
                        Name = "SM - Red Kihunter Shaft - Bottom Door",
                        Type = TransitionType.Yellow,
                        Locks = new[] {
                            new Lock {
                                Name = "Red Kihunter Shaft Yellow Lock (to Wasteland)",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenYellowDoors"]*/ },
                                },
                            },
                        },
                    },
                    new Junction {
                        Name = "SM - Red Kihunter Shaft - Top Junction",
                    },
                    // The inner left portion of the morph tunnel, just to the right of the bomb blocks
                    new Junction {
                        Name = "SM - Red Kihunter Shaft - Left Morph Tunnel Junction",
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Red Kihunter Shaft - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Red Kihunter Shaft - Top Junction", new[] {
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
                        From = "SM - Red Kihunter Shaft - Bottom Door",
                        To = new[] {
                            new LinkTarget("SM - Red Kihunter Shaft - Left Morph Tunnel Junction", new[] {
                                new Strat {
                                    Name = "Morph Bombs",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "h_canUseMorphBombs",
                                    //  { "heatFrames": 300}
                                    //]
                                },
                                new Strat {
                                    Name = "Power Bombs",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "h_canUsePowerBombs",
                                    //  { "heatFrames": 300}
                                    //]
                                },
                                new Strat {
                                    Name = "Screw Attack",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "Morph",
                                    //  "ScrewAttack",
                                    //  { "heatFrames": 250}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Red Kihunter Shaft - Bottom Right Door",
                        To = new[] {
                            new LinkTarget("SM - Red Kihunter Shaft - Top Junction", new[] {
                                // Assumes the first Kihunter gets dodged and not killed.
                                new Strat {
                                    Name = "HeatProof Kihunter Kill",
                                    Requires = null,
                                    //[ "h_heatProof",
                                    //  {"enemyKill":{
                                    //    "enemies": [
                                    //      [ "Kihunter (red)", "Kihunter (red)" ]
                                    //    ]
                                    //  }}
                                    //]
                                },
                                // Most RNG patterns allow for 0 or 1 hits without weapon but some
                                // require 2 and a bit of extra time.
                                new Strat {
                                    Name = "HeatProof Run Through",
                                    Requires = null,
                                    //[ "h_heatProof",
                                    //  {"enemyDamage": {
                                    //    "enemy": "Kihunter (red)",
                                    //    "type": "contact",
                                    //    "hits": 2
                                    //  }}
                                    //]
                                },
                                // Most RNG patterns allow for 0 or 1 hits without weapon but some
                                // require 2 and a bit of extra time.
                                new Strat {
                                    Name = "Heat Run Through",
                                    Requires = null,
                                    //[ "canHeatRun",
                                    //  { "heatFrames": 850},
                                    //  {"enemyDamage": {
                                    //    "enemy": "Kihunter (red)",
                                    //    "type": "contact",
                                    //    "hits": 2
                                    //  }}
                                    //]
                                },
                                new Strat {
                                    Name = "Wave Plasma Kill",
                                    Requires = null,
                                    //[ "canHeatRun",
                                    //  "Wave",
                                    //  "Plasma",
                                    //  { "heatFrames": 1150}
                                    //]
                                },
                                new Strat {
                                    Name = "Screw Kill",
                                    Requires = null,
                                    //[ "canHeatRun",
                                    //  "ScrewAttack",
                                    //  { "heatFrames": 650}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Red Kihunter Shaft - Left Morph Tunnel Junction", new[] {
                                new Strat {
                                    Name = "Morph Bombs",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "h_canUseMorphBombs",
                                    //  { "heatFrames": 400}
                                    //]
                                },
                                new Strat {
                                    Name = "Power Bombs",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "h_canUsePowerBombs",
                                    //  { "heatFrames": 250}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Red Kihunter Shaft - Top Right Door",
                        To = new[] {
                            new LinkTarget("SM - Red Kihunter Shaft - Top Junction", new[] {
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
                        From = "SM - Red Kihunter Shaft - Top Junction",
                        To = new[] {
                            new LinkTarget("SM - Red Kihunter Shaft - Left Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 50}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Red Kihunter Shaft - Top Right Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 50}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Red Kihunter Shaft - Bottom Right Door", new[] {
                                // The KiHunters are much easier to avoid coming in from above, no
                                // need to kill them.
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
                        From = "SM - Red Kihunter Shaft - Left Morph Tunnel Junction",
                        To = new[] {
                            new LinkTarget("SM - Red Kihunter Shaft - Bottom Door", new[] {
                                new Strat {
                                    Name = "Morph Bombs",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "h_canUseMorphBombs",
                                    //  {"heatFrames": 350}
                                    //]
                                },
                                // "FIXME This strat also unlocks Bottom Door. Could add that in later?
                                new Strat {
                                    Name = "Power Bombs",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "h_canUsePowerBombs",
                                    //  {"heatFrames": 300}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Red Kihunter Shaft - Bottom Right Door", new[] {
                                new Strat {
                                    Name = "Morph Bombs",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "h_canUseMorphBombs",
                                    //  { "heatFrames": 500}
                                    //]
                                },
                                new Strat {
                                    Name = "Power Bombs",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "Morph",
                                    //  "PowerBomb",
                                    //  {"ammo": {
                                    //    "type": "PowerBomb",
                                    //    "count": 2
                                    //  }},
                                    //  { "heatFrames": 400}
                                    //]
                                },
                                // This requires Power Bombs because it saves neither energy nor
                                // ammo using Morph Bombs. It's slower than Spring Ball mainly
                                // because X-Ray scope won't activate during the PB explosion.
                                new Strat {
                                    Name = "Red Kihunter Shaft X-Ray Clip",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "h_canUsePowerBombs",
                                    //  "canXRayStandUp",
                                    //  "canCeilingClip",
                                    //  { "heatFrames": 400}
                                    //]
                                },
                                new Strat {
                                    Name = "Spring Power Bombs",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "h_canUsePowerBombs",
                                    //  "SpringBall",
                                    //  { "heatFrames": 350}
                                    //]
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "Red Kihunter Shaft Bottom Kihunter",
                        EnemyName = "Kihunter (red)",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Red Kihunter Shaft - Bottom Right Door" },
                        DropRequires = null, // ["h_heatProof"]
                    },
                    new Enemy {
                        GroupName = "Red Kihunter Shaft Top Kihunters",
                        EnemyName = "Kihunter (red)",
                        Quantity = 2,
                        BetweenNodes = new[] {
                            "SM - Red Kihunter Shaft - Bottom Right Door",
                            "SM - Red Kihunter Shaft - Top Junction",
                        },
                        DropRequires = null, // ["h_heatProof"]
                    },
                },
            },
            #endregion
            #region Wasteland
            new Room {
                Name = "SM - Wasteland",
                Layout = Room.LayoutFrom(@"
                            2
                            ↓
                       XXXXXX
                        X
                      1→X"
                    , "SM - Wasteland - Left Door"
                    , "SM - Wasteland - Top Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Wasteland - Left Door",
                        Type = TransitionType.Green,
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
                                Name = "SM - Wasteland - Green Lock",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenGreenDoors"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Wasteland - Top Door",
                        Type = TransitionType.Blue,
                    },
                    new Placement {
                        Name = "SM - Wasteland - Item",
                        Type = PlacementType.Visible,
                    },
                    // This includes either having killed the Dessgeega or having iframes so you can leave without further damage.
                    new Junction {
                        Name = "SM - Wasteland - Handled Enemy PB Blocks Junction",
                    },
                    // This means being just below the central junction, before dealing with the Dessgeega.
                    new Junction {
                        Name = "SM - Wasteland - Unhandled Enemy PB Blocks Junction",
                    },
                    // This means being just left of the central junction, before dealing with the Dessgeega.
                    new Junction {
                        Name = "SM - Wasteland - Left of PB Blocks Junction",
                    },
                    new Junction {
                        Name = "SM - Wasteland - Left Morph Tunnel Junction",
                    },
                },
                Obstacles = new[] {
                    new Obstacle {
                        Name = "Power Bomb Blocks",
                        Type = ObstacleType.Inanimate,
                    },
                    new Obstacle {
                        Name = "Bomb Blocks of Shame",
                        Type = ObstacleType.Inanimate,
                    },
                    new Obstacle {
                        Name = "Dessgeega on PB-blocks",
                        Type = ObstacleType.Enemies,
                    },
                    new Obstacle {
                        Name = "3 Dessgeegas",
                        Type = ObstacleType.Enemies,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Wasteland - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Wasteland - Unhandled Enemy PB Blocks Junction", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 580 },
                                    //  { "or": [
                                    //    "canWalljump",
                                    //    { "heatFrames": 200 }
                                    //  ]}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Power Bomb Blocks",
                                            Requires = null,
                                            //[ "h_canUsePowerBombs",
                                            //  { "heatFrames": 120 }
                                            //]
                                            AdditionalObstacles = new[] { "Bomb Blocks of Shame" },
                                        },
                                    },
                                },
                            }),
                            // This is a one-way link for the X-Ray climb, because it brings you to
                            // the left of the Dessgeega at the top.
                            new LinkTarget("SM - Wasteland - Left of PB Blocks Junction", new[] {
                                new Strat {
                                    Name = "Wasteland X-Ray Climb",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "canRightFacingDoorXRayClimb",
                                    //  {"resetRoom":{
                                    //    "nodes":[1],
                                    //    "mustStayPut": true
                                    //  }},
                                    //  { "heatFrames": 700 }
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Wasteland - Top Door",
                        To = new[] {
                            new LinkTarget("SM - Wasteland - Left Morph Tunnel Junction", new[] {
                                new Strat {
                                    Name = "Morph Bombs",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "h_canUseMorphBombs",
                                    //  {"heatFrames": 350}
                                    //]
                                },
                                new Strat {
                                    Name = "Power Bombs",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "Morph",
                                    //  "PowerBomb",
                                    //  {"ammo": {
                                    //    "type": "PowerBomb",
                                    //    "count": 2
                                    //  }},
                                    //  { "heatFrames": 350}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Wasteland - Item",
                        To = new[] {
                            new LinkTarget("SM - Wasteland - Left of PB Blocks Junction", new[] {
                                // It's not possible to reach Item without destroying
                                // Bomb Blocks of Shame. So no need to elaborate on how it can be
                                // destroyed from here and how many heat frames it would take.
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "Morph",
                                    //  {"heatFrames": 120}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Bomb Blocks of Shame",
                                            Requires = null, // ["never"]
                                        },
                                    },
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Wasteland - Handled Enemy PB Blocks Junction",
                        To = new[] {
                            new LinkTarget("SM - Wasteland - Unhandled Enemy PB Blocks Junction"),
                            new LinkTarget("SM - Wasteland - Left of PB Blocks Junction", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 100}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Wasteland - Left Morph Tunnel Junction", new[] {
                                new Strat {
                                    Name = "Tank the Damage",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 250},
                                    //  {"enemyDamage": {
                                    //    "enemy": "Dessgeega",
                                    //    "type": "contact",
                                    //    "hits": 1
                                    //  }}
                                    //]
                                },
                                new Strat {
                                    Name = "HeatProof Kill",
                                    Requires = null, // ["h_heatProof"]
                                    Obstacles = new[] {
                                        // Morph Bombs excluded because that'd probably cost more health than just running through.
                                        new Strat.Obstacle {
                                            Name = "3 Dessgeegas",
                                            Requires = null,
                                            //{"enemyKill":{
                                            //  "enemies": [
                                            //    [ "Dessgeega" ]
                                            //  ],
                                            //  "excludedWeapons": [ "Bombs" ]
                                            //}}
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Screw Kill",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 200}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "3 Dessgeegas",
                                            Requires = null,
                                            //[ { "heatFrames": 100},
                                            //  "ScrewAttack"
                                            //]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Supers Kill",
                                    Notable = false,
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 200}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "3 Dessgeegas",
                                            Requires = null,
                                            //[ { "heatFrames": 350},
                                            //  {"enemyKill":{
                                            //    "enemies": [
                                            //      [
                                            //        "Dessgeega", "Dessgeega", "Dessgeega"
                                            //      ]
                                            //    ],
                                            //    "explicitWeapons": [ "Super" ]
                                            //  }}
                                            //]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Beam Kill",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 200}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "3 Dessgeegas",
                                            Requires = null,
                                            //[ { "heatFrames": 350},
                                            //  "Plasma",
                                            //  {"or": [
                                            //    "Ice",
                                            //    "Wave"
                                            //  ]}
                                            //]
                                        },
                                    },
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Wasteland - Unhandled Enemy PB Blocks Junction",
                        To = new[] {
                            new LinkTarget("SM - Wasteland - Left Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 600}
                                    //]
                                    Obstacles = new[] {
                                        // This expects that the PB gets used a bit before the node
                                        // is actually reached. This is why the full wait time
                                        // isn't included in heat frames.
                                        new Strat.Obstacle {
                                            Name = "Power Bomb Blocks",
                                            Requires = null,
                                            //[ "h_canUsePowerBombs",
                                            //  {"heatFrames": 50}
                                            //]
                                            AdditionalObstacles = new[] { "Bomb Blocks of Shame" },
                                        },
                                    },
                                },
                            }),
                            // No strat specifically for if the enemy is just dead, since all the
                            // different kill strats require nothing if it's already dead.
                            new LinkTarget("SM - Wasteland - Handled Enemy PB Blocks Junction", new[] {
                                // Morph Bombs excluded because that'd probably cost more health
                                // than just running through.
                                new Strat {
                                    Name = "HeatProof Kill",
                                    Requires = null, // ["h_heatProof"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Dessgeega on PB-blocks",
                                            Requires = null,
                                            //{"enemyKill":{
                                            //  "enemies": [
                                            //    [ "Dessgeega" ]
                                            //  ],
                                            //  "excludedWeapons": [ "Bombs" ]
                                            //}}
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Tank the Damage",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 50 },
                                    //  {"enemyDamage": {
                                    //    "enemy": "Dessgeega",
                                    //    "type": "contact",
                                    //    "hits": 1
                                    //  }}
                                    //]
                                },
                                new Strat {
                                    Name = "Screw Kill",
                                    Requires = null, // ["h_canNavigateHeatRooms"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Dessgeega on PB-blocks",
                                            Requires = null,
                                            //[ { "heatFrames": 100 },
                                            //  "ScrewAttack"
                                            //]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Supers Kill",
                                    Requires = null, // ["h_canNavigateHeatRooms"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Dessgeega on PB-blocks",
                                            Requires = null,
                                            //[ { "heatFrames": 100 },
                                            //  {"enemyKill":{
                                            //    "enemies": [
                                            //      [ "Dessgeega" ]
                                            //    ],
                                            //    "explicitWeapons": [ "Super" ]
                                            //  }}
                                            //]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Beam Kill",
                                    Requires = null, // ["h_canNavigateHeatRooms"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Dessgeega on PB-blocks",
                                            Requires = null,
                                            //[ { "heatFrames": 100 },
                                            //  "Plasma",
                                            //  {"or": [
                                            //    "Ice",
                                            //    "Wave"
                                            //  ]}
                                            //]
                                        },
                                    },
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Wasteland - Left of PB Blocks Junction",
                        To = new[] {
                            new LinkTarget("SM - Wasteland - Item", new[] {
                                new Strat {
                                    Name = "Screw",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 100},
                                    //  "Morph"
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Bomb Blocks of Shame",
                                            Requires = null, // ["ScrewAttack"]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Morph Bombs",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 100},
                                    //  "Morph"
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Bomb Blocks of Shame",
                                            Requires = null,
                                            //[ { "heatFrames": 100},
                                            //  "h_canUseMorphBombs"
                                            //]
                                        },
                                    },
                                },
                                // This expects that the PB is used earlier, avoiding the need to wait for the blast.
                                new Strat {
                                    Name = "Power Bombs",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 100},
                                    //  "Morph"
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Bomb Blocks of Shame",
                                            Requires = null, // ["h_canUsePowerBombs"]
                                            AdditionalObstacles = new[] { "Power Bomb Blocks" },
                                        },
                                    },
                                },
                            }),
                            new LinkTarget("SM - Wasteland - Handled Enemy PB Blocks Junction", new[] {
                                new Strat {
                                    Name = "Tank the Damage",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 130},
                                    //  {"enemyDamage": {
                                    //    "enemy": "Dessgeega",
                                    //    "type": "contact",
                                    //    "hits": 1
                                    //  }}
                                    //]
                                },
                                // Morph Bombs excluded because that'd probably cost more health
                                // than just running through.
                                new Strat {
                                    Name = "HeatProof Kill",
                                    Requires = null, // ["h_heatProof"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Dessgeega on PB-blocks",
                                            Requires = null,
                                            //{"enemyKill":{
                                            //  "enemies": [
                                            //    [ "Dessgeega" ]
                                            //  ],
                                            //  "excludedWeapons": [ "Bombs" ]
                                            //}}
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Screw Kill",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 80}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Dessgeega on PB-blocks",
                                            Requires = null,
                                            //[ { "heatFrames": 50},
                                            //  "ScrewAttack"
                                            //]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Supers Kill",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 80}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Dessgeega on PB-blocks",
                                            Requires = null,
                                            //[ { "heatFrames": 50},
                                            //  {"enemyKill":{
                                            //    "enemies": [
                                            //      [
                                            //        "Dessgeega"
                                            //      ]
                                            //    ],
                                            //    "explicitWeapons": [ "Super" ]
                                            //  }}
                                            //]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Beam Kill",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 80}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Dessgeega on PB-blocks",
                                            Requires = null,
                                            //[ { "heatFrames": 50},
                                            //  "Plasma",
                                            //  {"or": [
                                            //    "Ice",
                                            //    "Wave"
                                            //  ]}
                                            //]
                                        },
                                    },
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Wasteland - Left Morph Tunnel Junction",
                        To = new[] {
                            new LinkTarget("SM - Wasteland - Top Door", new[] {
                                // The hibashi hit can be avoided by waiting for the pillar to go
                                // up. That requires the use of one PB and more time than is worth
                                // unless heat proof.
                                new Strat {
                                    Name = "Avoid Hibashi",
                                    Requires = null,
                                    //[ "h_heatProof",
                                    //  "Morph",
                                    //  "h_canUsePowerBombs",
                                    //  {"or":[
                                    //    "Bombs",
                                    //    {"ammo": {
                                    //      "type": "PowerBomb",
                                    //      "count": 1
                                    //    }}
                                    //  ]}
                                    //]
                                },
                                new Strat {
                                    Name = "Morph Bombs",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "h_canUseMorphBombs",
                                    //  { "heatFrames": 400},
                                    //  { "hibashiHits": 1}
                                    //]
                                },
                                new Strat {
                                    Name = "Power Bombs",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "Morph",
                                    //  "PowerBomb",
                                    //  {"ammo": {
                                    //    "type": "PowerBomb",
                                    //    "count": 2
                                    //  }},
                                    //  { "heatFrames": 400},
                                    //  { "hibashiHits": 1}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Wasteland - Handled Enemy PB Blocks Junction", new[] {
                                new Strat {
                                    Name = "Tank the Damage",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 200},
                                    //  {"enemyDamage": {
                                    //    "enemy": "Dessgeega",
                                    //    "type": "contact",
                                    //    "hits": 2
                                    //  }}
                                    //]
                                },
                                new Strat {
                                    Name = "HeatProof Kill",
                                    Requires = null, // ["h_heatProof"]
                                    Obstacles = new[] {
                                        // Morph Bombs are not excluded here because there are
                                        // consistent, safe setups for all Dessgeegas from this
                                        // direction.
                                        new Strat.Obstacle {
                                            Name = "3 Dessgeegas",
                                            Requires = null,
                                            //{"enemyKill":{
                                            //  "enemies": [
                                            //    [ "Dessgeega" ],
                                            //    [ "Dessgeega" ],
                                            //    [ "Dessgeega", "Dessgeega"]
                                            //  ]
                                            //}}
                                            AdditionalObstacles = new[] { "C" },
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Screw Kill",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 150}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "3 Dessgeegas",
                                            Requires = null,
                                            //[ "ScrewAttack",
                                            //  { "heatFrames": 150}
                                            //]
                                            AdditionalObstacles = new[] { "C" },
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Supers Kill",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 150}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "3 Dessgeegas",
                                            Requires = null,
                                            //[ { "heatFrames":450},
                                            //  {"enemyKill":{
                                            //    "enemies": [
                                            //      [
                                            //        "Dessgeega", "Dessgeega", "Dessgeega", "Dessgeega"
                                            //      ]
                                            //    ],
                                            //    "explicitWeapons": [ "Super" ]
                                            //  }}
                                            //]
                                            AdditionalObstacles = new[] { "C" },
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Beam Kill",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 150}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "3 Dessgeegas",
                                            Requires = null,
                                            //[ { "heatFrames":450},
                                            //  "Plasma",
                                            //  {"or": [
                                            //    "Ice",
                                            //    "Wave"
                                            //  ]}
                                            //]
                                            AdditionalObstacles = new[] { "C" },
                                        },
                                    },
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Wasteland - Left Dessgeega",
                        EnemyName = "Dessgeega",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Wasteland - Handled Enemy PB Blocks Junction" },
                        DropRequires = null, // ["h_heatProof"]
                    },
                    new Enemy {
                        GroupName = "SM - Wasteland - Right Dessgeegas",
                        EnemyName = "Dessgeega",
                        Quantity = 3,
                        BetweenNodes = new[] {
                            "SM - Wasteland - Handled Enemy PB Blocks Junction",
                            "SM - Wasteland - Left Morph Tunnel Junction",
                        },
                        DropRequires = null, // ["h_heatProof"]
                    },
                },
            },
            #endregion
            #region Metal Pirates Room
            new Room {
                Name = "SM - Metal Pirates Room",
                Layout = Room.LayoutFrom(@"
                      1→XXX←2"
                    , "SM - Metal Pirates Room - Left Door"
                    , "SM - Metal Pirates Room - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Metal Pirates Room - Left Door",
                        Type = TransitionType.Gray,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 0,
                                OpenEnd = 1,
                                Strats = new[] {
                                    // Just using the open end of this 0-tile runway does take some
                                    // maneuvering time.
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"heatFrames": 100}
                                        //]
                                    },
                                },
                            },
                        },
                        CanLeaveCharged = new[] {
                            new RunwayCharge {
                                Length =  33,
                                OpenEnd = 2,
                                FramesRemaining = 120,
                                Strats = new[] {
                                    new Strat {
                                        Name = "Kill the Pirates",
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"heatFrames": 400}
                                        //]
                                        Obstacles = new[] {
                                            new Strat.Obstacle {
                                                Name = "Metal Pirates",
                                                Requires = null, // {"heatFrames": 50}
                                            },
                                        },
                                    },
                                    new Strat {
                                        Name = "Hitbox Through Pirates",
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  { "heatFrames": 400},
                                        //  "canHitbox"
                                        //]
                                    },
                                },
                            },
                        },
                        Locks = new[] {
                            // The requirements for obstacle A are on the obstacle itself.
                            new Lock {
                                Name = "Metal Pirates Grey Lock (to Plowerhouse)",
                                Type = LockType.KillEnemies,
                                UnlockStrats = new[] {
                                    new Strat {
                                        Obstacles = new[] {
                                            new Strat.Obstacle { Name = "Metal Pirates" },
                                        },
                                    },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Metal Pirates Room - Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 0,
                                OpenEnd = 1,
                                Strats = new[] {
                                    // Just using the open end of this 0-tile runway does take some
                                    // maneuvering time.
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"heatFrames": 100}
                                        //]
                                    },
                                },
                            },
                        },
                        CanLeaveCharged = new[] {
                            new RunwayCharge {
                                Length = 33,
                                OpenEnd = 2,
                                FramesRemaining = 120,
                                Strats = new[] {
                                    new Strat {
                                        Name = "Kill the Pirates",
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"heatFrames": 400}
                                        //]
                                        Obstacles = new[] {
                                            new Strat.Obstacle {
                                                Name = "Metal Pirates",
                                                Requires = null // {"heatFrames": 50}
                                            },
                                        },
                                    },
                                    new Strat {
                                        Name = "Hitbox Through Pirates",
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  { "heatFrames": 400},
                                        //  "canHitbox"
                                        //]
                                    },
                                },
                            },
                        },
                    },
                },
                Obstacles = new[] {
                    new Obstacle {
                        Name = "Metal Pirates",
                        Type = ObstacleType.Enemies,
                        Requires = null,
                        //[ {"or": [
                        //    "h_heatProof",
                        //    "canHeatRun"
                        //  ]},
                        //  {"or": [
                        //    {"and": [
                        //      "Charge",
                        //      "Plasma",
                        //      {"or": [
                        //        {"heatFrames": 950},
                        //        {"and": [
                        //          "Ice",
                        //          {"or": [
                        //            {"heatFrames": 700},
                        //            {"and": [
                        //              "Wave",
                        //              { "heatFrames": 450}
                        //            ]}
                        //          ]}
                        //        ]}
                        //      ]}
                        //    ]},
                        //    {"and": [
                        //      "Charge",
                        //      "Spazer",
                        //      "Ice",
                        //      "Wave",
                        //      { "heatFrames": 1750}
                        //    ]},
                        //    {"and": [
                        //      {"enemyKill":{
                        //        "enemies": [
                        //          [ "Space Pirate (fighting)", "Space Pirate (fighting)" ]
                        //        ],
                        //        "explicitWeapons": [ "Super" ]
                        //      }},
                        //      { "heatFrames": 450}
                        //    ]}
                        //  ]}
                        //]
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Metal Pirates Room - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Metal Pirates Room - Right Door", new[] {
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
                        From = "SM - Metal Pirates Room - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Metal Pirates Room - Left Door", new[] {
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
                        GroupName = "SM - Metal Pirates Room - Metal Pirates",
                        EnemyName = "Space Pirate (fighting)",
                        Quantity = 2,
                        HomeNodes = new[] {
                            "SM - Metal Pirates Room - Left Door",
                            "SM - Metal Pirates Room - Right Door",
                        },
                        DropRequires = null, // ["h_heatProof"]
                    },
                },
            },
            #endregion
            #region Plowerhouse Room
            new Room {
                Name = "SM - Plowerhouse Room",
                Layout = Room.LayoutFrom(@"
                      1→XXX←2"
                    , "SM - Plowerhouse - Left Door"
                    , "SM - Plowerhouse - Right Door"
                ),
                Nodes = new Node[] {
                    // FIXME can leave charged by charging in the acid.
                    new Transition {
                        Name = "SM - Plowerhouse - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 1,
                                UsableComingIn = false,
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
                    // FIXME can leave charged by charging in the acid.
                    new Transition {
                        Name = "SM - Plowerhouse - Right Door",
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
                },
                Links = new[] {
                    new Link {
                        From = "SM - Plowerhouse - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Plowerhouse - Right Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 600}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Plowerhouse - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Plowerhouse - Left Door", new[] {
                                new Strat { Requires = null /*["h_heatProof"]*/ },
                                new Strat {
                                    Name = "Base HeatRun",
                                    Requires = null,
                                    //[ "canHeatRun",
                                    //  { "heatFrames": 450},
                                    //  {"enemyDamage": {
                                    //    "enemy": "Zebbo",
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
                        GroupName = "Plowerhouse Room Holtzes",
                        EnemyName = "Holtz",
                        Quantity = 6,
                        HomeNodes = new[] {
                            "SM - Plowerhouse - Left Door",
                            "SM - Plowerhouse - Right Door",
                        },
                        DropRequires = null, // ["h_heatProof"]
                    },
                    new Enemy {
                        GroupName = "Plowerhouse Room Left Zebbo",
                        EnemyName = "Zebbo",
                        Quantity = 1,
                        HomeNodes = new[] {
                            "SM - Plowerhouse - Left Door",
                            "SM - Plowerhouse - Right Door",
                        },
                        FarmCycles = new[] {
                            new FarmCycle {
                                Name = "Crouch over spawn point",
                                CycleFrames = 120,
                                Requires = null,
                                //[ "h_canNavigateHeatRooms",
                                //  {"heatFrames": 120}
                                //]
                            },
                        },
                    },
                    new Enemy {
                        GroupName = "Plowerhouse Room Middle Zebbo",
                        EnemyName = "Zebbo",
                        Quantity = 1,
                        HomeNodes = new[] {
                            "SM - Plowerhouse - Left Door",
                            "SM - Plowerhouse - Right Door",
                        },
                        FarmCycles = new[] {
                            new FarmCycle {
                                Name = "Crouch over spawn point",
                                CycleFrames = 120,
                                Requires = null,
                                //[ "h_canNavigateHeatRooms",
                                //  { "heatFrames": 120}
                                //]
                            },
                        },
                    },
                    new Enemy {
                        GroupName = "Plowerhouse Room Right Zebbo",
                        EnemyName = "Zebbo",
                        Quantity = 1,
                        HomeNodes = new[] {
                            "SM - Plowerhouse - Left Door",
                            "SM - Plowerhouse - Right Door",
                        },
                        FarmCycles = new[] {
                            new FarmCycle {
                                Name = "Crouch over spawn point",
                                CycleFrames = 120,
                                Requires = null,
                                //[ "h_canNavigateHeatRooms",
                                //  { "heatFrames": 120}
                                //]
                            },
                        },
                    },
                },
            },
            #endregion
            #region Norfair Lower Farming Room
            new Room {
                Name = "SM - Norfair Lower Farming Room",
                Layout = Room.LayoutFrom(@"
                      1→XXX←2"
                    , "SM - Norfair Lower Farming Room - Left Door"
                    , "SM - Norfair Lower Farming Room - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Norfair Lower Farming Room - Left Door",
                        Type = TransitionType.Gedora,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 0,
                                OpenEnd = 1,
                                Strats = new[] {
                                    // Just using the open end of this 0-tile runway does take some
                                    // maneuvering time.
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"heatFrames": 100}
                                        //]
                                    },
                                },
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Norfair Lower Farming Room - Eye Lock",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenEyeDoors"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Norfair Lower Farming Room - Right Door",
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
                },
                Links = new[] {
                    new Link {
                        From = "SM - Norfair Lower Farming Room - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Norfair Lower Farming Room - Right Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 400}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Norfair Lower Farming Room - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Norfair Lower Farming Room - Left Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 500}
                                    //]
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "Lower Norfair Farming Left Zebbos",
                        EnemyName = "Zebbo",
                        Quantity = 2,
                        HomeNodes = new[] {
                            "SM - Norfair Lower Farming Room - Left Door",
                            "SM - Norfair Lower Farming Room - Right Door",
                        },
                        FarmCycles = new[] {
                            // Involves tiny hops to get the drops as well.
                            new FarmCycle {
                                Name = "Turnaround two tiles above spawn",
                                CycleFrames = 240,
                                Requires = null,
                                //[ "h_canNavigateHeatRooms",
                                //  {"heatFrames": 240}
                                //]
                            },
                            new FarmCycle {
                                Name = "Grapple turnaround two tiles above spawn",
                                CycleFrames = 175,
                                Requires = null,
                                //[ "Grapple",
                                //  "h_canNavigateHeatRooms",
                                //  {"heatFrames": 175}
                                //]
                            },
                        },
                    },
                    new Enemy {
                        GroupName = "Lower Norfair Farming Middle Zebbos",
                        EnemyName = "Zebbo",
                        Quantity = 2,
                        HomeNodes = new[] {
                            "SM - Norfair Lower Farming Room - Left Door",
                            "SM - Norfair Lower Farming Room - Right Door",
                        },
                        FarmCycles = new[] {
                            // Involves tiny hops to get the drops as well.
                            new FarmCycle {
                                Name = "Turnaround two tiles above spawn",
                                CycleFrames = 240,
                                Requires = null,
                                //[ "h_canNavigateHeatRooms",
                                //  { "heatFrames": 240}
                                //]
                            },
                            new FarmCycle {
                                Name = "Grapple turnaround two tiles above spawn",
                                CycleFrames = 175,
                                Requires = null,
                                //[ "Grapple",
                                //  "h_canNavigateHeatRooms",
                                //  { "heatFrames": 175}
                                //]
                            },
                        },
                    },
                    new Enemy {
                        GroupName = "Lower Norfair Farming Right Zebbos",
                        EnemyName = "Zebbo",
                        Quantity = 2,
                        HomeNodes = new[] {
                            "SM - Norfair Lower Farming Room - Left Door",
                            "SM - Norfair Lower Farming Room - Right Door",
                        },
                        FarmCycles = new[] {
                            // Involves tiny hops to get the drops as well.
                            new FarmCycle {
                                Name = "Turnaround two tiles above spawn",
                                CycleFrames = 240,
                                Requires = null,
                                //[ "h_canNavigateHeatRooms",
                                //  { "heatFrames": 240}
                                //]
                            },
                            new FarmCycle {
                                Name = "Grapple turnaround two tiles above spawn",
                                CycleFrames = 175,
                                Requires = null,
                                //[ "Grapple",
                                //  "h_canNavigateHeatRooms",
                                //  { "heatFrames": 175}
                                //]
                            },
                        },
                    },
                    new Enemy {
                        GroupName = "Lower Norfair Farming Room Violas",
                        EnemyName = "Viola",
                        Quantity = 5,
                        HomeNodes = new[] {
                            "SM - Norfair Lower Farming Room - Left Door",
                            "SM - Norfair Lower Farming Room - Right Door",
                        },
                        DropRequires = null, // ["h_heatProof"]
                    },
                },
            },
            #endregion
            #region Ridley's Room
            new Room {
                Name = "SM - Ridley's Room",
                Layout = Room.LayoutFrom(@"
                        X←2
                      1→X"
                    , "SM - Ridley's Room - Left Door"
                    , "SM - Ridley's Room - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Ridley's Room - Left Door",
                        Type = TransitionType.Gray,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 0,
                                OpenEnd = 1,
                                Strats = new[] {
                                    // Just using the open end of this 0-tile runway does take some
                                    // maneuvering time.
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"heatFrames": 100}
                                        //]
                                    },
                                },
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "Ridley Room Left Grey Lock (to E-Tank)",
                                Type = LockType.GameFlag,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["f_DefeatedRidley"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Ridley's Room - Right Door",
                        Type = TransitionType.Gray,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 0,
                                OpenEnd = 1,
                                Strats = new[] {
                                    // Just using the open end of this 0-tile runway does take some
                                    // maneuvering time.
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"heatFrames": 100}
                                        //]
                                    },
                                },
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "Ridley Room Right Grey Lock (to Farming Room)",
                                Type = LockType.GameFlag,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["f_DefeatedRidley"]*/ },
                                },
                            },
                        },
                    },
                    new Event {
                        Name = "SM - Ridley's Room - Ridley",
                        Type = EventType.Boss,
                        Locks = new[] {
                            new Lock {
                                Name = "Ridley Fight",
                                Type = LockType.BossFight,
                                UnlockStrats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ {"enemyKill":{
                                        //    "enemies": [
                                        //      [ "Ridley" ]
                                        //    ]
                                        //  }},
                                        //  "h_heatProof"
                                        //]
                                    },
                                },
                            },
                        },
                        Yields = new[] { "f_DefeatedRidley" },
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Ridley's Room - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Ridley's Room - Ridley", new[] {
                                new Strat { Requires = null /*["h_heatProof"]*/ },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Ridley's Room - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Ridley's Room - Ridley", new[] {
                                new Strat { Requires = null /*["h_heatProof"]*/ },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Ridley's Room - Ridley",
                        To = new[] {
                            new LinkTarget("SM - Ridley's Room - Left Door", new[] {
                                new Strat { Requires = null /*["h_heatProof"]*/ },
                            }),
                            new LinkTarget("SM - Ridley's Room - Right Door", new[] {
                                new Strat { Requires = null /*["h_heatProof"]*/ },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Ridley's Room - Ridley",
                        EnemyName = "Ridley",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Ridley's Room - Ridley" },
                        StopSpawn = null, // ["f_DefeatedRidley"]
                    },
                },
            },
            #endregion
            // Todo: Acceptable name?
            #region Broken Capsule Room
            new Room {
                Name = "SM - Broken Capsule Room",
                Layout = Room.LayoutFrom(@"
                      X←1"
                    , "SM - Broken Capsule Room - Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Broken Capsule Room - Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 0,
                                OpenEnd = 1,
                                Strats = new[] {
                                    // Just using the open end of this 0-tile runway does take some
                                    // maneuvering time.
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"heatFrames": 100}
                                        //]
                                    },
                                },
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - Broken Capsule Room - Item",
                        Type = PlacementType.Hidden,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Broken Capsule Room - Door",
                        To = new[] {
                            new LinkTarget("SM - Broken Capsule Room - Item", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "Morph",
                                    //  {"heatFrames": 50}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Broken Capsule Room - Item",
                        To = new[] {
                            new LinkTarget("SM - Broken Capsule Room - Door", new[] {
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
            },
            #endregion
            #region Mickey Mouse Room
            new Room {
                Name = "SM - Mickey Mouse Room",
                Layout = Room.LayoutFrom(@"
                           X←2
                          XX
                           X
                      1→XXXX"
                    , "SM - Mickey Mouse Room - Left Door"
                    , "SM - Mickey Mouse Room - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Mickey Mouse Room - Left Door",
                        Type = TransitionType.Gray,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 33,
                                OpenEnd = 1,
                                UsableComingIn = false,
                                Strats = new[] {
                                    // This runway requires killing the Dessgeegas closest to the
                                    // door, and taking a Multiviola hit if the Multiviola is alive.
                                    // This strat doesn't actually clear Bottom Multiviolas, but
                                    // since we're leaving the room after it doesn't really matter.
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"heatFrames": 250}
                                        //]
                                        Obstacles = new[] {
                                            new Strat.Obstacle {
                                                Name = "Bottom Multiviolas",
                                                Requires = null,
                                                //{"enemyDamage": {
                                                //  "enemy": "Multiviola",
                                                //  "type": "contact",
                                                //  "hits": 1
                                                //}}
                                            },
                                            new Strat.Obstacle {
                                                Name = "Runway Dessgeegas",
                                                Requires = null,
                                                //[ { "heatFrames": 350},
                                                //  {"enemyKill":{
                                                //    "enemies": [
                                                //      [
                                                //        "Dessgeega","Dessgeega","Dessgeega"
                                                //      ]
                                                //    ],
                                                //    "explicitWeapons": [ "Plasma", "ScrewAttack", "Super", "Missile" ]
                                                //  }}
                                                //]
                                            },
                                        },
                                    },
                                },
                            },
                        },
                        Locks = new[] {
                            // In reality, any combination of 5 enemies will unlock the door. But
                            // this room is way too complicated to try and track all possibilities.
                            // We went with the two most plausible ones.
                            new Lock {
                                Name = "SM - Mickey Mouse Room - Grey Lock",
                                Type = LockType.KillEnemies,
                                UnlockStrats = new[] {
                                    // The Multiviolas are far away and can't be killed from here,
                                    // hence the condition of 'never'. The only path through this
                                    // room where killing them and leaving here would be meaningful
                                    // would have passed through Below Bomb Blocks Junction at some
                                    // point. So this strat is only doable by killing the
                                    // Multiviolas when going Below Bomb Blocks Junction ->
                                    // Bottom Right Corner Hallway Junction.
                                    new Strat {
                                        Name = "Kill 5 Multiviolas",
                                        Obstacles = new[] {
                                            new Strat.Obstacle {
                                                Name = "Boxed-in Multiviolas",
                                                Requires = null, // ["never"]
                                            },
                                        },
                                    },
                                    // The obstacles have requirements of 'never' on the assumption
                                    // that Samus travels to Bottom Right Hallway Junction or
                                    // Bottom Right Corner Hallway Junction and back to unlock the
                                    // door.
                                    new Strat {
                                        Name = "Kill Bottom Left",
                                        Obstacles = new[] {
                                            new Strat.Obstacle {
                                                Name = "Runway Dessgeegas",
                                                Requires = null, // ["never"]
                                            },
                                            new Strat.Obstacle {
                                                Name = "Bottom Multiviolas",
                                                Requires = null, // ["never"]
                                            },
                                        },
                                    },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Mickey Mouse Room - Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 0,
                                OpenEnd = 1,
                                Strats = new[] {
                                    // Just using the open end of this 0-tile runway does take some
                                    // maneuvering time.
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"heatFrames": 100}
                                        //]
                                    },
                                },
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - Mickey Mouse Room - Item",
                        Type = PlacementType.Visible,
                    },
                    // Represents being below the bomb blocks, regardless of whether they are broken.
                    new Junction {
                        Name = "SM - Mickey Mouse Room - Below Bomb Blocks Junction",
                    },
                    // Represents being below the bomb blocks with some bomb blocks broken, but not all.
                    new Junction {
                        Name = "SM - Mickey Mouse Room - Below Bomb Partial Blocks Junction",
                    },
                    // This is below the crumble blocks, after getting a Multiviola in that chamber.
                    new Junction {
                        Name = "SM - Mickey Mouse Room - Below Crumble Blocks Junction",
                    },
                    // Position at the far right end of the bottom hallway.
                    new Junction {
                        Name = "SM - Mickey Mouse Room - Bottom Right Corner Hallway Junction",
                    },
                    // Position to the left of the farthest two Dessgeegas
                    new Junction {
                        Name = "SM - Mickey Mouse Room - Bottom Right Hallway Junction",
                    },
                    // Right after the bottom left door, but after getting hit by the Multiviola nearby.
                    new Junction {
                        Name = "SM - Mickey Mouse Room - Near Left Door Junction",
                    },
                },
                Obstacles = new[] {
                    new Obstacle {
                        Name = "All Bomb Blocks",
                        Type = ObstacleType.Inanimate,
                    },
                    // Represents one set of bomb blocks from All Bomb Blocks, with the rest intact.
                    // So this obstacle is mutually exclusive with All Bomb Blocks.
                    new Obstacle {
                        Name = "Some Bomb Blocks",
                        Type = ObstacleType.Inanimate,
                    },
                    // The 3 Dessgeegas closest to the left door.
                    new Obstacle {
                        Name = "Runway Dessgeegas",
                        Type = ObstacleType.Enemies,
                    },
                    // The 5 Multiviolas in the Multiviola boxes.
                    new Obstacle {
                        Name = "Boxed-in Multiviolas",
                        Type = ObstacleType.Enemies,
                    },
                    // The 2 Multiviolas in the bottom hallway.
                    new Obstacle {
                        Name = "Bottom Multiviolas",
                        Type = ObstacleType.Enemies,
                    },
                    // The 2 Dessgeegas farthest from the left door in the bottom hallway.
                    new Obstacle {
                        Name = "Far Dessgeegas",
                        Type = ObstacleType.Enemies,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Mickey Mouse Room - Left Door",
                        To = new[] {
                            // Direct link for SpeedBooster strats. Other strats should go
                            // Left Door -> Bottom Right Hallway Junction ->
                            // Bottom Right Corner Hallway Junction.
                            new LinkTarget("SM - Mickey Mouse Room - Bottom Right Corner Hallway Junction", new[] {
                                new Strat {
                                    Name = "Blue Suit Run",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 120},
                                    //  {"canComeInCharged": {
                                    //    "fromNode": 1,
                                    //    "framesRemaining": 180,
                                    //    "shinesparkFrames": 0
                                    //  }}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle { Name = "Bottom Multiviolas" },
                                        new Strat.Obstacle { Name = "Runway Dessgeegas" },
                                        new Strat.Obstacle { Name = "Far Dessgeegas" },
                                    },
                                },
                                // More heat frames than shinespark frames because the shinespark
                                // bonk takes some time.
                                new Strat {
                                    Name = "Shinespark",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 160},
                                    //  {"canComeInCharged": {
                                    //    "fromNode": 1,
                                    //    "framesRemaining": 0,
                                    //    "shinesparkFrames": 80
                                    //  }}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle { Name = "Bottom Multiviolas" },
                                        new Strat.Obstacle { Name = "Runway Dessgeegas" },
                                        new Strat.Obstacle { Name = "Far Dessgeegas", },
                                    },
                                },
                            }),
                            new LinkTarget("SM - Mickey Mouse Room - Near Left Door Junction", new[] {
                                new Strat {
                                    Name = "Get Hit",
                                    Requires = null,
                                    //{"enemyDamage": {
                                    //  "enemy": "Multiviola",
                                    //  "type": "contact",
                                    //  "hits": 1
                                    //}}
                                },
                                new Strat {
                                    Name = "Multiviola Already Dead",
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Bottom Multiviolas",
                                            Requires = null, // ["never"]
                                        },
                                    },
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Mickey Mouse Room - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Mickey Mouse Room - Below Bomb Blocks Junction", new[] {
                                new Strat {
                                    Name = "Power Bombs",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 200}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "All Bomb Blocks",
                                            Requires = null, // ["h_canUsePowerBombs"]
                                        },
                                    },
                                },
                            }),
                            new LinkTarget("SM - Mickey Mouse Room - Below Bomb Partial Blocks Junction", new[] {
                                new Strat {
                                    Name = "Screw",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 200},
                                    //  {"resetRoom":{
                                    //    "nodes": [1, 2],
                                    //    "obstaclesToAvoid": ["A"]
                                    //  }}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Some Bomb Blocks",
                                            Requires = null, // ["ScrewAttack"]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Morph Bombs",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 200},
                                    //  {"resetRoom":{
                                    //    "nodes": [1, 2],
                                    //    "obstaclesToAvoid": ["A"]
                                    //  }}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Some Bomb Blocks",
                                            Requires = null,
                                            //[ { "heatFrames": 50},
                                            //  "h_canUseMorphBombs"
                                            //]
                                        },
                                    },
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Mickey Mouse Room - Item",
                        To = new[] {
                            new LinkTarget("SM - Mickey Mouse Room - Below Bomb Blocks Junction", new[] {
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
                        From = "SM - Mickey Mouse Room - Below Bomb Blocks Junction",
                        To = new[] {
                            new LinkTarget("SM - Mickey Mouse Room - Right Door", new[] {
                                new Strat {
                                    Name = "SpaceJump",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 250},
                                    //  "SpaceJump"
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "All Bomb Blocks",
                                            Requires = null,
                                            //[ "h_canUsePowerBombs",
                                            //  {"heatFrames": 150}
                                            //]
                                        },
                                    },
                                },
                                // Requires one jump off a crumble block.
                                new Strat {
                                    Name = "HiJump",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "HiJump",
                                    //  "canCrumbleJump",
                                    //  {"heatFrames": 250}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "All Bomb Blocks",
                                            Requires = null,
                                            //[ "h_canUsePowerBombs",
                                            //  {"heatFrames": 150}
                                            //]
                                        },
                                    },
                                },
                                // Use SpringBall to just bounce on the crumble blocks.
                                new Strat {
                                    Name = "HiJump Springball",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "HiJump",
                                    //  "h_canUseSpringBall",
                                    //  { "heatFrames": 250}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "All Bomb Blocks",
                                            Requires = null,
                                            //[ "h_canUsePowerBombs",
                                            //  { "heatFrames": 150}
                                            //]
                                        },
                                    },
                                },
                                // Requires one jump off a crumble block.
                                new Strat {
                                    Name = "MidAir Spring Ball",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "canSpringBallJumpMidAir",
                                    //  "canCrumbleJump",
                                    //  {"heatFrames": 250}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "All Bomb Blocks",
                                            Requires = null,
                                            //[ "h_canUsePowerBombs",
                                            //  {"heatFrames": 150}
                                            //]
                                        },
                                    },
                                },
                                // Doable by pausing early enough and starting laterla momentum
                                // before the pause. The timing of the jump itself becomes very
                                // precise.
                                new Strat {
                                    Name = "MickeyMouse Crumbleless MidAir Spring Ball",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "canSpringBallJumpMidAir",
                                    //  {"heatFrames": 250}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "All Bomb Blocks",
                                            Requires = null,
                                            //[ "h_canUsePowerBombs",
                                            //  {"heatFrames": 150}
                                            //]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Mickey Mouse Springwall",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 250},
                                    //  "canSpringwall"
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "All Bomb Blocks",
                                            Requires = null,
                                            //[ "h_canUsePowerBombs",
                                            //  {"heatFrames": 150}
                                            //]
                                        },
                                    },
                                },
                                // Spinjump off a crumble block with just a tiny amount of run
                                // speed. It has to be more speed than zero but less than what hits
                                // the first big height drop in the formula. That gives just enough
                                // height to be able to walljump out.
                                new Strat {
                                    Name = "Mickey Mouse Crumble Speedjump",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "SpeedBooster",
                                    //  "canCrumbleSpinJump",
                                    //  {"heatFrames": 250}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "All Bomb Blocks",
                                            Requires = null,
                                            //[ "h_canUsePowerBombs",
                                            //  {"heatFrames": 150}
                                            //]
                                        },
                                    },
                                },
                                // This one's pretty horrible. The shot block respawns quickly so
                                // it's pretty unforgiving on the IBJ executions. On top of that,
                                // the IBJ is off a mid-air morph off a crumble block.
                                new Strat {
                                    Name = "Mickey Mouse IBJ",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canIBJ",
                                    //  "canCrumbleJump",
                                    //  {"heatFrames": 500}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "All Bomb Blocks",
                                            Requires = null,
                                            //[ "h_canUsePowerBombs",
                                            //  {"heatFrames": 150}
                                            //]
                                        },
                                    },
                                },
                                // Shoot the block before starting or in mid-air, then use spring
                                // ball to bounce on the crumb blocks and start an IBJ.
                                new Strat {
                                    Name = "Mickey Mouse SpringBall IBJ",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canIBJ",
                                    //  "h_canUseSpringBall",
                                    //  {"heatFrames": 550}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "All Bomb Blocks",
                                            Requires = null,
                                            //[ "h_canUsePowerBombs",
                                            //  {"heatFrames": 150}
                                            //]
                                        },
                                    },
                                },
                            }),
                            new LinkTarget("SM - Mickey Mouse Room - Item", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "Morph",
                                    //  {"heatFrames": 150}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Mickey Mouse Room - Below Bomb Partial Blocks Junction", new[] {
                                new Strat {
                                    Name = "Morph Bombs",
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Some Bomb Blocks",
                                            Requires = null,
                                            //[ {"resetRoom":{
                                            //    "nodes": [1, 2],
                                            //    "obstaclesToAvoid": ["A"]
                                            //  }},
                                            //  {"heatFrames": 100},
                                            //  "h_canUseMorphBombs"
                                            //]
                                        },
                                    },
                                },
                                // This is done by positioning the Power Bomb far enough left to
                                // only partially clear the blocks. Not sure if there's a way to
                                // get here and have the strat be relevant though?
                                new Strat {
                                    Name = "Power Bombs",
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Some Bomb Blocks",
                                            Requires = null,
                                            //[ {"resetRoom":{
                                            //    "nodes": [1, 2],
                                            //    "obstaclesToAvoid": ["A"]
                                            //  }},
                                            //  { "heatFrames": 300},
                                            //  "h_canUsePowerBombs"
                                            //]
                                        },
                                    },
                                },
                            }),
                            // Options are to tank the damage or kill the Multiviolas. This is
                            // one-way because the way back requires setting up the ice clip.
                            new LinkTarget("SM - Mickey Mouse Room - Bottom Right Corner Hallway Junction", new[] {
                                new Strat {
                                    Name = "Tank the Damage",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 500},
                                    //  {"enemyDamage": {
                                    //    "enemy": "Multiviola",
                                    //    "type": "contact",
                                    //    "hits": 3
                                    //  }}
                                    //]
                                },
                                // Considered killable with Power Beam without taking damage.
                                new Strat {
                                    Name = "HeatProof Kill",
                                    Requires = null, // ["h_heatProof"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle { Name = "Boxed-in Multiviolas" },
                                    },
                                },
                                new Strat {
                                    Name = "Screw Kill",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 500}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Boxed-in Multiviolas",
                                            Requires = null, // ["ScrewAttack"]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Wave Plasma Kill",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 500}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Boxed-in Multiviolas",
                                            Requires = null,
                                            //[ "Wave",
                                            //  "Plasma"
                                            //]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Power Bomb Kill",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 500}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Boxed-in Multiviolas",
                                            Requires = null,
                                            //{"enemyKill":{
                                            //  "enemies": [
                                            //    [ "Multiviola", "Multiviola" ],
                                            //    [ "Multiviola", "Multiviola", "Multiviola" ]
                                            //  ],
                                            //  "explicitWeapons": [ "PowerBomb" ]
                                            //}}
                                        },
                                    },
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Mickey Mouse Room - Below Bomb Partial Blocks Junction",
                        To = new[] {
                            new LinkTarget("SM - Mickey Mouse Room - Right Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 250}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Mickey Mouse Room - Below Bomb Blocks Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Mickey Mouse Room - Bottom Right Corner Hallway Junction",
                        To = new[] {
                            new LinkTarget("SM - Mickey Mouse Room - Left Door", new[] {
                                // Taking damage off a Dessgeega at the far right, coming in from
                                // the top, allows you to charge a blue suit and get through to the
                                // door. It doesn't fully clear any one obstacle though.
                                new Strat {
                                    Name = "Iframe Blue Suit Run",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"resetRoom":{
                                    //    "nodes": [2],
                                    //    "obstaclesToAvoid": ["F"]
                                    //  }},
                                    //  {"heatFrames":200},
                                    //  {"enemyDamage": {
                                    //    "enemy": "Dessgeega",
                                    //    "type": "contact",
                                    //    "hits": 1
                                    //  }},
                                    //  {"canShineCharge": {
                                    //    "usedTiles": 33,
                                    //    "shinesparkFrames": 0,
                                    //    "openEnd": 2
                                    //  }}
                                    //]
                                },
                            }),
                            // Options are to tank the damage or kill the Dessgeegas.
                            new LinkTarget("SM - Mickey Mouse Room - Bottom Right Hallway Junction", new[] {
                                new Strat {
                                    Name = "Tank the Damage",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 150},
                                    //  {"enemyDamage": {
                                    //    "enemy": "Dessgeega",
                                    //    "type": "contact",
                                    //    "hits": 1
                                    //  }}
                                    //]
                                },
                                // Morph Bombs excluded because there's no safe setup.
                                new Strat {
                                    Name = "HeatProof Kill",
                                    Requires = null, // ["h_heatProof"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Far Dessgeegas",
                                            Requires = null,
                                            //{"enemyKill":{
                                            //  "enemies": [
                                            //    [ "Dessgeega", "Dessgeega" ]
                                            //  ],
                                            //  "excludedWeapons": [ "Bombs" ]
                                            //}}
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Wave Plasma Kill",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 150}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Far Dessgeegas",
                                            Requires = null,
                                            //[ "Plasma",
                                            //  { "heatFrames": 250},
                                            //  "Wave"
                                            //]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Plasma Kill",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 150}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Far Dessgeegas",
                                            Requires = null,
                                            //[ "Plasma",
                                            //  { "heatFrames": 400}
                                            //]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Power Bomb Kill",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 150}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Far Dessgeegas",
                                            Requires = null,
                                            //[ {"enemyKill":{
                                            //    "enemies": [
                                            //      [ "Dessgeega", "Dessgeega" ]
                                            //    ],
                                            //    "explicitWeapons": [ "PowerBomb" ]
                                            //  }},
                                            //  { "heatFrames": 350}
                                            //]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Screw Kill",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 150}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Far Dessgeegas",
                                            Requires = null,
                                            //[ "ScrewAttack",
                                            //  { "heatFrames": 50}
                                            //]
                                        },
                                    },
                                },
                            }),
                            new LinkTarget("SM - Mickey Mouse Room - Below Crumble Blocks Junction", new[] {
                                // This is not just getting up there, but also bringing the correct
                                // Multiviola with you.
                                new Strat {
                                    Name = "Setup Ice Clip",
                                    Requires = null,
                                    //[ "h_heatProof",
                                    //  {"resetRoom":{
                                    //    "nodes": [1],
                                    //    "obstaclesToAvoid": ["E"]
                                    //  }}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Runway Dessgeegas",
                                            Requires = null,
                                            //{"enemyKill":{
                                            //  "enemies": [
                                            //    ["Dessgeega"],
                                            //    ["Dessgeega"],
                                            //    ["Dessgeega"]
                                            //  ],
                                            //  "excludedWeapons": ["Bombs"]
                                            //}}
                                        },
                                        new Strat.Obstacle {
                                            Name = "Far Dessgeegas",
                                            Requires = null,
                                            //{"enemyKill":{
                                            //  "enemies": [
                                            //    ["Dessgeega","Dessgeega"]
                                            //  ],
                                            //  "excludedWeapons": ["Bombs"]
                                            //}}
                                        },
                                        // Ice is required because it's needed for the clip anyway.
                                        // It's relevant here because it two-shots Multiviolas. The
                                        // one hit is here as a safety, and is likely required if
                                        // the Dessgeegas below aren't there yet.
                                        new Strat.Obstacle {
                                            Name = "Boxed-in Multiviolas",
                                            Requires = null,
                                            //[ "Ice",
                                            //  {"enemyDamage": {
                                            //    "enemy": "Multiviola",
                                            //    "type": "contact",
                                            //    "hits": 1
                                            //  }}
                                            //]
                                        },
                                    },
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Mickey Mouse Room - Bottom Right Hallway Junction",
                        To = new[] {
                            // Options are to tank the damage or kill the Dessgeegas and Multiviolas.
                            new LinkTarget("SM - Mickey Mouse Room - Near Left Door Junction", new[] {
                                // If the Dessgeegas to the far right are killed, a short charge
                                // can get through. To avoid redundancy, they must be killed by
                                // travelling between Bottom Right Hallway Junction and
                                // Bottom Right Center Hallway Junction.
                                new Strat {
                                    Name = "Speed Through",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"canShineCharge": {
                                    //    "usedTiles": 22,
                                    //    "shinesparkFrames": 0,
                                    //    "openEnd": 0
                                    //  }},
                                    //  {"heatFrames": 250}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle { Name = "Runway Dessgeegas" },
                                        new Strat.Obstacle { Name = "Bottom Multiviolas" },
                                        new Strat.Obstacle {
                                            Name = "Far Dessgeegas",
                                            Requires = null, // ["never"]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Tank the Damage",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 250},
                                    //  {"enemyDamage": {
                                    //    "enemy": "Dessgeega",
                                    //    "type": "contact",
                                    //    "hits": 2
                                    //  }}
                                    //]
                                },
                                // Some weapons are very slow and require use of the safe spot
                                // above Bottom Right Corner Hallway Junction. This is why the
                                // Dessgeegas to the right must already be dead. Morph Bombs are
                                // excluded because there is no safe setup.
                                new Strat {
                                    Name = "HeatProof Kill",
                                    Requires = null, // ["h_heatProof"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Far Dessgeegas",
                                            Requires = null, // ["never"]
                                        },
                                        new Strat.Obstacle {
                                            Name = "Runway Dessgeegas",
                                            Requires = null,
                                            //{"enemyKill":{
                                            //  "enemies": [
                                            //    [ "Dessgeega", "Dessgeega", "Dessgeega" ]
                                            //  ],
                                            //  "excludedWeapons": [ "Bombs" ]
                                            //}}
                                        },
                                        // Pretty much any weapon but PowerBeam and Morph Bombs can
                                        // kill the Multiviolas in time to not take a hit.
                                        new Strat.Obstacle {
                                            Name = "Bottom Multiviolas",
                                            Requires = null,
                                            //{"or":[
                                            //  {"enemyKill":{
                                            //    "enemies": [
                                            //      [ "Multiviola", "Multiviola" ]
                                            //    ],
                                            //    "excludedWeapons": [ "Bombs", "PowerBeam" ]
                                            //  }},
                                            //  {"enemyDamage": {
                                            //    "enemy": "Multiviola",
                                            //    "type": "contact",
                                            //    "hits": 2
                                            //  }}
                                            //]}
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Wave Plasma Kill",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 200}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Runway Dessgeegas",
                                            Requires = null,
                                            //[ "Plasma",
                                            //  "Wave",
                                            //  { "heatFrames": 200}
                                            //]
                                            AdditionalObstacles = new[] { "Bottom Multiviolas" },
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Plasma Kill",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 200}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Runway Dessgeegas",
                                            Requires = null,
                                            //[ "Plasma",
                                            //  { "heatFrames": 400}
                                            //]
                                            AdditionalObstacles = new[] { "Bottom Multiviolas" },
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Missiles Kill",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 200}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Runway Dessgeegas",
                                            Requires = null,
                                            //[ {"enemyKill":{
                                            //    "enemies": [
                                            //      [ "Dessgeega", "Dessgeega", "Dessgeega" ]
                                            //    ],
                                            //    "explicitWeapons": [ "Missile" ]
                                            //  }},
                                            //  { "heatFrames": 400}
                                            //]
                                        },
                                        new Strat.Obstacle {
                                            Name = "Bottom Multiviolas",
                                            Requires = null,
                                            //{"enemyKill":{
                                            //  "enemies": [
                                            //    [ "Multiviola", "Multiviola" ]
                                            //  ],
                                            //  "explicitWeapons": [ "Missile" ]
                                            //}}
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Supers Kill",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 200}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Runway Dessgeegas",
                                            Requires = null,
                                            //[ {"enemyKill":{
                                            //    "enemies": [
                                            //      [ "Dessgeega", "Dessgeega", "Dessgeega" ]
                                            //    ],
                                            //    "explicitWeapons": [ "Super" ]
                                            //  }},
                                            //  { "heatFrames": 200}
                                            //]
                                        },
                                        new Strat.Obstacle {
                                            Name = "Bottom Multiviolas",
                                            Requires = null,
                                            //[ {"enemyKill":{
                                            //    "enemies": [
                                            //      [ "Multiviola", "Multiviola" ]
                                            //    ],
                                            //    "explicitWeapons": [ "Super" ]
                                            //  }}
                                            //]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Screw Kill",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 200}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Runway Dessgeegas",
                                            Requires = null,
                                            //[ "ScrewAttack",
                                            //  { "heatFrames": 120}
                                            //]
                                            AdditionalObstacles = new[] { "Bottom Multiviolas" },
                                        },
                                    },
                                },
                            }),
                            // Options are to tank the damage or kill the Dessgeegas. No heatproof
                            // strats because it's less damage to run to the safe spot above
                            // Bottom Right Corner Hallway Junction and kill them from there.
                            new LinkTarget("SM - Mickey Mouse Room - Bottom Right Corner Hallway Junction", new[] {
                                new Strat {
                                    Name = "Tank the Damage",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 150},
                                    //  {"enemyDamage": {
                                    //    "enemy": "Dessgeega",
                                    //    "type": "contact",
                                    //    "hits": 1
                                    //  }}
                                    //]
                                },
                                new Strat {
                                    Name = "Plasma Wave Kill",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 100}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Far Dessgeegas",
                                            Requires = null,
                                            //[ "Plasma",
                                            //  { "heatFrames": 300},
                                            //  "Wave"
                                            //]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Plasma Kill",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 100}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Far Dessgeegas",
                                            Requires = null,
                                            //[ "Plasma",
                                            //  { "heatFrames": 500}
                                            //]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Supers Kill",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 100}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Far Dessgeegas",
                                            Requires = null,
                                            //[ {"enemyKill":{
                                            //    "enemies": [
                                            //      [ "Dessgeega", "Dessgeega" ]
                                            //    ],
                                            //    "explicitWeapons": [ "Super" ]
                                            //  }},
                                            //  { "heatFrames": 100}
                                            //]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Screw Kill",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 100}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Far Dessgeegas",
                                            Requires = null,
                                            //[ "ScrewAttack",
                                            //  { "heatFrames": 100}
                                            //]
                                        },
                                    },
                                },
                                new Strat{
                                    Name = "Missiles Kill",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 100}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Far Dessgeegas",
                                            Requires = null,
                                            //[ {"enemyKill":{
                                            //    "enemies": [
                                            //      [ "Dessgeega", "Dessgeega" ]
                                            //    ],
                                            //    "explicitWeapons": [ "Missile" ]
                                            //  }},
                                            //  { "heatFrames": 500}
                                            //]
                                        },
                                    },
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Mickey Mouse Room - Near Left Door Junction",
                        To = new[] {
                            new LinkTarget("SM - Mickey Mouse Room - Left Door"),
                            // Options are to Speed Booster dash or spark through, tank the damage,
                            // kill the Dessgeegas and Multiviolas, or go slower to spare the
                            // Multiviolas. No heatproof strats because it's less damage to run to
                            // the safe spot above Bottom Right Corner Hallway Junction and lure
                            // everything there.
                            new LinkTarget("SM - Mickey Mouse Room - Bottom Right Hallway Junction", new[] {
                                new Strat {
                                    Name = "Tank the Damage",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 200},
                                    //  {"enemyDamage": {
                                    //    "enemy": "Dessgeega",
                                    //    "type": "contact",
                                    //    "hits": 1
                                    //  }}
                                    //]
                                },
                                new Strat {
                                    Name = "Wave Plasma Kill",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 200}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Runway Dessgeegas",
                                            Requires = null,
                                            //[ { "heatFrames": 200},
                                            //  "Plasma",
                                            //  "Wave"
                                            //]
                                            AdditionalObstacles = new[] { "Bottom Multiviolas" },
                                        },
                                    },
                                },
                                // Sparing the Multiviolas is required to perform an ice clip
                                // further in. However, it requires going slower.
                                new Strat {
                                    Name = "Plasma Wave Kill Sparing Multiviolas",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 200}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Runway Dessgeegas",
                                            Requires = null,
                                            //[ { "heatFrames": 400},
                                            //  "Plasma",
                                            //  "Wave"
                                            //]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Plasma Kill",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 200}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Runway Dessgeegas",
                                            Requires = null,
                                            //[ { "heatFrames": 400},
                                            //  "Plasma"
                                            //]
                                            AdditionalObstacles = new[] { "Bottom Multiviolas" },
                                        },
                                    },
                                },
                                // Sparing the Multiviolas is required to perform an ice clip
                                // further in. However, it requires going slower.
                                new Strat {
                                    Name = "Plasma Kill Sparing Multiviolas",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 200}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Runway Dessgeegas",
                                            Requires = null,
                                            //[ { "heatFrames": 600},
                                            //  "Plasma"
                                            //]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Missiles Kill",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 200}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Runway Dessgeegas",
                                            Requires = null,
                                            //[ { "heatFrames": 400},
                                            //  {"enemyKill":{
                                            //    "enemies": [
                                            //      [
                                            //        "Dessgeega","Dessgeega","Dessgeega","Multiviola","Multiviola"
                                            //      ]
                                            //    ],
                                            //    "explicitWeapons": [ "Missile" ]
                                            //  }}
                                            //]
                                            AdditionalObstacles = new[] { "Bottom Multiviolas" },
                                        },
                                    },
                                },
                                // Sparing the Multiviolas is required to perform an ice clip
                                // further in. However, it requires going slower.
                                new Strat {
                                    Name = "Missiles Kill Sparing Multiviolas",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 200}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Runway Dessgeegas",
                                            Requires = null,
                                            //[ { "heatFrames": 400},
                                            //  {"enemyKill":{
                                            //    "enemies": [
                                            //      [
                                            //        "Dessgeega","Dessgeega","Dessgeega"
                                            //      ]
                                            //    ],
                                            //    "explicitWeapons": [ "Missile" ]
                                            //  }}
                                            //]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Supers Kill",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 200}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Runway Dessgeegas",
                                            Requires = null,
                                            //[ { "heatFrames": 200},
                                            //  {"enemyKill":{
                                            //    "enemies": [
                                            //      [
                                            //        "Dessgeega","Dessgeega","Dessgeega","Multiviola","Multiviola"
                                            //      ]
                                            //    ],
                                            //    "explicitWeapons": [ "Super" ]
                                            //  }}
                                            //]
                                            AdditionalObstacles = new[] { "Bottom Multiviolas" },
                                        },
                                    },
                                },
                                // Sparing the Multiviolas is required to perform an ice clip
                                // further in. However, it requires going slower.
                                new Strat {
                                    Name = "Supers Kill Sparing Multiviolas",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 200}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Runway Dessgeegas",
                                            Requires = null,
                                            //[ { "heatFrames": 200},
                                            //  {"enemyKill":{
                                            //    "enemies": [
                                            //      [
                                            //        "Dessgeega","Dessgeega","Dessgeega"
                                            //      ]
                                            //    ],
                                            //    "explicitWeapons": [ "Super" ]
                                            //  }}
                                            //]
                                        },
                                    },
                                },
                                // You can't catch the Multiviolas to kill them with Screw without
                                // reaching Bottom Right Corner Hallway Junction.
                                new Strat {
                                    Name = "Screw Kill Sparing Multiviolas",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 200}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Runway Dessgeegas",
                                            Requires = null,
                                            //[ "ScrewAttack",
                                            //  { "heatFrames": 50}
                                            //]
                                        },
                                    },
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Mickey Mouse Room - Below Crumble Blocks Junction",
                        To = new[] {
                            new LinkTarget("SM - Mickey Mouse Room - Below Bomb Blocks Junction", new[] {
                                new Strat {
                                    Name = "Mickey Mouse Multiviola Clip (Screw Attack)",
                                    Notable = true,
                                    Requires = null, // ["canMultiviolaClip"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Some Bomb Blocks",
                                            Requires = null, // ["ScrewAttack"]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Mickey Mouse Multiviola Clip (Morph Bomb)",
                                    Notable = true,
                                    Requires = null, // ["canMultiviolaClip"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Some Bomb Blocks",
                                            Requires = null, // ["h_canUseMorphBombs"]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Mickey Mouse Multiviola Clip (Power Bomb)",
                                    Notable = true,
                                    Requires = null, // ["canMultiviolaClip"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "All Bomb Blocks",
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
                        GroupName = "SM - Mickey Mouse Room - Bottom Multiviolas",
                        EnemyName = "Multiviola",
                        Quantity = 2,
                        BetweenNodes = new[] {
                            "SM - Mickey Mouse Room - Bottom Right Hallway Junction",
                            "SM - Mickey Mouse Room - Near Left Door Junction",
                        },
                        DropRequires = null, // ["h_heatProof"]
                    },
                    new Enemy {
                        GroupName = "SM - Mickey Mouse Room - Left Dessgeegas",
                        EnemyName = "Dessgeega",
                        Quantity = 3,
                        BetweenNodes = new[] {
                            "SM - Mickey Mouse Room - Bottom Right Hallway Junction",
                            "SM - Mickey Mouse Room - Near Left Door Junction",
                        },
                        DropRequires = null, // ["h_heatProof"]
                    },
                    new Enemy {
                        GroupName = "SM - Mickey Mouse Room - Top Multiviolas",
                        EnemyName = "Multiviola",
                        Quantity = 5,
                        BetweenNodes = new[] {
                            "SM - Mickey Mouse Room - Bottom Right Corner Hallway Junction",
                            "SM - Mickey Mouse Room - Below Bomb Blocks Junction",
                        },
                        DropRequires = null, // ["h_heatProof"]
                    },
                    new Enemy {
                        GroupName = "SM - Mickey Mouse Room - Right Dessgeegas",
                        EnemyName = "Dessgeega",
                        Quantity = 2,
                        HomeNodes = new[] {
                            "SM - Mickey Mouse Room - Bottom Right Corner Hallway Junction",
                            "SM - Mickey Mouse Room - Bottom Right Hallway Junction",
                        },
                        DropRequires = null, // ["h_heatProof"]
                    }
                },
            },
            #endregion
            #region Norfair Lower Fireflea Room
            new Room {
                Name = "SM - Norfair Lower Fireflea Room",
                Layout = Room.LayoutFrom(@"
                      2→XX←3
                         X
                         X
                       1→XX
                         XX
                         XX"
                    , "SM - Norfair Lower Fireflea Room - Bottom Left Door"
                    , "SM - Norfair Lower Fireflea Room - Top Left Door"
                    , "SM - Norfair Lower Fireflea Room - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Norfair Lower Fireflea Room - Bottom Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 1,
                            },
                        },
                        CanLeaveCharged = new[] {
                            new RunwayCharge {
                                Length = 20,
                                OpenEnd = 2,
                                FramesRemaining = 120,
                                Strats = new[] {
                                    new Strat {
                                        Obstacles = new[] {
                                            new Strat.Obstacle {
                                                Name = "Fune with a secret",
                                                Requires = null,
                                                //{"enemyKill":{
                                                //  "enemies": [
                                                //    [ "Fune" ]
                                                //  ]
                                                //}}
                                            },
                                        },
                                    },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Norfair Lower Fireflea Room - Top Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 21,
                                GentleDownTiles = 3,
                                GentleUpTiles = 3,
                                EndingUpTiles = 1,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Norfair Lower Fireflea Room - Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 5,
                                OpenEnd = 1,
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - Norfair Lower Fireflea Room - Item",
                        Type = PlacementType.Visible,
                    },
                    new Junction {
                        Name = "SM - Norfair Lower Fireflea Room - Behind Fune Junction",
                    },
                    new Junction {
                        Name = "SM - Norfair Lower Fireflea Room - Claw Junction",
                    },
                    new Junction {
                        Name = "SM - Norfair Lower Fireflea Room - Bottom Left Platform Junction",
                    },
                },
                Obstacles = new[] {
                    new Obstacle {
                        Name = "Fune with a secret",
                        Type = ObstacleType.Enemies,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Norfair Lower Fireflea Room - Top Left Door",
                        To = new[] {
                            new LinkTarget("SM - Norfair Lower Fireflea Room - Right Door"),
                        },
                    },
                    new Link {
                        From = "SM - Norfair Lower Fireflea Room - Bottom Left Door",
                        To = new[] {
                            new LinkTarget("SM - Norfair Lower Fireflea Room - Right Door"),
                            new LinkTarget("SM - Norfair Lower Fireflea Room - Behind Fune Junction", new[] {
                                // Use SpringBall to get up and over the Fune.
                                new Strat { Requires = null /*["h_canUseSpringBall"]*/ },
                                // Use a Morph Bomb to get up and over the Fune.
                                new Strat { Requires = null /*["h_canUseMorphBombs"]*/ },
                                // A well-done mid-air morph can get up and over the Fune using the
                                // boost from a projectile hit. This leads to a softlock if it's the
                                // only way in, because it doesn't work on the way out.
                                new Strat {
                                    Name = "Fireflea Room Fune Boost",
                                    Notable = true,
                                    Requires = null,
                                    //[ "Morph",
                                    //  "canDamageBoost",
                                    //  {"enemyDamage": {
                                    //    "enemy": "Fune",
                                    //    "type": "fireball",
                                    //    "hits": 1
                                    //  }}
                                    //]
                                },
                                new Strat {
                                    Name = "Kill the Fune",
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Fune with a secret",
                                            Requires = null,
                                            //{"enemyKill":{
                                            //  "enemies": [
                                            //    [ "Fune" ]
                                            //  ]
                                            //}}
                                        },
                                    },
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Norfair Lower Fireflea Room - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Norfair Lower Fireflea Room - Top Left Door"),
                            new LinkTarget("SM - Norfair Lower Fireflea Room - Bottom Left Door"),
                        },
                    },
                    new Link {
                        From = "SM - Norfair Lower Fireflea Room - Item",
                        To = new[] {
                            new LinkTarget("SM - Norfair Lower Fireflea Room - Bottom Left Platform Junction", new[] {
                                new Strat { Requires = null /*["SpaceJump"]*/ },
                                new Strat {
                                    Name = "Use Frozen Fireflea",
                                    Requires = null, // ["canUseFrozenEnemies"]
                                },
                                new Strat {
                                    Name = "Use iframes",
                                    Requires = null,
                                    //{"enemyDamage": {
                                    //  "enemy": "Fireflea",
                                    //  "type": "contact",
                                    //  "hits": 1
                                    //}}
                                },
                                new Strat {
                                    Name = "Tank Spike Damage",
                                    Requires = null, // { "spikeHits": 1}
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Norfair Lower Fireflea Room - Bottom Left Platform Junction",
                        To = new[] {
                            new LinkTarget("SM - Norfair Lower Fireflea Room - Item", new[] {
                                new Strat { Requires = null /*["SpaceJump"]*/ },
                                new Strat {
                                    Name = "Use Frozen Fireflea",
                                    Requires = null, // ["canUseFrozenEnemies"]
                                },
                                new Strat {
                                    Name = "Use iframes",
                                    Requires = null,
                                    //{"enemyDamage": {
                                    //  "enemy": "Fireflea",
                                    //  "type": "contact",
                                    //  "hits": 1
                                    //}}
                                },
                                new Strat {
                                    Name = "Tank Spike Damage",
                                    Requires = null, // { "spikeHits": 1}
                                },
                            }),
                            new LinkTarget("SM - Norfair Lower Fireflea Room - Claw Junction", new[] {
                                new Strat { Requires = null, /*["SpaceJump"]*/ },
                                new Strat {
                                    Name = "Speedjump",
                                    Requires = null,
                                    //[ "HiJump",
                                    //  "SpeedBooster"
                                    //]
                                },
                                new Strat {
                                    Name = "Dual Jump Assist",
                                    Requires = null,
                                    //[ "HiJump",
                                    //  "canSpringBallJumpMidAir"
                                    //]
                                },
                                new Strat {
                                    Name = "High Walljump",
                                    Requires = null,
                                    //[ "HiJump",
                                    //  "canWalljump"
                                    //]
                                },
                                new Strat {
                                    Name = "Frozen Fireflea",
                                    Requires = null, // ["canUseFrozenEnemies"]
                                },
                                // It's precise, and could only be needed if you don't feel like
                                // doing a walljump. But you can dboost off the highest Fireflea if
                                // you can set up to get hit at the apex of your jump.
                                new Strat {
                                    Name = "Norfair Fireflea Bug Boost",
                                    Notable = true,
                                    Requires = null,
                                    //[ "HiJump",
                                    //  "canDamageBoost"
                                    //]
                                },
                                // Made a notable strat because the dismount is trickier than most.
                                new Strat {
                                    Name = "Lower Norfair Fireflea IBJ",
                                    Notable = true,
                                    Requires = null, // ["canIBJ"]
                                },
                                // Left as its own, notable strat because it can be kind of tricky.
                                new Strat {
                                    Name = "Lower Norfair Fireflea Hjless Walljump",
                                    Notable = true,
                                    Requires = null, // ["canWalljump"]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Norfair Lower Fireflea Room - Behind Fune Junction",
                        To = new[] {
                            new LinkTarget("SM - Norfair Lower Fireflea Room - Bottom Left Door", new[] {
                                // Use SpringBall to get up and over the Fune.
                                new Strat { Requires = null /*["h_canUseSpringBall"]*/ },
                                // Use a Morph Bomb to get up and over the Fune.
                                new Strat { Requires = null /*["h_canUseMorphBombs"]*/ },
                                new Strat {
                                    Name = "Kill the Fune",
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Fune with a secret",
                                            Requires = null,
                                            //{"enemyKill":{
                                            //  "enemies": [
                                            //    [ "Fune" ]
                                            //  ]
                                            //}}
                                        },
                                    },
                                },
                            }),
                            new LinkTarget("SM - Norfair Lower Fireflea Room - Claw Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Norfair Lower Fireflea Room - Claw Junction",
                        To = new[] {
                            new LinkTarget("SM - Norfair Lower Fireflea Room - Bottom Left Platform Junction"),
                            new LinkTarget("SM - Norfair Lower Fireflea Room - Behind Fune Junction", new[] {
                                new Strat {
                                    Requires = null,
                                    //{"or":[
                                    //  "canWalljump",
                                    //  "SpaceJump"
                                    //]}
                                },
                                new Strat { Requires = null /*["canIBJ"]*/ },
                                new Strat {
                                    Name = "Speedjump",
                                    Requires = null,
                                    //[ "HiJump",
                                    //  "SpeedBooster"
                                    //]
                                },
                                new Strat {
                                    Name = "Dual Jump Assist",
                                    Requires = null,
                                    //[ "HiJump",
                                    //  "canSpringBallJumpMidAir"
                                    //]
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "Lower Norfair Fireflea Room Bottom Fune",
                        EnemyName = "Fune",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Norfair Lower Fireflea Room - Bottom Left Door" },
                    },
                    new Enemy {
                        GroupName = "Lower Norfair Fireflea Room Top Funes",
                        EnemyName = "Fune",
                        Quantity = 3,
                        BetweenNodes = new[] {
                            "SM - Norfair Lower Fireflea Room - Bottom Left Door",
                            "SM - Norfair Lower Fireflea Room - Right Door",
                        },
                    },
                    new Enemy {
                        GroupName = "Lower Norfair Fireflea Room Boulders",
                        EnemyName = "Boulder",
                        Quantity = 3,
                        BetweenNodes = new[] {
                            "SM - Norfair Lower Fireflea Room - Bottom Left Door",
                            "SM - Norfair Lower Fireflea Room - Right Door",
                        },
                    },
                    new Enemy {
                        GroupName = "Lower Norfair Top Fireflea",
                        EnemyName = "Fireflea",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Norfair Lower Fireflea Room - Claw Junction" },
                    },
                    new Enemy {
                        GroupName = "Lower Norfair Bottom Left Fireflea",
                        EnemyName = "Fireflea",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Norfair Lower Fireflea Room - Bottom Left Platform Junction" },
                    },
                    new Enemy {
                        GroupName = "Lower Norfair Bottom Mid-Left Fireflea",
                        EnemyName = "Fireflea",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Norfair Lower Fireflea Room - Bottom Left Platform Junction" },
                        DropRequires = null, // ["Grapple"]
                    },
                    new Enemy {
                        GroupName = "Lower Norfair Bottom Mid-Right Fireflea",
                        EnemyName = "Fireflea",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Norfair Lower Fireflea Room - Item" },
                        DropRequires = null, // ["Grapple"]
                    },
                    new Enemy {
                        GroupName = "Lower Norfair Bottom Right Fireflea",
                        EnemyName = "Fireflea",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Norfair Lower Fireflea Room - Item" },
                    }
                },
            },
            #endregion
            #region Spring Ball Maze Room
            new Room {
                Name = "SM - Spring Ball Maze Room",
                Layout = Room.LayoutFrom(@"
                      1→XXXXX
                        XX←2↑
                            3"
                    , "SM - Spring Ball Maze Room - Left Door"
                    , "SM - Spring Ball Maze Room - Right Door"
                    , "SM - Spring Ball Maze Room - Bottom Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Spring Ball Maze Room - Left Door",
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
                                },
                            },
                        },
                        CanLeaveCharged = new[] {
                            new RunwayCharge {
                                Length = 27,
                                OpenEnd = 1,
                                FramesRemaining = 60,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"heatFrames": 750}
                                        //]
                                    },
                                },
                            },
                        },
                    },
                    // The horizontal, right door at the bottom of the room.
                    new Transition {
                        Name = "SM - Spring Ball Maze Room - Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 7,
                                GentleUpTiles = 4,
                                EndingUpTiles = 1,
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
                    // The vertical door at the far right.
                    new Transition {
                        Name = "SM - Spring Ball Maze Room - Bottom Door",
                        Type = TransitionType.Blue,
                    },
                    new Placement {
                        Name = "SM - Spring Ball Maze Room - Item",
                        Type = PlacementType.Visible,
                    },
                    // This junction is just after the bomb blocks inside the Morph maze.
                    new Junction {
                        Name = "SM - Spring Ball Maze Room - Inside Maze Junction",
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Spring Ball Maze Room - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Spring Ball Maze Room - Right Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 380}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Spring Ball Maze Room - Item", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 200}
                                    //]
                                },
                            }),
                            // This one-way link represents only the Hotarubi Special. Anything else
                            // should go Left Door -> Item -> Inside Maze Junction.
                            new LinkTarget("SM - Spring Ball Maze Room - Inside Maze Junction", new[] {
                                // Involves doing a speedball then using Spring Ball to break the bomb blocks.
                                new Strat {
                                    Name = "Hotarubi Special",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "h_canUseSpringBall",
                                    //  "canMockball",
                                    //  "HiJump",
                                    //  {"canShineCharge": {
                                    //    "usedTiles": 21,
                                    //    "gentleDownTiles": 2,
                                    //    "openEnd": 1,
                                    //    "shinesparkFrames": 0
                                    //  }},
                                    //  { "heatFrames": 400}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Spring Ball Maze Room - Bottom Door",
                        To = Empty<LinkTarget>.List,
                    },
                    new Link {
                        From = "SM - Spring Ball Maze Room - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Spring Ball Maze Room - Left Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 400}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Spring Ball Maze Room - Item",
                        To = new[] {
                            new LinkTarget("SM - Spring Ball Maze Room - Left Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 350}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Spring Ball Maze Room - Inside Maze Junction", new[] {
                                new Strat {
                                    Name = "Morph Bombs",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "h_canUseMorphBombs",
                                    //  {"heatFrames": 450}
                                    //]
                                },
                                new Strat {
                                    Name = "Power Bombs",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "h_canUsePowerBombs",
                                    //  { "heatFrames": 300}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Spring Ball Maze Room - Inside Maze Junction",
                        To = new[] {
                            new LinkTarget("SM - Spring Ball Maze Room - Bottom Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "Morph",
                                    //  {"heatFrames": 550}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Spring Ball Maze Room - Item", new[] {
                                new Strat {
                                    Requires = null
                                    //[ "h_canNavigateHeatRooms",
                                    //  "Morph",
                                    //  {"heatFrames": 300}
                                    //]
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Spring Ball Maze Room - Bottom Alcoons",
                        EnemyName = "Alcoon",
                        Quantity = 3,
                        HomeNodes = new[] { "SM - Spring Ball Maze Room - Right Door" },
                        DropRequires = null, // ["h_heatProof"]
                    },
                    new Enemy {
                        GroupName = "SM - Spring Ball Maze Room - Top Alcoon",
                        EnemyName = "Alcoon",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Spring Ball Maze Room - Item" },
                        DropRequires = null, // ["h_heatProof"]
                    },
                },
            },
            #endregion
            #region Norfair Lower One-way Closet
            new Room {
                Name = "SM - Norfair Lower One-way Closet",
                Layout = Room.LayoutFrom(@"
                        2
                        ↓
                      1→X"
                    , "SM - Norfair Lower One-way Closet - Left Door"
                    , "SM - Norfair Lower One-way Closet - Top Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Norfair Lower One-way Closet - Left Door",
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
                        Name = "SM - Norfair Lower One-way Closet - Top Door",
                        Type = TransitionType.Blue,
                    },
                    new Placement {
                        Name = "SM - Norfair Lower One-way Closet - Item",
                        Type = PlacementType.Visible,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Norfair Lower One-way Closet - Left Door",
                        To = Empty<LinkTarget>.List,
                    },
                    new Link {
                        From = "SM - Norfair Lower One-way Closet - Top Door",
                        To = new[] {
                            new LinkTarget("SM - Norfair Lower One-way Closet - Left Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 100}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Norfair Lower One-way Closet - Item", new[] {
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
                        From = "SM - Norfair Lower One-way Closet - Item",
                        To = new[] {
                            new LinkTarget("SM - Norfair Lower One-way Closet - Top Door", new[] {
                                // Just reaching the node would be doable in 50 frames. We have 100
                                // here because getting into the door takes a bit more time than
                                // that.
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
            #region Three Musketeers' Room
            new Room {
                Name = "SM - Three Musketeers' Room",
                Layout = Room.LayoutFrom(@"
                      1→X
                        X
                       XXXX←2"
                    , "SM - Three Musketeers' Room - Left Door"
                    , "SM - Three Musketeers' Room - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Three Musketeers' Room - Left Door",
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
                                },
                            },
                            // With Blocks Intact.
                            // This longer runway is not usable if the shot blocks are destroyed.
                            new RunwayDash {
                                Length = 12,
                                OpenEnd = 0,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"resetRoom":{
                                        //    "nodes":[1],
                                        //    "mustStayPut": true
                                        //  }},
                                        //  { "heatFrames": 140}
                                        //]
                                    },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Three Musketeers' Room - Right Door",
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
                        Name = "SM - Three Musketeers' Room - Item",
                        Type = PlacementType.Visible,
                    },
                    new Junction {
                        Name = "SM - Three Musketeers' Room - Middle Junction",
                    },
                },
                Obstacles = new[] {
                    new Obstacle {
                        Name = "Three Musketeers",
                        Type = ObstacleType.Enemies,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Three Musketeers' Room - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Three Musketeers' Room - Middle Junction", new[] {
                                new Strat {
                                    Name = "Tank the Damage",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 450},
                                    //  {"enemyDamage": {
                                    //    "enemy": "Kihunter (red)",
                                    //    "type": "contact",
                                    //    "hits": 2
                                    //  }}
                                    //]
                                },
                                new Strat {
                                    Name = "HeatProof Kill",
                                    Requires = null, // ["h_heatProof"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Three Musketeers",
                                            Requires = null,
                                            //{"enemyKill":{
                                            //  "enemies": [
                                            //    [
                                            //      "Kihunter (red)","Kihunter (red)","Kihunter (red)"
                                            //    ]
                                            //  ]
                                            //}}
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "HitBox the Kihunters",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "canPlasmaHitbox",
                                    //  { "heatFrames": 400}
                                    //]
                                },
                                new Strat {
                                    Name = "Screw Kill",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 400}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Three Musketeers",
                                            Requires = null,
                                            //[ { "heatFrames": 100},
                                            //  "ScrewAttack"
                                            //]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Full Combo Kill",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 400}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Three Musketeers",
                                            Requires = null,
                                            //[ { "heatFrames": 200},
                                            //  "Charge",
                                            //  "Plasma",
                                            //  "Ice",
                                            //  "Wave"
                                            //]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Chargeless Full Combo Kill",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 400}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Three Musketeers",
                                            Requires = null,
                                            //[ { "heatFrames": 400},
                                            //  "Plasma",
                                            //  "Ice",
                                            //  "Wave"
                                            //]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Wave Plasma Kill",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 400}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Three Musketeers",
                                            Requires = null,
                                            //[ { "heatFrames": 600},
                                            //  "Plasma",
                                            //  "Wave"
                                            //]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Plasma Kill",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 400}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Three Musketeers",
                                            Requires = null,
                                            //[ { "heatFrames": 1000},
                                            //  "Plasma"
                                            //]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Supers Kill",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 400}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Three Musketeers",
                                            Requires = null,
                                            //[ { "heatFrames": 600},
                                            //  {"enemyKill":{
                                            //    "enemies": [
                                            //      [
                                            //        "Kihunter (red)","Kihunter (red)","Kihunter (red)"
                                            //      ]
                                            //    ],
                                            //    "explicitWeapons": ["Super"]
                                            //  }}
                                            //]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Ice Wave Spazer Kill",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 400}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Three Musketeers",
                                            Requires = null,
                                            //[ { "heatFrames": 1600},
                                            //  "Spazer",
                                            //  "Ice",
                                            //  "Wave"
                                            //]
                                        },
                                    },
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Three Musketeers' Room - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Three Musketeers' Room - Middle Junction", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "Morph",
                                    //  {"heatFrames": 660}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Three Musketeers' Room - Item",
                        To = new[] {
                            new LinkTarget("SM - Three Musketeers' Room - Middle Junction", new[] {
                                // There's technically a bomb block to break, but it's impossible
                                // to reach this node without destroying it beforehand.
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
                        From = "SM - Three Musketeers' Room - Middle Junction",
                        To = new[] {
                            new LinkTarget("SM - Three Musketeers' Room - Left Door", new[] {
                                new Strat {
                                    Name = "Tank the Damage",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 550},
                                    //  {"enemyDamage": {
                                    //    "enemy": "Kihunter (red)",
                                    //    "type": "contact",
                                    //    "hits": 3
                                    //  }}
                                    //]
                                },
                                new Strat {
                                    Name = "HeatProof Kill",
                                    Requires = null, // ["h_heatProof"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Three Musketeers",
                                            Requires = null
                                            //{"enemyKill":{
                                            //  "enemies": [
                                            //    [
                                            //      "Kihunter (red)","Kihunter (red)","Kihunter (red)"
                                            //    ]
                                            //  ]
                                            //}}
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Screw Kill",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 400}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Three Musketeers",
                                            Requires = null,
                                            //[ "ScrewAttack",
                                            //  { "heatFrames": 100}
                                            //]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Ice Wave Plasma Kill",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 400}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Three Musketeers",
                                            Requires = null,
                                            //[ "Ice",
                                            //  "Wave",
                                            //  "Plasma",
                                            //  { "heatFrames": 450}
                                            //]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Wave Plasma Kill",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 400}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Three Musketeers",
                                            Requires = null,
                                            //[ "Wave",
                                            //  "Plasma",
                                            //  { "heatFrames": 650}
                                            //]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Plasma Kill",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 400}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Three Musketeers",
                                            Requires = null,
                                            //[ "Plasma",
                                            //  { "heatFrames": 1200}
                                            //]
                                        }
                                    },
                                },
                                new Strat {
                                    Name = "Supers Kill",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 400}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Three Musketeers",
                                            Requires = null,
                                            //[ {"enemyKill":{
                                            //    "enemies": [
                                            //      [
                                            //        "Kihunter (red)","Kihunter (red)","Kihunter (red)"
                                            //      ]
                                            //    ],
                                            //    "explicitWeapons": [ "Super" ]
                                            //  }},
                                            //  { "heatFrames": 1000}
                                            //]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Ice Wave Spazer Kill",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 400}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Three Musketeers",
                                            Requires = null,
                                            //[ "Ice",
                                            //  "Wave",
                                            //  "Spazer",
                                            //  { "heatFrames": 1300}
                                            //]
                                        },
                                    },
                                },
                            }),
                            new LinkTarget("SM - Three Musketeers' Room - Right Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "Morph",
                                    //  { "heatFrames": 650}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Three Musketeers' Room - Item", new[] {
                                new Strat {
                                    Name = "Screw",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "Morph",
                                    //  "ScrewAttack",
                                    //  { "heatFrames": 250}
                                    //]
                                },
                                new Strat {
                                    Name = "Morph Bombs",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "h_canUseMorphBombs",
                                    //  "ScrewAttack",
                                    //  { "heatFrames": 300}
                                    //]
                                },
                                new Strat {
                                    Name = "Power Bombs",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "h_canUsePowerBombs",
                                    //  "ScrewAttack",
                                    //  { "heatFrames": 250}
                                    //]
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Three Musketeers' Room - Three Musketeers",
                        EnemyName = "Kihunter (red)",
                        Quantity = 3,
                        BetweenNodes = new[] {
                            "SM - Three Musketeers' Room - Left Door",
                            "SM - Three Musketeers' Room - Middle Junction",
                        },
                        DropRequires = null, // ["h_heatProof"]
                    },
                },
            },
            #endregion
            #region Norfair Lower Save Room
            new Room {
                Name = "SM - Norfair Lower Save Room",
                Layout = Room.LayoutFrom(@"
                      1→X"
                    , "SM - Norfair Lower Save Room - Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Norfair Lower Save Room - Door",
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
                        Name = "SM - Norfair Lower Save Room - Save Station",
                        Type = UtilityType.Save,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Norfair Lower Save Room - Door",
                        To = new[] {
                            new LinkTarget("SM - Norfair Lower Save Room - Save Station"),
                        },
                    },
                    new Link {
                        From = "SM - Norfair Lower Save Room - Save Station",
                        To = new[] {
                            new LinkTarget("SM - Norfair Lower Save Room - Door"),
                        },
                    },
                },
            },
            #endregion
        };

    }

}
