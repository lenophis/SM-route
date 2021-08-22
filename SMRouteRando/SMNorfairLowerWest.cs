using System.Collections.Generic;

namespace SMRouteRando {

    public class SMNorfairLowerWest {

        public static IList<Room> Rooms { get; } = new[] {
            #region Acid Statue Room
            new Room {
                Name = "SM - Acid Statue Room",
                Layout = Room.LayoutFrom(@"
                      XX←1
                      XX
                      XXX←2"
                    , "SM - Acid Statue Room - Top Right Door"
                    , "SM - Acid Statue Room - Bottom Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Acid Statue Room - Top Right Door",
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
                        Name = "SM - Acid Statue Room - Bottom Right Door",
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
                    // This node represents the ledge the statue is on. This is why it can be
                    // reached without breaking the PB blocks, nut not unlocked.
                    new Event {
                        Name = "SM - Acid Statue Room - Chozo Statue",
                        Type = EventType.Flag,
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Acid Statue Room - Statue Lock",
                                Type = LockType.TriggeredEvent,
                                UnlockStrats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  "SpaceJump",
                                        //  "h_canUsePowerBombs",
                                        //  {"heatFrames": 800}
                                        //]
                                    },
                                },
                            },
                        },
                        Yields = new[] { "f_UsedAcidChozoStatue" },
                    },
                    // Because going into the acid while it is present is pointless unless traveling
                    // from Top Right Door to Chozo Statue, this node will be considered to only be
                    // visitable when the acid is gone.
                    new Junction {
                        Name = "SM - Acid Statue Room - Drained Acid Junction",
                    },
                    new Junction {
                        Name = "SM - Acid Statue Room - Bottom Junction",
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Acid Statue Room - Top Right Door",
                        To = new[] {
                            new LinkTarget("SM - Acid Statue Room - Chozo Statue", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "SpaceJump",
                                    //  {"heatFrames": 200}
                                    //]
                                },
                                new Strat {
                                    Name = "Without Acid",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "f_UsedAcidChozoStatue",
                                    //  {"heatFrames": 350}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Acid Statue Room - Drained Acid Junction", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "f_UsedAcidChozoStatue",
                                    //  { "heatFrames": 100}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Acid Statue Room - Bottom Right Door",
                        To = new[] {
                            new LinkTarget("SM - Acid Statue Room - Bottom Junction", new[] {
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
                        From = "SM - Acid Statue Room - Chozo Statue",
                        To = new[] {
                            new LinkTarget("SM - Acid Statue Room - Top Right Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "SpaceJump",
                                    //  {"heatFrames": 300}
                                    //]
                                },
                                new Strat {
                                    Name = "Without Acid",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "f_UsedAcidChozoStatue",
                                    //  {"heatFrames": 300}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Acid Statue Room - Drained Acid Junction", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "f_UsedAcidChozoStatue",
                                    //  { "heatFrames": 100}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Acid Statue Room - Drained Acid Junction",
                        To = new[] {
                            new LinkTarget("SM - Acid Statue Room - Top Right Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "f_UsedAcidChozoStatue",
                                    //  {"heatFrames": 250}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Acid Statue Room - Chozo Statue", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "f_UsedAcidChozoStatue",
                                    //  {"heatFrames": 200}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Acid Statue Room - Bottom Junction", new[] {
                                new Strat {
                                    Name = "Morph Bombs",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "f_UsedAcidChozoStatue",
                                    //  "h_canUseMorphBombs",
                                    //  { "heatFrames": 400}
                                    //]
                                },
                                new Strat {
                                    Name = "PowerBombs",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "f_UsedAcidChozoStatue",
                                    //  "h_canUsePowerBombs",
                                    //  { "heatFrames": 250}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Acid Statue Room - Bottom Junction",
                        To = new[] {
                            new LinkTarget("SM - Acid Statue Room - Bottom Right Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 400}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Acid Statue Room - Drained Acid Junction", new[] {
                                new Strat {
                                    Name = "Morph Bombs",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "f_UsedAcidChozoStatue",
                                    //  "h_canUseMorphBombs",
                                    //  {"heatFrames": 600}
                                    //]
                                },
                                new Strat {
                                    Name = "Power Bombs",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "f_UsedAcidChozoStatue",
                                    //  "h_canUsePowerBombs",
                                    //  { "heatFrames": 300}
                                    //]
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Acid Statue Room - Holtzes",
                        EnemyName = "Holtz",
                        Quantity = 3,
                        HomeNodes = new[] { "SM - Acid Statue Room - Bottom Right Door" },
                        DropRequires = null, // ["h_heatProof"]
                    },
                    new Enemy {
                        GroupName = "SM - Acid Statue Room - Magdollite",
                        EnemyName = "Magdollite",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Acid Statue Room - Bottom Right Door" },
                        DropRequires = null,
                        //[ "Grapple",
                        //  "h_heatProof"
                        //]
                    },
                },
            },
            #endregion
            #region Golden Torizo's Room
            new Room {
                Name = "SM - Golden Torizo's Room",
                Layout = Room.LayoutFrom(@"
                      1→XX
                        XX←2"
                    , "SM - Golden Torizo Room - Left Door"
                    , "SM - Golden Torizo Room - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Golden Torizo Room - Left Door",
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
                        Name = "SM - Golden Torizo Room - Right Door",
                        Type = TransitionType.Gray,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 28,
                                OpenEnd = 0,
                                Strats = new[] {
                                    // Even if the door could be unlocked without killing GT, the
                                    // runway wouldn't be usable unless it's dead.
                                    new Strat {
                                        Requires = null,
                                        //[ "f_DefeatedGoldenTorizo",
                                        //  "h_canNavigateHeatRooms",
                                        //  {"heatFrames": 280}
                                        //]
                                    },
                                },
                            },
                        },
                        Locks = new[] {
                            new Lock {
                                Name = "SM - Golden Torizo Room - Grey Lock",
                                Type = LockType.GameFlag,
                                UnlockStrats = new[] {
                                    new Strat { Requires = null /*["f_DefeatedGoldenTorizo"]*/ },
                                },
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - Golden Torizo Room - Left Item",
                        Type = PlacementType.Visible,
                    },
                    new Placement {
                        Name = "SM - Golden Torizo Room - Right Item",
                        Type = PlacementType.Hidden,
                    },
                    new Event {
                        Name = "SM - Golden Torizo Room - Golden Torizo",
                        Type = EventType.Boss,
                        Locks = new[] {
                            new Lock {
                                Name = "Golden Torizo Fight",
                                Type = LockType.BossFight,
                                UnlockStrats = new[] {
                                    // Supers are farmable here, so no ammo requirement.
                                    new Strat {
                                        Name = "Heatproof Supers",
                                        Requires = null,
                                        //[ "h_heatProof",
                                        //  "Super"
                                        //]
                                    },
                                    new Strat {
                                        Name = "Heatproof Charge",
                                        Requires = null,
                                        //[ "h_heatProof",
                                        //  "Charge"
                                        //]
                                    },
                                    // No farming expected because that would change the heat frames.
                                    // Supers count hard-coded because of GT's inherent 'dodging' ability.
                                    // We could use an enemyKill if this were integrated into the enemy
                                    // definition. It actually takes 29 supers but giving 1 extra in
                                    // leniency since it's easy to miss.
                                    new Strat {
                                        Name = "Supers",
                                        Requires = null,
                                        //[ "canHeatRun",
                                        //  "Super",
                                        //  {"heatFrames": 1200},
                                        //  {"ammo": {
                                        //    "type": "Super",
                                        //    "count": 30
                                        //  }}
                                        //]
                                    },
                                    new Strat {
                                        Name = "Full Combo",
                                        Requires = null,
                                        //[ "canHeatRun",
                                        //  "Charge",
                                        //  "Ice",
                                        //  "Wave",
                                        //  "Plasma",
                                        //  { "heatFrames": 1250}
                                        //]
                                    },
                                    new Strat {
                                        Name = "Almost Full Combo",
                                        Requires = null,
                                        //[ "canHeatRun",
                                        //  "Charge",
                                        //  "Wave",
                                        //  "Plasma",
                                        //  { "heatFrames": 1400}
                                        //]
                                    },
                                    new Strat {
                                        Name = "Charge Plasma",
                                        Requires = null,
                                        //[ "canHeatRun",
                                        //  "Charge",
                                        //  "Plasma",
                                        //  { "heatFrames": 2000}
                                        //]
                                    },
                                    new Strat {
                                        Name = "Full Spazer",
                                        Requires = null,
                                        //[ "canHeatRun",
                                        //  "Charge",
                                        //  "Ice",
                                        //  "Wave",
                                        //  "Spazer",
                                        //  { "heatFrames": 4000}
                                        //]
                                    },
                                },
                            },
                        },
                        Yields = new[] { "f_DefeatedGoldenTorizo" },
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Golden Torizo Room - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Golden Torizo Room - Left Item", new[] {
                                new Strat {
                                    Name = "GT Crumble Jump to Left Item",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "canCrumbleJump",
                                    //  {"heatFrames": 100}
                                    //]
                                },
                                // There's enough running room in the room for a precise jump to get
                                // directly across. Needs to be flush against the door though, so takes
                                // a bit longer than the crumble jump.
                                new Strat {
                                    Name = "GT Direct Jump to Left Item",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "canTrickyJump",
                                    //  {"heatFrames": 150}
                                    //]
                                },
                                // Uses a single bomb blast to just barely get propelled past the crumble pit.
                                new Strat {
                                    Name = "GT HBJ to Left Item",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "canSingleHBJ",
                                    //  { "heatFrames": 200}
                                    //]
                                },
                                new Strat {
                                    Name = "Spring Ball",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "h_canUseSpringBall",
                                    //  { "heatFrames": 200}
                                    //]
                                },
                                new Strat {
                                    Name = "Space Jump",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "SpaceJump",
                                    //  { "heatFrames": 100}
                                    //]
                                },
                                new Strat {
                                    Name = "Shinespark",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"canComeInCharged": {
                                    //    "fromNode": 1,
                                    //    "framesRemaining": 0,
                                    //    "shinesparkFrames": 17
                                    //  }},
                                    //  { "heatFrames": 150}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Golden Torizo Room - Golden Torizo", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 200}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Golden Torizo Room - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Golden Torizo Room - Golden Torizo", new[] {
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
                        From = "SM - Golden Torizo Room - Left Item",
                        To = new[] {
                            new LinkTarget("SM - Golden Torizo Room - Left Door", new[] {
                                // It takes a short hop to avoid hitting the ceiling to do this
                                // with only one crumble jump.
                                new Strat {
                                    Name = "GT Crumble Jump from Left Item",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "canCrumbleJump",
                                    //  {"heatFrames": 150}
                                    //]
                                },
                                // There's not enough running room to get directly across. But with
                                // a precise enough jump and short hop, it's possible to walljump
                                // off the far edge and avoid the crumble blocks.
                                new Strat {
                                    Name = "GT Direct Jump from Left Item",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "canTrickyJump",
                                    //  {"heatFrames": 150}
                                    //]
                                },
                                // Uses a single bomb blast to just barely get propelled past the
                                // crumble pit.
                                new Strat {
                                    Name = "GT HBJ from Left Item",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "canSingleHBJ",
                                    //  { "heatFrames": 200}
                                    //]
                                },
                                new Strat {
                                    Name = "Spring Ball",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "h_canUseSpringBall",
                                    //  { "heatFrames": 200}
                                    //]
                                },
                                new Strat {
                                    Name = "Space Jump",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "SpaceJump",
                                    //  { "heatFrames": 100}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Golden Torizo Room - Golden Torizo", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 200}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Golden Torizo Room - Right Item",
                        To = new[] {
                            new LinkTarget("SM - Golden Torizo Room - Golden Torizo", new[] {
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
                        From = "SM - Golden Torizo Room - Golden Torizo",
                        To = new[] {
                            new LinkTarget("SM - Golden Torizo Room - Right Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 50}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Golden Torizo Room - Right Item", new[] {
                                new Strat {
                                    Name = "Power Bombs",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "h_canUsePowerBombs",
                                    //  {"heatFrames": 350}
                                    //]
                                },
                                new Strat {
                                    Name = "Space Screw",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "SpaceJump",
                                    //  "ScrewAttack",
                                    //  { "heatFrames": 200}
                                    //]
                                },
                                // This is kind of tricky because Screw off a walljump can only
                                // break bomb blocks if you change directions before bonking.
                                new Strat {
                                    Name = "GT Supers Screw Walljump",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "ScrewAttack",
                                    //  { "heatFrames": 200}
                                    //]
                                },
                                // Requires two separate sparks. One vertical spark is needed to
                                // open up the area directly above. Then, a second horizontal spark
                                // is performed where those blocks were cleared.
                                new Strat {
                                    Name = "GT Supers Double Shinespark",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "f_DefeatedGoldenTorizo",
                                    //  {"canShineCharge": {
                                    //    "usedTiles": 28,
                                    //    "shinesparkFrames": 11,
                                    //    "openEnd": 0
                                    //  }},
                                    //  { "heatFrames": 1000}
                                    //]
                                },
                                // Expects two IBJs; one to break a block, then another one to get
                                // back up.
                                new Strat {
                                    Name = "GT Supers IBJ",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "f_DefeatedGoldenTorizo",
                                    //  "canIBJ",
                                    //  { "heatFrames": 3000}
                                    //]
                                },
                                // Uses a Springwall to put a bomb on the left corner bomb block,
                                // then a second one to get in there. Then clears the rest of the
                                // bomb blocks normally. It winds up costing less heat frames than
                                // IBJ, if you fall.
                                new Strat {
                                    Name = "GT Supers Morph Bomb Springwall",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "h_canUseMorphBombs",
                                    //  "canSpringwall",
                                    //  { "heatFrames": 900}
                                    //]
                                },
                            }),
                        },
                    },
                },
                Enemies = new[] {
                    new Enemy {
                        GroupName = "SM - Golden Torizo Room - Golden Torizo",
                        EnemyName = "Golden Torizo",
                        Quantity = 1,
                        HomeNodes = new[] { "SM - Golden Torizo Room - Golden Torizo" },
                        StopSpawn = null, // ["f_DefeatedGoldenTorizo"]
                    },
                },
            },
            #endregion
            // Todo: Acceptable name?
            #region Norfair Lower Chozo Room
            new Room {
                Name = "SM - Norfair Lower Chozo Room",
                Layout = Room.LayoutFrom(@"
                        X←2
                        X←3
                      1→X"
                    , "SM - Norfair Lower Chozo Room - Left Door"
                    , "SM - Norfair Lower Chozo Room - Top Right Door"
                    , "SM - Norfair Lower Chozo Room - Bottom Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Norfair Lower Chozo Room - Left Door",
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
                        Name = "SM - Norfair Lower Chozo Room - Top Right Door",
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
                            // With Intact Blocks.
                            new RunwayDash {
                                Length = 12,
                                OpenEnd = 0,
                                Strats = new[] {
                                    // This longer runway is not usable if the bomb blocks are destroyed.
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"resetRoom":{
                                        //    "nodes": [3],
                                        //    "obstaclesToAvoid": ["A"]
                                        //  }},
                                        //  { "heatFrames": 220}
                                        //]
                                    },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Norfair Lower Chozo Room - Bottom Right Door",
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
                                        //  { "heatFrames": 100}
                                        //]
                                    },
                                },
                            },
                        },
                    },
                    new Placement {
                        Name = "SM - Norfair Lower Chozo Room - Item",
                        Type = PlacementType.Chozo,
                    },
                    // This exists because many strats for going up are somehwat independant from
                    // the strat for breaking the bomb blocks.
                    new Junction {
                        Name = "SM - Norfair Lower Chozo Room - Broken Top Blocks Middle Junction",
                    },
                },
                Obstacles = new[] {
                    new Obstacle {
                        Name = "Top Bomb Blocks",
                        Type = ObstacleType.Inanimate,
                    },
                    new Obstacle {
                        Name = "Bottom Bomb Blocks",
                        Type = ObstacleType.Inanimate,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Norfair Lower Chozo Room - Left Door",
                        To = new[] {
                            // Shinespark and XRayClimb have a direct link. Other strats should go
                            // Left Door -> Item -> Bottom Right Door.
                            new LinkTarget("SM - Norfair Lower Chozo Room - Bottom Right Door", new[] {
                                new Strat {
                                    Name = "Shinespark",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"canComeInCharged": {
                                    //    "fromNode": 1,
                                    //    "framesRemaining": 30,
                                    //    "shinesparkFrames": 35
                                    //  }},
                                    //  { "heatFrames": 200 }
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle { Name = "Bottom Bomb Blocks" },
                                    },
                                },
                                new Strat {
                                    Name = "Screw Attack Room Left-Side X-Ray Climb (to Middle Door)",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "canRightFacingDoorXRayClimb",
                                    //  {"resetRoom":{
                                    //    "nodes": [1],
                                    //    "mustStayPut": true
                                    //  }},
                                    //  { "heatFrames": 300}
                                    //]
                                },
                            }),
                            // Shinespark and XRayClimb have a direct link. Other strats should go
                            // Left Door -> Item -> Bottom Right Door -> Top Right Door.
                            new LinkTarget("SM - Norfair Lower Chozo Room - Top Right Door", new[] {
                                new Strat {
                                    Name = "Shinespark",
                                    Notable = false,
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"canComeInCharged": {
                                    //    "fromNode": 1,
                                    //    "framesRemaining": 60,
                                    //    "shinesparkFrames": 50
                                    //  }},
                                    //  { "heatFrames": 250 }
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle { Name = "Bottom Bomb Blocks" },
                                        new Strat.Obstacle { Name = "Top Bomb Blocks" },
                                    },
                                },
                                new Strat {
                                    Name = "Screw Attack Room Left-Side X-Ray Climb (to Top Door)",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "canRightFacingDoorXRayClimb",
                                    //  {"resetRoom":{
                                    //    "nodes": [1],
                                    //    "mustStayPut": true
                                    //  }},
                                    //  { "heatFrames": 800 }
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Norfair Lower Chozo Room - Item", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 60}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Norfair Lower Chozo Room - Bottom Right Door",
                        To = new[] {
                            new LinkTarget("SM - Norfair Lower Chozo Room - Top Right Door", new[] {
                                new Strat {
                                    Name = "Space Screw",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "SpaceJump",
                                    //  "ScrewAttack",
                                    //  {"heatFrames": 400}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle { Name = "Top Bomb Blocks" },
                                    },
                                },
                                // Run through the doorway with enough momentum to break the bomb
                                // blocks with Screw.
                                new Strat {
                                    Name = "Screw Attack Room Transition Screwjump",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "ScrewAttack",
                                    //  "HiJump",
                                    //  "SpeedBooster",
                                    //  {"adjacentRunway": {
                                    //    "fromNode": 2,
                                    //    "usedTiles": 2
                                    //  }},
                                    //  { "heatFrames": 150}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle { Name = "Top Bomb Blocks" },
                                    },
                                },
                                new Strat {
                                    Name = "Shinespark",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"canComeInCharged": {
                                    //    "fromNode": 2,
                                    //    "framesRemaining": 60,
                                    //    "shinesparkFrames": 35
                                    //  }},
                                    //  {"heatFrames": 250}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle { Name = "Top Bomb Blocks" },
                                    },
                                },
                            }),
                            new LinkTarget("SM - Norfair Lower Chozo Room - Item", new[] {
                                new Strat {
                                    Name = "Screw",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 140}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Bottom Bomb Blocks",
                                            Requires = null,
                                            //[ "ScrewAttack",
                                            //  {"heatFrames": 60}
                                            //]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Power Bombs",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 140}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Bottom Bomb Blocks",
                                            Requires = null,
                                            //[ "h_canUsePowerBombs",
                                            //  {"heatFrames": 60}
                                            //]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Morph Bombs",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 140}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Bottom Bomb Blocks",
                                            Requires = null,
                                            //[ "h_canUseMorphBombs",
                                            //  { "heatFrames": 120}
                                            //]
                                        },
                                    },
                                },
                            }),
                            // The heat frames for these strats assumes you've already fallen from
                            // the door, because the cost is already baked into the subsequent
                            // Broken Top Blocks Middle Junction -> Top Right Door heat costs when
                            // relevant.
                            new LinkTarget("SM - Norfair Lower Chozo Room - Broken Top Blocks Middle Junction", new[] {
                                new Strat {
                                    Name = "Power Bombs",
                                    Requires = null, // ["h_canNavigateHeatRooms"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Top Bomb Blocks",
                                            Requires = null,
                                            //[ "h_canUsePowerBombs",
                                            //  {"heatFrames": 200}
                                            //]
                                        },
                                    },
                                },
                                // Expects that you fall down afterwards.
                                new Strat {
                                    Name = "Screw Attack Room IBJ to Break the Top Blocks",
                                    Notable = true,
                                    Requires = null, // ["h_canNavigateHeatRooms"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Top Bomb Blocks",
                                            Requires = null,
                                            //[ "canIBJ",
                                            //  {"heatFrames": 1200}
                                            //]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Space Morph Bombs",
                                    Requires = null, // ["h_canNavigateHeatRooms"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Top Bomb Blocks",
                                            Requires = null,
                                            //[ "h_canUseMorphBombs",
                                            //  "SpaceJump",
                                            //  { "heatFrames": 300}
                                            //]
                                        },
                                    },
                                },
                                // Use a Springwall to get up to the bomb blocks, to break them
                                // with a morph bomb.
                                new Strat {
                                    Name = "Screw Attack Room Springwall Morph Bombs",
                                    Notable = true,
                                    Requires = null, // ["h_canNavigateHeatRooms"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Top Bomb Blocks",
                                            Requires = null,
                                            //[ "h_canUseMorphBombs",
                                            //  "canSpringwall",
                                            //  { "heatFrames": 300}
                                            //]
                                        },
                                    },
                                },
                                // Run in the adjacent room and jump through the door, to place a
                                // Morph Bomb to break the obstacle.
                                new Strat {
                                    Name = "Screw Attack Room Transition Speedjump (Morph Bombs)",
                                    Notable = true,
                                    Requires = null, // ["h_canNavigateHeatRooms"]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Top Bomb Blocks",
                                            Requires = null,
                                            //[ "HiJump",
                                            //  "SpeedBooster",
                                            //  {"adjacentRunway": {
                                            //    "fromNode": 2,
                                            //    "usedTiles": 2
                                            //  }},
                                            //  "h_canUseMorphBombs",
                                            //  { "heatFrames": 200}
                                            //]
                                        },
                                    },
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Norfair Lower Chozo Room - Top Right Door",
                        To = new[] {
                            new LinkTarget("SM - Norfair Lower Chozo Room - Bottom Right Door", new[] {
                                new Strat {
                                    Name = "Screw",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 200}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Top Bomb Blocks",
                                            Requires = null, // ["ScrewAttack"]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Power Bombs",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 200}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Top Bomb Blocks",
                                            Requires = null,
                                            //[ "h_canUsePowerBombs",
                                            //  { "heatFrames": 100}
                                            //]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Morph Bomb",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 200}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Top Bomb Blocks",
                                            Requires = null,
                                            //[ "h_canUseMorphBombs",
                                            //  { "heatFrames": 100}
                                            //]
                                        },
                                    },
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Norfair Lower Chozo Room - Item",
                        To = new[] {
                            new LinkTarget("SM - Norfair Lower Chozo Room - Left Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 60}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Norfair Lower Chozo Room - Bottom Right Door", new[] {
                                new Strat {
                                    Name = "Screw",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 200}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Bottom Bomb Blocks",
                                            Requires = null, // ["ScrewAttack"]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Power Bomb",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 200}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Bottom Bomb Blocks",
                                            Requires = null,
                                            //[ "h_canUsePowerBombs",
                                            //  { "heatFrames": 100}
                                            //]
                                        },
                                    },
                                },
                                new Strat {
                                    Name = "Morph Bomb",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 200}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Bottom Bomb Blocks",
                                            Requires = null,
                                            //[ "h_canUseMorphBombs",
                                            //  { "heatFrames": 100}
                                            //]
                                        },
                                    },
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Norfair Lower Chozo Room - Broken Top Blocks Middle Junction",
                        To = new[] {
                            // Because getting to this node always requires breaking
                            // Top Bomb Blocks, the strats here don't bother re-checking whether
                            // it's broken. Also, many of these strats expect that you come in from
                            // the door and fall down before doing anything.
                            new LinkTarget("SM - Norfair Lower Chozo Room - Top Right Door", new[] {
                                new Strat {
                                    Name = "Screw Attack Room IBJ",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "canIBJ",
                                    //  {"heatFrames": 1300}
                                    //]
                                },
                                new Strat {
                                    Name = "Space",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "SpaceJump",
                                    //  {"heatFrames": 400}
                                    //]
                                },
                                new Strat {
                                    Name = "Screw Attack Room Springwall",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "canSpringwall",
                                    //  { "heatFrames": 400}
                                    //]
                                },
                                // Position yourself in the door way, then run and jump. Makes it possible to walljump up.
                                new Strat {
                                    Name = "Screw Attack Room Doorway Speedjump",
                                    Notable = true,
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "HiJump",
                                    //  "SpeedBooster",
                                    //  { "heatFrames": 400}
                                    //]
                                },
                            }),
                        },
                    },
                },
            },
            #endregion
            #region Norfair Lower Energy Refill Room
            new Room {
                Name = "SM - Norfair Lower Energy Refill Room",
                Layout = Room.LayoutFrom(@"
                      1→X"
                    , "SM - Norfair Lower Energy Refill Room - Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Norfair Lower Energy Refill Room - Door",
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
                        Name = "SM - Norfair Lower Energy Refill Room - Energy Refill",
                        Type = UtilityType.Energy,
                    },
                },
                Links = new[] {
                    new Link {
                        From = "SM - Norfair Lower Energy Refill Room - Door",
                        To = new[] {
                            new LinkTarget("SM - Norfair Lower Energy Refill Room - Energy Refill"),
                        },
                    },
                    new Link {
                        From = "SM - Norfair Lower Energy Refill Room - Energy Refill",
                        To = new[] {
                            new LinkTarget("SM - Norfair Lower Energy Refill Room - Door"),
                        },
                    },
                },
            },
            #endregion
            #region Fast Ripper Room
            new Room {
                Name = "SM - Fast Ripper Room",
                Layout = Room.LayoutFrom(@"
                      1→XXXX←2"
                    , "SM - Fast Rippers Room - Left Door"
                    , "SM - Fast Rippers Room - Right Door"
                ),
                Nodes = new Node[] {
                    new Transition {
                        Name = "SM - Fast Rippers Room - Left Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 4,
                                OpenEnd = 1,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  {"heatFrames": 200}
                                        //]
                                    },
                                },
                            },
                        },
                    },
                    new Transition {
                        Name = "SM - Fast Rippers Room - Right Door",
                        Type = TransitionType.Blue,
                        Runways = new[] {
                            new RunwayDash {
                                Length = 9,
                                OpenEnd = 0,
                                Strats = new[] {
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  { "heatFrames": 120}
                                        //]
                                    },
                                },
                            },
                            // With Gate Open.
                            new RunwayDash {
                                Length = 28,
                                OpenEnd = 1,
                                UsableComingIn = false,
                                Strats = new[] {
                                    // This longer runway requires the green gate to be open, and
                                    // usually involves tanking some ripper hits.
                                    new Strat {
                                        Requires = null,
                                        //[ "h_canNavigateHeatRooms",
                                        //  { "heatFrames": 250},
                                        //  {"enemyDamage": {
                                        //    "enemy": "Ripper 2 (red)",
                                        //    "type": "contact",
                                        //    "hits": 2
                                        //  }}
                                        //]
                                        Obstacles = new[] {
                                            new Strat.Obstacle {
                                                Name = "Green Gate",
                                                Requires = null, // ["canHeatedGGG"]
                                            },
                                        },
                                    },
                                },
                            },
                        },
                    },
                    new Junction {
                        Name = "SM - Fast Rippers Room - Left of Gate Junction",
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
                        From = "SM - Fast Rippers Room - Left Door",
                        To = new[] {
                            new LinkTarget("SM - Fast Rippers Room - Left of Gate Junction", new[] {
                                new Strat {
                                    Name = "Tank the Rippers",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "h_canOpenGreenDoors",
                                    //  {"heatFrames": 450},
                                    //  {"enemyDamage": {
                                    //    "enemy": "Ripper 2 (red)",
                                    //    "type": "contact",
                                    //    "hits": 3
                                    //  }}
                                    //]
                                },
                                new Strat {
                                    Name = "Screw Attack",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "h_canOpenGreenDoors",
                                    //  {"heatFrames": 350},
                                    //  "ScrewAttack"
                                    //]
                                },
                                // The time lost by setting up a few strategic kills is pretty much
                                // offset by not having damage recoil.
                                new Strat {
                                    Name = "Kill some Rippers",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  "h_canOpenGreenDoors",
                                    //  { "heatFrames": 450},
                                    //  {"enemyKill":{
                                    //    "enemies": [
                                    //      [ "Ripper 2 (red)", "Ripper 2 (red)"]
                                    //    ],
                                    //    "explicitWeapons": [
                                    //      "Super",
                                    //      "PowerBomb"
                                    //    ]
                                    //  }}
                                    //]
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Fast Rippers Room - Right Door",
                        To = new[] {
                            new LinkTarget("SM - Fast Rippers Room - Left of Gate Junction", new[] {
                                new Strat {
                                    Name = "GGG",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 100}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Green Gate",
                                            Requires = null, // ["canHeatedGGG"]
                                        },
                                    },
                                },
                            }),
                        },
                    },
                    new Link {
                        From = "SM - Fast Rippers Room - Left of Gate Junction",
                        To = new[] {
                            new LinkTarget("SM - Fast Rippers Room - Left Door", new[] {
                                new Strat {
                                    Name = "Tank the Rippers",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 600},
                                    //  {"enemyDamage": {
                                    //    "enemy": "Ripper 2 (red)",
                                    //    "type": "contact",
                                    //    "hits": 2
                                    //  }}
                                    //]
                                },
                                new Strat {
                                    Name = "Screw Attack",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  {"heatFrames": 600},
                                    //  "ScrewAttack"
                                    //]
                                },
                                // It's more chaotic because the GGG's unreliability makes the room
                                // more variable, but one PB or 2 Super kills should usually do it.
                                new Strat {
                                    Name = "Kill some Rippers",
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 600},
                                    //  {"enemyKill":{
                                    //    "enemies": [
                                    //      [ "Ripper 2 (red)", "Ripper 2 (red)"]
                                    //    ],
                                    //    "explicitWeapons": [
                                    //      "Super",
                                    //      "PowerBomb"
                                    //    ]
                                    //  }}
                                    //]
                                },
                            }),
                            new LinkTarget("SM - Fast Rippers Room - Right Door", new[] {
                                new Strat {
                                    Requires = null,
                                    //[ "h_canNavigateHeatRooms",
                                    //  { "heatFrames": 100}
                                    //]
                                    Obstacles = new[] {
                                        new Strat.Obstacle {
                                            Name = "Green Gate",
                                            Requires = null,
                                            //[ "h_canNavigateHeatRooms",
                                            //  { "heatFrames": 50},
                                            //  "h_canOpenGreenDoors"
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
                        GroupName = "Fast Rippers",
                        EnemyName = "Ripper 2 (red)",
                        Quantity = 6,
                        HomeNodes = new[] { "SM - Fast Rippers Room - Left Door" },
                        DropRequires = null, // ["h_heatProof"]
                    },
                },
            },
            #endregion
        };

    }

}
