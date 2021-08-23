using FluentMigrator;
using System;

namespace CleanArch.Infra.EF.Sql.Migrations.Feedbacks
{
    [Migration(202108140002, description: "Criando tabela de Feedback")]
    public class CreateUser : Migration
    {
        public override void Down()
        {
            Delete.Table("User");
        }

        public override void Up()
        {
            Create.Table("User")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString().NotNullable();
        }
    }
}