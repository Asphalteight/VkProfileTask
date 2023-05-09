using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VkTask.Host.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class Insert_states : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var query =
                $"INSERT INTO public.\"UserState\" (\"Code\", \"Description\") VALUES('Active', 'Данный статус показывает, что пользователь активен.')," +
                "('Blocked', 'Данный статус показывает, что пользователь удален или заблокирован.')";
            
            migrationBuilder.Sql(query);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
