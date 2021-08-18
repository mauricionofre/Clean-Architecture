using FluentMigrator;

namespace CleanArch.Infra.EF.Sql.Migrations.Feedbacks
{
    [Migration(202108140004, description: "Adicionando coluna Status, StatusDescription e CreatedAt na tabela Feedback")]
    public class AlterTableFeedbackAddStatus : Migration
    {
        public override void Down()
        {
            Delete.Column("Status").FromTable("Feedback");
            Delete.Column("StatusDescription").FromTable("Feedback");
            Delete.Column("CreatedAt").FromTable("Feedback");
        }

        public override void Up()
        {
            Alter.Table("Feedback")
                .AddColumn("Status")
                    .AsInt32()
                    .WithDefaultValue(0)
                    .NotNullable()
                .AddColumn("StatusDescription").AsString().Nullable()
                .AddColumn("CreatedAt")
                    .AsDateTime()
                    .WithDefaultValue("getdate()")
                    .NotNullable();

            Delete.Column("Approved").FromTable("Feedback");
        }
    }
}