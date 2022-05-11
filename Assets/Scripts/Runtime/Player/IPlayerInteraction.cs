namespace Game.Player
{
    interface IPlayerInteraction
    {
        void StartUseMain();
        void StopUseMain();
        void StartUseSecond();
        void StopUseSecond();
        void QuickSelectItem(uint index);
        void UseSelectedItem();
    }
}