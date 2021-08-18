using System.ComponentModel;

namespace CleanArch.Domain.Enums
{
    public enum FeedbackStatusEnum
    {
        [Description("Pendente de aprovação")]
        Pending = 0,

        [Description("Aprovado")]
        Approved = 1,

        [Description("Rejeitado")]
        Rejected = 2
    }
}