namespace Ankh_Morpork.PredefinedData
{
    /// <summary>
    /// Result of user and npc interaction
    /// </summary>
    public enum InteractionResult 
    {
        InteractionSuccessful,
        InteractionNotImplemented,
        InteractionCostNotAssigned,
        InsufficientBalance,
        RewardNotGuessed,
        AssasinIsOccupied,
        TooMuchThefts
    }
}
