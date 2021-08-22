using System.Collections.Generic;
using SMRouteRando.Util;

namespace SMRouteRando {

    public class Room {
        public string Name { get; init; }
        public IList<LayoutSquare> Layout { get; init; }
        public IList<Node> Nodes { get; init; }
        public IList<Obstacle> Obstacles { get; init; }
        public IList<Link> Links { get; init; }
        public IList<Enemy> Enemies { get; init; }

        // Todo: Figure this out later
        public static IList<LayoutSquare> LayoutFrom(string template, params string[] transitions)
            => Empty<LayoutSquare>.List;
    }

    // Can currently only handle one entrance.
    // Will require list and flag enum to handle multiple.
    public class LayoutSquare {
        public SquareType Type { get; init; }
        public (int x, int y) Pos { get; init; }
        public string Transition { get; init; }

        public enum SquareType {
            Room,
            EnterFromLeft,
            EnterFromTop,
            EnterFromRight,
            EnterFromBottom,
        }
    }

    #region Node

    public class Node {
        public string Name { get; init; }
        public string SpawnAt { get; init; }
        public IList<RunwayDash> Runways { get; init; }
        public IList<RunwayCharge> CanLeaveCharged { get; init; }
        public IList<Lock> Locks { get; init; }
        public IList<ViewableNode> ViewableNodes { get; init; }
        public IList<string> Yields { get; init; }
    }

    public record ViewableNode(string Name, IList<Strat> Strats = null);

    public class Transition : Node {
        public TransitionType Type { get; init; }
        public TransitionDirection Direction { get; init; } = TransitionDirection.EnterExit;
    }

    public enum TransitionType {
        Gray,
        Blue,
        Red,
        Green,
        Yellow,
        Gedora,
        Elevator,
        Doorway,
        Passage,
        Sandpit,
    }

    public enum TransitionDirection {
        EnterExit,
        Enter,
        Exit,
    }

    public class Junction : Node { }

    public class Placement : Node {
        public PlacementType Type { get; init; }
    }

    public enum PlacementType {
        Visible,
        Hidden,
        Chozo,
    }

    public class Utility : Node {
        public UtilityType Type { get; init; }
    }

    public enum UtilityType {
        Save,
        Map,
        Energy,
        Missile,
        Ship,
    }

    public class Event : Node {
        public EventType Type { get; init; }
    }

    public enum EventType {
        Flag,
        Boss,
    }

    #endregion

    #region Runway

    public class Runway {
        public int Length { get; init; }
        public int GentleUpTiles { get; init; }
        public int GentleDownTiles { get; init; }
        public int SteepUpTiles { get; init; }
        public int SteepDownTiles { get; init; }
        public int StartingDownTiles { get; init; }
        public int OpenEnd { get; init; }
        public IList<Strat> Strats { get; init; }
    }

    public class RunwayDash : Runway {
        public int EndingUpTiles { get; init; }
        public bool UsableComingIn { get; init; } = true;
    }

    public class RunwayCharge : Runway {
        public InitiateRemotely InitiateRemotely { get; init; }
        public int FramesRemaining { get; init; }
        public int ShinesparkFrames { get; init; }
    }

    public class InitiateRemotely {
        public string InitiateAt { get; init; }
        public bool MustOpenDoorFirst { get; init; }
        public IList<PathStep> PathToDoor { get; init; }
    }

    public record PathStep(string DestinationNode, IList<string> Strats);

    #endregion

    #region Lock

    public class Lock {
        public string Name { get; init; }
        public LockType Type { get; init; }
        public Condition Active { get; init; }
        public IList<Strat> UnlockStrats { get; init; }
        public IList<Strat> BypassStrats { get; init; }
    }

    public enum LockType {
        ColoredDoor,
        KillEnemies,
        GameFlag,
        BossFight,
        Permanent,
        TriggeredEvent,
        Cutscene,
        EscapeFunnel,
    }

    #endregion

    #region Link

    public class Link {
        public string From { get; init; }
        public IList<LinkTarget> To { get; init; }
    }

    public record LinkTarget(string Name, IList<Strat> Strats = null);

    #endregion

    #region Obstacle

    public class Obstacle {
        public string Name { get; init; }
        public ObstacleType Type { get; init; }
        public Condition Requires { get; init; }
    }

    public enum ObstacleType {
        Inanimate,
        Enemies,
    }

    #endregion

    #region Enemy

    public class Enemy {
        public string GroupName { get; init; }
        public string EnemyName { get; init; }
        public int Quantity { get; init; }
        public IList<string> HomeNodes { get; init; }
        public IList<string> BetweenNodes { get; init; }
        public Condition Spawn { get; init; }
        public Condition StopSpawn { get; init; }
        public Condition DropRequires { get; init; }
        public IList<FarmCycle> FarmCycles { get; init; }
    }

    public class FarmCycle {
        public string Name { get; init; }
        public int CycleFrames { get; init; }
        public Condition Requires { get; init; }
    }

    #endregion

    public class Strat {
        public string Name { get; init; }
        public bool Notable { get; init; }
        public Condition Requires { get; init; }
        public IList<Obstacle> Obstacles { get; init; }
        public IList<Failure> Failures { get; init; }
        public IList<string> StratProperties { get; init; }

        public class Obstacle {
            public string Name { get; init; }
            public Condition Requires { get; init; }
            public Condition Bypass { get; init; }
            public IList<string> AdditionalObstacles { get; init; }
        }

        public class Failure {
            public string Name { get; init; }
            public string LeadsToNode { get; init; }
            public Condition Cost { get; init; }
            public bool Softlock { get; init; }
            public bool ClearsPreviousNode { get; init; }
        }
    }

}
