using FluentMigrator;
using System;

namespace CleanArch.Infra.EF.Sql.Migrations.Feedbacks
{
    [Migration(202108140001, description: "Criando tabela de Feedback")]
    public class CreateFeedback : Migration
    {
        public override void Down()
        {
            Delete.Table("Feedback");
        }

        public override void Up()
        {
            Create.Table("Feedback")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Commentary").AsString().NotNullable()
                .WithColumn("Approved").AsBoolean().NotNullable();
        }
    }
}