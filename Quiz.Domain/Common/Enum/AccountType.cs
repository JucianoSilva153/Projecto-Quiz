namespace Quiz.Domain.Common.Enum;

public enum AccountType
{
    Admin,
    Creator,
    Player
}

public static class AccountTypeExtension
{
    public static string ToFriendlyString(this AccountType type)
    {
        return type switch
        {
            AccountType.Admin => "Administrador",
            AccountType.Creator => "Criador",
            AccountType.Player => "Jogador",
            _ => "Desconhecido"
        };
    }
}