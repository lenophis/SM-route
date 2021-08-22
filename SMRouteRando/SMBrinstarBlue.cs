using System.Collections.Generic;

namespace SMRouteRando {

    public class SMBrinstarBlue {

        public static IList<Room> Rooms { get; } = new[] {
            // Todo: Acceptable name?
            #region Blue Highway
            new Room {
                Name = "SM - Blue Highway",
                Layout = Room.LayoutFrom(@"
                             2
                             ↓
                      1→XXXXXXXX←3"
                    , "SM - Blue Highway - Left Door"
                    , "SM - Blue Highway - Elevator"
                    , "SM - Blue Highway - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Blue Highway - Left Door",
                        Type = TransitionType.Gray,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 1,
                            },
                        },
                        CanLeaveCharged = new[] {
                            new RunwayCharge {
                                Length = 25,
                                FramesRemaining = 80,
                                OpenEnd = 0,
                                Strats = new[] {
                                    // Enabled by destroying obstacle C by travelling between nodes 1 and 6.
                                    new Strat {
                                        Obstacles = new[] {
                                            new Strat.Obstacle {
                                                Name = "Sidehopper trio",
                                                Requires = null, // ["never"]
                                            },
                                        },
                                    },
                                },
                            },
                        },
                        Locks = new[] {
                            // Obstacle requirements not repeated here to avoid duplication. It can be destroyed either going 1 -> 6 or 6 -> 1.
                            new Lock {
                                Name = "SM - Blue Highway - Grey Lock",
                                Type = LockType.KillEnemies,
                                Active = null, // ["f_ZebesAwake"]
                                UnlockStrats = new[] {
                                    new Strat {
                                        Obstacles = new[] {
                                            new Strat.Obstacle {
                                                Name = "Sidehopper trio",
                                                Requires = null, // ["never"]
                                            },
                                        },
                                    },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Blue Highway - Elevator",
                        Type = TransitionType.Elevator,
                    },
                    new Transition {
                        Name = "SM - Blue Highway - Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 4,
                                OpenEnd = 1,
                            },
                        },
                        CanLeaveCharged = new[] {
                            new RunwayCharge {
                                Length = 30,
                                OpenEnd = 0,
                                FramesRemaining = 100,
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - Blue Highway - Pedestal Item",
                        Type = PlacementType.Visible,
                    },
                    new Placement {
                        Name = "SM - Blue Highway - Walled Off Item",
                        Type = PlacementType.Visible,
                        Locks = new[] {
                            // Item doesn't appear before Zebes is awakened.
                            new Lock {
                                Name = "SM - Blue Highway - Walled Off Item Spawn Lock",
                                Type = LockType.GameFlag,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["f_ZebesAwake"]*/ },
                                },
                            },
                        },
                    },
                    new Junction {
                        Name = "SM - Blue Highway - Sidehopper Junction",
                    },
                },
                Obstacles = new[] {
                    new Obstacle {
                        Name = "Sidehopper trio",
                        Type = ObstacleType.Enemies,
                    },
                    new Obstacle {
                        Name = "Bomb Blocks",
                        Type = ObstacleType.Inanimate,
                    },
                    new Obstacle {
                        Name = "Power Bomb Blocks",
                        Type = ObstacleType.Inanimate,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Blue Highway - Left Door",
                        To = new[] {
                            // Requires either tanking one hit, or killing the Sidehoppers.
                            new LinkTarget("SM - Blue Highway - Sidehopper Junction", new[] {
                                new Strat {
                                    Name = "Run Through",
                                    Requires = null,
                                    //{"enemyDamage": {
                                    //  "enemy": "Sidehopper",
                                    //  "type": "contact",
                                    //  "hits": 1
                                    //}}
                                },
                                new Strat {
                                    Name = "Power Beam Sidehopper Kill",
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Sidehopper trio",
                                            Requires = null,
                                            //{"enemyDamage": {
                                            //  "enemy": "Sidehopper",
                                            //  "type": "contact",
                                            //  "hits": 6
                                            //}}
                                        },
                                    },
                                },
                                // For the PB (and screw) kill, this strat assumes you don't know
                                // you're entering the room beforehand. If you know, it's possible
                                // to PB kill the first two Sidehoppers damage-free by morphing
                                // before entering. For Screw, just entering with a spinjump would
                                // work.
                                new Strat {
                                    Name = "Quick Sidehopper Kill",
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Sidehopper trio",
                                            Requires = null,
                                            //[ {"enemyDamage": {
                                            //  "enemy": "Sidehopper",
                                            //  "type": "contact",
                                            //  "hits": 1
                                            //}},
                                            //{"or":[
                                            //  {"enemyKill":{
                                            //    "enemies": [
                                            //      ["Sidehopper", "Sidehopper"],
                                            //      ["Sidehopper"]
                                            //    ],
                                            //    "explicitWeapons": [
                                            //      "Missile",
                                            //      "Super",
                                            //      "PowerBomb",
                                            //      "ScrewAttack",
                                            //      "Plasma"
                                            //    ]
                                            //  }}
                                            //]}
                                        },
                                    },
                                },
                                // This strat assumes you don't know you're entering the room
                                // beforehand. Otherwise, it's possible to kill the first two
                                // Sidehoppers without taking damage. It's possible to take out
                                // obstacle A alongside the third Sidehopper, but there's a risk of
                                // taking an additional hit (negated by mockball).
                                new Strat {
                                    Name = "PB Sidehopper Kill with Bomb Blocks",
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Sidehopper trio",
                                            Requires = null,
                                            //[ {"enemyDamage": {
                                            //    "enemy": "Sidehopper",
                                            //    "type": "contact",
                                            //    "hits": 1
                                            //  }},
                                            //  {"or":[
                                            //    "canMockball",
                                            //    {"enemyDamage": {
                                            //      "enemy": "Sidehopper",
                                            //      "type": "contact",
                                            //      "hits": 1
                                            //    }}
                                            //  ]},
                                            //  {"enemyKill":{
                                            //    "enemies": [
                                            //      ["Sidehopper", "Sidehopper"],
                                            //      ["Sidehopper"]
                                            //    ],
                                            //    "explicitWeapons": [
                                            //      "PowerBomb"
                                            //    ]
                                            //  }}
                                            //]
                                            AdditionalObstacles = new[] { "Bomb Blocks" },
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Medium Sidehopper Kill",
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Sidehopper trio",
                                            Requires = null,
                                            //[ {"enemyDamage": {
                                            //    "enemy": "Sidehopper",
                                            //    "type": "contact",
                                            //    "hits": 3
                                            //  }},
                                            //  {"or":[
                                            //    "Spazer",
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
                        From = "SM - Blue Highway - Elevator",
                        To = new[] {
                            new LinkTarget("SM - Blue Highway - Right Door"),
                            new LinkTarget("SM - Blue Highway - Pedestal Item"),
                        },
                    },
                    new Link {
                        From = "SM - Blue Highway - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Blue Highway - Elevator"),
                        },
                    },
                    new Link {
                        From = "SM - Blue Highway - Pedestal Item",
                        To = new[] {
                            new LinkTarget("SM - Blue Highway - Elevator"),
                            new LinkTarget("SM - Blue Highway - Walled Off Item", new[] {
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
                        From = "SM - Blue Highway - Walled Off Item",
                        To = new[] {
                            new LinkTarget("SM - Blue Highway - Pedestal Item", new[] {
                                new Strat {
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Power Bomb Blocks",
                                            Requires = null, // ["h_canUsePowerBombs"]
                                        },
                                    },
                                },
                            }),
                            new LinkTarget("SM - Blue Highway - Sidehopper Junction", new[] {
                                new Strat {
                                    Name = "Bomb the Blocks",
                                    Requires = null, // ["Morph"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Bomb Blocks",
                                            Requires = null,
                                            //{"or":[
                                            //  "Bombs",
                                            //  {"and":[
                                            //    "PowerBomb",
                                            //    {"ammo": {
                                            //      "type": "PowerBomb",
                                            //      "count": 1
                                            //    }}
                                            //  ]}
                                            //]}
                                        },
                                    },
                                },
                                // It's a short charge into a speedball to break the bomb blocks.
                                // The Power Bomb Blocks needs to be destroyed to have enough
                                // running room.
                                new Strat {
                                    Name = "Morph Ball Room Speedball (Right to Left)",
                                    Notable = true,
                                    Requires = null, // ["Morph"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Power Bomb Blocks",
                                            Requires = null, // ["h_canUsePowerBombs"]
                                        },
                                        new Strat.Obstacle {
                                            Name = "Bomb Blocks",
                                            Requires = null,
                                            //[ {"canShineCharge": {
                                            //    "usedTiles": 21,
                                            //    "shinesparkFrames": 0,
                                            //    "openEnd": 1
                                            //  }},
                                            //  "canMockball"
                                            //]
                                        },
                                    },
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Blue Highway - Sidehopper Junction",
                        To = new[] {
                            new LinkTarget("SM - Blue Highway - Left Door", new[] {
                                // This strat is there to override all other strats' requirement if
                                // the Sidehoppers are already dead. Killing the Sidehoppers from
                                // here without coming from the PB item is undefined because it
                                // would be redundant.
                                new Strat {
                                    Name = "Laugh at Dead Sidehoppers",
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Sidehopper trio",
                                            Requires = null, // ["never"]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Tank the damage",
                                    Requires = null,
                                    //{"enemyDamage": {
                                    //  "enemy": "Sidehopper",
                                    //  "type": "contact",
                                    //  "hits": 1
                                    //}}
                                },
                                // If the bomb blocks are broken, the SideHoppers can be killed
                                // safely from behind with Power Beam. Breaking the obstacle here
                                // isn't handled to avoid redundancy. Obstacle can be broken by
                                // going to 5 and back.
                                new Strat {
                                    Name = "Safe Sidehopper Power Beam Kill",
                                    Requires = null, // ["Morph"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle { Name = "Sidehopper trio" },
                                        new Strat.Obstacle {
                                            Name = "Bomb Blocks",
                                            Requires = null, // ["never"]
                                        },
                                    },
                                },
                            }),
                            new LinkTarget("SM - Blue Highway - Walled Off Item", new[] {
                                new Strat {
                                    Name = "Bomb the Blocks",
                                    Requires = null, // ["Morph"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Bomb Blocks",
                                            Requires = null,
                                            //{"or":[
                                            //  "Bombs",
                                            //  {"and":[
                                            //    "PowerBomb",
                                            //    {"ammo": {
                                            //      "type": "PowerBomb",
                                            //      "count": 1
                                            //    }}
                                            //  ]}
                                            //]}
                                        },
                                    },
                                },
                                // It's a short charge into a speedball to break the bomb blocks.
                                // The Sidehoppers need to be destroyed beforehand to clear the
                                // running space.
                                new Strat {
                                    Name = "Morph Ball Room Speedball (Left to Right)",
                                    Notable = true,
                                    Requires = null, // ["Morph"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Sidehopper trio",
                                            Requires = null, // ["never"]
                                        },
                                        new Strat.Obstacle {
                                            Name = "Bomb Blocks",
                                            Requires = null,
                                            //[ {"canShineCharge": {
                                            //    "usedTiles": 18,
                                            //    "shinesparkFrames": 0,
                                            //    "openEnd": 0
                                            //  }},
                                            //  "canMockball"
                                            //]
                                        },
                                    },
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Blue Highway - Morph Ball Room Sidehoppers",
                        EnemyName = "Sidehopper",
                        Quantity = 3,
                        HomeNodes = new[] {
                            "SM - Blue Highway - Left Door",
                            "SM - Blue Highway - Sidehopper Junction",
                        },
                        Spawn = null, // ["f_ZebesAwake"]
                    }
                },
            },
            #endregion
            #region Construction Zone
            new Room {
                Name = "SM - Construction Zone",
                Layout = Room.LayoutFrom(@"
                      2→X←3
                      1→X"
                    , "SM - Construction Zone - Top Left Door"
                    , "SM - Construction Zone - Right Door"
                    , "SM - Construction Zone - Bottom Left Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Construction Zone - Top Left Door",
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
                        Name = "SM - Construction Zone - Right Door",
                        Type = TransitionType.Red,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 2,
                                OpenEnd = 0,
                                UsableComingIn = false,
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Construction Zone - Red Lock",
                                Type = LockType.ColoredDoor,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["h_canOpenRedDoors"]*/ },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Construction Zone - Bottom Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 3,
                                OpenEnd = 0,
                            },
                        },
                    },
                    new Junction {
                        Name = "SM - Construction Zone - Top Junction",
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Construction Zone - Top Left Door",
                        To = new[] {
                            new LinkTarget("SM - Construction Zone - Top Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Construction Zone - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Construction Zone - Top Junction"),
                        },
                    },
                    new Link {
                        From = "SM - Construction Zone - Bottom Left Door",
                        To = new[] {
                            new LinkTarget("SM - Construction Zone - Top Junction", new[] {
                                new Strat { Requires = null /*["Morph"]*/ },
                                new Strat {
                                    Name = "Construction Room X-Ray Climb",
                                    Notable = true,
                                    Requires = null,
                                    //[ "canRightFacingDoorXRayClimb",
                                    //  { "resetRoom": {
                                    //    "nodes": [3],
                                    //    "mustStayPut": true
                                    //  }}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Construction Zone - Top Junction",
                        To = new[] {
                            new LinkTarget("SM - Construction Zone - Top Left Door"),
                            new LinkTarget("SM - Construction Zone - Right Door"),
                            new LinkTarget("SM - Construction Zone - Bottom Left Door", new[] {
                                new Strat { Requires = null /*["Morph"]*/ },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Construction Zone - Geemers",
                        EnemyName = "Geemer (blue)",
                        Quantity = 2,
                        HomeNodes = new[] { "SM - Construction Zone - Top Junction" },
                        Spawn = null, // ["f_ZebesAwake"]
                    }
                },
            },
            #endregion
            #region Brinstar Blue Chozo Room
            new Room {
                Name = "SM - Brinstar Blue Chozo Room",
                Layout = Room.LayoutFrom(@"
                      X←1"
                    , "SM - Brinstar Blue Chozo Room - Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Brinstar Blue Chozo Room - Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 9,
                                OpenEnd = 0,
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - Brinstar Blue Chozo Room - Item",
                        Type = PlacementType.Chozo,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Brinstar Blue Chozo Room - Door",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Blue Chozo Room - Item"),
                        },
                    },
                    new Link {
                        From = "SM - Brinstar Blue Chozo Room - Item",
                        To = new[] {
                            new LinkTarget("SM - Brinstar Blue Chozo Room - Door"),
                        },
                    },
                },
            },
            #endregion
            // Todo: Acceptable name?
            #region Blue Highway Curve
            new Room {
                Name = "SM - Blue Highway Curve",
                Layout = Room.LayoutFrom(@"
                        2→X
                          X
                          X
                      1→XXX"
                    , "SM - Blue Highway Curve - Bottom Left Door"
                    , "SM - Blue Highway Curve - Top Left Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Blue Highway Curve - Bottom Left Door",
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
                                Length = 31,
                                OpenEnd = 0,
                                FramesRemaining = 120,
                            },
                            new RunwayCharge {
                                Length = 33,
                                FramesRemaining = 120,
                                OpenEnd = 0,
                                Strats = new[] {
                                    new Strat { Requires = null /*["h_canUsePowerBombs"]*/ },
                                },
                            },
                        },
                        ViewableNodes = new[] {
                            new ViewableNode("SM - Blue Highway Curve - Ceiling Item"),
                        },
                    },
                    new Transition {
                        Name = "SM - Blue Highway Curve - Top Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 4,
                                OpenEnd = 0,
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - Blue Highway Curve - Ceiling Item",
                        Type = PlacementType.Hidden,
                    },
                    new Placement {
                        Name = "SM - Blue Highway Curve - Curve Item",
                        Type = PlacementType.Visible,
                    },
                },
                Obstacles = new[] {
                    new Obstacle {
                        Name = "Top Bomb Block",
                        Type = ObstacleType.Inanimate,
                    },
                    new Obstacle {
                        Name = "Crumble Block",
                        Type = ObstacleType.Inanimate,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Blue Highway Curve - Bottom Left Door",
                        To = new[] {
                            new LinkTarget("SM - Blue Highway Curve - Ceiling Item", new[] {
                                new Strat {
                                    Requires = null,
                                    //{"or":[
                                    //  "HiJump",
                                    //  "SpaceJump",
                                    //  "canSpringBallJumpMidAir"
                                    //]}
                                },
                                new Strat {
                                    Name = "Use Frozen Enemy",
                                    Requires = null,
                                    //[ "f_ZebesAwake",
                                    //  "canUseFrozenEnemies"
                                    //]
                                },
                                // Would've been notable due to breaking the shot block while
                                // maintaining ibj, but there's a tech for that.
                                new Strat {
                                    Name = "Ceiling E-Tank IBJ",
                                    Requires = null, // ["canBombAboveIBJ"]
                                },
                                new Strat {
                                    Name = "Ceiling E-Tank Dboost",
                                    Notable = true,
                                    Requires = null,
                                    //[ "f_ZebesAwake",
                                    //  "canDamageBoost",
                                    //  {"enemyDamage": {
                                    //    "enemy": "Reo",
                                    //    "hits": 1,
                                    //    "type": "contact"
                                    //  }}
                                    //]
                                },
                                // Does not require a shinespark. You can shoot the block, then
                                // just run and jump.
                                new Strat {
                                    Name = "Ceiling E-Tank Speed Jump",
                                    Notable = true,
                                    Requires = null, // ["SpeedBooster"]
                                },
                                new Strat {
                                    Name = "Ceiling E-Tank PB Boost",
                                    Notable = true,
                                    Requires = null, // ["canUnmorphBombBoost"]
                                },
                            }),
                            new LinkTarget("SM - Blue Highway Curve - Curve Item", new[] {
                                new Strat { Requires = null /*["Morph"]*/ },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Blue Highway Curve - Top Left Door",
                        To = new[] {
                            new LinkTarget("SM - Blue Highway Curve - Curve Item", new[] {
                                new Strat {
                                    Requires = null, // ["Morph"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Top Bomb Block",
                                            Requires = null,
                                            //{"or":[
                                            //  "ScrewAttack",
                                            //  "Bombs",
                                            //  "h_canUsePowerBombs"
                                            //]}
                                        },
                                        new Strat.Obstacle { Name = "Crumble Block" },
                                    },
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Blue Highway Curve - Ceiling Item",
                        To = new[] {
                            new LinkTarget("SM - Blue Highway Curve - Bottom Left Door"),
                        },
                    },
                    new Link {
                        From = "SM - Blue Highway Curve - Curve Item",
                        To = new[] {
                            new LinkTarget("SM - Blue Highway Curve - Bottom Left Door", new[] {
                                new Strat { Requires = null, /*["Morph"]*/ },
                            }),
                            new LinkTarget("SM - Blue Highway Curve - Top Left Door", new[] {
                                // If the Crumble Block has been destroyed while going down, it's
                                // possible to go back up without breaking the PB blocks.
                                new Strat {
                                    Name = "Go Back Up",
                                    Requires = null, // ["Morph"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Crumble Block",
                                            Requires = null, // ["never"]
                                        },
                                        new Strat.Obstacle {
                                            Name = "Top Bomb Block",
                                            Requires = null,
                                            //{"or":[
                                            //  "ScrewAttack",
                                            //  "Bombs",
                                            //  {"and":[
                                            //    "PowerBomb",
                                            //    {"ammo": {
                                            //      "type": "PowerBomb",
                                            //      "count": 1
                                            //    }}
                                            //  ]}
                                            //]}
                                        },
                                    },
                                },
                                // Base strat when entering the room from below. The runway here is
                                // 31 tiles before breaking the PB blocks, but becomes longer after.
                                new Strat {
                                    Name = "Break the PB Blocks",
                                    Requires = null, // ["h_canUsePowerBombs"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Top Bomb Block",
                                            Requires = null,
                                            //{"or": [
                                            //  "ScrewAttack",
                                            //  "Bombs",
                                            //  {"canShineCharge": {
                                            //    "usedTiles": 33,
                                            //    "shinesparkFrames": 43,
                                            //    "openEnd": 2
                                            //  }},
                                            //  {"ammo": {
                                            //    "type": "PowerBomb",
                                            //    "count": 1
                                            //  }}
                                            //]}
                                        },
                                    },
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Blue Highway Curve - Geemers",
                        EnemyName = "Geemer (blue)",
                        Quantity = 2,
                        HomeNodes = new[] { "SM - Blue Highway Curve - Bottom Left Door" },
                        Spawn = null, // ["f_ZebesAwake"]
                    },
                    new Enemy {
                        GroupName = "SM - Blue Highway Curve - Skrees",
                        EnemyName = "Skree",
                        Quantity = 2,
                        HomeNodes = new[] { "SM - Blue Highway Curve - Bottom Left Door" },
                        Spawn = null, // ["f_ZebesAwake"]
                    },
                    new Enemy {
                        GroupName = "SM - Blue Highway Curve - Reo",
                        EnemyName = "Reo",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Blue Highway Curve - Bottom Left Door" },
                        Spawn = null, // ["f_ZebesAwake"]
                    },
                },
            },
            #endregion
            #region Boulder Room
            new Room {
                Name = "SM - Boulder Room",
                Layout = Room.LayoutFrom(@"
                      1→XX←2"
                    , "SM - Boulder Room - Left Door"
                    , "SM - Boulder Room - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Boulder Room - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 2,
                                OpenEnd = 0,
                                UsableComingIn = false,
                            },
                        },
                        CanLeaveCharged = new[] {
                            new RunwayCharge {
                                Length = 19,
                                OpenEnd = 2,
                                FramesRemaining = 100,
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Boulder Room - Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 0,
                                OpenEnd = 1,
                            },
                        },
                        CanLeaveCharged = new[] {
                            new RunwayCharge {
                                Length = 19,
                                OpenEnd = 2,
                                FramesRemaining = 50,
                                Strats = new[] {
                                    new Strat { Requires = null /*["Gravity"]*/ },
                                },
                            },
                        },
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Boulder Room - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Boulder Room - Right Door"),
                        },
                    },
                    new Link {
                        From = "SM - Boulder Room - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Boulder Room - Left Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //{"or":[
                                    //  "Gravity",
                                    //  "SpaceJump"
                                    //]}
                                },
                                // A doorsill with an open end is really all the room that's needed
                                // on the other side.
                                new Strat {
                                    Name = "Boulder Room Jump Through the Door",
                                    Notable = true,
                                    Requires = null,
                                    //[ {"adjacentRunway": {
                                    //    "fromNode": 2,
                                    //    "usedTiles": 0.5
                                    //  }},
                                    //  "canWalljump"
                                    //]
                                },
                                // It's not even necessary to jump through the door, the in-room
                                // doorsill gives enough running room to make it up.
                                new Strat {
                                    Name = "Boulder Room Doorsill Jump",
                                    Notable = true,
                                    Requires = null, // ["canWalljump"]
                                },
                                new Strat {
                                    Name = "Boulder Room SpringWall",
                                    Notable = true,
                                    Requires = null, // ["canSpringwall"]
                                },
                                // It's a delayed walljump while the water is low, followed by a
                                // tight walljump off the bridge.
                                new Strat {
                                    Name = "Boulder Room Naked Walljump",
                                    Notable = true,
                                    Requires = null, // ["canInsaneWalljump"],
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Boulder Room - Boulders",
                        EnemyName = "Boulder",
                        Quantity = 3,
                        HomeNodes = new[] { "SM - Boulder Room - Left Door" },
                    },
                },
            },
            #endregion
            #region Billy Mays Room
            new Room {
                Name = "SM - Billy Mays Room",
                Layout = Room.LayoutFrom(@"
                      X←1"
                    , "SM - Billy Mays Room - Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Billy Mays Room - Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 1,
                                OpenEnd = 1,
                                UsableComingIn = false,
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - Billy Mays Room - Pedestal Item",
                        Type = PlacementType.Visible,
                    },
                    new Placement {
                        Name = "SM - Billy Mays Room - Surprise Item",
                        Type = PlacementType.Hidden,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Billy Mays Room - Door",
                        To = new[] {
                            new LinkTarget("SM - Billy Mays Room - Pedestal Item"),
                        },
                    },
                    new Link {
                        From = "SM - Billy Mays Room - Pedestal Item",
                        To = new[] {
                            new LinkTarget("SM - Billy Mays Room - Door"),
                            new LinkTarget("SM - Billy Mays Room - Surprise Item"),
                        },
                    },
                    new Link {
                        From = "SM - Billy Mays Room - Surprise Item",
                        To = new[] {
                            new LinkTarget("SM - Billy Mays Room - Pedestal Item"),
                        },
                    },
                },
            },
            #endregion
        };

    }

}
