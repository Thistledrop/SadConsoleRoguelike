using System;
using SadConsole;
using SadConsole.Components;
using SadConsole.EasingFunctions;
using SadRogueExample.MapObjects.Components;
using SadRogueExample.Maps;
using SadRogueExample.Screens.MainGameMenus;
using SadRogueExample.Screens.MainGameStates;
using SadRogueExample.Screens.Surfaces;
using SadRogueExample.Themes;
using StatusPanel = SadRogueExample.Screens.Surfaces.StatusPanel;

namespace SadRogueExample.Screens;

/// <summary>
/// Main game screen that shows map, message log, etc.  It supports a number of "states", where states are components
/// which are attached to the map's DefaultRenderer and implement controls/logic for the state.
/// </summary>
internal class MainGame : ScreenObject
{
    public GameMap Map;
    public int currentLevel;
    public readonly MapManager MapManager;
    public MessageLogPanel MessagePanel;
    public StatusPanel StatusPanel;

    /// <summary>
    /// Component which locks the map's view onto an entity (usually the player).
    /// </summary>
    public SurfaceComponentFollowTarget ViewLock;

    private IComponent? _currentState;

    public IComponent CurrentState
    {
        get => _currentState ?? throw new InvalidOperationException("Current game state should never be null.");
        set
        {
            if (_currentState == value) return;

            if (_currentState != null) Map.DefaultRenderer!.SadComponents.Remove(_currentState);
            _currentState = value;
            Map.DefaultRenderer!.SadComponents.Add(_currentState);
        }
    }

    private const int StatusBarWidth = 25;
    private const int BottomPanelHeight = 5;

    public MainGame()
    {
        MapManager = new MapManager();

        currentLevel = 0;

        changeLevel(currentLevel);
    }

    public void changeLevel(int level)
    {
        currentLevel = level;
        GameMap newMap = MapManager.getLevelMap(level);

        Map = newMap;

        Engine.Player.AllComponents.GetFirst<PlayerFOVController>().CalculateFOV();

        if(Map.DefaultRenderer != null)
        { Map.RemoveRenderer(Map.DefaultRenderer); }
        Map.DefaultRenderer = Map.CreateRenderer((Engine.ScreenWidth, Engine.ScreenHeight - BottomPanelHeight));
        
        Children.Clear();
        Children.Add(Map);
        Map.DefaultRenderer.IsFocused = true;

        ViewLock = new SurfaceComponentFollowTarget { Target = Engine.Player };
        Map.DefaultRenderer.SadComponents.Add(ViewLock);

        // Create message log
        MessagePanel = new MessageLogPanel(Engine.ScreenWidth - StatusBarWidth - 1, BottomPanelHeight)
        {
            Parent = this,
            Position = new(StatusBarWidth + 1, Engine.ScreenHeight - BottomPanelHeight)
        };

        // Create status panel
        StatusPanel = new(StatusBarWidth, BottomPanelHeight)
        {
            Parent = this,
            Position = new(0, Engine.ScreenHeight - BottomPanelHeight)
        };

        CurrentState = new MainMapState(this);

        // Add player death handler
        Engine.Player.AllComponents.GetFirst<Combatant>().Died += PlayerDeath;

        Engine.MessageLog.Add(new($"Hello and welcome, adventurer, to dungeon level {currentLevel}", MessageColors.WelcomeTextAppearance));
    }

    public void Uninitialize()
    {
        MessagePanel.Parent = null;
        StatusPanel.Parent = null;
        Engine.Player.AllComponents.GetFirst<Combatant>().Died -= PlayerDeath;
    }

    public void DisplayStairConfirmation(bool isUp)
    {
        Engine.MessageLog.Add(new("You bumped the stairs"));

        Children.Add(new UseStairsConfirmation(isUp));
    }

    /// <summary>
    /// Called when the player dies.
    /// </summary>
    private void PlayerDeath(object? s, EventArgs e)
    {
        Engine.MessageLog.Add(new("You have died!", MessageColors.PlayerDiedAppearance));

        Engine.Player.AllComponents.GetFirst<Combatant>().Died -= PlayerDeath;

        // Switch to game over screen
        Children.Add(new GameOver());
    }
}