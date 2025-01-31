//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputContext {

    public InputEntity gameInputButtonEntity { get { return GetGroup(InputMatcher.GameInputButton).GetSingleEntity(); } }
    public Game.InputButtonComponent gameInputButton { get { return gameInputButtonEntity.gameInputButton; } }
    public bool hasGameInputButton { get { return gameInputButtonEntity != null; } }

    public InputEntity SetGameInputButton(Game.InputButton newInputButton, Game.InputState newInputState) {
        if (hasGameInputButton) {
            throw new Entitas.EntitasException("Could not set GameInputButton!\n" + this + " already has an entity with Game.InputButtonComponent!",
                "You should check if the context already has a gameInputButtonEntity before setting it or use context.ReplaceGameInputButton().");
        }
        var entity = CreateEntity();
        entity.AddGameInputButton(newInputButton, newInputState);
        return entity;
    }

    public void ReplaceGameInputButton(Game.InputButton newInputButton, Game.InputState newInputState) {
        var entity = gameInputButtonEntity;
        if (entity == null) {
            entity = SetGameInputButton(newInputButton, newInputState);
        } else {
            entity.ReplaceGameInputButton(newInputButton, newInputState);
        }
    }

    public void RemoveGameInputButton() {
        gameInputButtonEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public Game.InputButtonComponent gameInputButton { get { return (Game.InputButtonComponent)GetComponent(InputComponentsLookup.GameInputButton); } }
    public bool hasGameInputButton { get { return HasComponent(InputComponentsLookup.GameInputButton); } }

    public void AddGameInputButton(Game.InputButton newInputButton, Game.InputState newInputState) {
        var index = InputComponentsLookup.GameInputButton;
        var component = (Game.InputButtonComponent)CreateComponent(index, typeof(Game.InputButtonComponent));
        component.InputButton = newInputButton;
        component.InputState = newInputState;
        AddComponent(index, component);
    }

    public void ReplaceGameInputButton(Game.InputButton newInputButton, Game.InputState newInputState) {
        var index = InputComponentsLookup.GameInputButton;
        var component = (Game.InputButtonComponent)CreateComponent(index, typeof(Game.InputButtonComponent));
        component.InputButton = newInputButton;
        component.InputState = newInputState;
        ReplaceComponent(index, component);
    }

    public void RemoveGameInputButton() {
        RemoveComponent(InputComponentsLookup.GameInputButton);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherGameInputButton;

    public static Entitas.IMatcher<InputEntity> GameInputButton {
        get {
            if (_matcherGameInputButton == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.GameInputButton);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherGameInputButton = matcher;
            }

            return _matcherGameInputButton;
        }
    }
}
