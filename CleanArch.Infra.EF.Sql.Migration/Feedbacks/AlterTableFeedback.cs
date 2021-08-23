using FluentMigrator;
using System;

namespace CleanArch.Infra.EF.Sql.Migrations.Feedbacks
{
    [Migration(202108140003, description: "Adicionando coluna From e To UserId na tabela Feedback")]
    public class AlterTableFeedback : Migration
    {
        public override void Down()
        {
            Delete.Column("FromUserId").FromTable("Feedback");
            Delete.Column("ToUserId").FromTable("Feedback");
        }

        public override void Up()
        {
            Alter.Table("Feedback")
                .AddColumn("FromUserId").AsInt32().NotNullable()
                .AddColumn("ToUserId").AsInt32().NotNullable();
        }
    }
}