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
    public MessageLogPanel MessagePanel;
    public StatusPanel StatusPanel;
    public MonsterHealthPanel MonsterPanel;

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

    private const int StatusWidth = 25;
    private const int StatusHeight = 10;
    private const int BottomPanelHeight = 10;

    public MainGame()
    {
        currentLevel = 0;

        changeLevel(currentLevel);
    }

    public void changeLevel(int level)
    {
        if (Map != null)
        {
            Map.RemoveEntity(Engine.Player);
            Map.RemoveRenderer(Map.DefaultRenderer); 
        }
        Children.Clear();

        currentLevel = level;
        GameMap newMap = Maps.Factory.Dungeon(new(100, 60, 20, 30, 8, 12, 2, 2));
        newMap.AddPlayerAtPosition(newMap.stairsUpLocation);

        Map = newMap;

        Engine.Player.AllComponents.GetFirst<PlayerFOVController>().CalculateFOV();
        Map.DefaultRenderer = Map.CreateRenderer((Engine.ScreenWidth, Engine.ScreenHeight - BottomPanelHeight));
        
        Children.Add(Map);
        Map.DefaultRenderer.IsFocused = true;

        ViewLock = new SurfaceComponentFollowTarget { Target = Engine.Player };
        Map.DefaultRenderer.SadComponents.Add(ViewLock);

        // Create Message Log
        MessagePanel = new MessageLogPanel(Engine.ScreenWidth - StatusWidth, BottomPanelHeight)
        {
            Parent = this,
            Position = new(0, Engine.ScreenHeight - BottomPanelHeight)
        };

        // Create Status Panel
        StatusPanel = new StatusPanel(StatusWidth, StatusHeight)
        {
            Parent = this,
            Position = new(Engine.ScreenWidth - StatusWidth, 0)
        };

        //Create Monster Health Panel
        MonsterPanel = new MonsterHealthPanel(StatusWidth, Engine.ScreenHeight - StatusHeight)
        {
            Parent = this,
            Position = new(Engine.ScreenWidth - StatusWidth, StatusHeight)
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