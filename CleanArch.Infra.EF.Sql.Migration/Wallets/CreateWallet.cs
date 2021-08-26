using FluentMigrator;

namespace CleanArch.Infra.EF.Sql.Migrations.Feedbacks
{
    [Migration(202108250001, description: "Criando tabela Wallet")]
    public class CreateWallet : Migration
    {
        public override void Down()
        {
            Delete.Table("Wallet");
        }

        public override void Up()
        {
            Create.Table("Wallet")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("AvailableAmount").AsInt32().NotNullable()
                .WithColumn("Amount").AsInt32().NotNullable()
                .WithColumn("UserId").AsInt32().NotNullable();
        }
    }
}